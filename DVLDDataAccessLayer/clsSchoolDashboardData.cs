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

    }
}
