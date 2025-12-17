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
    public partial class frmShowLicenseInfo : Form
    {
        public frmShowLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            ctlDriverLicenseInfo1.LoadLicenseInfo(LicenseID);
        }
    }
}
