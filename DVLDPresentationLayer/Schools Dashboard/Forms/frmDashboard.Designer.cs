namespace DVLDPresentationLayer.Schools_Dashboard.Forms
{
    partial class frmDashboard
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
            this.panelTotalStudents = new System.Windows.Forms.Panel();
            this.panelActiveCourse = new System.Windows.Forms.Panel();
            this.paneInstructors = new System.Windows.Forms.Panel();
            this.panelTestsTodays = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelTotalStudents.SuspendLayout();
            this.panelActiveCourse.SuspendLayout();
            this.paneInstructors.SuspendLayout();
            this.panelTestsTodays.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTotalStudents
            // 
            this.panelTotalStudents.Controls.Add(this.label1);
            this.panelTotalStudents.Location = new System.Drawing.Point(25, 88);
            this.panelTotalStudents.Name = "panelTotalStudents";
            this.panelTotalStudents.Size = new System.Drawing.Size(200, 100);
            this.panelTotalStudents.TabIndex = 0;
            // 
            // panelActiveCourse
            // 
            this.panelActiveCourse.Controls.Add(this.label2);
            this.panelActiveCourse.Location = new System.Drawing.Point(280, 88);
            this.panelActiveCourse.Name = "panelActiveCourse";
            this.panelActiveCourse.Size = new System.Drawing.Size(200, 100);
            this.panelActiveCourse.TabIndex = 1;
            // 
            // paneInstructors
            // 
            this.paneInstructors.Controls.Add(this.label3);
            this.paneInstructors.Location = new System.Drawing.Point(530, 88);
            this.paneInstructors.Name = "paneInstructors";
            this.paneInstructors.Size = new System.Drawing.Size(200, 100);
            this.paneInstructors.TabIndex = 1;
            // 
            // panelTestsTodays
            // 
            this.panelTestsTodays.Controls.Add(this.label4);
            this.panelTestsTodays.Location = new System.Drawing.Point(778, 88);
            this.panelTestsTodays.Name = "panelTestsTodays";
            this.panelTestsTodays.Size = new System.Drawing.Size(200, 100);
            this.panelTestsTodays.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Students";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "ActiveCourses";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Instructors";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tests Today";
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 664);
            this.Controls.Add(this.panelTestsTodays);
            this.Controls.Add(this.paneInstructors);
            this.Controls.Add(this.panelActiveCourse);
            this.Controls.Add(this.panelTotalStudents);
            this.Name = "frmDashboard";
            this.Text = "frmDashboard";
            this.panelTotalStudents.ResumeLayout(false);
            this.panelTotalStudents.PerformLayout();
            this.panelActiveCourse.ResumeLayout(false);
            this.panelActiveCourse.PerformLayout();
            this.paneInstructors.ResumeLayout(false);
            this.paneInstructors.PerformLayout();
            this.panelTestsTodays.ResumeLayout(false);
            this.panelTestsTodays.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTotalStudents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelActiveCourse;
        private System.Windows.Forms.Panel paneInstructors;
        private System.Windows.Forms.Panel panelTestsTodays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}