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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanelCards = new System.Windows.Forms.TableLayoutPanel();
            this.panelStudents = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStudentsTitle = new System.Windows.Forms.Label();
            this.lblTotalStudents = new System.Windows.Forms.Label();
            this.lblNewStudents = new System.Windows.Forms.Label();
            this.panelCourses = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCoursesTitle = new System.Windows.Forms.Label();
            this.lblTotalCourses = new System.Windows.Forms.Label();
            this.lblNewCourses = new System.Windows.Forms.Label();
            this.panelEarnings = new Guna.UI2.WinForms.Guna2Panel();
            this.lblEarningsTitle = new System.Windows.Forms.Label();
            this.lblTotalEarnings = new System.Windows.Forms.Label();
            this.lblEarningsSub = new System.Windows.Forms.Label();
            this.panelTests = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTestsTitle = new System.Windows.Forms.Label();
            this.lblTestsToday = new System.Windows.Forms.Label();
            this.lblTestsSub = new System.Windows.Forms.Label();
            this.panelChartContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.lblChartSubtitle = new System.Windows.Forms.Label();
            this.panelChartCanvas = new System.Windows.Forms.Panel();
            this.panelBottomRow = new System.Windows.Forms.TableLayoutPanel();
            this.panelRecent = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRecentTitle = new System.Windows.Forms.Label();
            this.dgvRecentStudents = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panelUpcoming = new Guna.UI2.WinForms.Guna2Panel();
            this.lblUpcomingTitle = new System.Windows.Forms.Label();
            this.lblVision = new System.Windows.Forms.Label();
            this.lblVisionPct = new System.Windows.Forms.Label();
            this.pbVision = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.lblTheory = new System.Windows.Forms.Label();
            this.lblTheoryPct = new System.Windows.Forms.Label();
            this.pbTheory = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.lblRoad = new System.Windows.Forms.Label();
            this.lblRoadPct = new System.Windows.Forms.Label();
            this.pbRoad = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.tableLayoutPanelCards.SuspendLayout();
            this.panelStudents.SuspendLayout();
            this.panelCourses.SuspendLayout();
            this.panelEarnings.SuspendLayout();
            this.panelTests.SuspendLayout();
            this.panelChartContainer.SuspendLayout();
            this.panelBottomRow.SuspendLayout();
            this.panelRecent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentStudents)).BeginInit();
            this.panelUpcoming.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelCards
            // 
            this.tableLayoutPanelCards.ColumnCount = 4;
            this.tableLayoutPanelCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCards.Controls.Add(this.panelStudents, 0, 0);
            this.tableLayoutPanelCards.Controls.Add(this.panelCourses, 1, 0);
            this.tableLayoutPanelCards.Controls.Add(this.panelEarnings, 2, 0);
            this.tableLayoutPanelCards.Controls.Add(this.panelTests, 3, 0);
            this.tableLayoutPanelCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelCards.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanelCards.Name = "tableLayoutPanelCards";
            this.tableLayoutPanelCards.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.tableLayoutPanelCards.RowCount = 1;
            this.tableLayoutPanelCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelCards.Size = new System.Drawing.Size(1200, 160);
            this.tableLayoutPanelCards.TabIndex = 0;
            // 
            // panelStudents
            // 
            this.panelStudents.BackColor = System.Drawing.Color.Transparent;
            this.panelStudents.BorderRadius = 15;
            this.panelStudents.Controls.Add(this.lblStudentsTitle);
            this.panelStudents.Controls.Add(this.lblTotalStudents);
            this.panelStudents.Controls.Add(this.lblNewStudents);
            this.panelStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStudents.FillColor = System.Drawing.Color.White;
            this.panelStudents.Location = new System.Drawing.Point(5, 5);
            this.panelStudents.Margin = new System.Windows.Forms.Padding(5, 5, 15, 5);
            this.panelStudents.Name = "panelStudents";
            this.panelStudents.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelStudents.ShadowDecoration.Enabled = true;
            this.panelStudents.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 2, 5, 5);
            this.panelStudents.Size = new System.Drawing.Size(280, 140);
            this.panelStudents.TabIndex = 0;
            // 
            // lblStudentsTitle
            // 
            this.lblStudentsTitle.AutoSize = true;
            this.lblStudentsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStudentsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(160)))));
            this.lblStudentsTitle.Location = new System.Drawing.Point(20, 20);
            this.lblStudentsTitle.Name = "lblStudentsTitle";
            this.lblStudentsTitle.Size = new System.Drawing.Size(153, 23);
            this.lblStudentsTitle.TabIndex = 0;
            this.lblStudentsTitle.Text = "TOTAL STUDENTS";
            // 
            // lblTotalStudents
            // 
            this.lblTotalStudents.AutoSize = true;
            this.lblTotalStudents.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
            this.lblTotalStudents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.lblTotalStudents.Location = new System.Drawing.Point(15, 45);
            this.lblTotalStudents.Name = "lblTotalStudents";
            this.lblTotalStudents.Size = new System.Drawing.Size(58, 67);
            this.lblTotalStudents.TabIndex = 1;
            this.lblTotalStudents.Text = "0";
            // 
            // lblNewStudents
            // 
            this.lblNewStudents.AutoSize = true;
            this.lblNewStudents.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNewStudents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(186)))), ((int)(((byte)(119)))));
            this.lblNewStudents.Location = new System.Drawing.Point(20, 115);
            this.lblNewStudents.Name = "lblNewStudents";
            this.lblNewStudents.Size = new System.Drawing.Size(124, 23);
            this.lblNewStudents.TabIndex = 2;
            this.lblNewStudents.Text = "+0 this month";
            // 
            // panelCourses
            // 
            this.panelCourses.BackColor = System.Drawing.Color.Transparent;
            this.panelCourses.BorderRadius = 15;
            this.panelCourses.Controls.Add(this.lblCoursesTitle);
            this.panelCourses.Controls.Add(this.lblTotalCourses);
            this.panelCourses.Controls.Add(this.lblNewCourses);
            this.panelCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCourses.FillColor = System.Drawing.Color.White;
            this.panelCourses.Location = new System.Drawing.Point(305, 5);
            this.panelCourses.Margin = new System.Windows.Forms.Padding(5, 5, 15, 5);
            this.panelCourses.Name = "panelCourses";
            this.panelCourses.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelCourses.ShadowDecoration.Enabled = true;
            this.panelCourses.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 2, 5, 5);
            this.panelCourses.Size = new System.Drawing.Size(280, 140);
            this.panelCourses.TabIndex = 1;
            // 
            // lblCoursesTitle
            // 
            this.lblCoursesTitle.AutoSize = true;
            this.lblCoursesTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCoursesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(160)))));
            this.lblCoursesTitle.Location = new System.Drawing.Point(20, 20);
            this.lblCoursesTitle.Name = "lblCoursesTitle";
            this.lblCoursesTitle.Size = new System.Drawing.Size(149, 23);
            this.lblCoursesTitle.TabIndex = 0;
            this.lblCoursesTitle.Text = "ACTIVE COURSES";
            // 
            // lblTotalCourses
            // 
            this.lblTotalCourses.AutoSize = true;
            this.lblTotalCourses.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
            this.lblTotalCourses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.lblTotalCourses.Location = new System.Drawing.Point(15, 45);
            this.lblTotalCourses.Name = "lblTotalCourses";
            this.lblTotalCourses.Size = new System.Drawing.Size(58, 67);
            this.lblTotalCourses.TabIndex = 1;
            this.lblTotalCourses.Text = "0";
            // 
            // lblNewCourses
            // 
            this.lblNewCourses.AutoSize = true;
            this.lblNewCourses.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNewCourses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lblNewCourses.Location = new System.Drawing.Point(20, 115);
            this.lblNewCourses.Name = "lblNewCourses";
            this.lblNewCourses.Size = new System.Drawing.Size(70, 23);
            this.lblNewCourses.TabIndex = 2;
            this.lblNewCourses.Text = "+0 new";
            // 
            // panelEarnings
            // 
            this.panelEarnings.BackColor = System.Drawing.Color.Transparent;
            this.panelEarnings.BorderRadius = 15;
            this.panelEarnings.Controls.Add(this.lblEarningsTitle);
            this.panelEarnings.Controls.Add(this.lblTotalEarnings);
            this.panelEarnings.Controls.Add(this.lblEarningsSub);
            this.panelEarnings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEarnings.FillColor = System.Drawing.Color.White;
            this.panelEarnings.Location = new System.Drawing.Point(605, 5);
            this.panelEarnings.Margin = new System.Windows.Forms.Padding(5, 5, 15, 5);
            this.panelEarnings.Name = "panelEarnings";
            this.panelEarnings.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelEarnings.ShadowDecoration.Enabled = true;
            this.panelEarnings.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 2, 5, 5);
            this.panelEarnings.Size = new System.Drawing.Size(280, 140);
            this.panelEarnings.TabIndex = 2;
            // 
            // lblEarningsTitle
            // 
            this.lblEarningsTitle.AutoSize = true;
            this.lblEarningsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEarningsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(160)))));
            this.lblEarningsTitle.Location = new System.Drawing.Point(20, 20);
            this.lblEarningsTitle.Name = "lblEarningsTitle";
            this.lblEarningsTitle.Size = new System.Drawing.Size(151, 23);
            this.lblEarningsTitle.TabIndex = 0;
            this.lblEarningsTitle.Text = "TOTAL EARNINGS";
            // 
            // lblTotalEarnings
            // 
            this.lblTotalEarnings.AutoSize = true;
            this.lblTotalEarnings.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
            this.lblTotalEarnings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.lblTotalEarnings.Location = new System.Drawing.Point(15, 45);
            this.lblTotalEarnings.Name = "lblTotalEarnings";
            this.lblTotalEarnings.Size = new System.Drawing.Size(87, 67);
            this.lblTotalEarnings.TabIndex = 1;
            this.lblTotalEarnings.Text = "$0";
            // 
            // lblEarningsSub
            // 
            this.lblEarningsSub.AutoSize = true;
            this.lblEarningsSub.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEarningsSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(167)))), ((int)(((byte)(38)))));
            this.lblEarningsSub.Location = new System.Drawing.Point(20, 115);
            this.lblEarningsSub.Name = "lblEarningsSub";
            this.lblEarningsSub.Size = new System.Drawing.Size(176, 23);
            this.lblEarningsSub.TabIndex = 2;
            this.lblEarningsSub.Text = "From all enrollments";
            // 
            // panelTests
            // 
            this.panelTests.BackColor = System.Drawing.Color.Transparent;
            this.panelTests.BorderRadius = 15;
            this.panelTests.Controls.Add(this.lblTestsTitle);
            this.panelTests.Controls.Add(this.lblTestsToday);
            this.panelTests.Controls.Add(this.lblTestsSub);
            this.panelTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTests.FillColor = System.Drawing.Color.White;
            this.panelTests.Location = new System.Drawing.Point(905, 5);
            this.panelTests.Margin = new System.Windows.Forms.Padding(5, 5, 15, 5);
            this.panelTests.Name = "panelTests";
            this.panelTests.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelTests.ShadowDecoration.Enabled = true;
            this.panelTests.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 2, 5, 5);
            this.panelTests.Size = new System.Drawing.Size(280, 140);
            this.panelTests.TabIndex = 3;
            // 
            // lblTestsTitle
            // 
            this.lblTestsTitle.AutoSize = true;
            this.lblTestsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTestsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(160)))));
            this.lblTestsTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTestsTitle.Name = "lblTestsTitle";
            this.lblTestsTitle.Size = new System.Drawing.Size(120, 23);
            this.lblTestsTitle.TabIndex = 0;
            this.lblTestsTitle.Text = "TESTS TODAY";
            // 
            // lblTestsToday
            // 
            this.lblTestsToday.AutoSize = true;
            this.lblTestsToday.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
            this.lblTestsToday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.lblTestsToday.Location = new System.Drawing.Point(15, 45);
            this.lblTestsToday.Name = "lblTestsToday";
            this.lblTestsToday.Size = new System.Drawing.Size(58, 67);
            this.lblTestsToday.TabIndex = 1;
            this.lblTestsToday.Text = "0";
            // 
            // lblTestsSub
            // 
            this.lblTestsSub.AutoSize = true;
            this.lblTestsSub.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTestsSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblTestsSub.Location = new System.Drawing.Point(20, 115);
            this.lblTestsSub.Name = "lblTestsSub";
            this.lblTestsSub.Size = new System.Drawing.Size(93, 23);
            this.lblTestsSub.TabIndex = 2;
            this.lblTestsSub.Text = "Scheduled";
            // 
            // panelChartContainer
            // 
            this.panelChartContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChartContainer.BackColor = System.Drawing.Color.Transparent;
            this.panelChartContainer.BorderRadius = 15;
            this.panelChartContainer.Controls.Add(this.lblChartTitle);
            this.panelChartContainer.Controls.Add(this.lblChartSubtitle);
            this.panelChartContainer.Controls.Add(this.panelChartCanvas);
            this.panelChartContainer.FillColor = System.Drawing.Color.White;
            this.panelChartContainer.Location = new System.Drawing.Point(20, 190);
            this.panelChartContainer.Name = "panelChartContainer";
            this.panelChartContainer.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelChartContainer.ShadowDecoration.Enabled = true;
            this.panelChartContainer.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3, 3, 5, 5);
            this.panelChartContainer.Size = new System.Drawing.Size(1200, 320);
            this.panelChartContainer.TabIndex = 1;
            // 
            // lblChartTitle
            // 
            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.lblChartTitle.Location = new System.Drawing.Point(25, 20);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new System.Drawing.Size(235, 32);
            this.lblChartTitle.TabIndex = 0;
            this.lblChartTitle.Text = "Student enrollment";
            // 
            // lblChartSubtitle
            // 
            this.lblChartSubtitle.AutoSize = true;
            this.lblChartSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblChartSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(160)))));
            this.lblChartSubtitle.Location = new System.Drawing.Point(26, 52);
            this.lblChartSubtitle.Name = "lblChartSubtitle";
            this.lblChartSubtitle.Size = new System.Drawing.Size(330, 23);
            this.lblChartSubtitle.TabIndex = 1;
            this.lblChartSubtitle.Text = "New students per month — last 3 months";
            // 
            // panelChartCanvas
            // 
            this.panelChartCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChartCanvas.Location = new System.Drawing.Point(20, 85);
            this.panelChartCanvas.Name = "panelChartCanvas";
            this.panelChartCanvas.Size = new System.Drawing.Size(1160, 220);
            this.panelChartCanvas.TabIndex = 2;
            this.panelChartCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.panelChartCanvas_Paint);
            // 
            // panelBottomRow
            // 
            this.panelBottomRow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBottomRow.ColumnCount = 2;
            this.panelBottomRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.panelBottomRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.panelBottomRow.Controls.Add(this.panelRecent, 0, 0);
            this.panelBottomRow.Controls.Add(this.panelUpcoming, 1, 0);
            this.panelBottomRow.Location = new System.Drawing.Point(20, 530);
            this.panelBottomRow.Name = "panelBottomRow";
            this.panelBottomRow.RowCount = 1;
            this.panelBottomRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelBottomRow.Size = new System.Drawing.Size(1200, 330);
            this.panelBottomRow.TabIndex = 2;
            // 
            // panelRecent
            // 
            this.panelRecent.BackColor = System.Drawing.Color.Transparent;
            this.panelRecent.BorderRadius = 15;
            this.panelRecent.Controls.Add(this.lblRecentTitle);
            this.panelRecent.Controls.Add(this.dgvRecentStudents);
            this.panelRecent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRecent.FillColor = System.Drawing.Color.White;
            this.panelRecent.Location = new System.Drawing.Point(0, 0);
            this.panelRecent.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.panelRecent.Name = "panelRecent";
            this.panelRecent.Padding = new System.Windows.Forms.Padding(15);
            this.panelRecent.ShadowDecoration.Enabled = true;
            this.panelRecent.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3, 3, 5, 5);
            this.panelRecent.Size = new System.Drawing.Size(765, 330);
            this.panelRecent.TabIndex = 0;
            // 
            // lblRecentTitle
            // 
            this.lblRecentTitle.AutoSize = true;
            this.lblRecentTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRecentTitle.Location = new System.Drawing.Point(15, 15);
            this.lblRecentTitle.Name = "lblRecentTitle";
            this.lblRecentTitle.Size = new System.Drawing.Size(196, 28);
            this.lblRecentTitle.TabIndex = 0;
            this.lblRecentTitle.Text = "Recent Enrollments";
            // 
            // dgvRecentStudents
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvRecentStudents.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRecentStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.dgvRecentStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRecentStudents.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecentStudents.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRecentStudents.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRecentStudents.Location = new System.Drawing.Point(15, 50);
            this.dgvRecentStudents.Name = "dgvRecentStudents";
            this.dgvRecentStudents.RowHeadersVisible = false;
            this.dgvRecentStudents.RowHeadersWidth = 51;
            this.dgvRecentStudents.Size = new System.Drawing.Size(1295, 490);
            this.dgvRecentStudents.TabIndex = 1;
            this.dgvRecentStudents.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRecentStudents.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvRecentStudents.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvRecentStudents.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvRecentStudents.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvRecentStudents.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvRecentStudents.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRecentStudents.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.dgvRecentStudents.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRecentStudents.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRecentStudents.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.dgvRecentStudents.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRecentStudents.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvRecentStudents.ThemeStyle.ReadOnly = false;
            this.dgvRecentStudents.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRecentStudents.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRecentStudents.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRecentStudents.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvRecentStudents.ThemeStyle.RowsStyle.Height = 22;
            this.dgvRecentStudents.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRecentStudents.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // panelUpcoming
            // 
            this.panelUpcoming.BackColor = System.Drawing.Color.Transparent;
            this.panelUpcoming.BorderRadius = 15;
            this.panelUpcoming.Controls.Add(this.lblUpcomingTitle);
            this.panelUpcoming.Controls.Add(this.lblVision);
            this.panelUpcoming.Controls.Add(this.lblVisionPct);
            this.panelUpcoming.Controls.Add(this.pbVision);
            this.panelUpcoming.Controls.Add(this.lblTheory);
            this.panelUpcoming.Controls.Add(this.lblTheoryPct);
            this.panelUpcoming.Controls.Add(this.pbTheory);
            this.panelUpcoming.Controls.Add(this.lblRoad);
            this.panelUpcoming.Controls.Add(this.lblRoadPct);
            this.panelUpcoming.Controls.Add(this.pbRoad);
            this.panelUpcoming.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUpcoming.FillColor = System.Drawing.Color.White;
            this.panelUpcoming.Location = new System.Drawing.Point(780, 0);
            this.panelUpcoming.Margin = new System.Windows.Forms.Padding(0);
            this.panelUpcoming.Name = "panelUpcoming";
            this.panelUpcoming.ShadowDecoration.Enabled = true;
            this.panelUpcoming.Size = new System.Drawing.Size(420, 330);
            this.panelUpcoming.TabIndex = 1;
            // 
            // lblUpcomingTitle
            // 
            this.lblUpcomingTitle.AutoSize = true;
            this.lblUpcomingTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblUpcomingTitle.Location = new System.Drawing.Point(20, 15);
            this.lblUpcomingTitle.Name = "lblUpcomingTitle";
            this.lblUpcomingTitle.Size = new System.Drawing.Size(239, 28);
            this.lblUpcomingTitle.TabIndex = 0;
            this.lblUpcomingTitle.Text = "Pass Rates (This Month)";
            // 
            // lblVision
            // 
            this.lblVision.AutoSize = true;
            this.lblVision.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblVision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblVision.Location = new System.Drawing.Point(25, 60);
            this.lblVision.Name = "lblVision";
            this.lblVision.Size = new System.Drawing.Size(106, 25);
            this.lblVision.TabIndex = 1;
            this.lblVision.Text = "Vision Test";
            // 
            // lblVisionPct
            // 
            this.lblVisionPct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVisionPct.AutoSize = true;
            this.lblVisionPct.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblVisionPct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.lblVisionPct.Location = new System.Drawing.Point(560, 60);
            this.lblVisionPct.Name = "lblVisionPct";
            this.lblVisionPct.Size = new System.Drawing.Size(0, 25);
            this.lblVisionPct.TabIndex = 2;
            // 
            // pbVision
            // 
            this.pbVision.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbVision.BorderRadius = 4;
            this.pbVision.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.pbVision.Location = new System.Drawing.Point(25, 90);
            this.pbVision.Name = "pbVision";
            this.pbVision.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pbVision.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pbVision.Size = new System.Drawing.Size(580, 8);
            this.pbVision.TabIndex = 3;
            this.pbVision.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // lblTheory
            // 
            this.lblTheory.AutoSize = true;
            this.lblTheory.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTheory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblTheory.Location = new System.Drawing.Point(25, 130);
            this.lblTheory.Name = "lblTheory";
            this.lblTheory.Size = new System.Drawing.Size(114, 25);
            this.lblTheory.TabIndex = 4;
            this.lblTheory.Text = "Theory Test";
            // 
            // lblTheoryPct
            // 
            this.lblTheoryPct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTheoryPct.AutoSize = true;
            this.lblTheoryPct.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTheoryPct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.lblTheoryPct.Location = new System.Drawing.Point(560, 130);
            this.lblTheoryPct.Name = "lblTheoryPct";
            this.lblTheoryPct.Size = new System.Drawing.Size(0, 25);
            this.lblTheoryPct.TabIndex = 5;
            // 
            // pbTheory
            // 
            this.pbTheory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbTheory.BorderRadius = 4;
            this.pbTheory.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.pbTheory.Location = new System.Drawing.Point(25, 160);
            this.pbTheory.Name = "pbTheory";
            this.pbTheory.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pbTheory.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pbTheory.Size = new System.Drawing.Size(580, 8);
            this.pbTheory.TabIndex = 6;
            this.pbTheory.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // lblRoad
            // 
            this.lblRoad.AutoSize = true;
            this.lblRoad.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRoad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblRoad.Location = new System.Drawing.Point(25, 200);
            this.lblRoad.Name = "lblRoad";
            this.lblRoad.Size = new System.Drawing.Size(97, 25);
            this.lblRoad.TabIndex = 7;
            this.lblRoad.Text = "Road Test";
            // 
            // lblRoadPct
            // 
            this.lblRoadPct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRoadPct.AutoSize = true;
            this.lblRoadPct.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRoadPct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            this.lblRoadPct.Location = new System.Drawing.Point(560, 200);
            this.lblRoadPct.Name = "lblRoadPct";
            this.lblRoadPct.Size = new System.Drawing.Size(0, 25);
            this.lblRoadPct.TabIndex = 8;
            // 
            // pbRoad
            // 
            this.pbRoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbRoad.BorderRadius = 4;
            this.pbRoad.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            this.pbRoad.Location = new System.Drawing.Point(25, 230);
            this.pbRoad.Name = "pbRoad";
            this.pbRoad.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pbRoad.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.pbRoad.Size = new System.Drawing.Size(580, 8);
            this.pbRoad.TabIndex = 9;
            this.pbRoad.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(1240, 890);
            this.Controls.Add(this.panelBottomRow);
            this.Controls.Add(this.panelChartContainer);
            this.Controls.Add(this.tableLayoutPanelCards);
            this.Name = "frmDashboard";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.Resize += new System.EventHandler(this.frmDashboard_Resize);
            this.tableLayoutPanelCards.ResumeLayout(false);
            this.panelStudents.ResumeLayout(false);
            this.panelStudents.PerformLayout();
            this.panelCourses.ResumeLayout(false);
            this.panelCourses.PerformLayout();
            this.panelEarnings.ResumeLayout(false);
            this.panelEarnings.PerformLayout();
            this.panelTests.ResumeLayout(false);
            this.panelTests.PerformLayout();
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

        //private void _SetupGunaPassRate(Guna.UI2.WinForms.Guna2ProgressBar pb, System.Windows.Forms.Label pct, string name, int y)
        //{
        //    System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
        //    lbl.Text = name;
        //    lbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        //    lbl.ForeColor = System.Drawing.Color.FromArgb(60, 60, 80);
        //    lbl.Location = new System.Drawing.Point(25, y);
        //    lbl.AutoSize = true;
        //    this.panelUpcoming.Controls.Add(lbl);

        //    pct.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        //    pct.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
        //    pct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        //    pct.Location = new System.Drawing.Point(340, y);
        //    pct.AutoSize = true;
        //    this.panelUpcoming.Controls.Add(pct);

        //    pb.Location = new System.Drawing.Point(25, y + 30);
        //    pb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        //    pb.Size = new System.Drawing.Size(360, 8);
        //    pb.BorderRadius = 4;
        //    pb.ProgressColor = System.Drawing.Color.FromArgb(94, 148, 255);
        //    pb.ProgressColor2 = System.Drawing.Color.FromArgb(94, 148, 255);
        //    pb.FillColor = System.Drawing.Color.FromArgb(235, 235, 245);
        //    this.panelUpcoming.Controls.Add(pb);
        //}

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
        private System.Windows.Forms.Label lblVision;
        private System.Windows.Forms.Label lblTheory;
        private System.Windows.Forms.Label lblRoad;
    }
}