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
    public partial class frmListTestApppointments : Form
    {
        int _LDLApplicationID = 1;
        clsTestTypes.enTestType _TestType = clsTestTypes.enTestType.VisionTest;
        public frmListTestApppointments(int LDLApplicationID, clsTestTypes.enTestType TestType)
        {
            InitializeComponent();
            _LDLApplicationID = LDLApplicationID;
            _TestType = TestType;
            ctlDrivingLicenseApplicationInfo1.LoadLDLApplicationInfo(LDLApplicationID);
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestType)
            {

                case clsTestTypes.enTestType.VisionTest:
                    {
                        lblTitle.Text = "Vision Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.Vision_512;
                        break;
                    }

                case clsTestTypes.enTestType.WrittenTest:
                    {
                        lblTitle.Text = "Written Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.Written_Test_512;
                        break;
                    }
                case clsTestTypes.enTestType.StreetTest:
                    {
                        lblTitle.Text = "Street Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.driving_test_512;
                        break;
                    }
            }
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationInfoByID(_LDLApplicationID);
            if (localDrivingLicenseApplication.IsThereAnActiveScheduledTest((int)_TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsTests LastTest = localDrivingLicenseApplication.GetLastTestPerTestType(_TestType);
            if(LastTest == null)
            {
                frmScheduleTest frm = new frmScheduleTest(_LDLApplicationID, _TestType);
                frm.ShowDialog();
                frmListTestApppointments_Load(null, null);
                return;
            }
            if (LastTest.TestResult)
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmScheduleTest frm2 = new frmScheduleTest(_LDLApplicationID, _TestType);
            frm2.ShowDialog();
            frmListTestApppointments_Load(null, null);
            //if (localDrivingLicenseApplication.DoesPassTestType(_TestType))
            //{
            //    MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

        }

        private void frmListTestApppointments_Load(object sender, EventArgs e)
        {
            _LoadTestTypeImageAndTitle();

            dgvLicenseTestAppointments.DataSource = clsTestAppointments.GetApplicantTestAppointmentsPerTestType(_LDLApplicationID, (int)_TestType);
            dgvLicenseTestAppointments.Columns[0].HeaderText = "Appointmnet ID";
            dgvLicenseTestAppointments.Columns[0].Width = 150;

            dgvLicenseTestAppointments.Columns[1].HeaderText = "LDL Application ID";
            dgvLicenseTestAppointments.Columns[1].Width = 170;

            dgvLicenseTestAppointments.Columns[2].HeaderText = "Appointmnet Date";
            dgvLicenseTestAppointments.Columns[2].Width = 220;

            dgvLicenseTestAppointments.Columns[3].HeaderText = "Paid Fees";
            dgvLicenseTestAppointments.Columns[3].Width = 140;

            dgvLicenseTestAppointments.Columns[4].HeaderText = "Is Locked";
            dgvLicenseTestAppointments.Columns[4].Width = 130;

            lblRecordsCount.Text = dgvLicenseTestAppointments.RowCount.ToString();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value;
            frmTakeTest frm = new frmTakeTest(TestAppointmentID, _TestType);
            frm.ShowDialog();
            frmListTestApppointments_Load(null, null);
        }
    }
}
