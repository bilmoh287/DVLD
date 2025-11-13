using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPresentationLayer
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        //// Win32 imports to allow dragging
        //[DllImport("user32.dll")]
        //public static extern void ReleaseCapture();
        //[DllImport("user32.dll")]
        //public static extern void SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        //private const int WM_NCLBUTTONDOWN = 0xA1;
        //private const int HTCAPTION = 0x2;

        //private Panel pnlHeader;
        //private Label lblTitle;
        //private Button btnClose;

        //private void SetupCustomHeader()
        //{
        //    this.FormBorderStyle = FormBorderStyle.None;
        //    this.Padding = new Padding(1);
        //    this.BackColor = Color.LightGray; // border color

        //    // === Header panel ===
        //    pnlHeader = new Panel
        //    {
        //        Dock = DockStyle.Top,
        //        Height = 40,
        //        BackColor = Color.DarkRed,
        //    };
        //    pnlHeader.MouseDown += PnlHeader_MouseDown;
        //    this.Controls.Add(pnlHeader);

        //    // === Title label ===
        //    lblTitle = new Label
        //    {
        //        Text = this.Text,
        //        ForeColor = Color.White,
        //        Font = new Font("Segoe UI", 12, FontStyle.Bold),
        //        AutoSize = true,
        //        Location = new Point(12, 10)
        //    };
        //    pnlHeader.Controls.Add(lblTitle);

        //    // === Close button ===
        //    btnClose = new Button
        //    {
        //        Text = "X",
        //        ForeColor = Color.White,
        //        FlatStyle = FlatStyle.Flat,
        //        BackColor = Color.DarkRed,
        //        Font = new Font("Segoe UI", 10, FontStyle.Bold),
        //        Size = new Size(40, 30),
        //        Anchor = AnchorStyles.Top | AnchorStyles.Right,
        //        Location = new Point(this.Width - 50, 5)
        //    };
        //    btnClose.FlatAppearance.BorderSize = 0;
        //    btnClose.Click += (s, e) => this.Close();
        //    pnlHeader.Controls.Add(btnClose);

        //    this.Resize += FrmBaseForm_Resize;
        //}

        //private void FrmBaseForm_Resize(object sender, EventArgs e)
        //{
        //    if (btnClose != null)
        //        btnClose.Location = new Point(this.Width - 50, 5);
        //}

        //private void PnlHeader_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        ReleaseCapture();
        //        SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        //    }
        //}

        //// Allow derived forms to easily change title text or color
        //public void SetHeader(string title, Color? backColor = null)
        //{
        //    lblTitle.Text = title;
        //    if (backColor.HasValue)
        //        pnlHeader.BackColor = backColor.Value;
        //}

        public void SetHeaderColor(Color color)
        {
            pnlHeader.BackColor = color;
        }

        public void SetHeaderTitle(string title)
        {
            lblTitle.Text = title;
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {

        }
    }
}
