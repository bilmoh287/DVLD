namespace DVLDPresentationLayer.Main_Dashboard.User_Controls
{
    partial class ucDashboard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.kpiLayout = new System.Windows.Forms.TableLayoutPanel();
            this.contentLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblWelcome = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlKpi1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlKpi2 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlKpi3 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlKpi4 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlPendingTasks = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlQuickActions = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlRecentApps = new Guna.UI2.WinForms.Guna2Panel();
            this.layoutQuickActions = new System.Windows.Forms.TableLayoutPanel();
            this.btnNewApplicant = new Guna.UI2.WinForms.Guna2Button();
            this.btnNewApplication = new Guna.UI2.WinForms.Guna2Button();
            this.btnIssueLicense = new Guna.UI2.WinForms.Guna2Button();
            this.btnScheduleTest = new Guna.UI2.WinForms.Guna2Button();
            this.btnRenewLicense = new Guna.UI2.WinForms.Guna2Button();
            this.btnFindPerson = new Guna.UI2.WinForms.Guna2Button();
            this.lblQuickActions = new System.Windows.Forms.Label();

            this.mainLayout.SuspendLayout();
            this.kpiLayout.SuspendLayout();
            this.contentLayout.SuspendLayout();
            this.pnlQuickActions.SuspendLayout();
            this.layoutQuickActions.SuspendLayout();
            this.SuspendLayout();

            // mainLayout
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.lblTitle, 0, 0);
            this.mainLayout.Controls.Add(this.lblWelcome, 0, 1);
            this.mainLayout.Controls.Add(this.kpiLayout, 0, 2);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(1288, 730);

            // lblTitle
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Text = "Dashboard";

            // kpiLayout
            this.kpiLayout.ColumnCount = 4;
            this.kpiLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.kpiLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.kpiLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.kpiLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.kpiLayout.Controls.Add(this.pnlKpi1, 0, 0);
            this.kpiLayout.Controls.Add(this.pnlKpi2, 1, 0);
            this.kpiLayout.Controls.Add(this.pnlKpi3, 2, 0);
            this.kpiLayout.Controls.Add(this.pnlKpi4, 3, 0);
            this.kpiLayout.Dock = System.Windows.Forms.DockStyle.Fill;

            // pnlQuickActions
            this.pnlQuickActions.BorderRadius = 15;
            this.pnlQuickActions.FillColor = System.Drawing.Color.White;
            this.pnlQuickActions.Controls.Add(this.lblQuickActions);
            this.pnlQuickActions.Controls.Add(this.layoutQuickActions);
            this.pnlQuickActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuickActions.ShadowDecoration.Enabled = true;

            // layoutQuickActions
            this.layoutQuickActions.ColumnCount = 3;
            this.layoutQuickActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.layoutQuickActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.layoutQuickActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.layoutQuickActions.RowCount = 2;
            this.layoutQuickActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutQuickActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutQuickActions.Controls.Add(this.btnNewApplicant, 0, 0);
            this.layoutQuickActions.Controls.Add(this.btnNewApplication, 1, 0);
            this.layoutQuickActions.Controls.Add(this.btnIssueLicense, 2, 0);
            this.layoutQuickActions.Controls.Add(this.btnScheduleTest, 0, 1);
            this.layoutQuickActions.Controls.Add(this.btnRenewLicense, 1, 1);
            this.layoutQuickActions.Controls.Add(this.btnFindPerson, 2, 1);
            this.layoutQuickActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutQuickActions.Padding = new System.Windows.Forms.Padding(10, 40, 10, 10);

            // Button Styles (General)
            this.btnNewApplicant.BorderRadius = 8;
            this.btnNewApplicant.BorderThickness = 1;
            this.btnNewApplicant.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnNewApplicant.FillColor = System.Drawing.Color.White;
            this.btnNewApplicant.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.btnNewApplicant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNewApplicant.Text = "New Applicant";
            this.btnNewApplicant.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.btnNewApplication.BorderRadius = 8;
            this.btnNewApplication.BorderThickness = 1;
            this.btnNewApplication.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnNewApplication.FillColor = System.Drawing.Color.White;
            this.btnNewApplication.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.btnNewApplication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNewApplication.Text = "New Application";
            this.btnNewApplication.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.btnIssueLicense.BorderRadius = 8;
            this.btnIssueLicense.BorderThickness = 1;
            this.btnIssueLicense.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnIssueLicense.FillColor = System.Drawing.Color.White;
            this.btnIssueLicense.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.btnIssueLicense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnIssueLicense.Text = "Issue License";
            this.btnIssueLicense.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            // ucDashboard
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.Controls.Add(this.mainLayout);
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Size = new System.Drawing.Size(1328, 770);
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.kpiLayout.ResumeLayout(false);
            this.contentLayout.ResumeLayout(false);
            this.pnlQuickActions.ResumeLayout(false);
            this.pnlQuickActions.PerformLayout();
            this.layoutQuickActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.TableLayoutPanel kpiLayout;
        private System.Windows.Forms.TableLayoutPanel contentLayout;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblWelcome;
        private Guna.UI2.WinForms.Guna2Panel pnlKpi1;
        private Guna.UI2.WinForms.Guna2Panel pnlKpi2;
        private Guna.UI2.WinForms.Guna2Panel pnlKpi3;
        private Guna.UI2.WinForms.Guna2Panel pnlKpi4;
        private Guna.UI2.WinForms.Guna2Panel pnlPendingTasks;
        private Guna.UI2.WinForms.Guna2Panel pnlQuickActions;
        private Guna.UI2.WinForms.Guna2Panel pnlRecentApps;
        private System.Windows.Forms.TableLayoutPanel layoutQuickActions;
        private Guna.UI2.WinForms.Guna2Button btnNewApplicant;
        private Guna.UI2.WinForms.Guna2Button btnNewApplication;
        private Guna.UI2.WinForms.Guna2Button btnIssueLicense;
        private Guna.UI2.WinForms.Guna2Button btnScheduleTest;
        private Guna.UI2.WinForms.Guna2Button btnRenewLicense;
        private Guna.UI2.WinForms.Guna2Button btnFindPerson;
        private System.Windows.Forms.Label lblQuickActions;
    }
}
