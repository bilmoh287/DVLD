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
        public frmListTestApppointments(int LDLApplicationID)
        {
            InitializeComponent();
            _LDLApplicationID = LDLApplicationID;
            ctlDrivingLicenseApplicationInfo1.LoadLDLApplicationInfo(LDLApplicationID);
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            frmScheduleTest frm = new frmScheduleTest(_LDLApplicationID);
            frm.ShowDialog();
            frmListTestApppointments_Load(null, null);
        }

        private void frmListTestApppointments_Load(object sender, EventArgs e)
        {
            dgvLicenseTestAppointments.DataSource = clsTestAppointments.GetAllTestAppointments();
            dgvLicenseTestAppointments.Columns[0].HeaderText = "Appointmnet ID";
            dgvLicenseTestAppointments.Columns[0].Width = 150;

            dgvLicenseTestAppointments.Columns[1].HeaderText = "Appointmnet Date";
            dgvLicenseTestAppointments.Columns[1].Width = 250;

            dgvLicenseTestAppointments.Columns[2].HeaderText = "Paid Fees";
            dgvLicenseTestAppointments.Columns[2].Width = 150;

            dgvLicenseTestAppointments.Columns[3].HeaderText = "Is Locked";
            dgvLicenseTestAppointments.Columns[3].Width = 150;
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value;
            frmTakeTest frm = new frmTakeTest(TestAppointmentID);
            frm.ShowDialog();
        }
    }
}
