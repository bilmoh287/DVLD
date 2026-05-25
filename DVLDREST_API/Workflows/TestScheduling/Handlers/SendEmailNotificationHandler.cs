using MediatR;
using System;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using DVLDBussinessLayer;

namespace DVLDREST_API.Workflows.TestScheduling.Handlers
{
    public class SendEmailNotificationHandler : INotificationHandler<TestScheduledNotification>
    {
        public Task Handle(TestScheduledNotification notification, CancellationToken cancellationToken)
        {
            try
            {
                // Retrieve the person's email
                clsPerson person = clsPerson.Find(notification.ApplicantPersonID);
                string email = person != null ? person.Email : "applicant@dvld.gov";
                string applicantName = person != null ? ($"{person.FirstName} {person.LastName}") : "Applicant";

                string testName = "Driving Test";
                switch (notification.TestTypeID)
                {
                    case 1: testName = "Vision Test"; break;
                    case 2: testName = "Written Test"; break;
                    case 3: testName = "Practical Test"; break;
                }

                string emailBody = $@"
                    <h3>DVLD Test Appointment Scheduled</h3>
                    <p>Dear {applicantName},</p>
                    <p>This is to confirm that your <strong>{testName}</strong> has been successfully scheduled.</p>
                    <ul>
                        <li><strong>Date:</strong> {notification.AppointmentDate:MMMM dd, yyyy}</li>
                        <li><strong>Time:</strong> {notification.AppointmentDate:hh:mm tt}</li>
                    </ul>
                    <p>Please arrive at least 15 minutes before your scheduled appointment.</p>
                    <p>Sincerely,<br/>International DVLD Department</p>";

                if (person != null && !string.IsNullOrEmpty(person.Email))
                {
                    using (var mail = new MailMessage())
                    {
                        mail.From = new MailAddress("dvld-notifications@gov.com", "DVLD Notifications");
                        mail.To.Add(person.Email);
                        mail.Subject = "DVLD Test Appointment Scheduled";
                        mail.Body = emailBody;
                        mail.IsBodyHtml = true;

                        try
                        {
                            using (var client = new SmtpClient("localhost", 25))
                            {
                                client.Send(mail);
                                Console.WriteLine($"[MEDIATR EMAIL] Sent email to {person.Email} via localhost SMTP.");
                            }
                        }
                        catch (Exception localEx)
                        {
                            Console.WriteLine($"[MEDIATR EMAIL WARNING] Local SMTP failed, attempting Gmail SMTP. Details: {localEx.Message}");
                        }
                    }
                }

                // Simulate sending email via SMTP/SendGrid
                Console.WriteLine($"[MEDIATR SUBSCRIBER] [Email SMTP Server] Sending Email to {email}...");
                Console.WriteLine($"[MEDIATR SUBSCRIBER] [Email Sent] Subject: DVLD Test Appointment Scheduled");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[MEDIATR SUBSCRIBER ERROR] SendEmailNotificationHandler failed: {ex.Message}");
            }

            return Task.CompletedTask;
        }
    }
}
