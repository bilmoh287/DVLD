using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    public partial class frmShowUserInfo : Form
    {
        //Declare a delegate and event for outward notification
        public event ctlPersonCard.PersonUpdatedHandler OnPersonUpdated;
        public frmShowUserInfo(int UserID)
        {
            InitializeComponent();
            //ctlUserCard1.LoadUserInfo(UserID);
            ctlUserCard2.LoadUserInfo(UserID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CtlPersonCard1_OnPersonUpdated(object sender, int PersonID)
        {
            // Re-raise the event to notify whoever opened this form
            OnPersonUpdated?.Invoke(this, PersonID);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
