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
    public partial class ctlDrivingLicenseApplicationInfo : UserControl
    {
        int _LDLApplicationID;
        clsLocalDrivingLicenseApplication _LDLApplication;
        public ctlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private void _ResetPersonInfo()
        {
            _LDLApplicationID = -1;
            lblLocalDrivingLicenseApplicationID.Text = "[????]";
            lblAppliedFor.Text = "[????]";
            lblPassedTests.Text = "[????]";
            llShowLicenceInfo.Enabled = false;
        }

        private void _FillLDLApplicationInfo()
        {
            _LDLApplicationID = _LDLApplication.LocalDrivingLicenseApplicationID;
            lblLocalDrivingLicenseApplicationID.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedFor.Text = _LDLApplication.LicesnseClassInfo.ClassName;
            lblPassedTests.Text = "0/3"; //Not yet implemented
            ctlApplicationBasicInfo1.LoadBasicApplicationInfo(_LDLApplication.ApplicationID);
        }

        public void LoadLDLApplicationInfo(int LDLApplicationID)
        {
            _LDLApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationInfoByID(LDLApplicationID);
            if (_LDLApplication == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No Application with ApplicationID = " + _LDLApplication.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLDLApplicationInfo();
        }

        private void llShowLicenceInfo_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("This feature is not Implemented yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
