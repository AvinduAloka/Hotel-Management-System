using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectA
{
    public partial class PreLoadedWindow : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        public PreLoadedWindow()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 6, 6));

        }

        private const int CS_DropShadow = 0x00020000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = CS_DropShadow;
                return cp;
            }
        }

        string userNameValue;

        private void UserNameValueText()
        {
            userNameValue = Form1.insender.textboxLoginUser.Text;
        }

        private void PreLoadedWindow_Load(object sender, EventArgs e)
        {
            UserNameValueText();
            lblChangeLaableText.Text = "Hay!, " + userNameValue;
            timer1.Start();
        }

        public Point mouseLocation;

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 1;
                lblProjesCount.Text = progressBar1.Value.ToString() + "%";
                if (progressBar1.Value < 15)
                {
                    lblChangebletext.Text = "Manageing Resorces Files..";
                }
                else if (progressBar1.Value < 35)
                {
                    lblChangebletext.Text = "Getting DataBases...";
                }
                else if (progressBar1.Value < 50)
                {
                    lblChangebletext.Text = "Configeration files...";
                }
                else if(progressBar1.Value < 72)
                {
                    lblChangebletext.Text = "Building Interfaces..";
                }
                else
                {
                    lblChangebletext.Text = "Please Wait To Load DashBoard";
                }

            }
            else
            {
                timer1.Stop();

                View vv = new View();
                vv.Show();
                FutureCustomerNotes fd = new FutureCustomerNotes();
                fd.Show();

                View.instance.lblProfile.Text = userNameValue;
                if (userNameValue == "Admin" )
                {
                    View.instance.lblProfile.BackColor = Color.Maroon;
                    View.instance.minimizedLable.Visible = false;
                    View.instance.maximizeLable.Visible = true;
                    View.instance.addButton.Visible = true;

                    View.instance.AdvanceSettings.Visible = true;
                    View.instance.minimizedLable1.Visible = false;
                    View.instance.maximizeLable1.Visible = true;
                    View.instance.texter1.Visible = false;
                    View.instance.texter2.Visible = true;

                    View.instance.accountsettingslable.BackColor = Color.Maroon;
                    View.instance.accountsettingslable.Text = "Admin";

                    View.instance.accountSettingsUserButton.Visible = true;

                }
                else if (userNameValue == "User")
                {
                    View.instance.lblProfile.BackColor = Color.Green;
                    View.instance.minimizedLable.Visible = true;
                    View.instance.maximizeLable.Visible = false;
                    View.instance.addButton.Visible = false;

                    View.instance.AdvanceSettings.Visible = false;
                    View.instance.minimizedLable1.Visible = true;
                    View.instance.maximizeLable1.Visible = false;
                    View.instance.texter1.Visible = true;
                    View.instance.texter2.Visible = false;

                    View.instance.accountsettingslable.BackColor = Color.DarkGreen;
                    View.instance.accountsettingslable.Text = "User";

                    View.instance.accountSettingsUserButton.Visible = false;

                }
                else
                {
                    Form1 fm = new Form1();
                    fm.Show();
                    vv.Hide();
                    this.Hide();
                }

                this.Hide();
            }
        }
    }
}
