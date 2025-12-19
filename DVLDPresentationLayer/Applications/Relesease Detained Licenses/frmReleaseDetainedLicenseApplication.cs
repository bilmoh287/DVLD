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
using DVLDPresentationLayer.Licenses;

namespace DVLDPresentationLayer.Applications.Relesease_Detained_Licenses
{
    public partial class frmReleaseDetainedLicenseApplication : Form
    {
        private int _LicenseID = -1;
        private clsDetainedLicenses _DetainedLicense;
        public frmReleaseDetainedLicenseApplication()
        {
            InitializeComponent();
        }
        public frmReleaseDetainedLicenseApplication(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }
        private void FillingDetainLicenseInfo(int LicenseID)
        {
            lblDetainID.Text = _DetainedLicense.DetainID.ToString();
            lblLicenseID.Text = LicenseID.ToString();
            lblDetainDate.Text = clsFormat.DateToShort(_DetainedLicense.DetainDate);
            lblCreatedByUser.Text = clsUser.FindByUserID(_DetainedLicense.CreatedByUserID).UserName;
            decimal ApplicationFee = clsApplicationTypes.FindApplicationType((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).ApplicationTypeFees;
            lblApplicationFees.Text = ApplicationFee.ToString();
            lblFineFees.Text = _DetainedLicense.FineFees.ToString();
            lblTotalFees.Text = (ApplicationFee + _DetainedLicense.FineFees).ToString();

            llShowLicenseHistory.Enabled = true;
        }
        private void frmReleaseDetainedLicenseApplication_Load(object sender, EventArgs e)
        {
            if (_LicenseID != -1)
            {
                ctlDriverLicenseInfoWithFilter1.LoadLicenseInfo(_LicenseID);
                ctlDriverLicenseInfoWithFilter1.FilterEnabled = false;

                //filling Detain License Form
                FillingDetainLicenseInfo(_LicenseID);
                _DetainedLicense = clsDetainedLicenses.FindByLicenseID(_LicenseID);
                btnRelease.Enabled = true;
            }
            else
            {
                ctlDriverLicenseInfoWithFilter1.FilterEnabled = true;
                ctlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
            }
        }

        private void ctlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            if (_LicenseID == -1)
            {
                int LicenseID = obj;
                if (LicenseID != -1)
                {
                    _LicenseID = LicenseID;
                    //ToDo: make sure the license is Active before Detainmnet.
                    if (!ctlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
                    {
                        MessageBox.Show("Selected License is not Active, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //ToDo: make sure the license is not detained already.
                    if (!ctlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseDetained())
                    {
                        MessageBox.Show("Selected License is NOT detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //filling Detain License Form
                    _DetainedLicense = clsDetainedLicenses.FindByLicenseID(LicenseID);
                    FillingDetainLicenseInfo(LicenseID);
                    btnRelease.Enabled = true;
                }
            }
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Release thi License?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int ApplicationID = ctlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Release(clsGlobal.CurrentUser.UserID);
            if (ApplicationID != -1)
            {
                lblApplicationID.Text = ApplicationID.ToString();
                MessageBox.Show("Licensed Released Successfully.", "License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnRelease.Enabled = false;
                ctlDriverLicenseInfoWithFilter1.FilterEnabled = false;
                llShowLicenseInfo.Enabled = true;
                ctlDriverLicenseInfoWithFilter1.ChangeIsDetainedlbl = "No";
            }
            else
            {
                MessageBox.Show("Failed to Release License.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
