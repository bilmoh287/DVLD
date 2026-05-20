using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DVLDREST_API.Workflows.TestScheduling.Handlers
{
    public class LogAuditTrailHandler : INotificationHandler<TestScheduledNotification>
    {
        public Task Handle(TestScheduledNotification notification, CancellationToken cancellationToken)
        {
            try
            {
                // Record the event in security / transaction audit logs
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                Console.WriteLine($"[MEDIATR SUBSCRIBER] [Audit Logger] [{timestamp}] TRANSACTION RECORDED:");
                Console.WriteLine($"  - Event Type: TestScheduled");
                Console.WriteLine($"  - Appointment ID: {notification.TestAppointmentID}");
                Console.WriteLine($"  - Local License Application ID: {notification.LocalDrivingLicenseApplicationID}");
                Console.WriteLine($"  - Scheduled Date: {notification.AppointmentDate:yyyy-MM-dd HH:mm:tt}");
                Console.WriteLine($"  - System Status: Decoupled broadcast successfully processed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[MEDIATR SUBSCRIBER ERROR] LogAuditTrailHandler failed: {ex.Message}");
            }

            return Task.CompletedTask;
        }
    }
}
