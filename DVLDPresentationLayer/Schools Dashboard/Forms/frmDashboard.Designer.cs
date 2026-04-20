namespace DVLDPresentationLayer.Schools_Dashboard.Forms
{
    partial class frmDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // ── KPI Card 1: Total Students ───────────────────────────────────
            this.panelStudents       = new System.Windows.Forms.Panel();
            this.panelStudentsAccent = new System.Windows.Forms.Panel();
            this.lblStudentsTitle    = new System.Windows.Forms.Label();
            this.lblTotalStudents    = new System.Windows.Forms.Label();
            this.lblNewStudents      = new System.Windows.Forms.Label();

            // ── KPI Card 2: Active Courses ───────────────────────────────────
            this.panelCourses        = new System.Windows.Forms.Panel();
            this.panelCoursesAccent  = new System.Windows.Forms.Panel();
            this.lblCoursesTitle     = new System.Windows.Forms.Label();
            this.lblTotalCourses     = new System.Windows.Forms.Label();
            this.lblCoursesSubtitle  = new System.Windows.Forms.Label();

            // ── KPI Card 3: Instructors ──────────────────────────────────────
            this.panelInstructors       = new System.Windows.Forms.Panel();
            this.panelInstructorsAccent = new System.Windows.Forms.Panel();
            this.lblInstructorsTitle    = new System.Windows.Forms.Label();
            this.lblTotalInstructors    = new System.Windows.Forms.Label();
            this.lblInstructorsSubtitle = new System.Windows.Forms.Label();

            // ── KPI Card 4: Tests Today ──────────────────────────────────────
            this.panelTests       = new System.Windows.Forms.Panel();
            this.panelTestsAccent = new System.Windows.Forms.Panel();
            this.lblTestsTitle    = new System.Windows.Forms.Label();
            this.lblTestsToday    = new System.Windows.Forms.Label();
            this.lblTestsSubtitle = new System.Windows.Forms.Label();

            // ── Recent Students Panel (bottom-left) ──────────────────────────
            this.panelRecentStudents    = new System.Windows.Forms.Panel();
            this.lblRecentTitle         = new System.Windows.Forms.Label();
            this.lblRecentSubtitle      = new System.Windows.Forms.Label();
            this.dgvRecentStudents      = new System.Windows.Forms.DataGridView();

            // ── Pass Rates Panel (bottom-right) ──────────────────────────────
            this.panelPassRates         = new System.Windows.Forms.Panel();
            this.lblPassRatesTitle      = new System.Windows.Forms.Label();
            this.lblVisionLabel         = new System.Windows.Forms.Label();
            this.lblVisionPct           = new System.Windows.Forms.Label();
            this.pbVision               = new System.Windows.Forms.ProgressBar();
            this.lblTheoryLabel         = new System.Windows.Forms.Label();
            this.lblTheoryPct           = new System.Windows.Forms.Label();
            this.pbTheory               = new System.Windows.Forms.ProgressBar();
            this.lblRoadLabel           = new System.Windows.Forms.Label();
            this.lblRoadPct             = new System.Windows.Forms.Label();
            this.pbRoad                 = new System.Windows.Forms.ProgressBar();

            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentStudents)).BeginInit();
            this.panelStudents.SuspendLayout();
            this.panelCourses.SuspendLayout();
            this.panelInstructors.SuspendLayout();
            this.panelTests.SuspendLayout();
            this.panelRecentStudents.SuspendLayout();
            this.panelPassRates.SuspendLayout();
            this.SuspendLayout();

            // ═══════════════════════════════════════════════════════════════
            //  KPI CARD 1 — Total Students
            // ═══════════════════════════════════════════════════════════════
            this.panelStudents.BackColor  = System.Drawing.Color.White;
            this.panelStudents.Location   = new System.Drawing.Point(16, 16);
            this.panelStudents.Name       = "panelStudents";
            this.panelStudents.Size       = new System.Drawing.Size(224, 120);
            this.panelStudents.TabIndex   = 0;
            this.panelStudents.Paint     += new System.Windows.Forms.PaintEventHandler(this.KpiCard_Paint);
            this.panelStudents.Controls.Add(this.panelStudentsAccent);
            this.panelStudents.Controls.Add(this.lblStudentsTitle);
            this.panelStudents.Controls.Add(this.lblTotalStudents);
            this.panelStudents.Controls.Add(this.lblNewStudents);

            this.panelStudentsAccent.BackColor = System.Drawing.Color.FromArgb(67, 160, 71);
            this.panelStudentsAccent.Dock      = System.Windows.Forms.DockStyle.Top;
            this.panelStudentsAccent.Height    = 4;
            this.panelStudentsAccent.Name      = "panelStudentsAccent";
            this.panelStudentsAccent.TabIndex  = 10;

            this.lblStudentsTitle.AutoSize  = true;
            this.lblStudentsTitle.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular);
            this.lblStudentsTitle.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.lblStudentsTitle.Location  = new System.Drawing.Point(14, 18);
            this.lblStudentsTitle.Name      = "lblStudentsTitle";
            this.lblStudentsTitle.Text      = "TOTAL STUDENTS";

            this.lblTotalStudents.AutoSize  = true;
            this.lblTotalStudents.Font      = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTotalStudents.ForeColor = System.Drawing.Color.FromArgb(30, 30, 50);
            this.lblTotalStudents.Location  = new System.Drawing.Point(10, 36);
            this.lblTotalStudents.Name      = "lblTotalStudents";
            this.lblTotalStudents.Text      = "—";

            this.lblNewStudents.AutoSize  = true;
            this.lblNewStudents.Font      = new System.Drawing.Font("Segoe UI", 8F);
            this.lblNewStudents.ForeColor = System.Drawing.Color.FromArgb(67, 160, 71);
            this.lblNewStudents.Location  = new System.Drawing.Point(14, 94);
            this.lblNewStudents.Name      = "lblNewStudents";
            this.lblNewStudents.Text      = "+0 this month";

            // ═══════════════════════════════════════════════════════════════
            //  KPI CARD 2 — Active Courses
            // ═══════════════════════════════════════════════════════════════
            this.panelCourses.BackColor  = System.Drawing.Color.White;
            this.panelCourses.Location   = new System.Drawing.Point(256, 16);
            this.panelCourses.Name       = "panelCourses";
            this.panelCourses.Size       = new System.Drawing.Size(224, 120);
            this.panelCourses.TabIndex   = 1;
            this.panelCourses.Paint     += new System.Windows.Forms.PaintEventHandler(this.KpiCard_Paint);
            this.panelCourses.Controls.Add(this.panelCoursesAccent);
            this.panelCourses.Controls.Add(this.lblCoursesTitle);
            this.panelCourses.Controls.Add(this.lblTotalCourses);
            this.panelCourses.Controls.Add(this.lblCoursesSubtitle);

            this.panelCoursesAccent.BackColor = System.Drawing.Color.FromArgb(30, 136, 229);
            this.panelCoursesAccent.Dock      = System.Windows.Forms.DockStyle.Top;
            this.panelCoursesAccent.Height    = 4;
            this.panelCoursesAccent.Name      = "panelCoursesAccent";
            this.panelCoursesAccent.TabIndex  = 10;

            this.lblCoursesTitle.AutoSize  = true;
            this.lblCoursesTitle.Font      = new System.Drawing.Font("Segoe UI", 8F);
            this.lblCoursesTitle.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.lblCoursesTitle.Location  = new System.Drawing.Point(14, 18);
            this.lblCoursesTitle.Name      = "lblCoursesTitle";
            this.lblCoursesTitle.Text      = "ACTIVE COURSES";

            this.lblTotalCourses.AutoSize  = true;
            this.lblTotalCourses.Font      = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTotalCourses.ForeColor = System.Drawing.Color.FromArgb(30, 30, 50);
            this.lblTotalCourses.Location  = new System.Drawing.Point(10, 36);
            this.lblTotalCourses.Name      = "lblTotalCourses";
            this.lblTotalCourses.Text      = "—";

            this.lblCoursesSubtitle.AutoSize  = true;
            this.lblCoursesSubtitle.Font      = new System.Drawing.Font("Segoe UI", 8F);
            this.lblCoursesSubtitle.ForeColor = System.Drawing.Color.FromArgb(150, 150, 170);
            this.lblCoursesSubtitle.Location  = new System.Drawing.Point(14, 94);
            this.lblCoursesSubtitle.Name      = "lblCoursesSubtitle";
            this.lblCoursesSubtitle.Text      = "Offered by institute";

            // ═══════════════════════════════════════════════════════════════
            //  KPI CARD 3 — Instructors
            // ═══════════════════════════════════════════════════════════════
            this.panelInstructors.BackColor  = System.Drawing.Color.White;
            this.panelInstructors.Location   = new System.Drawing.Point(496, 16);
            this.panelInstructors.Name       = "panelInstructors";
            this.panelInstructors.Size       = new System.Drawing.Size(224, 120);
            this.panelInstructors.TabIndex   = 2;
            this.panelInstructors.Paint     += new System.Windows.Forms.PaintEventHandler(this.KpiCard_Paint);
            this.panelInstructors.Controls.Add(this.panelInstructorsAccent);
            this.panelInstructors.Controls.Add(this.lblInstructorsTitle);
            this.panelInstructors.Controls.Add(this.lblTotalInstructors);
            this.panelInstructors.Controls.Add(this.lblInstructorsSubtitle);

            this.panelInstructorsAccent.BackColor = System.Drawing.Color.FromArgb(251, 140, 0);
            this.panelInstructorsAccent.Dock      = System.Windows.Forms.DockStyle.Top;
            this.panelInstructorsAccent.Height    = 4;
            this.panelInstructorsAccent.Name      = "panelInstructorsAccent";
            this.panelInstructorsAccent.TabIndex  = 10;

            this.lblInstructorsTitle.AutoSize  = true;
            this.lblInstructorsTitle.Font      = new System.Drawing.Font("Segoe UI", 8F);
            this.lblInstructorsTitle.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.lblInstructorsTitle.Location  = new System.Drawing.Point(14, 18);
            this.lblInstructorsTitle.Name      = "lblInstructorsTitle";
            this.lblInstructorsTitle.Text      = "INSTRUCTORS";

            this.lblTotalInstructors.AutoSize  = true;
            this.lblTotalInstructors.Font      = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTotalInstructors.ForeColor = System.Drawing.Color.FromArgb(30, 30, 50);
            this.lblTotalInstructors.Location  = new System.Drawing.Point(10, 36);
            this.lblTotalInstructors.Name      = "lblTotalInstructors";
            this.lblTotalInstructors.Text      = "—";

            this.lblInstructorsSubtitle.AutoSize  = true;
            this.lblInstructorsSubtitle.Font      = new System.Drawing.Font("Segoe UI", 8F);
            this.lblInstructorsSubtitle.ForeColor = System.Drawing.Color.FromArgb(150, 150, 170);
            this.lblInstructorsSubtitle.Location  = new System.Drawing.Point(14, 94);
            this.lblInstructorsSubtitle.Name      = "lblInstructorsSubtitle";
            this.lblInstructorsSubtitle.Text      = "Registered at institute";

            // ═══════════════════════════════════════════════════════════════
            //  KPI CARD 4 — Tests Today
            // ═══════════════════════════════════════════════════════════════
            this.panelTests.BackColor  = System.Drawing.Color.White;
            this.panelTests.Location   = new System.Drawing.Point(736, 16);
            this.panelTests.Name       = "panelTests";
            this.panelTests.Size       = new System.Drawing.Size(224, 120);
            this.panelTests.TabIndex   = 3;
            this.panelTests.Paint     += new System.Windows.Forms.PaintEventHandler(this.KpiCard_Paint);
            this.panelTests.Controls.Add(this.panelTestsAccent);
            this.panelTests.Controls.Add(this.lblTestsTitle);
            this.panelTests.Controls.Add(this.lblTestsToday);
            this.panelTests.Controls.Add(this.lblTestsSubtitle);

            this.panelTestsAccent.BackColor = System.Drawing.Color.FromArgb(0, 150, 136);
            this.panelTestsAccent.Dock      = System.Windows.Forms.DockStyle.Top;
            this.panelTestsAccent.Height    = 4;
            this.panelTestsAccent.Name      = "panelTestsAccent";
            this.panelTestsAccent.TabIndex  = 10;

            this.lblTestsTitle.AutoSize  = true;
            this.lblTestsTitle.Font      = new System.Drawing.Font("Segoe UI", 8F);
            this.lblTestsTitle.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.lblTestsTitle.Location  = new System.Drawing.Point(14, 18);
            this.lblTestsTitle.Name      = "lblTestsTitle";
            this.lblTestsTitle.Text      = "TESTS TODAY";

            this.lblTestsToday.AutoSize  = true;
            this.lblTestsToday.Font      = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTestsToday.ForeColor = System.Drawing.Color.FromArgb(30, 30, 50);
            this.lblTestsToday.Location  = new System.Drawing.Point(10, 36);
            this.lblTestsToday.Name      = "lblTestsToday";
            this.lblTestsToday.Text      = "—";

            this.lblTestsSubtitle.AutoSize  = true;
            this.lblTestsSubtitle.Font      = new System.Drawing.Font("Segoe UI", 8F);
            this.lblTestsSubtitle.ForeColor = System.Drawing.Color.FromArgb(150, 150, 170);
            this.lblTestsSubtitle.Location  = new System.Drawing.Point(14, 94);
            this.lblTestsSubtitle.Name      = "lblTestsSubtitle";
            this.lblTestsSubtitle.Text      = "Scheduled appointments";

            // ═══════════════════════════════════════════════════════════════
            //  RECENT STUDENTS PANEL (bottom-left)
            // ═══════════════════════════════════════════════════════════════
            this.panelRecentStudents.BackColor  = System.Drawing.Color.White;
            this.panelRecentStudents.Location   = new System.Drawing.Point(16, 152);
            this.panelRecentStudents.Name       = "panelRecentStudents";
            this.panelRecentStudents.Size       = new System.Drawing.Size(704, 320);
            this.panelRecentStudents.TabIndex   = 4;
            this.panelRecentStudents.Paint     += new System.Windows.Forms.PaintEventHandler(this.KpiCard_Paint);
            this.panelRecentStudents.Controls.Add(this.lblRecentTitle);
            this.panelRecentStudents.Controls.Add(this.lblRecentSubtitle);
            this.panelRecentStudents.Controls.Add(this.dgvRecentStudents);

            this.lblRecentTitle.AutoSize  = true;
            this.lblRecentTitle.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRecentTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 50);
            this.lblRecentTitle.Location  = new System.Drawing.Point(14, 14);
            this.lblRecentTitle.Name      = "lblRecentTitle";
            this.lblRecentTitle.Text      = "Recent Enrollments";

            this.lblRecentSubtitle.AutoSize  = true;
            this.lblRecentSubtitle.Font      = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRecentSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.lblRecentSubtitle.Location  = new System.Drawing.Point(16, 36);
            this.lblRecentSubtitle.Name      = "lblRecentSubtitle";
            this.lblRecentSubtitle.Text      = "Latest 8 students enrolled";

            // DataGridView — recent students
            this.dgvRecentStudents.AllowUserToAddRows    = false;
            this.dgvRecentStudents.AllowUserToDeleteRows = false;
            this.dgvRecentStudents.ReadOnly              = true;
            this.dgvRecentStudents.RowHeadersVisible     = false;
            this.dgvRecentStudents.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentStudents.BackgroundColor       = System.Drawing.Color.White;
            this.dgvRecentStudents.BorderStyle           = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentStudents.GridColor             = System.Drawing.Color.FromArgb(235, 235, 245);
            this.dgvRecentStudents.RowTemplate.Height    = 30;
            this.dgvRecentStudents.Font                  = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvRecentStudents.Location              = new System.Drawing.Point(0, 58);
            this.dgvRecentStudents.Name                  = "dgvRecentStudents";
            this.dgvRecentStudents.Size                  = new System.Drawing.Size(704, 262);
            this.dgvRecentStudents.TabIndex              = 0;
            this.dgvRecentStudents.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            // Header style
            this.dgvRecentStudents.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 250);
            this.dgvRecentStudents.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(80, 80, 100);
            this.dgvRecentStudents.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.dgvRecentStudents.ColumnHeadersBorderStyle                = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRecentStudents.ColumnHeadersHeightSizeMode             = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisabledResizing;
            this.dgvRecentStudents.ColumnHeadersHeight                     = 32;
            // Row style
            this.dgvRecentStudents.DefaultCellStyle.SelectionBackColor     = System.Drawing.Color.FromArgb(232, 240, 253);
            this.dgvRecentStudents.DefaultCellStyle.SelectionForeColor     = System.Drawing.Color.FromArgb(30, 30, 50);
            this.dgvRecentStudents.DefaultCellStyle.Padding                = new System.Windows.Forms.Padding(4, 0, 0, 0);

            // ═══════════════════════════════════════════════════════════════
            //  PASS RATES PANEL (bottom-right)
            // ═══════════════════════════════════════════════════════════════
            this.panelPassRates.BackColor  = System.Drawing.Color.White;
            this.panelPassRates.Location   = new System.Drawing.Point(736, 152);
            this.panelPassRates.Name       = "panelPassRates";
            this.panelPassRates.Size       = new System.Drawing.Size(224, 320);
            this.panelPassRates.TabIndex   = 5;
            this.panelPassRates.Paint     += new System.Windows.Forms.PaintEventHandler(this.KpiCard_Paint);
            this.panelPassRates.Controls.Add(this.lblPassRatesTitle);
            this.panelPassRates.Controls.Add(this.lblVisionLabel);
            this.panelPassRates.Controls.Add(this.lblVisionPct);
            this.panelPassRates.Controls.Add(this.pbVision);
            this.panelPassRates.Controls.Add(this.lblTheoryLabel);
            this.panelPassRates.Controls.Add(this.lblTheoryPct);
            this.panelPassRates.Controls.Add(this.pbTheory);
            this.panelPassRates.Controls.Add(this.lblRoadLabel);
            this.panelPassRates.Controls.Add(this.lblRoadPct);
            this.panelPassRates.Controls.Add(this.pbRoad);

            this.lblPassRatesTitle.AutoSize  = true;
            this.lblPassRatesTitle.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPassRatesTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 50);
            this.lblPassRatesTitle.Location  = new System.Drawing.Point(14, 14);
            this.lblPassRatesTitle.Name      = "lblPassRatesTitle";
            this.lblPassRatesTitle.Text      = "Pass Rates (This Month)";

            // ── Vision Test ──────────────────────────────────────────────────
            this.lblVisionLabel.AutoSize  = true;
            this.lblVisionLabel.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVisionLabel.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblVisionLabel.Location  = new System.Drawing.Point(14, 60);
            this.lblVisionLabel.Name      = "lblVisionLabel";
            this.lblVisionLabel.Text      = "Vision Test";

            this.lblVisionPct.AutoSize  = true;
            this.lblVisionPct.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVisionPct.ForeColor = System.Drawing.Color.FromArgb(30, 30, 50);
            this.lblVisionPct.Location  = new System.Drawing.Point(178, 60);
            this.lblVisionPct.Name      = "lblVisionPct";
            this.lblVisionPct.Text      = "—";

            this.pbVision.Location    = new System.Drawing.Point(14, 80);
            this.pbVision.Name        = "pbVision";
            this.pbVision.Size        = new System.Drawing.Size(196, 10);
            this.pbVision.TabIndex    = 0;
            this.pbVision.Maximum     = 100;
            this.pbVision.Value       = 0;
            this.pbVision.Style       = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbVision.ForeColor   = System.Drawing.Color.FromArgb(30, 136, 229);

            // ── Theory Test ──────────────────────────────────────────────────
            this.lblTheoryLabel.AutoSize  = true;
            this.lblTheoryLabel.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTheoryLabel.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblTheoryLabel.Location  = new System.Drawing.Point(14, 112);
            this.lblTheoryLabel.Name      = "lblTheoryLabel";
            this.lblTheoryLabel.Text      = "Theory Test";

            this.lblTheoryPct.AutoSize  = true;
            this.lblTheoryPct.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTheoryPct.ForeColor = System.Drawing.Color.FromArgb(30, 30, 50);
            this.lblTheoryPct.Location  = new System.Drawing.Point(178, 112);
            this.lblTheoryPct.Name      = "lblTheoryPct";
            this.lblTheoryPct.Text      = "—";

            this.pbTheory.Location    = new System.Drawing.Point(14, 132);
            this.pbTheory.Name        = "pbTheory";
            this.pbTheory.Size        = new System.Drawing.Size(196, 10);
            this.pbTheory.TabIndex    = 1;
            this.pbTheory.Maximum     = 100;
            this.pbTheory.Value       = 0;
            this.pbTheory.Style       = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbTheory.ForeColor   = System.Drawing.Color.FromArgb(67, 160, 71);

            // ── Road Test ────────────────────────────────────────────────────
            this.lblRoadLabel.AutoSize  = true;
            this.lblRoadLabel.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRoadLabel.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
            this.lblRoadLabel.Location  = new System.Drawing.Point(14, 164);
            this.lblRoadLabel.Name      = "lblRoadLabel";
            this.lblRoadLabel.Text      = "Road Test";

            this.lblRoadPct.AutoSize  = true;
            this.lblRoadPct.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRoadPct.ForeColor = System.Drawing.Color.FromArgb(30, 30, 50);
            this.lblRoadPct.Location  = new System.Drawing.Point(178, 164);
            this.lblRoadPct.Name      = "lblRoadPct";
            this.lblRoadPct.Text      = "—";

            this.pbRoad.Location    = new System.Drawing.Point(14, 184);
            this.pbRoad.Name        = "pbRoad";
            this.pbRoad.Size        = new System.Drawing.Size(196, 10);
            this.pbRoad.TabIndex    = 2;
            this.pbRoad.Maximum     = 100;
            this.pbRoad.Value       = 0;
            this.pbRoad.Style       = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbRoad.ForeColor   = System.Drawing.Color.FromArgb(251, 140, 0);

            // ═══════════════════════════════════════════════════════════════
            //  FORM
            // ═══════════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(245, 246, 250);
            this.ClientSize          = new System.Drawing.Size(976, 490);
            this.Name                = "frmDashboard";
            this.Text                = "Dashboard";
            this.Controls.Add(this.panelStudents);
            this.Controls.Add(this.panelCourses);
            this.Controls.Add(this.panelInstructors);
            this.Controls.Add(this.panelTests);
            this.Controls.Add(this.panelRecentStudents);
            this.Controls.Add(this.panelPassRates);
            this.Load += new System.EventHandler(this.frmDashboard_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentStudents)).EndInit();
            this.panelStudents.ResumeLayout(false);
            this.panelStudents.PerformLayout();
            this.panelCourses.ResumeLayout(false);
            this.panelCourses.PerformLayout();
            this.panelInstructors.ResumeLayout(false);
            this.panelInstructors.PerformLayout();
            this.panelTests.ResumeLayout(false);
            this.panelTests.PerformLayout();
            this.panelRecentStudents.ResumeLayout(false);
            this.panelRecentStudents.PerformLayout();
            this.panelPassRates.ResumeLayout(false);
            this.panelPassRates.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        // KPI Cards
        private System.Windows.Forms.Panel panelStudents;
        private System.Windows.Forms.Panel panelStudentsAccent;
        private System.Windows.Forms.Label lblStudentsTitle;
        private System.Windows.Forms.Label lblTotalStudents;
        private System.Windows.Forms.Label lblNewStudents;

        private System.Windows.Forms.Panel panelCourses;
        private System.Windows.Forms.Panel panelCoursesAccent;
        private System.Windows.Forms.Label lblCoursesTitle;
        private System.Windows.Forms.Label lblTotalCourses;
        private System.Windows.Forms.Label lblCoursesSubtitle;

        private System.Windows.Forms.Panel panelInstructors;
        private System.Windows.Forms.Panel panelInstructorsAccent;
        private System.Windows.Forms.Label lblInstructorsTitle;
        private System.Windows.Forms.Label lblTotalInstructors;
        private System.Windows.Forms.Label lblInstructorsSubtitle;

        private System.Windows.Forms.Panel panelTests;
        private System.Windows.Forms.Panel panelTestsAccent;
        private System.Windows.Forms.Label lblTestsTitle;
        private System.Windows.Forms.Label lblTestsToday;
        private System.Windows.Forms.Label lblTestsSubtitle;

        // Recent Students
        private System.Windows.Forms.Panel     panelRecentStudents;
        private System.Windows.Forms.Label     lblRecentTitle;
        private System.Windows.Forms.Label     lblRecentSubtitle;
        private System.Windows.Forms.DataGridView dgvRecentStudents;

        // Pass Rates
        private System.Windows.Forms.Panel       panelPassRates;
        private System.Windows.Forms.Label       lblPassRatesTitle;
        private System.Windows.Forms.Label       lblVisionLabel;
        private System.Windows.Forms.Label       lblVisionPct;
        private System.Windows.Forms.ProgressBar pbVision;
        private System.Windows.Forms.Label       lblTheoryLabel;
        private System.Windows.Forms.Label       lblTheoryPct;
        private System.Windows.Forms.ProgressBar pbTheory;
        private System.Windows.Forms.Label       lblRoadLabel;
        private System.Windows.Forms.Label       lblRoadPct;
        private System.Windows.Forms.ProgressBar pbRoad;
    }
}