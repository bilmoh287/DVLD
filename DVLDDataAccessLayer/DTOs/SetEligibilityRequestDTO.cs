namespace DVLDDataAccessLayer.DTOs
{
    /// <summary>
    /// Request body for PUT api/DrivingInstitutes/batches/{batchId}/eligibility/{applicationId}.
    /// The school instructor sends this to mark a student as eligible or ineligible for DVLD tests.
    /// </summary>
    public class SetEligibilityRequestDTO
    {
        /// <summary>
        /// True = student has met attendance/training requirements and can be scheduled for tests.
        /// False = student is revoked from the eligible list (e.g., dropped out or absent too often).
        /// </summary>
        public bool IsEligible { get; set; }
    }
}
