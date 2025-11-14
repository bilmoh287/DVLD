using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{
    public class clsTests
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public clsUser CreatedByUserInfo { get; set; }

        public clsTests()
        {
            TestID = -1;
            TestAppointmentID = -1;
            TestResult = false;
            Notes = "";
            CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }

        private clsTests(int testID, int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            TestID = testID;
            TestAppointmentID = testAppointmentID;
            TestResult = testResult;
            Notes = notes;
            CreatedByUserID = createdByUserID;
            CreatedByUserInfo = clsUser.FindByUserID(createdByUserID);
            Mode = enMode.Update;
        }

        public static DataTable GetAllTests()
        {
            return clsTestsData.GetAllTests();
        }

        public static clsTests Find(int testID)
        {
            int testAppointmentID = -1;
            bool testResult = false;
            string notes = "";
            int createdByUserID = -1;

            bool isFound = clsTestsData.GetTestByID(testID, ref testAppointmentID, ref testResult, ref notes, ref createdByUserID);

            if (isFound)
            {
                return new clsTests(testID, testAppointmentID, testResult, notes, createdByUserID);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewTest()
        {
            this.TestID = clsTestsData.AddNewTest(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);
            return (this.TestID != -1);
        }

        private bool _UpdateTest()
        {
            return clsTestsData.UpdateTest(this.TestID, this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTest())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateTest();

                default:
                    return false;
            }
        }

        public static bool DeleteTest(int testID)
        {
            return clsTestsData.DeleteTest(testID);
        }
    }
}
