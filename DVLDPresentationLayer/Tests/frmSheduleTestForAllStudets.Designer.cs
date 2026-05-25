namespace DVLDPresentationLayer.Tests
{
    partial class frmSheduleTestForAllStudets
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
            this.panelEligibleStduents = new System.Windows.Forms.Panel();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnScheduleVisionTest = new System.Windows.Forms.Button();
            this.btnScheduleWrittenTest = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnScheduleStreetTest = new System.Windows.Forms.Button();
            this.panelEligibleStduents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEligibleStduents
            // 
            this.panelEligibleStduents.Controls.Add(this.lblRecordsCount);
            this.panelEligibleStduents.Controls.Add(this.label2);
            this.panelEligibleStduents.Controls.Add(this.dataGridView1);
            this.panelEligibleStduents.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelEligibleStduents.Location = new System.Drawing.Point(0, 0);
            this.panelEligibleStduents.Name = "panelEligibleStduents";
            this.panelEligibleStduents.Size = new System.Drawing.Size(980, 745);
            this.panelEligibleStduents.TabIndex = 0;
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.ForeColor = System.Drawing.Color.Black;
            this.lblRecordsCount.Location = new System.Drawing.Point(120, 707);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(39, 29);
            this.lblRecordsCount.TabIndex = 130;
            this.lblRecordsCount.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 699);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 29);
            this.label2.TabIndex = 129;
            this.label2.Text = "# Records:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 215);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(942, 476);
            this.dataGridView1.TabIndex = 126;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnScheduleVisionTest);
            this.panelButtons.Controls.Add(this.btnScheduleWrittenTest);
            this.panelButtons.Controls.Add(this.btnClose);
            this.panelButtons.Controls.Add(this.btnScheduleStreetTest);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelButtons.Location = new System.Drawing.Point(1040, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(289, 745);
            this.panelButtons.TabIndex = 1;
            // 
            // btnScheduleVisionTest
            // 
            this.btnScheduleVisionTest.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnScheduleVisionTest.FlatAppearance.BorderSize = 2;
            this.btnScheduleVisionTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScheduleVisionTest.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScheduleVisionTest.Location = new System.Drawing.Point(35, 75);
            this.btnScheduleVisionTest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnScheduleVisionTest.Name = "btnScheduleVisionTest";
            this.btnScheduleVisionTest.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnScheduleVisionTest.Size = new System.Drawing.Size(227, 98);
            this.btnScheduleVisionTest.TabIndex = 8;
            this.btnScheduleVisionTest.Text = "Schudule Vision Test";
            this.btnScheduleVisionTest.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnScheduleVisionTest.UseVisualStyleBackColor = true;
            this.btnScheduleVisionTest.Click += new System.EventHandler(this.btnScheduleVisionTest_Click_1);
            // 
            // btnScheduleWrittenTest
            // 
            this.btnScheduleWrittenTest.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnScheduleWrittenTest.FlatAppearance.BorderSize = 2;
            this.btnScheduleWrittenTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScheduleWrittenTest.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScheduleWrittenTest.Location = new System.Drawing.Point(35, 204);
            this.btnScheduleWrittenTest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnScheduleWrittenTest.Name = "btnScheduleWrittenTest";
            this.btnScheduleWrittenTest.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnScheduleWrittenTest.Size = new System.Drawing.Size(227, 109);
            this.btnScheduleWrittenTest.TabIndex = 7;
            this.btnScheduleWrittenTest.Text = "Schedule Written Test";
            this.btnScheduleWrittenTest.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnScheduleWrittenTest.UseVisualStyleBackColor = true;
            this.btnScheduleWrittenTest.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLDPresentationLayer.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(136, 694);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 37);
            this.btnClose.TabIndex = 128;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnScheduleStreetTest
            // 
            this.btnScheduleStreetTest.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnScheduleStreetTest.FlatAppearance.BorderSize = 2;
            this.btnScheduleStreetTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScheduleStreetTest.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScheduleStreetTest.Location = new System.Drawing.Point(35, 343);
            this.btnScheduleStreetTest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnScheduleStreetTest.Name = "btnScheduleStreetTest";
            this.btnScheduleStreetTest.Padding = new System.Windows.Forms.Padding(8, 0, 0, 8);
            this.btnScheduleStreetTest.Size = new System.Drawing.Size(227, 107);
            this.btnScheduleStreetTest.TabIndex = 6;
            this.btnScheduleStreetTest.Text = "Schedule Street Test";
            this.btnScheduleStreetTest.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnScheduleStreetTest.UseVisualStyleBackColor = true;
            // 
            // frmSheduleTestForAllStudets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1329, 745);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelEligibleStduents);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmSheduleTestForAllStudets";
            this.Text = "frmSheduleTestForAllStudets";
            this.panelEligibleStduents.ResumeLayout(false);
            this.panelEligibleStduents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelEligibleStduents;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnScheduleVisionTest;
        private System.Windows.Forms.Button btnScheduleWrittenTest;
        private System.Windows.Forms.Button btnScheduleStreetTest;
    }
}