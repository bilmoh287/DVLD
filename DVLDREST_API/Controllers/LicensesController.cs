using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DVLDBussinessLayer;
using DVLDDataAccessLayer.DTOs;

namespace DVLDREST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicensesController : ControllerBase
    {
        public class RenewLicenseRequestDTO
        {
            public int LicenseID { get; set; }
            public string Notes { get; set; }
            public int CreatedByUserID { get; set; }
        }

        public class ReplaceLicenseRequestDTO
        {
            public int LicenseID { get; set; }
            public string Notes { get; set; }
            public int CreatedByUserID { get; set; }
            public int ReplacementReason { get; set; } // 3 = Damaged, 4 = Lost
        }

        // POST /api/licenses/issue
        [HttpPost("issue")]
        public IActionResult IssueLicense([FromBody] IssueLicenseRequestDTO request)
        {
            if (request == null) return BadRequest("Invalid request.");

            clsLocalDrivingLicenseApplication ldlApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationInfoByID(request.LocalDrivingLicenseApplicationID);
            if (ldlApplication == null) return NotFound("Local Driving License Application not found.");

            // Check if all tests passed
            if (!ldlApplication.PassedAllTest(ldlApplication.LocalDrivingLicenseApplicationID))
            {
                return BadRequest("Applicant has not passed all required tests.");
            }

            // Check if license already issued
            if (ldlApplication.IsLicenseIssued())
            {
                return BadRequest("License already issued for this application.");
            }

            // Note: Typos in Business Layer are preserved (Firt instead of First)
            int licenseID = ldlApplication.IssueLicenseForTheFirtTime(request.Notes, request.CreatedByUserID);

            if (licenseID != -1)
            {
                return Ok(new { message = "License issued successfully.", licenseID = licenseID });
            }

            return StatusCode(500, "Error issuing license.");
        }

        [HttpPost("renew")]
        public IActionResult RenewLicense([FromBody] RenewLicenseRequestDTO request)
        {
            if (request == null) return BadRequest("Invalid request.");

            clsLicenses oldLicense = clsLicenses.Find(request.LicenseID);
            if (oldLicense == null) return NotFound("License not found.");

            if (!oldLicense.IsActive) return BadRequest("Cannot renew an inactive license.");
            if (!oldLicense.IsLicenseExpired()) return BadRequest("License is not expired yet.");

            clsLicenses newLicense = oldLicense.RenewDrivingLicense(request.Notes, request.CreatedByUserID);

            if (newLicense != null)
            {
                // Find the application that was just created to get the fee
                clsApplication app = clsApplication.Find(newLicense.ApplicationID);
                decimal paidFees = app != null ? app.PaidFees : 0;

                return Ok(new { 
                    message = "License renewed successfully.", 
                    licenseID = newLicense.LicenseID,
                    applicationID = newLicense.ApplicationID,
                    paidFees = paidFees
                });
            }
            else
            {
                return StatusCode(500, "Error renewing license.");
            }
        }

        [HttpPost("replace")]
        public IActionResult ReplaceLicense([FromBody] ReplaceLicenseRequestDTO request)
        {
            if (request == null) return BadRequest("Invalid request.");

            clsLicenses oldLicense = clsLicenses.Find(request.LicenseID);
            if (oldLicense == null) return NotFound("License not found.");

            if (!oldLicense.IsActive) return BadRequest("Cannot replace an inactive license.");

            clsLicenses.enIssueReason reason = (clsLicenses.enIssueReason)request.ReplacementReason;
            if (reason != clsLicenses.enIssueReason.ReplacementForDamaged && reason != clsLicenses.enIssueReason.ReplacementForLost)
            {
                return BadRequest("Invalid replacement reason.");
            }

            clsLicenses newLicense = oldLicense.Replace((clsLicenses.enIssueReason)request.ReplacementReason, request.CreatedByUserID);

            if (newLicense != null)
            {
                clsApplication app = clsApplication.Find(newLicense.ApplicationID);
                decimal paidFees = app != null ? app.PaidFees : 0;

                return Ok(new { 
                    message = "License replaced successfully.", 
                    licenseID = newLicense.LicenseID,
                    applicationID = newLicense.ApplicationID,
                    paidFees = paidFees
                });
            }
            else
            {
                return StatusCode(500, "Error replacing license.");
            }
        }


        public class ApplyForRenewalRequestDTO
        {
            public int LicenseID { get; set; }
            public int CreatedByUserID { get; set; }
            public string ImageBase64 { get; set; }
        }

        [HttpPost("apply-renewal")]
        public IActionResult ApplyForRenewal([FromBody] ApplyForRenewalRequestDTO request)
        {
            if (request == null) return BadRequest(new { message = "Invalid request." });

            clsLicenses oldLicense = clsLicenses.Find(request.LicenseID);
            if (oldLicense == null) return NotFound(new { message = "License not found." });

            if (!oldLicense.IsActive) return BadRequest(new { message = "Cannot renew an inactive license." });
            if (!oldLicense.IsLicenseExpired()) return BadRequest(new { message = "License is not expired yet." });

            // Apply for renewal without issuing the license
            clsApplication application = oldLicense.ApplyForRenewal("", request.CreatedByUserID);

            if (application != null)
            {
                // Save image and update application
                string imagePath = SaveImageToDisk(request.ImageBase64, application.ApplicationID, "OldLicense");
                application.SaveDocuments(imagePath, "", "", "");

                return Ok(new { 
                    message = "Application submitted successfully.", 
                    applicationID = application.ApplicationID
                });
            }
            return StatusCode(500, new { message = "Error submitting renewal application." });
        }

        [HttpPost("apply-replacement-damaged")]
        public IActionResult ApplyForReplacementDamaged([FromBody] ApplyForRenewalRequestDTO request)
        {
            if (request == null) return BadRequest(new { message = "Invalid request." });

            clsLicenses oldLicense = clsLicenses.Find(request.LicenseID);
            if (oldLicense == null) return NotFound(new { message = "License not found." });

            if (!oldLicense.IsActive) return BadRequest(new { message = "Cannot replace an inactive license." });

            clsApplication application = oldLicense.ApplyForReplacementDamaged("", request.CreatedByUserID);

            if (application != null)
            {
                string imagePath = SaveImageToDisk(request.ImageBase64, application.ApplicationID, "DamagedLicense");
                application.SaveDocuments(imagePath, "", "", "");

                return Ok(new { 
                    message = "Application submitted successfully.", 
                    applicationID = application.ApplicationID
                });
            }
            return StatusCode(500, new { message = "Error submitting replacement application." });
        }

        [HttpPost("apply-replacement-lost")]
        public IActionResult ApplyForReplacementLost([FromBody] ApplyForRenewalRequestDTO request)
        {
            if (request == null) return BadRequest(new { message = "Invalid request." });

            clsLicenses oldLicense = clsLicenses.Find(request.LicenseID);
            if (oldLicense == null) return NotFound(new { message = "License not found." });

            if (!oldLicense.IsActive) return BadRequest(new { message = "Cannot replace an inactive license." });

            clsApplication application = oldLicense.ApplyForReplacementLost("", request.CreatedByUserID);

            if (application != null)
            {
                if (!string.IsNullOrEmpty(request.ImageBase64))
                {
                    string imagePath = SaveImageToDisk(request.ImageBase64, application.ApplicationID, "LostLicenseReport");
                    application.SaveDocuments(imagePath, "", "", "");
                }

                return Ok(new { 
                    message = "Application submitted successfully.", 
                    applicationID = application.ApplicationID
                });
            }
            return StatusCode(500, new { message = "Error submitting replacement application." });
        }



        private string SaveImageToDisk(string base64String, int applicationId, string docType)
        {
            if (string.IsNullOrEmpty(base64String)) return null;

            try
            {
                string folderPath = @"C:\DVLD_Uploads\Applications";
                if (!System.IO.Directory.Exists(folderPath))
                {
                    System.IO.Directory.CreateDirectory(folderPath);
                }

                if (base64String.Contains(","))
                {
                    base64String = base64String.Substring(base64String.IndexOf(",") + 1);
                }

                byte[] imageBytes = Convert.FromBase64String(base64String);
                string fileName = $"APP_{applicationId}_{docType}_{Guid.NewGuid().ToString("N")}.jpg";
                string fullPath = System.IO.Path.Combine(folderPath, fileName);

                System.IO.File.WriteAllBytes(fullPath, imageBytes);
                return fullPath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving image for Application {applicationId}: {ex.Message}");
                return null;
            }
        }

        // GET /api/licenses/person/{personId}
        [HttpGet("person/{personId}")]
        public IActionResult GetPersonLicenses(int personId)
        {
            DataTable dt = clsLicenses.GetPersonLicenses(personId);
            var licenses = new List<object>();

            foreach (DataRow row in dt.Rows)
            {
                int licenseID = (int)row["LicenseID"];
                licenses.Add(new
                {
                    LicenseID = licenseID,
                    ApplicationID = (int)row["ApplicationID"],
                    ClassName = (string)row["ClassName"],
                    IssueDate = (DateTime)row["IssueDate"],
                    ExpirationDate = (DateTime)row["ExpirationDate"],
                    IsActive = (bool)row["IsActive"],
                    IsDetained = clsDetainedLicenses.IsLicenseDetained(licenseID)
                });
            }

            return Ok(licenses);
        }
        
        // GET /api/licenses/{licenseId}
        [HttpGet("{licenseId}")]
        public IActionResult GetLicenseInfo(int licenseId)
        {
            clsLicenses license = clsLicenses.Find(licenseId);
            if (license == null) return NotFound("License not found.");

            return Ok(new {
                license.LicenseID,
                license.ApplicationID,
                license.DriverID,
                license.LicenseClass,
                ClassName = license.LicenseClassInfo?.ClassName ?? "Unknown",
                license.IssueDate,
                license.ExpirationDate,
                license.Notes,
                license.PaidFees,
                license.IsActive,
                IssueReason = license.IssueReasonText,
                license.CreatedByUserID
            });
        }
    }
}
