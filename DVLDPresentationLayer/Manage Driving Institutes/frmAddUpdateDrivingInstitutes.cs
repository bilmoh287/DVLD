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

namespace DVLDPresentationLayer
{
    public partial class frmAddUpdateDrivingInstitutes : Form
    {
        // Declare a delegate
        public delegate void IntituteSavedHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event IntituteSavedHandler OnInstituteSaved;

        enum enMode { AddNew = 0, Update = 1 };
        private int _InstituteID = -1;
        private clsDrivingInstitute _Institute  = new clsDrivingInstitute();
        enMode _Mode = enMode.AddNew;
        public frmAddUpdateDrivingInstitutes()
        {
            InitializeComponent();
            chkIsActive.Checked = true;
        }

        public frmAddUpdateDrivingInstitutes(int InstituteID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _InstituteID = InstituteID;

        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                //lblTitle.Text = "Add New Driving Institute";
                this.Text = "Add New Driving Institute";
                _Institute = new clsDrivingInstitute();
            }
            else
            {
                //lblTitle.Text = "Update Driving Institute";
                this.Text = "Update Driving Institute";
            }

            txtInstituteName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            chkIsActive.Checked = true;
            txtCommercialLicenseNo.Text = "";
            dtpLicenseExpiryDate.Value = DateTime.Now;
            txtManagerName.Text = "";
            numCapacity.Value = 0;
            pbLogo.Image = null;
            llRemoveLogo.Visible = false;
            lblDocumentFileName.Text = "No file";
        }


        private void _LoadData()
        {
            _Institute = clsDrivingInstitute.Find(_InstituteID);

            if (_Institute == null)
            {
                MessageBox.Show("No Institute with ID = " + _InstituteID, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            lblInstituteID.Text = _Institute.InstituteID.ToString();
            txtInstituteName.Text = _Institute.InstituteName;
            txtAddress.Text = _Institute.Address;
            txtPhone.Text = _Institute.Phone;
            txtEmail.Text = _Institute.Email;
            chkIsActive.Checked = _Institute.IsActive;

            txtCommercialLicenseNo.Text = _Institute.CommercialLicenseNo;
            dtpLicenseExpiryDate.Value = _Institute.LicenseExpiryDate;
            txtManagerName.Text = _Institute.ManagerName;
            numCapacity.Value = _Institute.Capacity;
            
            if (!string.IsNullOrEmpty(_Institute.LogoPath))
            {
                pbLogo.ImageLocation = _Institute.LogoPath;
                llRemoveLogo.Visible = true;
            }

            if (!string.IsNullOrEmpty(_Institute.DocumentPath))
            {
                lblDocumentFileName.Text = System.IO.Path.GetFileName(_Institute.DocumentPath);
            }
        }


        private void ManageDrivingInstitute_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtInstituteName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtInstituteName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtInstituteName, "Institute Name is required!");
            }
            else
            {
                errorProvider1.SetError(txtInstituteName, null);
            }
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtInstituteName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAddress, "Institute Address is required!");
            }
            else
            {
                errorProvider1.SetError(txtAddress, null);
            }

        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhone, "Phone number is required!");
            }
            else if (txtPhone.Text.Length < 9) // Basic length check
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhone, "Phone number is too short!");
            }
            else
            {
                errorProvider1.SetError(txtPhone, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text.Trim())) return; // Email is optional in some schemas

            // Using your existing clsValidation utility
            if (!clsValidation.ValidateEmail(txtEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address format (e.g., name@domain.com)!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid! Please check the red icons.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Assigning values from UI to the Business Object
            _Institute.InstituteName = txtInstituteName.Text.Trim();
            _Institute.Address = txtAddress.Text.Trim();
            _Institute.Phone = txtPhone.Text.Trim();
            _Institute.Email = txtEmail.Text.Trim();
            _Institute.IsActive = chkIsActive.Checked;
            _Institute.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            _Institute.CommercialLicenseNo = txtCommercialLicenseNo.Text.Trim();
            _Institute.LicenseExpiryDate = dtpLicenseExpiryDate.Value;
            _Institute.ManagerName = txtManagerName.Text.Trim();
            _Institute.Capacity = (int)numCapacity.Value;
            _Institute.LogoPath = pbLogo.ImageLocation;
            // DocumentPath is set during drag/click


            // Assuming current user ID is handled globally or passed to the form
            // _Institute.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_Institute.Save())
            {
                lblInstituteID.Text = _Institute.InstituteID.ToString();
                _Mode = enMode.Update; // Change mode to update after first save
                //lblTitle.Text = "Update Driving Institute";

                // Trigger the event
                OnInstituteSaved?.Invoke(this, _Institute.InstituteID);

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

        private void frmAddUpdateDrivingInstitutes_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void ctrl_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void pbLogo_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                pbLogo.ImageLocation = files[0];
                llRemoveLogo.Visible = true;
            }
        }

        private void llSetLogo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbLogo.ImageLocation = openFileDialog1.FileName;
                llRemoveLogo.Visible = true;
            }
        }

        private void llRemoveLogo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbLogo.ImageLocation = null;
            pbLogo.Image = null;
            llRemoveLogo.Visible = false;
        }

        private void pnlDocument_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                _HandleDocumentSelection(files[0]);
            }
        }

        private void pnlDocument_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All Files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _HandleDocumentSelection(openFileDialog1.FileName);
            }
        }

        private void _HandleDocumentSelection(string filePath)
        {
            _Institute.DocumentPath = filePath;
            lblDocumentFileName.Text = System.IO.Path.GetFileName(filePath);
        }
    }
}

