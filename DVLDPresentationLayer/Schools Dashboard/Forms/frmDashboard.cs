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
            if (clsGlobal.CurrentInstituteID == null)
                return;

            // Create the WPF Dashboard control
            _wpfDashboard = new ucSchoolDashboard();

            // Wire up events from WPF to open WinForms windows
            _wpfDashboard.AttendanceClicked += (s, ev) =>
            {
                frmAttendance frm = new frmAttendance();
                frm.ShowDialog();
            };

            _wpfDashboard.StudentsClicked += (s, ev) =>
            {
                frmStudents frm = new frmStudents();
                frm.ShowDialog();
            };

            // Host the WPF control inside the WinForms ElementHost
            wpfHost.Child = _wpfDashboard;

            // Initialize with the current institute data
            _wpfDashboard.InitializeDashboard(clsGlobal.CurrentInstituteID.Value);
        }
    }
}
