namespace DVLDPresentationLayer.Schools_Dashboard.Forms
{
    partial class frmStudents
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
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle rowStyle    = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle altRowStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.lblPageTitle       = new System.Windows.Forms.Label();
            this.lblStudentCount    = new System.Windows.Forms.Label();
            this.txtSearch          = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2DataGridView1  = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnClose           = new Guna.UI2.WinForms.Guna2Button();

            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            this.SuspendLayout();

            // ─── PAGE HEADER ────────────────────────────────────────────────
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 50);
            this.lblPageTitle.Location = new System.Drawing.Point(18, 18);
            this.lblPageTitle.Text = "Students";

            this.lblStudentCount.AutoSize = true;
            this.lblStudentCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStudentCount.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.lblStudentCount.Location = new System.Drawing.Point(22, 58);
            this.lblStudentCount.Text = "0 student(s) found";

            // ─── SEARCH BOX (GUNA2) ─────────────────────────────────────────
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(208, 208, 208);
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(226, 226, 226);
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(138, 138, 138);
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(50, 50, 70);
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(94, 148, 255);
            this.txtSearch.Location = new System.Drawing.Point(630, 24);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "Search by name, course, phone...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(330, 40);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // ─── DATA GRID ──────────────────────────────────────────────────
            this.guna2DataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2DataGridView1.AllowUserToAddRows = false;
            this.guna2DataGridView1.AllowUserToDeleteRows = false;
            
            altRowStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = altRowStyle;

            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(100, 88, 255);
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = headerStyle;
            this.guna2DataGridView1.ColumnHeadersHeight = 40;

            rowStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            rowStyle.BackColor = System.Drawing.Color.White;
            rowStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            rowStyle.ForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
            rowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(231, 229, 255);
            rowStyle.SelectionForeColor = System.Drawing.Color.FromArgb(71, 69, 94);
            this.guna2DataGridView1.DefaultCellStyle = rowStyle;

            this.guna2DataGridView1.GridColor = System.Drawing.Color.FromArgb(231, 229, 255);
            this.guna2DataGridView1.Location = new System.Drawing.Point(20, 85);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.ReadOnly = true;
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.Size = new System.Drawing.Size(940, 540);
            this.guna2DataGridView1.TabIndex = 1;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 35;

            // ─── CLOSE BUTTON ───────────────────────────────────────────────
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BorderRadius = 5;
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(100, 88, 255);
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(860, 640);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // ─── FORM ───────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 249, 253);
            this.ClientSize = new System.Drawing.Size(981, 700);
            this.Controls.Add(this.lblPageTitle);
            this.Controls.Add(this.lblStudentCount);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.guna2DataGridView1);
            this.Controls.Add(this.btnClose);
            this.Name = "frmStudents";
            this.Text = "Students";
            this.Load += new System.EventHandler(this.frmStudents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblStudentCount;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}