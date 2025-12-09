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

namespace DVLDPresentationLayer
{
    public partial class ctlScheduledTest : UserControl
    {
        //private clsTests _Test;
        private clsTestAppointments _TestAppointment;
        //private clsLocalDrivingLicenseApplication _LDLApplication;
        public ctlScheduledTest()
        {
            InitializeComponent();
        }

        public int TestAppointmentID()
        {
            return _TestAppointment.TestAppointmentID;
        }
        private void _ResetPersonInfo()
        {
            lblLocalDrivingLicenseAppID.Text = "???";
            lblDrivingClass.Text = "???";
            lblFullName.Text = "???";
            lblTrial.Text = "???";
            lblDate.Text = "???";
            lblFees.Text = "???";
            lblTestID.Text = "???";
        }

        private void _FillTestAppointmentInfo()
        {
            gbTestType.Text = clsTestTypes.Find((clsTestTypes.enTestType)_TestAppointment.TestTypeID).TestTypeTitle;
            lblLocalDrivingLicenseAppID.Text = _TestAppointment.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _TestAppointment.LDLApplicationInfo.LicesnseClassInfo.ClassName;
            lblFullName.Text = _TestAppointment.LDLApplicationInfo.FullName;
            lblTrial.Text ="0"; // will be applied
            lblDate.Text = _TestAppointment.AppointmentDate.ToString();
            lblFees.Text = _TestAppointment.PaidFees.ToString();
        }
        public void LoadTestAppointmentInfo(int TestAppointmentID)
        {
            _TestAppointment = clsTestAppointments.Find(TestAppointmentID);
            if (_TestAppointment == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No Test Appointment with AppointmentID = " + TestAppointmentID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillTestAppointmentInfo();
        }
    }
}
