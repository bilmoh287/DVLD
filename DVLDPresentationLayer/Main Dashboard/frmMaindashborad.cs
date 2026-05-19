using System;
using System.Drawing;
using System.Windows.Forms;
using DVLDBussinessLayer;
using DVLDPresentationLayer.Global_Classes;
using DVLDPresentationLayer.Main_Dashboard.User_Controls;
using DVLDPresentationLayer.Vehicles;

namespace DVLDPresentationLayer
{
    public partial class frmMaindashborad : Form
    {
        public frmMaindashborad()
        {
            InitializeComponent();
        }

        private void _LoadUserControl(UserControl userControl)
        {
            if (panel2.Controls.Count > 0)
                panel2.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            panel2.Controls.Add(userControl);
        }

        private void _ApplyPermissions()
        {
            //// Dashboard — visible to all
            //btnDashboard.Visible       = true;
            //// Applicants — visible to all
            //btnApplicants.Visible      = true;

            //btnApplications.Visible    = clsGlobal.HasPermission(clsUserPermission.enPermissions.ManageApplications);
            //btnTestManagement.Visible  = clsGlobal.HasPermission(clsUserPermission.enPermissions.ManageTests);
            //btnLicenses.Visible        = clsGlobal.HasPermission(clsUserPermission.enPermissions.IssueLicense);
            //btnVehicles.Visible        = clsGlobal.HasPermission(clsUserPermission.enPermissions.ViewPeople);
            //btnReports.Visible         = clsGlobal.HasPermission(clsUserPermission.enPermissions.ManageApplications);
            //btnComplaints.Visible      = clsGlobal.HasPermission(clsUserPermission.enPermissions.ManageUsers);
            //btnNotifications.Visible   = true; // everyone
            //btnSettings.Visible        = clsGlobal.HasPermission(clsUserPermission.enPermissions.ManageUsers);
        }

        // ── Sidebar Handlers ────────────────────────────────────────────────

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            lblHeader.Text = "DASHBOARD";
            _LoadUserControl(new ucDashboard());
        }

        private void btnApplicants_Click(object sender, EventArgs e)
        {
            lblHeader.Text = "APPLICANTS";
            _LoadUserControl(new ucApplicants());
        }

        private void btnApplications_Click(object sender, EventArgs e)
        {
            lblHeader.Text = "PEOPLE";
            _LoadUserControl(new ucPeople());
        }

        private void btnTestManagement_Click(object sender, EventArgs e)
        {
            lblHeader.Text = "TEST MANAGEMENT";
            _LoadUserControl(new ucTestManagement());
        }

        private void btnLicenses_Click(object sender, EventArgs e)
        {
            lblHeader.Text = "USERS";
            _LoadUserControl(new ucUsers());
        }

        private void btnVehicles_Click(object sender, EventArgs e)
        {
            lblHeader.Text = "VEHICLES";
            
            // To embed the form inside the panel instead of popping it up, we could do:
            LiestVehicles frm = new LiestVehicles();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            if (panel2.Controls.Count > 0)
                panel2.Controls.Clear();
            panel2.Controls.Add(frm);
            frm.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            lblHeader.Text = "REPORTS & REVIEW";
            // Opens the Under Review form as a dialog from this hub
            new frmUnderReview().ShowDialog();
        }

        private void btnComplaints_Click(object sender, EventArgs e)
        {
            lblHeader.Text = "COMPLAINTS INBOX";
            // Wire to frmComplaints when you build it
            MessageBox.Show("Complaints form coming soon.", "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            lblHeader.Text = "NOTIFICATIONS";
            MessageBox.Show("Notifications form coming soon.", "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            lblHeader.Text = "SETTINGS";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblHeader.Text = "USERS";
            _LoadUserControl(new ucUsers());
        }

        // ── Form Events ──────────────────────────────────────────────────────

        private void frmMaindashborad_Load(object sender, EventArgs e)
        {
            _ApplyPermissions();
            btnDashboard_Click(null, null);
        }
    }
}

