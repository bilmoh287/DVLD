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
            ctlPersonCard1.LoadPersonInfo(PersonID);
        }
        public testForm()
        {
            InitializeComponent();
            //ctlPersonCard1.LoadPersonInfo(PersonID);
        }

        private void testForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication app = new clsLocalDrivingLicenseApplication();
            app.ApplicantPersonID = 1;
            app.ApplicationDate = DateTime.Now;
            app.ApplicationTypeID = 1;
            app.ApplicationStatus = clsApplication.enApplicationStatus.New;
            app.LastStatusDate = DateTime.Now;
            app.PaidFees = 100;
            app.CreatedByUserID = 1;
            //app.ApplicationID = 1;
            app.LicenseClassID = 3;

            bool result = app.SaveLDLA();
            MessageBox.Show(result ? $"Base Saved! ID={app.ApplicationID}" : "Base Failed!");

            //clsLocalDrivingLicenseApplication app1 = new clsLocalDrivingLicenseApplication();
            //app1.ApplicationID = 1;
            //app1.LicenseClassID = 3;

            //bool result1 = app1.SaveLDLA();
            //MessageBox.Show(result1 ? "Saved!" : "Failed!");


        }
    }
}
