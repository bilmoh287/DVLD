using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using DVLDBussinessLayer;

namespace DVLDREST_API.Workflows.TestScheduling.Handlers
{
    public class SendSmsNotificationHandler : INotificationHandler<TestScheduledNotification>
    {
        public Task Handle(TestScheduledNotification notification, CancellationToken cancellationToken)
        {
            try
            {
                // Retrieve the person's phone number
                clsPerson person = clsPerson.Find(notification.ApplicantPersonID);
                string phone = person != null ? person.Phone : "+1 (555) 019-2834";
                string applicantName = person != null ? ($"{person.FirstName} {person.LastName}") : "Applicant";

                string testName = "Driving Test";
                switch (notification.TestTypeID)
                {
                    case 1: testName = "Vision Test"; break;
                    case 2: testName = "Written Test"; break;
                    case 3: testName = "Practical Test"; break;
                }

                string smsMessage = $"Hello {applicantName}, your {testName} is scheduled for {notification.AppointmentDate:yyyy-MM-dd HH:mm}. Pls bring your ID. -DVLD";

                // Simulate sending SMS via Twilio / SMS Gateway
                Console.WriteLine($"[MEDIATR SUBSCRIBER] [SMS Gateway] Sending SMS to {phone}...");
                Console.WriteLine($"[MEDIATR SUBSCRIBER] [SMS Sent] Message: \"{smsMessage}\"");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[MEDIATR SUBSCRIBER ERROR] SendSmsNotificationHandler failed: {ex.Message}");
            }

            return Task.CompletedTask;
        }
    }
}
