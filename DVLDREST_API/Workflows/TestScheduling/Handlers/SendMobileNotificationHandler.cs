using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using DVLDBussinessLayer;

namespace DVLDREST_API.Workflows.TestScheduling.Handlers
{
    public class SendMobileNotificationHandler : INotificationHandler<TestScheduledNotification>
    {
        public Task Handle(TestScheduledNotification notification, CancellationToken cancellationToken)
        {
            try
            {
                string testName = "Driving Test";
                switch (notification.TestTypeID)
                {
                    case 1: testName = "Vision Test"; break;
                    case 2: testName = "Written Test"; break;
                    case 3: testName = "Practical Test"; break;
                }

                string title = "New Test Scheduled";
                string content = $"Your {testName} has been scheduled for {notification.AppointmentDate.ToString("MMMM dd, yyyy")} at {notification.AppointmentDate.ToString("hh:mm tt")}. Please make sure to arrive 15 minutes early.";

                // Send the mobile system message (saved to database and fetched by mobile Flutter app)
                clsUserMessage.SendSystemMessage(notification.ApplicantPersonID, title, content, "Test");
                
                Console.WriteLine($"[MEDIATR SUBSCRIBER] SendMobileNotificationHandler successfully sent app notification to Person ID: {notification.ApplicantPersonID}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[MEDIATR SUBSCRIBER ERROR] SendMobileNotificationHandler failed: {ex.Message}");
            }

            return Task.CompletedTask;
        }
    }
}
