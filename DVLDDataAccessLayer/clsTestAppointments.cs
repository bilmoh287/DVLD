using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsTestAppointmentsData
    {
        public static DataTable GetAllTestAppointments()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT * FROM TestAppointments_View
                             ORDER BY AppointmentDate DESC;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error loading TestAppointments: " + ex.Message);
                    }
                }
            }

            return dt;
        }

        public static bool GetTestAppointmentInfoByID(
            int TestAppointmentID,
            ref int TestTypeID,
            ref int LocalDrivingLicenseApplicationID,
            ref DateTime AppointmentDate,
            ref decimal PaidFees,
            ref int CreatedByUserID,
            ref bool IsLocked,
            ref int RetakeTestApplicationID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT * FROM TestAppointments 
                                 WHERE TestAppointmentID = @TestAppointmentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            isFound = true;

                            TestTypeID = Convert.ToInt32(reader["TestTypeID"]);
                            LocalDrivingLicenseApplicationID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]);
                            AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                            PaidFees = Convert.ToDecimal(reader["PaidFees"]);
                            CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                            IsLocked = Convert.ToBoolean(reader["IsLocked"]);
                            RetakeTestApplicationID = (reader["RetakeTestApplicationID"] == DBNull.Value) ? -1 : (int)reader["RetakeTestApplicationID"];
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error loading TestAppointment: " + ex.Message);
                    }
                }
            }

            return isFound;
        }

        public static int AddNewTestAppointment(
            int TestTypeID,
            int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate,
            decimal PaidFees,
            int CreatedByUserID,
            bool IsLocked)
        {
            int newID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"INSERT INTO TestAppointments 
                                (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked)
                                VALUES (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, @IsLocked);
                                SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@IsLocked", IsLocked);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                            newID = Convert.ToInt32(result);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error adding TestAppointment: " + ex.Message);
                    }
                }
            }

            return newID;
        }

        public static bool UpdateTestAppointment(
            int TestAppointmentID,
            int TestTypeID,
            int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate,
            decimal PaidFees,
            int CreatedByUserID,
            bool IsLocked)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"UPDATE TestAppointments
                                 SET TestTypeID = @TestTypeID,
                                     LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,
                                     AppointmentDate = @AppointmentDate,
                                     PaidFees = @PaidFees,
                                     CreatedByUserID = @CreatedByUserID,
                                     IsLocked = @IsLocked
                                 WHERE TestAppointmentID = @TestAppointmentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@IsLocked", IsLocked);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error updating TestAppointment: " + ex.Message);
                    }
                }
            }

            return (rowsAffected > 0);
        }

        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"DELETE FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error deleting TestAppointment: " + ex.Message);
                    }
                }
            }

            return (rowsAffected > 0);
        }

        public static bool IsTestAppointmentExist(int TestAppointmentID)
        {
            bool exists = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT 1 FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        exists = result != null;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error checking if TestAppointment exists: " + ex.Message);
                    }
                }
            }

            return exists;
        }
    }
}
