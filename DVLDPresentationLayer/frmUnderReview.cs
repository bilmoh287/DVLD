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
    public partial class frmUnderReview : Form
    {
        int _PersonID = 1;
        public frmUnderReview()
        {
            InitializeComponent();
            ctlPersonCard1.LoadPersonInfo(_PersonID);
        }


        private void panelDetail_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvUnderReviewList_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int applicationID = Convert.ToInt32(dgvUnderReviewList.Rows[e.RowIndex].Cells["ApplicationID"].Value);
            var app = DVLDBussinessLayer.clsApplication.Find(applicationID);
            if (app != null)
            {
                panelDetail.Visible = true;
                _PersonID = app.ApplicantPersonID;
                ctlPersonCard1.LoadPersonInfo(_PersonID);
                ; // Your user control's method
                
            }
        }

        private void frmUnderReview_Load(object sender, EventArgs e)
        {
            dgvUnderReviewList.DataSource = clsLocalDrivingLicenseApplication.GetAllNewLocalDrivingLicenseApplications();
            if (dgvUnderReviewList.Rows.Count > 0)
            {
                dgvUnderReviewList.Columns["ApplicationID"].HeaderText = "Application ID";
                dgvUnderReviewList.Columns["ApplicationID"].Width = 100;

                dgvUnderReviewList.Columns["FullName"].HeaderText = "Full Name";
                dgvUnderReviewList.Columns["FullName"].Width = 180;

                dgvUnderReviewList.Columns["NationalNo"].HeaderText = "National No.";
                dgvUnderReviewList.Columns["NationalNo"].Width = 120;

                dgvUnderReviewList.Columns["ApplicationDate"].HeaderText = "Date";
                dgvUnderReviewList.Columns["ApplicationDate"].Width = 130;

                dgvUnderReviewList.Columns["ApplicationStatus"].HeaderText = "Status";
                dgvUnderReviewList.Columns["ApplicationStatus"].Width = 100;
            }
        }
    }
}
