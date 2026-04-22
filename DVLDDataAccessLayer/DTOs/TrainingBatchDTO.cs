using System;

namespace DVLDDataAccessLayer.DTOs
{
    public class TrainingBatchDTO
    {
        public int BatchID { get; set; }
        public int InstituteID { get; set; }
        public string BatchName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxCapacity { get; set; }

        public TrainingBatchDTO(int batchID, int instituteID, string batchName, DateTime startDate, DateTime endDate, int maxCapacity)
        {
            this.BatchID = batchID;
            this.InstituteID = instituteID;
            this.BatchName = batchName;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.MaxCapacity = maxCapacity;
        }
    }
}
