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
    public partial class frmAddUpdateLocalDrivingLicenseApplication : Form
    {
        // Declare a delegate
        public delegate void ApplicationSavedHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event ApplicationSavedHandler OnApplicationSaved;

        enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode = enMode.AddNew;
        int _LDLApplicationID;
        clsLocalDrivingLicenseApplication _LDLApplication;
        //clsUser _CreatedByUser = clsUser.FindByUserID(clsGlobal.CurrentUser.UserID);
        public frmAddUpdateLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }
        public frmAddUpdateLocalDrivingLicenseApplication(int LDLApplicationID)
        {
            InitializeComponent();
            _LDLApplicationID = LDLApplicationID;
            _Mode = enMode.Update;
        }
        public void _FillClassNameInComboBox()
        {
            DataTable dtLicenseClasses = clsLicenseClasses.GetAllLicenseClasses();
            cbLicenseClass.DataSource = dtLicenseClasses;
            cbLicenseClass.DisplayMember = "ClassName";
            cbLicenseClass.ValueMember = "LicenseClassID";
        }

        private void _ResetDefaultValues()
        {
            _FillClassNameInComboBox();
            if(_Mode == enMode.AddNew)
            {
                lblTitle.Text = "New Driving License Application";
                this.Name = lblTitle.Text;
                _LDLApplication = new clsLocalDrivingLicenseApplication();
                tpApplicationInfo.Enabled = false; 
                btnSave.Enabled = false;

                cbLicenseClass.SelectedIndex = cbLicenseClass.FindString("Class 3 - Ordinary driving license");
                lblLocalDrivingLicebseApplicationID.Text = "[???]";
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblFees.Text = clsApplicationTypes.FindApplicationType((int)clsApplication.enApplicationType.NewDrivingLicense).ApplicationTypeFees.ToString();
                lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            }
            else
            {
                lblTitle.Text = "Update Driving License Application";
                this.Name = lblTitle.Text;
                tpApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void _LoadLocalDrivingLicenseApplicationInfo()
        {
            _LDLApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationInfoByID(_LDLApplicationID);
            if (_LDLApplication == null)
            {
                MessageBox.Show("No LDLApplication with ID = " + _LDLApplication.ApplicantPersonID, "Applicaation Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }


            //lblTitle.Text = "Update User";
            ctlPersonCardWithFilter1.FilterEnables = false;
            lblLocalDrivingLicebseApplicationID.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = _LDLApplication.ApplicationDate.ToString();
            lblFees.Text = _LDLApplication.PaidFees.ToString();
            lblCreatedByUser.Text = clsUser.FindByUserID(_LDLApplication.CreatedByUserID).UserName;
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(_LDLApplication.LicesnseClassInfo.ClassName);
            ctlPersonCardWithFilter1.LoadPersonInfo(_LDLApplication.ApplicantPersonID);
        }
        private void frmAddUpdateLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
            {
                _LoadLocalDrivingLicenseApplicationInfo();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                tpApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
                tcLogin.SelectedTab = tcLogin.TabPages["tpApplicationInfo"];
                return;
            }

            //For Add New Local Driving License Case
            if (ctlPersonCardWithFilter1.PersonID != -1)
            {
                //Check if Person is already has Application
                if (clsLocalDrivingLicenseApplication.IsApplicationExist(_LDLApplicationID))
                {
                    MessageBox.Show("Selected Person is already a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctlPersonCardWithFilter1.FilterFocus();
                }
                else
                {
                    btnSave.Enabled = true;
                    tpApplicationInfo.Enabled = true;
                    tcLogin.SelectedTab = tcLogin.TabPages["tpApplicationInfo"];
                    this.AcceptButton = btnSave;
                }
            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctlPersonCardWithFilter1.FilterFocus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenseClassID = clsLicenseClasses.Find(cbLicenseClass.Text).LicenseClassID;

            //Check if the user have active application with the same License Calss
            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(ctlPersonCardWithFilter1.PersonID, clsApplication.enApplicationType.NewDrivingLicense, LicenseClassID);
            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }

            //Chec if the Applicant Person Age is Allowed for the specified License Class
            int MinimumAllowedAge = clsLicenseClasses.Find(cbLicenseClass.Text).MinimumAllowedAge;
            DateTime ApplicantDateOfBirth = clsPerson.Find(ctlPersonCardWithFilter1.PersonID).DateOfBirth;
            int ApplicantAge = clsUtil.GetDifferenceInYears(ApplicantDateOfBirth, DateTime.Now);
            //MessageBox.Show($"ApplicantAge = {ApplicantAge}, MinAge = {MinimumAllowedAge}");
            if (MinimumAllowedAge > ApplicantAge)
            {
                MessageBox.Show($"Person is not allowed for this Driving License Class, it requires a {MinimumAllowedAge} years old and above", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LDLApplication.ApplicantPersonID = ctlPersonCardWithFilter1.PersonID;
            _LDLApplication.ApplicationDate = Convert.ToDateTime(lblApplicationDate.Text);
            _LDLApplication.ApplicationTypeID = (byte)clsApplication.enApplicationType.NewDrivingLicense;
            _LDLApplication.LastStatusDate = DateTime.Now;
            _LDLApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LDLApplication.PaidFees = Convert.ToDecimal(lblFees.Text);
            _LDLApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _LDLApplication.LicenseClassID = LicenseClassID;

            if (_LDLApplication.SaveLDLA())
            {
                lblLocalDrivingLicebseApplicationID.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();
                _Mode = enMode.Update;
                lblTitle.Text = "Update Driving License Application";
                this.Text = lblTitle.Text;
                OnApplicationSaved?.Invoke(this, _LDLApplication.LocalDrivingLicenseApplicationID);
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAddUpdateLocalDrivingLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctlPersonCardWithFilter1.Focus();
        }
    }
}
