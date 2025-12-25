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

namespace DVLDPresentationLayer.Applications.International_Driving_License
{
    public partial class frmInternationalDrivingLicenseApplication : Form
    {
        private int _LicenseID = -1;
        private int _InternationalLicenseID = -1;
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

                    //check the license class, person could not issue international license without having
                    //normal license of class 3.
                    if (!clsLicenses.IsLicenseExistByPersonIDAndClassID(ctlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonInfo.PersonID, 3))
                    {
                        MessageBox.Show("Selected Applicant should've Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //check if person already have an active international license
                    int ActiveInternaionalLicenseID = clsInternationalLicenses.GetActiveInternationalLicenseIDByDriverID(ctlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID);

                    if (ActiveInternaionalLicenseID != -1)
                    {
                        MessageBox.Show("Person already have an active international license with ID = " + ActiveInternaionalLicenseID.ToString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        llShowLicenseInfo.Enabled = true;
                        _InternationalLicenseID = ActiveInternaionalLicenseID;
                        btnIssueInternationalLicense.Enabled = false;
                        return;
                    }
                    //filling Detain License Form
                    FillInternationalLicenseInfo(LicenseID);
                    _LicenseID = LicenseID;
                    btnIssueInternationalLicense.Enabled = true;
                }
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void frmInternationalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblApplicationDate.Text;
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(1));//add one year.
            lblFees.Text = clsApplicationTypes.FindApplicationType((int)clsApplication.enApplicationType.NewInternationalLicense).ApplicationTypeFees.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
        }

        private void btnIssueInternationalLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsInternationalLicenses InternationalLicense = new clsInternationalLicenses();
            //those are the information for the base application, because it inhirts from application, they are part of the sub class.

            InternationalLicense.ApplicantPersonID = ctlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            InternationalLicense.ApplicationDate = DateTime.Now;
            InternationalLicense.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            InternationalLicense.LastStatusDate = DateTime.Now;
            InternationalLicense.PaidFees = clsApplicationTypes.FindApplicationType((int)clsApplication.enApplicationType.NewInternationalLicense).ApplicationTypeFees;
            InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            InternationalLicense.DriverID = ctlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID;
            InternationalLicense.IssuedUsingLocalLicenseID = ctlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID;
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);

            InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (!InternationalLicense.SaveInternationa())
            {
                MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
            _InternationalLicenseID = InternationalLicense.InternationalLicenseID;
            lblInternationalLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
            MessageBox.Show("International License Issued Successfully with ID=" + InternationalLicense.InternationalLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnIssueInternationalLicense.Enabled = false;
            ctlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = ctlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
