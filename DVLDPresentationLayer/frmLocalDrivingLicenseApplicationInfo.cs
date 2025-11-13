using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    public partial class frmLocalDrivingLicenseApplicationInfo : Form
    {
        public frmLocalDrivingLicenseApplicationInfo(int LDLApplicationID)
        {
            InitializeComponent();
            ctlDrivingLicenseApplicationInfo1.LoadLDLApplicationInfo(LDLApplicationID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
