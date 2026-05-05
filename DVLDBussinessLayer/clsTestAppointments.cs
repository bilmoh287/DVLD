using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{
    public class clsTestAppointments
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }


        // Optional relationships
        public clsUser CreatedByUserInfo;
        public clsLocalDrivingLicenseApplication LDLApplicationInfo;

        public clsTestAppointments()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.IsLocked = false;
            this.RetakeTestApplicationID = -1;
            Mode = enMode.AddNew;
        }

        private clsTestAppointments(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;

            this.CreatedByUserInfo = clsUser.FindByUserID(CreatedByUserID);
            this.LDLApplicationInfo = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationInfoByID(LocalDrivingLicenseApplicationID);

            Mode = enMode.Update;
        }

        public static DataTable GetAllTestAppointments()
        {
            return clsTestAppointmentsData.GetAllTestAppointments();
        }

        public static clsTestAppointments Find(int TestAppointmentID)
        {
            int TestTypeID = -1;
            int LocalDrivingLicenseApplicationID = -1;
            DateTime AppointmentDate = DateTime.Now;
            decimal PaidFees = 0;
            int CreatedByUserID = -1;
            bool IsLocked = false;
            int RetakeTestApplicationID = -1;

            bool isFound = clsTestAppointmentsData.GetTestAppointmentInfoByID(
                TestAppointmentID,
                ref TestTypeID,
                ref LocalDrivingLicenseApplicationID,
                ref AppointmentDate,
                ref PaidFees,
                ref CreatedByUserID,
                ref IsLocked,
                ref RetakeTestApplicationID
            );

            if (isFound)
            {
                return new clsTestAppointments(
                    TestAppointmentID,
                    TestTypeID,
                    LocalDrivingLicenseApplicationID,
                    AppointmentDate,
                    PaidFees,
                    CreatedByUserID,
                    IsLocked,
                    RetakeTestApplicationID
                );
            }
            else
                return null;
        }

        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = clsTestAppointmentsData.AddNewTestAppointment(
                this.TestTypeID,
                this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate,
                this.PaidFees,
                this.CreatedByUserID,
                this.IsLocked
            );

            return (this.TestAppointmentID != -1);
        }

        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentsData.UpdateTestAppointment(
                this.TestAppointmentID,
                this.TestTypeID,
                this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate,
                this.PaidFees,
                this.CreatedByUserID,
                this.IsLocked
            );
        }

        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            return clsTestAppointmentsData.DeleteTestAppointment(TestAppointmentID);
        }

        public static bool IsTestAppointmentExist(int TestAppointmentID)
        {
            return clsTestAppointmentsData.IsTestAppointmentExist(TestAppointmentID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestAppointment())
                    {
                        Mode = enMode.Update;
                        _NotifyApplicant(); // Trigger Notification for Mobile App
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateTestAppointment();

                default:
                    return false;
            }
        }

        private void _NotifyApplicant()
        {
            try
            {
                // We need to find the person ID associated with this LDL application
                clsLocalDrivingLicenseApplication ldla = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationInfoByID(this.LocalDrivingLicenseApplicationID);
                if (ldla == null) return;

                string testName = "Driving Test";
                switch (this.TestTypeID)
                {
                    case 1: testName = "Vision Test"; break;
                    case 2: testName = "Written Test"; break;
                    case 3: testName = "Practical Test"; break;
                }

                string title = "New Test Scheduled";
                string content = $"Your {testName} has been scheduled for {this.AppointmentDate.ToString("MMMM dd, yyyy")} at {this.AppointmentDate.ToString("hh:mm tt")}. Please make sure to arrive 15 minutes early.";

                clsUserMessage.SendSystemMessage(ldla.ApplicantPersonID, title, content, "Test");
            }
            catch (Exception)
            {
                // We don't want to crash the main app if notification fails
            }
        }

        public bool LockAppointment()
        {
            this.IsLocked = true;
            return _UpdateTestAppointment();
        }

        public static DataTable GetApplicantTestAppointmentsPerTestType(int LDLApplicationID, int TestTypeID)
        {
            return clsTestAppointmentsData.GetApplicantestAppointmentsPerTestType(LDLApplicationID, TestTypeID);
        }


    }
}
