using DVLDDataAccessLayer.DTOs;
using DVLDBussinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using MediatR;
using DVLDREST_API.Workflows.TestScheduling;
using System.Threading.Tasks;

namespace DVLDREST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Requires JWT token for all endpoints
    public class ApplicationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApplicationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

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

                // Get LDLApplicationID for this record
                int ldlAppID = (int)row["LocalDrivingLicenseApplicationID"];

                results.Add(new ApplicationStatusResponseDTO
                {
                    ApplicationID    = (int)row["ApplicationID"],
                    LDLApplicationID = ldlAppID,
                    ClassName        = row["ClassName"]?.ToString() ?? "",
                    Status           = row["Status"]?.ToString() ?? "",
                    AppliedDate      = (DateTime)row["ApplicationDate"],
                    PassedExamsCount = clsTests.CountPassedTests(ldlAppID)
                });
            }

            return Ok(results);
        }
        // GET /api/applications/fees/{typeId} — Returns fee for a specific application type
        [HttpGet("fees/{typeId}")]
        public IActionResult GetApplicationFee(int typeId)
        {
            clsApplicationTypes appType = clsApplicationTypes.FindApplicationType(typeId);
            if (appType == null) return NotFound("Application type not found.");
            
            return Ok(new { 
                ApplicationTypeID = appType.ApplicationTypeID,
                ApplicationTypeTitle = appType.ApplicationTypeTitle,
                Fees = appType.ApplicationTypeFees 
            });
        }

        // GET /api/applications/test-history/{ldlAppId} — Returns all test attempts for an application
        [HttpGet("test-history/{ldlAppId}")]
        public IActionResult GetTestHistory(int ldlAppId)
        {
            DataTable dt = clsTests.GetTestHistoryByLDLAppID(ldlAppId);
            List<object> history = new List<object>();

            foreach (DataRow row in dt.Rows)
            {
                history.Add(new
                {
                    TestID = (int)row["TestID"],
                    TestType = row["TestTypeTitle"].ToString(),
                    Result = (bool)row["TestResult"] ? "Pass" : "Fail",
                    Notes = row["Notes"].ToString(),
                    Date = (DateTime)row["AppointmentDate"]
                });
            }

            return Ok(history);
        }

        // POST /api/applications/approve/{ldlAppId}
        [HttpPost("approve/{ldlAppId}")]
        public IActionResult ApproveApplication(int ldlAppId)
        {
            clsLocalDrivingLicenseApplication application = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationInfoByID(ldlAppId);
            if (application == null) return NotFound("Application not found.");

            if (application.Approve()) return Ok(new { message = "Application Approved successfully." });
            return StatusCode(500, "Error approving application.");
        }

        // POST /api/applications/reject/{ldlAppId}
        [HttpPost("reject/{ldlAppId}")]
        public IActionResult RejectApplication(int ldlAppId)
        {
            clsLocalDrivingLicenseApplication application = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationInfoByID(ldlAppId);
            if (application == null) return NotFound("Application not found.");

            if (application.Reject()) return Ok(new { message = "Application Rejected successfully." });
            return StatusCode(500, "Error rejecting application.");
        }
        // GET /api/applications/next-test/{ldlAppId}
        [HttpGet("next-test/{ldlAppId}")]
        public IActionResult GetNextTest(int ldlAppId)
        {
            clsLocalDrivingLicenseApplication application = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationInfoByID(ldlAppId);
            if (application == null) return NotFound("Application not found.");

            int nextTestId = 0;
            string nextTestTitle = "All Tests Passed";
            bool isScheduled = false;

            if (!application.DoesPassTestType(clsTestTypes.enTestType.VisionTest))
            {
                nextTestId = 1;
                nextTestTitle = "Vision Test";
                isScheduled = application.IsThereAnActiveScheduledTest(1);
            }
            else if (!application.DoesPassTestType(clsTestTypes.enTestType.WrittenTest))
            {
                nextTestId = 2;
                nextTestTitle = "Written Test";
                isScheduled = application.IsThereAnActiveScheduledTest(2);
            }
            else if (!application.DoesPassTestType(clsTestTypes.enTestType.StreetTest))
            {
                nextTestId = 3;
                nextTestTitle = "Street Test";
                isScheduled = application.IsThereAnActiveScheduledTest(3);
            }

            return Ok(new { 
                NextTestTypeID = nextTestId, 
                NextTestTitle = nextTestTitle,
                IsScheduled = isScheduled
            });
        }

        // POST /api/applications/schedule-test
        [HttpPost("schedule-test")]
        public async Task<IActionResult> ScheduleTest([FromBody] ScheduleTestRequestDTO request)
        {
            if (request == null) return BadRequest("Invalid request.");

            clsLocalDrivingLicenseApplication ldlApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationInfoByID(request.LocalDrivingLicenseApplicationID);
            if (ldlApplication == null) return NotFound("Local Driving License Application not found.");

            // Check if there is an active scheduled test for the same test type
            if (ldlApplication.IsThereAnActiveScheduledTest(request.TestTypeID))
            {
                return BadRequest("Person already has an active scheduled test for this test type.");
            }

            // Check if person already passed this test
            if (ldlApplication.DoesPassTestType((clsTestTypes.enTestType)request.TestTypeID))
            {
                return BadRequest("Person already passed this test.");
            }

            clsTestAppointments appointment = new clsTestAppointments();
            appointment.LocalDrivingLicenseApplicationID = request.LocalDrivingLicenseApplicationID;
            appointment.TestTypeID = request.TestTypeID;
            appointment.AppointmentDate = request.AppointmentDate;
            appointment.CreatedByUserID = request.CreatedByUserID;
            
            clsTestTypes testType = clsTestTypes.Find((clsTestTypes.enTestType)request.TestTypeID);
            appointment.PaidFees = testType.TestTypeFees;

            // Check if it's a retake
            if (ldlApplication.TotalTrialsPerTest((clsTestTypes.enTestType)request.TestTypeID) > 0)
            {
                // Create Retake Application
                clsApplication retakeApp = new clsApplication();
                retakeApp.ApplicantPersonID = ldlApplication.ApplicantPersonID;
                retakeApp.ApplicationDate = DateTime.Now;
                retakeApp.ApplicationTypeID = (int)clsApplication.enApplicationType.RetakeTest;
                retakeApp.ApplicationStatus = clsApplication.enApplicationStatus.Completed; // Paid & closed immediately
                retakeApp.LastStatusDate = DateTime.Now;
                retakeApp.CreatedByUserID = request.CreatedByUserID;
                
                clsApplicationTypes retakeAppType = clsApplicationTypes.FindApplicationType((int)clsApplication.enApplicationType.RetakeTest);
                retakeApp.PaidFees = retakeAppType.ApplicationTypeFees;

                if (retakeApp.Save())
                {
                    appointment.RetakeTestApplicationID = retakeApp.ApplicationID;
                }
                else
                {
                    return StatusCode(500, "Error creating retake application.");
                }
            }

            if (appointment.Save())
            {
                // Publish domain event/notification so all handlers (Mobile, SMS, Email, School, Audit) can execute asynchronously
                await _mediator.Publish(new TestScheduledNotification(
                    appointment.TestAppointmentID,
                    appointment.LocalDrivingLicenseApplicationID,
                    appointment.TestTypeID,
                    appointment.AppointmentDate,
                    ldlApplication.ApplicantPersonID
                ));

                return Ok(new { message = "Test Scheduled successfully.", appointmentID = appointment.TestAppointmentID });
            }

            return StatusCode(500, "Error scheduling test.");
        }
    }
}
