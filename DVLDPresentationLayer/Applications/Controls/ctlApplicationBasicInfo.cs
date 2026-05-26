using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBussinessLayer;
using DVLDPresentationLayer.Global_Classes;
using DVLDPresentationLayer.Properties;

namespace DVLDPresentationLayer
{
    public partial class ctlApplicationBasicInfo : UserControl
    {
        int _ApplicationID;
        //clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        clsApplication _Application;
        public ctlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        public int ApplicationID
        {
            get { return _ApplicationID; }
        }

        public void ResetBasicApplicationInfo()
        {
            _ApplicationID = -1;
            lblApplicationID.Text = "[????]";
            lblStatus.Text = "[????]";
            lblFees.Text = "[????]";
            lblType.Text = "[????]";
            lblApplicant.Text = "[????]";
            lblDate.Text = "[????]";
            lblStatusDate.Text = "[????]";
            lblCreatedByUser.Text = "[????]";
            llViewPersonInfo.Enabled = false;
        }

        private void _FillApplicationInfo()
        {
            _ApplicationID = _Application.ApplicationID;
            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblStatus.Text = _Application.StatusText;
            lblFees.Text = _Application.PaidFees.ToString();
            lblType.Text = _Application.ApplicationTypeInfo != null ? _Application.ApplicationTypeInfo.ApplicationTypeTitle : "Unknown";
            lblApplicant.Text = _Application.FullName;
            lblDate.Text = clsFormat.DateToShort(_Application.ApplicationDate);
            lblStatusDate.Text = clsFormat.DateToShort(_Application.LastStatusDate); ;
            lblCreatedByUser.Text = _Application.CreatedByUserInfo != null ? _Application.CreatedByUserInfo.UserName : "System (ID: " + _Application.CreatedByUserID + ")";
        }

        public void LoadBasicApplicationInfo(int ApplicationID)
        {
            _Application = clsApplication.Find(ApplicationID);
            if (_Application == null)
            {
                ResetBasicApplicationInfo();
                MessageBox.Show("No Application with ApplicationID = " + _ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillApplicationInfo();
        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(_Application.ApplicantPersonID);
            frm.ShowDialog();

        }
    }
}
