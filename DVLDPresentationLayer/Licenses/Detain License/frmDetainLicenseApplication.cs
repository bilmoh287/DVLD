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
            errorProvider1.SetError(txtFineFees, "Fee cannot be blank");
            llShowLicenseHistory.Enabled = true;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
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
                llShowLicenseInfo.Enabled = true;
            }
        }
    }
}
