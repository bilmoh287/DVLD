using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DVLDBussinessLayer;
using DVLDPresentationLayer.Global_Classes;

namespace DVLDPresentationLayer.Schools_Dashboard.Forms
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            _LoadDashboard();
        }

        // ─── Master loader ───────────────────────────────────────────────────
        private void _LoadDashboard()
        {
            if (clsGlobal.CurrentInstituteID == null)
                return;

            int id = clsGlobal.CurrentInstituteID.Value;

            clsSchoolDashboardStats stats = clsSchoolDashboardStats.Load(id);

            _PopulateKpiCards(stats);
            _PopulatePassRates(stats);
            _LoadRecentStudents(id);
        }

        // ─── KPI Cards ───────────────────────────────────────────────────────
        private void _PopulateKpiCards(clsSchoolDashboardStats stats)
        {
            // Card 1 — Total Students
            lblTotalStudents.Text = stats.TotalStudents.ToString();
            lblNewStudents.Text   = stats.NewStudentsThisMonth > 0
                                        ? $"+{stats.NewStudentsThisMonth} this month"
                                        : "No new enrollments this month";
            lblNewStudents.ForeColor = stats.NewStudentsThisMonth > 0
                                        ? Color.FromArgb(67, 160, 71)
                                        : Color.FromArgb(150, 150, 170);

            // Card 2 — Active Courses
            lblTotalCourses.Text = stats.ActiveCourses.ToString();

            // Card 3 — Instructors
            lblTotalInstructors.Text = stats.TotalInstructors > 0
                                            ? stats.TotalInstructors.ToString()
                                            : "—";

            // Card 4 — Tests Today
            lblTestsToday.Text = stats.TestsToday.ToString();
        }

        // ─── Pass Rates ──────────────────────────────────────────────────────
        private void _PopulatePassRates(clsSchoolDashboardStats stats)
        {
            _SetPassRate(pbVision, lblVisionPct, stats.PassRateVision);
            _SetPassRate(pbTheory, lblTheoryPct, stats.PassRateTheory);
            _SetPassRate(pbRoad,   lblRoadPct,   stats.PassRateRoad);
        }

        private void _SetPassRate(ProgressBar pb, Label lbl, int rate)
        {
            if (rate < 0)
            {
                // No data this month
                pb.Value  = 0;
                lbl.Text  = "—";
                lbl.ForeColor = Color.FromArgb(150, 150, 170);
            }
            else
            {
                pb.Value  = Math.Min(rate, 100);
                lbl.Text  = $"{rate}%";
                lbl.ForeColor = Color.FromArgb(30, 30, 50);
            }
        }

        // ─── Recent Students Grid ────────────────────────────────────────────
        private void _LoadRecentStudents(int instituteID)
        {
            DataTable dt = clsEnrollment.GetAllByInstitute(instituteID);

            // Take top 8 rows — no LINQ dependency needed
            DataTable top8 = dt.Clone();
            int max = Math.Min(8, dt.Rows.Count);
            for (int i = 0; i < max; i++)
                top8.ImportRow(dt.Rows[i]);

            dgvRecentStudents.DataSource = top8;

            // Hide internal ID columns
            _HideColumn("EnrollmentID");
            _HideColumn("PersonID");

            // Rename visible columns
            _RenameColumn("FullName",       "Student Name");
            _RenameColumn("Phone",          "Phone");
            _RenameColumn("CourseName",     "Course");
            _RenameColumn("EnrollmentDate", "Enrolled On");
            _RenameColumn("IsActive",       "Active");
        }

        private void _HideColumn(string name)
        {
            if (dgvRecentStudents.Columns[name] != null)
                dgvRecentStudents.Columns[name].Visible = false;
        }

        private void _RenameColumn(string name, string header)
        {
            if (dgvRecentStudents.Columns[name] != null)
                dgvRecentStudents.Columns[name].HeaderText = header;
        }

        // ─── Shared KPI card drop-shadow paint ──────────────────────────────
        private void KpiCard_Paint(object sender, PaintEventArgs e)
        {
            Panel p = (Panel)sender;
            using (Pen pen = new Pen(Color.FromArgb(230, 230, 238), 1))
            {
                e.Graphics.DrawRectangle(pen,
                    0, 0,
                    p.Width - 1, p.Height - 1);
            }
        }
    }
}
