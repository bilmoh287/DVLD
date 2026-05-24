using System;
using System.Data;
using System.Data.SqlClient;
using DVLDDataAccessLayer.DTOs;

namespace DVLDDataAccessLayer
{
    public class clsTrainingBatchData
    {
        public static TrainingBatchDTO GetBatchByID(int BatchID)
        {
            TrainingBatchDTO BatchDTO = null;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = "SELECT * FROM TrainingBatches WHERE TrainingBatchID = @BatchID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BatchID", BatchID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        BatchDTO = new TrainingBatchDTO(
                            (int)reader["TrainingBatchID"],
                            (int)reader["InstituteID"],
                            (string)reader["BatchName"],
                            (DateTime)reader["StartDate"],
                            (DateTime)reader["EndDate"],
                            (int)reader["MaxCapacity"]
                        );
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return BatchDTO;
        }

        public static int AddNewBatch(TrainingBatchDTO batchDTO)
        {
            int BatchID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"INSERT INTO TrainingBatches (InstituteID, BatchName, StartDate, EndDate, MaxCapacity)
                                 VALUES (@InstituteID, @BatchName, @StartDate, @EndDate, @MaxCapacity);
                                 SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@InstituteID", batchDTO.InstituteID);
                command.Parameters.AddWithValue("@BatchName", batchDTO.BatchName);
                command.Parameters.AddWithValue("@StartDate", batchDTO.StartDate);
                command.Parameters.AddWithValue("@EndDate", batchDTO.EndDate);
                command.Parameters.AddWithValue("@MaxCapacity", batchDTO.MaxCapacity);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        BatchID = insertedID;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return BatchID;
        }

        public static bool UpdateBatch(TrainingBatchDTO batchDTO)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"UPDATE TrainingBatches
                                 SET InstituteID = @InstituteID,
                                     BatchName = @BatchName,
                                     StartDate = @StartDate,
                                     EndDate = @EndDate,
                                     MaxCapacity = @MaxCapacity
                                 WHERE TrainingBatchID = @BatchID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BatchID", batchDTO.BatchID);
                command.Parameters.AddWithValue("@InstituteID", batchDTO.InstituteID);
                command.Parameters.AddWithValue("@BatchName", batchDTO.BatchName);
                command.Parameters.AddWithValue("@StartDate", batchDTO.StartDate);
                command.Parameters.AddWithValue("@EndDate", batchDTO.EndDate);
                command.Parameters.AddWithValue("@MaxCapacity", batchDTO.MaxCapacity);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return (rowsAffected > 0);
        }

