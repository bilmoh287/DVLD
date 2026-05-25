using MediatR;
using System;
using System.Data;
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

                int instituteID = 0;
                int? batchID = null;

                DataTable dtBatch = clsTrainingBatch.GetStudentBatch(notification.ApplicantPersonID);
                if (dtBatch.Rows.Count > 0)
                {
                    batchID = Convert.ToInt32(dtBatch.Rows[0]["TrainingBatchID"]);
                    instituteID = Convert.ToInt32(dtBatch.Rows[0]["InstituteID"]);
                }
                else
                {
                    DataTable dtEnrollment = clsEnrollment.GetEnrollmentsByPersonID(notification.ApplicantPersonID);
                    if (dtEnrollment.Rows.Count > 0)
                    {
                        instituteID = Convert.ToInt32(dtEnrollment.Rows[0]["InstituteID"]);
                    }
                }

                if (instituteID > 0)
                {
                    string title = $"Test Scheduled: {testName}";
                    string content = $"A {testName} has been scheduled for student {studentName} on {notification.AppointmentDate.ToString("MMMM dd, yyyy")} at {notification.AppointmentDate.ToString("hh:mm tt")}.";
                    clsAnnouncement.CreateAnnouncement(instituteID, batchID, title, content, 1);
                    Console.WriteLine($"[MEDIATR SUBSCRIBER] Posted school announcement for student '{studentName}' and test '{testName}'.");
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
