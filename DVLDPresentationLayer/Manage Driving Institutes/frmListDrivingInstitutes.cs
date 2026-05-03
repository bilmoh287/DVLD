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
            dataGridView1.Columns.Clear(); // Force clear old columns
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
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[0].Width = 70;

                dataGridView1.Columns[1].HeaderText = "Institute Name";
                dataGridView1.Columns[1].Width = 200;

                dataGridView1.Columns[2].HeaderText = "Address";
                dataGridView1.Columns[2].Width = 150;

                dataGridView1.Columns[3].HeaderText = "City";
                dataGridView1.Columns[3].Width = 100;

                dataGridView1.Columns[4].HeaderText = "Region";
                dataGridView1.Columns[4].Width = 100;

                dataGridView1.Columns[5].HeaderText = "Phone";
                dataGridView1.Columns[5].Width = 120;

                dataGridView1.Columns[6].HeaderText = "Email";
                dataGridView1.Columns[6].Width = 180;

                dataGridView1.Columns[7].HeaderText = "Manager";
                dataGridView1.Columns[7].Width = 140;

                dataGridView1.Columns[8].HeaderText = "Cap.";
                dataGridView1.Columns[8].Width = 60;

                dataGridView1.Columns[9].HeaderText = "Active";
                dataGridView1.Columns[9].Width = 70;

            }
        }
        private void Frm_OnInstituteSaved(object sender, int instituteID)
        {
            // Reload the grid after saving
            dataGridView1.DataSource = clsDrivingInstitute.GetAllInstitutes();
            lblRecordsCount.Text = dataGridView1.Rows.Count.ToString();
        }

        private void btnAddInstitute_Click(object sender, EventArgs e)
        {
            frmAddUpdateDrivingInstitutes frm = new frmAddUpdateDrivingInstitutes();
            frm.OnInstituteSaved += Frm_OnInstituteSaved;
            frm.ShowDialog();
        }

        private void showCoursesListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InstituteId = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frmListInstituteCourse frm = new frmListInstituteCourse(InstituteId);
            frm.ShowDialog();
        }

        private void addNewCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateDrivingInstitutes frm = new frmAddUpdateDrivingInstitutes();
            frm.ShowDialog();
        }

        private void editInstitueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InstituteId = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frmAddUpdateDrivingInstitutes frm = new frmAddUpdateDrivingInstitutes(InstituteId);
            frm.OnInstituteSaved += Frm_OnInstituteSaved;
            frm.ShowDialog();
        }

        private void deleteInstiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InstituteId = (int)dataGridView1.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("Are you sure you want to delete [" + dataGridView1.CurrentRow.Cells[1].Value + "Institute]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsDrivingInstitute.DeleteInstitute(InstituteId))
                {
                    MessageBox.Show("User Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmListDrivingInstitutes2_Load(null, null);
                }
                else
                {
                    MessageBox.Show("User was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
