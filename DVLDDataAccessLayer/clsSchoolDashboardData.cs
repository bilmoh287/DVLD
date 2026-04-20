using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDDataAccessLayer
{
    /// <summary>
    /// Provides lightweight aggregate queries for the School Dashboard KPI cards.
    /// Each method is scoped strictly to the given InstituteID for multi-tenant safety.
    /// </summary>
    public class clsSchoolDashboardData
    {
        /// <summary>
        /// Returns the number of active students enrolled at the institute.
        /// Delegates to clsEnrollmentData to keep a single source of truth.
        /// </summary>
        public static int GetTotalStudentCount(int InstituteID)
        {
            return clsEnrollmentData.GetTotalStudentCount(InstituteID);
        }

        /// <summary>
        /// Returns the number of new students enrolled this calendar month.
        /// </summary>
        public static int GetNewStudentsThisMonth(int InstituteID)
        {
            int count = 0;
            string query = @"
                SELECT COUNT(*) FROM Enrollments
                WHERE InstituteID = @InstituteID
                  AND MONTH(EnrollmentDate) = MONTH(GETDATE())
                  AND YEAR(EnrollmentDate)  = YEAR(GETDATE())";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@InstituteID", InstituteID);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                        count = Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error counting new students this month: " + ex.Message);
                }
            }
            return count;
        }

        /// <summary>
        /// Returns the number of courses offered by this institute.
        /// </summary>
        public static int GetActiveCourseCount(int InstituteID)
        {
            int count = 0;

            string query = @"
                SELECT COUNT(*) FROM InstituteCourses
                WHERE InstituteID = @InstituteID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@InstituteID", InstituteID);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                        count = Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error counting active courses: " + ex.Message);
                }
            }
            return count;
        }

        /// <summary>
        /// Returns the total number of instructors registered at this institute.
        /// </summary>
        public static int GetTotalInstructorCount(int InstituteID)
        {
            int count = 0;
            string query = @"
                SELECT COUNT(*) FROM Instructors
                WHERE InstituteID = @InstituteID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@InstituteID", InstituteID);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                        count = Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error counting instructors: " + ex.Message);
                }
            }
            return count;
        }

        /// <summary>
        /// Returns the number of test appointments scheduled today for applicants
        /// whose LDL application is linked to this institute.
        /// </summary>
        public static int GetTestsTodayCount(int InstituteID)
        {
            int count = 0;
            string query = @"
                SELECT COUNT(*)
                FROM   TestAppointments TA
                INNER JOIN LocalDrivingLicenseApplications LDLA
                       ON TA.LocalDrivingLicenseApplicationID = LDLA.LocalDrivingLicenseApplicationID
                WHERE  LDLA.InstituteID = @InstituteID
                  AND  CAST(TA.AppointmentDate AS DATE) = CAST(GETDATE() AS DATE)";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@InstituteID", InstituteID);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                        count = Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error counting tests today: " + ex.Message);
                }
            }
            return count;
        }

        /// <summary>
        /// Returns the pass rate (0-100) for a given test type at this institute this month.
        /// TestTypeID: 1=Vision, 2=Theory, 3=Road.
        /// Returns -1 if there are no tests recorded (avoids division by zero).
        /// </summary>
        public static int GetPassRateByTestType(int InstituteID, int TestTypeID)
        {
            string query = @"
                SELECT
                    Total   = COUNT(T.TestID),
                    Passed  = SUM(CASE WHEN T.TestResult = 1 THEN 1 ELSE 0 END)
                FROM   Tests T
                INNER JOIN TestAppointments TA
                       ON T.TestAppointmentID = TA.TestAppointmentID
                INNER JOIN LocalDrivingLicenseApplications LDLA
                       ON TA.LocalDrivingLicenseApplicationID = LDLA.LocalDrivingLicenseApplicationID
                WHERE  LDLA.InstituteID  = @InstituteID
                  AND  TA.TestTypeID     = @TestTypeID
                  AND  MONTH(TA.AppointmentDate) = MONTH(GETDATE())
                  AND  YEAR(TA.AppointmentDate)  = YEAR(GETDATE())";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@InstituteID", InstituteID);
                command.Parameters.AddWithValue("@TestTypeID",  TestTypeID);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int total  = Convert.ToInt32(reader["Total"]);
                            int passed = Convert.ToInt32(reader["Passed"]);
                            if (total == 0) return -1;
                            return (int)Math.Round((double)passed / total * 100);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error calculating pass rate: " + ex.Message);
                }
            }
            return -1;
        }
    }
}
