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
    public partial class testForm : Form
    {
        public testForm(int PersonID)
        {
            InitializeComponent();
            ctlPersonCard1.LoadPersonInfo(PersonID);
        }

        private void testForm_Load(object sender, EventArgs e)
        {

        }
    }
}
