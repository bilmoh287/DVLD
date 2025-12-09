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
        int _TestAppointmentID;
        //clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        clsLocalDrivingLicenseApplication _LDLApplication;
        clsTestAppointments _TestAppointment;
        clsApplication _Application;
        public ctlScheduleTest()
        {
            InitializeComponent();
        }

        public int TestTypeID { set; get; }
        public int AppointmnetID
        {
            get { return _TestAppointmentID; }
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

        public void LoadScheduleTestInfo(int LDLApplicationID)
        {
            _LDLApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationInfoByID(LDLApplicationID);
            if (_LDLApplication == null)
            {
                ResetTestAppointmentInfo();
                MessageBox.Show("No Appointmnent with AppointmnentID = " + _TestAppointmentID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
