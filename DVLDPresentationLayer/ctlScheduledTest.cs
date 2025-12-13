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
using DVLDPresentationLayer.Properties;

namespace DVLDPresentationLayer
{
    public partial class ctlScheduledTest : UserControl
    {
        //private clsTests _Test;
        //private clsTestAppointments _TestAppointment;
        //private clsLocalDrivingLicenseApplication _LDLApplication;

        private clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.VisionTest;
        private clsLocalDrivingLicenseApplication _LDLApplication;
        private int _LDLApplicationID = -1;
        private clsTestAppointments _TestAppointment;
        private int _TestAppointmentID = -1;

        public ctlScheduledTest()
        {
            InitializeComponent();
        }

        public clsTestTypes.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;
                switch (_TestTypeID)
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
            //gbTestType.Text = clsTestTypes.Find((clsTestTypes.enTestType)_TestAppointment.TestTypeID).TestTypeTitle;
            lblLocalDrivingLicenseAppID.Text = _TestAppointment.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _TestAppointment.LDLApplicationInfo.LicesnseClassInfo.ClassName;
            lblFullName.Text = _TestAppointment.LDLApplicationInfo.FullName;
            lblTrial.Text = _TestAppointment.LDLApplicationInfo.TotalTrialsPerTest(_TestTypeID).ToString();
            lblDate.Text = _TestAppointment.AppointmentDate.ToString();
            lblFees.Text = _TestAppointment.PaidFees.ToString();
        }
        public void LoadTestAppointmentInfo(int TestAppointmentID, clsTestTypes.enTestType TestType)
        {
            _TestAppointment = clsTestAppointments.Find(TestAppointmentID);
            _TestTypeID = TestType;
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
