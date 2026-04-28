namespace DVLDPresentationLayer
{
    partial class frmAssignStudentToBatch
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
            this.dgvEligibleStudents = new System.Windows.Forms.DataGridView();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEligibleStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(232, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(360, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Assign Student to Batch";
            // 
            // dgvEligibleStudents
            // 
            this.dgvEligibleStudents.AllowUserToAddRows = false;
            this.dgvEligibleStudents.AllowUserToDeleteRows = false;
            this.dgvEligibleStudents.BackgroundColor = System.Drawing.Color.White;
            this.dgvEligibleStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEligibleStudents.Location = new System.Drawing.Point(23, 116);
            this.dgvEligibleStudents.MultiSelect = false;
            this.dgvEligibleStudents.Name = "dgvEligibleStudents";
            this.dgvEligibleStudents.ReadOnly = true;
            this.dgvEligibleStudents.RowHeadersWidth = 51;
            this.dgvEligibleStudents.RowTemplate.Height = 24;
            this.dgvEligibleStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEligibleStudents.Size = new System.Drawing.Size(760, 313);
            this.dgvEligibleStudents.TabIndex = 1;
            // 
            // btnAssign
            // 
            this.btnAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssign.Location = new System.Drawing.Point(665, 447);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(118, 38);
            this.btnAssign.TabIndex = 2;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(541, 447);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(118, 38);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 456);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "# Records:";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(129, 456);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(19, 20);
            this.lblRecordsCount.TabIndex = 5;
            this.lblRecordsCount.Text = "0";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(101, 79);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(253, 22);
            this.txtSearch.TabIndex = 6;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Search:";
            // 
            // frmAssignStudentToBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(808, 510);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.dgvEligibleStudents);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAssignStudentToBatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Assign Student to Batch";
            this.Load += new System.EventHandler(this.frmAssignStudentToBatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEligibleStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvEligibleStudents;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
    }
}
