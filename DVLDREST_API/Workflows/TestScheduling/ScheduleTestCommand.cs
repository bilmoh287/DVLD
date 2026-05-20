using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using DVLDBussinessLayer;

namespace DVLDREST_API.Workflows.TestScheduling
{
    public class ScheduleTestCommand : IRequest<ScheduleTestResult>
    {
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int TestTypeID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int CreatedByUserID { get; set; }
    }

    public class ScheduleTestResult
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public int AppointmentID { get; set; }

        public static ScheduleTestResult Success(int appointmentId) => new ScheduleTestResult { IsSuccess = true, AppointmentID = appointmentId };
        public static ScheduleTestResult Failure(string message) => new ScheduleTestResult { IsSuccess = false, ErrorMessage = message };
    }

    public class ScheduleTestCommandHandler : IRequestHandler<ScheduleTestCommand, ScheduleTestResult>
    {
        private readonly IMediator _mediator;

        public ScheduleTestCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ScheduleTestResult> Handle(ScheduleTestCommand request, CancellationToken cancellationToken)
        {
            // Perform Business validations
            clsLocalDrivingLicenseApplication ldlApp = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationInfoByID(request.LocalDrivingLicenseApplicationID);
            if (ldlApp == null)
            {
                return ScheduleTestResult.Failure("Application not found.");
            }

            if (ldlApp.DoesPassTestType((clsTestTypes.enTestType)request.TestTypeID))
            {
                return ScheduleTestResult.Failure("Applicant already passed this test.");
            }

            if (ldlApp.IsThereAnActiveScheduledTest(request.TestTypeID))
            {
                return ScheduleTestResult.Failure("Applicant already has an active scheduled test for this type.");
            }

            // Create test appointment
            clsTestAppointments appointment = new clsTestAppointments();
            appointment.TestTypeID = request.TestTypeID;
            appointment.LocalDrivingLicenseApplicationID = request.LocalDrivingLicenseApplicationID;
            appointment.AppointmentDate = request.AppointmentDate;
            
            var testType = clsTestTypes.Find((clsTestTypes.enTestType)request.TestTypeID);
            if (testType == null)
            {
                return ScheduleTestResult.Failure("Invalid test type.");
            }
            appointment.PaidFees = testType.TestTypeFees;
            appointment.CreatedByUserID = request.CreatedByUserID;
            appointment.IsLocked = false;

            if (appointment.Save())
            {
                // Decoupled Event Publication!
                // Publish domain event/notification so all handlers (Mobile, SMS, Email, School, Audit) can execute asynchronously
                await _mediator.Publish(new TestScheduledNotification(
                    appointment.TestAppointmentID,
                    appointment.LocalDrivingLicenseApplicationID,
                    appointment.TestTypeID,
                    appointment.AppointmentDate,
                    ldlApp.ApplicantPersonID
                ), cancellationToken);

                return ScheduleTestResult.Success(appointment.TestAppointmentID);
            }

            return ScheduleTestResult.Failure("Error occurred while saving the test appointment.");
        }
    }
}
