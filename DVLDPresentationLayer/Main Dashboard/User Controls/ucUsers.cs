using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPresentationLayer.Main_Dashboard.User_Controls
{
    public partial class ucUsers : UserControl
    {
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public ucUsers()
        {
            InitializeComponent();
            _PolishUI();
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
    }
}
