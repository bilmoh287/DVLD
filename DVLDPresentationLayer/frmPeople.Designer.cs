namespace DVLDPresentationLayer
{
    partial class frmPeople
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
            this.dgvListPeople = new System.Windows.Forms.DataGridView();
            this.cmsPeopleMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNNewPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.lblRecord = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListPeople)).BeginInit();
            this.cmsPeopleMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListPeople
            // 
            this.dgvListPeople.AllowUserToAddRows = false;
            this.dgvListPeople.AllowUserToDeleteRows = false;
            this.dgvListPeople.AllowUserToOrderColumns = true;
            this.dgvListPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListPeople.ContextMenuStrip = this.cmsPeopleMenu;
            this.dgvListPeople.Location = new System.Drawing.Point(12, 251);
            this.dgvListPeople.Name = "dgvListPeople";
            this.dgvListPeople.ReadOnly = true;
            this.dgvListPeople.RowHeadersWidth = 51;
            this.dgvListPeople.RowTemplate.Height = 24;
            this.dgvListPeople.Size = new System.Drawing.Size(1540, 306);
            this.dgvListPeople.TabIndex = 0;
            // 
            // cmsPeopleMenu
            // 
            this.cmsPeopleMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsPeopleMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsPeopleMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.editPersonToolStripMenuItem,
            this.addNNewPersonToolStripMenuItem});
            this.cmsPeopleMenu.Name = "cmsPeopleMenu";
            this.cmsPeopleMenu.Size = new System.Drawing.Size(229, 128);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(228, 32);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // editPersonToolStripMenuItem
            // 
            this.editPersonToolStripMenuItem.Name = "editPersonToolStripMenuItem";
            this.editPersonToolStripMenuItem.Size = new System.Drawing.Size(228, 32);
            this.editPersonToolStripMenuItem.Text = "Edit Person";
            this.editPersonToolStripMenuItem.Click += new System.EventHandler(this.editPersonToolStripMenuItem_Click);
            // 
            // addNNewPersonToolStripMenuItem
            // 
            this.addNNewPersonToolStripMenuItem.Name = "addNNewPersonToolStripMenuItem";
            this.addNNewPersonToolStripMenuItem.Size = new System.Drawing.Size(228, 32);
            this.addNNewPersonToolStripMenuItem.Text = "Add New Person";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(592, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 54);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage People";
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Location = new System.Drawing.Point(1463, 191);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(89, 54);
            this.btnAddNewPerson.TabIndex = 2;
            this.btnAddNewPerson.Text = "Add New";
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1427, 563);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add New";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(12, 576);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(101, 25);
            this.label.TabIndex = 4;
            this.label.Text = "# Record: ";
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.Location = new System.Drawing.Point(119, 576);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(101, 25);
            this.lblRecord.TabIndex = 5;
            this.lblRecord.Text = "# Record: ";
            // 
            // frmPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1587, 611);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.label);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvListPeople);
            this.Name = "frmPeople";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPeople";
            this.Load += new System.EventHandler(this.frmPeople_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListPeople)).EndInit();
            this.cmsPeopleMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListPeople;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ContextMenuStrip cmsPeopleMenu;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNNewPersonToolStripMenuItem;
        private System.Windows.Forms.Label lblRecord;
    }
}