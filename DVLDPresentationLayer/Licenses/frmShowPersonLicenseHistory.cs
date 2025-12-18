using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPresentationLayer.Licenses
{
    public partial class frmShowPersonLicenseHistory : Form
    {
        int _PersonID = -1;
        public frmShowPersonLicenseHistory()
        {
            InitializeComponent();
        }
        public frmShowPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            this._PersonID = PersonID;
        }

        private void ctlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            if(_PersonID == -1)
            {
                int PersonID = obj;
                if (PersonID != 1)
                {
                    ctlPersonCardWithFilter1.LoadPersonInfo(_PersonID);
                    ctlPersonCardWithFilter1.FilterEnables = false;
                    ctlDriverLicenses1.LoadInfoByPersonID(_PersonID);
                }
                else
                {
                    ctlDriverLicenses1.Clear();
                }
            }
        }

        private void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            if(_PersonID != 1)
            {
                ctlPersonCardWithFilter1.LoadPersonInfo(_PersonID);
                ctlPersonCardWithFilter1.FilterEnables = false;
                ctlDriverLicenses1.LoadInfoByPersonID(_PersonID);
            }
            else
            {
                ctlDriverLicenseInfoWithFilter1.FilterEnabled = true;
                ctlPersonCardWithFilter1.FilterFocus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
