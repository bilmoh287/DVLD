namespace DVLDPresentationLayer
{
    partial class testForm
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
            this.driverLicenseInfoWithFilter1 = new DVLDPresentationLayer.ctlDriverLicenseInfoWithFilter();
            this.ctlDriverLicenses1 = new DVLDPresentationLayer.Licenses.Controls.ctlDriverLicenses();
            this.SuspendLayout();
            // 
            // driverLicenseInfoWithFilter1
            // 
            this.driverLicenseInfoWithFilter1.BackColor = System.Drawing.Color.White;
            this.driverLicenseInfoWithFilter1.FilterEnabled = true;
            this.driverLicenseInfoWithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driverLicenseInfoWithFilter1.Location = new System.Drawing.Point(0, 14);
            this.driverLicenseInfoWithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.driverLicenseInfoWithFilter1.Name = "driverLicenseInfoWithFilter1";
            this.driverLicenseInfoWithFilter1.Size = new System.Drawing.Size(875, 437);
            this.driverLicenseInfoWithFilter1.TabIndex = 0;
            // 
            // ctlDriverLicenses1
            // 
            this.ctlDriverLicenses1.BackColor = System.Drawing.Color.White;
            this.ctlDriverLicenses1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlDriverLicenses1.Location = new System.Drawing.Point(0, 458);
            this.ctlDriverLicenses1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctlDriverLicenses1.Name = "ctlDriverLicenses1";
            this.ctlDriverLicenses1.Size = new System.Drawing.Size(1058, 328);
            this.ctlDriverLicenses1.TabIndex = 1;
            // 
            // testForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 800);
            this.Controls.Add(this.ctlDriverLicenses1);
            this.Controls.Add(this.driverLicenseInfoWithFilter1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "testForm";
            this.Text = "testForm";
            this.Load += new System.EventHandler(this.testForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctlDriverLicenseInfoWithFilter driverLicenseInfoWithFilter1;
        private Licenses.Controls.ctlDriverLicenses ctlDriverLicenses1;
    }
}