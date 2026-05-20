using System;
using System.Windows.Forms;
using DVLDPresentationLayer.Global_Classes;
using WPFPLDashboards;

namespace DVLDPresentationLayer.Schools_Dashboard.Forms
{
    public partial class frmDashboard : Form
    {
        private ucSchoolDashboard _wpfDashboard;

        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentInstituteID == null || !clsGlobal.CurrentInstituteID.HasValue)
            {
                MessageBox.Show("No institute is currently selected.", "Dashboard",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create the WPF Dashboard control
            _wpfDashboard = new ucSchoolDashboard();

            // Wire up events from WPF to open WinForms windows
            _wpfDashboard.AttendanceClicked += (s, ev) =>
            {
                try
                {
                    frmAttendance frm = new frmAttendance();
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not open Attendance: " + ex.Message);
                }
            };

            _wpfDashboard.StudentsClicked += (s, ev) =>
            {
                try
                {
                    frmStudents frm = new frmStudents();
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not open Students: " + ex.Message);
                }
            };

            _wpfDashboard.ScheduleTestClicked += (s, ev) =>
            {
                MessageBox.Show("Test Scheduling will be available soon.", "Coming Soon",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            _wpfDashboard.CoursesClicked += (s, ev) =>
            {
                MessageBox.Show("Courses management will be available soon.", "Coming Soon",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            // Host the WPF control inside the WinForms ElementHost
            wpfHost.Child = _wpfDashboard;

            // Initialize with the current institute data
            _wpfDashboard.InitializeDashboard(clsGlobal.CurrentInstituteID.Value);
        }
    }
}
