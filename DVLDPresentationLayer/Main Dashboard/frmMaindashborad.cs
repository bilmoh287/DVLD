using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDPresentationLayer.Main_Dashboard.User_Controls;

namespace DVLDPresentationLayer
{
    public partial class frmMaindashborad : Form
    {
        public frmMaindashborad()
        {
            InitializeComponent();
        }

        private void _LoadUserControl(UserControl userControl)
        {
            // Clear current content
            if (panel2.Controls.Count > 0)
                panel2.Controls.Clear();

            // Setup the new control to fill the panel (handles Maximized state)
            userControl.Dock = DockStyle.Fill;
            
            // Add to panel
            panel2.Controls.Add(userControl);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            lblHeader.Text = "DASHBOARD";
            _LoadUserControl(new ucDashboard());
        }

        private void frmMaindashborad_Load(object sender, EventArgs e)
        {
            // Automatically load dashboard on startup
            btnDashboard_Click(null, null);
        }

        private void btnApplicants_Click(object sender, EventArgs e)
        {
            lblHeader.Text = "HELLO";
            _LoadUserControl(new ucApplicants());
        }
    }
}
