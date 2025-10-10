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
    public partial class ctlPersonCard : UserControl
    {
        enum enMode { AddNewMode, UpdateMode };
        enMode _Mode;

        int _PersonID;
        clsPerson _Person;
        public ctlPersonCard()
        {
            InitializeComponent();
            _Mode = (_PersonID != -1) ? enMode.UpdateMode : enMode.UpdateMode;
        }

        public void _FillComboBox()
        {
            DataTable dtCountries = clsCountries.GetAllCountriesList();
            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }

        public void LoadPersonData(clsPerson person)
        {
            txtFirstName.Text = person.FirstName;
            txtSecondName.Text = person.SecondName;
            txtThirdName.Text = person.ThirdName;
            txtLastName.Text = person.LastName;
            dtpDateOfBirth.Value = person.DateOfBirth;
            txtNationalNo.Text = person.NationalNo;
            txtEmail.Text = person.Email;
            txtPhone.Text = person.Phone;
            txtAddress.Text = person.Address;
            if (person.Gender == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;
            _FillComboBox();
        }

        public clsPerson GetPersonData()
        {
            _Person.NationalNo = txtNationalNo.Text;
            _Person.FirstName = txtFirstName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.ThirdName = txtThirdName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.Phone = txtPhone.Text;
            _Person.Address = txtAddress.Text;
            _Person.Email = txtEmail.Text;
            if(rbMale.Checked)
                _Person.Gender = (int)rbMale.Tag;
            else
                _Person.Gender = (int)rbFemale.Tag;

            return _Person;
        }
        private void ctlPersonCard_Load(object sender, EventArgs e)
        {

        }
    }
}
