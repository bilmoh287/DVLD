namespace DVLDPresentationLayer.Schools_Dashboard.Forms
{
    partial class frmDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.flowKpiCards        = new System.Windows.Forms.FlowLayoutPanel();
            
            // KPI Cards (will be added to flow)
            this.panelStudents       = new System.Windows.Forms.Panel();
            this.lblTotalStudents    = new System.Windows.Forms.Label();
            this.lblStudentsTitle    = new System.Windows.Forms.Label();
            
            this.panelCourses        = new System.Windows.Forms.Panel();
            this.lblTotalCourses     = new System.Windows.Forms.Label();
            this.lblCoursesTitle     = new System.Windows.Forms.Label();
            
            this.panelEarnings       = new System.Windows.Forms.Panel();
            this.lblTotalEarnings    = new System.Windows.Forms.Label();
            this.lblEarningsTitle    = new System.Windows.Forms.Label();
            
            this.panelTests          = new System.Windows.Forms.Panel();
            this.lblTestsToday       = new System.Windows.Forms.Label();
            this.lblTestsTitle       = new System.Windows.Forms.Label();

            // Analytics Section
            this.panelChartContainer = new System.Windows.Forms.Panel();
            this.lblChartTitle       = new System.Windows.Forms.Label();
            this.panelChartCanvas    = new System.Windows.Forms.Panel(); // Custom paint happens here

            // Bottom Section (Grid + Pass Rates)
            this.panelBottomRow      = new System.Windows.Forms.TableLayoutPanel();
            this.panelRecentStudents = new System.Windows.Forms.Panel();
            this.dgvRecentStudents   = new System.Windows.Forms.DataGridView();
            this.lblRecentTitle      = new System.Windows.Forms.Label();
            
            this.panelPassRates      = new System.Windows.Forms.Panel();
            this.lblPassRatesTitle   = new System.Windows.Forms.Label();
            this.pbVision            = new System.Windows.Forms.ProgressBar();
            this.pbTheory            = new System.Windows.Forms.ProgressBar();
            this.pbRoad              = new System.Windows.Forms.ProgressBar();
            this.lblVisionPct        = new System.Windows.Forms.Label();
            this.lblTheoryPct        = new System.Windows.Forms.Label();
            this.lblRoadPct          = new System.Windows.Forms.Label();

            this.flowKpiCards.SuspendLayout();
            this.panelChartContainer.SuspendLayout();
            this.panelBottomRow.SuspendLayout();
            this.panelRecentStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentStudents)).BeginInit();
            this.panelPassRates.SuspendLayout();
            this.SuspendLayout();

            // ── FLOW LAYOUT FOR KPI CARDS ───────────────────────────────────
            this.flowKpiCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowKpiCards.Location = new System.Drawing.Point(20, 20);
            this.flowKpiCards.Name = "flowKpiCards";
            this.flowKpiCards.Size = new System.Drawing.Size(1000, 140);
            this.flowKpiCards.TabIndex = 0;
            this.flowKpiCards.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);

            // Setup helper for styles
            _SetupCard(this.panelStudents, this.lblStudentsTitle, this.lblTotalStudents, "STUDENTS", "0", System.Drawing.Color.FromArgb(67, 160, 71));
            _SetupCard(this.panelCourses,  this.lblCoursesTitle,  this.lblTotalCourses,  "COURSES",  "0", System.Drawing.Color.FromArgb(30, 136, 229));
            _SetupCard(this.panelEarnings, this.lblEarningsTitle, this.lblTotalEarnings, "EARNINGS", "$0", System.Drawing.Color.FromArgb(251, 140, 0));
            _SetupCard(this.panelTests,    this.lblTestsTitle,    this.lblTestsToday,    "TESTS TODAY", "0", System.Drawing.Color.FromArgb(0, 150, 136));

            this.flowKpiCards.Controls.Add(this.panelStudents);
            this.flowKpiCards.Controls.Add(this.panelCourses);
            this.flowKpiCards.Controls.Add(this.panelEarnings);
            this.flowKpiCards.Controls.Add(this.panelTests);

            // ── ANALYTICS CHART CONTAINER ──────────────────────────────────
            this.panelChartContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChartContainer.BackColor = System.Drawing.Color.White;
            this.panelChartContainer.Location = new System.Drawing.Point(20, 160);
            this.panelChartContainer.Name = "panelChartContainer";
            this.panelChartContainer.Size = new System.Drawing.Size(960, 280);
            this.panelChartContainer.TabIndex = 1;
            this.panelChartContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_BorderPaint);

            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 50);
            this.lblChartTitle.Location = new System.Drawing.Point(20, 15);
            this.lblChartTitle.Text = "Student Enrollment (Last 3 Months)";

            this.panelChartCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChartCanvas.Location = new System.Drawing.Point(20, 50);
            this.panelChartCanvas.Name = "panelChartCanvas";
            this.panelChartCanvas.Size = new System.Drawing.Size(920, 210);
            this.panelChartCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.panelChartCanvas_Paint);

            this.panelChartContainer.Controls.Add(this.lblChartTitle);
            this.panelChartContainer.Controls.Add(this.panelChartCanvas);

            // ── BOTTOM ROW (GRID + PASS RATES) ─────────────────────────────
            this.panelBottomRow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBottomRow.ColumnCount = 2;
            this.panelBottomRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.panelBottomRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.panelBottomRow.Location = new System.Drawing.Point(20, 450);
            this.panelBottomRow.Name = "panelBottomRow";
            this.panelBottomRow.RowCount = 1;
            this.panelBottomRow.Size = new System.Drawing.Size(960, 300);
            this.panelBottomRow.TabIndex = 2;

            // Recent Students Panel
            this.panelRecentStudents.BackColor = System.Drawing.Color.White;
            this.panelRecentStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecentStudents.Padding = new System.Windows.Forms.Padding(10);
            this.panelRecentStudents.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_BorderPaint);
            
            this.lblRecentTitle.AutoSize = true;
            this.lblRecentTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRecentTitle.Location = new System.Drawing.Point(14, 10);
            this.lblRecentTitle.Text = "Recent Enrollments";

            this.dgvRecentStudents.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvRecentStudents.Height = 230;
            this.dgvRecentStudents.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentStudents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentStudents.RowHeadersVisible = false;

            this.panelRecentStudents.Controls.Add(this.lblRecentTitle);
            this.panelRecentStudents.Controls.Add(this.dgvRecentStudents);

            // Pass Rates Panel
            this.panelPassRates.BackColor = System.Drawing.Color.White;
            this.panelPassRates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPassRates.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panelPassRates.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_BorderPaint);

            this.lblPassRatesTitle.AutoSize = true;
            this.lblPassRatesTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPassRatesTitle.Location = new System.Drawing.Point(14, 10);
            this.lblPassRatesTitle.Text = "Pass Rates";

            // Visual setup for pass rate bars happens in code
            this._SetupPassRate(this.pbVision, this.lblVisionPct, "Vision Test", 50);
            this._SetupPassRate(this.pbTheory, this.lblTheoryPct, "Theory Test", 100);
            this._SetupPassRate(this.pbRoad,   this.lblRoadPct,   "Road Test",   150);

            this.panelPassRates.Controls.Add(this.lblPassRatesTitle);

            this.panelBottomRow.Controls.Add(this.panelRecentStudents, 0, 0);
            this.panelBottomRow.Controls.Add(this.panelPassRates, 1, 0);

            // ── FORM SETTINGS ───────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 253);
            this.ClientSize = new System.Drawing.Size(1000, 770);
            this.Controls.Add(this.panelBottomRow);
            this.Controls.Add(this.panelChartContainer);
            this.Controls.Add(this.flowKpiCards);
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Name = "frmDashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.Resize += new System.EventHandler(this.frmDashboard_Resize);

            this.flowKpiCards.ResumeLayout(false);
            this.panelChartContainer.ResumeLayout(false);
            this.panelChartContainer.PerformLayout();
            this.panelBottomRow.ResumeLayout(false);
            this.panelRecentStudents.ResumeLayout(false);
            this.panelRecentStudents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentStudents)).EndInit();
            this.panelPassRates.ResumeLayout(false);
            this.panelPassRates.PerformLayout();
            this.ResumeLayout(false);
        }

        private void _SetupCard(System.Windows.Forms.Panel p, System.Windows.Forms.Label title, System.Windows.Forms.Label val, string tStr, string vStr, System.Drawing.Color color)
        {
            p.Size = new System.Drawing.Size(220, 110);
            p.BackColor = System.Drawing.Color.White;
            p.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            p.Padding = new System.Windows.Forms.Padding(15);
            
            // Top Accent
            System.Windows.Forms.Panel accent = new System.Windows.Forms.Panel();
            accent.Dock = System.Windows.Forms.DockStyle.Top;
            accent.Height = 4;
            accent.BackColor = color;
            p.Controls.Add(accent);

            title.AutoSize = true;
            title.Font = new System.Drawing.Font("Segoe UI Semibold", 8F);
            title.ForeColor = System.Drawing.Color.FromArgb(140, 140, 160);
            title.Location = new System.Drawing.Point(15, 18);
            title.Text = tStr;
            p.Controls.Add(title);

            val.AutoSize = true;
            val.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            val.ForeColor = System.Drawing.Color.FromArgb(40, 40, 60);
            val.Location = new System.Drawing.Point(12, 38);
            val.Text = vStr;
            p.Controls.Add(val);

            p.Paint += (s, e) => {
                using (System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(230, 230, 240), 1))
                    e.Graphics.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
            };
        }

        private void _SetupPassRate(System.Windows.Forms.ProgressBar pb, System.Windows.Forms.Label pct, string name, int y)
        {
            System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
            lbl.Text = name;
            lbl.Font = new System.Drawing.Font("Segoe UI", 9F);
            lbl.Location = new System.Drawing.Point(15, y);
            lbl.AutoSize = true;
            this.panelPassRates.Controls.Add(lbl);

            pct.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            pct.Location = new System.Drawing.Point(210, y);
            pct.AutoSize = true;
            this.panelPassRates.Controls.Add(pct);

            pb.Location = new System.Drawing.Point(15, y + 20);
            pb.Size = new System.Drawing.Size(230, 6);
            pb.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.panelPassRates.Controls.Add(pb);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowKpiCards;
        private System.Windows.Forms.Panel panelStudents;
        private System.Windows.Forms.Label lblTotalStudents;
        private System.Windows.Forms.Label lblStudentsTitle;
        private System.Windows.Forms.Panel panelCourses;
        private System.Windows.Forms.Label lblTotalCourses;
        private System.Windows.Forms.Label lblCoursesTitle;
        private System.Windows.Forms.Panel panelEarnings;
        private System.Windows.Forms.Label lblTotalEarnings;
        private System.Windows.Forms.Label lblEarningsTitle;
        private System.Windows.Forms.Panel panelTests;
        private System.Windows.Forms.Label lblTestsToday;
        private System.Windows.Forms.Label lblTestsTitle;

        private System.Windows.Forms.Panel panelChartContainer;
        private System.Windows.Forms.Label lblChartTitle;
        private System.Windows.Forms.Panel panelChartCanvas;

        private System.Windows.Forms.TableLayoutPanel panelBottomRow;
        private System.Windows.Forms.Panel panelRecentStudents;
        private System.Windows.Forms.DataGridView dgvRecentStudents;
        private System.Windows.Forms.Label lblRecentTitle;
        
        private System.Windows.Forms.Panel panelPassRates;
        private System.Windows.Forms.Label lblPassRatesTitle;
        private System.Windows.Forms.ProgressBar pbVision;
        private System.Windows.Forms.ProgressBar pbTheory;
        private System.Windows.Forms.ProgressBar pbRoad;
        private System.Windows.Forms.Label lblVisionPct;
        private System.Windows.Forms.Label lblTheoryPct;
        private System.Windows.Forms.Label lblRoadPct;
    }
}