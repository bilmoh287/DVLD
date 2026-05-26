using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPresentationLayer.Vehicles
{
    public partial class LiestVehicles : Form
    {
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public int SelectedVehicleID { get; set; } = -1;
        private DataTable _dtVehiclesCatalog;

        public LiestVehicles()
        {
            InitializeComponent();
            _PolishUI();
            this.Load += LiestVehicles_Load;
        }

        private void LiestVehicles_Load(object sender, EventArgs e)
        {
            cbFilterBy.Items.Clear();
            cbFilterBy.Items.AddRange(new object[] { "None", "Vehicle ID", "Make", "Model" });
            cbFilterBy.SelectedIndex = 0;

            // Wire up handlers programmatically
            cbFilterBy.SelectedIndexChanged += cbFilterBy_SelectedIndexChanged;
            txtFilterValue.TextChanged += txtFilterValue_TextChanged;
            btnClose.Click += btnClose_Click;
            dgvListPeople.CellDoubleClick += dgvListPeople_CellDoubleClick;

            _RefreshList();
        }

        private void _RefreshList()
        {
            string filterValue = txtFilterValue.Text.Trim();
            string search = "";

            if (cbFilterBy.Text != "None" && !string.IsNullOrEmpty(filterValue))
            {
                search = filterValue;
            }

            // Load from database (top 100 matching items to avoid memory semaphore bottleneck)
            _dtVehiclesCatalog = DVLDBussinessLayer.clsDriverVehicle.GetVehiclesCatalog(cbFilterBy.Text, search, 100);
            dgvListPeople.DataSource = _dtVehiclesCatalog;
            lblRecord.Text = dgvListPeople.Rows.Count.ToString();

            if (dgvListPeople.Rows.Count > 0)
            {
                dgvListPeople.Columns["ID"].HeaderText = "Vehicle ID";
                dgvListPeople.Columns["ID"].Width = 100;

                dgvListPeople.Columns["Vehicle_Display_Name"].HeaderText = "Display Name";
                dgvListPeople.Columns["Vehicle_Display_Name"].Width = 350;

                dgvListPeople.Columns["Year"].HeaderText = "Year";
                dgvListPeople.Columns["Year"].Width = 80;

                dgvListPeople.Columns["Make"].HeaderText = "Make";
                dgvListPeople.Columns["Make"].Width = 150;

                dgvListPeople.Columns["ModelName"].HeaderText = "Model";
                dgvListPeople.Columns["ModelName"].Width = 150;
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
            _RefreshList();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _RefreshList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dgvListPeople_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectedVehicleID = (int)dgvListPeople.Rows[e.RowIndex].Cells["ID"].Value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void _PolishUI()
        {
            this.BackColor = Color.FromArgb(245, 247, 250);
            foreach (Control c in this.Controls)
            {
                if (c is Button btn)
                {
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.FromArgb(26, 58, 96);
                    btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 12, 12));
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Cursor = Cursors.Hand;
                    btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(235, 242, 255);
                    btn.MouseLeave += (s, e) => btn.BackColor = Color.White;
                }
                else if (c is Guna.UI2.WinForms.Guna2HtmlLabel lbl)
                {
                    lbl.ForeColor = Color.FromArgb(26, 58, 96);
                    lbl.Font = new Font("Segoe UI", 24, FontStyle.Bold);
                }
            }
        }
    }
}
