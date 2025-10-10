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
    public partial class frmAddEditPerson : Form
    {
        public delegate void PersonSavedHandler();
        public event PersonSavedHandler OnPersonSaved;

        enum enMode { AddNewMode, UpdateMode };
        enMode _Mode;

        int _PersonID;
        clsPerson _Person;
        public frmAddEditPerson(int PersonID)
        {
            _PersonID = PersonID;
            InitializeComponent();
            _Mode = (_PersonID != -1) ? enMode.UpdateMode : enMode.AddNewMode;

        }

        public void _FillComboBox()
        {
            DataTable dtCountries = clsCountries.GetAllCountriesList();
            cbCountry.DataSource = dtCountries;
            cbCountry.DisplayMember = "CountryName";
            cbCountry.ValueMember = "CountryID";
        }

        private void LoadPersonData()
        {

            lblAddEdit.Text = "Edit Person";
            lblPersonID.Text = _PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            txtNationalNo.Text = _Person.NationalNo;
            txtEmail.Text = _Person.Email;
            txtPhone.Text = _Person.Phone;
            txtAddress.Text = _Person.Address;
            if (_Person.Gender == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;
            if(_Person.ImagePath != null)
            {
                pbImage.Load(_Person.ImagePath);
            }
            else
            {
                llRemove.Visible = false;
            }
            _FillComboBox();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Person.NationalNo = txtNationalNo.Text;
            _Person.FirstName = txtFirstName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.ThirdName = txtThirdName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.Phone = txtPhone.Text;
            _Person.Address = txtAddress.Text;
            _Person.Email = txtEmail.Text;
            _Person.Gender = rbMale.Checked ? 0 : 1;
            _Person.ImagePath = (pbImage.ImageLocation != null) ? pbImage.ImageLocation.ToString() : "";
            _Person.CountryID = (int)cbCountry.SelectedValue;

            if (_Person.Save())
            {
                MessageBox.Show("Data Saved Successfully");
                OnPersonSaved?.Invoke();
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");

            }

            lblAddEdit.Text = "Edit Person";
            lblPersonID.Text = _PersonID.ToString();
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.JFIF;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);

                pbImage.Load(selectedFilePath);
                // ...
            }
        }

        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _FillComboBox();

            if (_Mode == enMode.AddNewMode)
            {
                _Person = new clsPerson();
                llRemove.Visible = false;
                return;
            }

            _Person = clsPerson.Find(_PersonID);
            if (_Person == null)
            {
                MessageBox.Show("Person Not Found");
                this.Close();
                return;
            }

            LoadPersonData();
        }

        private void llRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.ImageLocation = null;
            llRemove.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
