namespace DVLDPresentationLayer.Applications.Application_Reviews
{
    partial class frmReviewRenewalApplications
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
            this.panelDetail = new System.Windows.Forms.Panel();
            this.btnReject = new Guna.UI2.WinForms.Guna2Button();
            this.btnApprove = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pbIdpictrue = new System.Windows.Forms.PictureBox();
            this.ctlPersonCard1 = new DVLDPresentationLayer.ctlPersonCard();
            this.dgvUnderReviewList = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIdpictrue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnderReviewList)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDetail
            // 
            this.panelDetail.AutoScroll = true;
            this.panelDetail.Controls.Add(this.btnReject);
            this.panelDetail.Controls.Add(this.btnApprove);
            this.panelDetail.Controls.Add(this.label1);
            this.panelDetail.Controls.Add(this.pbIdpictrue);
            this.panelDetail.Controls.Add(this.ctlPersonCard1);
            this.panelDetail.Location = new System.Drawing.Point(15, 61);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(998, 298);
            this.panelDetail.TabIndex = 6;
            this.panelDetail.Visible = false;
            // 
            // btnReject
            // 
            this.btnReject.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReject.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReject.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReject.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReject.FillColor = System.Drawing.Color.Crimson;
            this.btnReject.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(861, 533);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(111, 37);
            this.btnReject.TabIndex = 4;
            this.btnReject.Text = "Reject";
            // 
            // btnApprove
            // 
            this.btnApprove.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnApprove.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnApprove.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnApprove.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnApprove.FillColor = System.Drawing.Color.LimeGreen;
            this.btnApprove.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(861, 475);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(111, 37);
            this.btnApprove.TabIndex = 3;
            this.btnApprove.Text = "Approve";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 790);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Vision health Medical Proof:";
            // 
            // pbIdpictrue
            // 
            this.pbIdpictrue.Location = new System.Drawing.Point(303, 719);
            this.pbIdpictrue.Name = "pbIdpictrue";
            this.pbIdpictrue.Size = new System.Drawing.Size(445, 411);
            this.pbIdpictrue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIdpictrue.TabIndex = 1;
            this.pbIdpictrue.TabStop = false;
            // 
            // ctlPersonCard1
            // 
            this.ctlPersonCard1.BackColor = System.Drawing.Color.White;
            this.ctlPersonCard1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlPersonCard1.Location = new System.Drawing.Point(13, 426);
            this.ctlPersonCard1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctlPersonCard1.Name = "ctlPersonCard1";
            this.ctlPersonCard1.Size = new System.Drawing.Size(841, 285);
            this.ctlPersonCard1.TabIndex = 0;
            // 
            // dgvUnderReviewList
            // 
            this.dgvUnderReviewList.AllowUserToAddRows = false;
            this.dgvUnderReviewList.AllowUserToDeleteRows = false;
            this.dgvUnderReviewList.BackgroundColor = System.Drawing.Color.White;
            this.dgvUnderReviewList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnderReviewList.Location = new System.Drawing.Point(14, 387);
            this.dgvUnderReviewList.Name = "dgvUnderReviewList";
            this.dgvUnderReviewList.ReadOnly = true;
            this.dgvUnderReviewList.RowHeadersWidth = 51;
            this.dgvUnderReviewList.RowTemplate.Height = 24;
            this.dgvUnderReviewList.Size = new System.Drawing.Size(983, 283);
            this.dgvUnderReviewList.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(876, 677);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 39);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(175, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(588, 49);
            this.lblTitle.TabIndex = 136;
            this.lblTitle.Text = "Review Renewal Application\r\n";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmReviewRenewalApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1020, 723);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panelDetail);
            this.Controls.Add(this.dgvUnderReviewList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmReviewRenewalApplications";
            this.Text = "frmReviewRenewalApplications";
            this.panelDetail.ResumeLayout(false);
            this.panelDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIdpictrue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnderReviewList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDetail;
        private Guna.UI2.WinForms.Guna2Button btnReject;
        private Guna.UI2.WinForms.Guna2Button btnApprove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbIdpictrue;
        private ctlPersonCard ctlPersonCard1;
        private System.Windows.Forms.DataGridView dgvUnderReviewList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
    }
}