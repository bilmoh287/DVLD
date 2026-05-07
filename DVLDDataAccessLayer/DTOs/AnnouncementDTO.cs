using System;

namespace DVLDDataAccessLayer.DTOs
{
    public class AnnouncementDTO
    {
        public int AnnouncementID { get; set; }
        public int InstituteID { get; set; }
        public int? BatchID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public int CreatedByUserID { get; set; }

        public AnnouncementDTO() { }

        public AnnouncementDTO(int id, int instituteID, int? batchID, string title, string content, DateTime dateCreated, int createdByUserID)
        {
            this.AnnouncementID = id;
            this.InstituteID = instituteID;
            this.BatchID = batchID;
            this.Title = title;
            this.Content = content;
            this.DateCreated = dateCreated;
            this.CreatedByUserID = createdByUserID;
        }
    }
}
