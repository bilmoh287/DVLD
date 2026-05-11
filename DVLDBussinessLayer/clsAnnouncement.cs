using System;
using System.Data;
using DVLDDataAccessLayer;
using DVLDDataAccessLayer.DTOs;

namespace DVLDBussinessLayer
{
    public class clsAnnouncement
    {
        public static bool CreateAnnouncement(int InstituteID, int? BatchID, string Title, string Content, int CreatedByUserID)
        {
            AnnouncementDTO dto = new AnnouncementDTO(
                -1,
                InstituteID,
                BatchID,
                Title,
                Content,
                DateTime.Now,
                CreatedByUserID
            );

            return clsAnnouncementData.AddNewAnnouncement(dto) != -1;
        }

        public static DataTable GetInstituteAnnouncements(int InstituteID)
        {
            return clsAnnouncementData.GetAnnouncementsByInstitute(InstituteID);
        }

        public static DataTable GetBatchAnnouncements(int BatchID)
        {
            return clsAnnouncementData.GetAnnouncementsForBatch(BatchID);
        }
    }
}
