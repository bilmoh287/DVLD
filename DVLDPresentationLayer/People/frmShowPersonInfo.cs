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
    public partial class frmShowPersonInfo : Form
    {
        private int _PersonID;
        private clsPerson _Person;
        public frmShowPersonInfo(int PersonID)
        {
            InitializeComponent();
            //this.AutoScaleMode = AutoScaleMode.None;
            ctlPersonCard1.LoadPersonInfo(PersonID);
        }
        public frmShowPersonInfo(string NationalNo)
        {
            InitializeComponent();
            //this.AutoScaleMode = AutoScaleMode.None;
            ctlPersonCard1.LoadPersonInfo(NationalNo);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
