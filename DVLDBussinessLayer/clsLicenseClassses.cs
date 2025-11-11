using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{
    public class clsLicenseClasses
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }

        private clsLicenseClasses()
        {
            LicenseClassID = -1;
            ClassName = string.Empty;
            ClassDescription = string.Empty;
            MinimumAllowedAge = 0;
            DefaultValidityLength = 0;
            ClassFees = 0;
            Mode = enMode.AddNew;
        }
        public clsLicenseClasses(int LiceseClassID, string ClassName, string ClassDescription,
            byte MinimumAllowedAge, byte DefaultValidityLength, decimal ClassFees)
        {
            this.LicenseClassID = LiceseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
            Mode = enMode.Update;
        }

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassesData.GetAllLicenseClassesList();
        }

        public static clsLicenseClasses Find(int LicenseClassID)
        {
            string ClassName = "";
            string ClassDescription = "";
            byte MinimumAllowedAge = 0;
            byte DefaultValidityLength = 0;
            decimal ClassFees = 0;

            if (clsLicenseClassesData.GetLicenseClassInfoByID(
                    LicenseClassID,
                    ref ClassName,
                    ref ClassDescription,
                    ref MinimumAllowedAge,
                    ref DefaultValidityLength,
                    ref ClassFees))
            {
                return new clsLicenseClasses(LicenseClassID, ClassName, ClassDescription,
                    MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }
            else
            {
                return null;
            }
        }

        public static clsLicenseClasses Find(string LicenseClassName)
        {
            int LicenseClassID = -1;
            string ClassDescription = "";
            byte MinimumAllowedAge = 0;
            byte DefaultValidityLength = 0;
            decimal ClassFees = 0;

            if (clsLicenseClassesData.GetLicenseClassInfoByName(
                    LicenseClassName,
                    ref LicenseClassID,
                    ref ClassDescription,
                    ref MinimumAllowedAge,
                    ref DefaultValidityLength,
                    ref ClassFees))
            {
                return new clsLicenseClasses(LicenseClassID, LicenseClassName, ClassDescription,
                    MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewLicenseClass()
        {
            this.LicenseClassID = clsLicenseClassesData.AddNewLicenseClass(
                this.ClassName,
                this.ClassDescription,
                this.MinimumAllowedAge,
                this.DefaultValidityLength,
                this.ClassFees
            );

            return (this.LicenseClassID != -1);
        }

        private bool _UpdateLicenseClass()
        {
            return clsLicenseClassesData.UpdateLicenseClass(
                this.LicenseClassID,
                this.ClassName,
                this.ClassDescription,
                this.MinimumAllowedAge,
                this.DefaultValidityLength,
                this.ClassFees
            );
        }
        public static bool DeleteLicenseClass(int LicenseClassID)
        {
            return clsLicenseClassesData.DeleteLicenseClass(LicenseClassID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicenseClass())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateLicenseClass();

                default:
                    return false;
            }
        }
    }
}
