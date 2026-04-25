using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;
using DVLDDataAccessLayer.DTOs;


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
        public string CommercialLicenseNo { get; set; }
        public DateTime LicenseExpiryDate { get; set; }
        public string ManagerName { get; set; }
        public int Capacity { get; set; }
        public string LogoPath { get; set; }
        public string DocumentPath { get; set; }

        public DrivingInstituteDTO InstituteDTO
        {
            get
            {
                return new DrivingInstituteDTO(this.InstituteID, this.InstituteName, this.Address,
                    this.Phone, this.Email, this.IsActive, this.CreatedByUserID,
                    this.CommercialLicenseNo, this.LicenseExpiryDate, this.ManagerName,
                    this.Capacity, this.LogoPath, this.DocumentPath);
            }
        }


        public clsDrivingInstitute()
        {
            this.InstituteID = -1;
            this.InstituteName = "";
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.IsActive = true;
            this.CreatedByUserID = -1;
            this.CommercialLicenseNo = "";
            this.LicenseExpiryDate = DateTime.Now;
            this.ManagerName = "";
            this.Capacity = 0;
            this.LogoPath = "";
            this.DocumentPath = "";


            Mode = enMode.AddNew;
        }

        private clsDrivingInstitute(DrivingInstituteDTO dto)
        {
            this.InstituteID = dto.InstituteID;
            this.InstituteName = dto.InstituteName;
            this.Address = dto.Address;
            this.Phone = dto.Phone;
            this.Email = dto.Email;
            this.IsActive = dto.IsActive;
            this.CreatedByUserID = dto.CreatedByUserID;
            this.CommercialLicenseNo = dto.CommercialLicenseNo;
            this.LicenseExpiryDate = dto.LicenseExpiryDate;
            this.ManagerName = dto.ManagerName;
            this.Capacity = dto.Capacity;
            this.LogoPath = dto.LogoPath;
            this.DocumentPath = dto.DocumentPath;

            Mode = enMode.Update;
        }


        public static clsDrivingInstitute Find(int InstituteID)
        {
            DrivingInstituteDTO dto = clsDrivingInstituteData.GetInstituteInfoByID(InstituteID);

            if (dto != null)
            {
                return new clsDrivingInstitute(dto);
            }


            else
            {
                return null;
            }
        }

        private bool _AddNewInstitute()
        {
            this.InstituteID = clsDrivingInstituteData.AddNewInstitute(this.InstituteDTO);
            return (this.InstituteID != -1);
        }

        private bool _UpdateInstitute()
        {
            return clsDrivingInstituteData.UpdateInstitute(this.InstituteDTO);
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

        public static DataTable GetInstituteMobileDetail(int InstituteID)
        {
            return clsDrivingInstituteData.GetInstituteMobileDetailByID(InstituteID);
        }

        public static bool IsInstituteExist(int InstituteID)

        {
            return clsDrivingInstituteData.IsInstituteExist(InstituteID);
        }
    }
}
