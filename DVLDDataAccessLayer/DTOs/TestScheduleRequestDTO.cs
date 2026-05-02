using System;

namespace DVLDDataAccessLayer.DTOs
{
    public class TestScheduleRequestDTO
    {
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int TestTypeID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int CreatedByUserID { get; set; }

        public TestScheduleRequestDTO() { }
    }
}
