namespace DVLDPresentationLayer
{
    partial class frmRegistration
    {
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            // Declare components
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.pnlSidebar = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSidebarTitle = new System.Windows.Forms.Label();
            this.btnNavApplicants = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavApplications = new Guna.UI2.WinForms.Guna2Button();
            this.btnNavVerification = new Guna.UI2.WinForms.Guna2Button();
            
            this.pnlContent = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.btnAppClose = new Guna.UI2.WinForms.Guna2ControlBox();
            
            this.pnlCard1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblC1Title = new System.Windows.Forms.Label();
            this.lblC1Value = new System.Windows.Forms.Label();
            
            this.pnlCard2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblC2Title = new System.Windows.Forms.Label();
            this.lblC2Value = new System.Windows.Forms.Label();
            
            this.pnlCard3 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblC3Title = new System.Windows.Forms.Label();
            this.lblC3Value = new System.Windows.Forms.Label();
            
            this.btnAddApplicant = new Guna.UI2.WinForms.Guna2Button();
            this.dgvApplicants = new Guna.UI2.WinForms.Guna2DataGridView();

            this.pnlSidebar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlCard1.SuspendLayout();
            this.pnlCard2.SuspendLayout();
            this.pnlCard3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicants)).BeginInit();
            this.SuspendLayout();

            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 15;
            this.guna2BorderlessForm1.ContainerControl = this;

            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.pnlSidebar.Controls.Add(this.lblSidebarTitle);
            this.pnlSidebar.Controls.Add(this.btnNavApplicants);
            this.pnlSidebar.Controls.Add(this.btnNavApplications);
            this.pnlSidebar.Controls.Add(this.btnNavVerification);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(220, 720);

            // 
            // lblSidebarTitle
            // 
            this.lblSidebarTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSidebarTitle.ForeColor = System.Drawing.Color.White;
            this.lblSidebarTitle.Location = new System.Drawing.Point(20, 20);
            this.lblSidebarTitle.Name = "lblSidebarTitle";
            this.lblSidebarTitle.Size = new System.Drawing.Size(180, 50);
            this.lblSidebarTitle.Text = "DVLD\nManagement System";

            // 
            // btnNavApplicants
            // 
            this.btnNavApplicants.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.btnNavApplicants.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavApplicants.ForeColor = System.Drawing.Color.White;
            this.btnNavApplicants.Location = new System.Drawing.Point(10, 100);
            this.btnNavApplicants.Name = "btnNavApplicants";
            this.btnNavApplicants.Size = new System.Drawing.Size(200, 40);
            this.btnNavApplicants.Text = "Applicants";
            this.btnNavApplicants.BorderRadius = 8;

            // btnNavApplications
            this.btnNavApplications.FillColor = System.Drawing.Color.Transparent;
            this.btnNavApplications.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavApplications.ForeColor = System.Drawing.Color.Gray;
            this.btnNavApplications.Location = new System.Drawing.Point(10, 150);
            this.btnNavApplications.Name = "btnNavApplications";
            this.btnNavApplications.Size = new System.Drawing.Size(200, 40);
            this.btnNavApplications.Text = "Applications";
            
            // btnNavVerification
            this.btnNavVerification.FillColor = System.Drawing.Color.Transparent;
            this.btnNavVerification.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNavVerification.ForeColor = System.Drawing.Color.Gray;
            this.btnNavVerification.Location = new System.Drawing.Point(10, 200);
            this.btnNavVerification.Name = "btnNavVerification";
            this.btnNavVerification.Size = new System.Drawing.Size(200, 40);
            this.btnNavVerification.Text = "Verification";

            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlContent.Controls.Add(this.pnlHeader);
            this.pnlContent.Controls.Add(this.pnlCard1);
            this.pnlContent.Controls.Add(this.pnlCard2);
            this.pnlContent.Controls.Add(this.pnlCard3);
            this.pnlContent.Controls.Add(this.btnAddApplicant);
            this.pnlContent.Controls.Add(this.dgvApplicants);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(220, 0);
            this.pnlContent.Name = "pnlContent";

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Controls.Add(this.btnAppClose);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 60;

            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.lblHeaderTitle.Location = new System.Drawing.Point(20, 15);
            this.lblHeaderTitle.Text = "Registration & Application Management";

            // btnAppClose
            this.btnAppClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAppClose.FillColor = System.Drawing.Color.Transparent;
            this.btnAppClose.IconColor = System.Drawing.Color.Black;
            this.btnAppClose.Location = new System.Drawing.Point(1000, 10);
            this.btnAppClose.Size = new System.Drawing.Size(40, 40);

            // Cards Configuration
            // Card 1
            this.pnlCard1.BorderRadius = 10;
            this.pnlCard1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.pnlCard1.Location = new System.Drawing.Point(20, 80);
            this.pnlCard1.Size = new System.Drawing.Size(300, 100);
            this.pnlCard1.Controls.Add(this.lblC1Title);
            this.pnlCard1.Controls.Add(this.lblC1Value);
            
            this.lblC1Title.Text = "New Registrations";
            this.lblC1Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(165)))), ((int)(((byte)(50)))));
            this.lblC1Title.Location = new System.Drawing.Point(15, 15);
            this.lblC1Title.Font = new System.Drawing.Font("Segoe UI", 10F);
            
            this.lblC1Value.Text = "4";
            this.lblC1Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(165)))), ((int)(((byte)(50)))));
            this.lblC1Value.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblC1Value.Location = new System.Drawing.Point(15, 40);
            this.lblC1Value.AutoSize = true;

            // Card 2
            this.pnlCard2.BorderRadius = 10;
            this.pnlCard2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.pnlCard2.Location = new System.Drawing.Point(340, 80);
            this.pnlCard2.Size = new System.Drawing.Size(300, 100);
            this.pnlCard2.Controls.Add(this.lblC2Title);
            this.pnlCard2.Controls.Add(this.lblC2Value);
            
            this.lblC2Title.Text = "Under Review";
            this.lblC2Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.lblC2Title.Location = new System.Drawing.Point(15, 15);
            this.lblC2Title.Font = new System.Drawing.Font("Segoe UI", 10F);
            
            this.lblC2Value.Text = "2";
            this.lblC2Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.lblC2Value.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblC2Value.Location = new System.Drawing.Point(15, 40);
            this.lblC2Value.AutoSize = true;

            // Card 3
            this.pnlCard3.BorderRadius = 10;
            this.pnlCard3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(252)))), ((int)(((byte)(243)))));
            this.pnlCard3.Location = new System.Drawing.Point(660, 80);
            this.pnlCard3.Size = new System.Drawing.Size(300, 100);
            this.pnlCard3.Controls.Add(this.lblC3Title);
            this.pnlCard3.Controls.Add(this.lblC3Value);
            
            this.lblC3Title.Text = "Verified Students";
            this.lblC3Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(160)))), ((int)(((byte)(80)))));
            this.lblC3Title.Location = new System.Drawing.Point(15, 15);
            this.lblC3Title.Font = new System.Drawing.Font("Segoe UI", 10F);
            
            this.lblC3Value.Text = "1";
            this.lblC3Value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(160)))), ((int)(((byte)(80)))));
            this.lblC3Value.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblC3Value.Location = new System.Drawing.Point(15, 40);
            this.lblC3Value.AutoSize = true;

            // btnAddApplicant
            this.btnAddApplicant.BorderRadius = 5;
            this.btnAddApplicant.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.btnAddApplicant.BorderThickness = 1;
            this.btnAddApplicant.FillColor = System.Drawing.Color.White;
            this.btnAddApplicant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.btnAddApplicant.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddApplicant.Location = new System.Drawing.Point(20, 240);
            this.btnAddApplicant.Size = new System.Drawing.Size(160, 40);
            this.btnAddApplicant.Text = "+ New Applicant";
            this.btnAddApplicant.Click += new System.EventHandler(this.btnAddApplicant_Click);

            // dgvApplicants
            this.dgvApplicants.Location = new System.Drawing.Point(20, 300);
            this.dgvApplicants.Size = new System.Drawing.Size(1000, 380);
            this.dgvApplicants.BackgroundColor = System.Drawing.Color.White;
            this.dgvApplicants.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvApplicants.RowHeadersVisible = false;
            this.dgvApplicants.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvApplicants.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Gray;
            this.dgvApplicants.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvApplicants.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.dgvApplicants.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;

            // 
            // frmRegistration
            // 
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration Management";
            this.Load += new System.EventHandler(this.frmRegistration_Load);
            
            this.pnlSidebar.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCard1.ResumeLayout(false);
            this.pnlCard2.ResumeLayout(false);
            this.pnlCard3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicants)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel pnlSidebar;
        private System.Windows.Forms.Label lblSidebarTitle;
        private Guna.UI2.WinForms.Guna2Button btnNavApplicants;
        private Guna.UI2.WinForms.Guna2Button btnNavApplications;
        private Guna.UI2.WinForms.Guna2Button btnNavVerification;

        private Guna.UI2.WinForms.Guna2Panel pnlContent;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private Guna.UI2.WinForms.Guna2ControlBox btnAppClose;
        
        private Guna.UI2.WinForms.Guna2Panel pnlCard1;
        private System.Windows.Forms.Label lblC1Title;
        private System.Windows.Forms.Label lblC1Value;
        
        private Guna.UI2.WinForms.Guna2Panel pnlCard2;
        private System.Windows.Forms.Label lblC2Title;
        private System.Windows.Forms.Label lblC2Value;
        
        private Guna.UI2.WinForms.Guna2Panel pnlCard3;
        private System.Windows.Forms.Label lblC3Title;
        private System.Windows.Forms.Label lblC3Value;

        private Guna.UI2.WinForms.Guna2Button btnAddApplicant;
        private Guna.UI2.WinForms.Guna2DataGridView dgvApplicants;
    }
}
