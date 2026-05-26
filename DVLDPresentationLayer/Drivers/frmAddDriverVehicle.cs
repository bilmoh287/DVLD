using System;
using System.Drawing;
using System.Windows.Forms;
using DVLDBussinessLayer;
using DVLDPresentationLayer.Global_Classes;

namespace DVLDPresentationLayer.Drivers
{
    public class frmAddDriverVehicle : Form
    {
        private Label lblTitle;
        private Label lblDriverID;
        private TextBox txtDriverID;
        private Label lblVehicleID;
        private TextBox txtVehicleID;
        private Button btnSearchCatalog;
        private Label lblPlateNumber;
        private TextBox txtPlateNumber;
        private Label lblVIN;
        private TextBox txtVIN;
        private Label lblColor;
        private TextBox txtColor;
        private Label lblPrice;
        private TextBox txtPrice;
        private Label lblDate;
        private DateTimePicker dtpDate;
        private Button btnSave;
        private Button btnCancel;

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public frmAddDriverVehicle()
        {
            InitializeComponent();
            _PolishUI();
        }

        public frmAddDriverVehicle(int driverID) : this()
        {
            txtDriverID.Text = driverID.ToString();
            txtDriverID.ReadOnly = true;
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblDriverID = new Label();
            this.txtDriverID = new TextBox();
            this.lblVehicleID = new Label();
            this.txtVehicleID = new TextBox();
            this.btnSearchCatalog = new Button();
            this.lblPlateNumber = new Label();
            this.txtPlateNumber = new TextBox();
            this.lblVIN = new Label();
            this.txtVIN = new TextBox();
            this.lblColor = new Label();
            this.txtColor = new TextBox();
            this.lblPrice = new Label();
            this.txtPrice = new TextBox();
            this.lblDate = new Label();
            this.dtpDate = new DateTimePicker();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Brown;
            this.lblTitle.Location = new Point(12, 15);
            this.lblTitle.Size = new Size(460, 40);
            this.lblTitle.Text = "Assign Vehicle to Driver";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Driver ID
            this.lblDriverID.Text = "Driver ID:";
            this.lblDriverID.Location = new Point(30, 80);
            this.lblDriverID.Size = new Size(100, 25);
            this.txtDriverID.Location = new Point(140, 77);
            this.txtDriverID.Size = new Size(280, 25);

            // Vehicle ID
            this.lblVehicleID.Text = "Vehicle ID:";
            this.lblVehicleID.Location = new Point(30, 120);
            this.lblVehicleID.Size = new Size(100, 25);
            this.txtVehicleID.Location = new Point(140, 117);
            this.txtVehicleID.Size = new Size(160, 25);
            this.btnSearchCatalog.Text = "Catalog";
            this.btnSearchCatalog.Location = new Point(310, 115);
            this.btnSearchCatalog.Size = new Size(110, 30);
            this.btnSearchCatalog.Click += BtnSearchCatalog_Click;

            // Plate Number
            this.lblPlateNumber.Text = "Plate No:";
            this.lblPlateNumber.Location = new Point(30, 160);
            this.lblPlateNumber.Size = new Size(100, 25);
            this.txtPlateNumber.Location = new Point(140, 157);
            this.txtPlateNumber.Size = new Size(280, 25);

            // VIN
            this.lblVIN.Text = "VIN:";
            this.lblVIN.Location = new Point(30, 200);
            this.lblVIN.Size = new Size(100, 25);
            this.txtVIN.Location = new Point(140, 197);
            this.txtVIN.Size = new Size(280, 25);

            // Color
            this.lblColor.Text = "Color:";
            this.lblColor.Location = new Point(30, 240);
            this.lblColor.Size = new Size(100, 25);
            this.txtColor.Location = new Point(140, 237);
            this.txtColor.Size = new Size(280, 25);
            this.txtColor.Text = "White";

            // Price
            this.lblPrice.Text = "Price ($):";
            this.lblPrice.Location = new Point(30, 280);
            this.lblPrice.Size = new Size(100, 25);
            this.txtPrice.Location = new Point(140, 277);
            this.txtPrice.Size = new Size(280, 25);
            this.txtPrice.Text = "15000";

            // Date
            this.lblDate.Text = "Purchase Date:";
            this.lblDate.Location = new Point(30, 320);
            this.lblDate.Size = new Size(110, 25);
            this.dtpDate.Location = new Point(140, 317);
            this.dtpDate.Size = new Size(280, 25);
            this.dtpDate.Format = DateTimePickerFormat.Short;

            // Save / Cancel
            this.btnSave.Text = "Save";
            this.btnSave.Location = new Point(200, 380);
            this.btnSave.Size = new Size(100, 35);
            this.btnSave.Click += BtnSave_Click;

            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new Point(320, 380);
            this.btnCancel.Size = new Size(100, 35);
            this.btnCancel.Click += BtnCancel_Click;

            // Form
            this.ClientSize = new Size(480, 450);
            this.Controls.AddRange(new Control[] {
                this.lblTitle,
                this.lblDriverID, this.txtDriverID,
                this.lblVehicleID, this.txtVehicleID, this.btnSearchCatalog,
                this.lblPlateNumber, this.txtPlateNumber,
                this.lblVIN, this.txtVIN,
                this.lblColor, this.txtColor,
                this.lblPrice, this.txtPrice,
                this.lblDate, this.dtpDate,
                this.btnSave, this.btnCancel
            });
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Assign Vehicle";
        }

