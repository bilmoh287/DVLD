using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBussinessLayer;
using DVLDPresentationLayer.Licenses;

namespace DVLDPresentationLayer
{
    public partial class frmListDrivers : Form
    {
        private static  DataTable _dtAllDrivers = clsDrivers.GetAllDrivers();

        private DataTable _dtDrivers =
        _dtAllDrivers.DefaultView.ToTable(false,
            "DriverID",
            "PersonID",
            "NationalNo",
            "FullName",
            "CreatedDate",
            "NumberOfActiveLicenses"
        );
        public frmListDrivers()
        {
            InitializeComponent();
        }

        private void _RefreshList()
        {
            _dtAllDrivers = clsDrivers.GetAllDrivers();

            _dtDrivers =
                _dtAllDrivers.DefaultView.ToTable(false,
                    "DriverID",
                    "PersonID",
                    "NationalNo",
                    "FullName",
                    "CreatedDate",
                    "NumberOfActiveLicenses"
                );
            dgvDrivers.DataSource = _dtDrivers;
            lblRecordsCount.Text = _dtDrivers.Rows.Count.ToString();
        }

        private void frmDriversList_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            dgvDrivers.DataSource = _dtDrivers;
            lblRecordsCount.Text = dgvDrivers.Rows.Count.ToString();
            if (dgvDrivers.Rows.Count > 0)
            {
                dgvDrivers.Columns[0].HeaderText = "Driver ID";
                dgvDrivers.Columns[0].Width = 120;

                dgvDrivers.Columns[1].HeaderText = "Person ID";
                dgvDrivers.Columns[1].Width = 120;

                dgvDrivers.Columns[2].HeaderText = "National No.";
                dgvDrivers.Columns[2].Width = 140;

                dgvDrivers.Columns[3].HeaderText = "Full Name";
                dgvDrivers.Columns[3].Width = 320;

                dgvDrivers.Columns[4].HeaderText = "Date";
                dgvDrivers.Columns[4].Width = 170;

                dgvDrivers.Columns[5].HeaderText = "Active Licenses";
                dgvDrivers.Columns[5].Width = 150;
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

            _dtDrivers.DefaultView.RowFilter = "";
            lblRecordsCount.Text = _dtDrivers.DefaultView.Count.ToString();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            // Map combo selection to actual DataTable column
            switch (cbFilterBy.Text)
            {
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Active Licenses":
                    FilterColumn = "NumberOfActiveLicenses";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            string filterValue = txtFilterValue.Text.Trim();

            // Clear filter if empty or invalid
            if (string.IsNullOrEmpty(filterValue) || FilterColumn == "None")
            {
                _dtDrivers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtDrivers.DefaultView.Count.ToString();
                return;
            }

            // Numeric filters
            if (FilterColumn == "DriverID" ||
                FilterColumn == "PersonID" ||
                FilterColumn == "NumberOfActiveLicenses")
            {
                if (int.TryParse(filterValue, out int idValue))
                {
                    _dtDrivers.DefaultView.RowFilter = $"[{FilterColumn}] = {idValue}";
                }
                else
                {
                    _dtDrivers.DefaultView.RowFilter = "";
                }
            }
            else
            {
                // Text filter (safe from quotes issue)
                string safeText = filterValue.Replace("'", "''");
                _dtDrivers.DefaultView.RowFilter = $"[{FilterColumn}] LIKE '{safeText}%'";
            }

            // Update record count
            lblRecordsCount.Text = _dtDrivers.DefaultView.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers for numeric filters
            if (cbFilterBy.Text == "Driver ID" ||
                cbFilterBy.Text == "Person ID" ||
                cbFilterBy.Text == "Active Licenses")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvDrivers.CurrentRow.Cells[1].Value;
            frmShowPersonInfo frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();
        }

        private void issueInternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvDrivers.CurrentRow.Cells[1].Value;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void manageAssignedVehiclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDrivers.CurrentRow == null) return;
            int DriverID = (int)dgvDrivers.CurrentRow.Cells[0].Value;
            Drivers.frmAssinVehiclesForDrivers frm = new Drivers.frmAssinVehiclesForDrivers(DriverID);
            frm.ShowDialog();
            _RefreshList();
        }
    }
}
