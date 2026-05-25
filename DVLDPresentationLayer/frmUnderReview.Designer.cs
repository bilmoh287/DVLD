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
            this.btnReject = new Guna.UI2.WinForms.Guna2Button();
            this.btnApprove = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ctlPersonCard1 = new DVLDPresentationLayer.ctlPersonCard();
            this.label2 = new System.Windows.Forms.Label();
            this.pbidpictureback = new System.Windows.Forms.PictureBox();
            this.pbBirthCertificate = new System.Windows.Forms.PictureBox();
            this.pbIdpictruefront = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pb12thTranscript = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnderReviewList)).BeginInit();
            this.panelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbidpictureback)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBirthCertificate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIdpictruefront)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb12thTranscript)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUnderReviewList
            // 
            this.dgvUnderReviewList.AllowUserToAddRows = false;
            this.dgvUnderReviewList.AllowUserToDeleteRows = false;
            this.dgvUnderReviewList.BackgroundColor = System.Drawing.Color.White;
            this.dgvUnderReviewList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnderReviewList.Location = new System.Drawing.Point(12, 426);
            this.dgvUnderReviewList.Name = "dgvUnderReviewList";
            this.dgvUnderReviewList.ReadOnly = true;
            this.dgvUnderReviewList.RowHeadersWidth = 51;
            this.dgvUnderReviewList.RowTemplate.Height = 24;
            this.dgvUnderReviewList.Size = new System.Drawing.Size(973, 282);
            this.dgvUnderReviewList.TabIndex = 2;
            this.dgvUnderReviewList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUnderReviewList_CellContentClick_1);
            // 
            // panelDetail
            // 
            this.panelDetail.AutoScroll = true;
            this.panelDetail.Controls.Add(this.pb12thTranscript);
            this.panelDetail.Controls.Add(this.label3);
            this.panelDetail.Controls.Add(this.label2);
            this.panelDetail.Controls.Add(this.pbidpictureback);
            this.panelDetail.Controls.Add(this.pbBirthCertificate);
            this.panelDetail.Controls.Add(this.btnReject);
            this.panelDetail.Controls.Add(this.btnApprove);
            this.panelDetail.Controls.Add(this.label1);
            this.panelDetail.Controls.Add(this.pbIdpictruefront);
            this.panelDetail.Controls.Add(this.ctlPersonCard1);
            this.panelDetail.Location = new System.Drawing.Point(0, 0);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(1000, 402);
            this.panelDetail.TabIndex = 3;
            this.panelDetail.Visible = false;
            this.panelDetail.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDetail_Paint);
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
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
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
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 359);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID picture front:";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(461, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "ID picture:";
            // 
            // pbidpictureback
            // 
            this.pbidpictureback.Location = new System.Drawing.Point(645, 293);
            this.pbidpictureback.Name = "pbidpictureback";
            this.pbidpictureback.Size = new System.Drawing.Size(327, 170);
            this.pbidpictureback.TabIndex = 6;
            this.pbidpictureback.TabStop = false;
            // 
            // pbBirthCertificate
            // 
            this.pbBirthCertificate.Location = new System.Drawing.Point(70, 479);
            this.pbBirthCertificate.Name = "pbBirthCertificate";
            this.pbBirthCertificate.Size = new System.Drawing.Size(421, 244);
            this.pbBirthCertificate.TabIndex = 5;
            this.pbBirthCertificate.TabStop = false;
            // 
            // pbIdpictruefront
            // 
            this.pbIdpictruefront.Location = new System.Drawing.Point(161, 293);
            this.pbIdpictruefront.Name = "pbIdpictruefront";
            this.pbIdpictruefront.Size = new System.Drawing.Size(330, 170);
            this.pbIdpictruefront.TabIndex = 1;
            this.pbIdpictruefront.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(497, 344);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "ID picture back:";
            // 
            // pb12thTranscript
            // 
            this.pb12thTranscript.Location = new System.Drawing.Point(551, 479);
            this.pb12thTranscript.Name = "pb12thTranscript";
            this.pb12thTranscript.Size = new System.Drawing.Size(421, 244);
            this.pb12thTranscript.TabIndex = 9;
            this.pb12thTranscript.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(861, 714);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 38);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // frmUnderReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(998, 759);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panelDetail);
            this.Controls.Add(this.dgvUnderReviewList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmUnderReview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmUnderReview";
            this.Load += new System.EventHandler(this.frmUnderReview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnderReviewList)).EndInit();
            this.panelDetail.ResumeLayout(false);
            this.panelDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbidpictureback)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBirthCertificate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIdpictruefront)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb12thTranscript)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvUnderReviewList;
        private System.Windows.Forms.Panel panelDetail;
        private ctlPersonCard ctlPersonCard1;
        private System.Windows.Forms.PictureBox pbIdpictruefront;
        private Guna.UI2.WinForms.Guna2Button btnReject;
        private Guna.UI2.WinForms.Guna2Button btnApprove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbidpictureback;
        private System.Windows.Forms.PictureBox pbBirthCertificate;
        private System.Windows.Forms.PictureBox pb12thTranscript;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
    }
}