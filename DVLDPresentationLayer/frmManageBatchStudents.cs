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
    public partial class frmManageBatchStudents : Form
    {
        private int _BatchID;
        private clsTrainingBatch _Batch;
        private DataTable _dtBatchStudents;

        public frmManageBatchStudents(int BatchID)
        {
            InitializeComponent();
            _BatchID = BatchID;
        }

        private void _RefreshStudentsList()
        {
            _dtBatchStudents = _Batch.GetApplicants();
            dgvStudents.DataSource = _dtBatchStudents;
            lblRecordsCount.Text = _dtBatchStudents.Rows.Count.ToString();
            
            // Update capacity label
            lblCapacity.Text = $"{_dtBatchStudents.Rows.Count} / {_Batch.MaxCapacity}";
        }

        private void frmManageBatchStudents_Load(object sender, EventArgs e)
        {
            _Batch = clsTrainingBatch.Find(_BatchID);
            if (_Batch == null)
            {
                MessageBox.Show("No Batch with ID = " + _BatchID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblBatchName.Text = _Batch.BatchName;
            _RefreshStudentsList();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            // Open selection form
            frmAssignStudentToBatch frm = new frmAssignStudentToBatch(_Batch.InstituteID, _BatchID);
            frm.ShowDialog();
            _RefreshStudentsList();
        }

        private void removeStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove this student from the batch?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int ApplicationID = (int)dgvStudents.CurrentRow.Cells["ApplicationID"].Value;

            if (clsTrainingBatch.RemoveApplicant(ApplicationID, _BatchID))
            {
                _RefreshStudentsList();
            }
            else
            {
                MessageBox.Show("Error: Could not remove student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
