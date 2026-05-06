using System;

namespace DVLDDataAccessLayer.DTOs
{
    public class ApplicationStatusResponseDTO
    {
        public int ApplicationID { get; set; }
        public int LDLApplicationID { get; set; }
        public string ClassName { get; set; }
        public string Status { get; set; }
        public DateTime AppliedDate { get; set; }
        public int PassedExamsCount { get; set; }

        public ApplicationStatusResponseDTO() { }
    }
}
