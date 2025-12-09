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
    public partial class frmTakeTest : Form
    {
        public frmTakeTest(int TestAppointmentID)
        {
            InitializeComponent();
            ctlScheduledTest1.LoadTestAppointmentInfo(TestAppointmentID);
        }
    }
}
