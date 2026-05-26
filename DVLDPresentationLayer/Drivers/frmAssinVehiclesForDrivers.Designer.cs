namespace DVLDPresentationLayer.Drivers
{
    partial class frmAssinVehiclesForDrivers
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
            this.toolStripSeparatorVehicle1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparatorVehicle2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cbInstitute = new System.Windows.Forms.ComboBox();
            this.cbBatch = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvLocalDrivingLicenseApplications = new System.Windows.Forms.DataGridView();
            this.btnAddNewApplication = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.showVehicleInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignNewVehicleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseVehicleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripSeparatorVehicle1
            // 
            this.toolStripSeparatorVehicle1.Name = "toolStripSeparatorVehicle1";
            this.toolStripSeparatorVehicle1.Size = new System.Drawing.Size(223, 6);
            // 
            // toolStripSeparatorVehicle2
            // 
            this.toolStripSeparatorVehicle2.Name = "toolStripSeparatorVehicle2";
            this.toolStripSeparatorVehicle2.Size = new System.Drawing.Size(223, 6);
            // 
            // cmsApplications
            // 
            this.cmsApplications.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showVehicleInfoToolStripMenuItem,
            this.toolStripSeparatorVehicle1,
            this.assignNewVehicleToolStripMenuItem,
            this.toolStripSeparatorVehicle2,
            this.releaseVehicleToolStripMenuItem});
            this.cmsApplications.Name = "contextMenuStrip1";
            this.cmsApplications.Size = new System.Drawing.Size(227, 130);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "National No.",
            "Full Name",
            "Status",
            "Institute",
            "Batch"});
            this.cbFilterBy.Location = new System.Drawing.Point(90, 263);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(210, 33);
            this.cbFilterBy.TabIndex = 148;
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Location = new System.Drawing.Point(307, 263);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(256, 30);
            this.txtFilterValue.TabIndex = 147;
            // 
            // cbInstitute
            // 
            this.cbInstitute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInstitute.FormattingEnabled = true;
            this.cbInstitute.Location = new System.Drawing.Point(307, 263);
            this.cbInstitute.Name = "cbInstitute";
            this.cbInstitute.Size = new System.Drawing.Size(256, 33);
            this.cbInstitute.TabIndex = 153;
            this.cbInstitute.Visible = false;
            // 
            // cbBatch
            // 
            this.cbBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBatch.FormattingEnabled = true;
            this.cbBatch.Location = new System.Drawing.Point(307, 263);
            this.cbBatch.Name = "cbBatch";
            this.cbBatch.Size = new System.Drawing.Size(256, 33);
            this.cbBatch.TabIndex = 154;
            this.cbBatch.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 152;
            this.label1.Text = "Filter By:";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(387, 196);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(568, 39);
            this.lblTitle.TabIndex = 146;
            this.lblTitle.Text = "Local Driving License Applications";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.ForeColor = System.Drawing.Color.Black;
            this.lblRecordsCount.Location = new System.Drawing.Point(114, 698);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(34, 25);
            this.lblRecordsCount.TabIndex = 145;
            this.lblRecordsCount.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 698);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 144;
            this.label2.Text = "# Records:";
            // 
            // dgvLocalDrivingLicenseApplications
            // 
            this.dgvLocalDrivingLicenseApplications.AllowUserToAddRows = false;
            this.dgvLocalDrivingLicenseApplications.AllowUserToDeleteRows = false;
            this.dgvLocalDrivingLicenseApplications.AllowUserToOrderColumns = true;
            this.dgvLocalDrivingLicenseApplications.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalDrivingLicenseApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalDrivingLicenseApplications.Location = new System.Drawing.Point(12, 302);
            this.dgvLocalDrivingLicenseApplications.Name = "dgvLocalDrivingLicenseApplications";
            this.dgvLocalDrivingLicenseApplications.ReadOnly = true;
            this.dgvLocalDrivingLicenseApplications.RowHeadersWidth = 51;
            this.dgvLocalDrivingLicenseApplications.RowTemplate.Height = 24;
            this.dgvLocalDrivingLicenseApplications.Size = new System.Drawing.Size(1327, 376);
            this.dgvLocalDrivingLicenseApplications.TabIndex = 142;
            // 
            // btnAddNewApplication
            // 
            this.btnAddNewApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewApplication.Image = global::DVLDPresentationLayer.Properties.Resources.New_Application_64;
            this.btnAddNewApplication.Location = new System.Drawing.Point(1251, 219);
            this.btnAddNewApplication.Name = "btnAddNewApplication";
            this.btnAddNewApplication.Size = new System.Drawing.Size(88, 75);
            this.btnAddNewApplication.TabIndex = 150;
            this.btnAddNewApplication.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::DVLDPresentationLayer.Properties.Resources.closeBlack32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1214, 684);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(124, 39);
            this.btnClose.TabIndex = 143;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPersonImage.Image = global::DVLDPresentationLayer.Properties.Resources.Vehicle;
            this.pbPersonImage.InitialImage = null;
            this.pbPersonImage.Location = new System.Drawing.Point(569, 2);
            this.pbPersonImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(220, 189);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 149;
            this.pbPersonImage.TabStop = false;
            // 
            // showVehicleInfoToolStripMenuItem
            // 
            this.showVehicleInfoToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.PersonDetails_32;
            this.showVehicleInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showVehicleInfoToolStripMenuItem.Name = "showVehicleInfoToolStripMenuItem";
            this.showVehicleInfoToolStripMenuItem.Size = new System.Drawing.Size(226, 38);
            this.showVehicleInfoToolStripMenuItem.Text = "Show Vehicle Info";
            this.showVehicleInfoToolStripMenuItem.Click += new System.EventHandler(this.showVehicleInfoToolStripMenuItem_Click);
            // 
            // assignNewVehicleToolStripMenuItem
            // 
            this.assignNewVehicleToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.AddPerson_32;
            this.assignNewVehicleToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.assignNewVehicleToolStripMenuItem.Name = "assignNewVehicleToolStripMenuItem";
            this.assignNewVehicleToolStripMenuItem.Size = new System.Drawing.Size(226, 38);
            this.assignNewVehicleToolStripMenuItem.Text = "Assign New Vehicle";
            this.assignNewVehicleToolStripMenuItem.Click += new System.EventHandler(this.assignNewVehicleToolStripMenuItem_Click);
            // 
            // releaseVehicleToolStripMenuItem
            // 
            this.releaseVehicleToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.Delete_32;
            this.releaseVehicleToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.releaseVehicleToolStripMenuItem.Name = "releaseVehicleToolStripMenuItem";
            this.releaseVehicleToolStripMenuItem.Size = new System.Drawing.Size(226, 38);
            this.releaseVehicleToolStripMenuItem.Text = "Release/Sell Vehicle";
            this.releaseVehicleToolStripMenuItem.Click += new System.EventHandler(this.releaseVehicleToolStripMenuItem_Click);
            // 
            // frmAssinVehiclesForDrivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1351, 729);
            this.Controls.Add(this.btnAddNewApplication);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pbPersonImage);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.cbInstitute);
            this.Controls.Add(this.cbBatch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvLocalDrivingLicenseApplications);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAssinVehiclesForDrivers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAssinVehiclesForDrivers";
            this.cmsApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplications)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddNewApplication;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStripMenuItem showVehicleInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorVehicle1;
        private System.Windows.Forms.ToolStripMenuItem assignNewVehicleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorVehicle2;
        private System.Windows.Forms.ToolStripMenuItem releaseVehicleToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.ContextMenuStrip cmsApplications;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cbInstitute;
        private System.Windows.Forms.ComboBox cbBatch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvLocalDrivingLicenseApplications;
    }
}