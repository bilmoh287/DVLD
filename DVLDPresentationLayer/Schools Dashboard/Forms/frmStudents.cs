using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DVLDBussinessLayer;
using DVLDPresentationLayer.Global_Classes;

namespace DVLDPresentationLayer.Schools_Dashboard.Forms
{
    public partial class frmStudents : Form
    {
        // ── State ────────────────────────────────────────────────────────────
        private DataTable _allStudents;

        public frmStudents()
        {
            InitializeComponent();
        }

        private void frmStudents_Load(object sender, EventArgs e)
        {
            _LoadStudents();
        }

        // ── Load all students for this institute ─────────────────────────────
        private void _LoadStudents()
        {
            if (clsGlobal.CurrentInstituteID == null)
                return;

            _allStudents = clsEnrollment.GetAllByInstitute(clsGlobal.CurrentInstituteID.Value);

            _ApplyToGrid(_allStudents);
        }

        // ── Bind a DataTable to the grid and set column display ──────────────
        private void _ApplyToGrid(DataTable dt)
        {
            guna2DataGridView1.DataSource = dt;

            _Hide("EnrollmentID");
            _Hide("PersonID");

            _Rename("FullName",       "Student Name");
            _Rename("Phone",          "Phone");
            _Rename("CourseName",     "Course");
            _Rename("EnrollmentDate", "Enrolled On");
            _Rename("IsActive",       "Active");

            lblStudentCount.Text = $"{dt.Rows.Count} student(s) found";
        }

        // ── Search / filter ──────────────────────────────────────────────────
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_allStudents == null)
                return;

            string filter = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(filter))
            {
                _ApplyToGrid(_allStudents);
                return;
            }

            // Filter in-memory — no extra DB call
            DataTable filtered = _allStudents.Clone();
            foreach (DataRow row in _allStudents.Rows)
            {
                string name   = row["FullName"].ToString();
                string course = row["CourseName"].ToString();
                string phone  = row["Phone"].ToString();

                if (name.IndexOf(filter,   StringComparison.OrdinalIgnoreCase) >= 0 ||
                    course.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    phone.IndexOf(filter,  StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    filtered.ImportRow(row);
                }
            }

            _ApplyToGrid(filtered);
        }

        // ── Helpers ──────────────────────────────────────────────────────────
        private void _Hide(string col)
        {
            if (guna2DataGridView1.Columns[col] != null)
                guna2DataGridView1.Columns[col].Visible = false;
        }

        private void _Rename(string col, string header)
        {
            if (guna2DataGridView1.Columns[col] != null)
                guna2DataGridView1.Columns[col].HeaderText = header;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
