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
using DVLDPresentationLayer.Properties;

namespace DVLDPresentationLayer
{
    public partial class ctlDriverLicenseInfo : UserControl
    {
        int _LicenseID = -1;
        clsLicenses _License;
        public ctlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public int LicenseID
        {
            get { return _LicenseID; }
        }

        public clsLicenses SelectedLicenseInfo
        {
            get { return _License; }
        }

        public string ChangeIsActivelbl
        {
            set { lblIsActive.Text = value; }
            get { return lblIsActive.Text; }
        }
        public string ChangeIsDetainedlbl
        {
            set { lblIsDetained.Text = value; }
            get { return lblIsDetained.Text; }
        }

        private void _LoadPersonImage()
        {
            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;
            if (ImagePath != "")
                pbPersonImage.ImageLocation = ImagePath;
            else
                pbPersonImage.Image = (_License.DriverInfo.PersonInfo.Gender == 0) ? Resources.Male_512 : Resources.Female_512;
        }
        private void _FillLicenseInfo()
        {
            lblClass.Text = _License.LicenseClassInfo.ClassName;
            lblFullName.Text = _License.DriverInfo.PersonInfo.FullName;
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = (_License.DriverInfo.PersonInfo.Gender == 0) ? "Male" : "Female";
            lblIssueDate.Text = clsFormat.DateToShort(_License.IssueDate);
            lblIssueReason.Text = _License.IssueReasonText;
            lblNotes.Text = _License.Notes;
            lblIsActive.Text = (_License.IsActive == true) ? "Yes" : "No";
            lblDateOfBirth.Text = clsFormat.DateToShort(_License.DriverInfo.PersonInfo.DateOfBirth);
            lblDriverID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text = clsFormat.DateToShort(_License.ExpirationDate);
            lblIsDetained.Text = _License.IsLicenseDetained() ? "Yes" : "No";
            pbPersonImage.Image = Resources.Male_512;

            _LoadPersonImage();
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicenses.Find(LicenseID);
            if (_License == null)
            {
                MessageBox.Show("Could not find License ID = " + _LicenseID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }

            _FillLicenseInfo();
        }
    }
}
