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
    }
}
