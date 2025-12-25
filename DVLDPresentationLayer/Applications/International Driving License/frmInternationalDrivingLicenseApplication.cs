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

namespace DVLDPresentationLayer.Applications.International_Driving_License
{
    public partial class frmInternationalDrivingLicenseApplication : Form
    {
        private int _LicenseID = -1;
        public frmInternationalDrivingLicenseApplication()
        {
            InitializeComponent();
        }
        public frmInternationalDrivingLicenseApplication(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }
        private void FillInternationalLicenseInfo(int LicenseID)
        {
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            decimal ApplicationFee = clsApplicationTypes.FindApplicationType((int)clsApplication.enApplicationType.NewInternationalLicense).ApplicationTypeFees;
            lblFees.Text = ApplicationFee.ToString();
            lblLocalLicenseID.Text = LicenseID.ToString();

            llShowLicenseHistory.Enabled = true;
        }
        private void ctlDriverLicenseInfoWithFilter1_Load(object sender, EventArgs e)
        {
            if (_LicenseID != -1)
            {
                ctlDriverLicenseInfoWithFilter1.LoadLicenseInfo(_LicenseID);
                ctlDriverLicenseInfoWithFilter1.FilterEnabled = false;

                //filling Detain License Form
                FillInternationalLicenseInfo(_LicenseID);
                btnIssueInternationalLicense.Enabled = true;
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
                    if (ctlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseDetained())
                    {
                        MessageBox.Show("Selected License is detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //filling Detain License Form
                    FillInternationalLicenseInfo(LicenseID);
                    btnIssueInternationalLicense.Enabled = true;
                }
            }
        }
    }
}
