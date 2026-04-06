using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLDDataAccessLayer;

namespace DVLDBussinessLayer
{
    public class clsInstituteCourses
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int CourseID { get; set; }
        public int InstituteID { get; set; }
        public string CourseName { get; set; }
        public int DurationInDays { get; set; }
        public decimal CourseFee { get; set; }

        public clsInstituteCourses()
        {
            this.CourseID = -1;
            this.InstituteID = -1;
            this.CourseName = "";
            this.DurationInDays = 0;
            this.CourseFee = 0;
            Mode = enMode.AddNew;
        }

        private clsInstituteCourses(int CourseID, int InstituteID, string CourseName, int DurationInDays, decimal CourseFee)
        {
            this.CourseID = CourseID;
            this.InstituteID = InstituteID;
            this.CourseName = CourseName;
            this.DurationInDays = DurationInDays;
            this.CourseFee = CourseFee;
            Mode = enMode.Update;
        }

        public static clsInstituteCourses Find(int CourseID)
        {
            int InstituteID = -1, DurationInDays = 0;
            string CourseName = "";
            decimal CourseFee = 0;

            if (clsInstituteCourseData.GetCourseInfoByID(CourseID, ref InstituteID, ref CourseName, ref DurationInDays, ref CourseFee))
            {
                return new clsInstituteCourses(CourseID, InstituteID, CourseName, DurationInDays, CourseFee);
            }
            return null;
        }

        public static clsInstituteCourses Find(int CourseID, int InstituteID)
        {
            string CourseName = "";
            int DurationInDays = 0;
            decimal CourseFee = 0;

            if (clsInstituteCourseData.GetCourseInfoByCourseAndInstituteID(CourseID, InstituteID,
                ref CourseName, ref DurationInDays, ref CourseFee))
            {
                return new clsInstituteCourses(CourseID, InstituteID, CourseName, DurationInDays, CourseFee);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNew()
        {
            this.CourseID = clsInstituteCourseData.AddNewCourse(this.InstituteID, this.CourseName, this.DurationInDays, this.CourseFee);
            return (this.CourseID != -1);
        }

        private bool _Update()
        {
            return clsInstituteCourseData.UpdateCourse(this.CourseID, this.InstituteID, this.CourseName, this.DurationInDays, this.CourseFee);
        }

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
            }
            return false;
        }

        public static DataTable GetCoursesList(int InstituteID)
        {
            return clsInstituteCourseData.GetAllCoursesByInstituteID(InstituteID);
        }

        public static bool DeleteCourse(int CourseID, int InstituteID)
        {
            return clsInstituteCourseData.DeleteCourse(CourseID, InstituteID);
        }
    }
}
