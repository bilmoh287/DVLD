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

namespace DVLDPresentationLayer.Applications.Application_Reviews
{
    public partial class frmReviewRenewalApplications : Form
    {
        private int _ApplicationID = -1;
        private clsApplication _Application;

        public frmReviewRenewalApplications()
        {
            InitializeComponent();
            this.Load += FrmReviewRenewalApplications_Load;
            dgvUnderReviewList.CellClick += DgvUnderReviewList_CellClick;
            btnApprove.Click += BtnApprove_Click;
            btnReject.Click += BtnReject_Click;
            btnClose.Click += (sender, e) => this.Close();
        }

        private void FrmReviewRenewalApplications_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            dgvUnderReviewList.DataSource = clsApplication.GetUnderReviewApplicationsByType((int)clsApplication.enApplicationType.RenewDrivingLicense);
            panelDetail.Visible = false;
        }

        private void DgvUnderReviewList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            _ApplicationID = Convert.ToInt32(dgvUnderReviewList.Rows[e.RowIndex].Cells["ApplicationID"].Value);
            _Application = clsApplication.Find(_ApplicationID);

            if (_Application != null)
            {
                panelDetail.Visible = true;
                ctlPersonCard1.LoadPersonInfo(_Application.ApplicantPersonID);

                if (!string.IsNullOrEmpty(_Application.DocumentPath))
                {
                    try { pbIdpictrue.ImageLocation = _Application.DocumentPath; } catch { }
                }
                else { pbIdpictrue.Image = null; }
            }
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            if (_Application != null)
            {
                _Application.ApplicationStatus = clsApplication.enApplicationStatus.Approved;
                _Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                if (_Application.Save())
                {
                    MessageBox.Show("Application Approved successfully. User will be notified to pay.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                }
            }
        }

        private void BtnReject_Click(object sender, EventArgs e)
        {
            if (_Application != null)
            {
                _Application.ApplicationStatus = clsApplication.enApplicationStatus.Rejected;
                _Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                if (_Application.Save())
                {
                    MessageBox.Show("Application Rejected.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                }
            }
        }
    }
}
