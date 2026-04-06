using System;
using System.Windows.Forms;
using DVLDBussinessLayer;

namespace DVLDPresentationLayer
{
    public partial class testForm : Form
    {
        public testForm(int PersonID)
        {
            InitializeComponent();
            //ctlPersonCard1.LoadPersonInfo(PersonID);
        }
        public testForm()
        {
            InitializeComponent();
            //ctlPersonCard1.LoadPersonInfo(PersonID);
            //ctlApplicationBasicInfo1.LoadBasicApplicationInfo(1);
            //ctlDrivingLicenseApplicationInfo1.LoadLDLApplicationInfo(1);
        }

        private void testForm_Load(object sender, EventArgs e)
        {
            //ctlPersonCard1.LoadPersonInfo(1);
            //ctlScheduledTest1.LoadTestAppointmentInfo(1, clsTestTypes.enTestType.VisionTest);
            //ctlScheduleTest1.LoadScheduleTestInfo(1);
            ctlDriverLicenses1.LoadInfoByDriverID(2);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //clsLocalDrivingLicenseApplication app = new clsLocalDrivingLicenseApplication();
            //app.ApplicantPersonID = 1;
            //app.ApplicationDate = DateTime.Now;
            //app.ApplicationTypeID = 1;
            //app.ApplicationStatus = clsApplication.enApplicationStatus.New;
            //app.LastStatusDate = DateTime.Now;
            //app.PaidFees = 100;
            //app.CreatedByUserID = 1;
            ////app.ApplicationID = 1;
            //app.LicenseClassID = 3;

            //bool result = app.SaveLDLA();
            //MessageBox.Show(result ? $"Base Saved! ID={app.ApplicationID}" : "Base Failed!");

            ////clsLocalDrivingLicenseApplication app1 = new clsLocalDrivingLicenseApplication();
            ////app1.ApplicationID = 1;
            ////app1.LicenseClassID = 3;

            ////bool result1 = app1.SaveLDLA();
            ////MessageBox.Show(result1 ? "Saved!" : "Failed!");
            ///

            //frmTakeTest frm = new frmTakeTest(1);
            //frm.ShowDialog();

            string m = clsTestTypes.Find((clsTestTypes.enTestType)1).TestTypeTitle;
            MessageBox.Show(m);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmListInstituteCourse frm  = new frmListInstituteCourse(1);
            frm.ShowDialog();
        }
    }
}
