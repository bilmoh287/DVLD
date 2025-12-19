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

namespace DVLDPresentationLayer.Applications.Replace_Lost_or_Damaged_License
{
    public partial class frmReplaceLostOrDamagedLicense : Form
    {
        public frmReplaceLostOrDamagedLicense()
        {
            InitializeComponent();
        }
        private int _NewLicenseID = -1;
        private clsApplication.enApplicationType _ReplacementType;
        private clsLicenses.enIssueReason _IssueReason;

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbDamagedLicense.Checked)
                return;
            _ReplacementType = clsApplication.enApplicationType.ReplaceDamagedDrivingLicense;
            _IssueReason = clsLicenses.enIssueReason.ReplacementForDamaged;
            UpateUI();
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbLostLicense.Checked)
                return;
            _ReplacementType = clsApplication.enApplicationType.ReplaceLostDrivingLicense;
            _IssueReason = clsLicenses.enIssueReason.ReplacementForLost;
            UpateUI();
        }

        private void UpateUI()
        {
            lblTitle.Text = _ReplacementType == clsApplication.enApplicationType.ReplaceDamagedDrivingLicense ?
                "Replacement for Damaged License" : "Replacement for Lost License";
            this.Text = lblTitle.Text;
            lblApplicationFees.Text = clsApplicationTypes.FindApplicationType((int)_ReplacementType).ApplicationTypeFees.ToString();
        }

        private void frmReplaceLostOrDamagedLicense_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            _ReplacementType = clsApplication.enApplicationType.ReplaceDamagedDrivingLicense;
            _IssueReason = clsLicenses.enIssueReason.ReplacementForDamaged;
            UpateUI();
        }

        private void ctlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;
            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            llShowLicenseHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)
            {
                return;
            }

            //dont allow a replacement if is Active .
            if (!ctlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
                return;
            }

            btnIssueReplacement.Enabled = true;
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Issue a Replacement for the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            clsLicenses NewLicense =
               ctlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Replace(_IssueReason,
               clsGlobal.CurrentUser.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Issue a replacemnet for this  License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;

            lblRreplacedLicenseID.Text = _NewLicenseID.ToString();
            MessageBox.Show("Licensed Replaced Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnIssueReplacement.Enabled = false;
            gbReplacementFor.Enabled = false;
            ctlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;
            ctlDriverLicenseInfoWithFilter1.ChangeIsActivelbl = "No";
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = ctlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }
    }
}
