using DVLDBussinessLayer;
using DVLDPresentationLayer.Applications.Application_Reviews;
using DVLDPresentationLayer.Applications.International_Driving_License;
using DVLDPresentationLayer.Applications.Relesease_Detained_Licenses;
using DVLDPresentationLayer.Applications.Renew_Local_License;
using DVLDPresentationLayer.Applications.Replace_Lost_or_Damaged_License;
using DVLDPresentationLayer.Global_Classes;
using DVLDPresentationLayer.Licenses.Detain_License;
using DVLDPresentationLayer.Tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    public partial class frmMain : Form
    {
        private bool _isLoggingOut = false;
        frmLogin _frmLogin;
        public frmMain(frmLogin LoginForm)
        {
            InitializeComponent();
            _frmLogin = LoginForm;
        }


        private void _ApplyPermissions()
        {
            // Users Management (Admin)
            usersToolStripMenuItem.Visible =
                clsGlobal.HasPermission(clsUserPermission.enPermissions.ManageUsers);

            // People
            peopleToolStripMenuItem.Visible =
                clsGlobal.HasPermission(clsUserPermission.enPermissions.ViewPeople);

            // Applications
            localLicenseToolStripMenuItem.Visible =
                clsGlobal.HasPermission(clsUserPermission.enPermissions.ManageApplications);

            localDrivingLicenseApplicationsToolStripMenuItem.Visible =
                clsGlobal.HasPermission(clsUserPermission.enPermissions.ManageApplications);

            // Tests
            manageTestTypesToolStripMenuItem.Visible =
                clsGlobal.HasPermission(clsUserPermission.enPermissions.ManageTests);

            manToolStripMenuItem.Visible =
                clsGlobal.HasPermission(clsUserPermission.enPermissions.ManageTests);

            // License Operations
            renewDrivingLicenseApplicationToolStripMenuItem.Visible =
                clsGlobal.HasPermission(clsUserPermission.enPermissions.IssueLicense);

            replacementForLostOrDamagedLicenseToolStripMenuItem.Visible =
                clsGlobal.HasPermission(clsUserPermission.enPermissions.IssueLicense);

            detainLicenseToolStripMenuItem1.Visible =
                clsGlobal.HasPermission(clsUserPermission.enPermissions.ManageDetainedLicenses);

            releaseLicenseToolStripMenuItem.Visible =
                clsGlobal.HasPermission(clsUserPermission.enPermissions.ManageDetainedLicenses);

            // Drivers
            driversToolStripMenuItem.Visible =
                clsGlobal.HasPermission(clsUserPermission.enPermissions.ViewPeople);

            // International License
            internationalLicenseToolStripMenuItem.Visible =
                clsGlobal.HasPermission(clsUserPermission.enPermissions.IssueLicense);

            // Institutes
            manageDrivingInstitutesToolStripMenuItem.Visible =
                clsGlobal.HasPermission(clsUserPermission.enPermissions.ManageInstitutes);

            manageTestTypesToolStripMenuItem.Visible =
                clsGlobal.HasPermission(clsUserPermission.enPermissions.ManageApplications);
        }
        
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPeople frm = new frmListPeople();
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListUsers frm = new frmListUsers();
            frm.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserInfo frm = new frmShowUserInfo(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _isLoggingOut = true;
            clsGlobal.Logout();

            _frmLogin.Show();
            this.Close();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!_isLoggingOut)
            {
                clsGlobal.Logout();
                Application.Exit();
            }
        }

        private void manToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListApplicationTypes frm = new frmListApplicationTypes();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestTypes frm = new frmListTestTypes();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicenseApplications frm = new frmListLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDrivers frm = new frmListDrivers();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewlLocalDrivingLicenseApplication frm = new frmRenewlLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLostOrDamagedLicense frm = new frmReplaceLostOrDamagedLicense();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm = new frmDetainLicenseApplication();
            frm.ShowDialog();
        }

        private void releaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();

        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses frm = new frmListDetainedLicenses();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalDrivingLicenseApplication frm = new frmInternationalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListInternationalLicenses frm = new frmListInternationalLicenses();
            frm.ShowDialog();
        }

        private void manageDrivingInstitutesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmListDrivingInstitutes frm = new frmListDrivingInstitutes();
            frm.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _ApplyPermissions();
        }

        private void listTrainingBatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTrainingBatches frm = new frmListTrainingBatches();
            frm.ShowDialog();
        }

        private void newApplicantStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUnderReview frm = new frmUnderReview();
            frm.ShowDialog();
        }

        private void scheduleTestForStudetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSheduleTestForAllStudets frm = new frmSheduleTestForAllStudets();
            frm.ShowDialog();
        }

        private void reviewApplicartionsForReplacementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReviewRenewalApplications frm = new frmReviewRenewalApplications();
            frm.ShowDialog();
        }

        private void reviewApplicationForLostOrDamagedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReviewForDamagedLicense frm = new frmReviewForDamagedLicense();
            frm.ShowDialog();
        }

        private void reviewApplicationForLostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReviewApplicationForLost frm = new frmReviewApplicationForLost();
            frm.ShowDialog();
        }
    }
}
