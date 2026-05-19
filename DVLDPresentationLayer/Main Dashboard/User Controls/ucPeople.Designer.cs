namespace DVLDPresentationLayer.Main_Dashboard.User_Controls
{
    partial class ucPeople
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnAddUpdatePeople = new System.Windows.Forms.Button();
            this.btnListPeople = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(344, 41);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(304, 48);
            this.guna2HtmlLabel1.TabIndex = 9;
            this.guna2HtmlLabel1.Text = "Manage Persons";
            // 
            // btnAddUpdatePeople
            // 
            this.btnAddUpdatePeople.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnAddUpdatePeople.FlatAppearance.BorderSize = 2;
            this.btnAddUpdatePeople.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUpdatePeople.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUpdatePeople.Location = new System.Drawing.Point(547, 359);
            this.btnAddUpdatePeople.Name = "btnAddUpdatePeople";
            this.btnAddUpdatePeople.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnAddUpdatePeople.Size = new System.Drawing.Size(173, 95);
            this.btnAddUpdatePeople.TabIndex = 8;
            this.btnAddUpdatePeople.Text = "Add/Update Poeple";
            this.btnAddUpdatePeople.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnAddUpdatePeople.UseVisualStyleBackColor = true;
            // 
            // btnListPeople
            // 
            this.btnListPeople.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnListPeople.FlatAppearance.BorderSize = 2;
            this.btnListPeople.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListPeople.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListPeople.Location = new System.Drawing.Point(301, 359);
            this.btnListPeople.Name = "btnListPeople";
            this.btnListPeople.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnListPeople.Size = new System.Drawing.Size(169, 95);
            this.btnListPeople.TabIndex = 7;
            this.btnListPeople.Text = "      List People";
            this.btnListPeople.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnListPeople.UseVisualStyleBackColor = true;
            // 
            // ucPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.btnAddUpdatePeople);
            this.Controls.Add(this.btnListPeople);
            this.Name = "ucPeople";
            this.Size = new System.Drawing.Size(1024, 654);
            this.Load += new System.EventHandler(this.ucPeople_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.Button btnAddUpdatePeople;
        private System.Windows.Forms.Button btnListPeople;
    }
}
