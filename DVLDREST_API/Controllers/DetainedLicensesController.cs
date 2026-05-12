using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DVLDBussinessLayer;

namespace DVLDREST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetainedLicensesController : ControllerBase
    {
        public class ReleaseRequestDTO
        {
            public int LicenseID { get; set; }
            public int CreatedByUserID { get; set; }
        }

        // GET /api/detainedlicenses/is-detained/{licenseId}
        [HttpGet("is-detained/{licenseId}")]
        public IActionResult IsLicenseDetained(int licenseId)
        {
            bool isDetained = clsDetainedLicenses.IsLicenseDetained(licenseId);
            return Ok(new { isDetained });
        }

        // GET /api/detainedlicenses/info/{licenseId}
        [HttpGet("info/{licenseId}")]
        public IActionResult GetDetainInfo(int licenseId)
        {
            clsDetainedLicenses detainInfo = clsDetainedLicenses.FindByLicenseID(licenseId);
            if (detainInfo == null) return NotFound("No detention record found for this license.");

            return Ok(new
            {
                detainInfo.DetainID,
                detainInfo.LicenseID,
                detainInfo.DetainDate,
                detainInfo.FineFees,
                detainInfo.IsReleased,
                detainInfo.ReleaseDate,
                detainInfo.ReleaseApplicationID,
                detainInfo.DetainReason,
                detainInfo.DetainPlace
            });
        }

        // POST /api/detainedlicenses/release
        [HttpPost("release")]
        public IActionResult ReleaseLicense([FromBody] ReleaseRequestDTO request)
        {
            if (request == null) return BadRequest("Invalid request.");

            // 1. Check if license is actually detained
            if (!clsDetainedLicenses.IsLicenseDetained(request.LicenseID))
            {
                return BadRequest("License is not currently detained.");
            }

            clsDetainedLicenses detainInfo = clsDetainedLicenses.FindByLicenseID(request.LicenseID);
            if (detainInfo == null || detainInfo.IsReleased)
            {
                return BadRequest("License is not detained or already released.");
            }

            // 2. Find the person who owns the license to create the application
            clsLicenses license = clsLicenses.Find(request.LicenseID);
            if (license == null) return NotFound("License not found.");
            
            clsDrivers driver = clsDrivers.Find(license.DriverID);
            if (driver == null) return NotFound("Driver not found.");

            // 3. Create Release Application
            clsApplication releaseApp = new clsApplication();
            releaseApp.ApplicantPersonID = driver.PersonID;
            releaseApp.ApplicationDate = DateTime.Now;
            releaseApp.ApplicationTypeID = (int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense;
            releaseApp.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            releaseApp.LastStatusDate = DateTime.Now;
            releaseApp.CreatedByUserID = request.CreatedByUserID;
            
            clsApplicationTypes appType = clsApplicationTypes.FindApplicationType((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense);
            releaseApp.PaidFees = appType.ApplicationTypeFees + detainInfo.FineFees;

            if (releaseApp.Save())
            {
                // 4. Release the license
                if (detainInfo.Release(request.CreatedByUserID, releaseApp.ApplicationID))
                {
                    return Ok(new { 
                        message = "License released successfully.", 
                        releaseApplicationID = releaseApp.ApplicationID,
                        detainID = detainInfo.DetainID 
                    });
                }
                else
                {
                    return StatusCode(500, "Error releasing license record.");
                }
            }

            return StatusCode(500, "Error creating release application.");
        }
    }
}
