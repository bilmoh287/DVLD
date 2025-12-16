using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{
    public class clsLicenses
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        // Corresponds to the database fields
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public byte IssueReason { get; set; } // Matches tinyint
        public int CreatedByUserID { get; set; }

        // Enum for IssueReason (Based on License table image/details)
        public enum enIssueReason : byte
        {
            FirstTime = 1,
            Renew = 2,
            ReplacementForDamaged = 3,
            ReplacementForLost = 4
        }

        // Optional relationships (similar to clsTestAppointments)
        // public clsApplication ApplicationInfo;
        // public clsDriver DriverInfo;
        // public clsUser CreatedByUserInfo;

        // Default Constructor (For creating a new license object)
        public clsLicenses()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClass = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = 0;
            this.IsActive = true;
            this.IssueReason = (byte)enIssueReason.FirstTime;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }

        // Private Constructor (For loading an existing license object)
        private clsLicenses(int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
                           DateTime IssueDate, DateTime ExpirationDate, string Notes,
                           decimal PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            // Initialize relationship objects here if needed

            Mode = enMode.Update;
        }

        // Method 1: Static Find method to retrieve an existing license
        public static clsLicenses Find(int LicenseID)
        {
            int ApplicationID = -1, DriverID = -1, LicenseClass = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "";
            decimal PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = 0;

            bool isFound = clsLicensesData.GetLicenseInfoByID(
                LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass,
                ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees,
                ref IsActive, ref IssueReason, ref CreatedByUserID);

            if (isFound)
            {
                return new clsLicenses(
                    LicenseID, ApplicationID, DriverID, LicenseClass,
                    IssueDate, ExpirationDate, Notes, PaidFees,
                    IsActive, IssueReason, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        // Method 2: Private AddNew
        private bool _AddNewLicense()
        {
            this.LicenseID = clsLicensesData.AddNewLicense(
                this.ApplicationID, this.DriverID, this.LicenseClass,
                this.IssueDate, this.ExpirationDate, this.Notes,
                this.PaidFees, this.IsActive, this.IssueReason,
                this.CreatedByUserID);

            return (this.LicenseID != -1);
        }

        // Method 3: Private Update
        private bool _UpdateLicense()
        {
            return clsLicensesData.UpdateLicense(
                this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClass,
                this.IssueDate, this.ExpirationDate, this.Notes,
                this.PaidFees, this.IsActive, this.IssueReason,
                this.CreatedByUserID);
        }

        // Method 4: Public Save method
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateLicense();

                default:
                    return false;
            }
        }

        // Method 5: Static method to get all licenses
        public static DataTable GetAllLicenses()
        {
            return clsLicensesData.GetAllLicenses();
        }

        // Method 6: Business rule to Deactivate a license (Update IsActive field)
        public bool DeactivateLicense()
        {
            this.IsActive = false;
            return _UpdateLicense();
        }
    }
}
