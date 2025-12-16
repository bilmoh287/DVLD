using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDDataAccessLayer
{
    public class clsTestsData
    {
        public static DataTable GetAllTests()
        {
            DataTable dtTests = new DataTable();
            string query = "SELECT * FROM Tests;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dtTests.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading Tests: " + ex.Message);
                }
            }
            return dtTests;
        }

        public static bool GetTestByID(
            int TestID,
            ref int TestAppointmentID,
            ref bool TestResult,
            ref string Notes,
            ref int CreatedByUserID)
        {
            bool isFound = false;
            string query = @"SELECT * FROM Tests WHERE TestID = @TestID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TestID", TestID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        TestAppointmentID = (int)reader["TestAppointmentID"];
                        TestResult = (bool)reader["TestResult"];
                        Notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : "";
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                        isFound = true;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error reading Test: " + ex.Message);
                }
            }
            return isFound;
        }

        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int newID = -1;
            string query = @"
                INSERT INTO Tests (TestAppointmentID, TestResult, Notes, CreatedByUserID)
                VALUES (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);
                SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                command.Parameters.AddWithValue("@TestResult", TestResult);
                command.Parameters.AddWithValue("@Notes", (object)Notes ?? DBNull.Value);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        newID = insertedID;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding Test: " + ex.Message);
                }
            }
            return newID;
        }

        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int rowsAffected = 0;
            string query = @"
                UPDATE Tests
                SET 
                    TestAppointmentID = @TestAppointmentID,
                    TestResult = @TestResult,
                    Notes = @Notes,
                    CreatedByUserID = @CreatedByUserID
                WHERE TestID = @TestID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TestID", TestID);
                command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                command.Parameters.AddWithValue("@TestResult", TestResult);
                command.Parameters.AddWithValue("@Notes", (object)Notes ?? DBNull.Value);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating Test: " + ex.Message);
                }
            }
            return (rowsAffected > 0);
        }

        public static bool DeleteTest(int TestID)
        {
            int rowsAffected = 0;
            string query = "DELETE FROM Tests WHERE TestID = @TestID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TestID", TestID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting Test: " + ex.Message);
                }
            }
            return (rowsAffected > 0);
        }

        public static bool GetLastTestByPersonAndTestTypeAndLicenseClass
            (int PersonID, int LicenseClassID, int TestTypeID, int LocalDrivingLicenseApplicationID, ref int TestID,
              ref int TestAppointmentID, ref bool TestResult,
              ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;
            string query = @"SELECT TOP 1 Tests.TestID, 
                            Tests.TestAppointmentID, Tests.TestResult, 
			                Tests.Notes, Tests.CreatedByUserID, Applications.ApplicantPersonID
                            FROM            LocalDrivingLicenseApplications INNER JOIN
                                                     Tests INNER JOIN
                                                     TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                                     Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                            WHERE        (Applications.ApplicantPersonID = @ApplicantPersonID) 
                                    AND (LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID)
                                    AND ( TestAppointments.TestTypeID= @TestTypeID)
                                    AND ( TestAppointments.LocalDrivingLicenseApplicationID= @LocalDrivingLicenseApplicationID)
                            ORDER BY Tests.TestAppointmentID DESC;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", TestTypeID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        TestID = (int)reader["TestID"];
                        TestAppointmentID = (int)reader["TestAppointmentID"];
                        TestResult = (bool)reader["TestResult"];
                        Notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : "";
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                        isFound = true;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error reading Test: " + ex.Message);
                }
            }
            return isFound;
        }

        public static int CountPassedTest(int LocalDrivingLicenseApplicationID)
        {
            int CountPassedTest = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT PassedTestCount = COUNT(Tests.TestID)
                                FROM     Tests INNER JOIN
                                                  TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                                WHERE TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND Tests.TestResult = 1;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();

                        if (result != null && byte.TryParse(result.ToString(), out byte returnedResult))
                        {
                            CountPassedTest = returnedResult;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error checking if Applicant Pass Test: " + ex.Message);
                    }
                }
            }

            return CountPassedTest;
        }
    }
}
