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

namespace projectA
{
    public partial class FutureCustomerNotes : Form
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


        public FutureCustomerNotes()
        {
            InitializeComponent();

            deletedatebynote();

            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 6, 6));
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-6S94ROH;Initial Catalog=HotelDB;Integrated Security=True");

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

        private void deletedatebynote()
        {
            con.Open();
            SqlCommand cmd2 = new SqlCommand("DELETE FROM FuturecustomerTB WHERE CheckInDate < GETDATE() - 1", con);
            cmd2.ExecuteNonQuery();
            con.Close();
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.Red;
            button4.ForeColor = Color.White;
            button4.FlatAppearance.BorderSize = 0;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.MidnightBlue;
            button4.ForeColor = Color.White;
            button4.FlatAppearance.BorderSize = 0;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.Blue;
            button5.ForeColor = Color.White;
            button5.FlatAppearance.BorderSize = 0;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.MidnightBlue;
            button5.ForeColor = Color.White;
            button5.FlatAppearance.BorderSize = 0;
        }

        private void btnUpdate_MouseEnter(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.MidnightBlue;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.FlatAppearance.BorderSize = 0;
        }

        private void btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.Gainsboro;
            btnUpdate.ForeColor = Color.Black;
            btnUpdate.FlatAppearance.BorderSize = 0;
        }

        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.Green;
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatAppearance.BorderSize = 0;
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.Gainsboro;
            btnAdd.ForeColor = Color.Black;
            btnAdd.FlatAppearance.BorderSize = 0;
        }

        private void btnDelete_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.Red;
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatAppearance.BorderSize = 0;
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.Gainsboro;
            btnDelete.ForeColor = Color.Black;
            btnDelete.FlatAppearance.BorderSize = 0;
        }

        public Point mouseLocation;

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string NowDate;
        string NowTime;

        private void FutureCustomerNotes_Load(object sender, EventArgs e)
        {
            btnAdd.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnAdd.Width, btnAdd.Height, 2, 2));
            btnUpdate.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnUpdate.Width, btnUpdate.Height, 2, 2));
            btnDelete.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnDelete.Width, btnDelete.Height, 2, 2));
            btnToday.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnToday.Width, btnToday.Height, 2, 2));
            btnAll.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnAll.Width, btnAll.Height, 2, 2));
            dataGridViewFutureCustomer.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dataGridViewFutureCustomer.Width, dataGridViewFutureCustomer.Height, 2, 2));

            btnAll.Enabled = false;

            timer1.Start();
            NowDate = DateTime.Now.ToLongDateString();
            NowTime = DateTime.Now.ToLongTimeString();

            con.Open();
            customerviewgird();
            con.Close();
        }

        private void customerviewgird()
        {
            SqlCommand cmd3 = new SqlCommand("Select * from FuturecustomerTB order by 1 asc", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd3);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewFutureCustomer.DataSource = dt;
        }

        string text;

        private void maxidcount()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM FuturecustomerTB WHERE ID = (SELECT MAX(ID) FROM FuturecustomerTB) ", con);
            int max = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            max++;
            text = Convert.ToString(max);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtAddress.Text == "" || txtMobileNo.Text == "" || txtNICNo.Text == "")
            {
                MessageBox.Show("Please Enter The Values!");
                return;
            }
            else
            {
                if (txtNICNo.Text.Length < 12)
                {

                    maxidcount();
                    con.Open();
                    try
                    {
                        string values = txtNICNo.Text;
                        int result = 0;
                        if (int.TryParse(values, out result))
                        {
                            txtNICNo.Text = values + "v";
                        }

                        SqlCommand cmd5 = new SqlCommand("insert into FuturecustomerTB values (@ID,@CheckInDate,@CheckOutDate,@Name,@Address,@Mobile,@NIC,@NowDate,@NowTime)", con);
                        cmd5.Parameters.AddWithValue("@ID", int.Parse(text));
                        cmd5.Parameters.AddWithValue("@CheckInDate", DateTime.Parse(dtpCheckInDate.Text));
                        cmd5.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtpCheckOutDate.Text));
                        cmd5.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd5.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd5.Parameters.AddWithValue("@Mobile", txtMobileNo.Text);
                        cmd5.Parameters.AddWithValue("@NIC", txtNICNo.Text);
                        cmd5.Parameters.AddWithValue("@NowDate", DateTime.Parse(NowDate));
                        cmd5.Parameters.AddWithValue("@NowTime", DateTime.Parse(NowTime));
                        cmd5.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Successfull!");

                        


                        customerviewgird();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Invalied Details!");
                    }
                    finally
                    {
                        con.Close();
                    }
                }
               
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtAddress.Text == "" || txtMobileNo.Text == "" || txtNICNo.Text == "")
            {
                MessageBox.Show("Please Enter The Values!");
                return;
            }
            else
            {
                try
                {
                    string values = txtNICNo.Text;
                    int result = 0;
                    if (int.TryParse(values, out result))
                    {
                        txtNICNo.Text = values + "v";
                    }

                    con.Open();
                    SqlCommand cmd5 = new SqlCommand("Update FuturecustomerTB set CheckInDate= @CheckInDate,CheckOutDate= @CheckOutDate,Name= @Name,Address= @Address,Mobile= @Mobile,NIC= @NIC,NowDate= @NowDate,NowTime= @NowTime WHERE ID= @ID", con);
                    cmd5.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
                    cmd5.Parameters.AddWithValue("@CheckInDate", DateTime.Parse(dtpCheckInDate.Text));
                    cmd5.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtpCheckOutDate.Text));
                    cmd5.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd5.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd5.Parameters.AddWithValue("@Mobile", txtMobileNo.Text);
                    cmd5.Parameters.AddWithValue("@NIC", txtNICNo.Text);
                    cmd5.Parameters.AddWithValue("@NowDate", DateTime.Parse(NowDate));
                    cmd5.Parameters.AddWithValue("@NowTime", DateTime.Parse(NowTime));
                    cmd5.ExecuteNonQuery();
                    MessageBox.Show("Successfull Upate!");

                    

                    customerviewgird();

                }
                catch (Exception)
                {
                    MessageBox.Show("Invalied Details!");
                }
                finally
                {
                    con.Close();
                }
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Please enter the ID!");
                return;
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete FuturecustomerTB where ID= @ID", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted!");


                customerviewgird();

                con.Close();
            }
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            btnAll.Enabled = true;
            clickColorToday();
            con.Open();
            SqlCommand cmd3 = new SqlCommand("Select * from FuturecustomerTB where CheckInDate = '" + DateTime.Parse(NowDate)+ "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd3);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewFutureCustomer.DataSource = dt;
            con.Close();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            btnAll.Enabled = false;
            clickColorToday();
            con.Open();
            customerviewgird();
            con.Close();
        }

        private void clickColorToday()
        {
            if (btnAll.Enabled == true)
            {
                btnToday.BackColor = Color.Goldenrod;
                btnToday.ForeColor = Color.White;
                btnToday.FlatAppearance.BorderSize = 0;
            }
            else if (btnAll.Enabled == false)
            {
                btnToday.BackColor = Color.Gainsboro;
                btnToday.ForeColor = Color.Black;
                btnToday.FlatAppearance.BorderSize = 0;
            }
        }

        private void btnAll_MouseEnter(object sender, EventArgs e)
        {
            btnAll.BackColor = Color.Green;
            btnAll.ForeColor = Color.White;
            btnAll.FlatAppearance.BorderSize = 0;
        }

        private void btnAll_MouseLeave(object sender, EventArgs e)
        {
            btnAll.BackColor = Color.Gainsboro;
            btnAll.ForeColor = Color.Black;
            btnAll.FlatAppearance.BorderSize = 0;
        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            string SearchQuarry = "select * from FuturecustomerTB where CONCAT(NowDate,NIC,Name,Mobile) LIKE '%" + txtCustomerSearch.Text + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(SearchQuarry, con);
            DataTable ta = new DataTable();
            adapter.Fill(ta);
            dataGridViewFutureCustomer.DataSource = ta;
            con.Close();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from FuturecustomerTB where ID ='" + int.Parse(txtID.Text) + "'", con);
                SqlDataReader srd = cmd.ExecuteReader();
                while (srd.Read())
                {
                    txtName.Text = srd.GetValue(3).ToString();
                    txtAddress.Text = srd.GetValue(4).ToString();
                    txtMobileNo.Text = srd.GetValue(5).ToString();
                    txtNICNo.Text = srd.GetValue(6).ToString();
                    dtpCheckInDate.Text = srd.GetValue(1).ToString();
                    dtpCheckOutDate.Text = srd.GetValue(2).ToString();
                }
                con.Close();
            }
            catch (Exception)
            {
                return;
            }
            finally
            {
                con.Close();
            }
        }

        private void txtMobileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNICNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
