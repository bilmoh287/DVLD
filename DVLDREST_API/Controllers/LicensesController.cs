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
