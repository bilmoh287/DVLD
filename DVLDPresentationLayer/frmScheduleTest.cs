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
    public partial class frmScheduleTest : Form
    {
        public frmScheduleTest(int LDLApplicationID)
        {
            InitializeComponent();
            ctlScheduleTest1.LoadScheduleTestInfo(LDLApplicationID);
        }

        private void ctlUserCard1_Load(object sender, EventArgs e)
        {

        }
    }
}
