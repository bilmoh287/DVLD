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

namespace DVLDPresentationLayer
{
    public partial class frmListTrainingBatches : Form
    {
        private int _InstituteID = -1;
        private DataTable _dtAllBatches;

        public frmListTrainingBatches()
        {
            InitializeComponent();
        }

        public frmListTrainingBatches(int InstituteID)
        {
            InitializeComponent();
            _InstituteID = InstituteID;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void _RefreshBatchesList()
        {
            if (_InstituteID == -1)
                _dtAllBatches = clsTrainingBatch.GetAllBatches();
            else
                _dtAllBatches = clsTrainingBatch.GetBatchesByInstituteID(_InstituteID);

            dgvBatchesList.DataSource = _dtAllBatches;
            _UpdateKPIs();
            
            if (dgvBatchesList.Rows.Count > 0)
            {
                dgvBatchesList.Columns["TrainingBatchID"].HeaderText = "ID";
                dgvBatchesList.Columns["TrainingBatchID"].Width = 60;

                if (_InstituteID == -1)
                {
                    dgvBatchesList.Columns["InstituteName"].HeaderText = "Institute";
                    dgvBatchesList.Columns["InstituteName"].Width = 200;
                }

                dgvBatchesList.Columns["BatchName"].HeaderText = "Batch Name";
                dgvBatchesList.Columns["BatchName"].Width = 250;

                dgvBatchesList.Columns["StartDate"].HeaderText = "Start Date";
                dgvBatchesList.Columns["StartDate"].Width = 120;

                dgvBatchesList.Columns["EndDate"].HeaderText = "End Date";
                dgvBatchesList.Columns["EndDate"].Width = 120;

                dgvBatchesList.Columns["MaxCapacity"].HeaderText = "Capacity";
                dgvBatchesList.Columns["MaxCapacity"].Width = 80;

                dgvBatchesList.Columns["CurrentStudents"].HeaderText = "Enrolled";
                dgvBatchesList.Columns["CurrentStudents"].Width = 80;
            }
        }

        private void _UpdateKPIs()
        {
            lblActiveBatches.Text = _dtAllBatches.Rows.Count.ToString();

            int totalCapacity = 0;
            int totalEnrolled = 0;
            int startingSoon = 0;
            int startingToday = 0;
            int upcomingCount = 0;
            DateTime soonDate = DateTime.Now.AddDays(7);

            foreach (DataRow row in _dtAllBatches.Rows)
            {
                int capacity = Convert.ToInt32(row["MaxCapacity"]);
                int enrolled = Convert.ToInt32(row["CurrentStudents"]);
                totalCapacity += capacity;
                totalEnrolled += enrolled;

                DateTime startDate = Convert.ToDateTime(row["StartDate"]);
                
                if (startDate.Date == DateTime.Now.Date)
                    startingToday++;

                if (startDate > DateTime.Now)
                    upcomingCount++;

                if (startDate >= DateTime.Now && startDate <= soonDate)
                {
                    startingSoon++;
                }
            }

            lblTotalCapacity.Text = totalCapacity.ToString();
            lblStartingSoon.Text = startingSoon.ToString();

            // Dynamic Colored Labels
            lblNewBaches.Text = $"+{upcomingCount} Upcoming";
            
            double utilization = totalCapacity > 0 ? (double)totalEnrolled / totalCapacity * 100 : 0;
            lblNewStudents.Text = $"{utilization:0}% Seats Filled";
            
            lblUpcomingStudents.Text = $"{startingToday} Starting Today";
        }

        private void frmListTrainingBatches_Load(object sender, EventArgs e)
        {
            _RefreshBatchesList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddBatch_Click(object sender, EventArgs e)
        {
            frmAddUpdateBatch frm;
            
            if (_InstituteID != -1)
                frm = new frmAddUpdateBatch(true, _InstituteID);
            else
                frm = new frmAddUpdateBatch();

            frm.BatchSaved += _RefreshBatchesList;
            frm.ShowDialog();
        }

        private void editBatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int BatchID = (int)dgvBatchesList.CurrentRow.Cells["TrainingBatchID"].Value;
            frmAddUpdateBatch frm = new frmAddUpdateBatch(BatchID);
            frm.BatchSaved += _RefreshBatchesList;
            frm.ShowDialog();
        }

        private void deleteBatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this batch?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int BatchID = (int)dgvBatchesList.CurrentRow.Cells["TrainingBatchID"].Value;

            //if (clsTrainingBatch.dele(BatchID))
            //{
            //    MessageBox.Show("Batch Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    _RefreshBatchesList();
            //}
            //else
            //{
            //    MessageBox.Show("Error: Could not delete batch. It might be linked to other data (Enrollments).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void _RefreshBatchesList(object sender, int BatchID)
        {
            _RefreshBatchesList();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string filterColumn = "BatchName";
            
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                _dtAllBatches.DefaultView.RowFilter = "";
            }
            else
            {
                _dtAllBatches.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", filterColumn, txtSearch.Text.Trim());
            }
        }
    }
}
