using DVLDDataAccessLayer.DTOs;
using DVLDBussinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DVLDREST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestsController : ControllerBase
    {
        [HttpGet("appointments/{localAppId}/{testTypeId}")]
        public IActionResult GetAppointments(int localAppId, int testTypeId)
        {
            DataTable dt = clsTestAppointments.GetApplicantTestAppointmentsPerTestType(localAppId, testTypeId);
            List<TestAppointmentDTO> appointments = new List<TestAppointmentDTO>();

            foreach (DataRow row in dt.Rows)
            {
                appointments.Add(new TestAppointmentDTO
                {
                    TestAppointmentID = (int)row["TestAppointmentID"],
                    AppointmentDate = (DateTime)row["AppointmentDate"],
                    PaidFees = (decimal)row["PaidFees"],
                    IsLocked = (bool)row["IsLocked"],
                    TestTypeID = testTypeId
                });
            }

            return Ok(appointments);
        }

        [HttpPost("schedule")]
        public IActionResult ScheduleTest([FromBody] TestScheduleRequestDTO request)
        {
            if (request == null) return BadRequest("Invalid request.");

            // Check if person has already passed this test type
            clsLocalDrivingLicenseApplication ldlApp = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationInfoByID(request.LocalDrivingLicenseApplicationID);
            if (ldlApp == null) return NotFound("Application not found.");

            if (ldlApp.DoesPassTestType((clsTestTypes.enTestType)request.TestTypeID))
            {
                return BadRequest("Applicant already passed this test.");
            }

            // Check for active scheduled tests
            if (ldlApp.IsThereAnActiveScheduledTest(request.TestTypeID))
            {
                return BadRequest("Applicant already has an active scheduled test for this type.");
            }

            clsTestAppointments appointment = new clsTestAppointments();
            appointment.TestTypeID = request.TestTypeID;
            appointment.LocalDrivingLicenseApplicationID = request.LocalDrivingLicenseApplicationID;
            appointment.AppointmentDate = request.AppointmentDate;
            appointment.PaidFees = clsTestTypes.Find((clsTestTypes.enTestType)request.TestTypeID).TestTypeFees;
            appointment.CreatedByUserID = request.CreatedByUserID;
            appointment.IsLocked = false;

            if (appointment.Save())
            {
                return Ok(new { Message = "Test scheduled successfully.", AppointmentID = appointment.TestAppointmentID });
            }

            return StatusCode(500, "Error occurred while scheduling the test.");
        }

        [HttpGet("results/{localAppId}")]
        public IActionResult GetTestResults(int localAppId)
        {
            // Fetch all tests for this application
            // This logic is simplified: in a real app, you'd have a BLL method to get all results for an LDLA.
            // Using a placeholder query for now.
            DataTable dt = clsTests.GetAllTests(); 
            List<TestResultDTO> results = new List<TestResultDTO>();

            foreach (DataRow row in dt.Rows)
            {
                // We need to check if the test appointment belongs to this LDLA
                int appointmentID = (int)row["TestAppointmentID"];
                clsTestAppointments appt = clsTestAppointments.Find(appointmentID);
                
                if (appt != null && appt.LocalDrivingLicenseApplicationID == localAppId)
                {
                    results.Add(new TestResultDTO
                    {
                        TestID = (int)row["TestID"],
                        TestResult = (bool)row["TestResult"],
                        Notes = row["Notes"].ToString(),
                        TestDate = appt.AppointmentDate,
                        TestTypeTitle = clsTestTypes.Find((clsTestTypes.enTestType)appt.TestTypeID).TestTypeTitle
                    });
                }
            }

            return Ok(results);
        }
    }
}
