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
        int _PersonID = -1;
        private int _ApplicationID = -1;
        private clsApplication _Application;

        public frmUnderReview()
        {
            InitializeComponent();
        }



        private void panelDetail_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvUnderReviewList_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            
            _ApplicationID = Convert.ToInt32(dgvUnderReviewList.Rows[e.RowIndex].Cells["ApplicationID"].Value);
            _Application = clsLocalDrivingLicenseApplication.GetUnderReviewApplicationDetails(_ApplicationID);
            
            if (_Application != null)
            {
                panelDetail.Visible = true;
                _PersonID = _Application.ApplicantPersonID;
                ctlPersonCard1.LoadPersonInfo(_PersonID);

                if (!string.IsNullOrEmpty(_Application.DocumentPath))
                {
                    try
                    {
                        pbIdpictrue.ImageLocation = _Application.DocumentPath;
                    }
                    catch { }
                }
                else
                {
                    pbIdpictrue.Image = null;
                }
            }

        }

        private void frmUnderReview_Load(object sender, EventArgs e)
        {
            _RefreshApplicationsList();
        }

        private void _RefreshApplicationsList()
        {
            dgvUnderReviewList.DataSource = clsLocalDrivingLicenseApplication.GetUnderReviewApplications();
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

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (_Application == null) return;

            if (MessageBox.Show("Are you sure you want to approve this application?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (_Application.Approve())
            {
                MessageBox.Show("Application Approved successfully.");
                panelDetail.Visible = false;
                _RefreshApplicationsList();
            }
            else
            {
                MessageBox.Show("Error: Could not approve application.");
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (_Application == null) return;

            if (MessageBox.Show("Are you sure you want to reject this application?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (_Application.Reject())
            {
                MessageBox.Show("Application Rejected successfully.");
                panelDetail.Visible = false;
                _RefreshApplicationsList();
            }
            else
            {
                MessageBox.Show("Error: Could not reject application.");
            }
        }

    }
}
