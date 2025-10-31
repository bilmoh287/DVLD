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
    public partial class frmListTestTypes : Form
    {
        public frmListTestTypes()
        {
            InitializeComponent();
        }

        private void frmListTestTypes_Load(object sender, EventArgs e)
        {
            dgvListTestTypes.DataSource = clsTestTypes.GetAllTestTypesList();
            lblRecordsCount.Text = dgvListTestTypes.Rows.Count.ToString();

            if(dgvListTestTypes.Rows.Count>0)
            {
                // Customize header style (bold + sky blue)
                dgvListTestTypes.EnableHeadersVisualStyles = true;
                dgvListTestTypes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                //dgvListTestTypes.ColumnHeadersDefaultCellStyle.ForeColor = Color.DeepSkyBlue;
                //dgvListTestTypes.ColumnHeadersDefaultCellStyle.BackColor = Color.White; // optional, for contrast

                // Set column headers and widths
                dgvListTestTypes.Columns[0].HeaderText = "ID";
                dgvListTestTypes.Columns[0].Width = 50;

                dgvListTestTypes.Columns[1].HeaderText = "Test Type Title";
                dgvListTestTypes.Columns[1].Width = 200;

                dgvListTestTypes.Columns[2].HeaderText = "Test Type Description";
                dgvListTestTypes.Columns[2].Width = 450;

                dgvListTestTypes.Columns[3].HeaderText = "Fees";
                dgvListTestTypes.Columns[3].Width = 140;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvListTestTypes.CurrentRow.Cells[0].Value;
            frmUpdateTestTypes frm = new frmUpdateTestTypes(ID);
            frm.ShowDialog();
            frmListTestTypes_Load(null, null);
        }
    }
}
