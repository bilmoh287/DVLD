using System;
using System.Drawing;
using System.Windows.Forms;
using DVLDBussinessLayer;

namespace DVLDPresentationLayer
{
    public partial class frmRegistration : Form
    {
        public frmRegistration()
        {
            InitializeComponent();
        }

        private void _RefreshApplicantsList()
        {
            dgvApplicants.DataSource = clsPerson.GetAllPerson();
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            _RefreshApplicantsList();
        }

        private void btnAddApplicant_Click(object sender, EventArgs e)
        {
            frmRegisterApplicant frm = new frmRegisterApplicant();
            frm.ShowDialog();
            
            // Refresh data after modal is closed
            _RefreshApplicantsList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
