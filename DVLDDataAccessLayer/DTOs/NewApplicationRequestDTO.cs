namespace DVLDDataAccessLayer.DTOs
{
    public class NewApplicationRequestDTO
    {
        public int ApplicantPersonID { get; set; }
        public int LicenseClassID { get; set; }
        public int DrivingInstituteID { get; set; }

        public NewApplicationRequestDTO() { }
    }
}
