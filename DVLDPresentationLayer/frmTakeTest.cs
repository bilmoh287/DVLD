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
    public partial class frmTakeTest : Form
    {
        clsTestAppointments _TesAppointment;
        int _TestAppointmentID = -1;
        clsTestTypes.enTestType _TestType = clsTestTypes.enTestType.VisionTest;
        public frmTakeTest(int TestAppointmentID, clsTestTypes.enTestType TestType)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
            _TestType = TestType;  
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctlScheduledTest1.LoadTestAppointmentInfo(_TestAppointmentID, _TestType);
            _TesAppointment = clsTestAppointments.Find(_TestAppointmentID);
            if (_TesAppointment.IsLocked)
                btnSave.Enabled = false;
                lblUserMessage.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
            "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            clsTests _Test = new clsTests();
            _Test.TestAppointmentID = _TestAppointmentID;
            _Test.TestResult = (rbPass.Checked) ? true : false;
            _Test.Notes = txtNotes.Text.Trim();
            _Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if(_Test.Save())
            {
                if(_TesAppointment.LockAppointment())
                {
                    btnSave.Enabled = false;
                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
