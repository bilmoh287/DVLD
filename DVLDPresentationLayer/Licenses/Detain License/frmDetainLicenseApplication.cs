using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDPresentationLayer.Global_Classes;

namespace DVLDPresentationLayer.Licenses.Detain_License
{
    public partial class frmDetainLicenseApplication : Form
    {
        private int _LicenseID = -1;
        public frmDetainLicenseApplication()
        {
            InitializeComponent();
        }
        public frmDetainLicenseApplication(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }

        private void frmDetainLicenseApplication_Load(object sender, EventArgs e)
        {
            if(_LicenseID != -1)
            {
                ctlDriverLicenseInfoWithFilter1.LoadLicenseInfo(_LicenseID);
                ctlDriverLicenseInfoWithFilter1.FilterEnabled = false;

                //filling Detain License Form
                FillingDetainLicenseInfo(_LicenseID);
                btnDetain.Enabled = true;
            }
            else
            {
                ctlDriverLicenseInfoWithFilter1.FilterEnabled = true;
                ctlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
            }
        }

        private void ctlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            if(_LicenseID == -1)
            {
                int LicenseID = obj;
                if(LicenseID != -1)
                {
                    //ToDo: make sure the license is not detained already.
                    if (ctlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseDetained())
                    {
                        MessageBox.Show("Selected License is already detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //ToDo: make sure the license is Active before Detainmnet.
                    if (!ctlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
                    {
                        MessageBox.Show("Selected License is not Active, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //filling Detain License Form
                    FillingDetainLicenseInfo(LicenseID);
                    btnDetain.Enabled = true;
                }
            }
        }

        private void FillingDetainLicenseInfo(int LicenseID)
        {
            lblLicenseID.Text = LicenseID.ToString();
            lblDetainDate.Text = DateTime.Now.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserID.ToString();
            txtFineFees.Focus();
            llShowLicenseHistory.Enabled = true;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to Issue a Replacement for the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            string DetainReason = txtDetainReason.Text.Trim();
            string DetainPlace = txtDetainPlace.Text.Trim();
            decimal FineFee = Convert.ToDecimal(txtFineFees.Text.Trim());
            int UserID = clsGlobal.CurrentUser.UserID;

            int DetainID = ctlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Detain
                (DetainReason, DetainPlace, FineFee, UserID);

            if(DetainID != -1)
            {
                lblDetainID.Text = DetainID.ToString();
                MessageBox.Show("Licensed Detained Successfully, DetainID = " + DetainID.ToString(), "License Detained", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnDetain.Enabled = false;
                ctlDriverLicenseInfoWithFilter1.FilterEnabled = false;
                txtFineFees.Enabled = false;
                txtDetainReason.Enabled = false;
                txtDetainPlace.Enabled = false;
                llShowLicenseInfo.Enabled = true;
            }
            else
            {
                MessageBox.Show("Licensed Detainment Unsuccessfull.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = ctlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_LicenseID);
            frm.ShowDialog();
        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            // check if FineFee is empty
            if (string.IsNullOrEmpty(txtFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtFineFees, null);
            };
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
