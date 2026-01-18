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
    public partial class frmChangePassword : Form
    {
        // Declare a delegate
        public delegate void UserSavedHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event UserSavedHandler OnUserSaved;

        private int _UserID;
        private clsUser _User;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void _ResetDefaultValues()
        {
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtCurrentPassword.Focus();
        }



        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            _User = clsUser.FindByUserID(_UserID);
            if(_User == null )
            {
                MessageBox.Show("Could not Find User with id = " + _UserID,
                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctlUserCard1.LoadUserInfo(_UserID);
            this.KeyPreview = true;
        }
        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            string current = txtCurrentPassword.Text.Trim();

            if (string.IsNullOrEmpty(current))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Current password cannot be blank.");
                return;
            }

            if (_User == null || _User.Password != current)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Current password is incorrect.");
                return;
            }

            errorProvider1.SetError(txtCurrentPassword, null);
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            string newPassword = txtNewPassword.Text.Trim();

            if (string.IsNullOrEmpty(newPassword))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "New password cannot be blank.");
                return;
            }

            if (newPassword == txtCurrentPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "New password cannot be the same as the current password.");
                return;
            }

            if (newPassword.Length < 6)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "Password must be at least 6 characters long.");
                return;
            }

            errorProvider1.SetError(txtNewPassword, null);
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            string confirm = txtConfirmPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();

            if (string.IsNullOrEmpty(confirm))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Confirm password cannot be blank.");
                return;
            }

            if (confirm != newPassword)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Passwords do not match.");
                return;
            }

            errorProvider1.SetError(txtConfirmPassword, null);
        }

        private void frmChangePassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSave.PerformClick();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Step 1: Validate form
            if (!ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Step 2: Assign values from UI to business object
            //_User.Password = txtNewPassword.Text.Trim();
            _User.SetPassword(txtNewPassword.Text.Trim());

            // Step 3: Save
            if (_User.Save())
            {
                OnUserSaved?.Invoke(this, _User.UserID);
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ResetDefaultValues();
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangePassword_Shown(object sender, EventArgs e)
        {
            txtCurrentPassword.Focus();
        }

    }
}
