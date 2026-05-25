using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Mail;

namespace DVLDBussinessLayer
{
    public interface ITestScheduledSubscriber
    {
        void OnTestScheduled(int personID, int testTypeID, DateTime appointmentDate, int appointmentID);
    }

    public static class clsTestSchedulePublisher
    {
        private static readonly List<ITestScheduledSubscriber> _subscribers = new List<ITestScheduledSubscriber>();

        public static void Subscribe(ITestScheduledSubscriber subscriber)
        {
            if (!_subscribers.Contains(subscriber))
            {
                _subscribers.Add(subscriber);
            }
        }

        public static void Unsubscribe(ITestScheduledSubscriber subscriber)
        {
            if (_subscribers.Contains(subscriber))
            {
                _subscribers.Remove(subscriber);
            }
        }

        public static void Publish(int personID, int testTypeID, DateTime appointmentDate, int appointmentID)
        {
            foreach (var subscriber in _subscribers)
            {
                try
                {
                    subscriber.OnTestScheduled(personID, testTypeID, appointmentDate, appointmentID);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[PUB/SUB ERROR] Subscriber {subscriber.GetType().Name} failed: {ex.Message}");
                }
            }
        }
    }

    // --- CONCRETE SUBSCRIBERS ---

    public class clsStudentMobileSubscriber : ITestScheduledSubscriber
    {
        public void OnTestScheduled(int personID, int testTypeID, DateTime appointmentDate, int appointmentID)
        {
            string testName = "Driving Test";
            switch (testTypeID)
            {
                case 1: testName = "Vision Test"; break;
                case 2: testName = "Written Test"; break;
                case 3: testName = "Practical Test"; break;
            }

            string title = "New Test Scheduled";
            string content = $"Your {testName} has been scheduled for {appointmentDate.ToString("MMMM dd, yyyy")} at {appointmentDate.ToString("hh:mm tt")}. Please make sure to arrive 15 minutes early.";

            // Save to Messages table in database
            clsUserMessage.SendSystemMessage(personID, title, content, "Test");
            Console.WriteLine($"[PUB/SUB SUBSCRIBER] In-App Message pushed successfully to Person ID: {personID}");
        }
    }

    public class clsSchoolDashboardSubscriber : ITestScheduledSubscriber
    {
        public void OnTestScheduled(int personID, int testTypeID, DateTime appointmentDate, int appointmentID)
        {
            clsPerson person = clsPerson.Find(personID);
            string studentName = person != null ? ($"{person.FirstName} {person.LastName}") : "Applicant";

            string testName = "Driving Test";
            switch (testTypeID)
            {
                case 1: testName = "Vision Test"; break;
                case 2: testName = "Written Test"; break;
                case 3: testName = "Practical Test"; break;
            }

            // Sync with School database announcements
            int instituteID = 0;
            int? batchID = null;

            DataTable dtBatch = clsTrainingBatch.GetStudentBatch(personID);
            if (dtBatch.Rows.Count > 0)
            {
                batchID = Convert.ToInt32(dtBatch.Rows[0]["TrainingBatchID"]);
                instituteID = Convert.ToInt32(dtBatch.Rows[0]["InstituteID"]);
            }
            else
            {
                DataTable dtEnrollment = clsEnrollment.GetEnrollmentsByPersonID(personID);
                if (dtEnrollment.Rows.Count > 0)
                {
                    instituteID = Convert.ToInt32(dtEnrollment.Rows[0]["InstituteID"]);
                }
            }

            if (instituteID > 0)
            {
                string title = $"Test Scheduled: {testName}";
                string content = $"A {testName} has been scheduled for student {studentName} on {appointmentDate.ToString("MMMM dd, yyyy")} at {appointmentDate.ToString("hh:mm tt")}.";
                clsAnnouncement.CreateAnnouncement(instituteID, batchID, title, content, 1);
                Console.WriteLine($"[PUB/SUB SUBSCRIBER] Posted school announcement for student '{studentName}' and test '{testName}'.");
            }
        }
    }

    public class clsEmailSmtpSubscriber : ITestScheduledSubscriber
    {
        public void OnTestScheduled(int personID, int testTypeID, DateTime appointmentDate, int appointmentID)
        {
            clsPerson person = clsPerson.Find(personID);
            if (person == null || string.IsNullOrEmpty(person.Email)) return;

            string testName = "Driving Test";
            switch (testTypeID)
            {
                case 1: testName = "Vision Test"; break;
                case 2: testName = "Written Test"; break;
                case 3: testName = "Practical Test"; break;
            }

            string emailBody = $@"
                <h3>DVLD Test Appointment Scheduled</h3>
                <p>Dear {person.FullName},</p>
                <p>This is to confirm that your <strong>{testName}</strong> has been successfully scheduled.</p>
                <ul>
                    <li><strong>Date:</strong> {appointmentDate:MMMM dd, yyyy}</li>
                    <li><strong>Time:</strong> {appointmentDate:hh:mm tt}</li>
                </ul>
                <p>Please arrive at least 15 minutes before your scheduled appointment.</p>
                <p>Sincerely,<br/>International DVLD Department</p>";

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
                        Console.WriteLine($"[PUB/SUB SUBSCRIBER] Sent email to {person.Email} via localhost SMTP.");
                    }
                }
                catch (Exception localEx)
                {
                    Console.WriteLine($"[PUB/SUB SUBSCRIBER WARNING] Local SMTP failed, attempting Gmail SMTP. Details: {localEx.Message}");
                }
            }
        }
    }
}