        private void _PolishUI()
        {
            this.BackColor = Color.FromArgb(245, 247, 250);
            Font labelFont = new Font("Segoe UI", 10, FontStyle.Bold);
            Color textBlue = Color.FromArgb(26, 58, 96);

            foreach (Control c in this.Controls)
            {
                if (c is Label lbl && lbl != lblTitle)
                {
                    lbl.Font = labelFont;
                    lbl.ForeColor = textBlue;
                }
                else if (c is TextBox txt)
                {
                    txt.Font = new Font("Segoe UI", 10);
                    txt.BackColor = Color.White;
                }
                else if (c is Button btn)
                {
                    btn.BackColor = Color.White;
                    btn.ForeColor = textBlue;
                    btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 8, 8));
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Cursor = Cursors.Hand;
                    btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(235, 242, 255);
                    btn.MouseLeave += (s, e) => btn.BackColor = Color.White;
                }
            }

            btnSave.BackColor = Color.FromArgb(40, 85, 130);
            btnSave.ForeColor = Color.White;
            btnSave.MouseEnter += (s, e) => btnSave.BackColor = Color.FromArgb(50, 105, 160);
            btnSave.MouseLeave += (s, e) => btnSave.BackColor = Color.FromArgb(40, 85, 130);
        }

        private void BtnSearchCatalog_Click(object sender, EventArgs e)
        {
            // Open the vehicles catalog list form so the user can double-click/select a vehicle
            Vehicles.LiestVehicles frm = new Vehicles.LiestVehicles();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtVehicleID.Text = frm.SelectedVehicleID.ToString();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDriverID.Text) || 
                string.IsNullOrWhiteSpace(txtVehicleID.Text) || 
                string.IsNullOrWhiteSpace(txtPlateNumber.Text))
            {
                MessageBox.Show("Please fill all mandatory fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtDriverID.Text, out int driverID))
            {
                MessageBox.Show("Invalid Driver ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtVehicleID.Text, out int vehicleID))
            {
                MessageBox.Show("Invalid Vehicle ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal price = decimal.TryParse(txtPrice.Text, out decimal p) ? p : 0;

            clsDriverVehicle link = new clsDriverVehicle();
            link.DriverID = driverID;
            link.VehicleID = vehicleID;
            link.PlateNumber = txtPlateNumber.Text.Trim();
            link.VIN = txtVIN.Text.Trim();
            link.Color = txtColor.Text.Trim();
            link.PurchaseDate = dtpDate.Value;
            link.PurchasePrice = price;
            link.CreatedByUserID = clsGlobal.CurrentUser?.UserID ?? 1; // Default to UserID 1 if null

            if (link.Save())
            {
                MessageBox.Show("Vehicle linked successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to link vehicle to driver.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
