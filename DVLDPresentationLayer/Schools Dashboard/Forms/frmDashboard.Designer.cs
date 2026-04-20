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
            this.tableLayoutPanelCards = new System.Windows.Forms.TableLayoutPanel();
            
            // KPI Cards (will be added to table)
            this.panelStudents       = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalStudents    = new System.Windows.Forms.Label();
            this.lblStudentsTitle    = new System.Windows.Forms.Label();
            this.lblNewStudents      = new System.Windows.Forms.Label();
            
            this.panelCourses        = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalCourses     = new System.Windows.Forms.Label();
            this.lblCoursesTitle     = new System.Windows.Forms.Label();
            this.lblNewCourses       = new System.Windows.Forms.Label();
            
            this.panelEarnings       = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalEarnings    = new System.Windows.Forms.Label();
            this.lblEarningsTitle    = new System.Windows.Forms.Label();
            this.lblEarningsSub      = new System.Windows.Forms.Label();
            
            this.panelTests          = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTestsToday       = new System.Windows.Forms.Label();
            this.lblTestsTitle       = new System.Windows.Forms.Label();
            this.lblTestsSub         = new System.Windows.Forms.Label();

            // Analytics Section
            this.panelChartContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChartTitle       = new System.Windows.Forms.Label();
            this.lblChartSubtitle    = new System.Windows.Forms.Label();
            this.panelChartCanvas    = new System.Windows.Forms.Panel(); 

            // Bottom Section (Grid + Upcoming)
            this.panelBottomRow      = new System.Windows.Forms.TableLayoutPanel();
            this.panelRecent         = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvRecentStudents   = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblRecentTitle      = new System.Windows.Forms.Label();
            
            this.panelUpcoming       = new Guna.UI2.WinForms.Guna2Panel();
            this.lblUpcomingTitle    = new System.Windows.Forms.Label();
            
            // Pass Rate Controls (repurposed for layout compatibility)
            this.pbVision            = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.pbTheory            = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.pbRoad              = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.lblVisionPct        = new System.Windows.Forms.Label();
            this.lblTheoryPct        = new System.Windows.Forms.Label();
            this.lblRoadPct          = new System.Windows.Forms.Label();

            this.tableLayoutPanelCards.SuspendLayout();
            this.panelChartContainer.SuspendLayout();
            this.panelBottomRow.SuspendLayout();
            this.panelRecent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentStudents)).BeginInit();
            this.panelUpcoming.SuspendLayout();
            this.SuspendLayout();

            // ── TABLE LAYOUT FOR 4 KPI CARDS (Responsive & Maximized) ───────
            this.tableLayoutPanelCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelCards.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanelCards.Name = "tableLayoutPanelCards";
            this.tableLayoutPanelCards.Size = new System.Drawing.Size(1200, 160);
            this.tableLayoutPanelCards.TabIndex = 0;
            this.tableLayoutPanelCards.ColumnCount = 4;
            this.tableLayoutPanelCards.RowCount = 1;
            this.tableLayoutPanelCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCards.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);

            // Setup Helper for Guna2 Cards
            _SetupGunaCard(this.panelStudents, this.lblStudentsTitle, this.lblTotalStudents, this.lblNewStudents, "TOTAL STUDENTS", "0", "+0 this month", System.Drawing.Color.FromArgb(64, 186, 119));
            _SetupGunaCard(this.panelCourses,  this.lblCoursesTitle,  this.lblTotalCourses,  this.lblNewCourses,  "ACTIVE COURSES", "0", "+0 new", System.Drawing.Color.FromArgb(94, 148, 255));
            _SetupGunaCard(this.panelEarnings, this.lblEarningsTitle, this.lblTotalEarnings, this.lblEarningsSub, "TOTAL EARNINGS", "$0", "From all enrollments", System.Drawing.Color.FromArgb(255, 167, 38));
            _SetupGunaCard(this.panelTests,    this.lblTestsTitle,    this.lblTestsToday,    this.lblTestsSub,    "TESTS TODAY", "0", "Scheduled", System.Drawing.Color.FromArgb(76, 175, 80));

            this.tableLayoutPanelCards.Controls.Add(this.panelStudents, 0, 0);
            this.tableLayoutPanelCards.Controls.Add(this.panelCourses, 1, 0);
            this.tableLayoutPanelCards.Controls.Add(this.panelEarnings, 2, 0);
            this.tableLayoutPanelCards.Controls.Add(this.panelTests, 3, 0);

            // ── ANALYTICS CHART CONTAINER ──────────────────────────────────
            this.panelChartContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChartContainer.BackColor = System.Drawing.Color.Transparent;
            this.panelChartContainer.BorderRadius = 15;
            this.panelChartContainer.FillColor = System.Drawing.Color.White;
            this.panelChartContainer.Location = new System.Drawing.Point(20, 190);
            this.panelChartContainer.Name = "panelChartContainer";
            this.panelChartContainer.Size = new System.Drawing.Size(1200, 320);
            this.panelChartContainer.TabIndex = 1;
            this.panelChartContainer.ShadowDecoration.Enabled = true;
            this.panelChartContainer.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3, 3, 5, 5);
            this.panelChartContainer.ShadowDecoration.Color = System.Drawing.Color.FromArgb(30, 0, 0, 0);

            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 50);
            this.lblChartTitle.Location = new System.Drawing.Point(25, 20);
            this.lblChartTitle.Text = "Student enrollment";

            this.lblChartSubtitle.AutoSize = true;
            this.lblChartSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblChartSubtitle.ForeColor = System.Drawing.Color.FromArgb(140, 140, 160);
            this.lblChartSubtitle.Location = new System.Drawing.Point(26, 52);
            this.lblChartSubtitle.Text = "New students per month — last 3 months";

            this.panelChartCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChartCanvas.Location = new System.Drawing.Point(20, 85);
            this.panelChartCanvas.Name = "panelChartCanvas";
            this.panelChartCanvas.Size = new System.Drawing.Size(1160, 220);
            this.panelChartCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.panelChartCanvas_Paint);

            this.panelChartContainer.Controls.Add(this.lblChartTitle);
            this.panelChartContainer.Controls.Add(this.lblChartSubtitle);
            this.panelChartContainer.Controls.Add(this.panelChartCanvas);

            // ── BOTTOM ROW (GRID + PASS RATES) ─────────────────────────────
            this.panelBottomRow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBottomRow.ColumnCount = 2;
            this.panelBottomRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.panelBottomRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.panelBottomRow.Location = new System.Drawing.Point(20, 530);
            this.panelBottomRow.Name = "panelBottomRow";
            this.panelBottomRow.RowCount = 1;
            this.panelBottomRow.Size = new System.Drawing.Size(1200, 330);
            this.panelBottomRow.TabIndex = 2;

            // Recent Students Panel
            this.panelRecent.BackColor = System.Drawing.Color.Transparent;
            this.panelRecent.BorderRadius = 15;
            this.panelRecent.FillColor = System.Drawing.Color.White;
            this.panelRecent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecent.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.panelRecent.Padding = new System.Windows.Forms.Padding(15);
            this.panelRecent.ShadowDecoration.Enabled = true;
            this.panelRecent.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3, 3, 5, 5);
            
            this.lblRecentTitle.AutoSize = true;
            this.lblRecentTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRecentTitle.Location = new System.Drawing.Point(15, 15);
            this.lblRecentTitle.Text = "Recent Enrollments";

            this.dgvRecentStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRecentStudents.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentStudents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentStudents.RowHeadersVisible = false;
            this.dgvRecentStudents.Location = new System.Drawing.Point(15, 50);
            this.dgvRecentStudents.Size = new System.Drawing.Size(730, 260);

            // Modern Grid Style
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            headerStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            headerStyle.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            headerStyle.SelectionBackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.dgvRecentStudents.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvRecentStudents.ColumnHeadersHeight = 40;
            this.dgvRecentStudents.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(245, 246, 250);
            this.dgvRecentStudents.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            
            this.panelRecent.Controls.Add(this.lblRecentTitle);
            this.panelRecent.Controls.Add(this.dgvRecentStudents);

            // Pass Rates Panel
            this.panelUpcoming.BackColor = System.Drawing.Color.Transparent;
            this.panelUpcoming.BorderRadius = 15;
            this.panelUpcoming.FillColor = System.Drawing.Color.White;
            this.panelUpcoming.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUpcoming.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.panelUpcoming.ShadowDecoration.Enabled = true;

            this.lblUpcomingTitle.AutoSize = true;
            this.lblUpcomingTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblUpcomingTitle.Location = new System.Drawing.Point(20, 15);
            this.lblUpcomingTitle.Text = "Pass Rates (This Month)";

            // Setup pass rates visually
            this._SetupGunaPassRate(this.pbVision, this.lblVisionPct, "Vision Test", 60);
            this._SetupGunaPassRate(this.pbTheory, this.lblTheoryPct, "Theory Test", 130);
            this._SetupGunaPassRate(this.pbRoad,   this.lblRoadPct,   "Road Test",   200);

            this.panelUpcoming.Controls.Add(this.lblUpcomingTitle);
            this.panelBottomRow.Controls.Add(this.panelRecent, 0, 0);
            this.panelBottomRow.Controls.Add(this.panelUpcoming, 1, 0);

            // ── FORM SETTINGS ───────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 253);
            this.ClientSize = new System.Drawing.Size(1240, 890); // Default larger size
            this.Controls.Add(this.panelBottomRow);
            this.Controls.Add(this.panelChartContainer);
            this.Controls.Add(this.tableLayoutPanelCards);
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Name = "frmDashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.Resize += new System.EventHandler(this.frmDashboard_Resize);

            this.tableLayoutPanelCards.ResumeLayout(false);
            this.panelChartContainer.ResumeLayout(false);
            this.panelChartContainer.PerformLayout();
            this.panelBottomRow.ResumeLayout(false);
            this.panelRecent.ResumeLayout(false);
            this.panelRecent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentStudents)).EndInit();
            this.panelUpcoming.ResumeLayout(false);
            this.panelUpcoming.PerformLayout();
            this.ResumeLayout(false);
        }

        private void _SetupGunaCard(Guna.UI2.WinForms.Guna2Panel p, System.Windows.Forms.Label title, System.Windows.Forms.Label val, System.Windows.Forms.Label sub, string tStr, string vStr, string subStr, System.Drawing.Color color)
        {
            p.Dock = System.Windows.Forms.DockStyle.Fill;
            p.BackColor = System.Drawing.Color.Transparent;
            p.FillColor = System.Drawing.Color.White;
            p.BorderRadius = 15;
            p.Margin = new System.Windows.Forms.Padding(5, 5, 15, 5); // spacing
            p.ShadowDecoration.Enabled = true;
            p.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 2, 5, 5);
            p.ShadowDecoration.Color = System.Drawing.Color.FromArgb(20, 0, 0, 0);

            title.AutoSize = true;
            title.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            title.ForeColor = System.Drawing.Color.FromArgb(140, 140, 160);
            title.Location = new System.Drawing.Point(20, 20);
            title.Text = tStr;
            p.Controls.Add(title);

            val.AutoSize = true;
            val.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold); // HUGE font
            val.ForeColor = System.Drawing.Color.FromArgb(40, 40, 50);
            val.Location = new System.Drawing.Point(15, 45);
            val.Text = vStr;
            p.Controls.Add(val);

            sub.AutoSize = true;
            sub.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            sub.ForeColor = color; // Uses the accent color (e.g. green)
            sub.Location = new System.Drawing.Point(20, 115);
            sub.Text = subStr;
            p.Controls.Add(sub);
        }

        private void _SetupGunaPassRate(Guna.UI2.WinForms.Guna2ProgressBar pb, System.Windows.Forms.Label pct, string name, int y)
        {
            System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
            lbl.Text = name;
            lbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lbl.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            lbl.Location = new System.Drawing.Point(25, y);
            lbl.AutoSize = true;
            this.panelUpcoming.Controls.Add(lbl);

            pct.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            pct.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            pct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            pct.Location = new System.Drawing.Point(340, y);
            pct.AutoSize = true;
            this.panelUpcoming.Controls.Add(pct);

            pb.Location = new System.Drawing.Point(25, y + 30);
            pb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            pb.Size = new System.Drawing.Size(360, 8);
            pb.BorderRadius = 4;
            pb.ProgressColor = System.Drawing.Color.FromArgb(94, 148, 255);
            pb.ProgressColor2 = System.Drawing.Color.FromArgb(94, 148, 255);
            pb.FillColor = System.Drawing.Color.FromArgb(235, 235, 245);
            this.panelUpcoming.Controls.Add(pb);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCards;
        private Guna.UI2.WinForms.Guna2Panel panelStudents;
        private System.Windows.Forms.Label lblTotalStudents;
        private System.Windows.Forms.Label lblStudentsTitle;
        private System.Windows.Forms.Label lblNewStudents;
        private Guna.UI2.WinForms.Guna2Panel panelCourses;
        private System.Windows.Forms.Label lblTotalCourses;
        private System.Windows.Forms.Label lblCoursesTitle;
        private System.Windows.Forms.Label lblNewCourses;
        private Guna.UI2.WinForms.Guna2Panel panelEarnings;
        private System.Windows.Forms.Label lblTotalEarnings;
        private System.Windows.Forms.Label lblEarningsTitle;
        private System.Windows.Forms.Label lblEarningsSub;
        private Guna.UI2.WinForms.Guna2Panel panelTests;
        private System.Windows.Forms.Label lblTestsToday;
        private System.Windows.Forms.Label lblTestsTitle;
        private System.Windows.Forms.Label lblTestsSub;

        private Guna.UI2.WinForms.Guna2Panel panelChartContainer;
        private System.Windows.Forms.Label lblChartTitle;
        private System.Windows.Forms.Label lblChartSubtitle;
        private System.Windows.Forms.Panel panelChartCanvas;

        private System.Windows.Forms.TableLayoutPanel panelBottomRow;
        private Guna.UI2.WinForms.Guna2Panel panelRecent;
        private Guna.UI2.WinForms.Guna2DataGridView dgvRecentStudents;
        private System.Windows.Forms.Label lblRecentTitle;
        
        private Guna.UI2.WinForms.Guna2Panel panelUpcoming;
        private System.Windows.Forms.Label lblUpcomingTitle;
        private Guna.UI2.WinForms.Guna2ProgressBar pbVision;
        private Guna.UI2.WinForms.Guna2ProgressBar pbTheory;
        private Guna.UI2.WinForms.Guna2ProgressBar pbRoad;
        private System.Windows.Forms.Label lblVisionPct;
        private System.Windows.Forms.Label lblTheoryPct;
        private System.Windows.Forms.Label lblRoadPct;
    }
}