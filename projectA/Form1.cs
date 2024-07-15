using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace projectA
{
    public partial class Form1 : Form
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

        public static Form1 insender;
        public TextBox textboxLoginUser;

        public static string to;

        NetworkCredential login;
        SmtpClient client;
        MailMessage msg;

        public Form1()
        {
            InitializeComponent();
            insender = this;
            textboxLoginUser = txtLoginUserName;
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 6, 6));
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-6S94ROH;Initial Catalog=LogInDB;Integrated Security=True");

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-6S94ROH;Initial Catalog=HotelDB;Integrated Security=True");


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

        private void Form1_Load(object sender, EventArgs e)
        {
            coveObjects();
            txtLoginUserName.Focus();

            txtLoginPassword.UseSystemPasswordChar = true;
            txtNewPass.UseSystemPasswordChar = true;
            txtReNewPass.UseSystemPasswordChar = true;

            grbforgotPass.Visible = false;
            grbchangePass.Visible = false;

        }

        public void coveObjects()
        {
            btnClear.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnClear.Width, btnClear.Height, 2, 2));
            btnSignIn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSignIn.Width, btnSignIn.Height, 2, 2));
            btnSubmit.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSubmit.Width, btnSubmit.Height, 2, 2));
            btnclear3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnclear3.Width, btnclear3.Height, 2, 2));
            btnOk.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnOk.Width, btnOk.Height, 2, 2));
            button1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 2, 2));
            txtLoginUserName.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtLoginUserName.Width, txtLoginUserName.Height, 2, 2));
            txtLoginPassword.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtLoginPassword.Width, txtLoginPassword.Height, 2, 2));
        }

        public Point mouseLocation;

        private void lblMoveandDrag_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void lblMoveandDrag_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearValue();
        }

        private void clearValue()
        {
            txtLoginPassword.Clear();
            txtLoginUserName.Clear();

            txtLoginUserName.Focus();
        }

        private void btnLoginClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnlUserName_Paint(object sender, PaintEventArgs e)
        {
            Graphics grp = this.pnlUserName.CreateGraphics();
            Pen blackPen = new Pen(Color.Black, 1);

            PointF pnt1 = new PointF(576.0F, 006.0F);
            PointF pnt2 = new PointF(000.0F, 006.0F);
            e.Graphics.DrawLine(blackPen, pnt1, pnt2);
        }

        private void pnlPassword_Paint(object sender, PaintEventArgs e)
        {
            Graphics grp = this.pnlPassword.CreateGraphics();
            Pen blackPen = new Pen(Color.Black, 1);

            PointF pnt1 = new PointF(576.0F, 006.0F);
            PointF pnt2 = new PointF(000.0F, 006.0F);
            e.Graphics.DrawLine(blackPen, pnt1, pnt2);
        }

        private void btnSignIn_MouseEnter(object sender, EventArgs e)
        {
            btnSignIn.BackColor = Color.MidnightBlue;
            btnSignIn.ForeColor = Color.White;
            btnSignIn.FlatAppearance.BorderSize = 0;
        }

        private void btnSignIn_MouseLeave(object sender, EventArgs e)
        {
            btnSignIn.BackColor = Color.RoyalBlue;
            btnSignIn.ForeColor = Color.Gainsboro;
            btnSignIn.FlatAppearance.BorderSize = 0;
        }

        private void btnClear_MouseEnter(object sender, EventArgs e)
        {
            btnClear.BackColor = Color.Black;
            btnClear.ForeColor = Color.White;
            btnClear.FlatAppearance.BorderSize = 0;
        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            btnClear.BackColor = Color.Gainsboro;
            btnClear.ForeColor = Color.Black;
            btnClear.FlatAppearance.BorderSize = 0;
        }

        private void btnLoginClose_MouseEnter(object sender, EventArgs e)
        {
            btnLoginClose.BackColor = Color.Red;
            btnLoginClose.ForeColor = Color.White;
            btnLoginClose.FlatAppearance.BorderSize = 0;
        }

        private void btnLoginClose_MouseLeave(object sender, EventArgs e)
        {
            btnLoginClose.BackColor = Color.MidnightBlue;
            btnLoginClose.ForeColor = Color.DarkGray;
            btnLoginClose.FlatAppearance.BorderSize = 0;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            signinSystem();
        }

        private void signinSystem()
        {

            try
            {
                if (txtLoginUserName.Text == "Admin")
                {
                    int i = 1;
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select CONVERT(varchar(4000),DECRYPTBYPASSPHRASE('8',Password)) from logInTB where ID = '" + i + "'", con);
                    string password = Convert.ToString(cmd.ExecuteScalar());
                    con.Close();

                    if (password == txtLoginPassword.Text)
                    {
                        if (txtLoginUserName.Text == "Admin" || txtLoginUserName.Text == "User")
                        {
                            PreLoadedWindow pr = new PreLoadedWindow();
                            pr.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtLoginPassword.Clear();
                            txtLoginUserName.Clear();

                            txtLoginUserName.Focus();
                            return;
                        }

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (txtLoginUserName.Text == "User")
                {
                    int y = 2;
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select CONVERT(varchar(4000),DECRYPTBYPASSPHRASE('8',Password)) from logInTB where ID = '" + y + "'", con);
                    string password = Convert.ToString(cmd.ExecuteScalar());
                    con.Close();

                    if (password == txtLoginPassword.Text)
                    {
                        if (txtLoginUserName.Text == "Admin" || txtLoginUserName.Text == "User")
                        {
                            PreLoadedWindow pr = new PreLoadedWindow();
                            pr.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtLoginPassword.Clear();
                            txtLoginUserName.Clear();

                            txtLoginUserName.Focus();
                            return;
                        }

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                con.Close();
            }
        }

        private void txtLoginUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(txtLoginPassword.Text == "")
                {
                    txtLoginPassword.Focus();
                }
                else if (txtLoginPassword.Text != "" || txtLoginUserName.Text != "")
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("select CONVERT(varchar(4000),DECRYPTBYPASSPHRASE('8',Password)) from logInTB where UserName = '" + txtLoginUserName.Text + "'", con);
                        string password = Convert.ToString(cmd.ExecuteScalar());
                        con.Close();

                        if (password == txtLoginPassword.Text)
                        {
                            if (txtLoginUserName.Text == "Admin" || txtLoginUserName.Text == "User")
                            {
                                PreLoadedWindow pr = new PreLoadedWindow();
                                pr.Show();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtLoginPassword.Clear();
                                txtLoginUserName.Clear();

                                txtLoginUserName.Focus();
                                return;
                            }

                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error");
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        private void txtLoginPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtLoginUserName.Text == "")
                {
                    txtLoginUserName.Focus();
                }
                else if (txtLoginPassword.Text != "" || txtLoginUserName.Text != "")
                {
                    try
                    {
                        if (txtLoginUserName.Text == "Admin")
                        {
                            int i = 1;
                            con.Open();
                            SqlCommand cmd = new SqlCommand("select CONVERT(varchar(4000),DECRYPTBYPASSPHRASE('8',Password)) from logInTB where ID = '" + i + "'", con);
                            string password = Convert.ToString(cmd.ExecuteScalar());
                            con.Close();

                            if (password == txtLoginPassword.Text)
                            {
                                if (txtLoginUserName.Text == "Admin" || txtLoginUserName.Text == "User")
                                {
                                    PreLoadedWindow pr = new PreLoadedWindow();
                                    pr.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtLoginPassword.Clear();
                                    txtLoginUserName.Clear();

                                    txtLoginUserName.Focus();
                                    return;
                                }

                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else if (txtLoginUserName.Text == "User")
                        {
                            int y = 2;
                            con.Open();
                            SqlCommand cmd = new SqlCommand("select CONVERT(varchar(4000),DECRYPTBYPASSPHRASE('8',Password)) from logInTB where ID = '" + y + "'", con);
                            string password = Convert.ToString(cmd.ExecuteScalar());
                            con.Close();

                            if (password == txtLoginPassword.Text)
                            {
                                if (txtLoginUserName.Text == "Admin" || txtLoginUserName.Text == "User")
                                {
                                    PreLoadedWindow pr = new PreLoadedWindow();
                                    pr.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtLoginPassword.Clear();
                                    txtLoginUserName.Clear();

                                    txtLoginUserName.Focus();
                                    return;
                                }

                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Error");
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        

        string Validemail;

        private void getemailfromdatabase()
        {
            if (txtLoginUserName.Text == "Admin")
            {
                int y = 1;
                con.Open();
                SqlCommand cmd = new SqlCommand("select CONVERT(varchar(4000),DECRYPTBYPASSPHRASE('8',Email)) from logInTB where ID ='" + y + "'", con);
                Validemail = Convert.ToString(cmd.ExecuteScalar());
                con.Close();
            }
            else if (txtLoginUserName.Text == "User")
            {
                int k = 2;
                con.Open();
                SqlCommand cmd = new SqlCommand("select CONVERT(varchar(4000),DECRYPTBYPASSPHRASE('8',Email)) from logInTB where ID ='" + k + "'", con);
                Validemail = Convert.ToString(cmd.ExecuteScalar());
                con.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtverifyCode.Text == "")
            {
                MessageBox.Show("Sorry You No Enter the code!");
            }
            else
            {
                try
                {
                    int seleRandomOTP = Convert.ToInt32(selRandomOTP);
                    int checktextbox = Convert.ToInt32(txtverifyCode.Text);
                    if (checktextbox == seleRandomOTP)
                    {
                        grbforgotPass.Visible = true;
                        grbchangePass.Visible = true;

                        txtNewPass.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Sorry Your OTP Is Not Matched!");
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
            

        }

        private void timvcode_Tick(object sender, EventArgs e)
        {
            
        }

        String RandomCode1;
        String RandomCode2;

        string selRandomOTP;



        string body;

        string emailgot;

        string emailgotPass;

        private void bodymessages()
        {
            Random rand = new Random();
            RandomCode1 = (rand.Next(100, 999)).ToString();
            RandomCode2 = (rand.Next(100, 999)).ToString();
            selRandomOTP = RandomCode1 + RandomCode2;
            body = "<h1>Pinxel</h1><h4>One Time OTP Code!</h4><p>Your Reset Password OTP Code Is : </p><h1> " + RandomCode1 + "-" + RandomCode2 + "</h1><p>This is your Software Password Recovery Code. Enter This one and Create new Password to Login the system.</p>";
        }

        int id = 1;

        private void getemailindashbord()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from CompanyTB where ID = '"+ id +"'", conn);
            SqlDataReader srd = cmd.ExecuteReader();
            while (srd.Read())
            {
                emailgot = srd.GetValue(8).ToString();
                emailgotPass = srd.GetValue(9).ToString();
            }
            conn.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool connection = NetworkInterface.GetIsNetworkAvailable();
            if (connection == true)
            {
                if (txtLoginUserName.Text != "")
                {
                    if (txtLoginUserName.Text == "Admin" || txtLoginUserName.Text == "User")
                    {
                        bodymessages();
                        getemailfromdatabase();
                        getemailindashbord();
                        login = new NetworkCredential(emailgot, emailgotPass);
                        client = new SmtpClient("smtp.gmail.com");
                        client.Port = 587;
                        client.EnableSsl = true;
                        client.Credentials = login;
                        msg = new MailMessage { From = new MailAddress("pinxeltraders" + "smtp.gmail.com".Replace("smtp.", "@"), "Pinxel-Hotel Manazgement System", Encoding.UTF8) };
                        msg.To.Add(new MailAddress(Validemail));
                        msg.Subject = "Pinxel-OTP Code";
                        msg.Body = body;
                        msg.BodyEncoding = Encoding.UTF8;
                        msg.IsBodyHtml = true;
                        msg.Priority = MailPriority.Normal;
                        msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                        client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallBack);
                        string userstate = "Sending...";
                        client.SendAsync(msg, userstate);

                        grbforgotPass.Visible = true;
                        grbchangePass.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Invalied Your UserAccount");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter the Account To Send Mail!");
                }
            }
            else
            {
                MessageBox.Show("You are not Connected to the internet!");
                return;
            }
            
        }

        private void SendCompletedCallBack(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show(string.Format("{0} send Canceled.", e.UserState), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (e.Error != null)
            {
                MessageBox.Show(string.Format("{0} {1}", e.UserState, e.Error), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Your OTP has Been Successfully Sent For Your Email.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            grbforgotPass.Visible = false;
            grbchangePass.Visible = false;
            lblErrormessage.ForeColor = Color.DimGray;
            lblErrormessage.Text = "*Enter the Username and Password";
            txtLoginUserName.Clear();
            txtLoginPassword.Clear();
            txtNewPass.Clear();
            txtReNewPass.Clear();
            txtverifyCode.Clear();
            return;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            grbforgotPass.Visible = false;
            grbchangePass.Visible = false;
            lblErrormessage.ForeColor = Color.DimGray;
            lblErrormessage.Text = "*Enter the Username and Password";
            txtLoginUserName.Clear();
            txtLoginPassword.Clear();
            txtNewPass.Clear();
            txtReNewPass.Clear();
            txtverifyCode.Clear();
            return;
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            grbforgotPass.Visible = false;
            grbchangePass.Visible = false;
            lblErrormessage.ForeColor = Color.DimGray;
            lblErrormessage.Text = "*Enter the Username and Password";
            txtLoginUserName.Clear();
            txtLoginPassword.Clear();
            txtNewPass.Clear();
            txtReNewPass.Clear();
            txtverifyCode.Clear();
            return;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Graphics grp = this.panel3.CreateGraphics();
            Pen blackPen = new Pen(Color.Black, 1);

            PointF pnt1 = new PointF(576.0F, 006.0F);
            PointF pnt2 = new PointF(000.0F, 006.0F);
            e.Graphics.DrawLine(blackPen, pnt1, pnt2);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Graphics grp = this.panel4.CreateGraphics();
            Pen blackPen = new Pen(Color.Black, 1);

            PointF pnt1 = new PointF(576.0F, 006.0F);
            PointF pnt2 = new PointF(000.0F, 006.0F);
            e.Graphics.DrawLine(blackPen, pnt1, pnt2);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics grp = this.panel1.CreateGraphics();
            Pen blackPen = new Pen(Color.Black, 1);

            PointF pnt1 = new PointF(576.0F, 006.0F);
            PointF pnt2 = new PointF(000.0F, 006.0F);
            e.Graphics.DrawLine(blackPen, pnt1, pnt2);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtNewPass.Text != "" || txtReNewPass.Text != "")
            {
                if (txtNewPass.Text == txtReNewPass.Text)
                {
                    if (IsValidPassword(txtNewPass.Text))
                    {
                        if (txtLoginUserName.Text == "Admin")
                        {
                            int y = 1;
                            con.Open();
                            SqlCommand cmd1 = new SqlCommand("update loginTB set Password= ENCRYPTBYPASSPHRASE('8','" + txtNewPass.Text + "') where ID = '" + y + "'", con);
                            cmd1.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Update Successfull!");

                            grbforgotPass.Visible = false;
                            grbchangePass.Visible = false;

                            lblErrormessage.ForeColor = Color.DimGray;
                            lblErrormessage.Text = "*Enter the Username and Password";
                            txtLoginUserName.Clear();
                            txtLoginPassword.Clear();
                            txtNewPass.Clear();
                            txtReNewPass.Clear();
                            txtverifyCode.Clear();

                            txtLoginUserName.Focus();
                        }
                        else if (txtLoginUserName.Text == "User")
                        {
                            int k = 2;
                            con.Open();
                            SqlCommand cmd1 = new SqlCommand("update loginTB set Password= ENCRYPTBYPASSPHRASE('8','" + txtNewPass.Text + "') where ID = '" + k + "'", con);
                            cmd1.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Update Successfull!");

                            grbforgotPass.Visible = false;
                            grbchangePass.Visible = false;

                            lblErrormessage.ForeColor = Color.DimGray;
                            lblErrormessage.Text = "*Enter the Username and Password";
                            txtLoginUserName.Clear();
                            txtLoginPassword.Clear();
                            txtNewPass.Clear();
                            txtReNewPass.Clear();
                            txtverifyCode.Clear();

                            txtLoginUserName.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your Password Is Not Valied!");
                    }

                    
                }
                else
                {
                    MessageBox.Show("Passwords Not Matched!");
                }
            }
            else
            {
                MessageBox.Show("Please enter the new password!");
            }
        }

        private void btnclear3_Click(object sender, EventArgs e)
        {
            txtNewPass.Clear();
            txtReNewPass.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtverifyCode.Clear();
        }

        private void txtverifyCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNewPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNewPass.Text == "")
                {
                    txtReNewPass.Focus();
                }
                else if (txtReNewPass.Text == "" || txtNewPass.Text == "")
                {
                    MessageBox.Show("Please enter the new password!");
                    txtNewPass.Focus();
                }
                else
                {
                    if (txtNewPass.Text == txtReNewPass.Text)
                    {
                        if (IsValidPassword(txtNewPass.Text))
                        {
                            if (txtLoginUserName.Text == "Admin")
                            {
                                int y = 1;
                                con.Open();
                                SqlCommand cmd1 = new SqlCommand("update loginTB set Password= ENCRYPTBYPASSPHRASE('8','" + txtNewPass.Text + "') where ID = '" + y + "'", con);
                                cmd1.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("Update Successfull!");

                                grbforgotPass.Visible = false;
                                grbchangePass.Visible = false;

                                lblErrormessage.ForeColor = Color.DimGray;
                                lblErrormessage.Text = "*Enter the Username and Password";
                                txtLoginUserName.Clear();
                                txtLoginPassword.Clear();
                                txtNewPass.Clear();
                                txtReNewPass.Clear();
                                txtverifyCode.Clear();

                                txtLoginUserName.Focus();
                            }
                            else if (txtLoginUserName.Text == "User")
                            {
                                int k = 2;
                                con.Open();
                                SqlCommand cmd1 = new SqlCommand("update loginTB set Password= ENCRYPTBYPASSPHRASE('8','" + txtNewPass.Text + "') where ID = '" + k + "'", con);
                                cmd1.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("Update Successfull!");

                                grbforgotPass.Visible = false;
                                grbchangePass.Visible = false;

                                lblErrormessage.ForeColor = Color.DimGray;
                                lblErrormessage.Text = "*Enter the Username and Password";
                                txtLoginUserName.Clear();
                                txtLoginPassword.Clear();
                                txtNewPass.Clear();
                                txtReNewPass.Clear();
                                txtverifyCode.Clear();

                                txtLoginUserName.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Your Password Is Not Valied!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Passwords Not Matched!");
                    }
                }
            }
        }

        private void txtReNewPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtReNewPass.Text == "")
                {
                    txtNewPass.Focus();
                }
                else if (txtReNewPass.Text == "" || txtNewPass.Text == "")
                {
                    MessageBox.Show("Please enter the new password!");
                    txtNewPass.Focus();
                }
                else
                {
                    if (txtNewPass.Text == txtReNewPass.Text)
                    {
                        if (IsValidPassword(txtNewPass.Text))
                        {
                            if (txtLoginUserName.Text == "Admin")
                            {
                                int y = 1;
                                con.Open();
                                SqlCommand cmd1 = new SqlCommand("update loginTB set Password= ENCRYPTBYPASSPHRASE('8','" + txtNewPass.Text + "') where ID = '" + y + "'", con);
                                cmd1.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("Update Successfull!");

                                grbforgotPass.Visible = false;
                                grbchangePass.Visible = false;

                                lblErrormessage.ForeColor = Color.DimGray;
                                lblErrormessage.Text = "*Enter the Username and Password";
                                txtLoginUserName.Clear();
                                txtLoginPassword.Clear();
                                txtNewPass.Clear();
                                txtReNewPass.Clear();
                                txtverifyCode.Clear();

                                txtLoginUserName.Focus();
                            }
                            else if (txtLoginUserName.Text == "User")
                            {
                                int k = 2;
                                con.Open();
                                SqlCommand cmd1 = new SqlCommand("update loginTB set Password= ENCRYPTBYPASSPHRASE('8','" + txtNewPass.Text + "') where ID = '" + k + "'", con);
                                cmd1.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("Update Successfull!");

                                grbforgotPass.Visible = false;
                                grbchangePass.Visible = false;

                                lblErrormessage.ForeColor = Color.DimGray;
                                lblErrormessage.Text = "*Enter the Username and Password";
                                txtLoginUserName.Clear();
                                txtLoginPassword.Clear();
                                txtNewPass.Clear();
                                txtReNewPass.Clear();
                                txtverifyCode.Clear();

                                txtLoginUserName.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Your Password Is Not Valied!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Passwords Not Matched!");
                    }
                }
            }
        }

        private void txtverifyCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtverifyCode.Text == "")
                {
                    MessageBox.Show("Sorry You No Enter the code!");
                }
                else
                {
                    try
                    {
                        int seleRandomOTP = Convert.ToInt32(selRandomOTP);
                        int checktextbox = Convert.ToInt32(txtverifyCode.Text);
                        if (checktextbox == seleRandomOTP)
                        {
                            grbforgotPass.Visible = true;
                            grbchangePass.Visible = true;

                            txtNewPass.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Sorry Your OTP Is Not Matched!");
                        }
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
            }
        }

        public static bool IsValidPassword(string plainText)
        {
            Regex regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            Match match = regex.Match(plainText);
            return match.Success;
        }

        private void txtNewPass_TextChanged(object sender, EventArgs e)
        {
            if (IsValidPassword(txtNewPass.Text))
            {
                lblErrormessage.ForeColor = Color.DarkGreen;
                lblErrormessage.Text = "Valied Password";
            }
            else
            {
                lblErrormessage.ForeColor = Color.Red;
                lblErrormessage.Text = "Not Valied Password";
            }
        }

        private void txtNewPass_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Show("* Password of Length 8 \n * Requires at least 1 Unique Char. \n * Requires 1 Digit \n * Requires 1 Lower Case character \n * Requires 1 Upper Case character \n * Requires 1 Special Character", txtNewPass);
        }

        private void txtReNewPass_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Show("* Password of Length 8 \n * Requires at least 1 Unique Char. \n * Requires 1 Digit \n * Requires 1 Lower Case character \n * Requires 1 Upper Case character \n * Requires 1 Special Character", txtReNewPass);
        }

        private void chbShowPassNewPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chbShowPassNewPass.Checked)
            {
                txtNewPass.UseSystemPasswordChar = false;
                txtReNewPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtNewPass.UseSystemPasswordChar = true;
                txtReNewPass.UseSystemPasswordChar = true;
            }
        }

        private void chbSigninpass_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSigninpass.Checked)
            {
                txtLoginPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtLoginPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnclear3_MouseEnter(object sender, EventArgs e)
        {
            btnclear3.BackColor = Color.Black;
            btnclear3.ForeColor = Color.White;
            btnclear3.FlatAppearance.BorderSize = 0;
        }

        private void btnclear3_MouseLeave(object sender, EventArgs e)
        {
            btnclear3.BackColor = Color.Gainsboro;
            btnclear3.ForeColor = Color.Black;
            btnclear3.FlatAppearance.BorderSize = 0;
        }

        private void btnSubmit_MouseEnter(object sender, EventArgs e)
        {
            btnSubmit.BackColor = Color.MidnightBlue;
            btnSubmit.ForeColor = Color.White;
            btnSubmit.FlatAppearance.BorderSize = 0;
        }

        private void btnSubmit_MouseLeave(object sender, EventArgs e)
        {
            btnSubmit.BackColor = Color.RoyalBlue;
            btnSubmit.ForeColor = Color.White;
            btnSubmit.FlatAppearance.BorderSize = 0;
        }

        private void btnOk_MouseEnter(object sender, EventArgs e)
        {
            btnOk.BackColor = Color.MidnightBlue;
            btnOk.ForeColor = Color.White;
            btnOk.FlatAppearance.BorderSize = 0;
        }

        private void btnOk_MouseLeave(object sender, EventArgs e)
        {
            btnOk.BackColor = Color.RoyalBlue;
            btnOk.ForeColor = Color.White;
            btnOk.FlatAppearance.BorderSize = 0;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
            button1.ForeColor = Color.White;
            button1.FlatAppearance.BorderSize = 0;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Gainsboro;
            button1.ForeColor = Color.Black;
            button1.FlatAppearance.BorderSize = 0;
        }

        private void linkResend_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool connection = NetworkInterface.GetIsNetworkAvailable();
            if (connection == true)
            {
                if (txtLoginUserName.Text == "Admin" || txtLoginUserName.Text == "User")
                {
                    bodymessages();
                    getemailfromdatabase();
                    getemailindashbord();
                    login = new NetworkCredential(emailgot, emailgotPass);
                    client = new SmtpClient("smtp.gmail.com");
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Credentials = login;
                    msg = new MailMessage { From = new MailAddress("pinxeltraders" + "smtp.gmail.com".Replace("smtp.", "@"), "Pinxel-Hotel Manazgement System", Encoding.UTF8) };
                    msg.To.Add(new MailAddress(Validemail));
                    msg.Subject = "Pinxel-OTP Code";
                    msg.Body = body;
                    msg.BodyEncoding = Encoding.UTF8;
                    msg.IsBodyHtml = true;
                    msg.Priority = MailPriority.Normal;
                    msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallBack);
                    string userstate = "Sending...";
                    client.SendAsync(msg, userstate);

                    grbforgotPass.Visible = true;
                    grbchangePass.Visible = false;
                }
                else
                {
                    MessageBox.Show("Invalied Your UserAccount");
                }
            }
            else
            {
                MessageBox.Show("You are not Connected to the internet!");
                return;
            }
            
        }

        private void txtverifyCode_TextChanged(object sender, EventArgs e)
        {



            
        }
    }
}
