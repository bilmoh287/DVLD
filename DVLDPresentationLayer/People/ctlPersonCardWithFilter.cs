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
    public partial class ctlPersonCardWithFilter : UserControl
    {
        // Event declaration: Notifies subscribers when calculation is complete
        public event Action<int> OnPersonSelected;
        // Optional helper method to raise the event safely
        public virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID);
            }
        }

        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get { return _ShowAddPerson; }
            set
            {
                _ShowAddPerson = value;
                btnAddNewAddPerson.Enabled = _ShowAddPerson;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnables
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }

        public int PersonID
        {
            get { return ctlPersonCard1.PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return ctlPersonCard1.SelectedPersonInfo; }
        }

        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }

        public ctlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(int PersonID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            FindNow();
        }

        public void FindNow()
        {
            switch (cbFilterBy.Text)
            {
                case "National No":
                    ctlPersonCard1.LoadPersonInfo(txtFilterValue.Text.Trim());
                    break;
                case "Person ID":
                    ctlPersonCard1.LoadPersonInfo(int.Parse(txtFilterValue.Text.Trim()));
                    break;
                default:
                    break;
            }


            if (OnPersonSelected != null && FilterEnables)
                // Raise the event with a parameter
                PersonSelected(ctlPersonCard1.PersonID);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valid!, put the mouse over the red icon(s) to see the error", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FindNow();
        }

        private void btnAddNewAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.OnPersonSaved += DataBack;
            frm.ShowDialog();
        }

        public void DataBack(object sender, int PersonID)
        {
            // Handle the data received

            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            LoadPersonInfo(PersonID);
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtFilterValue, null); 
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }

            //this will allow only digits if person id is selected
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void ctlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }

        private void ctlPersonCard1_Load(object sender, EventArgs e)
        {

        }
    }
}
