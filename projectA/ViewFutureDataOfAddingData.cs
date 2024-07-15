using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace projectA
{
    public partial class ViewFutureDataOfAddingData : UserControl
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

        public static ViewFutureDataOfAddingData instanceses;
        public Label dateID;
        public Label dateofview;
        public Label timeofview;
        public Label dayofbookings;
        public Label dayofprofit;
        public Label monthofbookings;
        public Label monthofprofit;

        public ViewFutureDataOfAddingData()
        {
            InitializeComponent();
            instanceses = this;
            dateID = lblBackUpId;
            dateofview = UCDateofviewdata;
            timeofview = UCtimeofviewdata;
            dayofbookings = UCofviewdatadaybookings;
            dayofprofit = UCofviewdatadayProfits;
            monthofbookings = UCofviewdataMonthBookings;
            monthofprofit = UCofviewdataMonthProfit;
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

        private void ViewFutureDataOfAddingData_Load(object sender, EventArgs e)
        {
            cornerradious();
        }

        private void cornerradious()
        {
            label1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label1.Width, label1.Height, 2, 2));
            label6.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label6.Width, label6.Height, 2, 2));
            btnOk.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnOk.Width, btnOk.Height, 2, 2));
            btnDelete.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnDelete.Width, btnDelete.Height, 2, 2));
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int idnum = Convert.ToInt32(lblBackUpId.Text);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete BackUpTB where ID= @ID", con);
            cmd.Parameters.AddWithValue("@ID", idnum);
            cmd.ExecuteNonQuery();
            con.Close();

            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from BackUpTB", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            View.instance.gridviewSummery.DataSource = dt;
            con.Close();

            View.instance.identer.Clear();

            this.Hide();
        }

        private void btnOk_MouseEnter(object sender, EventArgs e)
        {
            btnOk.BackColor = Color.Green;
            btnOk.ForeColor = Color.White;
            btnOk.FlatAppearance.BorderSize = 0;
        }

        private void btnOk_MouseLeave(object sender, EventArgs e)
        {
            btnOk.BackColor = Color.Gainsboro;
            btnOk.ForeColor = Color.Black;
            btnOk.FlatAppearance.BorderSize = 0;
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
    }
}
