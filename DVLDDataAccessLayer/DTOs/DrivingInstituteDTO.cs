using System;

namespace DVLDDataAccessLayer.DTOs
{
    public class DrivingInstituteDTO
    {
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
        public string City { get; set; }
        public string Region { get; set; }

        public DrivingInstituteDTO(int instituteID, string instituteName, string address, string phone, string email,
            bool isActive, int createdByUserID, string commercialLicenseNo, DateTime licenseExpiryDate,
            string managerName, int capacity, string logoPath, string documentPath, string city, string region)
        {
            this.InstituteID = instituteID;
            this.InstituteName = instituteName;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.IsActive = isActive;
            this.CreatedByUserID = createdByUserID;
            this.CommercialLicenseNo = commercialLicenseNo;
            this.LicenseExpiryDate = licenseExpiryDate;
            this.ManagerName = managerName;
            this.Capacity = capacity;
            this.LogoPath = logoPath;
            this.DocumentPath = documentPath;
            this.City = city;
            this.Region = region;
        }
    }
}
