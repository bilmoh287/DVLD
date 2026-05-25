using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
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

        public static DataTable GetEligibleApplicantsForTestSchedule(int InstituteID)
        {
            return clsTrainingBatchData.GetEligibleApplicantsForTestSchedule(InstituteID);
        }

        public static bool RemoveApplicant(int ApplicationID, int BatchID)
        {
            return clsTrainingBatchData.RemoveApplicantFromBatch(ApplicationID, BatchID);
        }

        public static DataTable GetStudentBatch(int PersonID)
        {
            return clsTrainingBatchData.GetBatchByPersonID(PersonID);
        }

        /// <summary>
        /// Returns all students in a batch with their attendance counts and eligibility flag.
        /// Used by the school web portal to let instructors review who is ready to be cleared for tests.
        /// </summary>
        public static DataTable GetBatchStudentsForEligibilityReview(int BatchID)
        {
            return clsTrainingBatchData.GetBatchStudentsForEligibilityReview(BatchID);
        }

        /// <summary>
        /// Marks a specific student as eligible (or not eligible) for tests within a batch.
        /// This is the school instructor's deliberate action that clears the student
        /// to appear in the DVLD officer's scheduling list.
        /// </summary>
        public static bool SetStudentEligibility(int ApplicationID, int BatchID, bool isEligible)
        {
            return clsTrainingBatchData.SetStudentEligibility(ApplicationID, BatchID, isEligible);
        }

        public static bool ResetStudentEligibility(int ApplicationID)
        {
            return clsTrainingBatchData.ResetStudentEligibility(ApplicationID);
        }

        public static DataTable GetStudentsEligibleForTestScheduling()
        {
            return clsTrainingBatchData.GetStudentsEligibleForTestScheduling();
        }

        public static void BatchScheduleTest(int testTypeID, DateTime appointmentDate, int createdByUserID, out int scheduledCount, out int skippedCount)
        {
            scheduledCount = 0;
            skippedCount = 0;

            // 1. Get all students marked as eligible for tests
            DataTable dtEligible = GetStudentsEligibleForTestScheduling();
            if (dtEligible.Rows.Count == 0) return;

            // 2. Pre-fetch active scheduled appointments (IsLocked = 0) to avoid SQL in loop
            HashSet<string> activeAppointments = new HashSet<string>();
            HashSet<string> passedTests = new HashSet<string>();

            // Query active appointments
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = "SELECT LocalDrivingLicenseApplicationID, TestTypeID FROM TestAppointments WHERE IsLocked = 0";
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int appId = reader.GetInt32(0);
                            int typeId = reader.GetInt32(1);
                            activeAppointments.Add(appId + "_" + typeId);
                        }
                    }
                }
                catch (Exception) { }
            }

            // Query passed tests
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString))
            {
                string query = @"SELECT TA.LocalDrivingLicenseApplicationID, TA.TestTypeID 
                                 FROM Tests T 
                                 INNER JOIN TestAppointments TA ON T.TestAppointmentID = TA.TestAppointmentID 
                                 WHERE T.TestResult = 1";
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int appId = reader.GetInt32(0);
                            int typeId = reader.GetInt32(1);
                            passedTests.Add(appId + "_" + typeId);
                        }
                    }
                }
                catch (Exception) { }
            }

            decimal testFees = clsTestTypes.Find((clsTestTypes.enTestType)testTypeID).TestTypeFees;

            // 3. Process loop with high-efficiency dictionary lookup (O(1))
            List<int> appsToSchedule = new List<int>();

            foreach (DataRow row in dtEligible.Rows)
            {
                int appId = (int)row["LocalDrivingLicenseApplicationID"];
                int nextTestTypeID = (row["NextTestTypeID"] != DBNull.Value) ? (int)row["NextTestTypeID"] : 0;

                // Ensure we only schedule the test that the student is actually due for next
                if (nextTestTypeID != testTypeID)
                {
                    skippedCount++;
                    continue;
                }

                // Constraint checks
                bool isEligible = false;

                if (testTypeID == 1) // Vision
                {
                    isEligible = !passedTests.Contains(appId + "_1") && !activeAppointments.Contains(appId + "_1");
                }
                else if (testTypeID == 2) // Written/Theory
                {
                    isEligible = passedTests.Contains(appId + "_1") && // Must pass Vision
                                 !passedTests.Contains(appId + "_2") && 
                                 !activeAppointments.Contains(appId + "_2");
                }
                else if (testTypeID == 3) // Street/Practical
                {
                    isEligible = passedTests.Contains(appId + "_2") && // Must pass Written
                                 !passedTests.Contains(appId + "_3") && 
                                 !activeAppointments.Contains(appId + "_3");
                }

                if (isEligible)
                {
                    appsToSchedule.Add(appId);
                }
                else
                {
                    skippedCount++;
                }
            }

            // 4. Save appointments in batch. We can parallelize this for high performance.
            int localScheduled = 0;

            System.Threading.Tasks.Parallel.ForEach(appsToSchedule, (appId) =>
            {
                clsTestAppointments appointment = new clsTestAppointments();
                appointment.LocalDrivingLicenseApplicationID = appId;
                appointment.TestTypeID = testTypeID;
                appointment.AppointmentDate = appointmentDate;
                appointment.PaidFees = testFees;
                appointment.CreatedByUserID = createdByUserID;
                appointment.IsLocked = false;

                if (appointment.Save())
                {
                    // Find personID to publish event
                    clsLocalDrivingLicenseApplication ldla = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationInfoByID(appId);
                    if (ldla != null)
                    {
                        clsTestSchedulePublisher.Publish(ldla.ApplicantPersonID, testTypeID, appointmentDate, appointment.TestAppointmentID);
                        ResetStudentEligibility(ldla.ApplicationID);
                    }

                    System.Threading.Interlocked.Increment(ref localScheduled);
                }
            });

            scheduledCount = localScheduled;
        }
    }
}
