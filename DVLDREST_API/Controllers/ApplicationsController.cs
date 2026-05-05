using DVLDDataAccessLayer.DTOs;
using DVLDBussinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DVLDREST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Requires JWT token for all endpoints
    public class ApplicationsController : ControllerBase
    {
        [HttpGet("classes")]
        public IActionResult GetAllLicenseClasses()
        {
            DataTable dt = clsLicenseClasses.GetAllLicenseClasses();
            List<LicenseClassDTO> classes = new List<LicenseClassDTO>();

            foreach (DataRow row in dt.Rows)
            {
                classes.Add(new LicenseClassDTO(
                    (int)row["LicenseClassID"],
                    (string)row["ClassName"],
                    (string)row["ClassDescription"],
                    (byte)row["MinimumAllowedAge"],
                    (byte)row["DefaultValidityLength"],
                    (decimal)row["ClassFees"]
                ));
            }

            return Ok(classes);
        }

        [HttpPost("new-local")]
        public IActionResult CreateLocalApplication([FromBody] NewApplicationRequestDTO request)
        {
            if (request == null) return BadRequest("Invalid request.");

            // Standard Application Type ID for 'New Local Driving License' is 1
            int newLocalAppTypeID = 1; 

            // 0. Verify the Person exists
            clsPerson person = clsPerson.Find(request.ApplicantPersonID);
            if (person == null)
            {
                return BadRequest(new { message = $"Person with ID {request.ApplicantPersonID} not found." });
            }

            // 1. Check if the user has an active application for the same license class
            // Using explicit (int) cast and literal check
            int activeApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(
                request.ApplicantPersonID, 
                (clsApplication.enApplicationType)newLocalAppTypeID, 
                request.LicenseClassID);

            if (activeApplicationID != -1)
            {
                return Conflict(new { 
                    message = "A person already has an active application for this license class.",
                    activeApplicationID = activeApplicationID,
                    personID = request.ApplicantPersonID,
                    licenseClassID = request.LicenseClassID
                });
            }

            // 2. Check if user already has a license of the same class
            if (clsLicenses.IsLicenseExistByPersonIDAndClassID(request.ApplicantPersonID, request.LicenseClassID))
            {
                return BadRequest(new { message = "Person already has an active license for this class." });
            }

            // 3. Age Validation
            clsLicenseClasses licenseClass = clsLicenseClasses.Find(request.LicenseClassID);

            if (licenseClass != null && person != null)
            {
                int applicantAge = DateTime.Now.Year - person.DateOfBirth.Year;
                if (person.DateOfBirth > DateTime.Now.AddYears(-applicantAge)) applicantAge--; // Precision adjustment

                if (applicantAge < licenseClass.MinimumAllowedAge)
                {
                    return BadRequest($"Person is too young for this license class. Minimum age required: {licenseClass.MinimumAllowedAge}.");
                }
            }

            clsLocalDrivingLicenseApplication application = new clsLocalDrivingLicenseApplication();
            application.ApplicantPersonID = request.ApplicantPersonID;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationTypeID = newLocalAppTypeID;
            application.ApplicationStatus = clsApplication.enApplicationStatus.New;
            application.LastStatusDate = DateTime.Now;
            application.PaidFees = clsApplicationTypes.FindApplicationType(newLocalAppTypeID).ApplicationTypeFees;
            application.CreatedByUserID = 1; // Default to Admin/System
            application.LicenseClassID = request.LicenseClassID;
            application.InstituteID = request.DrivingInstituteID;

            if (application.SaveLDLA())
            {
                return CreatedAtAction(nameof(GetApplicationStatus), new { personId = request.ApplicantPersonID }, application);
            }

            return StatusCode(500, "Error occurred while saving the application.");
        }

        // GET /api/applications/institutes — Returns ALL institutes, no filter
        [HttpGet("institutes")]
        public IActionResult GetAllInstitutes()
        {
            DataTable dt = clsDrivingInstitute.GetAllInstitutes();
            List<DrivingInstituteDTO> institutes = new List<DrivingInstituteDTO>();

            foreach (DataRow row in dt.Rows)
            {
                institutes.Add(new DrivingInstituteDTO(
                    (int)row["InstituteID"],
                    (string)row["InstituteName"],
                    (string)row["Address"],
                    (string)row["Phone"],
                    row["Email"]?.ToString() ?? "",
                    (bool)row["IsActive"],
                    (int)row["CreatedByUserID"],
                    row["CommercialLicenseNo"]?.ToString() ?? "",
                    (DateTime)row["LicenseExpiryDate"],
                    row["ManagerName"]?.ToString() ?? "",
                    (int)row["Capacity"],
                    row["LogoPath"]?.ToString() ?? "",
                    row["DocumentPath"]?.ToString() ?? "",
                    row["City"]?.ToString() ?? "",
                    row["Region"]?.ToString() ?? ""
                ));
            }

            return Ok(institutes);
        }

        // GET /api/applications/institutes/filter?city=Amman&region=East — Filtered list
        [HttpGet("institutes/filter")]
        public IActionResult GetFilteredInstitutes([FromQuery] string? city = null, [FromQuery] string? region = null)
        {
            DataTable dt = clsDrivingInstitute.GetAllInstitutes();
            List<DrivingInstituteDTO> institutes = new List<DrivingInstituteDTO>();

            foreach (DataRow row in dt.Rows)
            {
                string rowCity = row["City"]?.ToString() ?? "";
                string rowRegion = row["Region"]?.ToString() ?? "";

                if (!string.IsNullOrEmpty(city) && !rowCity.Equals(city, StringComparison.OrdinalIgnoreCase)) continue;
                if (!string.IsNullOrEmpty(region) && !rowRegion.Equals(region, StringComparison.OrdinalIgnoreCase)) continue;

                institutes.Add(new DrivingInstituteDTO(
                    (int)row["InstituteID"],
                    (string)row["InstituteName"],
                    (string)row["Address"],
                    (string)row["Phone"],
                    row["Email"]?.ToString() ?? "",
                    (bool)row["IsActive"],
                    (int)row["CreatedByUserID"],
                    row["CommercialLicenseNo"]?.ToString() ?? "",
                    (DateTime)row["LicenseExpiryDate"],
                    row["ManagerName"]?.ToString() ?? "",
                    (int)row["Capacity"],
                    row["LogoPath"]?.ToString() ?? "",
                    row["DocumentPath"]?.ToString() ?? "",
                    rowCity,
                    rowRegion
                ));
            }

            return Ok(institutes);
        }

        // GET /api/applications/institutes/filters — Returns distinct cities & regions for dropdowns
        [HttpGet("institutes/filters")]
        public IActionResult GetInstituteFilters()
        {
            DataTable dt = clsDrivingInstitute.GetAllInstitutes();
            var cities = dt.AsEnumerable()
                           .Select(r => r.Field<string>("City"))
                           .Where(c => !string.IsNullOrEmpty(c))
                           .Distinct()
                           .OrderBy(c => c)
                           .ToList();

            var regions = dt.AsEnumerable()
                            .Select(r => r.Field<string>("Region"))
                            .Where(r => !string.IsNullOrEmpty(r))
                            .Distinct()
                            .OrderBy(r => r)
                            .ToList();

            return Ok(new { Cities = cities, Regions = regions });
        }

        // GET /api/applications/status/{personId} — Application status for a person
        [HttpGet("status/{personId}")]
        public IActionResult GetApplicationStatus(int personId)
        {
            DataTable dt = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLiceseApplications();
            List<ApplicationStatusResponseDTO> results = new List<ApplicationStatusResponseDTO>();

            foreach (DataRow row in dt.Rows)
            {
                // The view exposes PersonID from the Applications table (not ApplicantPersonID)
                object personIdObj = row["PersonID"];
                if (personIdObj == DBNull.Value || personIdObj == null) continue;
                if ((int)personIdObj != personId) continue;

                results.Add(new ApplicationStatusResponseDTO
                {
                    ApplicationID    = (int)row["ApplicationID"],
                    ClassName        = row["ClassName"]?.ToString() ?? "",
                    Status           = row["Status"]?.ToString() ?? "",
                    AppliedDate      = (DateTime)row["ApplicationDate"],
                    PassedExamsCount = 0
                });
            }

            return Ok(results);
        }
    }
}
