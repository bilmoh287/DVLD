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
            lblNewStudents.Text   = $"+{_stats.NewStudentsThisMonth} this month";

            lblTotalCourses.Text  = _stats.ActiveCourses.ToString();
            lblNewCourses.Text    = "+0 new"; // Feature not in DB yet

            lblTestsToday.Text    = _stats.TestsToday.ToString();
            lblTestsSub.Text      = "Scheduled for today";

            lblTotalEarnings.Text = _stats.TotalEarnings.ToString("C0"); 
            lblEarningsSub.Text   = "From all enrollments";
        }

        private void _PopulatePassRates()
        {
            _SetPassRate(pbVision, lblVisionPct, _stats.PassRateVision);
            _SetPassRate(pbTheory, lblTheoryPct, _stats.PassRateTheory);
            _SetPassRate(pbRoad,   lblRoadPct,   _stats.PassRateRoad);
        }

        private void _SetPassRate(Guna.UI2.WinForms.Guna2ProgressBar pb, Label lbl, int rate)
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

        // ── CUSTOM CHART DRAWING (Modern Blue Curve) ───────────────────────
        private void panelChartCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (_stats == null || _stats.MonthlyEnrollmentStats == null || _stats.MonthlyEnrollmentStats.Rows.Count == 0)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            DataTable dt = _stats.MonthlyEnrollmentStats;
            int count = dt.Rows.Count;
            
            float width = panelChartCanvas.Width;
            float height = panelChartCanvas.Height - 40; // Leave space for labels at the bottom
            float marginX = 50;

            // Find Max for scaling
            int maxVal = 5; 
            foreach (DataRow row in dt.Rows)
                maxVal = Math.Max(maxVal, Convert.ToInt32(row["Count"]));
            maxVal = (int)(maxVal * 1.5); // Add head room

            // Calculate points
            PointF[] points = new PointF[count];
            float stepX = (width - (marginX * 2)) / (count > 1 ? count - 1 : 1);

            // Draw Y-Axis labels (optional but clean)
            g.DrawString(maxVal.ToString(), new Font("Segoe UI", 9), new SolidBrush(Color.FromArgb(150,150,170)), 5, 0);
            g.DrawString((maxVal/2).ToString(), new Font("Segoe UI", 9), new SolidBrush(Color.FromArgb(150,150,170)), 5, height/2);
            g.DrawString("0", new Font("Segoe UI", 9), new SolidBrush(Color.FromArgb(150,150,170)), 5, height - 15);

            for (int i = 0; i < count; i++)
            {
                int val = Convert.ToInt32(dt.Rows[i]["Count"]);
                float x = marginX + (i * stepX);
                float y = height - (val * (height / maxVal));
                
                // Keep y within bounds just in case
                y = Math.Max(0, y);
                points[i] = new PointF(x, y);

                // Draw X-Axis Label (Month)
                string month = dt.Rows[i]["MonthName"].ToString();
                g.DrawString(month, new Font("Segoe UI", 10), new SolidBrush(Color.FromArgb(100,100,120)), x - 10, height + 10);
                
                // Draw vertical grid line
                using (Pen gridPen = new Pen(Color.FromArgb(240, 240, 245), 1)) {
                    g.DrawLine(gridPen, x, 0, x, height);
                }
            }

            // Draw Area Gradient and Curve
            Color curveColor = Color.FromArgb(54, 114, 255); // The exact blue from the design
            
            if (count > 1)
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    // Tension=0.4 makes the curve smooth and natural
                    path.AddCurve(points, 0.4f);
                    
                    // Create path for filling
                    using (GraphicsPath fillPath = (GraphicsPath)path.Clone())
                    {
                        fillPath.AddLine(points[count - 1].X, height, points[0].X, height);
                        fillPath.CloseFigure();
                        
                        using (LinearGradientBrush lgb = new LinearGradientBrush(new PointF(0, 0), new PointF(0, height), 
                            Color.FromArgb(80, curveColor), Color.FromArgb(5, curveColor)))
                        {
                            g.FillPath(lgb, fillPath);
                        }
                    }

                    // Draw Smooth Line
                    using (Pen pen = new Pen(curveColor, 4))
                    {
                        pen.LineJoin = LineJoin.Round;
                        g.DrawPath(pen, path);
                    }
                }
            }

            // Draw data points (subtle white circles with blue borders)
            foreach (var p in points)
            {
                g.FillEllipse(Brushes.White, p.X - 5, p.Y - 5, 10, 10);
                g.DrawEllipse(new Pen(curveColor, 2), p.X - 5, p.Y - 5, 10, 10);
            }
        }

        private void frmDashboard_Resize(object sender, EventArgs e)
        {
            panelChartCanvas.Invalidate();
        }
    }
}
