using System;
using System.Data;
using DVLDDataAccessLayer;
using DVLDDataAccessLayer.DTOs;

namespace DVLDBussinessLayer
{
    public class clsAttendance
    {
        public static bool MarkAttendance(int ApplicationID, int BatchID, DateTime Date, bool IsPresent, int MarkedByUserID)
        {
            AttendanceDTO attendanceDTO = new AttendanceDTO(
                -1, // ID not needed for insert
                ApplicationID,
                BatchID,
                Date,
                IsPresent,
                MarkedByUserID
            );

            return clsAttendanceData.AddAttendance(attendanceDTO) != -1;
        }

        public static DataTable GetBatchAttendance(int BatchID)
        {
            return clsAttendanceData.GetAttendanceByBatch(BatchID);
        }
    }
}
