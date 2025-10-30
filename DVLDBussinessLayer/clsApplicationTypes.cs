using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{
    public class clsApplicationTypes
    {
        public enum enMode { AddNewMode = 0, UpdateMode = 1 };
        public enMode _Mode = enMode.UpdateMode;

        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationTypeFees { get; set; }

        clsApplicationTypes()
        {
            ApplicationTypeID = -1;
            ApplicationTypeTitle = "";
            ApplicationTypeFees = 0;

            _Mode = enMode.AddNewMode;
        }
        clsApplicationTypes(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationTypeFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationTypeFees = ApplicationTypeFees;

            _Mode = enMode.UpdateMode;
        }

        public static DataTable GetAllApplicationsTypeList()
        {
            return clsApplicationTypesData.GetAllApplicationTypesList();
        }

        public static clsApplicationTypes FindApplicationType(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            decimal AppliactionTypeFees = 0;
            if(clsApplicationTypesData.GetApplicationTypeByID(ApplicationTypeID, ref ApplicationTypeTitle, ref AppliactionTypeFees))
            {
                return new clsApplicationTypes(ApplicationTypeID, ApplicationTypeTitle, AppliactionTypeFees);
            }
            else
            {
                return null;
            }
        }

        public static bool UpdateApplicationTypeFees(int ApplicationTypeID, decimal ApplicationTypeFees)
        {
            return clsApplicationTypesData.UpdateApplicationFees(ApplicationTypeID, ApplicationTypeFees);
        }
    }
}
