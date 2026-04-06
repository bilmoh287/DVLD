using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBussinessLayer;
using DVLDPresentationLayer.Global_Classes;

namespace DVLDPresentationLayer
{
    public partial class frmAddUpdateInstitueCourse : Form
    {
        enum enMode { AddNew = 0, Update = 1 };
        public enum enGendor { Male = 0, Female = 1 };
        private int _InstituteID = -1;
        private int _CourseID = -1;
        private clsInstituteCourses _Course= new clsInstituteCourses();
        enMode _Mode = enMode.AddNew;
        public frmAddUpdateInstitueCourse(int InstitueID, int courseID)
        {
            InitializeComponent();
            _CourseID = courseID;
            _InstituteID = InstitueID;
        }
        public frmAddUpdateInstitueCourse(int CourseID)
        {
            InitializeComponent();
            _InstituteID = CourseID;
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                //lblTitle.Text = "Add New Driving Institute";
                this.Text = "Add New Course";
                _Course = new clsInstituteCourses();
            }
            else
            {
                //lblTitle.Text = "Update Driving Institute";
                this.Text = "Update Course";
            }

            lblInstituteID.Text = _InstituteID.ToString();
            txtCourseName.Text = "";
            txtDurationInDays.Text = "";
            txtCourseFee.Text = "";
        }

        private void _LoadData()
        {
            _Course = clsInstituteCourses.Find(_CourseID, _InstituteID);

            if (_Course == null)
            {
                MessageBox.Show("No Course with ID = " + _CourseID , "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            lblInstituteID.Text = _InstituteID.ToString();
            txtCourseName.Text = _Course.CourseName;
            txtDurationInDays.Text = _Course.DurationInDays.ToString();
            txtCourseFee.Text = _Course.CourseFee.ToString();
        }

        private void frmAddUpdateInstitueCourse_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid! Please check the red icons.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Assigning values from UI to the Business Object
            _Course.InstituteID = _InstituteID;
            _Course.CourseName = txtCourseName.Text.Trim();
            _Course.DurationInDays = Convert.ToInt32(txtDurationInDays.Text.Trim());
            _Course.CourseFee = Convert.ToDecimal(txtCourseFee.Text.Trim());

            // Assuming current user ID is handled globally or passed to the form
            // _Course.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_Course.Save())
            {
                lblInstituteID.Text = _Course.CourseID.ToString();
                _Mode = enMode.Update; // Change mode to update after first save
                //lblTitle.Text = "Update Driving Institute";

                // Trigger the event

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data was not saved successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCourseName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCourseName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCourseName, "Course Name is required!");
            }
            else
            {
                errorProvider1.SetError(txtCourseName, null);
            }
        }


        private void txtCourseFee_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCourseFee.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCourseFee, "Course Fee is required!");
            }
            else if (!decimal.TryParse(txtCourseFee.Text.Trim(), out decimal fee) || fee < 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCourseFee, "Please enter a valid non-negative fee amount!");
            }
            else
            {
                errorProvider1.SetError(txtCourseFee, null);
            }
        }

        private void txtDurationInDays_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDurationInDays.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDurationInDays, "Duration (in days) is required!");
            }
            else if (!int.TryParse(txtDurationInDays.Text.Trim(), out int duration) || duration <= 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDurationInDays, "Please enter a valid positive number of days!");
            }
            else
            {
                errorProvider1.SetError(txtDurationInDays, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
