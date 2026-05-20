using MediatR;
using System;

namespace DVLDREST_API.Workflows.TestScheduling
{
    public class TestScheduledNotification : INotification
    {
        public int TestAppointmentID { get; }
        public int LocalDrivingLicenseApplicationID { get; }
        public int TestTypeID { get; }
        public DateTime AppointmentDate { get; }
        public int ApplicantPersonID { get; }

        public TestScheduledNotification(int testAppointmentID, int localDrivingLicenseApplicationID, int testTypeID, DateTime appointmentDate, int applicantPersonID)
        {
            TestAppointmentID = testAppointmentID;
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            TestTypeID = testTypeID;
            AppointmentDate = appointmentDate;
            ApplicantPersonID = applicantPersonID;
        }
    }
}
