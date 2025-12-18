namespace DVLDPresentationLayer.Licenses
{
    partial class frmShowPersonLicenseHistory
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.ctlDriverLicenses1 = new DVLDPresentationLayer.Licenses.Controls.ctlDriverLicenses();
            this.ctlDriverLicenseInfoWithFilter1 = new DVLDPresentationLayer.ctlDriverLicenseInfoWithFilter();
            this.ctlPersonCardWithFilter1 = new DVLDPresentationLayer.ctlPersonCardWithFilter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(12, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1062, 49);
            this.lblTitle.TabIndex = 130;
            this.lblTitle.Text = "License History";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPersonImage.Image = global::DVLDPresentationLayer.Properties.Resources.PersonLicenseHistory_5121;
            this.pbPersonImage.InitialImage = null;
            this.pbPersonImage.Location = new System.Drawing.Point(13, 143);
            this.pbPersonImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(220, 189);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 135;
            this.pbPersonImage.TabStop = false;
            // 
            // ctlDriverLicenses1
            // 
            this.ctlDriverLicenses1.BackColor = System.Drawing.Color.White;
            this.ctlDriverLicenses1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlDriverLicenses1.Location = new System.Drawing.Point(4, 423);
            this.ctlDriverLicenses1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctlDriverLicenses1.Name = "ctlDriverLicenses1";
            this.ctlDriverLicenses1.Size = new System.Drawing.Size(1058, 328);
            this.ctlDriverLicenses1.TabIndex = 134;
            // 
            // ctlDriverLicenseInfoWithFilter1
            // 
            this.ctlDriverLicenseInfoWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctlDriverLicenseInfoWithFilter1.FilterEnabled = true;
            this.ctlDriverLicenseInfoWithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(540, 604);
            this.ctlDriverLicenseInfoWithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctlDriverLicenseInfoWithFilter1.Name = "ctlDriverLicenseInfoWithFilter1";
            this.ctlDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(8, 8);
            this.ctlDriverLicenseInfoWithFilter1.TabIndex = 132;
            // 
            // ctlPersonCardWithFilter1
            // 
            this.ctlPersonCardWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctlPersonCardWithFilter1.FilterEnables = true;
            this.ctlPersonCardWithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlPersonCardWithFilter1.Location = new System.Drawing.Point(232, 42);
            this.ctlPersonCardWithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctlPersonCardWithFilter1.Name = "ctlPersonCardWithFilter1";
            this.ctlPersonCardWithFilter1.ShowAddPerson = true;
            this.ctlPersonCardWithFilter1.Size = new System.Drawing.Size(842, 394);
            this.ctlPersonCardWithFilter1.TabIndex = 133;
            this.ctlPersonCardWithFilter1.OnPersonSelected += new System.Action<int>(this.ctlPersonCardWithFilter1_OnPersonSelected);
            // 
            // button1
            // 
            this.button1.AutoEllipsis = true;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::DVLDPresentationLayer.Properties.Resources.closeBlack32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(914, 743);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 36);
            this.button1.TabIndex = 183;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmShowPersonLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1070, 829);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbPersonImage);
            this.Controls.Add(this.ctlDriverLicenses1);
            this.Controls.Add(this.ctlDriverLicenseInfoWithFilter1);
            this.Controls.Add(this.ctlPersonCardWithFilter1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShowPersonLicenseHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "License History";
            this.Load += new System.EventHandler(this.frmShowPersonLicenseHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private ctlDriverLicenseInfoWithFilter ctlDriverLicenseInfoWithFilter1;
        private ctlPersonCardWithFilter ctlPersonCardWithFilter1;
        private Controls.ctlDriverLicenses ctlDriverLicenses1;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.Button button1;
    }
}