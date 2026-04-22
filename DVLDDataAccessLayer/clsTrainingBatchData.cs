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
                string query = "SELECT * FROM TrainingBatches";
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
                string query = @"SELECT A.ApplicationID, P.FirstName, P.LastName, AB.AssignedDate
                                 FROM ApplicantBatch AB
                                 INNER JOIN Applications A ON AB.ApplicationID = A.ApplicationID
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
    }
}
