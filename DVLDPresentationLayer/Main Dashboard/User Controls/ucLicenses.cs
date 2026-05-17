using System;
using System.Drawing;
using System.Windows.Forms;
using DVLDBussinessLayer;
using DVLDPresentationLayer.Applications.Renew_Local_License;
using DVLDPresentationLayer.Applications.Replace_Lost_or_Damaged_License;
using DVLDPresentationLayer.Applications.Relesease_Detained_Licenses;
using DVLDPresentationLayer.Licenses.Detain_License;

namespace DVLDPresentationLayer.Main_Dashboard.User_Controls
{
    public class ucLicenses : UserControl
    {
        public ucLicenses()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(245, 247, 250);
            _Build();
        }

        private void _Build()
        {
            // Title
            var lblTitle = new Label
            {
                Text = "License Management",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.FromArgb(26, 58, 96),
                AutoSize = true,
                Location = new Point(30, 30)
            };
            var lblSub = new Label
            {
                Text = "Manage all license operations from this panel.",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(32, 65)
            };

            var cards = new (string Title, string Desc, string Icon, Action OnClick)[]
            {
                ("Local Licenses", "Browse and manage all issued local licenses.", "📋", () => { new frmListLocalDrivingLicenseApplications().ShowDialog(); }),
                ("License History", "View full license history for a specific person.", "🕒", () => { new frmShowPersonLicenseHistory().ShowDialog(); }),
                ("Issue License", "Issue a first-time driver license.", "🪪", () => { new frmIssueDriverLicenseFirstTime().ShowDialog(); }),
                ("Renew License", "Process a license renewal application.", "🔄", () => { new frmRenewlLocalDrivingLicenseApplication().ShowDialog(); }),
                ("Replace License", "Replace a lost or damaged license.", "🔁", () => { new frmReplaceLostOrDamagedLicense().ShowDialog(); }),
                ("Detain License", "Record a license detention.", "🔒", () => { new frmDetainLicenseApplication().ShowDialog(); }),
                ("Release License", "Process a detained license release.", "🔓", () => { new frmReleaseDetainedLicenseApplication().ShowDialog(); }),
                ("Detained List", "View all currently detained licenses.", "📌", () => { new frmListDetainedLicenses().ShowDialog(); }),
            };

            var flowPanel = new FlowLayoutPanel
            {
                Location = new Point(30, 100),
                Size = new Size(this.Width - 60, this.Height - 120),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                AutoScroll = true,
                BackColor = Color.Transparent
            };

            foreach (var card in cards)
            {
                var action = card.OnClick;
                var panel = _MakeCard(card.Icon, card.Title, card.Desc, action);
                flowPanel.Controls.Add(panel);
            }

            this.Controls.Add(lblTitle);
            this.Controls.Add(lblSub);
            this.Controls.Add(flowPanel);
        }

        private Panel _MakeCard(string icon, string title, string desc, Action onClick)
        {
            var p = new Panel
            {
                Size = new Size(220, 140),
                BackColor = Color.White,
                Margin = new Padding(10),
                Cursor = Cursors.Hand
            };
            p.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 220, 140, 12, 12));

            var lblIcon = new Label { Text = icon, Font = new Font("Segoe UI", 22), Location = new Point(15, 15), AutoSize = true };
            var lblTitle = new Label { Text = title, Font = new Font("Segoe UI", 11, FontStyle.Bold), ForeColor = Color.FromArgb(26, 58, 96), Location = new Point(15, 60), AutoSize = true };
            var lblDesc = new Label { Text = desc, Font = new Font("Segoe UI", 8), ForeColor = Color.Gray, Location = new Point(15, 85), Size = new Size(190, 40), AutoSize = false };

            p.Controls.AddRange(new Control[] { lblIcon, lblTitle, lblDesc });

            EventHandler clickHandler = (s, e) => onClick?.Invoke();
            p.Click += clickHandler;
            foreach (Control c in p.Controls) c.Click += clickHandler;

            p.MouseEnter += (s, e) => p.BackColor = Color.FromArgb(235, 242, 255);
            p.MouseLeave += (s, e) => p.BackColor = Color.White;

            return p;
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
    }
}
