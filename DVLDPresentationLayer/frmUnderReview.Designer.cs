namespace DVLDPresentationLayer
{
    partial class frmUnderReview
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
            this.dgvUnderReviewList = new System.Windows.Forms.DataGridView();
            this.panelDetail = new System.Windows.Forms.Panel();
            this.pbIdpictrue = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnApprove = new Guna.UI2.WinForms.Guna2Button();
            this.btnReject = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.ctlPersonCard1 = new DVLDPresentationLayer.ctlPersonCard();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnderReviewList)).BeginInit();
            this.panelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIdpictrue)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUnderReviewList
            // 
            this.dgvUnderReviewList.AllowUserToAddRows = false;
            this.dgvUnderReviewList.AllowUserToDeleteRows = false;
            this.dgvUnderReviewList.BackgroundColor = System.Drawing.Color.White;
            this.dgvUnderReviewList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnderReviewList.Location = new System.Drawing.Point(13, 415);
            this.dgvUnderReviewList.Name = "dgvUnderReviewList";
            this.dgvUnderReviewList.ReadOnly = true;
            this.dgvUnderReviewList.RowHeadersWidth = 51;
            this.dgvUnderReviewList.RowTemplate.Height = 24;
            this.dgvUnderReviewList.Size = new System.Drawing.Size(973, 320);
            this.dgvUnderReviewList.TabIndex = 2;
            this.dgvUnderReviewList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUnderReviewList_CellContentClick_1);
            // 
            // panelDetail
            // 
            this.panelDetail.AutoScroll = true;
            this.panelDetail.Controls.Add(this.btnReject);
            this.panelDetail.Controls.Add(this.btnApprove);
            this.panelDetail.Controls.Add(this.label1);
            this.panelDetail.Controls.Add(this.pbIdpictrue);
            this.panelDetail.Controls.Add(this.ctlPersonCard1);
            this.panelDetail.Location = new System.Drawing.Point(0, 72);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(998, 318);
            this.panelDetail.TabIndex = 3;
            this.panelDetail.Visible = false;
            this.panelDetail.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDetail_Paint);
            // 
            // pbIdpictrue
            // 
            this.pbIdpictrue.Location = new System.Drawing.Point(141, 335);
            this.pbIdpictrue.Name = "pbIdpictrue";
            this.pbIdpictrue.Size = new System.Drawing.Size(421, 216);
            this.pbIdpictrue.TabIndex = 1;
            this.pbIdpictrue.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID picture:";
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
            this.btnApprove.Location = new System.Drawing.Point(861, 59);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(111, 37);
            this.btnApprove.TabIndex = 3;
            this.btnApprove.Text = "Approve";
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
            this.btnReject.Location = new System.Drawing.Point(861, 117);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(111, 37);
            this.btnReject.TabIndex = 4;
            this.btnReject.Text = "Reject";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(303, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(339, 33);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Under Review Students List";
            // 
            // ctlPersonCard1
            // 
            this.ctlPersonCard1.BackColor = System.Drawing.Color.White;
            this.ctlPersonCard1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlPersonCard1.Location = new System.Drawing.Point(13, 10);
            this.ctlPersonCard1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctlPersonCard1.Name = "ctlPersonCard1";
            this.ctlPersonCard1.Size = new System.Drawing.Size(841, 285);
            this.ctlPersonCard1.TabIndex = 0;
            // 
            // frmUnderReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(998, 735);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panelDetail);
            this.Controls.Add(this.dgvUnderReviewList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmUnderReview";
            this.Text = "frmUnderReview";
            this.Load += new System.EventHandler(this.frmUnderReview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnderReviewList)).EndInit();
            this.panelDetail.ResumeLayout(false);
            this.panelDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIdpictrue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvUnderReviewList;
        private System.Windows.Forms.Panel panelDetail;
        private ctlPersonCard ctlPersonCard1;
        private System.Windows.Forms.PictureBox pbIdpictrue;
        private Guna.UI2.WinForms.Guna2Button btnReject;
        private Guna.UI2.WinForms.Guna2Button btnApprove;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
    }
}