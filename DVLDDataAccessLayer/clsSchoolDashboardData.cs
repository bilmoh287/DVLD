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
                SELECT COUNT(*) FROM InstituteInstructors
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
                            int total  = reader["Total"] != DBNull.Value ? Convert.ToInt32(reader["Total"]) : 0;
                            int passed = reader["Passed"] != DBNull.Value ? Convert.ToInt32(reader["Passed"]) : 0;
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
        /// <summary>
        /// Returns the total revenue for the institute based on PaidFees from Applications.
        /// Linked through Enrollments -> LocalDrivingLicenseApplications -> Applications.
        /// </summary>
        public static decimal GetTotalEarnings(int InstituteID)
        {
            decimal total = 0;
            // Sum both official DVLD application fees AND school-specific course payments
            string query = @"
                SELECT 
                    (SELECT ISNULL(SUM(A.PaidFees), 0)
                     FROM   Applications A
                     INNER JOIN LocalDrivingLicenseApplications LDLA ON A.ApplicationID = LDLA.ApplicationID
                     WHERE  LDLA.InstituteID = @InstituteID)
                +
                    (SELECT ISNULL(SUM(IP.AmountPaid), 0)
                     FROM   InstitutePayments IP
                     WHERE  IP.InstituteID = @InstituteID)";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@InstituteID", InstituteID);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        total = Convert.ToDecimal(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error calculating earnings: " + ex.Message);
                }
            }
            return total;
        }

        /// <summary>
        /// Returns enrollment counts for the last 3 calendar months.
        /// Key = Month Name (e.g. "Jan"), Value = Count.
        /// </summary>
        public static DataTable GetMonthlyEnrollmentStats(int InstituteID)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MonthName", typeof(string));
            dt.Columns.Add("Count",     typeof(int));

            // Query for the last 3 months (including current)
            string query = @"
                SELECT
                    MonthName = FORMAT(EnrollmentDate, 'MMM'),
                    MonthNum  = MONTH(EnrollmentDate),
                    YearNum   = YEAR(EnrollmentDate),
                    Cnt       = COUNT(*)
                FROM Enrollments
                WHERE InstituteID = @InstituteID
                  AND EnrollmentDate >= DATEADD(MONTH, -2, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1))
                GROUP BY FORMAT(EnrollmentDate, 'MMM'), MONTH(EnrollmentDate), YEAR(EnrollmentDate)
                ORDER BY YearNum, MonthNum";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@InstituteID", InstituteID);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dt.Rows.Add(reader["MonthName"], reader["Cnt"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading enrollment stats: " + ex.Message);
                }
            }
            return dt;
        }

        /// <summary>
        /// Returns the number of batches currently active at this institute.
        /// </summary>
        public static int GetActiveBatchesCount(int InstituteID)
        {
            int count = 0;
            string query = @"
                SELECT COUNT(*) FROM TrainingBatches
                WHERE InstituteID = @InstituteID AND EndDate >= CAST(GETDATE() AS DATE)";

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
                    Console.WriteLine("Error counting active batches: " + ex.Message);
                }
            }
            return count;
        }

        /// <summary>
        /// Returns the number of students who are approved but not yet in a training batch.
        /// </summary>
        public static int GetWaitingListCount(int InstituteID)
        {
            int count = 0;
            string query = @"
                SELECT COUNT(DISTINCT L.LocalDrivingLicenseApplicationID)
                FROM LocalDrivingLicenseApplications L
                INNER JOIN Applications A ON L.ApplicationID = A.ApplicationID
                WHERE L.InstituteID = @InstituteID 
                  AND A.ApplicationStatus = 3
                  AND L.ApplicationID NOT IN (SELECT ApplicationID FROM ApplicantBatch)";

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
                    Console.WriteLine("Error counting waiting list: " + ex.Message);
                }
            }
            return count;
        }

        /// <summary>
        /// Returns the percentage of students marked present today across all batches.
        /// </summary>
        public static int GetTodayAttendanceRate(int InstituteID)
        {
            string query = @"
                SELECT 
                    Total = COUNT(*),
                    Present = SUM(CASE WHEN A.IsPresent = 1 AND (A.IsLate = 0 OR A.IsLate IS NULL) THEN 1 ELSE 0 END),
                    Late = SUM(CASE WHEN A.IsPresent = 1 AND A.IsLate = 1 THEN 1 ELSE 0 END)
                FROM Attendance A
                INNER JOIN TrainingBatches TB ON A.TrainingBatchID = TB.TrainingBatchID
                WHERE TB.InstituteID = @InstituteID 
                  AND CAST(A.AttendanceDate AS DATE) = CAST(GETDATE() AS DATE)";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@InstituteID", InstituteID);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read() && reader["Total"] != DBNull.Value)
                        {
                            int total = Convert.ToInt32(reader["Total"]);
                            int present = reader["Present"] != DBNull.Value ? Convert.ToInt32(reader["Present"]) : 0;
                            if (total == 0) return 0;
                            return (int)Math.Round((double)present / total * 100);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error calculating attendance rate: " + ex.Message);
                }
            }
            return 0;
        }
    }
}
