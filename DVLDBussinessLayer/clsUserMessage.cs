using System;
using System.Collections.Generic;
using System.Data;
using DVLDDataAccessLayer;
using DVLDDataAccessLayer.DTOs;

namespace DVLDBussinessLayer
{
    public class clsUserMessage
    {
        public int MessageID { get; set; }
        public int PersonID { get; set; }
        public int? SenderID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public string MessageType { get; set; }

        public clsUserMessage()
        {
            this.MessageID = -1;
            this.PersonID = -1;
            this.SenderID = null;
            this.Title = "";
            this.Content = "";
            this.IsRead = false;
            this.CreatedAt = DateTime.Now;
            this.MessageType = "Notification";
        }

        public static bool SendSystemMessage(int PersonID, string Title, string Content, string MessageType = "Notification")
        {
            return clsUserMessageData.AddNewMessage(PersonID, null, Title, Content, MessageType) != -1;
        }

        public static bool SendChatMessage(int PersonID, int SenderID, string Title, string Content, string MessageType = "Chat")
        {
            return clsUserMessageData.AddNewMessage(PersonID, SenderID, Title, Content, MessageType) != -1;
        }

        public static List<UserMessageDTO> GetUserMessages(int PersonID)
        {
            List<UserMessageDTO> messages = new List<UserMessageDTO>();
            DataTable dt = clsUserMessageData.GetMessagesByPersonID(PersonID);

            foreach (DataRow row in dt.Rows)
            {
                messages.Add(new UserMessageDTO(
                    (int)row["MessageID"],
                    (int)row["PersonID"],
                    row["SenderID"] == DBNull.Value ? (int?)null : (int)row["SenderID"],
                    (string)row["Title"],
                    (string)row["Content"],
                    (bool)row["IsRead"],
                    (DateTime)row["CreatedAt"],
                    (string)row["MessageType"]
                ));
            }

            return messages;
        }

        public static bool MarkAsRead(int MessageID)
        {
            return clsUserMessageData.MarkAsRead(MessageID);
        }

        public static int GetUnreadCount(int PersonID)
        {
            return clsUserMessageData.GetUnreadCount(PersonID);
        }
    }
}
