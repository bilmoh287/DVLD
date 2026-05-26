using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer.DTOs;


namespace DVLDDataAccessLayer
{
    public class clsDrivingInstituteData
    {
        public static DataTable GetAllInstitutes()
        {
            DataTable dt = new DataTable();
            string query = @"SELECT InstituteID, InstituteName, Address, City, Region, Phone, Email, ManagerName, Capacity, IsActive, CreatedByUserID, CommercialLicenseNo, LicenseExpiryDate, LogoPath, DocumentPath from DrivingInstitutes;";

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

        public static DrivingInstituteDTO GetInstituteInfoByID(int InstituteID)
        {
            DrivingInstituteDTO dto = null;
            string query = @"SELECT * FROM DrivingInstitutes WHERE InstituteID = @InstituteID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@InstituteID", InstituteID);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            dto = new DrivingInstituteDTO(
                                (int)reader["InstituteID"],
                                (string)reader["InstituteName"],
                                (string)reader["Address"],
                                (string)reader["Phone"],
                                (string)reader["Email"],
                                (bool)reader["IsActive"],
                                (int)reader["CreatedByUserID"],
                                (string)reader["CommercialLicenseNo"],
                                (DateTime)reader["LicenseExpiryDate"],
                                (string)reader["ManagerName"],
                                Convert.ToInt32(reader["Capacity"]),
                                reader["LogoPath"] == DBNull.Value ? "" : (string)reader["LogoPath"],
                                reader["DocumentPath"] == DBNull.Value ? "" : (string)reader["DocumentPath"],
                                reader["City"] == DBNull.Value ? "" : (string)reader["City"],
                                reader["Region"] == DBNull.Value ? "" : (string)reader["Region"]
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading Institute: " + ex.Message);
                }
            }
            return dto;
        }


        public static int AddNewInstitute(DrivingInstituteDTO dto)


        {
            int newID = -1;
            string query = @"INSERT INTO DrivingInstitutes (InstituteName, Address, Phone, Email, IsActive, CreatedByUserID,
                             CommercialLicenseNo, LicenseExpiryDate, ManagerName, Capacity, LogoPath, DocumentPath, City, Region)
                             VALUES (@InstituteName, @Address, @Phone, @Email, @IsActive, @CreatedByUserID,
                             @CommercialLicenseNo, @LicenseExpiryDate, @ManagerName, @Capacity, @LogoPath, @DocumentPath, @City, @Region);
                             SELECT SCOPE_IDENTITY();";


            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@InstituteName", dto.InstituteName);
                command.Parameters.AddWithValue("@Address", dto.Address);
                command.Parameters.AddWithValue("@Phone", dto.Phone);
                command.Parameters.AddWithValue("@Email", dto.Email);
                command.Parameters.AddWithValue("@IsActive", dto.IsActive);
                command.Parameters.AddWithValue("@CreatedByUserID", dto.CreatedByUserID);
                command.Parameters.AddWithValue("@CommercialLicenseNo", dto.CommercialLicenseNo);
                command.Parameters.AddWithValue("@LicenseExpiryDate", dto.LicenseExpiryDate);
                command.Parameters.AddWithValue("@ManagerName", dto.ManagerName);
                command.Parameters.AddWithValue("@Capacity", dto.Capacity);
                command.Parameters.AddWithValue("@LogoPath", (object)dto.LogoPath ?? DBNull.Value);
                command.Parameters.AddWithValue("@DocumentPath", (object)dto.DocumentPath ?? DBNull.Value);
                command.Parameters.AddWithValue("@City", (object)dto.City ?? DBNull.Value);
                command.Parameters.AddWithValue("@Region", (object)dto.Region ?? DBNull.Value);

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

        public static bool UpdateInstitute(DrivingInstituteDTO dto)


