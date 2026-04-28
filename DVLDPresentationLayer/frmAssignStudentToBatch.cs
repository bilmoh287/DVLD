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
    public partial class frmAssignStudentToBatch : Form
    {
        private int _InstituteID;
        private int _BatchID;
        private DataTable _dtEligibleStudents;

        public frmAssignStudentToBatch(int InstituteID, int BatchID)
        {
            InitializeComponent();
            _InstituteID = InstituteID;
            _BatchID = BatchID;
        }

        private void _RefreshList()
        {
            _dtEligibleStudents = clsTrainingBatch.GetEligibleStudents(_InstituteID);
            dgvEligibleStudents.DataSource = _dtEligibleStudents;
            lblRecordsCount.Text = _dtEligibleStudents.Rows.Count.ToString();
        }

        private void frmAssignStudentToBatch_Load(object sender, EventArgs e)
        {
            _RefreshList();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (dgvEligibleStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int ApplicationID = (int)dgvEligibleStudents.CurrentRow.Cells["ApplicationID"].Value;
            
            clsTrainingBatch batch = clsTrainingBatch.Find(_BatchID);
            
            if (batch.AssignApplicant(ApplicationID))
            {
                MessageBox.Show("Student assigned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshList();
            }
            else
            {
                MessageBox.Show("Error: Assignment failed. The batch might be full.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
             _dtEligibleStudents.DefaultView.RowFilter = string.Format("[FullName] LIKE '{0}%'", txtSearch.Text.Trim());
        }
    }
}
