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
        public string NationalIDBackPath { get; set; }
        public string BirthCertificatePath { get; set; }
        public string Transcript12thPath { get; set; }
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
            NationalIDBackPath = "";
            BirthCertificatePath = "";
            Transcript12thPath = "";
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


        public static DataTable GetUnderReviewApplicationsByType(int applicationTypeID)
        {
            return clsApplicationData.GetUnderReviewApplicationsByType(applicationTypeID);
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
                this.NationalIDBackPath = row["NationalIDBackPath"] != DBNull.Value ? row["NationalIDBackPath"].ToString() : "";
                this.BirthCertificatePath = row["BirthCertificatePath"] != DBNull.Value ? row["BirthCertificatePath"].ToString() : "";
                this.Transcript12thPath = row["Transcript12thPath"] != DBNull.Value ? row["Transcript12thPath"].ToString() : "";
                
                this.Mode = enMode.Update;
                return true;
            }
            return false;
        }

        public static clsApplication Find(int ApplicationID)
        {
            clsApplication application = new clsApplication();
            if (application.LoadApplicationDetails(ApplicationID))
            {
                return application;
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
            enApplicationStatus oldStatus = enApplicationStatus.New;
            if (Mode == enMode.Update)
            {
                clsApplication oldApp = clsApplication.Find(this.ApplicationID);
                if (oldApp != null)
                {
                    oldStatus = oldApp.ApplicationStatus;
                }
            }

            bool success = false;
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {
                        Mode = enMode.Update;
                        success = true;
                    }
                    break;

                case enMode.Update:
                    success = _UpdateApplication();
                    break;
            }

            if (success && Mode == enMode.Update && oldStatus != this.ApplicationStatus)
            {
                if (this.ApplicationStatus == enApplicationStatus.Approved)
                {
                    _NotifyStatusUpdate("Application Approved", "Great news! Your application has been approved. You can now proceed to the next steps.");
                }
                else if (this.ApplicationStatus == enApplicationStatus.Rejected)
                {
                    _NotifyStatusUpdate("Application Rejected", "We regret to inform you that your driving license application has been rejected. Please visit the office for more information.");
                }
                else if (this.ApplicationStatus == enApplicationStatus.Completed)
                {
                    _NotifyStatusUpdate("Application Completed", "Congratulations! Your application is now complete. You can proceed with the next steps or collect your license.");
                }
                else if (this.ApplicationStatus == enApplicationStatus.Cancelled)
                {
                    _NotifyStatusUpdate("Application Cancelled", "Your application has been successfully cancelled as per your request or administrative action.");
                }
            }

            return success;
        }

        public bool SaveDocuments(string front, string back, string birthCert, string transcript)
        {
            if (clsApplicationData.UpdateApplicationDocuments(this.ApplicationID, front, back, birthCert, transcript))
            {
                this.DocumentPath = front;
                this.NationalIDBackPath = back;
                this.BirthCertificatePath = birthCert;
                this.Transcript12thPath = transcript;
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
            if (clsApplicationData.UpdateStatus(ApplicationID, (byte)enApplicationStatus.Cancelled))
            {
                _NotifyStatusUpdate("Application Cancelled", "Your application has been successfully cancelled as per your request or administrative action.");
                return true;
            }
            return false;
        }

        public bool SetComplete()
        {
            if (clsApplicationData.UpdateStatus(ApplicationID, (byte)enApplicationStatus.Completed))
            {
                _NotifyStatusUpdate("Application Completed", "Congratulations! Your application is now complete. You can proceed with the next steps or collect your license.");
                return true;
            }
            return false;
        }

        public bool Reject()
        {
            if (clsApplicationData.UpdateStatus(ApplicationID, (byte)enApplicationStatus.Rejected))
            {
                _NotifyStatusUpdate("Application Rejected", "We regret to inform you that your driving license application has been rejected. Please visit the office for more information.");
                return true;
            }
            return false;
        }

        public bool Approve()
        {
            if (clsApplicationData.UpdateStatus(ApplicationID, (byte)enApplicationStatus.Approved))
            {
                _NotifyStatusUpdate("Application Approved", "Great news! Your application has been approved. You can now proceed to the next steps.");
                return true;
            }
            return false;
        }

        private void _NotifyStatusUpdate(string title, string message)
        {
            try
            {
                clsUserMessage.SendSystemMessage(this.ApplicantPersonID, title, message, "Status");
            }
            catch (Exception)
            {
                // Safety catch
            }
        }

        public static int GetActiveApplicationID(int PersonID, int ApplicationTypeID)
        {
            return clsApplicationData.GetActiveApplicationID(PersonID, ApplicationTypeID);
        }
    }
}