        {
            int rowsAffected = 0;
            string query = @"UPDATE DrivingInstitutes
                             SET InstituteName = @InstituteName,
                                 Address = @Address,
                                 Phone = @Phone,
                                 Email = @Email,
                                 IsActive = @IsActive,
                                 CreatedByUserID = @CreatedByUserID,
                                 CommercialLicenseNo = @CommercialLicenseNo,
                                 LicenseExpiryDate = @LicenseExpiryDate,
                                 ManagerName = @ManagerName,
                                 Capacity = @Capacity,
                                 LogoPath = @LogoPath,
                                 DocumentPath = @DocumentPath,
                                 City = @City,
                                 Region = @Region
                             WHERE InstituteID = @InstituteID";


            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@InstituteID", dto.InstituteID);
                command.Parameters.AddWithValue("@InstituteName", dto.InstituteName);
                command.Parameters.AddWithValue("@Address", dto.Address);
                command.Parameters.AddWithValue("@Phone", dto.Phone);
                command.Parameters.AddWithValue("@Email", dto.Email);
                command.Parameters.AddWithValue("@IsActive", dto.IsActive);
                command.Parameters.AddWithValue("@CreatedByUserID", dto.CreatedByUserID);
                command.Parameters.AddWithValue("@CommercialLicenseNo", dto.CommercialLicenseNo);
                command.Parameters.AddWithValue("@LicenseExpiryDate", dto.LicenseExpiryDate);
                command.Parameters.AddWithValue("@ManagerName", dto.ManagerName);
                command.Parameters.AddWithValue("@Capacity", dto.Capacity);
                command.Parameters.AddWithValue("@LogoPath", (object)dto.LogoPath ?? DBNull.Value);
                command.Parameters.AddWithValue("@DocumentPath", (object)dto.DocumentPath ?? DBNull.Value);
                command.Parameters.AddWithValue("@City", (object)dto.City ?? DBNull.Value);
                command.Parameters.AddWithValue("@Region", (object)dto.Region ?? DBNull.Value);


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
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    string query = @"DELETE FROM DrivingInstitutes WHERE InstituteID = @InstituteID;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InstituteID", InstituteID);
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting Institute: " + ex.Message);
            }

            return rowsAffected > 0;
        }

        public static int GetInstituteIDByUserID(int UserID)
        {
            int InstituteID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    string query = "SELECT TOP 1 InstituteID FROM InstituteInstructors WHERE UserID = @UserID AND IsActive = 1";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", UserID);
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int id))
                        {
                            InstituteID = id;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return InstituteID;
        }

        public static DataTable GetInstituteMobileDetailByID(int InstituteID)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT I.*, 
                    (SELECT COUNT(*) FROM Enrollments E WHERE E.InstituteID = I.InstituteID AND E.IsActive = 1) as EnrollmentCount,
                    (SELECT COUNT(*) FROM TrainingBatches B WHERE B.InstituteID = I.InstituteID AND B.Status = 'Active') as ActiveBatches
                FROM DrivingInstitutes I
                WHERE I.InstituteID = @InstituteID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@InstituteID", InstituteID);
                try
                {
                    connection.Open();
                    dt.Load(command.ExecuteReader());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return dt;
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
        public static bool LinkManagerToInstitute(int InstituteID, int UserID)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // 1. Deactivate existing manager of this institute
                            string query1 = "UPDATE InstituteInstructors SET IsActive = 0 WHERE InstituteID = @InstituteID AND IsManager = 1";
                            using (SqlCommand cmd1 = new SqlCommand(query1, connection, transaction))
                            {
                                cmd1.Parameters.AddWithValue("@InstituteID", InstituteID);
                                cmd1.ExecuteNonQuery();
                            }

                            // 2. Deactivate this user as manager from any other institute
                            string query2 = "UPDATE InstituteInstructors SET IsActive = 0 WHERE UserID = @UserID AND IsManager = 1";
                            using (SqlCommand cmd2 = new SqlCommand(query2, connection, transaction))
                            {
                                cmd2.Parameters.AddWithValue("@UserID", UserID);
                                cmd2.ExecuteNonQuery();
                            }

                            // 3. Check if record exists
                            bool exists = false;
                            string query3 = "SELECT COUNT(*) FROM InstituteInstructors WHERE InstituteID = @InstituteID AND UserID = @UserID";
                            using (SqlCommand cmd3 = new SqlCommand(query3, connection, transaction))
                            {
                                cmd3.Parameters.AddWithValue("@InstituteID", InstituteID);
                                cmd3.Parameters.AddWithValue("@UserID", UserID);
                                exists = ((int)cmd3.ExecuteScalar() > 0);
                            }

                            // 4. Update or Insert
                            string query4 = "";
                            if (exists)
                            {
                                query4 = "UPDATE InstituteInstructors SET IsManager = 1, IsActive = 1, HireDate = GETDATE() WHERE InstituteID = @InstituteID AND UserID = @UserID";
                            }
                            else
                            {
                                query4 = "INSERT INTO InstituteInstructors (InstituteID, UserID, IsManager, IsActive, HireDate) VALUES (@InstituteID, @UserID, 1, 1, GETDATE())";
                            }

                            using (SqlCommand cmd4 = new SqlCommand(query4, connection, transaction))
                            {
                                cmd4.Parameters.AddWithValue("@InstituteID", InstituteID);
                                cmd4.Parameters.AddWithValue("@UserID", UserID);
                                rowsAffected = cmd4.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Console.WriteLine("Transaction Error: " + ex.Message);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection Error: " + ex.Message);
                return false;
            }
        }

        public static int GetInstituteManagerUserID(int InstituteID)
        {
            int UserID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    string query = "SELECT TOP 1 UserID FROM InstituteInstructors WHERE InstituteID = @InstituteID AND IsManager = 1 AND IsActive = 1";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InstituteID", InstituteID);
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int id))
                        {
                            UserID = id;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting manager UserID: " + ex.Message);
            }
            return UserID;
        }

        public static DataTable GetInstructorsByInstituteID(int InstituteID)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT ii.InstructorID, ii.UserID, u.UserName, 
                       p.FirstName + ' ' + p.LastName as FullName, 
                       p.Phone, p.Email, ii.IsActive, ii.IsManager, ii.HireDate 
                FROM InstituteInstructors ii 
                INNER JOIN Users u ON ii.UserID = u.UserID 
                INNER JOIN People p ON u.PersonID = p.PersonID 
                WHERE ii.InstituteID = @InstituteID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@InstituteID", InstituteID);
                try
                {
                    connection.Open();
                    dt.Load(command.ExecuteReader());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error getting instructors: " + ex.Message);
                }
            }
            return dt;
        }

        public static bool AddInstructorToInstitute(int InstituteID, int UserID)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    connection.Open();
                    // 1. Check if record exists
                    bool exists = false;
                    string queryCheck = "SELECT COUNT(*) FROM InstituteInstructors WHERE InstituteID = @InstituteID AND UserID = @UserID";
                    using (SqlCommand cmdCheck = new SqlCommand(queryCheck, connection))
                    {
                        cmdCheck.Parameters.AddWithValue("@InstituteID", InstituteID);
                        cmdCheck.Parameters.AddWithValue("@UserID", UserID);
                        exists = ((int)cmdCheck.ExecuteScalar() > 0);
                    }

                    // 2. Insert or Update
                    string querySave = "";
                    if (exists)
                    {
                        querySave = "UPDATE InstituteInstructors SET IsActive = 1, IsManager = 0, HireDate = GETDATE() WHERE InstituteID = @InstituteID AND UserID = @UserID";
                    }
                    else
                    {
                        querySave = "INSERT INTO InstituteInstructors (InstituteID, UserID, IsManager, IsActive, HireDate) VALUES (@InstituteID, @UserID, 0, 1, GETDATE())";
                    }

                    using (SqlCommand cmdSave = new SqlCommand(querySave, connection))
                    {
                        cmdSave.Parameters.AddWithValue("@InstituteID", InstituteID);
                        cmdSave.Parameters.AddWithValue("@UserID", UserID);
                        rowsAffected = cmdSave.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding instructor: " + ex.Message);
                return false;
            }
            return rowsAffected > 0;
        }

        public static bool RemoveInstructorFromInstitute(int InstituteID, int UserID)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    connection.Open();
                    // We deactivate the instructor: IsActive = 0
                    string query = "UPDATE InstituteInstructors SET IsActive = 0 WHERE InstituteID = @InstituteID AND UserID = @UserID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@InstituteID", InstituteID);
                        command.Parameters.AddWithValue("@UserID", UserID);
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error removing instructor: " + ex.Message);
                return false;
            }
            return rowsAffected > 0;
        }
    }
}
