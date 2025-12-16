using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsDriversData
    {
        public static DataTable GetAllDrivers()
        {
            DataTable dt = new DataTable();

            string query = @"SELECT * FROM Drivers ORDER BY CreatedDate DESC";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    dt.Load(command.ExecuteReader());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading Drivers: " + ex.Message);
                }
            }

            return dt;
        }

        public static bool GetDriverInfoByID(
            int driverID,
            ref int personID,
            ref int createdByUserID,
            ref DateTime createdDate)
        {
            bool isFound = false;

            string query = @"SELECT * FROM Drivers WHERE DriverID = @DriverID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DriverID", driverID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        isFound = true;
                        personID = (int)reader["PersonID"];
                        createdByUserID = (int)reader["CreatedByUserID"];
                        createdDate = Convert.ToDateTime(reader["CreatedDate"]);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading Driver: " + ex.Message);
                }
            }

            return isFound;
        }

        public static int AddNewDriver(
            int personID,
            int createdByUserID,
            DateTime createdDate)
        {
            int newID = -1;

            string query = @"INSERT INTO Drivers (PersonID, CreatedByUserID, CreatedDate)
                             VALUES (@PersonID, @CreatedByUserID, @CreatedDate);
                             SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonID", personID);
                command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
                command.Parameters.AddWithValue("@CreatedDate", createdDate);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                        newID = Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding Driver: " + ex.Message);
                }
            }

            return newID;
        }

        public static bool UpdateDriver(
            int driverID,
            int personID,
            int createdByUserID,
            DateTime createdDate)
        {
            int rowsAffected = 0;

            string query = @"UPDATE Drivers
                             SET PersonID = @PersonID,
                                 CreatedByUserID = @CreatedByUserID,
                                 CreatedDate = @CreatedDate
                             WHERE DriverID = @DriverID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DriverID", driverID);
                command.Parameters.AddWithValue("@PersonID", personID);
                command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
                command.Parameters.AddWithValue("@CreatedDate", createdDate);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating Driver: " + ex.Message);
                }
            }

            return (rowsAffected > 0);
        }

        public static bool DeleteDriver(int driverID)
        {
            int rowsAffected = 0;

            string query = @"DELETE FROM Drivers WHERE DriverID = @DriverID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DriverID", driverID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting Driver: " + ex.Message);
                }
            }

            return (rowsAffected > 0);
        }

        public static bool IsDriverExist(int driverID)
        {
            bool exists = false;

            string query = @"SELECT 1 FROM Drivers WHERE DriverID = @DriverID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DriverID", driverID);

                try
                {
                    connection.Open();
                    exists = command.ExecuteScalar() != null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error checking Driver existence: " + ex.Message);
                }
            }

            return exists;
        }
    }
}