        public static DataTable GetAllBatches()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT 
                                    B.TrainingBatchID, 
                                    I.InstituteName, 
                                    B.BatchName, 
                                    B.StartDate, 
                                    B.EndDate, 
                                    B.MaxCapacity,
                                    (SELECT COUNT(*) FROM ApplicantBatch AB WHERE AB.TrainingBatchID = B.TrainingBatchID) as CurrentStudents
                                 FROM TrainingBatches B
                                 INNER JOIN DrivingInstitutes I ON B.InstituteID = I.InstituteID";
                
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return dt;
        }

        public static DataTable GetBatchesByInstituteID(int InstituteID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT 
                                    B.TrainingBatchID, 
                                    B.BatchName, 
                                    B.StartDate, 
                                    B.EndDate, 
                                    B.MaxCapacity,
                                    (SELECT COUNT(*) FROM ApplicantBatch AB WHERE AB.TrainingBatchID = B.TrainingBatchID) as CurrentStudents
                                 FROM TrainingBatches B
                                 WHERE B.InstituteID = @InstituteID";
                
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@InstituteID", InstituteID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return dt;
        }

        public static bool AssignApplicantToBatch(int ApplicationID, int BatchID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"INSERT INTO ApplicantBatch (ApplicationID, TrainingBatchID, AssignedDate)
                                 VALUES (@ApplicationID, @BatchID, GETDATE())";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                command.Parameters.AddWithValue("@BatchID", BatchID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return (rowsAffected > 0);
        }

        public static DataTable GetApplicantsByBatch(int BatchID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT AB.ApplicationID, 
                                 P.PersonID,
                                 P.FirstName + ' ' + P.LastName AS FullName, 
                                 C.ClassName, P.Phone, AB.AssignedDate
                                 FROM ApplicantBatch AB
                                 INNER JOIN Applications A ON AB.ApplicationID = A.ApplicationID
                                 INNER JOIN LocalDrivingLicenseApplications L ON A.ApplicationID = L.ApplicationID
                                 INNER JOIN LicenseClasses C ON L.LicenseClassID = C.LicenseClassID
                                 INNER JOIN People P ON A.ApplicantPersonID = P.PersonID
                                 WHERE AB.TrainingBatchID = @BatchID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BatchID", BatchID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return dt;
        }

        /// <summary>
        /// Returns students in a batch who have been explicitly marked eligible for tests
        /// by the school (IsEligibleForTest = 1). These are the students cleared to schedule
        /// a Vision/Theory/Street test at the DVLD office.
        /// </summary>
        public static DataTable GetEligibleApplicantsForBatch(int InstituteID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                // Returns students who:
                // 1. Are in a batch at this institute
                // 2. Have been marked IsEligibleForTest = 1 by the school
                // 3. Have NOT yet passed all 3 tests (to prevent double-listing graduates)
                string query = @"SELECT DISTINCT
                                     AB.ApplicationID,
                                     P.PersonID,
                                     P.FirstName + ' ' + P.LastName AS FullName,
                                     C.ClassName,
                                     E.EnrollmentDate,
                                     P.Phone
                                 FROM ApplicantBatch AB
                                 INNER JOIN Applications A ON AB.ApplicationID = A.ApplicationID
                                 INNER JOIN LocalDrivingLicenseApplications L ON A.ApplicationID = L.ApplicationID
                                 INNER JOIN LicenseClasses C ON L.LicenseClassID = C.LicenseClassID
                                 INNER JOIN People P ON A.ApplicantPersonID = P.PersonID
                                 INNER JOIN Enrollments E ON A.ApplicantPersonID = E.PersonID AND E.InstituteID = @InstituteID
                                 INNER JOIN TrainingBatches TB ON AB.TrainingBatchID = TB.TrainingBatchID
                                 WHERE TB.InstituteID = @InstituteID
                                   AND AB.IsEligibleForTest = 1";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@InstituteID", InstituteID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return dt;
        }

        /// <summary>
        /// Returns all students in a batch with their eligibility status and attendance stats.
        /// Used by the school web portal to review and mark students as eligible for testing.
        /// </summary>
        public static DataTable GetBatchStudentsForEligibilityReview(int BatchID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT
                                     AB.ApplicantBatchID,
                                     AB.ApplicationID,
                                     P.PersonID,
                                     P.FirstName + ' ' + P.LastName AS FullName,
                                     P.Phone,
                                     C.ClassName,
                                     AB.IsEligibleForTest,
                                     AB.AssignedDate,
                                     TotalSessions  = COUNT(ATT.AttendanceID),
                                     PresentCount   = SUM(CAST(ISNULL(ATT.IsPresent, 0) AS INT))
                                 FROM ApplicantBatch AB
                                 INNER JOIN Applications A ON AB.ApplicationID = A.ApplicationID
                                 INNER JOIN LocalDrivingLicenseApplications L ON A.ApplicationID = L.ApplicationID
                                 INNER JOIN LicenseClasses C ON L.LicenseClassID = C.LicenseClassID
                                 INNER JOIN People P ON A.ApplicantPersonID = P.PersonID
                                 LEFT JOIN Attendance ATT ON AB.ApplicationID = ATT.ApplicationID
                                                         AND AB.TrainingBatchID = ATT.TrainingBatchID
                                 WHERE AB.TrainingBatchID = @BatchID
                                 GROUP BY AB.ApplicantBatchID, AB.ApplicationID, P.PersonID,
                                          P.FirstName, P.LastName, P.Phone, C.ClassName,
                                          AB.IsEligibleForTest, AB.AssignedDate";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BatchID", BatchID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return dt;
        }

        /// <summary>
        /// Sets IsEligibleForTest = 1 or 0 for a specific student in a specific batch.
        /// Called by the school web portal when the instructor confirms the student
        /// has met the attendance/training requirements.
        /// </summary>
        public static bool SetStudentEligibility(int ApplicationID, int BatchID, bool isEligible)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"UPDATE ApplicantBatch
                                 SET IsEligibleForTest = @IsEligible
                                 WHERE ApplicationID = @ApplicationID
                                   AND TrainingBatchID = @BatchID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                command.Parameters.AddWithValue("@BatchID", BatchID);
                command.Parameters.AddWithValue("@IsEligible", isEligible ? 1 : 0);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return (rowsAffected > 0);
        }

        public static bool RemoveApplicantFromBatch(int ApplicationID, int BatchID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"DELETE FROM ApplicantBatch 
                                 WHERE ApplicationID = @ApplicationID 
                                 AND TrainingBatchID = @BatchID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                command.Parameters.AddWithValue("@BatchID", BatchID);

                try
                {
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return (rowsAffected > 0);
        }
        public static DataTable GetBatchByPersonID(int PersonID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT B.* FROM TrainingBatches B
                                 INNER JOIN ApplicantBatch AB ON B.TrainingBatchID = AB.TrainingBatchID
                                 INNER JOIN Applications A ON AB.ApplicationID = A.ApplicationID
                                 WHERE A.ApplicantPersonID = @PersonID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return dt;
        }
    }
}
