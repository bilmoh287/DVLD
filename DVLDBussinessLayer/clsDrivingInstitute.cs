using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{
    public class clsDrivingInstitute
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int InstituteID { get; set; }
        public string InstituteName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        public clsDrivingInstitute()
        {
            this.InstituteID = -1;
            this.InstituteName = "";
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.IsActive = true;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        private clsDrivingInstitute(int InstituteID, string InstituteName, string Address,
            string Phone, string Email, bool IsActive, int CreatedByUserID)
        {
            this.InstituteID = InstituteID;
            this.InstituteName = InstituteName;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        public static clsDrivingInstitute Find(int InstituteID)
        {
            string InstituteName = "";
            string Address = "";
            string Phone = "";
            string Email = "";
            bool IsActive = false;
            int CreatedByUserID = -1;

            if (clsDrivingInstituteData.GetInstituteInfoByID(InstituteID, ref InstituteName,
                ref Address, ref Phone, ref Email, ref IsActive, ref CreatedByUserID))
            {
                return new clsDrivingInstitute(InstituteID, InstituteName, Address,
                    Phone, Email, IsActive, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewInstitute()
        {
            this.InstituteID = clsDrivingInstituteData.AddNewInstitute(
                this.InstituteName, this.Address, this.Phone, this.Email,
                this.IsActive, this.CreatedByUserID);

            return (this.InstituteID != -1);
        }

        private bool _UpdateInstitute()
        {
            return clsDrivingInstituteData.UpdateInstitute(
                this.InstituteID, this.InstituteName, this.Address, this.Phone,
                this.Email, this.IsActive, this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInstitute())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateInstitute();

                default:
                    return false;
            }
        }

        public static DataTable GetAllInstitutes()
        {
            return clsDrivingInstituteData.GetAllInstitutes();
        }

        public static bool DeleteInstitute(int InstituteID)
        {
            return clsDrivingInstituteData.DeleteInstitute(InstituteID);
        }

        public static bool IsInstituteExist(int InstituteID)
        {
            return clsDrivingInstituteData.IsInstituteExist(InstituteID);
        }
    }
}
