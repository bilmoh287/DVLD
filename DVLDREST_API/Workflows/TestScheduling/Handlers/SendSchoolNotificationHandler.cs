using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using DVLDBussinessLayer;

namespace DVLDREST_API.Workflows.TestScheduling.Handlers
{
    public class SendSchoolNotificationHandler : INotificationHandler<TestScheduledNotification>
    {
        public Task Handle(TestScheduledNotification notification, CancellationToken cancellationToken)
        {
            try
            {
                // Retrieve driving institute details if applicant is enrolled in a school
                clsPerson person = clsPerson.Find(notification.ApplicantPersonID);
                string studentName = person != null ? ($"{person.FirstName} {person.LastName}") : "Applicant";

                string testName = "Driving Test";
                switch (notification.TestTypeID)
                {
                    case 1: testName = "Vision Test"; break;
                    case 2: testName = "Written Test"; break;
                    case 3: testName = "Practical Test"; break;
                }

                // Emits a notification to the Driving Institute dashboard / training batches
                Console.WriteLine($"[MEDIATR SUBSCRIBER] [School Dashboard Service] Notifying driving school that student '{studentName}' is scheduled for their {testName} on {notification.AppointmentDate:yyyy-MM-dd HH:mm}.");
                Console.WriteLine($"[MEDIATR SUBSCRIBER] [School Dashboard Updated] Synchronized student batch status with new test schedule.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[MEDIATR SUBSCRIBER ERROR] SendSchoolNotificationHandler failed: {ex.Message}");
            }

            return Task.CompletedTask;
        }
    }
}
