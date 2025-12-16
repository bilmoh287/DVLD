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

        // Issueing Reason
        public enum enIssueReason : byte
        {
            FirstTime = 1,
            Renew = 2,
            ReplacementForDamaged = 3,
            ReplacementForLost = 4
        }

        // Database fields
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public int CreatedByUserID { get; set; }

        // public clsDriver DriverInfo;
        // public clsApplication ApplicationInfo;

        // Read-only helper (mentor-style)
        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);
            }
        }

        public clsLicenses()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClass = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = "";
            PaidFees = 0;
            IsActive = true;
            IssueReason = enIssueReason.FirstTime;
            CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsLicenses(int licenseID, int applicationID, int driverID, int licenseClass,
                            DateTime issueDate, DateTime expirationDate, string notes,
                            decimal paidFees, bool isActive,
                            enIssueReason issueReason, int createdByUserID)
        {
            LicenseID = licenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            LicenseClass = licenseClass;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IsActive = isActive;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;

            Mode = enMode.Update;
        }

        public static clsLicenses Find(int LicenseID)
        {
            int ApplicationID = -1, DriverID = -1, LicenseClass = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "";
            decimal PaidFees = 0;
            bool IsActive = false;
            byte IssueReasonDB = 0;

            bool isFound = clsLicensesData.GetLicenseInfoByID(
                LicenseID,
                ref ApplicationID,
                ref DriverID,
                ref LicenseClass,
                ref IssueDate,
                ref ExpirationDate,
                ref Notes,
                ref PaidFees,
                ref IsActive,
                ref IssueReasonDB,
                ref CreatedByUserID);

            if (isFound)
            {
                return new clsLicenses(
                    LicenseID,
                    ApplicationID,
                    DriverID,
                    LicenseClass,
                    IssueDate,
                    ExpirationDate,
                    Notes,
                    PaidFees,
                    IsActive,
                    (enIssueReason)IssueReasonDB,
                    CreatedByUserID);
            }

            return null;
        }

        private bool _AddNewLicense()
        {
            LicenseID = clsLicensesData.AddNewLicense(
                ApplicationID,
                DriverID,
                LicenseClass,
                IssueDate,
                ExpirationDate,
                Notes,
                PaidFees,
                IsActive,
                (byte)IssueReason,
                CreatedByUserID);

            return (LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            return clsLicensesData.UpdateLicense(
                LicenseID,
                ApplicationID,
                DriverID,
                LicenseClass,
                IssueDate,
                ExpirationDate,
                Notes,
                PaidFees,
                IsActive,
                (byte)IssueReason,
                CreatedByUserID);
        }

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
                    return false;

                case enMode.Update:
                    return _UpdateLicense();
            }

            return false;
        }

        public static DataTable GetAllLicenses()
        {
            return clsLicensesData.GetAllLicenses();
        }

        public bool DeactivateLicense()
        {
            IsActive = false;
            return _UpdateLicense();
        }

        public static string GetIssueReasonText(enIssueReason IssueReason)
        {
            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.ReplacementForDamaged:
                    return "Replacement for Damaged";
                case enIssueReason.ReplacementForLost:
                    return "Replacement for Lost";
                default:
                    return "First Time";
            }
        }
    }
}
