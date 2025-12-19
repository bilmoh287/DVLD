using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{
    public class clsDetainedLicenses
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        // Database Fields
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public string DetainReason { get; set; }
        public string DetainPlace { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? ReleasedByUserID { get; set; }
        public int? ReleaseApplicationID { get; set; }

        // Navigation Helpers (optional)
        public clsLicenses LicenseInfo;


        public clsDetainedLicenses()
        {
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.Now;
            DetainReason = "";
            DetainPlace = "";
            FineFees = 0;
            CreatedByUserID = -1;
            IsReleased = false;
            ReleaseDate = null;
            ReleasedByUserID = null;
            ReleaseApplicationID = null;

            Mode = enMode.AddNew;
        }

        private clsDetainedLicenses(
            int detainID,
            int licenseID,
            DateTime detainDate,
            string detainReason,
            string detainPlace,
            decimal fineFees,
            int createdByUserID,
            bool isReleased,
            DateTime? releaseDate,
            int? releasedByUserID,
            int? releaseApplicationID)
        {
            DetainID = detainID;
            LicenseID = licenseID;
            DetainDate = detainDate;
            DetainReason = detainReason;
            DetainPlace = detainPlace;
            FineFees = fineFees;
            CreatedByUserID = createdByUserID;
            IsReleased = isReleased;
            ReleaseDate = releaseDate;
            ReleasedByUserID = releasedByUserID;
            ReleaseApplicationID = releaseApplicationID;

            LicenseInfo = clsLicenses.Find(licenseID);

            Mode = enMode.Update;
        }

        // ================= Find =================

        public static clsDetainedLicenses Find(int DetainID)
        {
            int LicenseID = -1, CreatedByUserID = -1;
            int? ReleasedByUserID = null, ReleaseApplicationID = null;
            DateTime DetainDate = DateTime.Now;
            DateTime? ReleaseDate = null;
            string DetainReason = "", DetainPlace = "";
            decimal FineFees = 0;
            bool IsReleased = false;

            bool isFound = clsDetainedLicensesData.GetDetainInfoByID(
                DetainID,
                ref LicenseID,
                ref DetainDate,
                ref DetainReason,
                ref DetainPlace,
                ref FineFees,
                ref CreatedByUserID,
                ref IsReleased,
                ref ReleaseDate,
                ref ReleasedByUserID,
                ref ReleaseApplicationID);

            if (isFound)
            {
                return new clsDetainedLicenses(
                    DetainID,
                    LicenseID,
                    DetainDate,
                    DetainReason,
                    DetainPlace,
                    FineFees,
                    CreatedByUserID,
                    IsReleased,
                    ReleaseDate,
                    ReleasedByUserID,
                    ReleaseApplicationID);
            }

            return null;
        }

        // ================= Add / Update =================

        private bool _AddNewDetain()
        {
            DetainID = clsDetainedLicensesData.AddNewDetain(
                LicenseID,
                DetainDate,
                DetainReason,
                DetainPlace,
                FineFees,
                CreatedByUserID);

            return (DetainID != -1);
        }

        private bool _UpdateDetain()
        {
            return clsDetainedLicensesData.UpdateDetain(
                DetainID,
                LicenseID,
                DetainDate,
                DetainReason,
                DetainPlace,
                FineFees,
                CreatedByUserID,
                IsReleased,
                ReleaseDate,
                ReleasedByUserID,
                ReleaseApplicationID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDetain())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateDetain();
            }

            return false;
        }

        // ================= Business Methods =================

        public bool Release(int ReleasedByUserID, int ReleaseApplicationID)
        {
            if (IsReleased)
                return false;

            IsReleased = true;
            ReleaseDate = DateTime.Now;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;

            return Save();
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainedLicensesData.IsLicenseDetained(LicenseID);
        }

        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicensesData.GetAllDetainedLicenses();
        }

        public static DataTable GetDetainedLicensesByLicenseID(int LicenseID)
        {
            return clsDetainedLicensesData.GetDetainedLicensesByLicenseID(LicenseID);
        }
    }
}
