using System;

namespace DVLDDataAccessLayer.DTOs
{
    public class UserMessageDTO
    {
        public int MessageID { get; set; }
        public int PersonID { get; set; }
        public int? SenderID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public string MessageType { get; set; }

        public UserMessageDTO() { }

        public UserMessageDTO(int messageID, int personID, int? senderID, string title, string content, bool isRead, DateTime createdAt, string messageType)
        {
            MessageID = messageID;
            PersonID = personID;
            SenderID = senderID;
            Title = title;
            Content = content;
            IsRead = isRead;
            CreatedAt = createdAt;
            MessageType = messageType;
        }
    }
}
