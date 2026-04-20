namespace DVLDPresentationLayer.Schools_Dashboard.Forms
{
    partial class frmStudents
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
            System.Windows.Forms.DataGridViewCellStyle headerStyle  = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle rowStyle     = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle altRowStyle  = new System.Windows.Forms.DataGridViewCellStyle();

            this.lblPageTitle      = new System.Windows.Forms.Label();
            this.lblStudentCount   = new System.Windows.Forms.Label();
            this.panelSearch       = new System.Windows.Forms.Panel();
            this.txtSearch         = new System.Windows.Forms.TextBox();
            this.lblSearchIcon     = new System.Windows.Forms.Label();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnClose          = new Guna.UI2.WinForms.Guna2Button();

            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            this.SuspendLayout();

            // ── Page title ───────────────────────────────────────────────────
            this.lblPageTitle.AutoSize  = true;
            this.lblPageTitle.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 50);
            this.lblPageTitle.Location  = new System.Drawing.Point(18, 18);
            this.lblPageTitle.Name      = "lblPageTitle";
            this.lblPageTitle.Text      = "Students";

            // ── Student count ────────────────────────────────────────────────
            this.lblStudentCount.AutoSize  = true;
            this.lblStudentCount.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStudentCount.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            this.lblStudentCount.Location  = new System.Drawing.Point(22, 52);
            this.lblStudentCount.Name      = "lblStudentCount";
            this.lblStudentCount.Text      = "Loading...";

            // ── Search panel ─────────────────────────────────────────────────
            this.panelSearch.BackColor    = System.Drawing.Color.White;
            this.panelSearch.BorderStyle  = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSearch.Location     = new System.Drawing.Point(610, 24);
            this.panelSearch.Name         = "panelSearch";
            this.panelSearch.Size         = new System.Drawing.Size(350, 36);
            this.panelSearch.TabIndex     = 10;
            this.panelSearch.Controls.Add(this.txtSearch);
            this.panelSearch.Controls.Add(this.lblSearchIcon);

            this.lblSearchIcon.AutoSize  = false;
            this.lblSearchIcon.Font      = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSearchIcon.ForeColor = System.Drawing.Color.FromArgb(150, 150, 170);
            this.lblSearchIcon.Location  = new System.Drawing.Point(6, 4);
            this.lblSearchIcon.Name      = "lblSearchIcon";
            this.lblSearchIcon.Size      = new System.Drawing.Size(24, 24);
            this.lblSearchIcon.Text      = "🔍";

            this.txtSearch.BorderStyle    = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font           = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor      = System.Drawing.Color.FromArgb(50, 50, 70);
            this.txtSearch.Location       = new System.Drawing.Point(34, 7);
            this.txtSearch.Name           = "txtSearch";
            this.txtSearch.PlaceholderText = "Search by name, course, or phone…";
            this.txtSearch.Size           = new System.Drawing.Size(310, 22);
            this.txtSearch.TabIndex       = 0;
            this.txtSearch.TextChanged   += new System.EventHandler(this.txtSearch_TextChanged);

            // ── DataGridView ─────────────────────────────────────────────────
            altRowStyle.BackColor  = System.Drawing.Color.White;

            headerStyle.Alignment        = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor        = System.Drawing.Color.FromArgb(100, 88, 255);
            headerStyle.Font             = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor        = System.Drawing.Color.White;
            headerStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            headerStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;

            rowStyle.Alignment           = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            rowStyle.BackColor           = System.Drawing.Color.White;
            rowStyle.Font                = new System.Drawing.Font("Segoe UI", 9F);
            rowStyle.ForeColor           = System.Drawing.Color.FromArgb(71, 69, 94);
            rowStyle.SelectionBackColor  = System.Drawing.Color.FromArgb(231, 229, 255);
            rowStyle.SelectionForeColor  = System.Drawing.Color.FromArgb(71, 69, 94);

            this.guna2DataGridView1.AllowUserToAddRows               = false;
            this.guna2DataGridView1.AllowUserToDeleteRows            = false;
            this.guna2DataGridView1.AllowUserToOrderColumns          = true;
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle  = altRowStyle;
            this.guna2DataGridView1.BackgroundColor                  = System.Drawing.Color.FromArgb(245, 246, 250);
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle    = headerStyle;
            this.guna2DataGridView1.ColumnHeadersHeightSizeMode      = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisabledResizing;
            this.guna2DataGridView1.ColumnHeadersHeight              = 36;
            this.guna2DataGridView1.ColumnHeadersBorderStyle         = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView1.DefaultCellStyle                 = rowStyle;
            this.guna2DataGridView1.GridColor                        = System.Drawing.Color.FromArgb(231, 229, 255);
            this.guna2DataGridView1.Location                         = new System.Drawing.Point(0, 76);
            this.guna2DataGridView1.Name                             = "guna2DataGridView1";
            this.guna2DataGridView1.ReadOnly                         = true;
            this.guna2DataGridView1.RowHeadersVisible                = false;
            this.guna2DataGridView1.RowTemplate.Height               = 32;
            this.guna2DataGridView1.AutoSizeColumnsMode              = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.guna2DataGridView1.Size                             = new System.Drawing.Size(981, 558);
            this.guna2DataGridView1.TabIndex                         = 0;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor   = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font        = null;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor   = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.BackColor                        = System.Drawing.Color.FromArgb(245, 246, 250);
            this.guna2DataGridView1.ThemeStyle.GridColor                        = System.Drawing.Color.FromArgb(231, 229, 255);
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor            = System.Drawing.Color.FromArgb(100, 88, 255);
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle          = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font                 = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor            = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode      = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisabledResizing;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height               = 36;
            this.guna2DataGridView1.ThemeStyle.ReadOnly                         = true;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor              = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle            = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font                   = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor              = System.Drawing.Color.FromArgb(71, 69, 94);
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height                 = 32;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor     = System.Drawing.Color.FromArgb(231, 229, 255);
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor     = System.Drawing.Color.FromArgb(71, 69, 94);

            // ── Close button ─────────────────────────────────────────────────
            this.btnClose.DisabledState.BorderColor       = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor         = System.Drawing.Color.FromArgb(169, 169, 169);
            this.btnClose.DisabledState.ForeColor         = System.Drawing.Color.FromArgb(141, 141, 141);
            this.btnClose.FillColor                       = System.Drawing.Color.FromArgb(100, 88, 255);
            this.btnClose.Font                            = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor                       = System.Drawing.Color.White;
            this.btnClose.Location                        = new System.Drawing.Point(866, 650);
            this.btnClose.Name                            = "btnClose";
            this.btnClose.Size                            = new System.Drawing.Size(103, 37);
            this.btnClose.TabIndex                        = 1;
            this.btnClose.Text                            = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // ── Form ─────────────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(245, 246, 250);
            this.ClientSize          = new System.Drawing.Size(981, 700);
            this.Name                = "frmStudents";
            this.Text                = "Students";
            this.Controls.Add(this.lblPageTitle);
            this.Controls.Add(this.lblStudentCount);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.guna2DataGridView1);
            this.Controls.Add(this.btnClose);
            this.Load += new System.EventHandler(this.frmStudents_Load);

            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label   lblPageTitle;
        private System.Windows.Forms.Label   lblStudentCount;
        private System.Windows.Forms.Panel   panelSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label   lblSearchIcon;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private Guna.UI2.WinForms.Guna2Button       btnClose;
    }
}