using System;
using System.Windows.Forms;
using DVLDBussinessLayer;

namespace DVLDPresentationLayer
{
    public partial class frmAddUpdateUser : Form
    {
        // Declare a delegate
        public delegate void UserSavedHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event UserSavedHandler OnUserSaved;

        enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode = enMode.AddNew;
        int _UserID;
        clsUser _User;
        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _UserID = UserID;
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New User";
                this.Text = lblTitle.Text;
                _User = new clsUser();
                ctlPersonCardWithFilter1.FilterFocus();
                tpLoginInfo.Enabled = false;
            }
            else
            {
                lblTitle.Text = "Update User";
                this.Text = lblTitle.Text;
                btnSave.Enabled = true;
                tpLoginInfo.Enabled = true;
            }

            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            chkIsActive.Checked = true;
        }
        private void _LoadRoles()
        {
            cbRoles.DataSource = null;
            var dtRoles = clsRole.GetAllRoles();
            cbRoles.DataSource = dtRoles;
            cbRoles.DisplayMember = "RoleName";
            cbRoles.ValueMember = "RoleID";
            cbRoles.SelectedIndex = -1; // No selection by default
        }

        private void _LoadUserInfo()
        {
            _User = clsUser.FindByUserID(_UserID);
            if( _User == null )
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            //lblTitle.Text = "Update User";
            ctlPersonCardWithFilter1.FilterEnables = false;
            lblUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            chkIsActive.Checked = _User.IsActive;
            txtPassword.Enabled = false;
            txtUserName.Enabled = false;
            txtConfirmPassword.Enabled = false;
            ctlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);
        }
        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _LoadRoles();
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
            {
                _LoadUserInfo();
                // Optionally, select the user's current role if updating
                var userRoles = clsUserRole.GetRolesByUserID(_UserID);
                if (userRoles.Rows.Count > 0)
                {
                    cbRoles.SelectedValue = Convert.ToInt32(userRoles.Rows[0]["RoleID"]);
                }
            }
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
            _User.PersonID = ctlPersonCardWithFilter1.PersonID;
            _User.UserName = txtUserName.Text.Trim();
            _User.Password = txtPassword.Text.Trim();
            _User.IsActive = chkIsActive.Checked;
            if (_Mode == enMode.AddNew)
            {
                _User.SetPassword(_User.Password); // hashing the input password before saving
            }


            // Step 3: Save
            if (_User.Save())
            {
                // Assign role to user
                int selectedRoleID = Convert.ToInt32(cbRoles.SelectedValue);
                clsUserRole.ResetUserRoles(_User.UserID); // Remove old roles if any
                clsUserRole.AssignRole(_User.UserID, selectedRoleID);

                lblTitle.Text = _User.UserID.ToString();
                lblTitle.Text = "Update User";
                this.Text = lblTitle.Text;
                OnUserSaved?.Invoke(this, _User.UserID);
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tcLogin.SelectedTab = tcLogin.TabPages["tpUserInfo"];
                txtPassword.Enabled = false;
                txtUserName.Enabled = false;
                txtConfirmPassword.Enabled = false;

            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_Mode == enMode.Update)
            {
                tpLoginInfo.Enabled = true;
                btnSave.Enabled = true;
                tcLogin.SelectedTab = tcLogin.TabPages["tpLoginInfo"];
                return;
            }

            //For Add New case
            if (ctlPersonCardWithFilter1.PersonID != -1)
            {
                //Check if Person is already selected as a User
                if (clsUser.IsUserExistByPersonID(ctlPersonCardWithFilter1.PersonID))
                {
                    MessageBox.Show("Selected Person is already a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctlPersonCardWithFilter1.FilterFocus();
                }
                else
                {
                    btnSave.Enabled = true;
                    tpLoginInfo.Enabled = true;
                    tcLogin.SelectedTab = tcLogin.TabPages["tpLoginInfo"];
                    this.AcceptButton = btnSave;
                }
            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctlPersonCardWithFilter1.FilterFocus();
            }
        }

        private void txtUserName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // check if username is empty
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            };

            // in case of AddNew Mode 
            if(_Mode == enMode.AddNew)
            {
                // checks if username is used by another user.
                if (clsUser.IsUserExist(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "username is used by another user");
                }
                else
                {
                    errorProvider1.SetError(txtUserName, null);
                }
            }

            // In case of Update Mode
            else
            {
                // if he is using old username 
                if(_User.UserName != txtUserName.Text.Trim())
                {
                    // checks if username is used by another user.
                    if (clsUser.IsUserExist(txtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtUserName, "username is used by another user");
                    }
                    else
                    {
                        errorProvider1.SetError(txtUserName, null);
                    }
                }
            }
        }

        private void txtPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // check if password is empty
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "password cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            };
        }

        private void txtConfirmPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // check if password is empty
            if (string.IsNullOrEmpty(txtConfirmPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Confirm password cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            };

            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            };
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbRoles_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (cbRoles.SelectedIndex == -1)
            {
                e.Cancel = true;
                errorProvider1.SetError(cbRoles, "Please select a role.");
            }
            else
            {
                errorProvider1.SetError(cbRoles, null);
            }
        }
    }
}
