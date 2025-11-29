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
            this.button1 = new System.Windows.Forms.Button();
            this.ctlDrivingLicenseApplicationInfo1 = new DVLDPresentationLayer.ctlDrivingLicenseApplicationInfo();
            this.ctlPersonCard1 = new DVLDPresentationLayer.ctlPersonCard();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(330, 377);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 63);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctlDrivingLicenseApplicationInfo1
            // 
            this.ctlDrivingLicenseApplicationInfo1.BackColor = System.Drawing.Color.White;
            this.ctlDrivingLicenseApplicationInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(3, 9);
            this.ctlDrivingLicenseApplicationInfo1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctlDrivingLicenseApplicationInfo1.Name = "ctlDrivingLicenseApplicationInfo1";
            this.ctlDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(888, 369);
            this.ctlDrivingLicenseApplicationInfo1.TabIndex = 2;
            // 
            // ctlPersonCard1
            // 
            this.ctlPersonCard1.BackColor = System.Drawing.Color.White;
            this.ctlPersonCard1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlPersonCard1.Location = new System.Drawing.Point(-18, 437);
            this.ctlPersonCard1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctlPersonCard1.Name = "ctlPersonCard1";
            this.ctlPersonCard1.Size = new System.Drawing.Size(841, 285);
            this.ctlPersonCard1.TabIndex = 3;
            // 
            // testForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 736);
            this.Controls.Add(this.ctlPersonCard1);
            this.Controls.Add(this.ctlDrivingLicenseApplicationInfo1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "testForm";
            this.Text = "testForm";
            this.Load += new System.EventHandler(this.testForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private ctlDrivingLicenseApplicationInfo ctlDrivingLicenseApplicationInfo1;
        private ctlPersonCard ctlPersonCard1;
    }
}