using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBussinessLayer;

namespace DVLDPresentationLayer
{
    public partial class frmAddUpdateInstitueCourse : Form
    {
        enum enMode { AddNew = 0, Update = 1 };
        public enum enGendor { Male = 0, Female = 1 };
        private int _CourseID = -1;
        private clsInstituteCourses CourseID = new clsInstituteCourses();
        enMode _Mode = enMode.AddNew;
        public frmAddUpdateInstitueCourse()
        {
            InitializeComponent();
        }
        public frmAddUpdateInstitueCourse(int CourseID)
        {
            InitializeComponent();
            _CourseID = CourseID;
        }
    }
}
