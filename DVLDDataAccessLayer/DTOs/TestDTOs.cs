using System;

namespace DVLDDataAccessLayer.DTOs
{
    public class TestAppointmentDTO
    {
        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsLocked { get; set; }

        public TestAppointmentDTO() { }
    }

    public class TestResultDTO
    {
        public int TestID { get; set; }
        public string TestTypeTitle { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public DateTime TestDate { get; set; }

        public TestResultDTO() { }
    }
}
