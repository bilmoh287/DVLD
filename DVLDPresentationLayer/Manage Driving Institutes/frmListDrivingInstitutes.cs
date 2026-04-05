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
    public partial class frmListDrivingInstitutes : Form
    {
        public frmListDrivingInstitutes()
        {
            InitializeComponent();
        }

        private void frmListDrivingInstitutes2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsDrivingInstitute.GetAllInstitutes();
            lblRecordsCount.Text = dataGridView1.Rows.Count.ToString();

            if (dataGridView1.Rows.Count > 0)
            {
                // Customize header style (bold + sky blue)
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkBlue;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.White; // optional, for contrast

                // Set column headers and widths
                dataGridView1.Columns[0].HeaderText = "Institute ID";
                dataGridView1.Columns[0].Width = 110;

                dataGridView1.Columns[1].HeaderText = "Institute Name";
                dataGridView1.Columns[1].Width = 267;

                dataGridView1.Columns[2].HeaderText = "Address";
                dataGridView1.Columns[2].Width = 150;

                dataGridView1.Columns[3].HeaderText = "Phone";
                dataGridView1.Columns[3].Width = 130;

                dataGridView1.Columns[4].HeaderText = "Email";
                dataGridView1.Columns[4].Width = 200;

                dataGridView1.Columns[5].HeaderText = "Is Active";
                dataGridView1.Columns[5].Width = 100;

            }
        }

        private void btnAddInstitute_Click(object sender, EventArgs e)
        {
            frmAddUpdateDrivingInstitutes frm = new frmAddUpdateDrivingInstitutes();
            frm.ShowDialog();
        }
    }
}
