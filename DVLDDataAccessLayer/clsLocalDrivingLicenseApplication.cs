using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsLocalDrivingLicenseApplicationData
    {
        public static DataTable GetAllApplicationsList()
        {
            DataTable dtTestTypes = new DataTable();

            string query = @"select * from LocalDrivingLicenseApplications_View
                             ORDER BY ApplicationDate DESC;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
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
        }

        public static bool GetLocalDrivingLicenseApplicationInfoByID(int LocalDrivingLicenseApplicationID,
           ref int ApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT * FROM LocalDrivingLicenseApplications
                                 WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            isFound = true;

                            ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                            LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]);
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error loading Local Driving License Application: " + ex.Message);
                    }
                }
            }

            return isFound;
        }

        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            int newID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID)
                                 VALUES (@ApplicationID, @LicenseClassID);
                                 SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null)
                            newID = Convert.ToInt32(result);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error adding Local Driving License Application: " + ex.Message);
                    }
                }
            }

            return newID;
        }

        public static bool UpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID,
            int ApplicationID, int LicenseClassID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"UPDATE LocalDrivingLicenseApplications
                                 SET ApplicationID = @ApplicationID,
                                     LicenseClassID = @LicenseClassID
                                 WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error updating Local Driving License Application: " + ex.Message);
                    }
                }
            }

            return (rowsAffected > 0);
        }

        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"DELETE FROM LocalDrivingLicenseApplications
                                 WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error deleting Local Driving License Application: " + ex.Message);
                    }
                }
            }

            return (rowsAffected > 0);
        }

        public static bool IsApplicationExist(int LocalDrivingLicenseApplicationID)
        {
            bool IsExists = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string Query = @"SELECT 1 FROM LocalDrivingLicenseApplications WHERE 
                                LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                    try
                    {
                        connection.Open();
                        object res = command.ExecuteScalar();
                        IsExists = res != null;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return IsExists;
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool DeoesHaveActiveAppointment = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT TOP 1 found = 1 FROM TestAppointments
                                WHERE TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                                        AND TestAppointments.TestTypeID = @TestTypeID
		                                AND IsLocked = 0
                                ORDER BY TestAppointments.AppointmentDate DESC;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        DeoesHaveActiveAppointment = result != null;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error checking if Applicant has Active Appointment: " + ex.Message);
                    }
                }
            }

            return DeoesHaveActiveAppointment;
        }

        public static bool DoesAtendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool DoesAttend = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT TOP 1 Found = 1
                                FROM     TestAppointments INNER JOIN
                                                  LocalDrivingLicenseApplications ON TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                                WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID  
                                        AND TestAppointments.TestTypeID = @TestTypeID
                                ORDER BY TestAppointments.AppointmentDate DESC;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        DoesAttend = result != null;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error checking if Applicant Attend Test: " + ex.Message);
                    }
                }
            }

            return DoesAttend;
        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool DoesPass = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT TOP 1 Tests.TestResult
                                FROM     TestAppointments INNER JOIN
                                                  Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                                WHERE TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
		                                AND TestAppointments.TestTypeID = @TestTypeID
                                ORDER BY AppointmentDate DESC;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && bool.TryParse(result.ToString(), out bool returnedResult))
                        {
                            DoesPass = returnedResult;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error checking if Applicant Pass Test: " + ex.Message);
                    }
                }
            }

            return DoesPass;
        }

        public static int TotalTrialPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            int TotalTrialsPerTest = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT TotalTrialPerTest = COUNT(TestID)
                                FROM     TestAppointments INNER JOIN
                                                  Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                                WHERE TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                                      AND TestAppointments.TestTypeID = @TestTypeID;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                    command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        TotalTrialsPerTest = (result == null) ? 0 : Convert.ToInt32(result);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error counting trials per test: " + ex.Message);
                    }
                }
            }

            return TotalTrialsPerTest;
        }
    }
}
