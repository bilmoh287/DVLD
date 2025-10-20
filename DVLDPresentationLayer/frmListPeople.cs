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
    public partial class frmListPeople : Form
    {
        public frmListPeople()
        {
            InitializeComponent();
        }

        private void _RefreshPeople(object sender, int PersonID)
        {
            dgvListPeople.DataSource = clsPerson.GetAllPerson();
            lblRecord.Text = dgvListPeople.RowCount.ToString();
        }
        private void frmPeople_Load(object sender, EventArgs e)
        {
            _RefreshPeople(this,-1);
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.OnPersonSaved += _RefreshPeople;
            frm.ShowDialog();
        }

        private void editPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvListPeople.CurrentRow.Cells[0].Value;
            frmAddUpdatePerson frm = new frmAddUpdatePerson(PersonID);
            frm.OnPersonSaved += _RefreshPeople;
            frm.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvListPeople.CurrentRow.Cells[0].Value;
            frmShowPersonInfo frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();
        }
    }
}
