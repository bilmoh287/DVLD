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

namespace DVLDPresentationLayer.Drivers
{
    public partial class frmAssinVehiclesForDrivers : Form
    {
        private DataTable _dtDriverVehicles;
        private int _SelectedDriverID = -1;

        public frmAssinVehiclesForDrivers()
        {
            InitializeComponent();
            this.Load += frmAssinVehiclesForDrivers_Load;
        }

        public frmAssinVehiclesForDrivers(int driverID) : this()
        {
            _SelectedDriverID = driverID;
        }

        private void frmAssinVehiclesForDrivers_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Driver Vehicles Assignment";
            pbPersonImage.Image = global::DVLDPresentationLayer.Properties.Resources.Local_32;

            // Setup filters
            cbFilterBy.Items.Clear();
            cbFilterBy.Items.AddRange(new object[] { "None", "Driver ID" });
            
            // Assign ContextMenuStrip to DataGridView
            dgvLocalDrivingLicenseApplications.ContextMenuStrip = cmsApplications;

            if (_SelectedDriverID != -1)
            {
                cbFilterBy.SelectedIndex = 1; // Filter by Driver ID
                txtFilterValue.Text = _SelectedDriverID.ToString();
            }
            else
            {
                cbFilterBy.SelectedIndex = 1; // Default to filter by Driver ID
                txtFilterValue.Text = "1"; // Default search for Driver 1 to load sample data instantly
            }

            // Wire up event handlers
            txtFilterValue.KeyPress += TxtFilterValue_KeyPress;
            txtFilterValue.TextChanged += TxtFilterValue_TextChanged;
            btnAddNewApplication.Click += BtnAddNewApplication_Click;
            btnClose.Click += BtnClose_Click;

            _RefreshList();
        }

        private void _RefreshList()
        {
            if (string.IsNullOrWhiteSpace(txtFilterValue.Text) || cbFilterBy.Text == "None")
            {
                dgvLocalDrivingLicenseApplications.DataSource = null;
                lblRecordsCount.Text = "0";
                return;
            }

            if (int.TryParse(txtFilterValue.Text.Trim(), out int driverID))
            {
                _dtDriverVehicles = clsDriverVehicle.GetDriverHistory(driverID);
                dgvLocalDrivingLicenseApplications.DataSource = _dtDriverVehicles;
                lblRecordsCount.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();

                // Beautify grid column headers if data exists
                if (dgvLocalDrivingLicenseApplications.Rows.Count > 0)
                {
                    dgvLocalDrivingLicenseApplications.Columns["OwnershipID"].HeaderText = "Ownership ID";
                    dgvLocalDrivingLicenseApplications.Columns["OwnershipID"].Width = 110;

                    dgvLocalDrivingLicenseApplications.Columns["PlateNumber"].HeaderText = "Plate No";
                    dgvLocalDrivingLicenseApplications.Columns["PlateNumber"].Width = 120;

                    dgvLocalDrivingLicenseApplications.Columns["VIN"].HeaderText = "VIN";
                    dgvLocalDrivingLicenseApplications.Columns["VIN"].Width = 150;

                    dgvLocalDrivingLicenseApplications.Columns["Color"].HeaderText = "Color";
                    dgvLocalDrivingLicenseApplications.Columns["Color"].Width = 90;

                    dgvLocalDrivingLicenseApplications.Columns["Make"].HeaderText = "Make";
                    dgvLocalDrivingLicenseApplications.Columns["Make"].Width = 120;

                    dgvLocalDrivingLicenseApplications.Columns["ModelName"].HeaderText = "Model";
                    dgvLocalDrivingLicenseApplications.Columns["ModelName"].Width = 150;

                    dgvLocalDrivingLicenseApplications.Columns["Year"].HeaderText = "Year";
                    dgvLocalDrivingLicenseApplications.Columns["Year"].Width = 80;

                    dgvLocalDrivingLicenseApplications.Columns["Vehicle_Display_Name"].HeaderText = "Display Name";
                    dgvLocalDrivingLicenseApplications.Columns["Vehicle_Display_Name"].Width = 200;

                    dgvLocalDrivingLicenseApplications.Columns["PurchaseDate"].HeaderText = "Purchase Date";
                    dgvLocalDrivingLicenseApplications.Columns["PurchaseDate"].Width = 130;

                    dgvLocalDrivingLicenseApplications.Columns["PurchasePrice"].HeaderText = "Price ($)";
                    dgvLocalDrivingLicenseApplications.Columns["PurchasePrice"].Width = 100;
                }
            }
        }

        private void TxtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers for Driver ID
            if (cbFilterBy.Text == "Driver ID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void TxtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _RefreshList();
        }

        private void BtnAddNewApplication_Click(object sender, EventArgs e)
        {
            int defaultDriverID = 1;
            if (int.TryParse(txtFilterValue.Text, out int parsed))
            {
                defaultDriverID = parsed;
            }

            frmAddDriverVehicle frm = new frmAddDriverVehicle(defaultDriverID);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _RefreshList();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showVehicleInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLocalDrivingLicenseApplications.CurrentRow == null) return;

            var row = dgvLocalDrivingLicenseApplications.CurrentRow;
            string make = row.Cells["Make"].Value.ToString();
            string model = row.Cells["ModelName"].Value.ToString();
            string year = row.Cells["Year"].Value.ToString();
            string plate = row.Cells["PlateNumber"].Value.ToString();
            string vin = row.Cells["VIN"].Value.ToString();
            string color = row.Cells["Color"].Value.ToString();
            string displayName = row.Cells["Vehicle_Display_Name"].Value.ToString();
            string purchaseDate = Convert.ToDateTime(row.Cells["PurchaseDate"].Value).ToShortDateString();
            string price = row.Cells["PurchasePrice"].Value.ToString();
            string status = row.Cells["Status"].Value.ToString();

            string info = $"Vehicle: {displayName}\n" +
                          $"Make: {make}\n" +
                          $"Model: {model}\n" +
                          $"Year: {year}\n" +
                          $"Plate Number: {plate}\n" +
                          $"VIN: {vin}\n" +
                          $"Color: {color}\n" +
                          $"Purchase Date: {purchaseDate}\n" +
                          $"Purchase Price: ${price}\n" +
                          $"Status: {status}";

            MessageBox.Show(info, "Vehicle Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void assignNewVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtnAddNewApplication_Click(sender, e);
        }

        private void releaseVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvLocalDrivingLicenseApplications.CurrentRow == null) return;

            int ownershipID = (int)dgvLocalDrivingLicenseApplications.CurrentRow.Cells["OwnershipID"].Value;

            object saleDateVal = dgvLocalDrivingLicenseApplications.CurrentRow.Cells["SaleDate"].Value;
            if (saleDateVal != DBNull.Value && saleDateVal != null)
            {
                MessageBox.Show("This vehicle has already been sold/released.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Are you sure you want to release/sell this vehicle?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsDriverVehicle.ReleaseVehicle(ownershipID))
                {
                    MessageBox.Show("Vehicle released/sold successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshList();
                }
                else
                {
                    MessageBox.Show("Failed to release/sell vehicle.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
