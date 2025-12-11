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
    public partial class ctlScheduleTest : UserControl
    {
        // Event declaration: Notifies subscribers when calculation is complete
        public event Action<int> OnTestAppointmentSaved;
        // Optional helper method to raise the event safely
        public virtual void TestAppointmentSaved(int PersonID)
        {
            Action<int> handler = OnTestAppointmentSaved;
            if (handler != null) 
            {
                handler(PersonID);
            }
        }

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        public enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1 };
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;

        private clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.VisionTest;
        private clsLocalDrivingLicenseApplication _LDLApplication;
        private int _LDLApplicationID = -1;
        private clsTestAppointments _TestAppointment;
        private int _TestAppointmentID = -1;
        public ctlScheduleTest()
        {
            InitializeComponent();
        }

        public clsTestTypes.enTestType TestTypeID 
        {   get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;
                switch(_TestTypeID)
                { 
                    case clsTestTypes.enTestType.VisionTest:
                        gbTestType.Text = "Vision Test";
                        pbTestTypeImage.Image = Resources.Vision_512;
                        break;
                    case clsTestTypes.enTestType.WrittenTest:
                        gbTestType.Text = "Written Test";
                        pbTestTypeImage.Image = Resources.Written_Test_512;
                        break;
                    case clsTestTypes.enTestType.StreetTest:
                        gbTestType.Text = "Street Test";
                        pbTestTypeImage.Image = Resources.driving_test_512;
                        break;
                }
                    
            }
        }

        public void ResetTestAppointmentInfo()
        {
            _TestAppointmentID = -1;
            lblLocalDrivingLicenseAppID.Text = "[????]";
            lblDrivingClass.Text = "[????]";
            lblFees.Text = "[????]";
            lblFullName.Text = "[????]";
            lblTrial.Text = "[????]";
            lblRetakeTestAppID.Text = "[????]";
            lblRetakeAppFees.Text = "[????]";
            lblTotalFees.Text = "[????]";
            gbRetakeTestInfo.Enabled = false;

        }

        private void _FillAppointmentInfo()
        {
            _TestAppointment = new clsTestAppointments();
            //_TestAppointmentID = _TestAppointment.TestAppointmentID;
            lblLocalDrivingLicenseAppID.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _LDLApplication.LicesnseClassInfo.ClassName;
            lblFees.Text = _LDLApplication.PaidFees.ToString();
            lblFullName.Text = _LDLApplication.FullName;
            dtpTestDate.Value = DateTime.Now;
            lblUserMessage.Text = "";
            lblTrial.Text = "0"; // not yet implemented
            lblRetakeTestAppID.Text = "[N/A]";
            lblRetakeAppFees.Text = "[????]";
            lblTotalFees.Text = _LDLApplication.PaidFees.ToString();
        }

        public void LoadScheduleTestInfo(int LDLApplicationID, int AppointmnetID = -1)
        {
            //if no appointment id this means AddNew mode otherwise it's update mode.
            if (AppointmnetID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

            _TestAppointmentID = AppointmnetID;
            _LDLApplicationID = LDLApplicationID;
            _LDLApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationInfoByID(LDLApplicationID);

            if (_LDLApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LDLApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetTestAppointmentInfo();
                btnSave.Enabled = false;
                return;
            }

            if()
            ResetTestAppointmentInfo();
            _FillAppointmentInfo();
        }

        public void LoadScheduleTestInfo()
        {
            //_TestAppointment = clsTestAppointments.Find(TestAppointmentsID);
            if (_TestAppointment == null)
            {
                ResetTestAppointmentInfo();
                MessageBox.Show("No Appointmnent with AppointmnentID = " + _TestAppointmentID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ResetTestAppointmentInfo();

            //_FillAppointmentInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Step 1: Validate form
            if (!ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Step 2: Assign values from UI to business object
            _TestAppointment.LocalDrivingLicenseApplicationID = _LDLApplication.LocalDrivingLicenseApplicationID;
            _TestAppointment.TestTypeID = _TestAppointment.TestTypeID;
            _TestAppointment.AppointmentDate = dtpTestDate.Value;
            _TestAppointment.PaidFees = Convert.ToDecimal(lblTotalFees.Text);
            _TestAppointment.IsLocked = true;
            _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.PersonID;

            // Step 3: Save
            if (_TestAppointment.Save())
            {
                //lblTitle.Text = _TestAppointment.UserID.ToString();
                //OnTestAppointmentSaved?.Invoke(this, _TestAppointment.TestAppointmentID);
                TestAppointmentSaved(_TestAppointmentID);
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
