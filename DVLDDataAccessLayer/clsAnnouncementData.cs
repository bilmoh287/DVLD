using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DVLDDataAccessLayer.DTOs;

namespace DVLDDataAccessLayer
{
    public class clsAnnouncementData
    {
        public static int AddNewAnnouncement(AnnouncementDTO announcement)
        {
            int AnnouncementID = -1;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"INSERT INTO InstituteAnnouncements (InstituteID, BatchID, Title, Content, DateCreated, CreatedByUserID)
                                 VALUES (@InstituteID, @BatchID, @Title, @Content, @DateCreated, @CreatedByUserID);
                                 SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@InstituteID", announcement.InstituteID);
                command.Parameters.AddWithValue("@BatchID", (object)announcement.BatchID ?? DBNull.Value);
                command.Parameters.AddWithValue("@Title", announcement.Title);
                command.Parameters.AddWithValue("@Content", announcement.Content);
                command.Parameters.AddWithValue("@DateCreated", announcement.DateCreated);
                command.Parameters.AddWithValue("@CreatedByUserID", announcement.CreatedByUserID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {
                        AnnouncementID = insertedID;
                    }
                }
                catch { }
            }
            return AnnouncementID;
        }

        public static DataTable GetAnnouncementsByInstitute(int InstituteID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = "SELECT * FROM InstituteAnnouncements WHERE InstituteID = @InstituteID ORDER BY DateCreated DESC";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@InstituteID", InstituteID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                }
                catch { }
            }
            return dt;
        }

        public static DataTable GetAnnouncementsForBatch(int BatchID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT * FROM InstituteAnnouncements 
                                 WHERE (BatchID = @BatchID OR BatchID IS NULL) 
                                 AND InstituteID = (SELECT InstituteID FROM TrainingBatches WHERE TrainingBatchID = @BatchID)
                                 ORDER BY DateCreated DESC";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BatchID", BatchID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                }
                catch { }
            }
            return dt;
        }
    }
}
