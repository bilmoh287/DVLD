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
    public partial class frmAddUpdateLocalDrivingLicenseApplication : Form
    {
        // Declare a delegate
        public delegate void ApplicationSavedHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event ApplicationSavedHandler OnApplicationSaved;

        enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode = enMode.AddNew;
        int _LDLApplicationID;
        clsApplication _Application;
        clsUser _CreatedByUser = clsUser.FindByUserID(clsGlobal.CurrentUser.UserID);
        public frmAddUpdateLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }
        public frmAddUpdateLocalDrivingLicenseApplication(int ApplicationID)
        {
            InitializeComponent();
            _LDLApplicationID = ApplicationID;
        }

        public void 
        private void frmAddUpdateLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {

        }
    }
}
