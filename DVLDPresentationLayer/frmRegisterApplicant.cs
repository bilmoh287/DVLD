using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DVLDBussinessLayer;

namespace DVLDPresentationLayer
{
    public partial class frmRegisterApplicant : Form
    {
        public frmRegisterApplicant()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNationalNo.Text) || string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Please fill all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsPerson.IsPersonExist(txtNationalNo.Text))
            {
                MessageBox.Show("Person with this National No already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsPerson Person = new clsPerson();
            Person.NationalNo = txtNationalNo.Text;
            Person.FirstName = txtFirstName.Text;
            Person.SecondName = txtSecondName.Text;
            Person.ThirdName = "";
            Person.LastName = txtLastName.Text;
            Person.DateOfBirth = dtpDateOfBirth.Value;
            Person.Gender = cmbGender.SelectedIndex == 0 ? 0 : 1;
            Person.Address = txtAddress.Text;
            Person.Phone = txtPhone.Text;
            Person.Email = txtEmail.Text;
            Person.CountryID = Convert.ToInt32(cmbNationality.SelectedValue);
            Person.ImagePath = "";

            if (Person.Save())
            {
                MessageBox.Show("Applicant Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: Data Is Not Saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmRegisterApplicant_Load(object sender, EventArgs e)
        {
            // Load Countries
            DataTable dtCountries = clsCountries.GetAllCountriesList();
            cmbNationality.DataSource = dtCountries;
            cmbNationality.DisplayMember = "CountryName";
            cmbNationality.ValueMember = "CountryID";

            // Default Selections
            if (cmbNationality.Items.Count > 0)
                cmbNationality.SelectedIndex = cmbNationality.FindString("Jordan");
                
            if (cmbGender.Items.Count > 0)
                cmbGender.SelectedIndex = 0;
        }
    }
}
