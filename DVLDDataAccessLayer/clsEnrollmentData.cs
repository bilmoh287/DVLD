using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLDDataAccessLayer
{
    public class clsEnrollmentData
    {
        /// <summary>
        /// Returns all enrolled students for a specific institute, joined with
        /// People and InstituteCourses for full display info.
        /// </summary>
        public static DataTable GetAllEnrollmentsByInstituteID(int InstituteID)
        {
            DataTable dt = new DataTable();

            string query = @"
                SELECT
                    E.EnrollmentID,
                    E.PersonID,
                    FullName = P.FirstName + ' ' + P.SecondName + ' ' +
                               ISNULL(P.ThirdName, '') + ' ' + P.LastName,
                    P.Phone,
                    C.CourseName,
                    E.EnrollmentDate,
                    E.IsActive
                FROM Enrollments E
                INNER JOIN People            P ON E.PersonID  = P.PersonID
                INNER JOIN InstituteCourses  C ON E.CourseID  = C.CourseID
                WHERE E.InstituteID = @InstituteID
                ORDER BY E.EnrollmentDate DESC;";

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
                    Console.WriteLine("Error loading enrollments: " + ex.Message);
                }
            }
            return dt;
        }

        /// <summary>
        /// Returns a single enrollment record by its ID.
        /// </summary>
        public static bool GetEnrollmentInfoByID(int EnrollmentID, ref int PersonID,
            ref int InstituteID, ref int CourseID, ref DateTime EnrollmentDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool isFound = false;

            string query = "SELECT * FROM Enrollments WHERE EnrollmentID = @EnrollmentID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@EnrollmentID", EnrollmentID);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        isFound          = true;
                        PersonID         = (int)reader["PersonID"];
                        InstituteID      = (int)reader["InstituteID"];
                        CourseID         = (int)reader["CourseID"];
                        EnrollmentDate   = (DateTime)reader["EnrollmentDate"];
                        IsActive         = (bool)reader["IsActive"];
                        CreatedByUserID  = (int)reader["CreatedByUserID"];
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading enrollment: " + ex.Message);
                }
            }
            return isFound;
        }

        /// <summary>
        /// Adds a new enrollment record and returns the new EnrollmentID, or -1 on failure.
        /// </summary>
        public static int AddNewEnrollment(int PersonID, int InstituteID, int CourseID, int CreatedByUserID)
        {
            int newID = -1;

            string query = @"
                INSERT INTO Enrollments (PersonID, InstituteID, CourseID, EnrollmentDate, IsActive, CreatedByUserID)
                VALUES (@PersonID, @InstituteID, @CourseID, GETDATE(), 1, @CreatedByUserID);
                SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonID",        PersonID);
                command.Parameters.AddWithValue("@InstituteID",     InstituteID);
                command.Parameters.AddWithValue("@CourseID",        CourseID);
                command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                        newID = Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding enrollment: " + ex.Message);
                }
            }
            return newID;
        }

        /// <summary>
        /// Updates an existing enrollment's active status.
        /// </summary>
        public static bool UpdateEnrollment(int EnrollmentID, bool IsActive)
        {
            int rowsAffected = 0;

            string query = @"
                UPDATE Enrollments
                SET IsActive = @IsActive
                WHERE EnrollmentID = @EnrollmentID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@EnrollmentID", EnrollmentID);
                command.Parameters.AddWithValue("@IsActive",     IsActive);
                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating enrollment: " + ex.Message);
                }
            }
            return (rowsAffected > 0);
        }

        /// <summary>
        /// Deletes an enrollment record.
        /// </summary>
        public static bool DeleteEnrollment(int EnrollmentID)
        {
            int rowsAffected = 0;

            string query = "DELETE FROM Enrollments WHERE EnrollmentID = @EnrollmentID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@EnrollmentID", EnrollmentID);
                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting enrollment: " + ex.Message);
                }
            }
            return (rowsAffected > 0);
        }

        /// <summary>
        /// Returns the total count of active students enrolled at a specific institute.
        /// </summary>
        public static int GetTotalStudentCount(int InstituteID)
        {
            int count = 0;

            string query = @"
                SELECT COUNT(*) FROM Enrollments
                WHERE InstituteID = @InstituteID AND IsActive = 1";

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
                    Console.WriteLine("Error counting students: " + ex.Message);
                }
            }
            return count;
        }

        /// <summary>
        /// Checks if a person is already actively enrolled in a specific course at this institute.
        /// Prevents duplicate enrollments.
        /// </summary>
        public static bool IsPersonAlreadyEnrolled(int PersonID, int InstituteID, int CourseID)
        {
            bool exists = false;

            string query = @"
                SELECT 1 FROM Enrollments
                WHERE PersonID = @PersonID AND InstituteID = @InstituteID
                      AND CourseID = @CourseID AND IsActive = 1";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonID",    PersonID);
                command.Parameters.AddWithValue("@InstituteID", InstituteID);
                command.Parameters.AddWithValue("@CourseID",    CourseID);
                try
                {
                    connection.Open();
                    exists = command.ExecuteScalar() != null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error checking enrollment: " + ex.Message);
                }
            }
            return exists;
        }
        /// <summary>
        /// Checks if a person is already enrolled at a specific institute (any course).
        /// Used to auto-enroll students during in-person application creation.
        /// </summary>
        public static bool IsPersonEnrolledAtInstitute(int PersonID, int InstituteID)
        {
            bool exists = false;

            string query = @"
                SELECT 1 FROM Enrollments
                WHERE PersonID = @PersonID AND InstituteID = @InstituteID AND IsActive = 1";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@InstituteID", InstituteID);
                try
                {
                    connection.Open();
                    exists = command.ExecuteScalar() != null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error checking institute enrollment: " + ex.Message);
                }
            }
            return exists;
        }

        /// <summary>
        /// Gets the default CourseID for an institute (first active course).
        /// Used as a fallback when auto-enrolling during in-person registration.
        /// </summary>
        public static int GetDefaultCourseIDForInstitute(int InstituteID)
        {
            int courseID = -1;

            string query = @"SELECT TOP 1 CourseID FROM InstituteCourses 
                             WHERE InstituteID = @InstituteID ORDER BY CourseID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@InstituteID", InstituteID);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                        courseID = Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error getting default course: " + ex.Message);
                }
            }
            return courseID;
        }
        public static DataTable GetEnrollmentsByPersonID(int PersonID)
        {
            DataTable dt = new DataTable();

            string query = @"
                SELECT
                    E.*,
                    I.InstituteName
                FROM Enrollments E
                INNER JOIN DrivingInstitutes I ON E.InstituteID = I.InstituteID
                WHERE E.PersonID = @PersonID AND E.IsActive = 1;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PersonID", PersonID);
                try
                {
                    connection.Open();
                    dt.Load(command.ExecuteReader());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading person enrollments: " + ex.Message);
                }
            }
            return dt;
        public static decimal GetCourseFee(int CourseID)
        {
            decimal fee = 0;
            string query = "SELECT CourseFee FROM InstituteCourses WHERE CourseID = @CourseID";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CourseID", CourseID);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && decimal.TryParse(result.ToString(), out decimal res))
                    {
                        fee = res;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return fee;
        }
    }
}
