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
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(319, 37);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Register New Applicant";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubTitle.Location = new System.Drawing.Point(22, 55);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(294, 20);
            this.lblSubTitle.TabIndex = 2;
            this.lblSubTitle.Text = "Form A-2024-001 • Fill in all required fields";
            // 
            // btnAppClose
            // 
            this.btnAppClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAppClose.FillColor = System.Drawing.Color.Transparent;
            this.btnAppClose.IconColor = System.Drawing.Color.Gray;
            this.btnAppClose.Location = new System.Drawing.Point(540, 10);
            this.btnAppClose.Name = "btnAppClose";
            this.btnAppClose.Size = new System.Drawing.Size(40, 40);
            this.btnAppClose.TabIndex = 0;
            // 
            // lblPersonalInfo
            // 
            this.lblPersonalInfo.AutoSize = true;
            this.lblPersonalInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPersonalInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.lblPersonalInfo.Location = new System.Drawing.Point(20, 100);
            this.lblPersonalInfo.Name = "lblPersonalInfo";
            this.lblPersonalInfo.Size = new System.Drawing.Size(232, 23);
            this.lblPersonalInfo.TabIndex = 3;
            this.lblPersonalInfo.Text = "| PERSONAL INFORMATION";
            // 
            // txtNationalNo
            // 
            this.txtNationalNo.BorderRadius = 5;
            this.txtNationalNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNationalNo.DefaultText = "";
            this.txtNationalNo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNationalNo.Location = new System.Drawing.Point(28, 161);
            this.txtNationalNo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtNationalNo.Name = "txtNationalNo";
            this.txtNationalNo.PlaceholderText = "National No. (e.g. N1234)";
            this.txtNationalNo.SelectedText = "";
            this.txtNationalNo.Size = new System.Drawing.Size(292, 46);
            this.txtNationalNo.TabIndex = 4;
            // 
            // txtFirstName
            // 
            this.txtFirstName.BorderRadius = 5;
            this.txtFirstName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFirstName.DefaultText = "";
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFirstName.Location = new System.Drawing.Point(338, 161);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.PlaceholderText = "First Name";
            this.txtFirstName.SelectedText = "";
            this.txtFirstName.Size = new System.Drawing.Size(292, 46);
            this.txtFirstName.TabIndex = 5;
            // 
            // txtSecondName
            // 
            this.txtSecondName.BorderRadius = 5;
            this.txtSecondName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSecondName.DefaultText = "";
            this.txtSecondName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSecondName.Location = new System.Drawing.Point(28, 224);
            this.txtSecondName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtSecondName.Name = "txtSecondName";
            this.txtSecondName.PlaceholderText = "Second Name";
            this.txtSecondName.SelectedText = "";
            this.txtSecondName.Size = new System.Drawing.Size(292, 46);
            this.txtSecondName.TabIndex = 6;
            // 
            // txtLastName
            // 
            this.txtLastName.BorderRadius = 5;
            this.txtLastName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLastName.DefaultText = "";
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLastName.Location = new System.Drawing.Point(338, 224);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.PlaceholderText = "Last Name";
            this.txtLastName.SelectedText = "";
            this.txtLastName.Size = new System.Drawing.Size(292, 46);
            this.txtLastName.TabIndex = 7;
            // 
            // cmbGender
            // 
            this.cmbGender.BackColor = System.Drawing.Color.Transparent;
            this.cmbGender.BorderRadius = 5;
            this.cmbGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FocusedColor = System.Drawing.Color.Empty;
            this.cmbGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbGender.ItemHeight = 30;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbGender.Location = new System.Drawing.Point(25, 250);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(260, 36);
            this.cmbGender.TabIndex = 8;
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.dtpDateOfBirth.BorderRadius = 5;
            this.dtpDateOfBirth.BorderThickness = 1;
            this.dtpDateOfBirth.Checked = true;
            this.dtpDateOfBirth.FillColor = System.Drawing.Color.White;
            this.dtpDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(300, 250);
            this.dtpDateOfBirth.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDateOfBirth.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(260, 36);
            this.dtpDateOfBirth.TabIndex = 9;
            this.dtpDateOfBirth.Value = new System.DateTime(2026, 5, 20, 2, 17, 19, 818);
            // 
            // cmbNationality
            // 
            this.cmbNationality.BackColor = System.Drawing.Color.Transparent;
            this.cmbNationality.BorderRadius = 5;
            this.cmbNationality.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbNationality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNationality.FocusedColor = System.Drawing.Color.Empty;
            this.cmbNationality.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbNationality.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbNationality.ItemHeight = 30;
            this.cmbNationality.Items.AddRange(new object[] {
            "Ethiopia",
            "Palestine",
            "Djibouti",
            "Somalia",
            "Eritrea",
            "Kenya",
            "Sudan",
            "Yemen",
            "Other"});
            this.cmbNationality.Location = new System.Drawing.Point(25, 305);
            this.cmbNationality.Name = "cmbNationality";
            this.cmbNationality.Size = new System.Drawing.Size(535, 36);
            this.cmbNationality.TabIndex = 10;
            // 
            // txtAddress
            // 
            this.txtAddress.BorderRadius = 5;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.DefaultText = "";
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAddress.Location = new System.Drawing.Point(28, 414);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PlaceholderText = "Address";
            this.txtAddress.SelectedText = "";
            this.txtAddress.Size = new System.Drawing.Size(602, 46);
            this.txtAddress.TabIndex = 11;
            // 
            // txtPhone
            // 
            this.txtPhone.BorderRadius = 5;
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhone.DefaultText = "";
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhone.Location = new System.Drawing.Point(28, 477);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PlaceholderText = "Phone Number (e.g. 09XXXXXXXX)";
            this.txtPhone.SelectedText = "";
            this.txtPhone.Size = new System.Drawing.Size(292, 46);
            this.txtPhone.TabIndex = 12;
            // 
            // txtEmail
            // 
            this.txtEmail.BorderRadius = 5;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(338, 477);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "Email Address (Optional)";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(292, 46);
            this.txtEmail.TabIndex = 13;
            // 
            // btnCancel
            // 
            this.btnCancel.BorderColor = System.Drawing.Color.LightGray;
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.BorderThickness = 1;
            this.btnCancel.FillColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(290, 500);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 45);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.BorderRadius = 5;
            this.btnCreate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.btnCreate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(420, 500);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(140, 45);
            this.btnCreate.TabIndex = 15;
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
