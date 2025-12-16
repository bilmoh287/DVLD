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
    public partial class frmIssueDriverLicenseFirstTime : Form
    {
        private int _LDLApplicationID;
        private clsLocalDrivingLicenseApplication _LDLApplication;
        public frmIssueDriverLicenseFirstTime(int LDLApplicationID)
        {
            InitializeComponent();
            _LDLApplicationID = LDLApplicationID;
            _LDLApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationInfoByID(_LDLApplicationID);
        }

        private void frmIssueDriverLicenseFirstTime_Load(object sender, EventArgs e)
        {
            if (_LDLApplication == null)
            {

                MessageBox.Show("No Applicaiton with ID=" + _LDLApplicationID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }


            if (!_LDLApplication.PassedAllTest(_LDLApplicationID))
            {

                MessageBox.Show("Person Should Pass All Tests First.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctlDrivingLicenseApplicationInfo1.LoadLDLApplicationInfo(_LDLApplicationID);
        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            int LicenseID = _LDLApplication.IssueLicenseForTheFirtTime(txtNotes.Text.Trim(), clsGlobal.CurrentUser.UserID);

            if (LicenseID != -1)
            {
                MessageBox.Show("License Issued Successfully with License ID = " + LicenseID.ToString(),
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("License Was not Issued ! ",
                 "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
