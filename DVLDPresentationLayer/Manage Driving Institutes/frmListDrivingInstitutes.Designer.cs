namespace DVLDPresentationLayer
{
    partial class frmListDrivingInstitutes
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
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddInstitute = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showCoursesListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewCourseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editInstitueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteInstiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.ForeColor = System.Drawing.Color.Black;
            this.lblRecordsCount.Location = new System.Drawing.Point(126, 506);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(36, 25);
            this.lblRecordsCount.TabIndex = 125;
            this.lblRecordsCount.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(18, 506);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 124;
            this.label2.Text = "# Records:";
            // 
            // btnAddInstitute
            // 
            this.btnAddInstitute.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddInstitute.Location = new System.Drawing.Point(934, 82);
            this.btnAddInstitute.Name = "btnAddInstitute";
            this.btnAddInstitute.Size = new System.Drawing.Size(88, 54);
            this.btnAddInstitute.TabIndex = 122;
            this.btnAddInstitute.Text = "Add Institute";
            this.btnAddInstitute.UseVisualStyleBackColor = true;
            this.btnAddInstitute.Click += new System.EventHandler(this.btnAddInstitute_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(10, 142);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1012, 350);
            this.dataGridView1.TabIndex = 121;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLDPresentationLayer.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(896, 500);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 37);
            this.btnClose.TabIndex = 123;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showCoursesListToolStripMenuItem,
            this.toolStripMenuItem1,
            this.addNewCourseToolStripMenuItem,
            this.editInstitueToolStripMenuItem,
            this.deleteInstiToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(214, 162);
            // 
            // showCoursesListToolStripMenuItem
            // 
            this.showCoursesListToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.notes__1_;
            this.showCoursesListToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showCoursesListToolStripMenuItem.Name = "showCoursesListToolStripMenuItem";
            this.showCoursesListToolStripMenuItem.Size = new System.Drawing.Size(226, 38);
            this.showCoursesListToolStripMenuItem.Text = "Show Courses List";
            this.showCoursesListToolStripMenuItem.Click += new System.EventHandler(this.showCoursesListToolStripMenuItem_Click);
            // 
            // addNewCourseToolStripMenuItem
            // 
            this.addNewCourseToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.AddPerson_32;
            this.addNewCourseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewCourseToolStripMenuItem.Name = "addNewCourseToolStripMenuItem";
            this.addNewCourseToolStripMenuItem.Size = new System.Drawing.Size(226, 38);
            this.addNewCourseToolStripMenuItem.Text = "Add New Institute";
            this.addNewCourseToolStripMenuItem.Click += new System.EventHandler(this.addNewCourseToolStripMenuItem_Click);
            // 
            // editInstitueToolStripMenuItem
            // 
            this.editInstitueToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.edit_32;
            this.editInstitueToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editInstitueToolStripMenuItem.Name = "editInstitueToolStripMenuItem";
            this.editInstitueToolStripMenuItem.Size = new System.Drawing.Size(226, 38);
            this.editInstitueToolStripMenuItem.Text = "Edit Institue";
            this.editInstitueToolStripMenuItem.Click += new System.EventHandler(this.editInstitueToolStripMenuItem_Click);
            // 
            // deleteInstiToolStripMenuItem
            // 
            this.deleteInstiToolStripMenuItem.Image = global::DVLDPresentationLayer.Properties.Resources.Delete_32_2;
            this.deleteInstiToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteInstiToolStripMenuItem.Name = "deleteInstiToolStripMenuItem";
            this.deleteInstiToolStripMenuItem.Size = new System.Drawing.Size(226, 38);
            this.deleteInstiToolStripMenuItem.Text = "Delete Institute";
            this.deleteInstiToolStripMenuItem.Click += new System.EventHandler(this.deleteInstiToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(223, 6);
            // 
            // frmListDrivingInstitutes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1031, 548);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddInstitute);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmListDrivingInstitutes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmListDrivingInstitutes2";
            this.Load += new System.EventHandler(this.frmListDrivingInstitutes2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddInstitute;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showCoursesListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewCourseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editInstitueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteInstiToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    }
}