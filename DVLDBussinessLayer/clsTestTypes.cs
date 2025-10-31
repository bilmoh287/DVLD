using System;
using System.Data;
using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{
    public class clsTestTypes
    {
        public enum enMode { AddNewMode = 0, UpdateMode = 1 };
        public enMode _Mode = enMode.AddNewMode;
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };
        public clsTestTypes.enTestType TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }

        public clsTestTypes()
        {
            TestTypeID = enTestType.VisionTest;
            TestTypeTitle = "";
            TestTypeDescription = "";
            TestTypeFees = 0;

            _Mode = enMode.AddNewMode;
        }

        private clsTestTypes(clsTestTypes.enTestType testTypeID, string title, string description, decimal fees)
        {
            this.TestTypeID = testTypeID;
            TestTypeTitle = title;
            TestTypeDescription = description;
            TestTypeFees = fees;

            _Mode = enMode.UpdateMode;
        }

        public static DataTable GetAllTestTypesList()
        {
            return clsTestTypesData.GetAllTestTypesList();
        }

        public static clsTestTypes Find(enTestType testTypeID)
        {
            string title = "";
            string description = "";
            decimal fees = 0;

            if (clsTestTypesData.GetTestTypeByID((int)testTypeID, ref title, ref description, ref fees))
            {
                return new clsTestTypes(testTypeID, title, description, fees);
            }

            return null;
        }

        private bool _AddNewTestType()
        {
            this.TestTypeID = (clsTestTypes.enTestType)clsTestTypesData.AddNewTestType(this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
            return (this.TestTypeTitle != "");
        }

        private bool _UpdateTestType()
        {
            return clsTestTypesData.UpdateTestType((int)this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
        }

        public static bool Delete(int testTypeID)
        {
            return clsTestTypesData.DeleteTestType(testTypeID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNewMode:
                    if (_AddNewTestType())
                    {
                        _Mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                        return false;

                case enMode.UpdateMode:
                    return _UpdateTestType();
            }

            return false;
        }
    }
}
