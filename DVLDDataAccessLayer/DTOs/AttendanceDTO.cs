using System;

namespace DVLDDataAccessLayer.DTOs
{
    public class AttendanceDTO
    {
        public int AttendanceID { get; set; }
        public int ApplicationID { get; set; }
        public int BatchID { get; set; }
        public DateTime AttendanceDate { get; set; }
        public bool IsPresent { get; set; }
        public bool IsLate { get; set; }
        public int MarkedByUserID { get; set; }

        public AttendanceDTO() { }

        public AttendanceDTO(int attendanceID, int applicationID, int batchID, DateTime attendanceDate, bool isPresent, bool isLate, int markedByUserID)
        {
            this.AttendanceID = attendanceID;
            this.ApplicationID = applicationID;
            this.BatchID = batchID;
            this.AttendanceDate = attendanceDate;
            this.IsPresent = isPresent;
            this.IsLate = isLate;
            this.MarkedByUserID = markedByUserID;
        }
    }
}
