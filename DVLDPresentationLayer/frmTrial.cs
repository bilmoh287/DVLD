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
    public partial class frmTrial : Form
    {
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblRole;
        private ComboBox cmbRole;
        private CheckBox chkRememberMe;
        private Button btnLogin;
        private Button btnCancel;
        private Label lblFooter;
        private PictureBox picShield;

        public frmTrial()
        {
            InitializeComponent();
            InitializeLoginForm();
        }

        private void InitializeLoginForm()
        {
            // Shield Icon
            picShield = new PictureBox
            {
                Image = SystemIcons.Shield.ToBitmap(),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(20, 20),
                Size = new Size(48, 48)
            };
            Controls.Add(picShield);

            // Username
            lblUsername = new Label { Text = "Username:", Location = new Point(80, 25), AutoSize = true };
            txtUsername = new TextBox { Location = new Point(170, 22), Width = 180 };
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);

            // Password
            lblPassword = new Label { Text = "Password:", Location = new Point(80, 65), AutoSize = true };
            txtPassword = new TextBox { Location = new Point(170, 62), Width = 180, UseSystemPasswordChar = true };
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);

            // Role Dropdown
            lblRole = new Label { Text = "Role:", Location = new Point(80, 105), AutoSize = true };
            cmbRole = new ComboBox
            {
                Location = new Point(170, 102),
                Width = 180,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbRole.Items.AddRange(new string[] { "Admin", "Officer", "User" });
            cmbRole.SelectedIndex = 0;
            Controls.Add(lblRole);
            Controls.Add(cmbRole);

            // Remember Me
            chkRememberMe = new CheckBox { Text = "Remember Me", Location = new Point(170, 142), AutoSize = true };
            Controls.Add(chkRememberMe);

            // Login Button
            btnLogin = new Button { Text = "Login", Location = new Point(170, 180), Width = 80 };
            btnLogin.Click += BtnLogin_Click;
            Controls.Add(btnLogin);

            // Cancel Button
            btnCancel = new Button { Text = "Cancel", Location = new Point(270, 180), Width = 80 };
            btnCancel.Click += (s, e) => this.Close();
            Controls.Add(btnCancel);

            // Footer
            lblFooter = new Label
            {
                Text = "© 2024 DVLD Management System",
                AutoSize = true,
                ForeColor = Color.Gray,
                Location = new Point(120, 230)
            };
            Controls.Add(lblFooter);

            // Set form properties
            this.Text = "DVLD Login";
            this.ClientSize = new Size(400, 270);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // Basic validation (replace with secure authentication logic)
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: Implement secure authentication here

            MessageBox.Show("Login successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Proceed to main application
        }
    }
}
