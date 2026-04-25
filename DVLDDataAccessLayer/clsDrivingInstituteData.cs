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
            string query = @"SELECT * from DrivingInstitutes;";

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
                                reader["DocumentPath"] == DBNull.Value ? "" : (string)reader["DocumentPath"]
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
                             CommercialLicenseNo, LicenseExpiryDate, ManagerName, Capacity, LogoPath, DocumentPath)
                             VALUES (@InstituteName, @Address, @Phone, @Email, @IsActive, @CreatedByUserID,
                             @CommercialLicenseNo, @LicenseExpiryDate, @ManagerName, @Capacity, @LogoPath, @DocumentPath);
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
                                 DocumentPath = @DocumentPath
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
    }
}
