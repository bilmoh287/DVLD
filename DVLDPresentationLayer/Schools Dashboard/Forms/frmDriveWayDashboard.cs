using System;
using System.Windows.Forms;
using DVLDPresentationLayer.Global_Classes;
using WPFPLDashboards;

namespace DVLDPresentationLayer.Schools_Dashboard.Forms
{
    public partial class frmDriveWayDashboard : Form
    {
        private ucDriveWayDashboard _wpfDashboard;

        public frmDriveWayDashboard()
        {
            InitializeComponent();
        }

        private void frmDriveWayDashboard_Load(object sender, EventArgs e)
        {
            if (clsGlobal.CurrentInstituteID == null || !clsGlobal.CurrentInstituteID.HasValue)
            {
                MessageBox.Show("No institute is currently selected.", "Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _wpfDashboard = new ucDriveWayDashboard();

            // Wire up events from WPF to WinForms navigation
            _wpfDashboard.StudentsClicked += (s, ev) =>
            {
                try {
                    frmStudents frm = new frmStudents();
                    frm.ShowDialog();
                } catch (Exception ex) { MessageBox.Show("Could not open Students: " + ex.Message); }
            };

            _wpfDashboard.FleetClicked += (s, ev) =>
            {
                try {
                    DVLDPresentationLayer.Vehicles.LiestVehicles frm = new DVLDPresentationLayer.Vehicles.LiestVehicles();
                    frm.ShowDialog();
                } catch (Exception ex) { MessageBox.Show("Could not open Fleet: " + ex.Message); }
            };

            wpfHost.Child = _wpfDashboard;
            _wpfDashboard.InitializeDashboard(clsGlobal.CurrentInstituteID.Value);
        }
    }
}
