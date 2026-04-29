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

        private void _SetupColumns()
        {
            if (dgvEligibleStudents.Columns.Count == 0) return;

            dgvEligibleStudents.Columns["ApplicationID"].HeaderText = "App ID";
            dgvEligibleStudents.Columns["ApplicationID"].Width = 80;
            dgvEligibleStudents.Columns["ApplicationID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvEligibleStudents.Columns["FullName"].HeaderText = "Full Name";
            dgvEligibleStudents.Columns["FullName"].Width = 300;
            dgvEligibleStudents.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvEligibleStudents.Columns["ClassName"].HeaderText = "License Class";
            dgvEligibleStudents.Columns["ClassName"].Width = 280;
            dgvEligibleStudents.Columns["ClassName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvEligibleStudents.Columns["Phone"].HeaderText = "Phone";
            dgvEligibleStudents.Columns["Phone"].Width = 150;
            dgvEligibleStudents.Columns["Phone"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvEligibleStudents.Columns["ApplicationDate"].HeaderText = "Application Date";
            dgvEligibleStudents.Columns["ApplicationDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void frmAssignStudentToBatch_Load(object sender, EventArgs e)
        {
            _RefreshList();
            _SetupColumns();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (dgvEligibleStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one student.", "Selection Required", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }

            clsTrainingBatch batch = clsTrainingBatch.Find(_BatchID);
            if (batch == null) return;

            int successCount = 0;
            int failCount = 0;

            foreach (DataGridViewRow row in dgvEligibleStudents.SelectedRows)
            {
                int ApplicationID = (int)row.Cells["ApplicationID"].Value;
                if (batch.AssignApplicant(ApplicationID))
                    successCount++;
                else
                    failCount++;
            }

            if (successCount > 0)
                MessageBox.Show($"{successCount} student(s) assigned successfully!" + 
                                (failCount > 0 ? $"\n{failCount} failed (batch may be full)." : ""),
                                "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Assignment failed. The batch might be full.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            _RefreshList();
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
