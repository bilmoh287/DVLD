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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelStudents = new System.Windows.Forms.Panel();
            this.panelStudentsAccent = new System.Windows.Forms.Panel();
            this.lblStudentsTitle = new System.Windows.Forms.Label();
            this.lblTotalStudents = new System.Windows.Forms.Label();
            this.lblNewStudents = new System.Windows.Forms.Label();
            this.panelCourses = new System.Windows.Forms.Panel();
            this.panelCoursesAccent = new System.Windows.Forms.Panel();
            this.lblCoursesTitle = new System.Windows.Forms.Label();
            this.lblTotalCourses = new System.Windows.Forms.Label();
            this.lblCoursesSubtitle = new System.Windows.Forms.Label();
            this.panelInstructors = new System.Windows.Forms.Panel();
            this.panelInstructorsAccent = new System.Windows.Forms.Panel();
            this.lblInstructorsTitle = new System.Windows.Forms.Label();
            this.lblTotalInstructors = new System.Windows.Forms.Label();
            this.lblInstructorsSubtitle = new System.Windows.Forms.Label();
            this.panelTests = new System.Windows.Forms.Panel();
            this.panelTestsAccent = new System.Windows.Forms.Panel();
            this.lblTestsTitle = new System.Windows.Forms.Label();
            this.lblTestsToday = new System.Windows.Forms.Label();
            this.lblTestsSubtitle = new System.Windows.Forms.Label();
            this.panelRecentStudents = new System.Windows.Forms.Panel();
            this.lblRecentTitle = new System.Windows.Forms.Label();
            this.lblRecentSubtitle = new System.Windows.Forms.Label();
            this.dgvRecentStudents = new System.Windows.Forms.DataGridView();
            this.panelPassRates = new System.Windows.Forms.Panel();
            this.lblPassRatesTitle = new System.Windows.Forms.Label();
            this.lblVisionLabel = new System.Windows.Forms.Label();
            this.lblVisionPct = new System.Windows.Forms.Label();
            this.pbVision = new System.Windows.Forms.ProgressBar();
            this.lblTheoryLabel = new System.Windows.Forms.Label();
            this.lblTheoryPct = new System.Windows.Forms.Label();
            this.pbTheory = new System.Windows.Forms.ProgressBar();
            this.lblRoadLabel = new System.Windows.Forms.Label();
            this.lblRoadPct = new System.Windows.Forms.Label();
            this.pbRoad = new System.Windows.Forms.ProgressBar();
            this.panelStudents.SuspendLayout();
            this.panelCourses.SuspendLayout();
            this.panelInstructors.SuspendLayout();
            this.panelTests.SuspendLayout();
            this.panelRecentStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentStudents)).BeginInit();
            this.panelPassRates.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelStudents
            // 
            this.panelStudents.BackColor = System.Drawing.Color.White;
            this.panelStudents.Controls.Add(this.panelStudentsAccent);
            this.panelStudents.Controls.Add(this.lblStudentsTitle);
            this.panelStudents.Controls.Add(this.lblTotalStudents);
            this.panelStudents.Controls.Add(this.lblNewStudents);
            this.panelStudents.Location = new System.Drawing.Point(16, 16);
            this.panelStudents.Name = "panelStudents";
            this.panelStudents.Size = new System.Drawing.Size(224, 120);
            this.panelStudents.TabIndex = 0;
            this.panelStudents.Paint += new System.Windows.Forms.PaintEventHandler(this.KpiCard_Paint);
            // 
            // panelStudentsAccent
            // 
            this.panelStudentsAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(160)))), ((int)(((byte)(71)))));
            this.panelStudentsAccent.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStudentsAccent.Location = new System.Drawing.Point(0, 0);
            this.panelStudentsAccent.Name = "panelStudentsAccent";
            this.panelStudentsAccent.Size = new System.Drawing.Size(224, 4);
            this.panelStudentsAccent.TabIndex = 10;
            // 
            // lblStudentsTitle
            // 
            this.lblStudentsTitle.AutoSize = true;
            this.lblStudentsTitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblStudentsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.lblStudentsTitle.Location = new System.Drawing.Point(14, 18);
            this.lblStudentsTitle.Name = "lblStudentsTitle";
            this.lblStudentsTitle.Size = new System.Drawing.Size(116, 19);
            this.lblStudentsTitle.TabIndex = 11;
            this.lblStudentsTitle.Text = "TOTAL STUDENTS";
            // 
            // lblTotalStudents
            // 
            this.lblTotalStudents.AutoSize = true;
            this.lblTotalStudents.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTotalStudents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.lblTotalStudents.Location = new System.Drawing.Point(10, 36);
            this.lblTotalStudents.Name = "lblTotalStudents";
            this.lblTotalStudents.Size = new System.Drawing.Size(74, 62);
            this.lblTotalStudents.TabIndex = 12;
            this.lblTotalStudents.Text = "—";
            // 
            // lblNewStudents
            // 
            this.lblNewStudents.AutoSize = true;
            this.lblNewStudents.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblNewStudents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(160)))), ((int)(((byte)(71)))));
            this.lblNewStudents.Location = new System.Drawing.Point(14, 94);
            this.lblNewStudents.Name = "lblNewStudents";
            this.lblNewStudents.Size = new System.Drawing.Size(98, 19);
            this.lblNewStudents.TabIndex = 13;
            this.lblNewStudents.Text = "+0 this month";
            // 
            // panelCourses
            // 
            this.panelCourses.BackColor = System.Drawing.Color.White;
            this.panelCourses.Controls.Add(this.panelCoursesAccent);
            this.panelCourses.Controls.Add(this.lblCoursesTitle);
            this.panelCourses.Controls.Add(this.lblTotalCourses);
            this.panelCourses.Controls.Add(this.lblCoursesSubtitle);
            this.panelCourses.Location = new System.Drawing.Point(256, 16);
            this.panelCourses.Name = "panelCourses";
            this.panelCourses.Size = new System.Drawing.Size(224, 120);
            this.panelCourses.TabIndex = 1;
            this.panelCourses.Paint += new System.Windows.Forms.PaintEventHandler(this.KpiCard_Paint);
            // 
            // panelCoursesAccent
            // 
            this.panelCoursesAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.panelCoursesAccent.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCoursesAccent.Location = new System.Drawing.Point(0, 0);
            this.panelCoursesAccent.Name = "panelCoursesAccent";
            this.panelCoursesAccent.Size = new System.Drawing.Size(224, 4);
            this.panelCoursesAccent.TabIndex = 10;
            // 
            // lblCoursesTitle
            // 
            this.lblCoursesTitle.AutoSize = true;
            this.lblCoursesTitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblCoursesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.lblCoursesTitle.Location = new System.Drawing.Point(14, 18);
            this.lblCoursesTitle.Name = "lblCoursesTitle";
            this.lblCoursesTitle.Size = new System.Drawing.Size(117, 19);
            this.lblCoursesTitle.TabIndex = 11;
            this.lblCoursesTitle.Text = "ACTIVE COURSES";
            // 
            // lblTotalCourses
            // 
            this.lblTotalCourses.AutoSize = true;
            this.lblTotalCourses.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTotalCourses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.lblTotalCourses.Location = new System.Drawing.Point(10, 36);
            this.lblTotalCourses.Name = "lblTotalCourses";
            this.lblTotalCourses.Size = new System.Drawing.Size(74, 62);
            this.lblTotalCourses.TabIndex = 12;
            this.lblTotalCourses.Text = "—";
            // 
            // lblCoursesSubtitle
            // 
            this.lblCoursesSubtitle.AutoSize = true;
            this.lblCoursesSubtitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblCoursesSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblCoursesSubtitle.Location = new System.Drawing.Point(14, 94);
            this.lblCoursesSubtitle.Name = "lblCoursesSubtitle";
            this.lblCoursesSubtitle.Size = new System.Drawing.Size(128, 19);
            this.lblCoursesSubtitle.TabIndex = 13;
            this.lblCoursesSubtitle.Text = "Offered by institute";
            // 
            // panelInstructors
            // 
            this.panelInstructors.BackColor = System.Drawing.Color.White;
            this.panelInstructors.Controls.Add(this.panelInstructorsAccent);
            this.panelInstructors.Controls.Add(this.lblInstructorsTitle);
            this.panelInstructors.Controls.Add(this.lblTotalInstructors);
            this.panelInstructors.Controls.Add(this.lblInstructorsSubtitle);
            this.panelInstructors.Location = new System.Drawing.Point(496, 16);
            this.panelInstructors.Name = "panelInstructors";
            this.panelInstructors.Size = new System.Drawing.Size(224, 120);
            this.panelInstructors.TabIndex = 2;
            this.panelInstructors.Paint += new System.Windows.Forms.PaintEventHandler(this.KpiCard_Paint);
            // 
            // panelInstructorsAccent
            // 
            this.panelInstructorsAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.panelInstructorsAccent.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInstructorsAccent.Location = new System.Drawing.Point(0, 0);
            this.panelInstructorsAccent.Name = "panelInstructorsAccent";
            this.panelInstructorsAccent.Size = new System.Drawing.Size(224, 4);
            this.panelInstructorsAccent.TabIndex = 10;
            // 
            // lblInstructorsTitle
            // 
            this.lblInstructorsTitle.AutoSize = true;
            this.lblInstructorsTitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblInstructorsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.lblInstructorsTitle.Location = new System.Drawing.Point(14, 18);
            this.lblInstructorsTitle.Name = "lblInstructorsTitle";
            this.lblInstructorsTitle.Size = new System.Drawing.Size(96, 19);
            this.lblInstructorsTitle.TabIndex = 11;
            this.lblInstructorsTitle.Text = "INSTRUCTORS";
            // 
            // lblTotalInstructors
            // 
            this.lblTotalInstructors.AutoSize = true;
            this.lblTotalInstructors.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTotalInstructors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.lblTotalInstructors.Location = new System.Drawing.Point(10, 36);
            this.lblTotalInstructors.Name = "lblTotalInstructors";
            this.lblTotalInstructors.Size = new System.Drawing.Size(74, 62);
            this.lblTotalInstructors.TabIndex = 12;
            this.lblTotalInstructors.Text = "—";
            // 
            // lblInstructorsSubtitle
            // 
            this.lblInstructorsSubtitle.AutoSize = true;
            this.lblInstructorsSubtitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblInstructorsSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblInstructorsSubtitle.Location = new System.Drawing.Point(14, 94);
            this.lblInstructorsSubtitle.Name = "lblInstructorsSubtitle";
            this.lblInstructorsSubtitle.Size = new System.Drawing.Size(143, 19);
            this.lblInstructorsSubtitle.TabIndex = 13;
            this.lblInstructorsSubtitle.Text = "Registered at institute";
            // 
            // panelTests
            // 
            this.panelTests.BackColor = System.Drawing.Color.White;
            this.panelTests.Controls.Add(this.panelTestsAccent);
            this.panelTests.Controls.Add(this.lblTestsTitle);
            this.panelTests.Controls.Add(this.lblTestsToday);
            this.panelTests.Controls.Add(this.lblTestsSubtitle);
            this.panelTests.Location = new System.Drawing.Point(736, 16);
            this.panelTests.Name = "panelTests";
            this.panelTests.Size = new System.Drawing.Size(224, 120);
            this.panelTests.TabIndex = 3;
            this.panelTests.Paint += new System.Windows.Forms.PaintEventHandler(this.KpiCard_Paint);
            // 
            // panelTestsAccent
            // 
            this.panelTestsAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panelTestsAccent.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTestsAccent.Location = new System.Drawing.Point(0, 0);
            this.panelTestsAccent.Name = "panelTestsAccent";
            this.panelTestsAccent.Size = new System.Drawing.Size(224, 4);
            this.panelTestsAccent.TabIndex = 10;
            // 
            // lblTestsTitle
            // 
            this.lblTestsTitle.AutoSize = true;
            this.lblTestsTitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblTestsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.lblTestsTitle.Location = new System.Drawing.Point(14, 18);
            this.lblTestsTitle.Name = "lblTestsTitle";
            this.lblTestsTitle.Size = new System.Drawing.Size(91, 19);
            this.lblTestsTitle.TabIndex = 11;
            this.lblTestsTitle.Text = "TESTS TODAY";
            // 
            // lblTestsToday
            // 
            this.lblTestsToday.AutoSize = true;
            this.lblTestsToday.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTestsToday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.lblTestsToday.Location = new System.Drawing.Point(10, 36);
            this.lblTestsToday.Name = "lblTestsToday";
            this.lblTestsToday.Size = new System.Drawing.Size(74, 62);
            this.lblTestsToday.TabIndex = 12;
            this.lblTestsToday.Text = "—";
            // 
            // lblTestsSubtitle
            // 
            this.lblTestsSubtitle.AutoSize = true;
            this.lblTestsSubtitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblTestsSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblTestsSubtitle.Location = new System.Drawing.Point(14, 94);
            this.lblTestsSubtitle.Name = "lblTestsSubtitle";
            this.lblTestsSubtitle.Size = new System.Drawing.Size(160, 19);
            this.lblTestsSubtitle.TabIndex = 13;
            this.lblTestsSubtitle.Text = "Scheduled appointments";
            // 
            // panelRecentStudents
            // 
            this.panelRecentStudents.BackColor = System.Drawing.Color.White;
            this.panelRecentStudents.Controls.Add(this.lblRecentTitle);
            this.panelRecentStudents.Controls.Add(this.lblRecentSubtitle);
            this.panelRecentStudents.Controls.Add(this.dgvRecentStudents);
            this.panelRecentStudents.Location = new System.Drawing.Point(16, 152);
            this.panelRecentStudents.Name = "panelRecentStudents";
            this.panelRecentStudents.Size = new System.Drawing.Size(704, 320);
            this.panelRecentStudents.TabIndex = 4;
            this.panelRecentStudents.Paint += new System.Windows.Forms.PaintEventHandler(this.KpiCard_Paint);
            // 
            // lblRecentTitle
            // 
            this.lblRecentTitle.AutoSize = true;
            this.lblRecentTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRecentTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.lblRecentTitle.Location = new System.Drawing.Point(14, 14);
            this.lblRecentTitle.Name = "lblRecentTitle";
            this.lblRecentTitle.Size = new System.Drawing.Size(183, 25);
            this.lblRecentTitle.TabIndex = 0;
            this.lblRecentTitle.Text = "Recent Enrollments";
            // 
            // lblRecentSubtitle
            // 
            this.lblRecentSubtitle.AutoSize = true;
            this.lblRecentSubtitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRecentSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.lblRecentSubtitle.Location = new System.Drawing.Point(16, 36);
            this.lblRecentSubtitle.Name = "lblRecentSubtitle";
            this.lblRecentSubtitle.Size = new System.Drawing.Size(168, 19);
            this.lblRecentSubtitle.TabIndex = 1;
            this.lblRecentSubtitle.Text = "Latest 8 students enrolled";
            // 
            // dgvRecentStudents
            // 
            this.dgvRecentStudents.AllowUserToAddRows = false;
            this.dgvRecentStudents.AllowUserToDeleteRows = false;
            this.dgvRecentStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentStudents.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentStudents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentStudents.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecentStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRecentStudents.ColumnHeadersHeight = 32;
            this.dgvRecentStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecentStudents.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRecentStudents.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvRecentStudents.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.dgvRecentStudents.Location = new System.Drawing.Point(0, 58);
            this.dgvRecentStudents.Name = "dgvRecentStudents";
            this.dgvRecentStudents.ReadOnly = true;
            this.dgvRecentStudents.RowHeadersVisible = false;
            this.dgvRecentStudents.RowHeadersWidth = 51;
            this.dgvRecentStudents.RowTemplate.Height = 30;
            this.dgvRecentStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentStudents.Size = new System.Drawing.Size(704, 262);
            this.dgvRecentStudents.TabIndex = 0;
            // 
            // panelPassRates
            // 
            this.panelPassRates.BackColor = System.Drawing.Color.White;
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
            this.panelPassRates.Location = new System.Drawing.Point(736, 152);
            this.panelPassRates.Name = "panelPassRates";
            this.panelPassRates.Size = new System.Drawing.Size(224, 320);
            this.panelPassRates.TabIndex = 5;
            this.panelPassRates.Paint += new System.Windows.Forms.PaintEventHandler(this.KpiCard_Paint);
            // 
            // lblPassRatesTitle
            // 
            this.lblPassRatesTitle.AutoSize = true;
            this.lblPassRatesTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPassRatesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.lblPassRatesTitle.Location = new System.Drawing.Point(14, 14);
            this.lblPassRatesTitle.Name = "lblPassRatesTitle";
            this.lblPassRatesTitle.Size = new System.Drawing.Size(221, 25);
            this.lblPassRatesTitle.TabIndex = 0;
            this.lblPassRatesTitle.Text = "Pass Rates (This Month)";
            // 
            // lblVisionLabel
            // 
            this.lblVisionLabel.AutoSize = true;
            this.lblVisionLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVisionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblVisionLabel.Location = new System.Drawing.Point(14, 60);
            this.lblVisionLabel.Name = "lblVisionLabel";
            this.lblVisionLabel.Size = new System.Drawing.Size(79, 20);
            this.lblVisionLabel.TabIndex = 1;
            this.lblVisionLabel.Text = "Vision Test";
            // 
            // lblVisionPct
            // 
            this.lblVisionPct.AutoSize = true;
            this.lblVisionPct.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVisionPct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.lblVisionPct.Location = new System.Drawing.Point(178, 60);
            this.lblVisionPct.Name = "lblVisionPct";
            this.lblVisionPct.Size = new System.Drawing.Size(24, 20);
            this.lblVisionPct.TabIndex = 2;
            this.lblVisionPct.Text = "—";
            // 
            // pbVision
            // 
            this.pbVision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(229)))));
            this.pbVision.Location = new System.Drawing.Point(14, 80);
            this.pbVision.Name = "pbVision";
            this.pbVision.Size = new System.Drawing.Size(196, 10);
            this.pbVision.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbVision.TabIndex = 0;
            // 
            // lblTheoryLabel
            // 
            this.lblTheoryLabel.AutoSize = true;
            this.lblTheoryLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTheoryLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblTheoryLabel.Location = new System.Drawing.Point(14, 112);
            this.lblTheoryLabel.Name = "lblTheoryLabel";
            this.lblTheoryLabel.Size = new System.Drawing.Size(84, 20);
            this.lblTheoryLabel.TabIndex = 3;
            this.lblTheoryLabel.Text = "Theory Test";
            // 
            // lblTheoryPct
            // 
            this.lblTheoryPct.AutoSize = true;
            this.lblTheoryPct.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTheoryPct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.lblTheoryPct.Location = new System.Drawing.Point(178, 112);
            this.lblTheoryPct.Name = "lblTheoryPct";
            this.lblTheoryPct.Size = new System.Drawing.Size(24, 20);
            this.lblTheoryPct.TabIndex = 4;
            this.lblTheoryPct.Text = "—";
            // 
            // pbTheory
            // 
            this.pbTheory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(160)))), ((int)(((byte)(71)))));
            this.pbTheory.Location = new System.Drawing.Point(14, 132);
            this.pbTheory.Name = "pbTheory";
            this.pbTheory.Size = new System.Drawing.Size(196, 10);
            this.pbTheory.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbTheory.TabIndex = 1;
            // 
            // lblRoadLabel
            // 
            this.lblRoadLabel.AutoSize = true;
            this.lblRoadLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRoadLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblRoadLabel.Location = new System.Drawing.Point(14, 164);
            this.lblRoadLabel.Name = "lblRoadLabel";
            this.lblRoadLabel.Size = new System.Drawing.Size(74, 20);
            this.lblRoadLabel.TabIndex = 5;
            this.lblRoadLabel.Text = "Road Test";
            // 
            // lblRoadPct
            // 
            this.lblRoadPct.AutoSize = true;
            this.lblRoadPct.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRoadPct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.lblRoadPct.Location = new System.Drawing.Point(178, 164);
            this.lblRoadPct.Name = "lblRoadPct";
            this.lblRoadPct.Size = new System.Drawing.Size(24, 20);
            this.lblRoadPct.TabIndex = 6;
            this.lblRoadPct.Text = "—";
            // 
            // pbRoad
            // 
            this.pbRoad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.pbRoad.Location = new System.Drawing.Point(14, 184);
            this.pbRoad.Name = "pbRoad";
            this.pbRoad.Size = new System.Drawing.Size(196, 10);
            this.pbRoad.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbRoad.TabIndex = 2;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1117, 579);
            this.Controls.Add(this.panelStudents);
            this.Controls.Add(this.panelCourses);
            this.Controls.Add(this.panelInstructors);
            this.Controls.Add(this.panelTests);
            this.Controls.Add(this.panelRecentStudents);
            this.Controls.Add(this.panelPassRates);
            this.Name = "frmDashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentStudents)).EndInit();
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