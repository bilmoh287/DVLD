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

namespace DVLDPresentationLayer.Schools_Dashboard.Forms
{
    public partial class frmTakeAttendance : Form
    {
        private int _BatchID = -1;

        // Ensure the designer constructor still exists for form viewer compatibility, but ideally we use the parameterized one
        public frmTakeAttendance()
        {
            InitializeComponent();
        }

        public frmTakeAttendance(int BatchID)
        {
            InitializeComponent();
            _BatchID = BatchID;
        }

        private void frmTakeAttendance_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            if (_BatchID == -1)
            {
                MessageBox.Show("Invalid Batch ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            clsTrainingBatch batch = clsTrainingBatch.Find(_BatchID);
            if (batch == null)
            {
                MessageBox.Show("Batch not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblBatchName.Text = batch.BatchName;

            // Stop the grid from creating random extra columns
            dgvAttendance.AutoGenerateColumns = false;

            // Link your manual columns to the Data fields
            dgvAttendance.Columns["ApplicationID"].DataPropertyName = "ApplicationID";
            dgvAttendance.Columns["FullName"].DataPropertyName = "FullName";
            dgvAttendance.Columns["ClassName"].DataPropertyName = "ClassName";

            DataTable dtStudents = batch.GetApplicants();
            dgvAttendance.DataSource = dtStudents;

            // Show only the columns we want
            dgvAttendance.Columns["FullName"].Visible = true;
            dgvAttendance.Columns["ClassName"].Visible = true;
            dgvAttendance.Columns["IsPresent"].Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvAttendance.Rows.Count == 0) return;

            DateTime attendanceDate = dtpAttendanceDate.Value;
            int markedByUserID = clsGlobal.CurrentUser.UserID;

            int savedCount = 0;

            foreach (DataGridViewRow row in dgvAttendance.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["ApplicationID"].Value != null)
                {
                    int appID = Convert.ToInt32(row.Cells["ApplicationID"].Value);
                    
                    bool isPresent = false;
                    if (row.Cells["IsPresent"].Value != null && row.Cells["IsPresent"].Value != DBNull.Value)
                    {
                        isPresent = Convert.ToBoolean(row.Cells["IsPresent"].Value);
                    }

                    if (clsAttendance.MarkAttendance(appID, _BatchID, attendanceDate, isPresent, markedByUserID))
                    {
                        savedCount++;
                    }
                }
            }

            MessageBox.Show($"Successfully saved attendance for {savedCount} students!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
