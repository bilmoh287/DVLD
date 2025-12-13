using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

        private bool _FillAppointmentInfo()
        {
            _TestAppointment = clsTestAppointments.Find(_TestAppointmentID);
            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No Appointment with ID = " + _TestAppointmentID.ToString(),
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }

            lblFees.Text = _TestAppointment.PaidFees.ToString();
            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
                dtpTestDate.MinDate = DateTime.Now;
            else
                dtpTestDate.MinDate = _TestAppointment.AppointmentDate;
            dtpTestDate.Value = _TestAppointment.AppointmentDate;

            if(_TestAppointment.RetakeTestApplicationID == -1)
            {
                gbRetakeTestInfo.Enabled = false;
                lblRetakeTestAppID.Text = "-1";
                lblRetakeAppFees.Text = "0";
            }
            else
            {
                lblRetakeAppFees.Text = clsApplication.Find((int)clsApplication.enApplicationType.RetakeTest).PaidFees.ToString();
                gbRetakeTestInfo.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRetakeTestAppID.Text = _TestAppointment.RetakeTestApplicationID.ToString();
            }
            return true;
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
                btnSave.Enabled = false;
                return;
            }


            if (_Mode == enMode.AddNew)
            {
                lblFees.Text = clsTestTypes.Find(_TestTypeID).TestTypeFees.ToString();
                dtpTestDate.MinDate = DateTime.Now;
                lblRetakeTestAppID.Text = "N/A";

                _TestAppointment = new clsTestAppointments();
            }

            else
            {
                if (!_FillAppointmentInfo())
                    return;
            }

            //checksif the Appointment it for Retake Test or Not
            if (_LDLApplication.DoesAttendTestType((int)_TestTypeID))
                _CreationMode = enCreationMode.RetakeTestSchedule;
            else
                _CreationMode = enCreationMode.FirstTimeSchedule;

            // FIll the Retake Test info Based on the Creation Mode
            if(_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                decimal RetakeTestFee = clsApplication.Find((int)clsApplication.enApplicationType.RetakeTest).PaidFees;
                lblRetakeAppFees.Text = RetakeTestFee.ToString();
                gbRetakeTestInfo.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRetakeTestAppID.Text = "-1";
                lblTotalFees.Text = (_TestAppointment.PaidFees + RetakeTestFee).ToString();
            }
            else
            {
                gbRetakeTestInfo.Enabled = false;
                lblRetakeAppFees.Text = "0";
                lblTitle.Text = "Schedule Test";
                lblRetakeTestAppID.Text = "N/A";

            }

            lblLocalDrivingLicenseAppID.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _LDLApplication.LicesnseClassInfo.ClassName;
            lblFullName.Text = _LDLApplication.FullName;
            lblTrial.Text = "0"; // not yet implemented

            if (!_HandleActiveTestAppointmentConstraint())
                return;
            if (!_HandleAppointmentLockedConstraint())
                return;
            if (!_HandlePrviousTestConstraint())
                return;
        }


        private bool _HandleActiveTestAppointmentConstraint()
        {
            if(_Mode == enMode.AddNew && _LDLApplication.IsThereAnActiveScheduledTest((int)_TestTypeID))

            {
                lblUserMessage.Text = "Person Already have an active appointment for this test";
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
                return false;
            }
            return true;
        }

        private bool _HandleAppointmentLockedConstraint()
        {
            if (_TestAppointment.IsLocked)
            {
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "Person already sat for the test, appointment loacked.";
                dtpTestDate.Enabled = false;
                btnSave.Enabled = false;
                return false;
            }
            else
                lblUserMessage.Visible = true;
            return true;
        }

        private bool _HandlePrviousTestConstraint()
        {
            //we need to make sure that this person passed the prvious required test before apply to the new test.
            //person cannno apply for written test unless s/he passes the vision test.
            //person cannot apply for street test unless s/he passes the written test.

            switch (TestTypeID)
            {
                case clsTestTypes.enTestType.VisionTest:
                    //in this case no required prvious test to pass.
                    lblUserMessage.Visible = false;

                    return true;

                case clsTestTypes.enTestType.WrittenTest:
                    //Written Test, you cannot sechdule it before person passes the vision test.
                    //we check if pass visiontest 1.
                    if (!_LDLApplication.DoesPassTestType(clsTestTypes.enTestType.VisionTest))
                    {
                        lblUserMessage.Text = "Cannot Sechule, Vision Test should be passed first";
                        lblUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpTestDate.Enabled = true;
                    }


                    return true;

                case clsTestTypes.enTestType.StreetTest:

                    //Street Test, you cannot sechdule it before person passes the written test.
                    //we check if pass Written 2.
                    if (!_LDLApplication.DoesPassTestType(clsTestTypes.enTestType.WrittenTest))
                    {
                        lblUserMessage.Text = "Cannot Sechule, Written Test should be passed first";
                        lblUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpTestDate.Enabled = true;
                    }


                    return true;

            }
            return true;

        }
        private bool HanleRetakeTestApplication()
        {
            //this will decide to create a seperate application for retake test or not.
            // and will create it if needed , then it will linkit to the appoinment.
            if (_Mode == enMode.AddNew && _CreationMode == enCreationMode.RetakeTestSchedule)
            {
                //incase the mode is add new and creation mode is retake test we should create a seperate application for it.
                //then we linke it with the appointment.

                //First Create Applicaiton 
                clsApplication _Application = new clsApplication();
                _Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RetakeTest;
                _Application.ApplicantPersonID = _LDLApplication.ApplicantPersonID;
                _Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                _Application.ApplicationDate = DateTime.Now;
                _Application.LastStatusDate = DateTime.Now;
                _Application.PaidFees = clsApplicationTypes.FindApplicationType((int)clsApplication.enApplicationType.RetakeTest).ApplicationTypeFees;
                _Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                if(!_Application.Save())
                {
                    _TestAppointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                _TestAppointment.RetakeTestApplicationID = _Application.ApplicationID;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Saving Retake Test Application First if it is Retake Test
            if (!HanleRetakeTestApplication())
                return;

            // Step 2: Assign values from UI to business object
            _TestAppointment.LocalDrivingLicenseApplicationID = _LDLApplication.LocalDrivingLicenseApplicationID;
            _TestAppointment.TestTypeID = (int)_TestTypeID;
            _TestAppointment.AppointmentDate = dtpTestDate.Value;
            _TestAppointment.IsLocked = false;
            _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                _TestAppointment.PaidFees = Convert.ToDecimal(lblTotalFees.Text);

            }
            else
            {
                _TestAppointment.PaidFees = Convert.ToDecimal(lblFees.Text);
            }


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
