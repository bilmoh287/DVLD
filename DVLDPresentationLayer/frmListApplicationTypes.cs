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
    public partial class frmListApplicationTypes : Form
    {
        public frmListApplicationTypes()
        {
            InitializeComponent();
        }

        private void frmListApplicationTypes_Load(object sender, EventArgs e)
        {
            dgvListApplications.DataSource = clsApplicationTypes.GetAllApplicationsTypeList();
            lblRecordsCount.Text = dgvListApplications.Rows.Count.ToString();

            // Customize header style (bold + sky blue)
            dgvListApplications.EnableHeadersVisualStyles = false;
            dgvListApplications.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvListApplications.ColumnHeadersDefaultCellStyle.ForeColor = Color.DeepSkyBlue;
            dgvListApplications.ColumnHeadersDefaultCellStyle.BackColor = Color.White; // optional, for contrast

            // Set column headers and widths
            dgvListApplications.Columns[0].HeaderText = "ID";
            dgvListApplications.Columns[0].Width = 110;

            dgvListApplications.Columns[1].HeaderText = "Application Type Title";
            dgvListApplications.Columns[1].Width = 360;

            dgvListApplications.Columns[2].HeaderText = "Fees";
            dgvListApplications.Columns[2].Width = 140;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvListApplications.CurrentRow.Cells[0].Value;
            frmUpdateApplicationType frm = new frmUpdateApplicationType(ID);
            frm.ShowDialog();

            frmListApplicationTypes_Load(null, null);
        }
    }
}
