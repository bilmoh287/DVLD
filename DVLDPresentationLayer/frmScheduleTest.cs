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
    public partial class frmScheduleTest : Form
    {
        int _TestAppointmentID = -1;
        int _LDLApplicationID = -1;
        clsTestTypes.enTestType _TesType = clsTestTypes.enTestType.VisionTest;
        public frmScheduleTest(int LDLApplicationID, clsTestTypes.enTestType TestType, int AppointmentID = -1)
        {
            InitializeComponent();
            _TestAppointmentID = AppointmentID;
            _LDLApplicationID = LDLApplicationID;
            _TesType = TestType;
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ctlScheduleTest1.TestTypeID = _TesType;
            ctlScheduleTest1.LoadScheduleTestInfo(_LDLApplicationID, _TestAppointmentID);
        }
    }
}
