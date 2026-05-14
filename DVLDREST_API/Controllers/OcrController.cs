using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DVLDREST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcrController : ControllerBase
    {
        private readonly IConfiguration _config;
        private static readonly HttpClient _httpClient = new HttpClient();

        // gemini-2.5-flash: the latest available model on the new 2026 API key
        private const string GeminiModel = "gemini-2.5-flash";

        public OcrController(IConfiguration config)
        {
            _config = config;
        }

        public class ScanIdRequestDTO
        {
            public string? ImageBase64 { get; set; }
            public string MimeType { get; set; } = "image/jpeg";
        }

        // POST /api/ocr/scan-id
        [HttpPost("scan-id")]
        public async Task<IActionResult> ScanId([FromBody] ScanIdRequestDTO request)
        {
            if (request == null || string.IsNullOrEmpty(request.ImageBase64))
                return BadRequest("Image data is required.");

            var apiKey = _config["GeminiApiKey"];
            if (string.IsNullOrEmpty(apiKey) || apiKey == "PASTE_YOUR_KEY_HERE")
                return StatusCode(503, "AI service is not configured. Please add your Gemini API key.");

            try
            {
                // Highly specific prompt tuned for the Ethiopian Digital ID Card layout.
                // The card has TWO sides:
                //   FRONT: Full Name (English), Date of Birth (Gregorian & Ethiopian), Sex, FAN number (below barcode)
                //   BACK:  Phone Number, Nationality, Address (multi-line: Region / Zone / City), FIN number
                // Instructions are bilingual-aware (Amharic labels + English labels on the card).
                var prompt = @"
You are an expert OCR system specialized in reading the Ethiopian Digital National ID Card (ብሄራዊ መታወቂያ ካርድ).

This card has a FRONT and a BACK side. You may receive one or both sides. Extract all available fields.

FRONT SIDE fields:
- Full Name: printed in English under the label 'Full Name' (ምሉዕ ስም)
- Date of Birth: use the GREGORIAN date only (the one in DD/MM/YYYY format, e.g. '04/01/1995'). Convert to YYYY-MM-DD format.
- Gender: printed under label 'Sex' (ፆታ) — value is 'Male' or 'Female'
- NationalID: ONLY extract the FAN number (printed as digits above or below the barcode on the FRONT, labeled 'FAN' or 'ካርድ ቁጥር'). Do NOT extract the FIN number from the back. If FAN is not present, return null.

BACK SIDE fields:
- Phone: the phone number under label 'Phone Number' (ስልክ) — include the country code (e.g. +251...)
- Nationality: the value under label 'Nationality' (ዜግነት) — typically 'Ethiopian'
- Address: combine all address lines into one string, separated by commas. The address is under label 'Address' (አድራሻ) and spans multiple lines (Region, Zone/Woreda, City).

IMPORTANT RULES:
1. Return ONLY a valid JSON object. No markdown, no explanation, no code blocks.
2. Use null for any field that is not clearly visible or not present in the provided image.
3. If only one side is provided, return null for fields from the missing side.
4. For the date, always output in YYYY-MM-DD format using the Gregorian calendar year.
5. For the FAN number, output only the digits with no spaces. NEVER use the FIN number.

Required JSON format:
{
  ""fullName"": ""string or null"",
  ""dateOfBirth"": ""YYYY-MM-DD or null"",
  ""gender"": ""Male or Female or null"",
  ""nationalId"": ""FAN digits only (never FIN), no spaces, or null"",
  ""phone"": ""+251... or null"",
  ""nationality"": ""string or null"",
  ""address"": ""Region, Zone, City combined or null""
}";

                var geminiRequest = new
                {
                    contents = new[]
                    {
                        new
                        {
                            parts = new object[]
                            {
                                new
                                {
                                    inline_data = new
                                    {
                                        mime_type = request.MimeType,
                                        data = request.ImageBase64
                                    }
                                },
                                new { text = prompt }
                            }
                        }
                    },
                    generationConfig = new
                    {
                        temperature = 0.0,   // Zero temperature = fully deterministic, maximally accurate
                        maxOutputTokens = 512,
                        responseMimeType = "application/json"  // Force JSON-only response (supported by gemini-2.0-flash)
                    }
                };

                var jsonBody = JsonSerializer.Serialize(geminiRequest);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                var url = $"https://generativelanguage.googleapis.com/v1beta/models/{GeminiModel}:generateContent?key={apiKey}";
                var response = await _httpClient.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorBody = await response.Content.ReadAsStringAsync();
                    return StatusCode(502, $"Gemini API error ({response.StatusCode}): {errorBody}");
                }

                var responseBody = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(responseBody);

                // Navigate the Gemini response to extract the generated text
                var text = doc.RootElement
                    .GetProperty("candidates")[0]
                    .GetProperty("content")
                    .GetProperty("parts")[0]
                    .GetProperty("text")
                    .GetString() ?? "";

                // Defensive clean-up in case model wraps in markdown despite responseMimeType
                text = text.Trim();
                if (text.StartsWith("```"))
                {
                    var firstNewline = text.IndexOf('\n');
                    if (firstNewline >= 0) text = text.Substring(firstNewline + 1);
                    var lastFence = text.LastIndexOf("```");
                    if (lastFence >= 0) text = text.Substring(0, lastFence).Trim();
                }

                using var extracted = JsonDocument.Parse(text);
                var root = extracted.RootElement;

                return Ok(new
                {
                    fullName    = SafeString(root, "fullName"),
                    dateOfBirth = SafeString(root, "dateOfBirth"),
                    gender      = SafeString(root, "gender"),
                    nationalId  = SafeString(root, "nationalId"),
                    phone       = SafeString(root, "phone"),
                    nationality = SafeString(root, "nationality"),
                    address     = SafeString(root, "address")
                });
            }
            catch (JsonException)
            {
                // Gemini returned unparseable content — return empty result so Flutter shows "enter manually"
                return Ok(new
                {
                    fullName    = (string?)null,
                    dateOfBirth = (string?)null,
                    gender      = (string?)null,
                    nationalId  = (string?)null,
                    phone       = (string?)null,
                    nationality = (string?)null,
                    address     = (string?)null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal error: {ex.Message}");
            }
        }

        private static string? SafeString(JsonElement element, string property)
        {
            if (element.TryGetProperty(property, out var val) && val.ValueKind == JsonValueKind.String)
                return val.GetString();
            return null;
        }
    }
}
