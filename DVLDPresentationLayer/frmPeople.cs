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
    public partial class frmPeople : Form
    {
        public frmPeople()
        {
            InitializeComponent();
        }

        private void _RefreshPeople()
        {
            dgvListPeople.DataSource = clsPeople.GetAllPeople();
        }
        private void frmPeople_Load(object sender, EventArgs e)
        {
            _RefreshPeople();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
