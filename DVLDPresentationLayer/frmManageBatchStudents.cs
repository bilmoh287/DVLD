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
            lblCapacity.Text = $"{_dtBatchStudents.Rows.Count} / {_Batch.MaxCapacity}";
        }

        private void _SetupColumns()
        {
            if (dgvStudents.Columns.Count == 0) return;

            if (dgvStudents.Columns["ApplicationID"] != null)
            {
                dgvStudents.Columns["ApplicationID"].HeaderText = "App ID";
                dgvStudents.Columns["ApplicationID"].Width = 80;
                dgvStudents.Columns["ApplicationID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            if (dgvStudents.Columns["FullName"] != null)
            {
                dgvStudents.Columns["FullName"].HeaderText = "Full Name";
                dgvStudents.Columns["FullName"].Width = 280;
                dgvStudents.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            if (dgvStudents.Columns["ClassName"] != null)
            {
                dgvStudents.Columns["ClassName"].HeaderText = "License Class";
                dgvStudents.Columns["ClassName"].Width = 280;
                dgvStudents.Columns["ClassName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            if (dgvStudents.Columns["Phone"] != null)
            {
                dgvStudents.Columns["Phone"].HeaderText = "Phone";
                dgvStudents.Columns["Phone"].Width = 150;
                dgvStudents.Columns["Phone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            if (dgvStudents.Columns["AssignedDate"] != null)
            {
                dgvStudents.Columns["AssignedDate"].HeaderText = "Assigned Date";
                dgvStudents.Columns["AssignedDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
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
            _SetupColumns();
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
