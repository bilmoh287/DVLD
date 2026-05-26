namespace DVLDPresentationLayer
{
    partial class frmAddUpdateDrivingInstitutes
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblInstituteName = new System.Windows.Forms.Label();
            this.txtInstituteName = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInstituteID = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.lblCommLicense = new System.Windows.Forms.Label();
            this.txtCommercialLicenseNo = new System.Windows.Forms.TextBox();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.dtpLicenseExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.lblManager = new System.Windows.Forms.Label();
            this.lblManagerName = new System.Windows.Forms.Label();
            this.llSelectManager = new System.Windows.Forms.LinkLabel();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.numCapacity = new System.Windows.Forms.NumericUpDown();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.llSetLogo = new System.Windows.Forms.LinkLabel();
            this.llRemoveLogo = new System.Windows.Forms.LinkLabel();
            this.lblDocumentFileName = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pnlDocument = new System.Windows.Forms.Panel();
            this.lblDragInfo = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlDocument.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(103, 239);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(67, 25);
            this.lblEmail.TabIndex = 119;
            this.lblEmail.Text = "Emai:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(103, 190);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(81, 25);
            this.lblPhone.TabIndex = 118;
            this.lblPhone.Text = "Phone:";
            // 
            // lblInstituteName
            // 
            this.lblInstituteName.AutoSize = true;
            this.lblInstituteName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstituteName.Location = new System.Drawing.Point(52, 132);
            this.lblInstituteName.Name = "lblInstituteName";
            this.lblInstituteName.Size = new System.Drawing.Size(151, 25);
            this.lblInstituteName.TabIndex = 116;
            this.lblInstituteName.Text = "Institue Name:";
            this.lblInstituteName.Click += new System.EventHandler(this.label13_Click);
            // 
            // txtInstituteName
            // 
            this.txtInstituteName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInstituteName.Location = new System.Drawing.Point(249, 134);
            this.txtInstituteName.Multiline = true;
            this.txtInstituteName.Name = "txtInstituteName";
            this.txtInstituteName.Size = new System.Drawing.Size(249, 33);
            this.txtInstituteName.TabIndex = 130;
            this.txtInstituteName.Validating += new System.ComponentModel.CancelEventHandler(this.txtInstituteName_Validating);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLDPresentationLayer.Properties.Resources.Email_32;
            this.pictureBox4.Location = new System.Drawing.Point(211, 238);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(31, 26);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 128;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLDPresentationLayer.Properties.Resources.Man_32;
            this.pictureBox2.Location = new System.Drawing.Point(211, 190);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 127;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLDPresentationLayer.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(212, 379);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 126;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::DVLDPresentationLayer.Properties.Resources.Person_32;
            this.pictureBox8.Location = new System.Drawing.Point(212, 134);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(31, 26);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 125;
            this.pictureBox8.TabStop = false;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(104, 376);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(99, 25);
            this.lblAddress.TabIndex = 117;
            this.lblAddress.Text = "Address:";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(249, 374);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(249, 33);
            this.txtAddress.TabIndex = 132;
            this.txtAddress.Validating += new System.ComponentModel.CancelEventHandler(this.txtAddress_Validating);
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(249, 185);
            this.txtPhone.Multiline = true;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(249, 33);
            this.txtPhone.TabIndex = 133;
            this.txtPhone.Validating += new System.ComponentModel.CancelEventHandler(this.txtPhone_Validating);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(249, 233);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(249, 33);
            this.txtEmail.TabIndex = 134;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsActive.Location = new System.Drawing.Point(192, 438);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(117, 29);
            this.chkIsActive.TabIndex = 4;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(506, 475);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 36);
            this.btnSave.TabIndex = 135;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(87, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 136;
            this.label1.Text = "Institue ID:";
            // 
            // lblInstituteID
            // 
            this.lblInstituteID.AutoSize = true;
            this.lblInstituteID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstituteID.Location = new System.Drawing.Point(244, 89);
            this.lblInstituteID.Name = "lblInstituteID";
            this.lblInstituteID.Size = new System.Drawing.Size(36, 25);
            this.lblInstituteID.TabIndex = 137;
            this.lblInstituteID.Text = "??";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(358, 475);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(130, 36);
            this.btnClose.TabIndex = 138;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblCommLicense
            // 
            this.lblCommLicense.AutoSize = true;
            this.lblCommLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommLicense.Location = new System.Drawing.Point(612, 89);
            this.lblCommLicense.Name = "lblCommLicense";
            this.lblCommLicense.Size = new System.Drawing.Size(168, 25);
            this.lblCommLicense.TabIndex = 139;
            this.lblCommLicense.Text = "Comm. License:";
            // 
            // txtCommercialLicenseNo
            // 
            this.txtCommercialLicenseNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txtCommercialLicenseNo.Location = new System.Drawing.Point(792, 85);
            this.txtCommercialLicenseNo.Name = "txtCommercialLicenseNo";
            this.txtCommercialLicenseNo.Size = new System.Drawing.Size(249, 27);
            this.txtCommercialLicenseNo.TabIndex = 140;
            this.txtCommercialLicenseNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtCommercialLicenseNo_Validating);
            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblExpiryDate.Location = new System.Drawing.Point(612, 132);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new System.Drawing.Size(130, 25);
            this.lblExpiryDate.TabIndex = 141;
            this.lblExpiryDate.Text = "Expiry Date:";
            // 
            // dtpLicenseExpiryDate
            // 
            this.dtpLicenseExpiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.dtpLicenseExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLicenseExpiryDate.Location = new System.Drawing.Point(792, 132);
            this.dtpLicenseExpiryDate.Name = "dtpLicenseExpiryDate";
            this.dtpLicenseExpiryDate.Size = new System.Drawing.Size(220, 27);
            this.dtpLicenseExpiryDate.TabIndex = 142;
            // 
            // lblManager
            // 
            this.lblManager.AutoSize = true;
            this.lblManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblManager.Location = new System.Drawing.Point(612, 180);
            this.lblManager.Name = "lblManager";
            this.lblManager.Size = new System.Drawing.Size(104, 25);
            this.lblManager.TabIndex = 143;
            this.lblManager.Text = "Manager:";
            // 
            // 
            // lblManagerName
            // 
            this.lblManagerName.AutoSize = true;
            this.lblManagerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManagerName.Location = new System.Drawing.Point(792, 180);
            this.lblManagerName.Name = "lblManagerName";
            this.lblManagerName.Size = new System.Drawing.Size(48, 25);
            this.lblManagerName.TabIndex = 144;
            this.lblManagerName.Text = "N/A";
            // 
            // llSelectManager
            // 
            this.llSelectManager.AutoSize = true;
            this.llSelectManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llSelectManager.Location = new System.Drawing.Point(920, 182);
            this.llSelectManager.Name = "llSelectManager";
            this.llSelectManager.Size = new System.Drawing.Size(95, 20);
            this.llSelectManager.TabIndex = 145;
            this.llSelectManager.TabStop = true;
            this.llSelectManager.Text = "Select/Add";
            this.llSelectManager.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSelectManager_LinkClicked);
            this.llSelectManager.Validating += new System.ComponentModel.CancelEventHandler(this.llSelectManager_Validating);
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblCapacity.Location = new System.Drawing.Point(612, 227);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(104, 25);
            this.lblCapacity.TabIndex = 145;
            this.lblCapacity.Text = "Capacity:";
            // 
            // numCapacity
            // 
            this.numCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.numCapacity.Location = new System.Drawing.Point(792, 227);
            this.numCapacity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCapacity.Name = "numCapacity";
            this.numCapacity.Size = new System.Drawing.Size(100, 27);
            this.numCapacity.TabIndex = 146;
            // 
            // pbLogo
            // 
            this.pbLogo.AllowDrop = true;
            this.pbLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLogo.Location = new System.Drawing.Point(912, 276);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(100, 100);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 147;
            this.pbLogo.TabStop = false;
            this.pbLogo.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbLogo_DragDrop);
            this.pbLogo.DragEnter += new System.Windows.Forms.DragEventHandler(this.ctrl_DragEnter);
            // 
            // llSetLogo
            // 
            this.llSetLogo.AutoSize = true;
            this.llSetLogo.Location = new System.Drawing.Point(885, 385);
            this.llSetLogo.Name = "llSetLogo";
            this.llSetLogo.Size = new System.Drawing.Size(61, 16);
            this.llSetLogo.TabIndex = 148;
            this.llSetLogo.TabStop = true;
            this.llSetLogo.Text = "Set Logo";
            this.llSetLogo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSetLogo_LinkClicked);
            // 
            // llRemoveLogo
            // 
            this.llRemoveLogo.AutoSize = true;
            this.llRemoveLogo.Location = new System.Drawing.Point(958, 385);
            this.llRemoveLogo.Name = "llRemoveLogo";
            this.llRemoveLogo.Size = new System.Drawing.Size(59, 16);
            this.llRemoveLogo.TabIndex = 149;
            this.llRemoveLogo.TabStop = true;
            this.llRemoveLogo.Text = "Remove";
            this.llRemoveLogo.Visible = false;
            this.llRemoveLogo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llRemoveLogo_LinkClicked);
            // 
            // lblDocumentFileName
            // 
            this.lblDocumentFileName.Location = new System.Drawing.Point(3, 45);
            this.lblDocumentFileName.Name = "lblDocumentFileName";
            this.lblDocumentFileName.Size = new System.Drawing.Size(271, 48);
            this.lblDocumentFileName.TabIndex = 0;
            this.lblDocumentFileName.Text = "No file";
            this.lblDocumentFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pnlDocument
            // 
            this.pnlDocument.AllowDrop = true;
            this.pnlDocument.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDocument.Controls.Add(this.lblDocumentFileName);
            this.pnlDocument.Controls.Add(this.lblDragInfo);
            this.pnlDocument.Location = new System.Drawing.Point(617, 275);
            this.pnlDocument.Name = "pnlDocument";
            this.pnlDocument.Size = new System.Drawing.Size(275, 100);
            this.pnlDocument.TabIndex = 150;
            this.pnlDocument.Click += new System.EventHandler(this.pnlDocument_Click);
            this.pnlDocument.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlDocument_DragDrop);
            this.pnlDocument.DragEnter += new System.Windows.Forms.DragEventHandler(this.ctrl_DragEnter);
            // 
            // lblDragInfo
            // 
            this.lblDragInfo.Location = new System.Drawing.Point(3, 5);
            this.lblDragInfo.Name = "lblDragInfo";
            this.lblDragInfo.Size = new System.Drawing.Size(259, 40);
            this.lblDragInfo.TabIndex = 1;
            this.lblDragInfo.Text = "Drag Docs Here or Click";
            this.lblDragInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Lucida Sans", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(332, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(367, 65);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Add Driving Institue";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCity
            // 
            this.txtCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCity.Location = new System.Drawing.Point(249, 327);
            this.txtCity.Multiline = true;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(249, 33);
            this.txtCity.TabIndex = 156;
            this.txtCity.Validating += new System.ComponentModel.CancelEventHandler(this.txtCity_Validating);
            // 
            // txtRegion
            // 
            this.txtRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegion.Location = new System.Drawing.Point(249, 279);
            this.txtRegion.Multiline = true;
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(249, 33);
            this.txtRegion.TabIndex = 155;
            this.txtRegion.Validating += new System.ComponentModel.CancelEventHandler(this.txtRegion_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(103, 333);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 25);
            this.label2.TabIndex = 152;
            this.label2.Text = "City:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(103, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 25);
            this.label3.TabIndex = 151;
            this.label3.Text = "Region:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLDPresentationLayer.Properties.Resources.Email_32;
            this.pictureBox3.Location = new System.Drawing.Point(211, 332);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 26);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 154;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLDPresentationLayer.Properties.Resources.Man_32;
            this.pictureBox5.Location = new System.Drawing.Point(211, 284);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(31, 26);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 153;
            this.pictureBox5.TabStop = false;
            // 
            // frmAddUpdateDrivingInstitutes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1069, 532);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtRegion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblInstituteID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblInstituteName);
            this.Controls.Add(this.txtInstituteName);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblCommLicense);
            this.Controls.Add(this.txtCommercialLicenseNo);
            this.Controls.Add(this.lblExpiryDate);
            this.Controls.Add(this.dtpLicenseExpiryDate);
            this.Controls.Add(this.lblManager);
            this.Controls.Add(this.lblManagerName);
            this.Controls.Add(this.llSelectManager);
            this.Controls.Add(this.lblCapacity);
            this.Controls.Add(this.numCapacity);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.llSetLogo);
            this.Controls.Add(this.llRemoveLogo);
            this.Controls.Add(this.pnlDocument);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddUpdateDrivingInstitutes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ManageDrivingInstitute";
            this.Load += new System.EventHandler(this.frmAddUpdateDrivingInstitutes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlDocument.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblInstituteName;
        private System.Windows.Forms.TextBox txtInstituteName;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInstituteID;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCommLicense;
        private System.Windows.Forms.TextBox txtCommercialLicenseNo;
        private System.Windows.Forms.Label lblExpiryDate;
        private System.Windows.Forms.DateTimePicker dtpLicenseExpiryDate;
        private System.Windows.Forms.Label lblManager;
        private System.Windows.Forms.Label lblManagerName;
        private System.Windows.Forms.LinkLabel llSelectManager;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.NumericUpDown numCapacity;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.LinkLabel llSetLogo;
        private System.Windows.Forms.LinkLabel llRemoveLogo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel pnlDocument;
        private System.Windows.Forms.Label lblDocumentFileName;
        private System.Windows.Forms.Label lblDragInfo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}