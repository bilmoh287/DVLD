using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DVLDBussinessLayer;
using Microsoft.AspNetCore.Authorization;

namespace DVLDREST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InternationalLicensesController : ControllerBase
    {
        // GET /api/internationallicenses/person/{personId}
        [HttpGet("person/{personId}")]
        public IActionResult GetPersonInternationalLicenses(int personId)
        {
            clsDrivers driver = clsDrivers.FindByPersonID(personId);
            if (driver == null) return Ok(new List<object>());

            DataTable dt = clsInternationalLicenses.GetDriverInternationalLicenses(driver.DriverID);
            List<object> licenses = new List<object>();

            foreach (DataRow row in dt.Rows)
            {
                licenses.Add(new
                {
                    InternationalLicenseID = (int)row["InternationalLicenseID"],
                    ApplicationID = (int)row["ApplicationID"],
                    IssuedUsingLocalLicenseID = (int)row["IssuedUsingLocalLicenseID"],
                    IssueDate = (DateTime)row["IssueDate"],
                    ExpirationDate = (DateTime)row["ExpirationDate"],
                    IsActive = (bool)row["IsActive"]
                });
            }

            return Ok(licenses);
        }

        // POST /api/internationallicenses/issue
        [HttpPost("issue")]
        public IActionResult IssueInternationalLicense([FromBody] IssueInternationalRequest request)
        {
            if (request == null) return BadRequest("Invalid request.");

            // 1. Find Local License
            clsLicenses localLicense = clsLicenses.Find(request.LocalLicenseID);
            if (localLicense == null) return NotFound("Local license not found.");

            // 2. Check if local license is active
            if (!localLicense.IsActive) return BadRequest("Local license is not active.");

            // 3. Check if local license is Class 3 (Ordinary)
            // Note: In DVLD database, Class 3 is usually the Ordinary Driving License
            if (localLicense.LicenseClass != 3) 
                return BadRequest("International license can only be issued for Class 3 (Ordinary) local licenses.");

            // 4. Check if driver already has an active international license
            int activeIntLicenseID = clsInternationalLicenses.GetActiveInternationalLicenseIDByDriverID(localLicense.DriverID);
            if (activeIntLicenseID != -1)
            {
                return Conflict(new { 
                    message = "Person already has an active international license.",
                    activeInternationalLicenseID = activeIntLicenseID
                });
            }

            // 5. Create Application
            clsInternationalLicenses intLicense = new clsInternationalLicenses();
            intLicense.ApplicantPersonID = localLicense.DriverInfo.PersonInfo.PersonID;
            intLicense.ApplicationDate = DateTime.Now;
            intLicense.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            intLicense.LastStatusDate = DateTime.Now;
            intLicense.PaidFees = clsApplicationTypes.FindApplicationType((int)clsApplication.enApplicationType.NewInternationalLicense).ApplicationTypeFees;
            intLicense.CreatedByUserID = request.CreatedByUserID;

            intLicense.DriverID = localLicense.DriverID;
            intLicense.IssuedUsingLocalLicenseID = localLicense.LicenseID;
            intLicense.IssueDate = DateTime.Now;
            intLicense.ExpirationDate = DateTime.Now.AddYears(1); // International licenses are usually 1 year
            intLicense.IsActive = true;

            if (intLicense.SaveInternationa())
            {
                // Notify
                try
                {
                    clsUserMessage.SendSystemMessage(intLicense.ApplicantPersonID, "International License Issued", 
                        $"Your International Driving License (ID: {intLicense.InternationalLicenseID}) has been issued successfully based on your local license #{localLicense.LicenseID}.", "License");
                }
                catch (Exception) { }

                return Ok(intLicense);
            }

            return StatusCode(500, "Error occurred while issuing international license.");
        }

        public class IssueInternationalRequest
        {
            public int LocalLicenseID { get; set; }
            public int CreatedByUserID { get; set; }
        }
    }
}
