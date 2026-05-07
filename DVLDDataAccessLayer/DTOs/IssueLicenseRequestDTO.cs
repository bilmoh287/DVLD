using System;

namespace DVLDDataAccessLayer.DTOs
{
    public class IssueLicenseRequestDTO
    {
        public int LocalDrivingLicenseApplicationID { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
    }
}
