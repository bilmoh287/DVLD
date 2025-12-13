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

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationInfoByID(_LDLApplicationID);
            if (localDrivingLicenseApplication.IsThereAnActiveScheduledTest((int)_TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (localDrivingLicenseApplication.DoesPassTestType(_TestType))
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmScheduleTest frm = new frmScheduleTest(_LDLApplicationID, _TestType);
            frm.ShowDialog();
            frmListTestApppointments_Load(null, null);
        }

        private void frmListTestApppointments_Load(object sender, EventArgs e)
        {
            dgvLicenseTestAppointments.DataSource = clsTestAppointments.GetApplicantTestAppointmentsPerTestType(_LDLApplicationID, (int)_TestType);
            dgvLicenseTestAppointments.Columns[0].HeaderText = "Appointmnet ID";
            dgvLicenseTestAppointments.Columns[0].Width = 150;

            dgvLicenseTestAppointments.Columns[1].HeaderText = "LDL Application ID";
            dgvLicenseTestAppointments.Columns[1].Width = 150;

            dgvLicenseTestAppointments.Columns[2].HeaderText = "Appointmnet Date";
            dgvLicenseTestAppointments.Columns[2].Width = 250;

            dgvLicenseTestAppointments.Columns[3].HeaderText = "Paid Fees";
            dgvLicenseTestAppointments.Columns[3].Width = 150;

            dgvLicenseTestAppointments.Columns[4].HeaderText = "Is Locked";
            dgvLicenseTestAppointments.Columns[4].Width = 150;
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
