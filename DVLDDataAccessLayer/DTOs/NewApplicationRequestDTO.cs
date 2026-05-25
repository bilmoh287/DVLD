namespace DVLDDataAccessLayer.DTOs
{
    public class NewApplicationRequestDTO
    {
        public int ApplicantPersonID { get; set; }
        public int LicenseClassID { get; set; }
        public int DrivingInstituteID { get; set; }
        
        public string? FrontIdBase64 { get; set; }
        public string? BackIdBase64 { get; set; }
        public string? BirthCertBase64 { get; set; }
        public string? TranscriptBase64 { get; set; }

        public NewApplicationRequestDTO() { }
    }
}
