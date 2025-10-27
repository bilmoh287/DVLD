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
    public partial class ctlUserCard : UserControl
    {
        private clsUser _User;
        public ctlUserCard()
        {
            InitializeComponent();
        }

        public int UseriD()
        {
            return _User.UserID;
        }
        private void _ResetPersonInfo()
        {
            lblUserID.Text = "???";
            lblUsername.Text = "???";
            lblIsActive.Text = "???";
        }

        private void _FillUserInfo()
        {
            ctlPersonCard1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUsername.Text = "[" + _User.UserName.ToString()+ "]";
            lblIsActive.Text = (_User.IsActive) ? "Yes" : "No";
        }
        public void LoadUserInfo(int UserID)
        {
            _User = clsUser.FindByUserID(UserID);
            if (_User == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No User with User ID = " + UserID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillUserInfo();
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void lblIsActive_Click(object sender, EventArgs e)
        {

        }
    }
}
