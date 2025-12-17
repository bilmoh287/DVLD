using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsApplicationData
    {
        public static DataTable GetAllApplicationsList()
        {
            DataTable dtTestTypes = new DataTable();

            string query = "SELECT * FROM Applications;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dtTestTypes.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading TestTypes: " + ex.Message);
                }
            }

            return dtTestTypes;
        }

        public static bool GetApplicationInfoByID(int ApplicationID,
            ref int ApplicantPersonID, ref DateTime ApplicationDate,
            ref int ApplicationTypeID, ref byte ApplicationStatus,
            ref DateTime LastStatusDate, ref decimal PaidFees, ref int CreatedByUserID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = "SELECT * FROM Applications WHERE ApplicationID = @ApplicationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        isFound = true;
                        ApplicantPersonID = (int)reader["ApplicantPersonID"];
                        ApplicationDate = (DateTime)reader["ApplicationDate"];
                        ApplicationTypeID = (int)reader["ApplicationTypeID"];
                        ApplicationStatus = Convert.ToByte(reader["ApplicationStatus"]);
                        LastStatusDate = (DateTime)reader["LastStatusDate"];
                        PaidFees = Convert.ToDecimal(reader["PaidFees"]);
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading TestTypes: " + ex.Message);
                }
            }

            return isFound;
        }

        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate,
                                    int ApplicationTypeID, byte ApplicationStatus,
                                    DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            int ApplicationID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"INSERT INTO Applications
                                (ApplicantPersonID, ApplicationDate, ApplicationTypeID, 
                                 ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
                                 VALUES (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, 
                                         @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID);
                                 SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                //command.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = PaidFees;
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                try
                {
                    connection.Open();
                    ApplicationID = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading TestTypes: " + ex.Message);

                }
            }

            return ApplicationID;
        }

        public static bool UpdateApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
                                             int ApplicationTypeID, byte ApplicationStatus,
                                             DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"UPDATE Applications
                                 SET ApplicantPersonID = @ApplicantPersonID,
                                     ApplicationDate = @ApplicationDate,
                                     ApplicationTypeID = @ApplicationTypeID,
                                     ApplicationStatus = @ApplicationStatus,
                                     LastStatusDate = @LastStatusDate,
                                     PaidFees = @PaidFees,
                                     CreatedByUserID = @CreatedByUserID
                                 WHERE ApplicationID = @ApplicationID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
                command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
                command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                command.Parameters.AddWithValue("@PaidFees", PaidFees);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading TestTypes: " + ex.Message);
                }
            }

            return (rowsAffected > 0);
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = "DELETE FROM Applications WHERE ApplicationID = @ApplicationID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading TestTypes: " + ex.Message);
                }
            }

            return (rowsAffected > 0);
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int ApplicationTypeID, int LicenseClassID)
        {
            int ActiveApplicationID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string Query = @"SELECT Applications.ApplicationID
                                FROM     Applications INNER JOIN
                                                  LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID INNER JOIN
                                                  LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID
                                WHERE LicenseClasses.LicenseClassID = @LicenseClassID AND ApplicantPersonID = @PersonID AND Applications.ApplicationTypeID = @ApplicationTypeID
                                      AND ApplicationStatus = 1;";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                    command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int AppID))
                        {
                            ActiveApplicationID = AppID;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return ActiveApplicationID;
        }

        public static bool UpdateStatus(int ApplicationID, byte NewApplicationStatus)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"Update  Applications  
                            set 
                                ApplicationStatus = @NewApplicationStatus, 
                                LastStatusDate = @LastStatusDate
                            where ApplicationID=@ApplicationID;";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                command.Parameters.AddWithValue("@NewApplicationStatus", NewApplicationStatus);
                command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading TestTypes: " + ex.Message);
                }
            }

            return (rowsAffected > 0);
        }
    }
}
