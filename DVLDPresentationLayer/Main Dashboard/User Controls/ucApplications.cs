using System;
using System.Drawing;
using System.Windows.Forms;
using DVLDPresentationLayer.Applications.International_Driving_License;

namespace DVLDPresentationLayer.Main_Dashboard.User_Controls
{
    public class ucApplications : UserControl
    {
        public ucApplications()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(245, 247, 250);
            _Build();
        }

        private void _Build()
        {
            var lblTitle = new Label
            {
                Text = "Application Management",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.FromArgb(26, 58, 96),
                AutoSize = true,
                Location = new Point(30, 30)
            };
            var lblSub = new Label
            {
                Text = "Handle all license applications submitted via mobile or counter.",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(32, 65)
            };

            var cards = new (string Title, string Desc, string Icon, Action OnClick)[]
            {
                ("New Local Application", "Create a new local driving license application.", "➕", () => { new frmAddUpdateLocalDrivingLicenseApplication().ShowDialog(); }),
                ("List All Applications", "Browse all local driving license applications.", "📋", () => { new frmListLocalDrivingLicenseApplications().ShowDialog(); }),
                ("International License", "Process a new international license application.", "🌍", () => { new frmInternationalDrivingLicenseApplication().ShowDialog(); }),
                ("List International", "View all international license applications.", "🗂️", () => { new frmListInternationalLicenses().ShowDialog(); }),
                ("Under Review", "Review and Approve/Reject pending applications.", "🔍", () => { new frmUnderReview().ShowDialog(); }),
                ("Application Types", "Manage application type fees and descriptions.", "⚙️", () => { new frmListApplicationTypes().ShowDialog(); }),
            };

            var flowPanel = _MakeFlowPanel();
            foreach (var card in cards)
            {
                flowPanel.Controls.Add(_MakeCard(card.Icon, card.Title, card.Desc, card.OnClick));
            }

            this.Controls.Add(lblTitle);
            this.Controls.Add(lblSub);
            this.Controls.Add(flowPanel);
        }

        private FlowLayoutPanel _MakeFlowPanel() => new FlowLayoutPanel
        {
            Location = new Point(30, 100),
            Size = new Size(this.Width - 60, this.Height - 120),
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = true,
            AutoScroll = true,
            BackColor = Color.Transparent
        };

        private Panel _MakeCard(string icon, string title, string desc, Action onClick)
        {
            var p = new Panel { Size = new Size(220, 140), BackColor = Color.White, Margin = new Padding(10), Cursor = Cursors.Hand };
            p.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 220, 140, 12, 12));

            var lblIcon  = new Label { Text = icon,  Font = new Font("Segoe UI", 22), Location = new Point(15, 15), AutoSize = true };
            var lblTitle = new Label { Text = title, Font = new Font("Segoe UI", 11, FontStyle.Bold), ForeColor = Color.FromArgb(26, 58, 96), Location = new Point(15, 60), AutoSize = true };
            var lblDesc  = new Label { Text = desc,  Font = new Font("Segoe UI", 8), ForeColor = Color.Gray, Location = new Point(15, 85), Size = new Size(190, 40) };

            p.Controls.AddRange(new Control[] { lblIcon, lblTitle, lblDesc });

            EventHandler h = (s, e) => onClick?.Invoke();
            p.Click += h;
            foreach (Control c in p.Controls) c.Click += h;
            p.MouseEnter += (s, e) => p.BackColor = Color.FromArgb(235, 242, 255);
            p.MouseLeave += (s, e) => p.BackColor = Color.White;
            return p;
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
    }
}
