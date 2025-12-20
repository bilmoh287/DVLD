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
using DVLDPresentationLayer.Licenses;
using DVLDPresentationLayer.Licenses.Detain_License;

namespace DVLDPresentationLayer.Applications.Relesease_Detained_Licenses
{
    public partial class frmListDetainedLicenses : Form
    {
        private static DataTable _dtAllDetainedLicenses = clsDetainedLicenses.GetAllDetainedLicenses();
        private DataTable _dtDetainedLicenses =
            _dtAllDetainedLicenses.DefaultView.ToTable(
                false,
                "DetainID",
                "LicenseID",
                "DetainDate",
                "IsReleased",
                "FineFees",
                "ReleaseDate",
                "NationalNo",
                "FullName",
                "ReleaseApplicationID");
        private clsLicenses _License;
        public frmListDetainedLicenses()
        {
            InitializeComponent();
        }

        private void _RefreshDetainedLicensesList()
        {
         _dtAllDetainedLicenses = clsDetainedLicenses.GetAllDetainedLicenses();
         _dtDetainedLicenses =
            _dtAllDetainedLicenses.DefaultView.ToTable(
                false,
                "DetainID",
                "LicenseID",
                "DetainDate",
                "IsReleased",
                "FineFees",
                "ReleaseDate",
                "NationalNo",
                "FullName",
                "ReleaseApplicationID");
            dgvDetainedLicenses.DataSource = _dtDetainedLicenses; 
            lblTotalRecords.Text = dgvDetainedLicenses.RowCount.ToString();
        }

        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            dgvDetainedLicenses.DataSource = _dtDetainedLicenses;
            lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();

            if (dgvDetainedLicenses.Rows.Count > 0)
            {
                dgvDetainedLicenses.Columns[0].HeaderText = "D.ID";
                dgvDetainedLicenses.Columns[0].Width = 90;

                dgvDetainedLicenses.Columns[1].HeaderText = "L.ID";
                dgvDetainedLicenses.Columns[1].Width = 90;

                dgvDetainedLicenses.Columns[2].HeaderText = "D.Date";
                dgvDetainedLicenses.Columns[2].Width = 160;

                dgvDetainedLicenses.Columns[3].HeaderText = "Is Released";
                dgvDetainedLicenses.Columns[3].Width = 110;

                dgvDetainedLicenses.Columns[4].HeaderText = "Fine Fees";
                dgvDetainedLicenses.Columns[4].Width = 110;

                dgvDetainedLicenses.Columns[5].HeaderText = "Release Date";
                dgvDetainedLicenses.Columns[5].Width = 200;

                dgvDetainedLicenses.Columns[6].HeaderText = "N.No.";
                dgvDetainedLicenses.Columns[6].Width = 150;

                dgvDetainedLicenses.Columns[7].HeaderText = "Full Name";
                dgvDetainedLicenses.Columns[7].Width = 245;

                dgvDetainedLicenses.Columns[8].HeaderText = "Rlease App.ID";
                dgvDetainedLicenses.Columns[8].Width = 150;
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.Text == "Is Released")
            {
                txtFilterValue.Visible = false;
                cbIsReleased.Visible = true;
                cbIsReleased.SelectedIndex = 0;
            }
            else
            {
                cbIsReleased.Visible = false;
                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                txtFilterValue.Enabled = (cbFilterBy.Text != "None");
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string filterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Detain ID":
                    filterColumn = "DetainID";
                    break;

                case "National No.":
                    filterColumn = "NationalNo";
                    break;

                case "Full Name":
                    filterColumn = "FullName";
                    break;

                case "Release Application ID":
                    filterColumn = "ReleaseApplicationID";
                    break;

                default:
                    filterColumn = "None";
                    break;
            }

            if (string.IsNullOrWhiteSpace(txtFilterValue.Text) || filterColumn == "None")
            {
                _dtDetainedLicenses.DefaultView.RowFilter = "";
                lblTotalRecords.Text = _dtDetainedLicenses.DefaultView.Count.ToString();
                return;
            }

            if (filterColumn == "DetainID" || filterColumn == "ReleaseApplicationID")
            {
                _dtDetainedLicenses.DefaultView.RowFilter =
                    $"[{filterColumn}] = {txtFilterValue.Text.Trim()}";
            }
            else
            {
                _dtDetainedLicenses.DefaultView.RowFilter =
                    $"[{filterColumn}] LIKE '{txtFilterValue.Text.Trim()}%'";
            }

            lblTotalRecords.Text = _dtDetainedLicenses.DefaultView.Count.ToString();
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIsReleased.Text == "All")
            {
                _dtDetainedLicenses.DefaultView.RowFilter = "";
            }
            else
            {
                int value = (cbIsReleased.Text == "Yes") ? 1 : 0;
                _dtDetainedLicenses.DefaultView.RowFilter = $"[IsReleased] = {value}";
            }

            lblTotalRecords.Text = _dtDetainedLicenses.DefaultView.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Detain ID" || cbFilterBy.Text == "Release Application ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void PesonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;
            int PerosonID = clsLicenses.Find(LicenseID).DriverInfo.PersonID;
            frmShowPersonInfo frm = new frmShowPersonInfo(PerosonID);
            frm.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;
            frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;
            int PerosonID = clsLicenses.Find(LicenseID).DriverInfo.PersonID;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PerosonID);
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication(LicenseID);
            frm.ShowDialog();
            _RefreshDetainedLicensesList();
        }

        private void btnReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
            _RefreshDetainedLicensesList();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm = new frmDetainLicenseApplication();
            frm.ShowDialog();
            _RefreshDetainedLicensesList();
        }

        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            bool IsReleased = (bool)dgvDetainedLicenses.CurrentRow.Cells[3].Value;
            releaseDetainedLicenseToolStripMenuItem.Enabled = !IsReleased;
        }
    }
}
