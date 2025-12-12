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
    public partial class frmTakeTest : Form
    {
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
        }
    }
}
