namespace DVLDPresentationLayer
{
    partial class frmListTrainingBatches
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListTrainingBatches));
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblNewBaches = new System.Windows.Forms.Label();
            this.lblActiveBatches = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNewStudents = new System.Windows.Forms.Label();
            this.lblTotalCapacity = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblUpcomingStudents = new System.Windows.Forms.Label();
            this.lblStartingSoon = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvBatchesList = new System.Windows.Forms.DataGridView();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.btnAddBatch = new System.Windows.Forms.Button();
            this.cmsBatches = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editBatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteBatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatchesList)).BeginInit();
            this.cmsBatches.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.pictureBox8);
            this.panel4.Controls.Add(this.lblNewBaches);
            this.panel4.Controls.Add(this.lblActiveBatches);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(124, 82);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(291, 134);
            this.panel4.TabIndex = 7;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // lblNewBaches
            // 
            this.lblNewBaches.AutoSize = true;
            this.lblNewBaches.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNewBaches.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblNewBaches.Location = new System.Drawing.Point(19, 98);
            this.lblNewBaches.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNewBaches.Name = "lblNewBaches";
            this.lblNewBaches.Size = new System.Drawing.Size(107, 20);
            this.lblNewBaches.TabIndex = 5;
            this.lblNewBaches.Text = "15 New Orders";
            // 
            // lblActiveBatches
            // 
            this.lblActiveBatches.AutoSize = true;
            this.lblActiveBatches.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.lblActiveBatches.ForeColor = System.Drawing.Color.Black;
            this.lblActiveBatches.Location = new System.Drawing.Point(4, 36);
            this.lblActiveBatches.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblActiveBatches.Name = "lblActiveBatches";
            this.lblActiveBatches.Size = new System.Drawing.Size(132, 57);
            this.lblActiveBatches.TabIndex = 4;
            this.lblActiveBatches.Text = "1,587";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(19, 17);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Active Batches";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblNewStudents);
            this.panel1.Controls.Add(this.lblTotalCapacity);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(507, 82);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 134);
            this.panel1.TabIndex = 8;
            // 
            // lblNewStudents
            // 
            this.lblNewStudents.AutoSize = true;
            this.lblNewStudents.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNewStudents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblNewStudents.Location = new System.Drawing.Point(19, 98);
            this.lblNewStudents.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNewStudents.Name = "lblNewStudents";
            this.lblNewStudents.Size = new System.Drawing.Size(107, 20);
            this.lblNewStudents.TabIndex = 5;
            this.lblNewStudents.Text = "15 New Orders";
            // 
            // lblTotalCapacity
            // 
            this.lblTotalCapacity.AutoSize = true;
            this.lblTotalCapacity.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.lblTotalCapacity.ForeColor = System.Drawing.Color.Black;
            this.lblTotalCapacity.Location = new System.Drawing.Point(4, 36);
            this.lblTotalCapacity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalCapacity.Name = "lblTotalCapacity";
            this.lblTotalCapacity.Size = new System.Drawing.Size(132, 57);
            this.lblTotalCapacity.TabIndex = 4;
            this.lblTotalCapacity.Text = "1,587";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(19, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total Capacity";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.lblUpcomingStudents);
            this.panel2.Controls.Add(this.lblStartingSoon);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(890, 82);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(291, 134);
            this.panel2.TabIndex = 8;
            // 
            // lblUpcomingStudents
            // 
            this.lblUpcomingStudents.AutoSize = true;
            this.lblUpcomingStudents.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUpcomingStudents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblUpcomingStudents.Location = new System.Drawing.Point(19, 98);
            this.lblUpcomingStudents.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUpcomingStudents.Name = "lblUpcomingStudents";
            this.lblUpcomingStudents.Size = new System.Drawing.Size(107, 20);
            this.lblUpcomingStudents.TabIndex = 5;
            this.lblUpcomingStudents.Text = "15 New Orders";
            // 
            // lblStartingSoon
            // 
            this.lblStartingSoon.AutoSize = true;
            this.lblStartingSoon.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.lblStartingSoon.ForeColor = System.Drawing.Color.Black;
            this.lblStartingSoon.Location = new System.Drawing.Point(4, 36);
            this.lblStartingSoon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartingSoon.Name = "lblStartingSoon";
            this.lblStartingSoon.Size = new System.Drawing.Size(132, 57);
            this.lblStartingSoon.TabIndex = 4;
            this.lblStartingSoon.Text = "1,587";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(19, 17);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Starting Soon";
            // 
            // dgvBatchesList
            // 
            this.dgvBatchesList.AllowUserToAddRows = false;
            this.dgvBatchesList.AllowUserToDeleteRows = false;
            this.dgvBatchesList.AllowUserToOrderColumns = true;
            this.dgvBatchesList.BackgroundColor = System.Drawing.Color.White;
            this.dgvBatchesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBatchesList.ContextMenuStrip = this.cmsBatches;
            this.dgvBatchesList.Location = new System.Drawing.Point(12, 292);
            this.dgvBatchesList.Name = "dgvBatchesList";
            this.dgvBatchesList.ReadOnly = true;
            this.dgvBatchesList.RowHeadersWidth = 51;
            this.dgvBatchesList.RowTemplate.Height = 24;
            this.dgvBatchesList.Size = new System.Drawing.Size(1283, 396);
            this.dgvBatchesList.TabIndex = 9;
            // 
            // btnAddBatch
            // 
            this.btnAddBatch.BackgroundImage = global::DVLDPresentationLayer.Properties.Resources.AddBatch_64;
            this.btnAddBatch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddBatch.Location = new System.Drawing.Point(1224, 222);
            this.btnAddBatch.Name = "btnAddBatch";
            this.btnAddBatch.Size = new System.Drawing.Size(71, 64);
            this.btnAddBatch.TabIndex = 13;
            this.btnAddBatch.UseVisualStyleBackColor = true;
            this.btnAddBatch.Click += new System.EventHandler(this.btnAddBatch_Click);
            // 
            // cmsBatches
            // 
            this.cmsBatches.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsBatches.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editBatchToolStripMenuItem,
            this.deleteBatchToolStripMenuItem});
            this.cmsBatches.Name = "cmsBatches";
            this.cmsBatches.Size = new System.Drawing.Size(163, 52);
            // 
            // editBatchToolStripMenuItem
            // 
            this.editBatchToolStripMenuItem.Name = "editBatchToolStripMenuItem";
            this.editBatchToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.editBatchToolStripMenuItem.Text = "Edit Batch";
            this.editBatchToolStripMenuItem.Click += new System.EventHandler(this.editBatchToolStripMenuItem_Click);
            // 
            // deleteBatchToolStripMenuItem
            // 
            this.deleteBatchToolStripMenuItem.Name = "deleteBatchToolStripMenuItem";
            this.deleteBatchToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.deleteBatchToolStripMenuItem.Text = "Delete Batch";
            // 
            // txtSearch
            // 
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Location = new System.Drawing.Point(13, 235);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(310, 39);
            this.txtSearch.TabIndex = 10;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(511, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(287, 46);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "Manage Batches";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1174, 699);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 34);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(206, 17);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(206, 17);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(66, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(206, 17);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(66, 48);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 6;
            this.pictureBox8.TabStop = false;
            // 
            // frmListTrainingBatches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 739);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvBatchesList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnAddBatch);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmListTrainingBatches";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmListTrainingBatches";
            this.Load += new System.EventHandler(this.frmListTrainingBatches_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatchesList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.cmsBatches.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label lblNewBaches;
        private System.Windows.Forms.Label lblActiveBatches;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNewStudents;
        private System.Windows.Forms.Label lblTotalCapacity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblUpcomingStudents;
        private System.Windows.Forms.Label lblStartingSoon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvBatchesList;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddBatch;
        private System.Windows.Forms.ContextMenuStrip cmsBatches;
        private System.Windows.Forms.ToolStripMenuItem editBatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteBatchToolStripMenuItem;
    }
}