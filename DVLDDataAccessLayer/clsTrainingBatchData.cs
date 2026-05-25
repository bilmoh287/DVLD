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
        /// Returns students who are enrolled at this institute and are waiting to be assigned to a batch.
        /// </summary>
        public static DataTable GetEligibleApplicantsForBatch(int InstituteID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                // Returns students who:
                // 1. Are enrolled at this institute (active enrollment)
                // 2. Have applications that are Approved
                // 3. Are not yet assigned to any batch
                string query = @"SELECT DISTINCT
                                     A.ApplicationID,
                                     P.PersonID,
                                     P.FirstName + ' ' + P.LastName AS FullName,
                                     C.ClassName,
                                     E.EnrollmentDate,
                                     P.Phone
                                 FROM Applications A
                                 INNER JOIN LocalDrivingLicenseApplications L ON A.ApplicationID = L.ApplicationID
                                 INNER JOIN LicenseClasses C ON L.LicenseClassID = C.LicenseClassID
                                 INNER JOIN People P ON A.ApplicantPersonID = P.PersonID
                                 INNER JOIN Enrollments E ON A.ApplicantPersonID = E.PersonID AND E.InstituteID = @InstituteID
                                 WHERE E.InstituteID = @InstituteID
                                   AND A.ApplicationStatus IN (4) --  Approved
                                   AND A.ApplicationID NOT IN (SELECT ApplicationID FROM ApplicantBatch)";

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
        /// Returns students who are in a batch at this institute and have been marked eligible for tests (IsEligibleForTest = 1).
        /// </summary>
        public static DataTable GetEligibleApplicantsForTestSchedule(int InstituteID)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
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
                string query = @"WITH TestStatusCTE AS (
                                     SELECT 
                                         L.LocalDrivingLicenseApplicationID,
                                         PassedVision = CASE WHEN EXISTS (
                                             SELECT 1 FROM Tests T 
                                             INNER JOIN TestAppointments TA ON T.TestAppointmentID = TA.TestAppointmentID 
                                             WHERE TA.LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID AND TA.TestTypeID = 1 AND T.TestResult = 1
                                         ) THEN 1 ELSE 0 END,
                                         PassedWritten = CASE WHEN EXISTS (
                                             SELECT 1 FROM Tests T 
                                             INNER JOIN TestAppointments TA ON T.TestAppointmentID = TA.TestAppointmentID 
                                             WHERE TA.LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID AND TA.TestTypeID = 2 AND T.TestResult = 1
                                         ) THEN 1 ELSE 0 END,
                                         PassedStreet = CASE WHEN EXISTS (
                                             SELECT 1 FROM Tests T 
                                             INNER JOIN TestAppointments TA ON T.TestAppointmentID = TA.TestAppointmentID 
                                             WHERE TA.LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID AND TA.TestTypeID = 3 AND T.TestResult = 1
                                         ) THEN 1 ELSE 0 END,
                                         
                                         PendingVision = CASE WHEN EXISTS (
                                             SELECT 1 FROM TestAppointments 
                                             WHERE LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID AND TestTypeID = 1 AND IsLocked = 0
                                         ) THEN 1 ELSE 0 END,
                                         PendingWritten = CASE WHEN EXISTS (
                                             SELECT 1 FROM TestAppointments 
                                             WHERE LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID AND TestTypeID = 2 AND IsLocked = 0
                                         ) THEN 1 ELSE 0 END,
                                         PendingStreet = CASE WHEN EXISTS (
                                             SELECT 1 FROM TestAppointments 
                                             WHERE LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID AND TestTypeID = 3 AND IsLocked = 0
                                         ) THEN 1 ELSE 0 END,

                                         FailedVision = CASE WHEN EXISTS (
                                             SELECT 1 FROM Tests T 
                                             INNER JOIN TestAppointments TA ON T.TestAppointmentID = TA.TestAppointmentID 
                                             WHERE TA.LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID AND TA.TestTypeID = 1
                                             AND T.TestID = (
                                                 SELECT TOP 1 T2.TestID 
                                                 FROM Tests T2 
                                                 INNER JOIN TestAppointments TA2 ON T2.TestAppointmentID = TA2.TestAppointmentID 
                                                 WHERE TA2.LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID AND TA2.TestTypeID = 1
                                                 ORDER BY TA2.AppointmentDate DESC, T2.TestID DESC
                                             )
                                             AND T.TestResult = 0
                                         ) THEN 1 ELSE 0 END,
                                         FailedWritten = CASE WHEN EXISTS (
                                             SELECT 1 FROM Tests T 
                                             INNER JOIN TestAppointments TA ON T.TestAppointmentID = TA.TestAppointmentID 
                                             WHERE TA.LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID AND TA.TestTypeID = 2
                                             AND T.TestID = (
                                                 SELECT TOP 1 T2.TestID 
                                                 FROM Tests T2 
                                                 INNER JOIN TestAppointments TA2 ON T2.TestAppointmentID = TA2.TestAppointmentID 
                                                 WHERE TA2.LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID AND TA2.TestTypeID = 2
                                                 ORDER BY TA2.AppointmentDate DESC, T2.TestID DESC
                                             )
                                             AND T.TestResult = 0
                                         ) THEN 1 ELSE 0 END,
                                         FailedStreet = CASE WHEN EXISTS (
                                             SELECT 1 FROM Tests T 
                                             INNER JOIN TestAppointments TA ON T.TestAppointmentID = TA.TestAppointmentID 
                                             WHERE TA.LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID AND TA.TestTypeID = 3
                                             AND T.TestID = (
                                                 SELECT TOP 1 T2.TestID 
                                                 FROM Tests T2 
                                                 INNER JOIN TestAppointments TA2 ON T2.TestAppointmentID = TA2.TestAppointmentID 
                                                 WHERE TA2.LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID AND TA2.TestTypeID = 3
                                                 ORDER BY TA2.AppointmentDate DESC, T2.TestID DESC
                                             )
                                             AND T.TestResult = 0
                                         ) THEN 1 ELSE 0 END
                                     FROM LocalDrivingLicenseApplications L
                                 ),
                                 ComputedNextTest AS (
                                     SELECT 
                                         LocalDrivingLicenseApplicationID,
                                         NextTestTypeID = CASE 
                                             WHEN PassedVision = 0 THEN 1 
                                             WHEN PassedWritten = 0 THEN 2 
                                             WHEN PassedStreet = 0 THEN 3 
                                             ELSE 4 
                                         END,
                                         NextTestName = CASE 
                                             WHEN PassedVision = 0 THEN 'Vision Test' 
                                             WHEN PassedWritten = 0 THEN 'Written Test' 
                                             WHEN PassedStreet = 0 THEN 'Street Test' 
                                             ELSE 'Passed All' 
                                         END,
                                         HasPendingTest = CASE 
                                             WHEN PassedVision = 0 THEN PendingVision 
                                             WHEN PassedWritten = 0 THEN PendingWritten 
                                             WHEN PassedStreet = 0 THEN PendingStreet 
                                             ELSE 0 
                                         END,
                                         HasFailedLast = CASE 
                                             WHEN PassedVision = 0 THEN FailedVision 
                                             WHEN PassedWritten = 0 THEN FailedWritten 
                                             WHEN PassedStreet = 0 THEN FailedStreet 
                                             ELSE 0 
                                         END
                                     FROM TestStatusCTE
                                 )
                                 SELECT
                                     AB.ApplicantBatchID,
                                     AB.ApplicationID,
                                     P.PersonID,
                                     P.FirstName + ' ' + P.LastName AS FullName,
                                     P.Phone,
                                     C.ClassName,
                                     AB.IsEligibleForTest,
                                     AB.AssignedDate,
                                     TotalSessions  = COUNT(ATT.AttendanceID),
                                     PresentCount   = SUM(CAST(ISNULL(ATT.IsPresent, 0) AS INT)),
                                     NT.NextTestTypeID,
                                     NT.NextTestName,
                                     NT.HasPendingTest,
                                     NT.HasFailedLast
                                 FROM ApplicantBatch AB
                                 INNER JOIN Applications A ON AB.ApplicationID = A.ApplicationID
                                 INNER JOIN LocalDrivingLicenseApplications L ON A.ApplicationID = L.ApplicationID
                                 INNER JOIN LicenseClasses C ON L.LicenseClassID = C.LicenseClassID
                                 INNER JOIN People P ON A.ApplicantPersonID = P.PersonID
                                 LEFT JOIN Attendance ATT ON AB.ApplicationID = ATT.ApplicationID
                                                         AND AB.TrainingBatchID = ATT.TrainingBatchID
                                 LEFT JOIN ComputedNextTest NT ON L.LocalDrivingLicenseApplicationID = NT.LocalDrivingLicenseApplicationID
                                 WHERE AB.TrainingBatchID = @BatchID
                                 GROUP BY AB.ApplicantBatchID, AB.ApplicationID, P.PersonID,
                                          P.FirstName, P.LastName, P.Phone, C.ClassName,
                                          AB.IsEligibleForTest, AB.AssignedDate,
                                          NT.NextTestTypeID, NT.NextTestName, NT.HasPendingTest, NT.HasFailedLast";

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

        /// <summary>
        /// Resets IsEligibleForTest = 0 for a student after they have been scheduled for a test.
        /// </summary>
        public static bool ResetStudentEligibility(int ApplicationID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"UPDATE ApplicantBatch
                                 SET IsEligibleForTest = 0
                                 WHERE ApplicationID = @ApplicationID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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

        public static DataTable GetStudentsEligibleForTestScheduling()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"WITH TestStatusCTE AS (
                                     SELECT 
                                         L.LocalDrivingLicenseApplicationID,
                                         PassedVision = CASE WHEN EXISTS (
                                             SELECT 1 FROM Tests T 
                                             INNER JOIN TestAppointments TA ON T.TestAppointmentID = TA.TestAppointmentID 
                                             WHERE TA.LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID AND TA.TestTypeID = 1 AND T.TestResult = 1
                                         ) THEN 1 ELSE 0 END,
                                         PassedWritten = CASE WHEN EXISTS (
                                             SELECT 1 FROM Tests T 
                                             INNER JOIN TestAppointments TA ON T.TestAppointmentID = TA.TestAppointmentID 
                                             WHERE TA.LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID AND TA.TestTypeID = 2 AND T.TestResult = 1
                                         ) THEN 1 ELSE 0 END,
                                         PassedStreet = CASE WHEN EXISTS (
                                             SELECT 1 FROM Tests T 
                                             INNER JOIN TestAppointments TA ON T.TestAppointmentID = TA.TestAppointmentID 
                                             WHERE TA.LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID AND TA.TestTypeID = 3 AND T.TestResult = 1
                                         ) THEN 1 ELSE 0 END
                                     FROM LocalDrivingLicenseApplications L
                                 ),
                                 ComputedNextTest AS (
                                     SELECT 
                                         LocalDrivingLicenseApplicationID,
                                         NextTestTypeID = CASE 
                                             WHEN PassedVision = 0 THEN 1 
                                             WHEN PassedWritten = 0 THEN 2 
                                             WHEN PassedStreet = 0 THEN 3 
                                             ELSE 4 
                                         END,
                                         NextTestName = CASE 
                                             WHEN PassedVision = 0 THEN 'Vision Test' 
                                             WHEN PassedWritten = 0 THEN 'Written Test' 
                                             WHEN PassedStreet = 0 THEN 'Street Test' 
                                             ELSE 'Passed All' 
                                         END
                                     FROM TestStatusCTE
                                 )
                                 SELECT 
                                     AB.ApplicationID, 
                                     L.LocalDrivingLicenseApplicationID,
                                     A.ApplicantPersonID AS PersonID,
                                     P.FirstName + ' ' + P.LastName AS FullName,
                                     C.ClassName,
                                     P.Phone,
                                     I.InstituteName,
                                     L.LicenseClassID,
                                     NT.NextTestTypeID,
                                     NT.NextTestName
                                 FROM ApplicantBatch AB
                                 INNER JOIN Applications A ON AB.ApplicationID = A.ApplicationID
                                 INNER JOIN LocalDrivingLicenseApplications L ON AB.ApplicationID = L.ApplicationID
                                 INNER JOIN LicenseClasses C ON L.LicenseClassID = C.LicenseClassID
                                 INNER JOIN People P ON A.ApplicantPersonID = P.PersonID
                                 INNER JOIN DrivingInstitutes I ON L.InstituteID = I.InstituteID
                                 LEFT JOIN ComputedNextTest NT ON L.LocalDrivingLicenseApplicationID = NT.LocalDrivingLicenseApplicationID
                                 WHERE AB.IsEligibleForTest = 1";

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
    }
}
