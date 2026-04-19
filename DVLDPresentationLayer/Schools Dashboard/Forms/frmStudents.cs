using System;
using System.Data;
using System.Windows.Forms;
using DVLDBussinessLayer;
using DVLDPresentationLayer.Global_Classes;

namespace DVLDPresentationLayer.Schools_Dashboard.Forms
{
    public partial class frmStudents : Form
    {
        public frmStudents()
        {
            InitializeComponent();
        }

        private void frmStudents_Load(object sender, EventArgs e)
        {
            _LoadStudents();
        }

        private void _LoadStudents()
        {
            if (clsGlobal.CurrentInstituteID == null)
                return;

            DataTable dt = clsEnrollment.GetAllByInstitute(clsGlobal.CurrentInstituteID.Value);

            guna2DataGridView1.DataSource = dt;

            // Make the grid columns human-readable
            if (guna2DataGridView1.Columns["EnrollmentID"] != null)
                guna2DataGridView1.Columns["EnrollmentID"].Visible = false;

            if (guna2DataGridView1.Columns["PersonID"] != null)
                guna2DataGridView1.Columns["PersonID"].Visible = false;

            if (guna2DataGridView1.Columns["FullName"] != null)
                guna2DataGridView1.Columns["FullName"].HeaderText = "Student Name";

            if (guna2DataGridView1.Columns["Phone"] != null)
                guna2DataGridView1.Columns["Phone"].HeaderText = "Phone";

            if (guna2DataGridView1.Columns["CourseName"] != null)
                guna2DataGridView1.Columns["CourseName"].HeaderText = "Course";

            if (guna2DataGridView1.Columns["EnrollmentDate"] != null)
                guna2DataGridView1.Columns["EnrollmentDate"].HeaderText = "Enrolled On";

            if (guna2DataGridView1.Columns["IsActive"] != null)
                guna2DataGridView1.Columns["IsActive"].HeaderText = "Active";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

