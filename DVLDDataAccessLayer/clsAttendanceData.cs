using System;
using System.Data;
using System.Data.SqlClient;
using DVLDDataAccessLayer.DTOs;

namespace DVLDDataAccessLayer
{
    public class clsAttendanceData
    {
        public static int AddAttendance(AttendanceDTO attendanceDTO)
        {
            int AttendanceID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"INSERT INTO Attendance (ApplicationID, TrainingBatchID, AttendanceDate, IsPresent, MarkedByUserID)
                                 VALUES (@ApplicationID, @BatchID, @Date, @IsPresent, @MarkedByUserID);
                                 SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", attendanceDTO.ApplicationID);
                command.Parameters.AddWithValue("@BatchID", attendanceDTO.BatchID);
                command.Parameters.AddWithValue("@Date", attendanceDTO.AttendanceDate);
                command.Parameters.AddWithValue("@IsPresent", attendanceDTO.IsPresent);
                command.Parameters.AddWithValue("@MarkedByUserID", attendanceDTO.MarkedByUserID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        AttendanceID = insertedID;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return AttendanceID;
        }

        public static DataTable GetAttendanceByBatch(int BatchID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT AT.AttendanceID, P.FirstName + ' ' + P.LastName AS FullName, 
                                        AT.AttendanceDate, AT.IsPresent
                                 FROM Attendance AT
                                 INNER JOIN Applications A ON AT.ApplicationID = A.ApplicationID
                                 INNER JOIN People P ON A.ApplicantPersonID = P.PersonID
                                 WHERE AT.TrainingBatchID = @BatchID
                                 ORDER BY AT.AttendanceDate DESC";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BatchID", BatchID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return dt;
        }
    }
}
