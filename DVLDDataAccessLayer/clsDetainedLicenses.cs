using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsDetainedLicensesData
    {
        public static bool GetDetainInfoByID(
            int DetainID,
            ref int LicenseID,
            ref DateTime DetainDate,
            ref string DetainReason,
            ref string DetainPlace,
            ref decimal FineFees,
            ref int CreatedByUserID,
            ref bool IsReleased,
            ref DateTime? ReleaseDate,
            ref int? ReleasedByUserID,
            ref int? ReleaseApplicationID)
        {
            bool isFound = false;

            using (SqlConnection connection =
                   new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT * FROM DetainedLicenses
                                 WHERE DetainID = @DetainID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DetainID", DetainID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            isFound = true;

                            LicenseID = (int)reader["LicenseID"];
                            DetainDate = (DateTime)reader["DetainDate"];
                            DetainReason = reader["DetainReason"] != DBNull.Value ?
                                           (string)reader["DetainReason"] : "";
                            DetainPlace = reader["DetainPlace"] != DBNull.Value ?
                                          (string)reader["DetainPlace"] : "";
                            FineFees = (decimal)reader["FineFees"];
                            CreatedByUserID = (int)reader["CreatedByUserID"];
                            IsReleased = (bool)reader["IsReleased"];

                            ReleaseDate = reader["ReleaseDate"] != DBNull.Value ?
                                          (DateTime?)reader["ReleaseDate"] : null;

                            ReleasedByUserID = reader["ReleasedByUserID"] != DBNull.Value ?
                                               (int?)reader["ReleasedByUserID"] : null;

                            ReleaseApplicationID = reader["ReleaseApplicationID"] != DBNull.Value ?
                                                   (int?)reader["ReleaseApplicationID"] : null;
                        }

                        reader.Close();
                    }
                    catch
                    {
                        isFound = false;
                    }
                }
            }

            return isFound;
        }
        public static bool GetDetainInfoByLicenseID(
    int LicenseID,
    ref int DetainID,
    ref DateTime DetainDate,
    ref string DetainReason,
    ref string DetainPlace,
    ref decimal FineFees,
    ref int CreatedByUserID,
    ref bool IsReleased,
    ref DateTime? ReleaseDate,
    ref int? ReleasedByUserID,
    ref int? ReleaseApplicationID)
        {
            bool isFound = false;

            using (SqlConnection connection =
                   new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT TOP 1 *
                         FROM DetainedLicenses
                         WHERE LicenseID = @LicenseID
                         ORDER BY DetainDate DESC";

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

                            DetainID = (int)reader["DetainID"];
                            DetainDate = (DateTime)reader["DetainDate"];
                            DetainReason = reader["DetainReason"] != DBNull.Value
                                ? (string)reader["DetainReason"] : "";

                            DetainPlace = reader["DetainPlace"] != DBNull.Value
                                ? (string)reader["DetainPlace"] : "";

                            FineFees = (decimal)reader["FineFees"];
                            CreatedByUserID = (int)reader["CreatedByUserID"];
                            IsReleased = (bool)reader["IsReleased"];

                            ReleaseDate = reader["ReleaseDate"] != DBNull.Value
                                ? (DateTime?)reader["ReleaseDate"] : null;

                            ReleasedByUserID = reader["ReleasedByUserID"] != DBNull.Value
                                ? (int?)reader["ReleasedByUserID"] : null;

                            ReleaseApplicationID = reader["ReleaseApplicationID"] != DBNull.Value
                                ? (int?)reader["ReleaseApplicationID"] : null;
                        }

                        reader.Close();
                    }
                    catch
                    {
                        isFound = false;
                    }
                }
            }

            return isFound;
        }

        public static int AddNewDetain(
            int LicenseID,
            DateTime DetainDate,
            string DetainReason,
            string DetainPlace,
            decimal FineFees,
            int CreatedByUserID)
        {
            int DetainID = -1;

            using (SqlConnection connection =
                   new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"INSERT INTO DetainedLicenses
                                 (LicenseID, DetainDate, DetainReason,
                                  DetainPlace, FineFees, CreatedByUserID, IsReleased)
                                 VALUES
                                 (@LicenseID, @DetainDate, @DetainReason,
                                  @DetainPlace, @FineFees, @CreatedByUserID, 0);

                                 SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@DetainDate", DetainDate);
                    command.Parameters.AddWithValue("@DetainReason",
                        string.IsNullOrEmpty(DetainReason) ? (object)DBNull.Value : DetainReason);
                    command.Parameters.AddWithValue("@DetainPlace",
                        string.IsNullOrEmpty(DetainPlace) ? (object)DBNull.Value : DetainPlace);
                    command.Parameters.AddWithValue("@FineFees", FineFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null)
                            DetainID = Convert.ToInt32(result);
                    }
                    catch
                    {
                        DetainID = -1;
                    }
                }
            }

            return DetainID;
        }

        public static bool UpdateDetain(
            int DetainID,
            int LicenseID,
            DateTime DetainDate,
            string DetainReason,
            string DetainPlace,
            decimal FineFees,
            int CreatedByUserID,
            bool IsReleased,
            DateTime? ReleaseDate,
            int? ReleasedByUserID,
            int? ReleaseApplicationID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection =
                   new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"UPDATE DetainedLicenses SET
                                    LicenseID = @LicenseID,
                                    DetainDate = @DetainDate,
                                    DetainReason = @DetainReason,
                                    DetainPlace = @DetainPlace,
                                    FineFees = @FineFees,
                                    CreatedByUserID = @CreatedByUserID,
                                    IsReleased = @IsReleased,
                                    ReleaseDate = @ReleaseDate,
                                    ReleasedByUserID = @ReleasedByUserID,
                                    ReleaseApplicationID = @ReleaseApplicationID
                                 WHERE DetainID = @DetainID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DetainID", DetainID);
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@DetainDate", DetainDate);
                    command.Parameters.AddWithValue("@DetainReason",
                        string.IsNullOrEmpty(DetainReason) ? (object)DBNull.Value : DetainReason);
                    command.Parameters.AddWithValue("@DetainPlace",
                        string.IsNullOrEmpty(DetainPlace) ? (object)DBNull.Value : DetainPlace);
                    command.Parameters.AddWithValue("@FineFees", FineFees);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@IsReleased", IsReleased);
                    command.Parameters.AddWithValue("@ReleaseDate",
                        ReleaseDate.HasValue ? (object)ReleaseDate.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@ReleasedByUserID",
                        ReleasedByUserID.HasValue ? (object)ReleasedByUserID.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@ReleaseApplicationID",
                        ReleaseApplicationID.HasValue ? (object)ReleaseApplicationID.Value : DBNull.Value);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch
                    {
                        return false;
                    }
                }
            }

            return (rowsAffected > 0);
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            using (SqlConnection connection =
                   new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT 1 FROM DetainedLicenses
                                 WHERE LicenseID = @LicenseID AND IsReleased = 0";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    connection.Open();
                    return command.ExecuteScalar() != null;
                }
            }
        }

        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection =
                   new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = "SELECT * FROM DetainedLicenses";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                }
            }

            return dt;
        }

        public static DataTable GetDetainedLicensesByLicenseID(int LicenseID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection =
                   new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT * FROM DetainedLicenses
                                 WHERE LicenseID = @LicenseID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                }
            }

            return dt;
        }

    }
}
