using System;
using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{
    /// <summary>
    /// A lightweight DTO (Data Transfer Object) that loads all KPI statistics
    /// for the School Dashboard home screen in a single, clean call.
    /// Instructors and TestsToday are reserved for future implementation.
    /// </summary>
    public class clsSchoolDashboardStats
    {
        // Live KPIs — populated from the database
        public int TotalStudents  { get; private set; }
        public int ActiveCourses  { get; private set; }

        // Deferred KPIs — placeholders until future tables are ready
        public int TotalInstructors { get; private set; } // 🔜 Deferred
        public int TestsToday       { get; private set; } // 🔜 Deferred (publisher/consumer)

        // Private constructor — always use the static Load() factory method
        private clsSchoolDashboardStats(int totalStudents, int activeCourses)
        {
            TotalStudents    = totalStudents;
            ActiveCourses    = activeCourses;
            TotalInstructors = 0; // Placeholder
            TestsToday       = 0; // Placeholder
        }

        /// <summary>
        /// Loads all available dashboard statistics for the given institute.
        /// Returns a fully populated stats object. Never returns null.
        /// </summary>
        public static clsSchoolDashboardStats Load(int InstituteID)
        {
            int totalStudents = clsSchoolDashboardData.GetTotalStudentCount(InstituteID);
            int activeCourses = clsSchoolDashboardData.GetActiveCourseCount(InstituteID);

            return new clsSchoolDashboardStats(totalStudents, activeCourses);
        }
    }
}
