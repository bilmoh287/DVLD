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

        private void _LoadUserInfo()
        {
            _User = clsUser.Find(_UserID);
            if( _User == null )
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            //lblTitle.Text = "Update User";
            ctlPersonCardWithFilter1.FilterEnables = false;
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            ctlPersonCardWithFilter1.LoadPersonInfo(_UserID);
            //btnNext.Enabled = true;
        }
        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
            {
                _LoadUserInfo();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _User.PersonID = ctlPersonCardWithFilter1.PersonID;
            _User.UserName = txtUserName.Text.Trim();
            _User.Password = txtPassword.Text.Trim();
            _User.IsActive = chkIsActive.Checked;

            if(_User.Save())
            {
                lblTitle.Text = _User.UserID.ToString();
                lblTitle.Text = "Update Person";
                this.Text = lblTitle.Text;
                OnUserSaved?.Invoke(this, _User.UserID);
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                }
            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctlPersonCardWithFilter1.FilterFocus();
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtUserName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if(clsUser.IsUserExist(txtUserName.Text.Trim()))
            //{

            //}
        }
    }
}
