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
    public partial class frmListInstituteCourse : Form
    {
        private int _InstituteID = -1;
        public frmListInstituteCourse(int InstituteID )
        {
            InitializeComponent();
            _InstituteID = InstituteID;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddUpdateInstitueCourse frm = new frmAddUpdateInstitueCourse(_InstituteID);
            frm.ShowDialog();
            frmListInstituteCourse_Load(null, null);
        }

        private void frmListInstituteCourse_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsInstituteCourses.GetCoursesList(_InstituteID);
            lblRecordsCount.Text = dataGridView1.Rows.Count.ToString();

            if (dataGridView1.Rows.Count > 0)
            {

                // Set column headers and widths
                dataGridView1.Columns[0].HeaderText = "Institute ID";
                dataGridView1.Columns[0].Width = 110;

                dataGridView1.Columns[1].HeaderText = "Institute Name";
                dataGridView1.Columns[1].Width = 200;

                dataGridView1.Columns[2].HeaderText = "Course Name";
                dataGridView1.Columns[2].Width = 150;

                dataGridView1.Columns[3].HeaderText = "Duration In Days";
                dataGridView1.Columns[3].Width = 150;

                dataGridView1.Columns[4].HeaderText = "Course Fee";
                dataGridView1.Columns[4].Width = 200;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addNewCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateInstitueCourse frm = new frmAddUpdateInstitueCourse(_InstituteID);
            frm.ShowDialog();
            frmListInstituteCourse_Load(null, null);
        }

        private void editInstitueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CourseId = (int)dataGridView1.CurrentRow.Cells[0].Value;
            frmAddUpdateInstitueCourse frm = new frmAddUpdateInstitueCourse(_InstituteID, CourseId);
            frm.ShowDialog();
            frmListInstituteCourse_Load(null, null);
        }

        private void deleteInstiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CourseId = (int)dataGridView1.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("Are you sure you want to delete course[" + dataGridView1.CurrentRow.Cells[2].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsInstituteCourses.DeleteCourse(_InstituteID, CourseId))
                {
                    MessageBox.Show("Course Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmListInstituteCourse_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Course  was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
