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
    [Authorize]
    public class TestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

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
        public async Task<IActionResult> ScheduleTest([FromBody] TestScheduleRequestDTO request)
        {
            if (request == null) return BadRequest("Invalid request.");

            var command = new ScheduleTestCommand
            {
                LocalDrivingLicenseApplicationID = request.LocalDrivingLicenseApplicationID,
                TestTypeID = request.TestTypeID,
                AppointmentDate = request.AppointmentDate,
                CreatedByUserID = request.CreatedByUserID
            };

            var result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                return Ok(new { Message = "Test scheduled successfully.", AppointmentID = result.AppointmentID });
            }

            return BadRequest(result.ErrorMessage);
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
