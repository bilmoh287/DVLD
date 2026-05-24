using System;
using System.Collections.Generic;

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

            // Sync with School Logs / Announcements database mock-up
            Console.WriteLine($"[PUB/SUB SUBSCRIBER] Driving School Dashboard: Notifying school that student '{studentName}' is scheduled for {testName} on {appointmentDate}.");
        }
    }

    public class clsEmailSmtpSubscriber : ITestScheduledSubscriber
    {
        public void OnTestScheduled(int personID, int testTypeID, DateTime appointmentDate, int appointmentID)
        {
            clsPerson person = clsPerson.Find(personID);
            if (person == null || string.IsNullOrEmpty(person.Email)) return;

            // Mock SMTP dispatch
            Console.WriteLine($"[PUB/SUB SUBSCRIBER] SMTP Server: Dispatched email confirmation of {testTypeID} scheduling to {person.Email}.");
        }
    }
}
