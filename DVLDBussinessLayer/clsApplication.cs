using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{
    public class clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };

        // added approved and rejected status to handle the case of application approval by admin and rejection by admin
        public enum enApplicationStatus
        {
            New = 1,
            Cancelled = 2,
            Completed = 3,
            Approved = 4,
            Rejected = 5
        }

        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public string FullName
        {
            get
            {
                return clsPerson.Find(ApplicantPersonID).FullName;
            }
        }
        public int ApplicationTypeID { get; set; }
        public clsApplicationTypes ApplicationTypeInfo { get; set; }
        public DateTime ApplicationDate { get; set; }
        public enApplicationStatus ApplicationStatus { get; set; }
        public string StatusText
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    case enApplicationStatus.Approved:
                        return "Approved";
                    case enApplicationStatus.Rejected:
                        return "Rejected";
                    default:
                        return "Unknown";
                }
            }
        }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo;
        public string DocumentPath { get; set; }


        public clsApplication()
        {
            ApplicationID = -1;
            ApplicantPersonID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationTypeID = -1;
            ApplicationStatus = enApplicationStatus.New; 
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            DocumentPath = "";
            Mode = enMode.AddNew;
        }
        public clsApplication(int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate, int ApplicationTypeID,
             enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
             decimal PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeInfo = clsApplicationTypes.FindApplicationType(ApplicationTypeID);
            this.ApplicationDate = ApplicationDate;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUserInfo = clsUser.FindByUserID(CreatedByUserID);
            this.Mode = enMode.Update;
        }

        public static DataTable GetAllApplications()
        {
            return clsApplicationData.GetAllApplicationsList();
        }

        public static DataTable GetUnderReviewApplications()
        {
            return clsApplicationData.GetUnderReviewApplications();
        }

        public bool LoadApplicationDetails(int applicationID)
        {
            DataRow row = clsApplicationData.GetApplicationDetails(applicationID);

            if (row != null)
            {
                this.ApplicationID = applicationID;
                this.ApplicantPersonID = (int)row["ApplicantPersonID"];
                this.ApplicationDate = (DateTime)row["ApplicationDate"];
                this.ApplicationTypeID = (int)row["ApplicationTypeID"];
                this.ApplicationStatus = (enApplicationStatus)Convert.ToByte(row["ApplicationStatus"]);
                this.LastStatusDate = (DateTime)row["LastStatusDate"];
                this.PaidFees = Convert.ToDecimal(row["PaidFees"]);
                this.CreatedByUserID = (int)row["CreatedByUserID"];
                this.DocumentPath = row["DocumentPath"] != DBNull.Value ? row["DocumentPath"].ToString() : "";
                
                this.Mode = enMode.Update;
                return true;
            }
            return false;
        }

        public static clsApplication Find(int ApplicationID)
        {
            int ApplicantPersonID = -1;
            DateTime ApplicationDate = DateTime.Now;
            int ApplicationTypeID = -1;
            byte ApplicationStatus = 0;
            DateTime LastStatusDate = DateTime.Now;
            decimal PaidFees = 0;
            int CreatedByUserID = -1;

            bool isFound = clsApplicationData.GetApplicationInfoByID(ApplicationID,
                ref ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID,
                ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID);

            if (isFound)
            {
                return new clsApplication(ApplicationID, ApplicantPersonID, ApplicationDate,
                    ApplicationTypeID, (enApplicationStatus)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            }
            else
                return null;
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationData.AddNewApplication(ApplicantPersonID,
                ApplicationDate, ApplicationTypeID, (byte)ApplicationStatus,
                LastStatusDate, PaidFees, CreatedByUserID);

            return (this.ApplicationID != -1);
        }

        private bool _UpdateApplication()
        {
            return clsApplicationData.UpdateApplication(ApplicationID, ApplicantPersonID,
                ApplicationDate, ApplicationTypeID, (byte)ApplicationStatus,
                LastStatusDate, PaidFees, CreatedByUserID);
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            return clsApplicationData.DeleteApplication(ApplicationID);
        }

        public bool SubmitApplication()
        {
            return this.Save();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateApplication();

                default:
                    return false;
            }
        }

        public bool SaveDocument(string path)
        {
            if (clsApplicationData.UpdateDocumentPath(this.ApplicationID, path))
            {
                this.DocumentPath = path;
                return true;
            }
            return false;
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, clsApplication.enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return clsApplicationData.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }

        public bool Cancel()
        {
            return clsApplicationData.UpdateStatus(ApplicationID, (byte)enApplicationStatus.Cancelled);
        }

        public bool SetComplete()
        {
            return clsApplicationData.UpdateStatus(ApplicationID, (byte)enApplicationStatus.Completed);
        }

        public bool Reject()
        {
            return clsApplicationData.UpdateStatus(ApplicationID, (byte)enApplicationStatus.Rejected);
        }

        public bool Approve()
        {
            return clsApplicationData.UpdateStatus(ApplicationID, (byte)enApplicationStatus.Approved);
        }
    }
}
