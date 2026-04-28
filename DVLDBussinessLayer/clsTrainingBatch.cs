using System;
using System.Data;
using DVLDDataAccessLayer;
using DVLDDataAccessLayer.DTOs;

namespace DVLDBussinessLayer
{
    public class clsTrainingBatch
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int BatchID { get; set; }
        public int InstituteID { get; set; }
        public string BatchName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxCapacity { get; set; }

        public TrainingBatchDTO BatchDTO
        {
            get
            {
                return new TrainingBatchDTO(this.BatchID, this.InstituteID, this.BatchName, this.StartDate, this.EndDate, this.MaxCapacity);
            }
        }

        public clsTrainingBatch()
        {
            this.BatchID = -1;
            this.InstituteID = -1;
            this.BatchName = "";
            this.StartDate = DateTime.Now;
            this.EndDate = DateTime.Now;
            this.MaxCapacity = 0;
            this.Mode = enMode.AddNew;
        }

        public clsTrainingBatch(TrainingBatchDTO batchDTO, enMode cMode = enMode.Update)
        {
            this.BatchID = batchDTO.BatchID;
            this.InstituteID = batchDTO.InstituteID;
            this.BatchName = batchDTO.BatchName;
            this.StartDate = batchDTO.StartDate;
            this.EndDate = batchDTO.EndDate;
            this.MaxCapacity = batchDTO.MaxCapacity;
            this.Mode = cMode;
        }

        public static clsTrainingBatch Find(int BatchID)
        {
            TrainingBatchDTO batchDTO = clsTrainingBatchData.GetBatchByID(BatchID);

            if (batchDTO != null)
            {
                return new clsTrainingBatch(batchDTO, enMode.Update);
            }
            return null;
        }

        private bool _AddNewBatch()
        {
            this.BatchID = clsTrainingBatchData.AddNewBatch(this.BatchDTO);
            return (this.BatchID != -1);
        }

        private bool _UpdateBatch()
        {
            return clsTrainingBatchData.UpdateBatch(this.BatchDTO);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBatch())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _UpdateBatch();
            }
            return false;
        }

        public static DataTable GetAllBatches()
        {
            return clsTrainingBatchData.GetAllBatches();
        }

        public static DataTable GetBatchesByInstituteID(int InstituteID)
        {
            return clsTrainingBatchData.GetBatchesByInstituteID(InstituteID);
        }

        public bool AssignApplicant(int ApplicationID)
        {
            // 1. Check Capacity
            DataTable dtApplicants = GetApplicants();
            if (dtApplicants.Rows.Count >= this.MaxCapacity)
            {
                return false; // Batch is full
            }

            return clsTrainingBatchData.AssignApplicantToBatch(ApplicationID, this.BatchID);
        }

        public DataTable GetApplicants()
        {
            return clsTrainingBatchData.GetApplicantsByBatch(this.BatchID);
        }

        public static DataTable GetEligibleStudents(int InstituteID)
        {
            return clsTrainingBatchData.GetEligibleApplicantsForBatch(InstituteID);
        }

        public static bool RemoveApplicant(int ApplicationID, int BatchID)
        {
            return clsTrainingBatchData.RemoveApplicantFromBatch(ApplicationID, BatchID);
        }
    }
}
