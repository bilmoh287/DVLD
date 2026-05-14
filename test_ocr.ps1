# ============================================================
# DVLD OCR Test Script - Ethiopian Digital ID Card Scanner
# Usage: Update $ImagePath below, then run in PowerShell
# ============================================================

# CHANGE THIS to the path of your Ethiopian ID card photo:
$ImagePath = "C:\Users\bilmo\Downloads\id_card.jpg"

# API endpoint
$ApiUrl = "http://localhost:5172/api/ocr/scan-id"

# --- Do NOT change below this line ---
if (-not (Test-Path $ImagePath)) {
    Write-Host "ERROR: Image not found at: $ImagePath" -ForegroundColor Red
    Write-Host "Please update the `$ImagePath variable in this script." -ForegroundColor Yellow
    exit 1
}

Write-Host ""
Write-Host "Reading image: $ImagePath" -ForegroundColor Cyan
$bytes  = [System.IO.File]::ReadAllBytes($ImagePath)
$b64    = [System.Convert]::ToBase64String($bytes)

$ext      = [System.IO.Path]::GetExtension($ImagePath).ToLower()
$mimeType = if ($ext -eq ".png") { "image/png" } else { "image/jpeg" }

$body = @{ imageBase64 = $b64; mimeType = $mimeType } | ConvertTo-Json -Depth 3

Write-Host "Sending to Gemini AI via $ApiUrl ..." -ForegroundColor Cyan

try {
    $result = Invoke-RestMethod `
        -Uri         $ApiUrl `
        -Method      POST `
        -ContentType "application/json" `
        -Body        $body

    Write-Host ""
    Write-Host "========================================" -ForegroundColor Green
    Write-Host "   AI SCAN RESULT" -ForegroundColor Green
    Write-Host "========================================" -ForegroundColor Green
    Write-Host "Full Name    : $($result.fullName)"    -ForegroundColor White
    Write-Host "Date of Birth: $($result.dateOfBirth)" -ForegroundColor White
    Write-Host "Gender       : $($result.gender)"      -ForegroundColor White
    Write-Host "FAN (Nat. ID): $($result.nationalId)"  -ForegroundColor White
    Write-Host "Phone        : $($result.phone)"       -ForegroundColor White
    Write-Host "Nationality  : $($result.nationality)" -ForegroundColor White
    Write-Host "Address      : $($result.address)"     -ForegroundColor White
    Write-Host "========================================" -ForegroundColor Green
    Write-Host ""

} catch {
    Write-Host ""
    Write-Host "ERROR calling API: $_" -ForegroundColor Red
    Write-Host "Make sure the API is running at http://localhost:5172" -ForegroundColor Yellow
}
