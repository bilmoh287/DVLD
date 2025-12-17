using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsLicensesData
    {
        public static bool GetLicenseInfoByID(
            int LicenseID,
            ref int ApplicationID,
            ref int DriverID,
            ref int LicenseClass,
            ref DateTime IssueDate,
            ref DateTime ExpirationDate,
            ref string Notes,
            ref decimal PaidFees,
            ref bool IsActive,
            ref byte IssueReason, // Using byte for tinyint
            ref int CreatedByUserID)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            isFound = true;
                            // Retrieve all attributes
                            ApplicationID = (int)reader["ApplicationID"];
                            DriverID = (int)reader["DriverID"];
                            LicenseClass = (int)reader["LicenseClass"];
                            IssueDate = (DateTime)reader["IssueDate"];
                            ExpirationDate = (DateTime)reader["ExpirationDate"];
                            Notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : "";
                            PaidFees = (decimal)reader["PaidFees"];
                            IsActive = (bool)reader["IsActive"];
                            IssueReason = (byte)reader["IssueReason"];
                            CreatedByUserID = (int)reader["CreatedByUserID"];
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        // Log error
                        Console.WriteLine("Error finding License: " + ex.Message);
                    }
                }
            }
            return isFound;
        }

        public static int AddNewLicense(
            int ApplicationID,
            int DriverID,
            int LicenseClass,
            DateTime IssueDate,
            DateTime ExpirationDate,
            string Notes,
            decimal PaidFees,
            bool IsActive,
            byte IssueReason,
            int CreatedByUserID)
        {
            int newLicenseID = -1;

            string query = @"
                INSERT INTO Licenses (ApplicationID, DriverID, LicenseClass, IssueDate, 
                                      ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
                VALUES (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, 
                        @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);
                SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                command.Parameters.AddWithValue("@DriverID", DriverID);
                command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                command.Parameters.AddWithValue("@IssueDate", IssueDate);
                command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                command.Parameters.AddWithValue("@IsActive", IsActive);
                command.Parameters.AddWithValue("@IssueReason", IssueReason);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        newLicenseID = insertedID;
                    }
                }
                catch (Exception ex)
                {
                    // Log error
                    Console.WriteLine("Error adding new License: " + ex.Message);
                }
            }
            return newLicenseID;
        }

        public static bool UpdateLicense(
            int LicenseID,
            int ApplicationID,
            int DriverID,
            int LicenseClass,
            DateTime IssueDate,
            DateTime ExpirationDate,
            string Notes,
            decimal PaidFees,
            bool IsActive,
            byte IssueReason,
            int CreatedByUserID)
        {
            int rowsAffected = 0;
            string query = @"
                UPDATE Licenses
                SET ApplicationID = @ApplicationID,
                    DriverID = @DriverID,
                    LicenseClass = @LicenseClass,
                    IssueDate = @IssueDate,
                    ExpirationDate = @ExpirationDate,
                    Notes = @Notes,
                    PaidFees = @PaidFees,
                    IsActive = @IsActive,
                    IssueReason = @IssueReason,
                    CreatedByUserID = @CreatedByUserID
                WHERE LicenseID = @LicenseID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@LicenseID", LicenseID);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                command.Parameters.AddWithValue("@DriverID", DriverID);
                command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                command.Parameters.AddWithValue("@IssueDate", IssueDate);
                command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                command.Parameters.AddWithValue("@IsActive", IsActive);
                command.Parameters.AddWithValue("@IssueReason", IssueReason);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log error
                    Console.WriteLine("Error updating License: " + ex.Message);
                }
            }
            return (rowsAffected > 0);
        }

        public static DataTable GetAllLicenses()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Licenses ORDER BY IssueDate DESC;";

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
                        Console.WriteLine("Error loading Licenses: " + ex.Message);
                    }
                }
            }
            return dt;
        }

        // Method 5: Check if License Exists
        public static bool IsLicenseExist(int LicenseID)
        {
            // Implementation similar to GetLicenseInfoByID but only checks for existence
            // ... (omitted for brevity)
            return false;
        }

        public static int GetActiveLicenseByPerosnIDAndClassName(int PerosnID, int LicenseClassID)
        {
            int LicenseID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT TOP 1 Licenses.LicenseID
                                FROM     Licenses INNER JOIN
                                                  Drivers ON Licenses.DriverID = Drivers.DriverID INNER JOIN
                                                  People ON Drivers.PersonID = People.PersonID
                                WHERE (People.PersonID = @PersonID) AND (LicenseClass = @LicenseClass) AND (Licenses.IsActive = 1);";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PerosnID);
                    command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && byte.TryParse(result.ToString(), out byte returnedResult))
                        {
                            LicenseID = returnedResult;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error checking if Applicant have active licenseID: " + ex.Message);
                    }
                }
            }

            return LicenseID;
        }
    }
}
