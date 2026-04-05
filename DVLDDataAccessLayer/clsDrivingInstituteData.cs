using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsDrivingInstituteData
    {
        public static DataTable GetAllInstitutes()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT InstituteID, InstituteName, Address, Phone, Email, IsActive from DrivingInstitutes;";

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
                    // Manual comments preserved as per your instruction
                    Console.WriteLine("Error loading Institutes: " + ex.Message);
                }
            }
            return dt;
        }

        public static bool GetInstituteInfoByID(int InstituteID, ref string InstituteName,
            ref string Address, ref string Phone, ref string Email, ref bool IsActive, ref int CreatedByUserID)
        {
            bool isFound = false;
            string query = @"SELECT * FROM DrivingInstitutes WHERE InstituteID = @InstituteID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@InstituteID", InstituteID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        isFound = true;
                        InstituteName = (string)reader["InstituteName"];
                        Address = (string)reader["Address"];
                        Phone = (string)reader["Phone"];
                        Email = (string)reader["Email"];
                        IsActive = (bool)reader["IsActive"];
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading Institute: " + ex.Message);
                }
            }
            return isFound;
        }

        public static int AddNewInstitute(string InstituteName, string Address,
            string Phone, string Email, bool IsActive, int CreatedByUserID)
        {
            int newID = -1;
            string query = @"INSERT INTO DrivingInstitutes (InstituteName, Address, Phone, Email, IsActive, CreatedByUserID)
                             VALUES (@InstituteName, @Address, @Phone, @Email, @IsActive, @CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@InstituteName", InstituteName);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@Phone", Phone);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@IsActive", IsActive);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                        newID = Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding Institute: " + ex.Message);
                }
            }
            return newID;
        }

        public static bool UpdateInstitute(int InstituteID, string InstituteName, string Address,
            string Phone, string Email, bool IsActive, int CreatedByUserID)
        {
            int rowsAffected = 0;
            string query = @"UPDATE DrivingInstitutes
                             SET InstituteName = @InstituteName,
                                 Address = @Address,
                                 Phone = @Phone,
                                 Email = @Email,
                                 IsActive = @IsActive,
                                 CreatedByUserID = @CreatedByUserID
                             WHERE InstituteID = @InstituteID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@InstituteID", InstituteID);
                command.Parameters.AddWithValue("@InstituteName", InstituteName);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@Phone", Phone);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@IsActive", IsActive);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating Institute: " + ex.Message);
                }
            }
            return (rowsAffected > 0);
        }

        public static bool DeleteInstitute(int InstituteID)
        {
            int rowsAffected = 0;
            string query = @"DELETE FROM DrivingInstitutes WHERE InstituteID = @InstituteID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@InstituteID", InstituteID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting Institute: " + ex.Message);
                }
            }
            return (rowsAffected > 0);
        }

        public static bool IsInstituteExist(int InstituteID)
        {
            bool exists = false;
            string query = @"SELECT 1 FROM DrivingInstitutes WHERE InstituteID = @InstituteID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@InstituteID", InstituteID);

                try
                {
                    connection.Open();
                    exists = command.ExecuteScalar() != null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error checking Institute existence: " + ex.Message);
                }
            }
            return exists;
        }
    }
}
