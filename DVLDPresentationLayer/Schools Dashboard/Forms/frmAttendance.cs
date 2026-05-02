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
    public partial class frmAttendance : Form
    {
        private int _BatchID = -1;

        public frmAttendance()
        {
            InitializeComponent();
        }

        public frmAttendance(int BatchID)
        {
            InitializeComponent();
            _BatchID = BatchID;
        }

        private void frmAttendance_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _LoadData()
        {
            if (_BatchID == -1) return;

            clsTrainingBatch batch = clsTrainingBatch.Find(_BatchID);
            if (batch == null) return;

            lblBatchName.Text = batch.BatchName;

            dgvAttendance.AutoGenerateColumns = false;
            dgvAttendance.Columns["ApplicationID"].DataPropertyName = "ApplicationID";
            dgvAttendance.Columns["FullName"].DataPropertyName = "FullName";
            dgvAttendance.Columns["ClassName"].DataPropertyName = "ClassName";

            dgvAttendance.DataSource = batch.GetApplicants();

            dgvAttendance.Columns["FullName"].Visible = true;
            dgvAttendance.Columns["ClassName"].Visible = true;
            dgvAttendance.Columns["IsPresent"].Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime attendanceDate = dtpAttendanceDate.Value;
            int markedByUserID = clsGlobal.CurrentUser.UserID;

            int savedCount = 0;

            foreach (DataGridViewRow row in dgvAttendance.Rows)
            {
                if (row.IsNewRow) continue;

                int appID = Convert.ToInt32(row.Cells["ApplicationID"].Value);
                bool isPresent = false;
                
                if (row.Cells["IsPresent"].Value != null && row.Cells["IsPresent"].Value != DBNull.Value)
                    isPresent = Convert.ToBoolean(row.Cells["IsPresent"].Value);

                if (clsAttendance.MarkAttendance(appID, _BatchID, attendanceDate, isPresent, markedByUserID))
                {
                    savedCount++;
                }
            }

            MessageBox.Show($"Attendance saved for {savedCount} students.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
