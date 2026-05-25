using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBussinessLayer;
using DVLDPresentationLayer.Global_Classes;

namespace DVLDPresentationLayer.Tests
{
    public partial class frmSheduleTestForAllStudets : Form
    {
        public frmSheduleTestForAllStudets()
        {
            InitializeComponent();
            
            // Wire up event handlers in constructor to keep designer cleaner
            this.Load += frmSheduleTestForAllStudets_Load;
            btnScheduleVisionTest.Click += btnScheduleVisionTest_Click;
            btnScheduleStreetTest.Click += btnScheduleStreetTest_Click;
            btnClose.Click += btnClose_Click;
        }

        private void frmSheduleTestForAllStudets_Load(object sender, EventArgs e)
        {
            _LoadEligibleStudents();
        }

        private void _LoadEligibleStudents()
        {
            DataTable dt = clsTrainingBatch.GetStudentsEligibleForTestScheduling();
            dataGridView1.DataSource = dt;
            lblRecordsCount.Text = dt.Rows.Count.ToString();

            // Set grid styling
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns["ApplicationID"].HeaderText = "App ID";
                dataGridView1.Columns["LocalDrivingLicenseApplicationID"].HeaderText = "LDL App ID";
                dataGridView1.Columns["FullName"].HeaderText = "Full Name";
                dataGridView1.Columns["ClassName"].HeaderText = "License Class";
                dataGridView1.Columns["Phone"].HeaderText = "Phone";
                dataGridView1.Columns["InstituteName"].HeaderText = "Institute Name";

                dataGridView1.Columns["FullName"].Width = 200;
                dataGridView1.Columns["ClassName"].Width = 200;
                dataGridView1.Columns["InstituteName"].Width = 200;
            }
        }

        private void _BatchSchedule(int testTypeID, string testName)
        {
            // Schedule test for tomorrow morning at 9:00 AM as general scheduling
            DateTime appointmentDate = DateTime.Now.AddDays(1);
            appointmentDate = new DateTime(appointmentDate.Year, appointmentDate.Month, appointmentDate.Day, 9, 0, 0);

            // Confirm prompt
            DialogResult confirm = MessageBox.Show($"Are you sure you want to batch schedule a {testName} for all eligible students on {appointmentDate:yyyy-MM-dd HH:mm}?", 
                "Confirm Batch Scheduling", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.No) return;

            int scheduledCount = 0;
            int skippedCount = 0;

            int currentUserID = (clsGlobal.CurrentUser != null) ? clsGlobal.CurrentUser.UserID : 1;
            
            // Call the fast optimized BLL method
            clsTrainingBatch.BatchScheduleTest(testTypeID, appointmentDate, currentUserID, out scheduledCount, out skippedCount);

            MessageBox.Show($"Batch scheduling complete!\n\nScheduled: {scheduledCount} student(s)\nSkipped / Prerequisites Not Met: {skippedCount} student(s)", 
                "Batch Results", MessageBoxButtons.OK, MessageBoxIcon.Information);

            _LoadEligibleStudents();
        }

        // Hooked from Designer (btnScheduleWrittenTest)
        private void button4_Click(object sender, EventArgs e)
        {
            _BatchSchedule(2, "Written Test");
        }

        private void btnScheduleVisionTest_Click(object sender, EventArgs e)
        {
            _BatchSchedule(1, "Vision Test");
        }

        private void btnScheduleStreetTest_Click(object sender, EventArgs e)
        {
            _BatchSchedule(3, "Street Test");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnScheduleVisionTest_Click_1(object sender, EventArgs e)
        {

        }
    }
}
