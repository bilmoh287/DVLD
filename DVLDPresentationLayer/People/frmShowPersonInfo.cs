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
    public partial class frmShowPersonInfo : Form
    {
        //Declare a delegate and event for outward notification
        public event ctlPersonCard.PersonUpdatedHandler OnPersonUpdated;

        private int _PersonID;
        private clsPerson _Person;
        public frmShowPersonInfo(int PersonID)
        {
            InitializeComponent();
            //ctlPersonCard1.LoadPersonInfo(PersonID);
            //SetHeaderColor(Color.AliceBlue);
            //SetHeaderTitle("Person Info");
            //subscribe to the ctlPersonCard1 event handler.
            ctlPersonCard1.OnPersonUpdated += CtlPersonCard1_OnPersonUpdated;
        }
        public frmShowPersonInfo(string NationalNo)
        {
            InitializeComponent();
            //this.AutoScaleMode = AutoScaleMode.None;
            ctlPersonCard1.LoadPersonInfo(NationalNo);
        }

        // This is the handler for the UserControl event
        private void CtlPersonCard1_OnPersonUpdated(object sender, int PersonID)
        {
            // Re-raise the event to notify whoever opened this form
            OnPersonUpdated?.Invoke(this, PersonID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
