using System;

namespace DVLDDataAccessLayer.DTOs
{
    public class ScheduleTestRequestDTO
    {
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int TestTypeID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int CreatedByUserID { get; set; }
    }
}
