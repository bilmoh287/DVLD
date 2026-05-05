using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DVLDDataAccessLayer
{
    public class clsUserMessageData
    {
        public static int AddNewMessage(int PersonID, int? SenderID, string Title, string Content, string MessageType)
        {
            int MessageID = -1;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"INSERT INTO UserMessages (PersonID, SenderID, Title, Content, MessageType)
                                 VALUES (@PersonID, @SenderID, @Title, @Content, @MessageType);
                                 SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@SenderID", (object)SenderID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@Content", Content);
                    command.Parameters.AddWithValue("@MessageType", MessageType);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {
                            MessageID = insertedID;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("DB Error in AddNewMessage: " + ex.Message);
                    }
                }
            }
            return MessageID;
        }

        public static DataTable GetMessagesByPersonID(int PersonID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = "SELECT * FROM UserMessages WHERE PersonID = @PersonID ORDER BY CreatedAt DESC";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            return dt;
        }

        public static bool MarkAsRead(int MessageID)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = "UPDATE UserMessages SET IsRead = 1 WHERE MessageID = @MessageID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MessageID", MessageID);
                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex) { }
                }
            }
            return rowsAffected > 0;
        }

        public static int GetUnreadCount(int PersonID)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM UserMessages WHERE PersonID = @PersonID AND IsRead = 0";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    try
                    {
                        connection.Open();
                        count = (int)command.ExecuteScalar();
                    }
                    catch (Exception ex) { }
                }
            }
            return count;
        }
    }
}
