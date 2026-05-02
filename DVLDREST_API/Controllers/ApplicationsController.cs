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

            // Standard Application Type ID for 'New Local Driving License' is typically 1
            int newLocalAppTypeID = 1; 

            clsLocalDrivingLicenseApplication application = new clsLocalDrivingLicenseApplication();
            application.ApplicantPersonID = request.ApplicantPersonID;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationTypeID = newLocalAppTypeID;
            application.ApplicationStatus = clsApplication.enApplicationStatus.New;
            application.LastStatusDate = DateTime.Now;
            application.PaidFees = clsApplicationTypes.FindApplicationType(newLocalAppTypeID).ApplicationTypeFees;
            application.CreatedByUserID = 1; // Default to Admin for now, or extract from JWT claims
            application.LicenseClassID = request.LicenseClassID;
            application.InstituteID = request.DrivingInstituteID;

            if (application.SaveLDLA())
            {
                return CreatedAtAction(nameof(GetApplicationStatus), new { personId = request.ApplicantPersonID }, application);
            }

            return StatusCode(500, "Error occurred while saving the application.");
        }

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
                    (string)row["Email"],
                    (bool)row["IsActive"],
                    (int)row["CreatedByUserID"],
                    row["CommercialLicenseNo"]?.ToString() ?? "",
                    (DateTime)row["LicenseExpiryDate"],
                    row["ManagerName"]?.ToString() ?? "",
                    (int)row["Capacity"],
                    row["LogoPath"]?.ToString() ?? "",
                    row["DocumentPath"]?.ToString() ?? ""
                ));
            }

            return Ok(institutes);
        }

        [HttpGet("status/{personId}")]
        public IActionResult GetApplicationStatus(int personId)
        {
            // For now, we will query all applications for this person
            // and map them to our DTO. 
            // In a real scenario, we'd add a dedicated BLL method for this.
            
            // This is a placeholder logic using existing GetUnderReviewApplications filtered locally
            // Ideally, add GetApplicationsByPersonID to BLL.
            DataTable dt = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLiceseApplications();
            List<ApplicationStatusResponseDTO> results = new List<ApplicationStatusResponseDTO>();

            foreach (DataRow row in dt.Rows)
            {
                if ((int)row["ApplicantPersonID"] == personId)
                {
                    results.Add(new ApplicationStatusResponseDTO
                    {
                        ApplicationID = (int)row["ApplicationID"],
                        ClassName = (string)row["ClassName"],
                        Status = (string)row["Status"], // Assuming the view/table has Status as string or we map it
                        AppliedDate = (DateTime)row["ApplicationDate"],
                        PassedExamsCount = 0 // In real app, call clsTest.CountPassedTests
                    });
                }
            }

            return Ok(results);
        }
    }
}
