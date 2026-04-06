using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccessLayer
{
    public class clsInstituteCourseData
    {
        public static bool GetCourseInfoByID(int CourseID, ref int InstituteID,
            ref string CourseName, ref int DurationInDays, ref decimal CourseFee)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    string query = "SELECT * FROM InstituteCourses WHERE CourseID = @CourseID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CourseID", CourseID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        isFound = true;
                        InstituteID = (int)reader["InstituteID"];
                        CourseName = (string)reader["CourseName"];
                        DurationInDays = (int)reader["DurationInDays"];
                        CourseFee = (decimal)reader["CourseFee"];
                    }
                    reader.Close();
                }
            }
            catch (Exception) { isFound = false; }
            return isFound;
        }

        public static int AddNewCourse(int InstituteID, string CourseName, int DurationInDays, decimal CourseFee)
        {
            int CourseID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    string query = @"INSERT INTO InstituteCourses (InstituteID, CourseName, DurationInDays, CourseFee)
                                     VALUES (@InstituteID, @CourseName, @DurationInDays, @CourseFee);
                                     SELECT SCOPE_IDENTITY();";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@InstituteID", InstituteID);
                    command.Parameters.AddWithValue("@CourseName", CourseName);
                    command.Parameters.AddWithValue("@DurationInDays", DurationInDays);
                    command.Parameters.AddWithValue("@CourseFee", CourseFee);

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        CourseID = insertedID;
                    }
                }
            }
            catch (Exception) { }
            return CourseID;
        }

        public static bool UpdateCourse(int CourseID, int InstituteID, string CourseName, int DurationInDays, decimal CourseFee)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    string query = @"UPDATE InstituteCourses 
                                     SET InstituteID = @InstituteID, CourseName = @CourseName, 
                                         DurationInDays = @DurationInDays, CourseFee = @CourseFee 
                                     WHERE CourseID = @CourseID";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CourseID", CourseID);
                    command.Parameters.AddWithValue("@InstituteID", InstituteID);
                    command.Parameters.AddWithValue("@CourseName", CourseName);
                    command.Parameters.AddWithValue("@DurationInDays", DurationInDays);
                    command.Parameters.AddWithValue("@CourseFee", CourseFee);

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception) { return false; }
            return (rowsAffected > 0);
        }

        public static DataTable GetAllCoursesByInstituteID(int InstituteID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    // Calling the Stored Procedure
                    SqlCommand command = new SqlCommand("SP_GetInstituteCoursesByInstituteID", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@InstituteID", InstituteID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                        dt.Load(reader);

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                // Log error if needed
            }
            return dt;
        }

        public static bool GetCourseInfoByCourseAndInstituteID(int CourseID, int InstituteID,
            ref string CourseName, ref int DurationInDays, ref decimal CourseFee)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    // We check both IDs to ensure the course belongs to this specific institute
                    string query = "SELECT * FROM InstituteCourses WHERE CourseID = @CourseID AND InstituteID = @InstituteID";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CourseID", CourseID);
                    command.Parameters.AddWithValue("@InstituteID", InstituteID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        isFound = true;
                        CourseName = (string)reader["CourseName"];
                        DurationInDays = (int)reader["DurationInDays"];
                        CourseFee = (decimal)reader["CourseFee"];
                    }
                    reader.Close();
                }
            }
            catch (Exception) { isFound = false; }

            return isFound;
        }

        public static bool DeleteCourse(int CourseID, int InstituteID)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
                {
                    // Using both IDs ensures we only delete the course if it belongs to this specific institute
                    string query = "DELETE FROM InstituteCourses WHERE CourseID = @CourseID AND InstituteID = @InstituteID";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CourseID", CourseID);
                    command.Parameters.AddWithValue("@InstituteID", InstituteID);

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                // Logic check: This will catch foreign key violations if the course is already linked to Attendance
                return false;
            }
            return (rowsAffected > 0);
        }
    }
}
