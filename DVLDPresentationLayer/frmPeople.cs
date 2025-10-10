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
            dgvListPeople.DataSource = clsPerson.GetAllPerson();
            lblRecord.Text = dgvListPeople.RowCount.ToString();
        }
        private void frmPeople_Load(object sender, EventArgs e)
        {
            _RefreshPeople();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(-1);
            frm.OnPersonSaved += _RefreshPeople;
            frm.ShowDialog();
        }

        private void editPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvListPeople.CurrentRow.Cells[0].Value;
            frmAddEditPerson frm = new frmAddEditPerson(PersonID);
            frm.OnPersonSaved += _RefreshPeople;
            frm.ShowDialog();
        }
    }
}
