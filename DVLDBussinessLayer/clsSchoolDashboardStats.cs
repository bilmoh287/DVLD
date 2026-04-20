using System;
using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{
    /// <summary>
    /// A snapshot of all KPI statistics for the School Dashboard home screen.
    /// Loaded in a single call via the static Load() factory method.
    /// Pass rates use -1 as a sentinel meaning "no test data this month".
    /// </summary>
    public class clsSchoolDashboardStats
    {
        // ── KPI Cards ────────────────────────────────────────────────────────
        public int TotalStudents         { get; private set; }
        public int NewStudentsThisMonth  { get; private set; }
        public int ActiveCourses         { get; private set; }
        public int TotalInstructors      { get; private set; }
        public int TestsToday            { get; private set; }

        // ── Pass Rates (0-100, or -1 if no data this month) ─────────────────
        public int PassRateVision  { get; private set; }
        public int PassRateTheory  { get; private set; }
        public int PassRateRoad    { get; private set; }

        // Private constructor — always use Load()
        private clsSchoolDashboardStats(
            int totalStudents, int newStudentsThisMonth,
            int activeCourses, int totalInstructors, int testsToday,
            int passRateVision, int passRateTheory, int passRateRoad)
        {
            TotalStudents        = totalStudents;
            NewStudentsThisMonth = newStudentsThisMonth;
            ActiveCourses        = activeCourses;
            TotalInstructors     = totalInstructors;
            TestsToday           = testsToday;
            PassRateVision       = passRateVision;
            PassRateTheory       = passRateTheory;
            PassRateRoad         = passRateRoad;
        }

        /// <summary>
        /// Loads all dashboard statistics for the given institute in one call.
        /// Never returns null.
        /// </summary>
        public static clsSchoolDashboardStats Load(int InstituteID)
        {
            return new clsSchoolDashboardStats(
                totalStudents:        clsSchoolDashboardData.GetTotalStudentCount(InstituteID),
                newStudentsThisMonth: clsSchoolDashboardData.GetNewStudentsThisMonth(InstituteID),
                activeCourses:        clsSchoolDashboardData.GetActiveCourseCount(InstituteID),
                totalInstructors:     clsSchoolDashboardData.GetTotalInstructorCount(InstituteID),
                testsToday:           clsSchoolDashboardData.GetTestsTodayCount(InstituteID),
                passRateVision:       clsSchoolDashboardData.GetPassRateByTestType(InstituteID, 1),
                passRateTheory:       clsSchoolDashboardData.GetPassRateByTestType(InstituteID, 2),
                passRateRoad:         clsSchoolDashboardData.GetPassRateByTestType(InstituteID, 3)
            );
        }
    }
}
