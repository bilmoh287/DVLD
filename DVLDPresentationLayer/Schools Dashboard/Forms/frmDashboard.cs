using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DVLDBussinessLayer;
using DVLDPresentationLayer.Global_Classes;

namespace DVLDPresentationLayer.Schools_Dashboard.Forms
{
    public partial class frmDashboard : Form
    {
        private clsSchoolDashboardStats _stats;

        public frmDashboard()
        {
            InitializeComponent();
            // Enable double buffering for the chart canvas to prevent flicker
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            _LoadDashboard();
        }

        private void _LoadDashboard()
        {
            if (clsGlobal.CurrentInstituteID == null) return;
            int id = clsGlobal.CurrentInstituteID.Value;

            _stats = clsSchoolDashboardStats.Load(id);

            _PopulateKpiCards();
            _PopulatePassRates();
            _LoadRecentStudents(id);
            
            panelChartCanvas.Invalidate(); // Trigger chart redraw
        }

        private void _PopulateKpiCards()
        {
            lblTotalStudents.Text = _stats.TotalStudents.ToString();
            lblTotalCourses.Text  = _stats.ActiveCourses.ToString();
            lblTestsToday.Text    = _stats.TestsToday.ToString();
            lblTotalEarnings.Text = _stats.TotalEarnings.ToString("C0"); // Format as currency
        }

        private void _PopulatePassRates()
        {
            _SetPassRate(pbVision, lblVisionPct, _stats.PassRateVision);
            _SetPassRate(pbTheory, lblTheoryPct, _stats.PassRateTheory);
            _SetPassRate(pbRoad,   lblRoadPct,   _stats.PassRateRoad);
        }

        private void _SetPassRate(ProgressBar pb, Label lbl, int rate)
        {
            if (rate < 0) { pb.Value = 0; lbl.Text = "—"; }
            else { pb.Value = Math.Min(rate, 100); lbl.Text = $"{rate}%"; }
        }

        private void _LoadRecentStudents(int instituteID)
        {
            DataTable dt = clsEnrollment.GetAllByInstitute(instituteID);
            DataTable top8 = dt.Clone();
            int max = Math.Min(8, dt.Rows.Count);
            for (int i = 0; i < max; i++) top8.ImportRow(dt.Rows[i]);

            dgvRecentStudents.DataSource = top8;
            if (dgvRecentStudents.Columns["EnrollmentID"] != null) dgvRecentStudents.Columns["EnrollmentID"].Visible = false;
            if (dgvRecentStudents.Columns["PersonID"] != null) dgvRecentStudents.Columns["PersonID"].Visible = false;
        }

        // ── CUSTOM CHART DRAWING ───────────────────────────────────────────
        private void panelChartCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (_stats == null || _stats.MonthlyEnrollmentStats == null || _stats.MonthlyEnrollmentStats.Rows.Count == 0)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            DataTable dt = _stats.MonthlyEnrollmentStats;
            int count = dt.Rows.Count;
            
            float width = panelChartCanvas.Width;
            float height = panelChartCanvas.Height - 30; // Leave space for labels
            float margin = 40;

            // Find Max for scaling
            int maxVal = 5; // Start with 5 as min ceiling
            foreach (DataRow row in dt.Rows)
                maxVal = Math.Max(maxVal, Convert.ToInt32(row["Count"]));
            maxVal = (int)(maxVal * 1.2); // Add 20% head room

            // Calculate points
            PointF[] points = new PointF[count];
            float stepX = (width - (margin * 2)) / (count > 1 ? count - 1 : 1);

            for (int i = 0; i < count; i++)
            {
                int val = Convert.ToInt32(dt.Rows[i]["Count"]);
                float x = margin + (i * stepX);
                float y = height - (val * (height / maxVal));
                points[i] = new PointF(x, y);

                // Draw X-Axis Label (Month)
                string month = dt.Rows[i]["MonthName"].ToString();
                g.DrawString(month, new Font("Segoe UI", 9), Brushes.Gray, x - 15, height + 10);
            }

            // Draw Area Gradient
            if (count > 1)
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddLines(points);
                    path.AddLine(points[count - 1].X, height, points[0].X, height);
                    path.CloseFigure();
                    using (LinearGradientBrush lgb = new LinearGradientBrush(new PointF(0, 0), new PointF(0, height), 
                        Color.FromArgb(100, 67, 160, 71), Color.Transparent))
                    {
                        g.FillPath(lgb, path);
                    }
                }

                // Draw Smooth Line
                using (Pen pen = new Pen(Color.FromArgb(67, 160, 71), 3))
                {
                    pen.LineJoin = LineJoin.Round;
                    g.DrawLines(pen, points);
                }
            }

            // Draw data points
            foreach (var p in points)
            {
                g.FillEllipse(Brushes.White, p.X - 5, p.Y - 5, 10, 10);
                g.DrawEllipse(new Pen(Color.FromArgb(67, 160, 71), 2), p.X - 5, p.Y - 5, 10, 10);
            }
        }

        private void frmDashboard_Resize(object sender, EventArgs e)
        {
            panelChartCanvas.Invalidate();
        }

        private void Panel_BorderPaint(object sender, PaintEventArgs e)
        {
            Control p = (Control)sender;
            using (Pen pen = new Pen(Color.FromArgb(235, 235, 245), 1))
                e.Graphics.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
        }
    }
}
