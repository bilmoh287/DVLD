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

namespace DVLDPresentationLayer.Main_Dashboard.User_Controls
{
    public partial class ucPeople : UserControl
    {
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public ucPeople()
        {
            InitializeComponent();
            _PolishUI();
            
            // Wire up button click events
            btnListPeople.Click += btnListPeople_Click;
            btnAddUpdatePeople.Click += btnAddUpdatePeople_Click;
        }

        private void _PolishUI()
        {
            this.BackColor = Color.FromArgb(245, 247, 250);
            foreach (Control c in this.Controls)
            {
                if (c is Button btn)
                {
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.FromArgb(26, 58, 96);
                    btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 12, 12));
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Cursor = Cursors.Hand;
                    btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(235, 242, 255);
                    btn.MouseLeave += (s, e) => btn.BackColor = Color.White;
                }
                else if (c is Guna.UI2.WinForms.Guna2HtmlLabel lbl)
                {
                    lbl.ForeColor = Color.FromArgb(26, 58, 96);
                    lbl.Font = new Font("Segoe UI", 24, FontStyle.Bold);
                }
            }
        }

        private void ucPeople_Load(object sender, EventArgs e)
        {
            _LoadKPIs();
        }

        private void _LoadKPIs()
        {
            int totalPeople = clsKPI.GetTotalPeople();
            int totalMales = clsKPI.GetTotalMales();
            int totalFemales = clsKPI.GetTotalFemales();
            int totalApplicants = clsKPI.GetTotalApplicants();
            int totalDrivers = clsKPI.GetTotalDrivers();
            int totalUsers = clsKPI.GetTotalUsers();

            // Find or Create KPI Container
            FlowLayoutPanel pnlKPIs = this.Controls.OfType<FlowLayoutPanel>().FirstOrDefault(p => p.Name == "pnlKPIs");
            if (pnlKPIs == null)
            {
                pnlKPIs = new FlowLayoutPanel();
                pnlKPIs.Name = "pnlKPIs";
                pnlKPIs.FlowDirection = FlowDirection.LeftToRight;
                pnlKPIs.WrapContents = true;
                pnlKPIs.Location = new Point(40, 120);
                pnlKPIs.Size = new Size(950, 250); // Increased height to accommodate multiple rows
                pnlKPIs.BackColor = Color.Transparent;
                this.Controls.Add(pnlKPIs);
            }
            
            pnlKPIs.Controls.Clear();

            // Add Cards
            pnlKPIs.Controls.Add(_CreateKPICard("TOTAL PEOPLE", totalPeople.ToString(), Color.FromArgb(41, 128, 185)));
            pnlKPIs.Controls.Add(_CreateKPICard("TOTAL MALES", totalMales.ToString(), Color.FromArgb(39, 174, 96)));
            pnlKPIs.Controls.Add(_CreateKPICard("TOTAL FEMALES", totalFemales.ToString(), Color.FromArgb(142, 68, 173)));
            pnlKPIs.Controls.Add(_CreateKPICard("TOTAL APPLICANTS", totalApplicants.ToString(), Color.FromArgb(230, 126, 34))); // Orange
            pnlKPIs.Controls.Add(_CreateKPICard("TOTAL DRIVERS", totalDrivers.ToString(), Color.FromArgb(192, 57, 43))); // Dark Red
            pnlKPIs.Controls.Add(_CreateKPICard("SYSTEM USERS", totalUsers.ToString(), Color.FromArgb(22, 160, 133))); // Teal
        }

        private Panel _CreateKPICard(string title, string value, Color accentColor)
        {
            Panel card = new Panel();
            card.Size = new Size(250, 100);
            card.BackColor = Color.White;
            card.Margin = new Padding(15);
            card.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, card.Width, card.Height, 15, 15));

            // Accent strip on the left
            Panel strip = new Panel();
            strip.Size = new Size(5, 100);
            strip.Dock = DockStyle.Left;
            strip.BackColor = accentColor;
            card.Controls.Add(strip);

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI Semibold", 10F);
            lblTitle.ForeColor = Color.Gray;
            lblTitle.Location = new Point(20, 15);
            lblTitle.AutoSize = true;

            Label lblValue = new Label();
            lblValue.Text = value;
            lblValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblValue.ForeColor = Color.FromArgb(26, 58, 96);
            lblValue.Location = new Point(15, 40);
            lblValue.AutoSize = true;

            card.Controls.Add(lblValue);
            card.Controls.Add(lblTitle);

            return card;
        }

        private void btnListPeople_Click(object sender, EventArgs e)
        {
            frmListPeople frm = new frmListPeople();
            frm.ShowDialog();
            
            // Refresh KPIs if they added/deleted someone
            _LoadKPIs();
        }

        private void btnAddUpdatePeople_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(-1);
            frm.ShowDialog();
            
            // Refresh KPIs if they added someone
            _LoadKPIs();
        }
    }
}
