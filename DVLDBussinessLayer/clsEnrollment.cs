using System;
using System.Data;
using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{
    /// <summary>
    /// Business object representing a student enrolled in a Driving Institute course.
    /// Follows the same AddNew/Update mode pattern as the rest of the DVLD business layer.
    /// </summary>
    public class clsEnrollment
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int      EnrollmentID    { get; set; }
        public int      PersonID        { get; set; }
        public int      InstituteID     { get; set; }
        public int      CourseID        { get; set; }
        public DateTime EnrollmentDate  { get; set; }
        public bool     IsActive        { get; set; }
        public int      CreatedByUserID { get; set; }

        // Default constructor for creating a new enrollment (AddNew mode)
        public clsEnrollment()
        {
            this.EnrollmentID    = -1;
            this.PersonID        = -1;
            this.InstituteID     = -1;
            this.CourseID        = -1;
            this.EnrollmentDate  = DateTime.Now;
            this.IsActive        = true;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        // Private constructor for loading existing data (Update mode)
        private clsEnrollment(int EnrollmentID, int PersonID, int InstituteID, int CourseID,
            DateTime EnrollmentDate, bool IsActive, int CreatedByUserID)
        {
            this.EnrollmentID    = EnrollmentID;
            this.PersonID        = PersonID;
            this.InstituteID     = InstituteID;
            this.CourseID        = CourseID;
            this.EnrollmentDate  = EnrollmentDate;
            this.IsActive        = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        /// <summary>
        /// Finds and loads an Enrollment by its ID. Returns null if not found.
        /// </summary>
        public static clsEnrollment Find(int EnrollmentID)
        {
            int      PersonID        = -1;
            int      InstituteID     = -1;
            int      CourseID        = -1;
            DateTime EnrollmentDate  = DateTime.MinValue;
            bool     IsActive        = false;
            int      CreatedByUserID = -1;

            if (clsEnrollmentData.GetEnrollmentInfoByID(EnrollmentID, ref PersonID, ref InstituteID,
                ref CourseID, ref EnrollmentDate, ref IsActive, ref CreatedByUserID))
            {
                return new clsEnrollment(EnrollmentID, PersonID, InstituteID, CourseID,
                    EnrollmentDate, IsActive, CreatedByUserID);
            }
            return null;
        }

        // Handles inserting a new record
        private bool _AddNew()
        {
            this.EnrollmentID = clsEnrollmentData.AddNewEnrollment(
                this.PersonID, this.InstituteID, this.CourseID, this.CreatedByUserID);

            return (this.EnrollmentID != -1);
        }

        // Handles updating an existing record (IsActive state only)
        private bool _Update()
        {
            return clsEnrollmentData.UpdateEnrollment(this.EnrollmentID, this.IsActive);
        }

        /// <summary>
        /// Saves the enrollment – inserts if AddNew, updates if Update mode.
        /// </summary>
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _Update();

                default:
                    return false;
            }
        }

        /// <summary>
        /// Permanently removes an enrollment record.
        /// </summary>
        public static bool Delete(int EnrollmentID)
        {
            return clsEnrollmentData.DeleteEnrollment(EnrollmentID);
        }

        /// <summary>
        /// Returns all enrollments for a given institute as a DataTable for display in the grid.
        /// Columns returned: EnrollmentID, PersonID, FullName, Phone, CourseName, EnrollmentDate, IsActive
        /// </summary>
        public static DataTable GetAllByInstitute(int InstituteID)
        {
            return clsEnrollmentData.GetAllEnrollmentsByInstituteID(InstituteID);
        }

        /// <summary>
        /// Checks if a person is already actively enrolled in this course at this institute.
        /// Use before calling Save() to prevent duplicate enrollments.
        /// </summary>
        public static bool IsAlreadyEnrolled(int PersonID, int InstituteID, int CourseID)
        {
            return clsEnrollmentData.IsPersonAlreadyEnrolled(PersonID, InstituteID, CourseID);
        }
    }
}
