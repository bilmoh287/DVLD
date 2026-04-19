using System;
using System.Windows.Forms;
using DVLDBussinessLayer;
using DVLDPresentationLayer.Global_Classes;

namespace DVLDPresentationLayer.Schools_Dashboard.Forms
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            _LoadDashboardStats();
        }

        private void _LoadDashboardStats()
        {
            if (clsGlobal.CurrentInstituteID == null)
                return;

            clsSchoolDashboardStats stats = clsSchoolDashboardStats.Load(clsGlobal.CurrentInstituteID.Value);

            // KPI: Total Students panel
            lblTotalStudents.Text = stats.TotalStudents.ToString();

            // KPI: Active Courses panel
            lblTotalCourses.Text = stats.ActiveCourses.ToString();

            // KPI: Instructors (deferred — show dash as placeholder)
            lblTotalInstructors.Text = "—";

            // KPI: Tests Today (deferred — show dash as placeholder)
            lblTestsToday.Text = "—";
        }
    }
}

