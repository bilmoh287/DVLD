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
        int _LDLApplicationID = -1;
        clsTestTypes.enTestType _TesType = clsTestTypes.enTestType.VisionTest;
        public frmTakeTest(int LDLApplicationID, clsTestTypes.enTestType _TestTypeID, int TestAppointmentID = -1)
        {
            InitializeComponent();
            _LDLApplicationID = LDLApplicationID;
            _TesType = _TestTypeID;
            _TestAppointmentID = TestAppointmentID;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {

        }
    }
}
