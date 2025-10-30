using System;
using System.Collections.Generic;
using System.Data;
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
        private bool _AddNewApplicationType()
        {
            //call DataAccess Layer 

            this.ApplicationTypeID = clsApplicationTypesData.AddNewApplicationType(this.ApplicationTypeTitle, this.ApplicationTypeFees);


            return (this.ApplicationTypeID != -1);
        }
        public bool _UpdateApplicationTypeFees()
        {
            return clsApplicationTypesData.UpdateApplicationFees(this.ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationTypeFees);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNewMode:
                    if (_AddNewApplicationType())
                    {

                        _Mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.UpdateMode:

                    return _UpdateApplicationTypeFees();

            }

            return false;
        }
    }
}
