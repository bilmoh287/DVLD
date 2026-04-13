namespace DVLDPresentationLayer
{
    partial class frmRegisterApplicant
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
            
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.btnAppClose = new Guna.UI2.WinForms.Guna2ControlBox();
            
            this.lblPersonalInfo = new System.Windows.Forms.Label();
            
            this.txtNationalNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtFirstName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSecondName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtLastName = new Guna.UI2.WinForms.Guna2TextBox();
            
            this.cmbGender = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtpDateOfBirth = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cmbNationality = new Guna.UI2.WinForms.Guna2ComboBox();
            
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnCreate = new Guna.UI2.WinForms.Guna2Button();

            this.SuspendLayout();

            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 15;
            this.guna2BorderlessForm1.ContainerControl = this;

            // btnAppClose
            this.btnAppClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAppClose.FillColor = System.Drawing.Color.Transparent;
            this.btnAppClose.IconColor = System.Drawing.Color.Gray;
            this.btnAppClose.Location = new System.Drawing.Point(540, 10);
            this.btnAppClose.Size = new System.Drawing.Size(40, 40);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Text = "Register New Applicant";

            // lblSubTitle
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubTitle.Location = new System.Drawing.Point(22, 55);
            this.lblSubTitle.Text = "Form A-2024-001 • Fill in all required fields";

            // lblPersonalInfo
            this.lblPersonalInfo.AutoSize = true;
            this.lblPersonalInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPersonalInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.lblPersonalInfo.Location = new System.Drawing.Point(20, 100);
            this.lblPersonalInfo.Text = "| PERSONAL INFORMATION";

            // txtNationalNo
            this.txtNationalNo.BorderRadius = 5;
            this.txtNationalNo.PlaceholderText = "National No. (e.g. N1234)";
            this.txtNationalNo.Location = new System.Drawing.Point(25, 140);
            this.txtNationalNo.Size = new System.Drawing.Size(260, 40);
            this.txtNationalNo.Font = new System.Drawing.Font("Segoe UI", 10F);

            // txtFirstName
            this.txtFirstName.BorderRadius = 5;
            this.txtFirstName.PlaceholderText = "First Name";
            this.txtFirstName.Location = new System.Drawing.Point(300, 140);
            this.txtFirstName.Size = new System.Drawing.Size(260, 40);
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 10F);

            // txtSecondName
            this.txtSecondName.BorderRadius = 5;
            this.txtSecondName.PlaceholderText = "Second Name";
            this.txtSecondName.Location = new System.Drawing.Point(25, 195);
            this.txtSecondName.Size = new System.Drawing.Size(260, 40);
            this.txtSecondName.Font = new System.Drawing.Font("Segoe UI", 10F);

            // txtLastName
            this.txtLastName.BorderRadius = 5;
            this.txtLastName.PlaceholderText = "Last Name";
            this.txtLastName.Location = new System.Drawing.Point(300, 195);
            this.txtLastName.Size = new System.Drawing.Size(260, 40);
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 10F);

            // cmbGender
            this.cmbGender.BorderRadius = 5;
            this.cmbGender.Items.AddRange(new object[] { "Male", "Female" });
            this.cmbGender.Location = new System.Drawing.Point(25, 250);
            this.cmbGender.Size = new System.Drawing.Size(260, 36);
            this.cmbGender.Font = new System.Drawing.Font("Segoe UI", 10F);

            // dtpDateOfBirth
            this.dtpDateOfBirth.BorderRadius = 5;
            this.dtpDateOfBirth.FillColor = System.Drawing.Color.White;
            this.dtpDateOfBirth.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.dtpDateOfBirth.BorderThickness = 1;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(300, 250);
            this.dtpDateOfBirth.Size = new System.Drawing.Size(260, 36);
            this.dtpDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 10F);

            // cmbNationality
            this.cmbNationality.BorderRadius = 5;
            this.cmbNationality.Items.AddRange(new object[] { "Ethiopia", "Palestine", "Djibouti", "Somalia", "Eritrea", "Kenya", "Sudan", "Yemen", "Other" });
            this.cmbNationality.Location = new System.Drawing.Point(25, 305);
            this.cmbNationality.Size = new System.Drawing.Size(535, 36);
            this.cmbNationality.Font = new System.Drawing.Font("Segoe UI", 10F);
            
            // txtAddress
            this.txtAddress.BorderRadius = 5;
            this.txtAddress.PlaceholderText = "Address";
            this.txtAddress.Location = new System.Drawing.Point(25, 360);
            this.txtAddress.Size = new System.Drawing.Size(535, 40);
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10F);

            // txtPhone
            this.txtPhone.BorderRadius = 5;
            this.txtPhone.PlaceholderText = "Phone Number (e.g. 09XXXXXXXX)";
            this.txtPhone.Location = new System.Drawing.Point(25, 415);
            this.txtPhone.Size = new System.Drawing.Size(260, 40);
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);

            // txtEmail
            this.txtEmail.BorderRadius = 5;
            this.txtEmail.PlaceholderText = "Email Address (Optional)";
            this.txtEmail.Location = new System.Drawing.Point(300, 415);
            this.txtEmail.Size = new System.Drawing.Size(260, 40);
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);

            // btnCancel
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.BorderColor = System.Drawing.Color.LightGray;
            this.btnCancel.BorderThickness = 1;
            this.btnCancel.FillColor = System.Drawing.Color.White;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(290, 500);
            this.btnCancel.Size = new System.Drawing.Size(120, 45);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // btnCreate
            this.btnCreate.BorderRadius = 5;
            this.btnCreate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCreate.Location = new System.Drawing.Point(420, 500);
            this.btnCreate.Size = new System.Drawing.Size(140, 45);
            this.btnCreate.Text = "Create Record";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);

            // 
            // frmRegisterApplicant
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(590, 570);
            this.Controls.Add(this.btnAppClose);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubTitle);
            this.Controls.Add(this.lblPersonalInfo);
            this.Controls.Add(this.txtNationalNo);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtSecondName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.dtpDateOfBirth);
            this.Controls.Add(this.cmbNationality);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRegisterApplicant";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register Applicant";
            this.Load += new System.EventHandler(this.frmRegisterApplicant_Load);
            
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private Guna.UI2.WinForms.Guna2ControlBox btnAppClose;
        private System.Windows.Forms.Label lblPersonalInfo;
        private Guna.UI2.WinForms.Guna2TextBox txtNationalNo;
        private Guna.UI2.WinForms.Guna2TextBox txtFirstName;
        private Guna.UI2.WinForms.Guna2TextBox txtSecondName;
        private Guna.UI2.WinForms.Guna2TextBox txtLastName;
        private Guna.UI2.WinForms.Guna2ComboBox cmbGender;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDateOfBirth;
        private Guna.UI2.WinForms.Guna2ComboBox cmbNationality;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private Guna.UI2.WinForms.Guna2TextBox txtPhone;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnCreate;
    }
}
