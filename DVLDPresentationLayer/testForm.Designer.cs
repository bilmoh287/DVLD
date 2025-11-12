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
            this.ctlApplicationBasicInfo1 = new DVLDPresentationLayer.ctlApplicationBasicInfo();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(326, 307);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 63);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctlApplicationBasicInfo1
            // 
            this.ctlApplicationBasicInfo1.BackColor = System.Drawing.Color.White;
            this.ctlApplicationBasicInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlApplicationBasicInfo1.Location = new System.Drawing.Point(2, 33);
            this.ctlApplicationBasicInfo1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctlApplicationBasicInfo1.Name = "ctlApplicationBasicInfo1";
            this.ctlApplicationBasicInfo1.Size = new System.Drawing.Size(877, 224);
            this.ctlApplicationBasicInfo1.TabIndex = 2;
            // 
            // testForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 391);
            this.Controls.Add(this.ctlApplicationBasicInfo1);
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
        private ctlApplicationBasicInfo ctlApplicationBasicInfo1;
    }
}