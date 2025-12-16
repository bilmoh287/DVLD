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
    public partial class frmListLocalDrivingLicenseApplications : Form
    {
        // Static cache: loads once and reused unless refreshed manually
        private static DataTable _dtAllLocalDrivingLicenseApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLiceseApplications();

        // Only select the columns needed for display — improves performance
        private DataTable _dtLocalDrivingLicenseApplications =
            _dtAllLocalDrivingLicenseApplications.DefaultView.ToTable(false,
                "LocalDrivingLicenseApplicationID",
                "ClassName",
                "NationalNo",
                "FullName",
                "ApplicationDate",
                "PassedTestCount",
                "Status"
            );
        public frmListLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }
        private void _RefreshList(object sender, int LDLApplicationID)
        {
            _dtAllLocalDrivingLicenseApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLiceseApplications();

            _dtLocalDrivingLicenseApplications =
                _dtAllLocalDrivingLicenseApplications.DefaultView.ToTable(false,
                    "LocalDrivingLicenseApplicationID",
                    "ClassName",
                    "NationalNo",
                    "FullName",
                    "ApplicationDate",
                    "PassedTestCount",
                    "Status"
                );

            dgvLocalDrivingLicenseApplications.DataSource = _dtLocalDrivingLicenseApplications;
            lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
        }
        private void frmListLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            dgvLocalDrivingLicenseApplications.DataSource = _dtLocalDrivingLicenseApplications;
            lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
            cbFilterBy.SelectedIndex = 0;

            if (dgvLocalDrivingLicenseApplications.Rows.Count > 0)
            {
                dgvLocalDrivingLicenseApplications.Columns[0].HeaderText = "L.D.L.AppID";
                dgvLocalDrivingLicenseApplications.Columns[0].Width = 120;

                dgvLocalDrivingLicenseApplications.Columns[1].HeaderText = "Driving Class";
                dgvLocalDrivingLicenseApplications.Columns[1].Width = 300;

                dgvLocalDrivingLicenseApplications.Columns[2].HeaderText = "National No.";
                dgvLocalDrivingLicenseApplications.Columns[2].Width = 150;

                dgvLocalDrivingLicenseApplications.Columns[3].HeaderText = "Full Name";
                dgvLocalDrivingLicenseApplications.Columns[3].Width = 290;

                dgvLocalDrivingLicenseApplications.Columns[4].HeaderText = "Application Date";
                dgvLocalDrivingLicenseApplications.Columns[4].Width = 170;

                dgvLocalDrivingLicenseApplications.Columns[5].HeaderText = "Passed Tests";
                dgvLocalDrivingLicenseApplications.Columns[5].Width = 130;
            }
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

            _dtLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
            lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            // Map combo selection to actual DataTable column
            switch (cbFilterBy.Text)
            {
                case "L.D.L.AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;
                case "National No.":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Status":
                    FilterColumn = "Status";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }
            string filterValue = txtFilterValue.Text.Trim();

            // If empty or no valid column, clear filter
            if (string.IsNullOrEmpty(filterValue) || FilterColumn == "None")
            {
                _dtLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtLocalDrivingLicenseApplications.DefaultView.Count.ToString();
                return;
            }

            if (FilterColumn == "LocalDrivingLicenseApplicationID")
            {
                // Ensure numeric input
                if (int.TryParse(filterValue, out int idValue))
                {
                    _dtLocalDrivingLicenseApplications.DefaultView.RowFilter = $"[{FilterColumn}] = {idValue}";
                }
                else
                {
                    // invalid numeric input. clear filter
                    _dtLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
                }
            }
            else
            {
                // Escape single quotes in text
                string safeText = filterValue.Replace("'", "''");
                _dtLocalDrivingLicenseApplications.DefaultView.RowFilter = $"[{FilterColumn}] LIKE '{safeText}%'";
            }
            lblRecordsCount.Text = _dtLocalDrivingLicenseApplications.DefaultView.Count.ToString();
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id is selected.
            if (cbFilterBy.Text == "L.D.L.AppID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication();
            frm.OnApplicationSaved += _RefreshList;
            frm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication(LDLApplicationID);
            frm.OnApplicationSaved += _RefreshList;
            frm.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            frmLocalDrivingLicenseApplicationInfo frm = new frmLocalDrivingLicenseApplicationInfo(LDLApplicationID);
            //frm.OnApplicationSaved += _RefreshList;
            frm.ShowDialog();
        }

        private void DeleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            int LDLApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationInfoByID(LDLApplicationID);
            if(LocalDrivingLicenseApplication !=  null)
            {
                if(clsLocalDrivingLicenseApplication.DeleteLocalDrivingLicenseApplication(LDLApplicationID))
                {
                    MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //refresh the form again.
                    _RefreshList(null, LDLApplicationID);
                }
                else
                {
                    MessageBox.Show("Could not delete applicatoin, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CancelApplicaitonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            int LDLApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationInfoByID(LDLApplicationID);

            if(LocalDrivingLicenseApplication != null)
            {
                if(LocalDrivingLicenseApplication.Cancel())
                {
                    MessageBox.Show("Application Cancelled Successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //refresh the form again.
                    _RefreshList(null, LDLApplicationID);
                }
                else
                {
                    MessageBox.Show("Could not Cancel applicatoin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void _Schedule(clsTestTypes.enTestType TestType)
        {
            int LDLApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            frmListTestApppointments frm = new frmListTestApppointments(LDLApplicationID, TestType);
            frm.ShowDialog();
            _RefreshList(null, LDLApplicationID);
        }
        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Schedule(clsTestTypes.enTestType.VisionTest);
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Schedule(clsTestTypes.enTestType.WrittenTest);
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Schedule(clsTestTypes.enTestType.StreetTest);
        }

        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                    clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationInfoByID
                                                    (LocalDrivingLicenseApplicationID);

            int TotalPassedTests = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[5].Value;

            showLicenseToolStripMenuItem.Enabled = false;

            //Enabled only if person does not passed all tests and the application status is New.
            ScheduleTestsMenue.Enabled = (TotalPassedTests != 3 && LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);
            //Enabled only if person passed all tests and Does not have license. 
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = (TotalPassedTests == 3);

            //Enable/Disable Cancel Menue Item
            //We only canel the applications with status=new.
            CancelApplicaitonToolStripMenuItem.Enabled = (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            //Enable/Disable Delete Menue Item
            //We only allow delete incase the application status is new not complete or Cancelled.
            DeleteApplicationToolStripMenuItem.Enabled = (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            //We only allow edit incase the application status is new not complete or Cancelled.
            editToolStripMenuItem.Enabled = (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            //Enable Disable Schedule menue and it's sub menue
            bool PassedVisionTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.VisionTest); ;
            bool PassedWrittenTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.WrittenTest);
            bool PassedStreetTest = LocalDrivingLicenseApplication.DoesPassTestType(clsTestTypes.enTestType.StreetTest);

            if(ScheduleTestsMenue.Enabled)
            {
                //To Allow Schdule vision test, Person must not passed the same test before.
                scheduleVisionTestToolStripMenuItem.Enabled = !PassedVisionTest;

                //To Allow Schdule written test, Person must pass the vision test and must not passed the same test before.
                scheduleWrittenTestToolStripMenuItem.Enabled = PassedVisionTest && !PassedWrittenTest;

                //To Allow Schdule steet test, Person must pass the vision * written tests, and must not passed the same test before.
                scheduleStreetTestToolStripMenuItem.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;
            }
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLApplicationID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            frmIssueDriverLicenseFirstTime frm = new frmIssueDriverLicenseFirstTime(LDLApplicationID);
            frm.ShowDialog();
            _RefreshList(null, LDLApplicationID);
        }
    }
}
