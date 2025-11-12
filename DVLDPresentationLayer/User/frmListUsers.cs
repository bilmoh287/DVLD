using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBussinessLayer;

namespace DVLDPresentationLayer
{
    public partial class frmListUsers : Form
    {
        private static DataTable _dtAllUsers = clsUser.GetAllUser();
        private DataTable _dtUsers = _dtAllUsers.DefaultView.ToTable(false, "UserID", "PersonID", "FullName", "UserName", "Password", "IsActive");
        public frmListUsers()
        {
            InitializeComponent();
        }

        private void _RefreshUsersList()
        {
            _dtAllUsers = clsUser.GetAllUser();
            _dtUsers = _dtAllUsers.DefaultView.ToTable(false, "UserID", "PersonID", "FullName", "UserName", "Password", "IsActive");
            dgvListUsers.DataSource = _dtUsers;
            lblRecordsCount.Text = dgvListUsers.RowCount.ToString();
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            //_RefreshUsersList();
            dgvListUsers.DataSource = _dtUsers;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvListUsers.Rows.Count.ToString();

            dgvListUsers.Columns[0].HeaderText = "User ID";
            dgvListUsers.Columns[0].Width = 110;

            dgvListUsers.Columns[1].HeaderText = "Person ID";
            dgvListUsers.Columns[1].Width = 110;

            dgvListUsers.Columns[2].HeaderText = "Full Name";
            dgvListUsers.Columns[2].Width = 350;

            dgvListUsers.Columns[3].HeaderText = "UserName";
            dgvListUsers.Columns[3].Width = 120;

            dgvListUsers.Columns[4].HeaderText = "Password";
            dgvListUsers.Columns[4].Width = 120;

            dgvListUsers.Columns[5].HeaderText = "Is Active";
            dgvListUsers.Columns[5].Width = 110;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cbIsActive.Visible = cbFilterBy.SelectedText == "Is Active";
            if(cbFilterBy.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.SelectedIndex = 0;
            }
            else
            {
                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsActive.Visible = false;

                if (cbFilterBy.Text == "None")
                    txtFilterValue.Enabled = false;
                else
                    txtFilterValue.Enabled = true;
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch(cbFilterBy.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "UserName":
                    FilterColumn = "UserName";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if(txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtUsers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtUsers.DefaultView.Count.ToString();
                return;
            }
            if(FilterColumn == "PersonID" || FilterColumn == "UserID")
            {
                // numeric filter
                _dtUsers.DefaultView.RowFilter = $"[{FilterColumn}] = {txtFilterValue.Text.Trim()}";
            }
            else
            {
                //string filter
                _dtUsers.DefaultView.RowFilter = $"[{FilterColumn}] LIKE '{txtFilterValue.Text.Trim()}%'";
            }

            lblRecordsCount.Text = _dtUsers.DefaultView.Count.ToString();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filterValue = cbIsActive.Text.Trim();
            if(filterValue == "All")
            {
                _dtUsers.DefaultView.RowFilter = "";
            }
            else
            {
                int isActive = (filterValue == "Yes") ? 1 : 0;
                _dtUsers.DefaultView.RowFilter = $"[IsActive] = {isActive}";
            }
            lblRecordsCount.Text = _dtUsers.DefaultView.Count.ToString();
        }

        private void OnPersonSelected(object sender, int UserID)
        {
            _RefreshUsersList();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id is selected.
            if (cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "User ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.OnUserSaved += OnPersonSelected;
            frm.ShowDialog();
            //_RefreshUsersList();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvListUsers.CurrentRow.Cells[0].Value;
            //MessageBox.Show (UserID.ToString());
            frmShowUserInfo frm = new frmShowUserInfo(UserID);
            frm.
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.OnUserSaved += OnPersonSelected;
            frm.ShowDialog();
            //_RefreshUsersList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvListUsers.CurrentRow.Cells[0].Value;
            frmAddUpdateUser frm = new frmAddUpdateUser(UserID);
            frm.OnUserSaved += OnPersonSelected;
            frm.ShowDialog();
            //_RefreshUsersList();
            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete user [" + dgvListUsers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsUser.DeleteUserByID((int)dgvListUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshUsersList();
                }
                else
                {
                    MessageBox.Show("User was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ChangePasswordtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvListUsers.CurrentRow.Cells[0].Value;
            frmChangePassword frm = new frmChangePassword(UserID);
            frm.OnUserSaved += OnPersonSelected;
            frm.ShowDialog();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
