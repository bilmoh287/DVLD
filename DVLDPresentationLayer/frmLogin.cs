using System;
using System.Windows.Forms;
using DVLDBussinessLayer;
using DVLDPresentationLayer.Global_Classes;

namespace DVLDPresentationLayer
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            clsUser _Usuer = clsUser.FindByUserNameAndPassword(username, password);
            if( _Usuer != null )
            {
                if (chkRememberMe.Checked)
                {
                    //store username and password
                    clsGlobal.RememberUsernameAndPassword(username, password);
                }
                else
                {
                    //store empty username and password
                    clsGlobal.RememberUsernameAndPassword("", "");
                }

                // In case user is not active
                if (!_Usuer.IsActive)
                {
                    txtUserName.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsGlobal.CurrentUser = _Usuer;
                this.Hide();
                frmMain frm = new frmMain(this);
                frm.ShowDialog();
            }
            else
            {
                txtUserName.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
