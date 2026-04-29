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
    public partial class frmAddUpdateBatch : Form
    {
        public delegate void DataBackEventHandler(object sender, int BatchID);
        public event DataBackEventHandler BatchSaved;

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        private int _BatchID = -1;
        private int _SelectedInstituteID = -1;
        private clsTrainingBatch _Batch;

        public frmAddUpdateBatch()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateBatch(int BatchID)
        {
            InitializeComponent();
            _BatchID = BatchID;
            _Mode = enMode.Update;
        }

        // Constructor to pre-select an institute (when adding from school dashboard)
        public frmAddUpdateBatch(bool isNew, int SelectedInstituteID)
        {
            InitializeComponent();
            _SelectedInstituteID = SelectedInstituteID;
            _Mode = enMode.AddNew;
        }

        private void _FillInstitutesInComboBox()
        {
            DataTable dtInstitutes = clsDrivingInstitute.GetAllInstitutes();
            cbInstitutes.DataSource = dtInstitutes;
            cbInstitutes.DisplayMember = "InstituteName";
            cbInstitutes.ValueMember = "InstituteID";

            if (_SelectedInstituteID != -1)
            {
                cbInstitutes.SelectedValue = _SelectedInstituteID;
                cbInstitutes.Enabled = false; // Lock it if we came from a specific school
            }
        }

        private void _ResetDefaultValues()
        {
            _FillInstitutesInComboBox();

            if (_Mode == enMode.AddNew)
            {
                this.Text = "Add New Batch";
                _Batch = new clsTrainingBatch();
                nudCapacity.Value = 20;
                dtpStartDate.Value = DateTime.Now;
                dtpEndDate.Value = DateTime.Now.AddMonths(1);
            }
            else
            {
                this.Text = "Update Batch";
            }

            txtBatchName.Text = "";
        }

        private void _LoadData()
        {
            _Batch = clsTrainingBatch.Find(_BatchID);

            if (_Batch == null)
            {
                MessageBox.Show("No Batch with ID = " + _BatchID, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            txtBatchName.Text = _Batch.BatchName;
            nudCapacity.Value = _Batch.MaxCapacity;
            dtpStartDate.Value = _Batch.StartDate;
            dtpEndDate.Value = _Batch.EndDate;
            cbInstitutes.SelectedValue = _Batch.InstituteID;
        }

        private void frmAddUpdateBatch_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBatchName.Text.Trim()))
            {
                MessageBox.Show("Batch Name cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dtpEndDate.Value <= dtpStartDate.Value)
            {
                MessageBox.Show("End Date must be after Start Date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Batch.InstituteID = (int)cbInstitutes.SelectedValue;
            _Batch.BatchName = txtBatchName.Text.Trim();
            _Batch.MaxCapacity = (int)nudCapacity.Value;
            _Batch.StartDate = dtpStartDate.Value;
            _Batch.EndDate = dtpEndDate.Value;

            if (_Batch.Save())
            {
                _Mode = enMode.Update;
                this.Text = "Update Batch";
                _BatchID = _Batch.BatchID;

                BatchSaved?.Invoke(this, _BatchID);

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data was not saved successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
