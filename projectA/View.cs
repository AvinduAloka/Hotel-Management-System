using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectA
{
    public partial class View : Form
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

        public static View instance;
        public Label lblProfile;
        public Label minimizedLable;
        public Label maximizeLable;
        public Button addButton;
        public Button AdvanceSettings;
        public Label minimizedLable1;
        public Label maximizeLable1;
        public Label texter1;
        public Label texter2;
        public TextBox identer;
        public DataGridView gridviewSummery;
        public Label accountsettingslable;
        public Button accountSettingsUserButton;
        public GroupBox grb1;
        public GroupBox grb2;
        public Button b1 ;
        public Button b2;
        public Button b3;
        public GroupBox grbDashPayment1;
        //Print Invoice As Pdf

        /*Bitmap MemoryImage;
        private PrintDocument printDocument1 = new PrintDocument();
        private PrintPreviewDialog previewdlg = new PrintPreviewDialog();*/
        //Print Invoice As Pdf


        public View()
        {
            
            InitializeComponent();
            instance = this;
            lblProfile = lblDashProfile;
            minimizedLable = lblDashOptionUser;
            maximizeLable = lblDashBtns;
            addButton = btnDashSummery;
            AdvanceSettings = btnSettings;
            minimizedLable1 = lblDashAboutLable;
            maximizeLable1 = lblDashAdvanceLableco;
            texter1 = lblDashAbout;
            texter2 = lblDashAdvancetext;
            identer = txtsummeryIDenter;
            gridviewSummery = dataGridViewSavingsummeryview;
            accountsettingslable = lblAccountSettingsIdentity;
            accountSettingsUserButton = btnUserChnage;
            grb1 = grbBookingPayInvoice1;
            grb2 = grbDashPayment;
            b1 = btnBookingPaySubmit;
            b2 = btnBookingUpdate;
            b3 = btnBookingPayClear;
            grbDashPayment1 = grbDashPayment;
            //Print Invoice As Pdf
            //printDocument1.PrintPage += new PrintPageEventHandler(printdoc1_PrintPage);
            //Print Invoice As Pdf


            deleteByDateData();
            getitemsbydate();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 6, 6));
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-6S94ROH;Initial Catalog=HotelDB;Integrated Security=True");

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-6S94ROH;Initial Catalog=LogInDB;Integrated Security=True");

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

        //Print Invoice As Pdf

        /*public void GetPrintArea(Panel pnl)
        {
            MemoryImage = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(MemoryImage, new Rectangle(0,0, pnl.Width, pnl.Height));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (MemoryImage != null)
            {
                e.Graphics.DrawImage(MemoryImage, 0, 0);
                base.OnPaint(e);
            }
        }

        void printdoc1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(MemoryImage, (pagearea.Width / 2) - (this.pnlInvoice.Width / 2), this.pnlInvoice.Location.Y);
        }

        public void Print(Panel pnl)
        {
            Panel pannel = pnl;
            GetPrintArea(pnl);
            previewdlg.Document = printDocument1;
            previewdlg.ShowDialog();
        }*/

        //Delete Old Date Files

        private void deleteByDateData()
        {
            con.Open();
            SqlCommand cmd2 = new SqlCommand("DELETE FROM PaymentDetailsMTB WHERE NowDate < GETDATE() - 60", con);
            cmd2.ExecuteNonQuery();

            SqlCommand cmd = new SqlCommand("DELETE FROM CustomerMTB WHERE NowDate < GETDATE() - 60", con);
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand("DELETE FROM RoomsMRTB WHERE NowDate < GETDATE() - 60", con);
            cmd1.ExecuteNonQuery();

            con.Close();
        }

        private void View_Load(object sender, EventArgs e)
        {
            coveBorders();
            LoadedVisible();

            checkValueIDcompany();
            uploadBtnVisible();
            companyValuesShowAlways();
            Summeryourinfo();

            loadCIdcounting();
            loadRoomNo();
        }

        //Cover All Buttons and Others

        private void coveBorders()
        {
            btnSettingsAdd.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSettingsAdd.Width, btnSettingsAdd.Height, 2, 2));
            btnSettingsUpdate.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSettingsUpdate.Width, btnSettingsUpdate.Height, 2, 2));
            btnSettingsDelete.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSettingsDelete.Width, btnSettingsDelete.Height, 2, 2));
            btnRooms.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnRooms.Width, btnRooms.Height, 2, 2));
            btnSettingsOption.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSettingsOption.Width, btnSettingsOption.Height, 2, 2));
            btnSettingsCompanySettings.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSettingsCompanySettings.Width, btnSettingsCompanySettings.Height, 2, 2));
            btnLogInSecurity.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnLogInSecurity.Width, btnLogInSecurity.Height, 2, 2));
            btnRoomCheck.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnRoomCheck.Width, btnRoomCheck.Height, 2, 2));
            btnDashBookingInvoices.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnDashBookingInvoices.Width, btnDashBookingInvoices.Height, 2, 12));
            btnBooking.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnBooking.Width, btnBooking.Height, 2, 2));
            btnHistory.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnHistory.Width, btnHistory.Height, 2, 2));
            btnCustomer.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnCustomer.Width, btnCustomer.Height, 2, 2));
            btnRooms.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnRooms.Width, btnRooms.Height, 2, 2));
            btnSettings.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSettings.Width, btnSettings.Height, 2, 2));
            btnAbout.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnAbout.Width, btnAbout.Height, 2, 2));
            btnLoginAccountsettings.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnLoginAccountsettings.Width, btnLoginAccountsettings.Height, 2, 2));
            lblDashBtns.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, lblDashBtns.Width, lblDashBtns.Height, 2, 2));
            lblRootPage1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, lblRootPage1.Width, lblRootPage1.Height, 15, 15));
            lblRootPage2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, lblRootPage2.Width, lblRootPage2.Height, 15, 15));
            lblBookingDash.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, lblBookingDash.Width, lblBookingDash.Height, 2, 2));
            btnBookingPayInvoices.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnBookingPayInvoices.Width, btnBookingPayInvoices.Height, 2, 2));
            btnBookingNext.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnBookingNext.Width, btnBookingNext.Height, 2, 2));
            btnBookingUpdate.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnBookingUpdate.Width, btnBookingUpdate.Height, 2, 2));
            btnBookingClear.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnBookingClear.Width, btnBookingClear.Height, 2, 2));
            lblDashProfile.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, lblDashProfile.Width, lblDashProfile.Height, 2, 2));
            lblDashOptionUser.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, lblDashOptionUser.Width, lblDashOptionUser.Height, 2, 2));
            btnDashSummery.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnDashSummery.Width, btnDashSummery.Height, 2, 2));
            btnDashSettingCompanySave.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnDashSettingCompanySave.Width, btnDashSettingCompanySave.Height, 2, 2));
            btnBookingPaySubmit.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnBookingPaySubmit.Width, btnBookingPaySubmit.Height, 2, 2));
            btnDashSettingCompanyClear.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnDashSettingCompanyClear.Width, btnDashSettingCompanyClear.Height, 2, 2));
            btnBookingPayClear.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnBookingPayClear.Width, btnBookingPayClear.Height, 2, 2));
            btnBack.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnBack.Width, btnBack.Height, 2, 2));
            btnAccountSettingsEdit.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnAccountSettingsEdit.Width, btnAccountSettingsEdit.Height, 2, 2));
            lblaccountSettings1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, lblaccountSettings1.Width, lblaccountSettings1.Height, 2, 2));
            btnAccountSettingsSave.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnAccountSettingsSave.Width, btnAccountSettingsSave.Height, 2, 2));
            btnDashSettingCompanyUpload.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnDashSettingCompanyUpload.Width, btnDashSettingCompanyUpload.Height, 2, 2));
            btnPayInvoiceCancel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnPayInvoiceCancel.Width, btnPayInvoiceCancel.Height, 2, 2));
            btnPayInvoiceSubmit.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnPayInvoiceSubmit.Width, btnPayInvoiceSubmit.Height, 2, 2));
            btnPayInvoicePrint.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnPayInvoicePrint.Width, btnPayInvoicePrint.Height, 2, 2));
            lblDashAdvanceLableco.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, lblDashAdvanceLableco.Width, lblDashAdvanceLableco.Height, 2, 2));
            lblDashAboutLable.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, lblDashAboutLable.Width, lblDashAboutLable.Height, 2, 2));
            btnBookingDelete.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnBookingDelete.Width, btnBookingDelete.Height, 2, 2));
            btnSettingsClear.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSettingsClear.Width, btnSettingsClear.Height, 2, 2));
            lblDashAboutUse.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, lblDashAboutUse.Width, lblDashAboutUse.Height, 2, 2));
            lblDashAboutUse1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, lblDashAboutUse1.Width, lblDashAboutUse1.Height, 2, 2));
            lblSummeryControl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, lblSummeryControl.Width, lblSummeryControl.Height, 2, 2));
            btnBackupsummery.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnBackupsummery.Width, btnBackupsummery.Height, 2, 2));
            SummeryDashTodayBackground1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SummeryDashTodayBackground1.Width, SummeryDashTodayBackground1.Height, 2, 2));
            SummeryDashTodayBackground2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SummeryDashTodayBackground2.Width, SummeryDashTodayBackground2.Height, 2, 2));
            SummeryDashTodayBackground3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SummeryDashTodayBackground3.Width, SummeryDashTodayBackground3.Height, 2, 2));
            SummeryDashTodayBackground.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, SummeryDashTodayBackground.Width, SummeryDashTodayBackground.Height, 2, 2));
            lblDashSumerybackgroundui1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, lblDashSumerybackgroundui1.Width, lblDashSumerybackgroundui1.Height, 2, 2));
            btnViewofSummery.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnViewofSummery.Width, btnViewofSummery.Height, 2, 2));
            btnBackOfSummery.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnBackOfSummery.Width, btnBackOfSummery.Height, 2, 2));
            btnUse.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnUse.Width, btnUse.Height, 2, 2));
            btnContact.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnContact.Width, btnContact.Height, 2, 2));
            lblAccountSettingsIdentity.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, lblAccountSettingsIdentity.Width, lblAccountSettingsIdentity.Height, 2, 2));
            btnUserChnage.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnUserChnage.Width, btnUserChnage.Height, 2, 2));
        }

        //Drag Application

        public Point mouseLocation;

        private void lblTophandleapp_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void lblTophandleapp_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        //Navigation Button

        private void btnFullexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void getitemsbydate()
        {
            con.Open();

            SqlCommand cmd1 = new SqlCommand("DELETE FROM RoomsRTB WHERE CheckOutDate = '" + DateTime.Parse(DateTime.Now.ToShortDateString()) + "' ", con);
            cmd1.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand("DELETE FROM CustomerTB WHERE CheckOutDate = '" + DateTime.Parse(DateTime.Now.ToShortDateString()) + "' ", con);
            cmd2.ExecuteNonQuery();

            SqlCommand cmd3 = new SqlCommand("DELETE FROM PaymentDetailsTB WHERE CheckOutDate = '" + DateTime.Parse(DateTime.Now.ToShortDateString()) + "' ", con);
            cmd3.ExecuteNonQuery();

            con.Close();
        }



        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnFullexit_MouseEnter(object sender, EventArgs e)
        {
            btnFullexit.BackColor = Color.Red;
            btnFullexit.ForeColor = Color.White;
            btnFullexit.FlatAppearance.BorderSize = 0;
        }

        private void btnFullexit_MouseLeave(object sender, EventArgs e)
        {
            btnFullexit.BackColor = Color.MidnightBlue;
            btnFullexit.ForeColor = Color.DarkGray;
            btnFullexit.FlatAppearance.BorderSize = 0;
        }

        private void btnMinimize_MouseEnter(object sender, EventArgs e)
        {
            btnMinimize.BackColor = Color.Blue;
            btnMinimize.ForeColor = Color.White;
            btnMinimize.FlatAppearance.BorderSize = 0;
        }

        private void btnMinimize_MouseLeave(object sender, EventArgs e)
        {
            btnMinimize.BackColor = Color.MidnightBlue;
            btnMinimize.ForeColor = Color.DarkGray;
            btnMinimize.FlatAppearance.BorderSize = 0;
        }

        //Design

        private void btnbookClickColor()
        {
            if (grbDashBook.Visible == true)
            {
                btnBooking.BackColor = Color.MidnightBlue;
                btnBooking.ForeColor = Color.White;
                btnBooking.FlatAppearance.BorderSize = 0;
            }
            else if (grbDashBook.Visible == true || grbBookingPayInvoice1.Visible == true)
            {
                btnBooking.BackColor = Color.MidnightBlue;
                btnBooking.ForeColor = Color.White;
                btnBooking.FlatAppearance.BorderSize = 0;
            }
            else if (grbDashBook.Visible == false)
            {
                btnBooking.BackColor = Color.Gainsboro;
                btnBooking.ForeColor = Color.Black;
                btnBooking.FlatAppearance.BorderSize = 0;
            }
            else if (grbDashBook.Visible == false || grbBookingPayInvoice1.Visible == false)
            {
                btnBooking.BackColor = Color.Gainsboro;
                btnBooking.ForeColor = Color.Black;
                btnBooking.FlatAppearance.BorderSize = 0;
            }
        }

        private void btncustomerClickColor()
        {
            if (grbDashCustomer.Visible == true)
            {
                btnCustomer.BackColor = Color.MidnightBlue;
                btnCustomer.ForeColor = Color.White;
                btnCustomer.FlatAppearance.BorderSize = 0;
            }
            else if (grbDashCustomer.Visible == false)
            {
                btnCustomer.BackColor = Color.Gainsboro;
                btnCustomer.ForeColor = Color.Black;
                btnCustomer.FlatAppearance.BorderSize = 0;
            }
        }

        private void btnroomsClickColor()
        {
            if (grbDashRooms.Visible == true)
            {
                btnRooms.BackColor = Color.MidnightBlue;
                btnRooms.ForeColor = Color.White;
                btnRooms.FlatAppearance.BorderSize = 0;
            }
            else if (grbDashRooms.Visible == false)
            {
                btnRooms.BackColor = Color.Gainsboro;
                btnRooms.ForeColor = Color.Black;
                btnRooms.FlatAppearance.BorderSize = 0;
            }
        }

        private void btnHistoryClickColor()
        {
            if (grbDashHistory.Visible == true)
            {
                btnHistory.BackColor = Color.MidnightBlue;
                btnHistory.ForeColor = Color.White;
                btnHistory.FlatAppearance.BorderSize = 0;
            }
            else if (grbDashHistory.Visible == false)
            {
                btnHistory.BackColor = Color.Gainsboro;
                btnHistory.ForeColor = Color.Black;
                btnHistory.FlatAppearance.BorderSize = 0;
            }
        }

        private void btnSummeryClickColor()
        {
            if (grbDashSummery.Visible == true)
            {
                btnDashSummery.BackColor = Color.MidnightBlue;
                btnDashSummery.ForeColor = Color.White;
                btnDashSummery.FlatAppearance.BorderSize = 0;
            }
            else if (grbDashSummery.Visible == false)
            {
                btnDashSummery.BackColor = Color.Gainsboro;
                btnDashSummery.ForeColor = Color.Black;
                btnDashSummery.FlatAppearance.BorderSize = 0;
            }
        }

        private void btnSettingsClickColor()
        {
            if (grbRoomsSettings.Visible == true)
            {
                btnSettings.BackColor = Color.MidnightBlue;
                btnSettings.ForeColor = Color.White;
                btnSettings.FlatAppearance.BorderSize = 0;
            }
            else if (grbRoomsSettings.Visible == true || grbLogIn.Visible == true)
            {
                btnSettings.BackColor = Color.MidnightBlue;
                btnSettings.ForeColor = Color.White;
                btnSettings.FlatAppearance.BorderSize = 0;
            }
            else if (grbDashRooms.Visible == false)
            {
                btnSettings.BackColor = Color.Gainsboro;
                btnSettings.ForeColor = Color.Black;
                btnSettings.FlatAppearance.BorderSize = 0;
            }
            else if (grbDashRooms.Visible == false || grbLogIn.Visible == false)
            {
                btnSettings.BackColor = Color.Gainsboro;
                btnSettings.ForeColor = Color.Black;
                btnSettings.FlatAppearance.BorderSize = 0;
            }
        }

        private void btnaboutClickColor()
        {
            if (grbDashAbout.Visible == true)
            {
                btnAbout.BackColor = Color.MidnightBlue;
                btnAbout.ForeColor = Color.White;
                btnAbout.FlatAppearance.BorderSize = 0;
            }
            else if (grbDashAbout.Visible == false)
            {
                btnAbout.BackColor = Color.Gainsboro;
                btnAbout.ForeColor = Color.Black;
                btnAbout.FlatAppearance.BorderSize = 0;
            }
        }


        //Other Buttons Designs

        private void btnBookingPaySubmit_MouseEnter(object sender, EventArgs e)
        {
            btnBookingPaySubmit.BackColor = Color.Green;
            btnBookingPaySubmit.ForeColor = Color.White;
            btnBookingPaySubmit.FlatAppearance.BorderSize = 0;
        }

        private void btnBookingPaySubmit_MouseLeave(object sender, EventArgs e)
        {
            btnBookingPaySubmit.BackColor = Color.Gainsboro;
            btnBookingPaySubmit.ForeColor = Color.Black;
            btnBookingPaySubmit.FlatAppearance.BorderSize = 0;
        }

        private void btnBookingPayClear_MouseEnter(object sender, EventArgs e)
        {
            btnBookingPayClear.BackColor = Color.Black;
            btnBookingPayClear.ForeColor = Color.White;
            btnBookingPayClear.FlatAppearance.BorderSize = 0;
        }

        private void btnBookingPayClear_MouseLeave(object sender, EventArgs e)
        {
            btnBookingPayClear.BackColor = Color.Gainsboro;
            btnBookingPayClear.ForeColor = Color.Black;
            btnBookingPayClear.FlatAppearance.BorderSize = 0;
        }

        private void btnBack_MouseEnter(object sender, EventArgs e)
        {
            btnBack.BackColor = Color.Goldenrod;
            btnBack.ForeColor = Color.White;
            btnBack.FlatAppearance.BorderSize = 0;
        }

        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            btnBack.BackColor = Color.Gainsboro;
            btnBack.ForeColor = Color.Black;
            btnBack.FlatAppearance.BorderSize = 0;
        }




        private void btnBookingNext_MouseEnter(object sender, EventArgs e)
        {
            btnBookingNext.BackColor = Color.Green;
            btnBookingNext.ForeColor = Color.White;
            btnBookingNext.FlatAppearance.BorderSize = 0;
        }

        private void btnBookingNext_MouseLeave(object sender, EventArgs e)
        {
            btnBookingNext.BackColor = Color.Gainsboro;
            btnBookingNext.ForeColor = Color.Black;
            btnBookingNext.FlatAppearance.BorderSize = 0;
        }

        private void btnBookingUpdate_MouseEnter(object sender, EventArgs e)
        {
            btnBookingUpdate.BackColor = Color.MidnightBlue;
            btnBookingUpdate.ForeColor = Color.White;
            btnBookingUpdate.FlatAppearance.BorderSize = 0;
        }

        private void btnBookingUpdate_MouseLeave(object sender, EventArgs e)
        {
            btnBookingUpdate.BackColor = Color.Gainsboro;
            btnBookingUpdate.ForeColor = Color.Black;
            btnBookingUpdate.FlatAppearance.BorderSize = 0;
        }

        private void btnBookingDelete_MouseEnter(object sender, EventArgs e)
        {
            btnBookingDelete.BackColor = Color.Red;
            btnBookingDelete.ForeColor = Color.White;
            btnBookingDelete.FlatAppearance.BorderSize = 0;
        }

        private void btnBookingDelete_MouseLeave(object sender, EventArgs e)
        {
            btnBookingDelete.BackColor = Color.Gainsboro;
            btnBookingDelete.ForeColor = Color.Black;
            btnBookingDelete.FlatAppearance.BorderSize = 0;
        }

        private void btnBookingClear_MouseEnter(object sender, EventArgs e)
        {
            btnBookingClear.BackColor = Color.Black;
            btnBookingClear.ForeColor = Color.White;
            btnBookingClear.FlatAppearance.BorderSize = 0;
        }

        private void btnBookingClear_MouseLeave(object sender, EventArgs e)
        {
            btnBookingClear.BackColor = Color.Gainsboro;
            btnBookingClear.ForeColor = Color.Black;
            btnBookingClear.FlatAppearance.BorderSize = 0;
        }




        private void btnPayInvoiceCancel_MouseEnter(object sender, EventArgs e)
        {
            btnPayInvoiceCancel.BackColor = Color.Red;
            btnPayInvoiceCancel.ForeColor = Color.White;
            btnPayInvoiceCancel.FlatAppearance.BorderSize = 0;
        }

        private void btnPayInvoiceCancel_MouseLeave(object sender, EventArgs e)
        {
            btnPayInvoiceCancel.BackColor = Color.Gainsboro;
            btnPayInvoiceCancel.ForeColor = Color.Black;
            btnPayInvoiceCancel.FlatAppearance.BorderSize = 0;
        }

        private void btnPayInvoiceSubmit_MouseEnter(object sender, EventArgs e)
        {
            btnPayInvoiceSubmit.BackColor = Color.Green;
            btnPayInvoiceSubmit.ForeColor = Color.White;
            btnPayInvoiceSubmit.FlatAppearance.BorderSize = 0;
        }

        private void btnPayInvoiceSubmit_MouseLeave(object sender, EventArgs e)
        {
            btnPayInvoiceSubmit.BackColor = Color.Gainsboro;
            btnPayInvoiceSubmit.ForeColor = Color.Black;
            btnPayInvoiceSubmit.FlatAppearance.BorderSize = 0;
        }

        private void btnPayInvoicePrint_MouseEnter(object sender, EventArgs e)
        {
            btnPayInvoicePrint.BackColor = Color.Black;
            btnPayInvoicePrint.ForeColor = Color.White;
            btnPayInvoicePrint.FlatAppearance.BorderSize = 0;
        }

        private void btnPayInvoicePrint_MouseLeave(object sender, EventArgs e)
        {
            btnPayInvoicePrint.BackColor = Color.Gainsboro;
            btnPayInvoicePrint.ForeColor = Color.Black;
            btnPayInvoicePrint.FlatAppearance.BorderSize = 0;
        }




        private void btnLogInSecurity_MouseEnter(object sender, EventArgs e)
        {
            btnLogInSecurity.BackColor = Color.MidnightBlue;
            btnLogInSecurity.ForeColor = Color.White;
            btnLogInSecurity.FlatAppearance.BorderSize = 0;
        }

        private void btnLogInSecurity_MouseLeave(object sender, EventArgs e)
        {
            btnLogInSecurity.BackColor = Color.Gainsboro;
            btnLogInSecurity.ForeColor = Color.Black;
            btnLogInSecurity.FlatAppearance.BorderSize = 0;
        }

        private void btnSettingsAdd_MouseEnter(object sender, EventArgs e)
        {
            btnSettingsAdd.BackColor = Color.Green;
            btnSettingsAdd.ForeColor = Color.White;
            btnSettingsAdd.FlatAppearance.BorderSize = 0;
        }

        private void btnSettingsAdd_MouseLeave(object sender, EventArgs e)
        {
            btnSettingsAdd.BackColor = Color.Gainsboro;
            btnSettingsAdd.ForeColor = Color.Black;
            btnSettingsAdd.FlatAppearance.BorderSize = 0;
        }

        private void btnSettingsUpdate_MouseEnter(object sender, EventArgs e)
        {
            btnSettingsUpdate.BackColor = Color.MidnightBlue;
            btnSettingsUpdate.ForeColor = Color.White;
            btnSettingsUpdate.FlatAppearance.BorderSize = 0;
        }

        private void btnSettingsUpdate_MouseLeave(object sender, EventArgs e)
        {
            btnSettingsUpdate.BackColor = Color.Gainsboro;
            btnSettingsUpdate.ForeColor = Color.Black;
            btnSettingsUpdate.FlatAppearance.BorderSize = 0;
        }

        private void btnSettingsDelete_MouseEnter(object sender, EventArgs e)
        {
            btnSettingsDelete.BackColor = Color.Red;
            btnSettingsDelete.ForeColor = Color.White;
            btnSettingsDelete.FlatAppearance.BorderSize = 0;
        }

        private void btnSettingsDelete_MouseLeave(object sender, EventArgs e)
        {
            btnSettingsDelete.BackColor = Color.Gainsboro;
            btnSettingsDelete.ForeColor = Color.Black;
            btnSettingsDelete.FlatAppearance.BorderSize = 0;
        }

        private void btnSettingsClear_MouseEnter(object sender, EventArgs e)
        {
            btnSettingsClear.BackColor = Color.Black;
            btnSettingsClear.ForeColor = Color.White;
            btnSettingsClear.FlatAppearance.BorderSize = 0;
        }

        private void btnSettingsClear_MouseLeave(object sender, EventArgs e)
        {
            btnSettingsClear.BackColor = Color.Gainsboro;
            btnSettingsClear.ForeColor = Color.Black;
            btnSettingsClear.FlatAppearance.BorderSize = 0;
        }



        private void btnBackupsummery_MouseEnter(object sender, EventArgs e)
        {
            btnBackupsummery.BackColor = Color.MidnightBlue;
            btnBackupsummery.ForeColor = Color.White;
            btnBackupsummery.FlatAppearance.BorderSize = 0;
        }

        private void btnBackupsummery_MouseLeave(object sender, EventArgs e)
        {
            btnBackupsummery.BackColor = Color.Gainsboro;
            btnBackupsummery.ForeColor = Color.Black;
            btnBackupsummery.FlatAppearance.BorderSize = 0;
        }



        //Design From Company Deatils

        private void btnDashSettingCompanyUpload_MouseEnter(object sender, EventArgs e)
        {
            btnDashSettingCompanyUpload.BackColor = Color.Black;
            btnDashSettingCompanyUpload.ForeColor = Color.White;
            btnDashSettingCompanyUpload.FlatAppearance.BorderSize = 0;
        }

        private void btnDashSettingCompanyUpload_MouseLeave(object sender, EventArgs e)
        {
            btnDashSettingCompanyUpload.BackColor = Color.Gainsboro;
            btnDashSettingCompanyUpload.ForeColor = Color.Black;
            btnDashSettingCompanyUpload.FlatAppearance.BorderSize = 0;
        }

        private void btnDashSettingCompanyClear_MouseEnter(object sender, EventArgs e)
        {
            btnDashSettingCompanyClear.BackColor = Color.Red;
            btnDashSettingCompanyClear.ForeColor = Color.White;
            btnDashSettingCompanyClear.FlatAppearance.BorderSize = 0;
        }

        private void btnDashSettingCompanyClear_MouseLeave(object sender, EventArgs e)
        {
            btnDashSettingCompanyClear.BackColor = Color.Gainsboro;
            btnDashSettingCompanyClear.ForeColor = Color.Black;
            btnDashSettingCompanyClear.FlatAppearance.BorderSize = 0;
        }

        private void btnDashSettingCompanySave_MouseEnter(object sender, EventArgs e)
        {
            btnDashSettingCompanySave.BackColor = Color.Green;
            btnDashSettingCompanySave.ForeColor = Color.White;
            btnDashSettingCompanySave.FlatAppearance.BorderSize = 0;
        }

        private void btnDashSettingCompanySave_MouseLeave(object sender, EventArgs e)
        {
            btnDashSettingCompanySave.BackColor = Color.Gainsboro;
            btnDashSettingCompanySave.ForeColor = Color.Black;
            btnDashSettingCompanySave.FlatAppearance.BorderSize = 0;
            
        }



        private void btnRoomCheck_MouseEnter(object sender, EventArgs e)
        {
            btnSettingsClear.BackColor = Color.MidnightBlue;
            btnSettingsClear.ForeColor = Color.White;
            btnSettingsClear.FlatAppearance.BorderSize = 0;
        }

        private void btnRoomCheck_MouseLeave(object sender, EventArgs e)
        {
            btnSettingsClear.BackColor = Color.Gainsboro;
            btnSettingsClear.ForeColor = Color.Black;
            btnSettingsClear.FlatAppearance.BorderSize = 0;
        }



        private void btnBackOfSummery_MouseEnter(object sender, EventArgs e)
        {
            btnBackOfSummery.BackColor = Color.Goldenrod;
            btnBackOfSummery.ForeColor = Color.White;
            btnBackOfSummery.FlatAppearance.BorderSize = 0;
        }

        private void btnBackOfSummery_MouseLeave(object sender, EventArgs e)
        {
            btnBackOfSummery.BackColor = Color.Gainsboro;
            btnBackOfSummery.ForeColor = Color.Black;
            btnBackOfSummery.FlatAppearance.BorderSize = 0;
        }

        private void btnViewofSummery_MouseEnter(object sender, EventArgs e)
        {
            btnViewofSummery.BackColor = Color.Green;
            btnViewofSummery.ForeColor = Color.White;
            btnViewofSummery.FlatAppearance.BorderSize = 0;
        }

        private void btnViewofSummery_MouseLeave(object sender, EventArgs e)
        {
            btnViewofSummery.BackColor = Color.Gainsboro;
            btnViewofSummery.ForeColor = Color.Black;
            btnViewofSummery.FlatAppearance.BorderSize = 0;
        }




        //Hide Another GroupBoxs

        private void BookingVisible()
        {
            grbDashBook.Visible = true;
            grbRoomsSettings.Visible = false;
            grbLogIn.Visible = false;
            grbDashCustomer.Visible = false;
            grbDashPayment.Visible = false;
            grbDashRooms.Visible = false;
            grbDashReload.Visible = false;
            grbDashAbout.Visible = false;
            grbDashSummery.Visible = false;
            grbDashHistory.Visible = false;
            viewFutureDataOfAddingData1.Visible = false;
            grbSummeryViewer.Visible = false;
            lblEmailErrorProvider.Visible = false;
            btnBookingPaySubmit.Enabled = true;
            grbAccountSettings.Visible = false;
            grbLoginAccountSettings.Visible = false;

            btnBookingPayInvoices.BackColor = Color.Gainsboro;
            btnBookingPayInvoices.ForeColor = Color.Black;
            btnBookingPayInvoices.FlatAppearance.BorderSize = 0;

            loadRoomNo();

            con.Open();
            SqlCommand cmd3 = new SqlCommand("Select RoomsTB.RoomNo, RoomsTB.RoomName, RoomsTB.RoomType, RoomsTB.RoomPrice from RoomsTB order by 1 asc", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd3);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewRooms.DataSource = dt;


            con.Close();
        }

        private void HistoryVisible()
        {
            grbDashBook.Visible = false;
            grbRoomsSettings.Visible = false;
            grbLogIn.Visible = false;
            grbDashCustomer.Visible = false;
            grbDashPayment.Visible = false;
            grbDashRooms.Visible = false;
            grbDashReload.Visible = false;
            grbDashAbout.Visible = false;
            grbDashSummery.Visible = false;
            viewFutureDataOfAddingData1.Visible = false;
            grbDashHistory.Visible = true;
            grbSummeryViewer.Visible = false;
            grbAccountSettings.Visible = false;
            grbLoginAccountSettings.Visible = false;

            historygirdviews();
        }

        private void historygirdviews()
        {
            con.Open();
            SqlCommand cmd3 = new SqlCommand("Select * from CustomerMTB", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd3);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewHistoryCustomer.DataSource = dt;
            con.Close();

            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from RoomsMRTB", con);
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            db.Fill(ds);
            dataGridViewHistoryRoomsBooking.DataSource = ds;
            con.Close();

            con.Open();
            SqlCommand cmd2 = new SqlCommand("Select * from PaymentDetailsMTB", con);
            SqlDataAdapter dd = new SqlDataAdapter(cmd2);
            DataTable du = new DataTable();
            dd.Fill(du);
            dataGridViewHistoryInvoices.DataSource = du;
            con.Close();
        }

        private void CustomerVisible()
        {
            grbDashBook.Visible = false;
            grbRoomsSettings.Visible = false;
            grbLogIn.Visible = false;
            grbDashCustomer.Visible = true;
            grbDashPayment.Visible = false;
            grbDashRooms.Visible = false;
            grbDashReload.Visible = false;
            grbDashAbout.Visible = false;
            grbDashSummery.Visible = false;
            grbDashHistory.Visible = false;
            viewFutureDataOfAddingData1.Visible = false;
            grbSummeryViewer.Visible = false;
            grbAccountSettings.Visible = false;
            grbLoginAccountSettings.Visible = false;

            CustomerGirdView();
        }

        private void CustomerGirdView()
        {
            con.Open();
            SqlCommand cmd3 = new SqlCommand("Select * from CustomerTB", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd3);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewCustomer.DataSource = dt;
            con.Close();
        }

        private void RoomsVisible()
        {
            grbDashBook.Visible = false;
            grbRoomsSettings.Visible = false;
            grbLogIn.Visible = false;
            grbDashCustomer.Visible = false;
            grbDashPayment.Visible = false;
            grbDashRooms.Visible = true;
            grbDashReload.Visible = false;
            grbDashAbout.Visible = false;
            grbDashSummery.Visible = false;
            grbDashHistory.Visible = false;
            viewFutureDataOfAddingData1.Visible = false;
            grbSummeryViewer.Visible = false;
            grbAccountSettings.Visible = false;
            grbLoginAccountSettings.Visible = false;

            con.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT RoomNo, RoomName, RoomType, RoomPrice FROM RoomsTB AS A WHERE NOT EXISTS(SELECT RoomNo, RoomName, RoomType, RoomPrice FROM RoomsRTB AS B WHERE A.RoomNo = B.RoomNo) order by 1 asc", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd2;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewRooms2Log.DataSource = dt;
            dataGridViewRooms2Log.Columns[1].HeaderText = "Room No.";

            SqlCommand cmd = new SqlCommand("Select RoomsTB.RoomNo, RoomsTB.RoomName, RoomsTB.RoomType, RoomsTB.RoomPrice from RoomsTB order by 1 asc", con);
            SqlDataAdapter dc = new SqlDataAdapter(cmd);
            DataTable du = new DataTable();
            dc.Fill(du);
            dataGridViewRooms1Log.DataSource = du;
            con.Close();
        }

        private void SettingsVisible()
        {
            grbDashBook.Visible = false;
            grbRoomsSettings.Visible = false;
            grbLogIn.Visible = true;
            grbDashCustomer.Visible = false;
            grbDashPayment.Visible = false;
            grbDashReload.Visible = false;
            grbDashRooms.Visible = false;
            grbDashAbout.Visible = false;
            grbDashSummery.Visible = false;
            grbDashHistory.Visible = false;
            viewFutureDataOfAddingData1.Visible = false;
            grbSummeryViewer.Visible = false;
            grbAccountSettings.Visible = false;
            grbLoginAccountSettings.Visible = false;

            lblLoginchangeble.Text = "Log In";

        }

        private void AboutVisible()
        {
            grbDashBook.Visible = false;
            grbRoomsSettings.Visible = false;
            grbLogIn.Visible = false;
            grbDashCustomer.Visible = false;
            grbDashPayment.Visible = false;
            grbDashRooms.Visible = false;
            grbDashReload.Visible = false;
            grbDashAbout.Visible = true;
            grbDashSummery.Visible = false;
            grbDashHistory.Visible = false;
            viewFutureDataOfAddingData1.Visible = false;
            grbSummeryViewer.Visible = false;
            grbAccountSettings.Visible = false;
            grbLoginAccountSettings.Visible = false;

            lblDashAboutUse1.Visible = true;
            lblDashAboutUse.Visible = true;
            lblHowtouse.Visible = true;
            pictureBContact.Visible = false;
            pictureBox2.Visible = false;
            label99.Visible = false;
            label101.Visible = false;

            btnUse.BackColor = Color.Goldenrod;
            btnUse.ForeColor = Color.White;
            btnUse.FlatAppearance.BorderSize = 0;

            btnContact.BackColor = Color.Gainsboro;
            btnContact.ForeColor = Color.Black;
            btnContact.FlatAppearance.BorderSize = 0;

        }

        private void LoadedVisible()
        {
            grbDashBook.Visible = false;
            grbRoomsSettings.Visible = false;
            grbLogIn.Visible = false;
            grbDashCustomer.Visible = false;
            grbDashPayment.Visible = false;
            grbDashRooms.Visible = false;
            grbDashReload.Visible = true;
            grbDashAbout.Visible = false;
            grbBookingInvoices.Visible = false;
            grbDashSummery.Visible = false;
            grbDashHistory.Visible = false;
            grbSummeryViewer.Visible = false;
            grbAccountSettings.Visible = false;
            grbLoginAccountSettings.Visible = false;
            invoicePrint1.Visible = false;

            viewFutureDataOfAddingData1.Visible = false;
            grbBookingPayInvoice1.Visible = false;

            lblEmailErrorProvider.Visible = false;

            txtPassword.UseSystemPasswordChar = true;
            txtEmailPasswordGenerated.UseSystemPasswordChar = true;

            cmbCustomerRoNo.Text = "";

            timer1.Start();
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();

            con.Open();
            SqlCommand cmd3 = new SqlCommand("Select RoomsTB.RoomNo, RoomsTB.RoomName, RoomsTB.RoomType, RoomsTB.RoomPrice from RoomsTB order by 1 asc", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd3);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewRooms.DataSource = dt;
            con.Close();
        }

        private void summeryVisible()
        {
            grbDashBook.Visible = false;
            grbRoomsSettings.Visible = false;
            grbLogIn.Visible = false;
            grbDashCustomer.Visible = false;
            grbDashPayment.Visible = false;
            grbDashRooms.Visible = false;
            grbDashReload.Visible = true;
            grbDashAbout.Visible = false;
            grbBookingInvoices.Visible = false;
            grbDashSummery.Visible = true;
            grbDashHistory.Visible = false;
            viewFutureDataOfAddingData1.Visible = false;
            grbSummeryViewer.Visible = false;
            grbAccountSettings.Visible = false;
            grbLoginAccountSettings.Visible = false;

            counttotroomswhereadded();
            counttotroomswherenonBookedadded();
            counttotroomswhereBookedaddedsUM();
            lastmonthsrecords();
            counttotofbookings();
            monrthlyprofitcount();
            counttotroomswhereBookedadded();
            companyValuesShowAlways();
            Summeryourinfo();
        }

        //Building Information
        private void BuidersDeatails()
        {
            lblContcatName.Text = "Avindu";
            lblContcatMobile.Text = "0781408518";
            lblContcatEmail.Text = "20avindualoka@gmail.com";
            lblContcatWhatsApp.Text = "0781408518";
        }

        private void hideing()
        {
            lblContctusme.Visible = false;
            lblNameofcontct.Visible = false;
            lblMobileOfcontcat.Visible = false;
            lblEmailofconact.Visible = false;
            lblwhatsappofcaontact.Visible = false;
            lblContcatName.Visible = false;
            lblContcatMobile.Visible = false;
            lblContcatEmail.Visible = false;
            lblContcatWhatsApp.Visible = false;
            lblParaContact.Visible = false;
            lblParaContact1.Visible = false;
            lblParaContact2.Visible = false;
            lblParaContact3.Visible = false;
            lblParaContact4.Visible = false;
            lblProductby.Visible = false;
            pcbimagecontcat.Visible = false;
        }

        private void hideing1()
        {
            BuidersDeatails();
            lblContctusme.Visible = true;
            lblNameofcontct.Visible = true;
            lblMobileOfcontcat.Visible = true;
            lblEmailofconact.Visible = true;
            lblwhatsappofcaontact.Visible = true;
            lblContcatName.Visible = true;
            lblContcatMobile.Visible = true;
            lblContcatEmail.Visible = true;
            lblContcatWhatsApp.Visible = true;
            lblParaContact.Visible = true;
            lblParaContact1.Visible = true;
            lblParaContact2.Visible = true;
            lblParaContact3.Visible = true;
            lblParaContact4.Visible = true;
            lblProductby.Visible = true;
            pcbimagecontcat.Visible = true;
        }

        //Summery Rooms Show

        double zero = 0;

        int i;

        private void counttotroomswhereadded()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(RoomNo) FROM RoomsTB ", con);
            i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            lblTotRooms.Text = zero + Convert.ToString(i);
        }

        private void counttotroomswherenonBookedadded()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(RoomNo) FROM RoomsTB AS A WHERE NOT EXISTS(SELECT RoomNo, RoomName, RoomType, RoomPrice FROM RoomsRTB AS B WHERE A.RoomNo = B.RoomNo) order by 1 asc", con);
            double x = Convert.ToDouble(cmd.ExecuteScalar());
            con.Close();
            double res = i - x;
            lblBookedRooms.Text = zero + Convert.ToString(res);
            lblSummeryEmptyRooms.Text = zero + Convert.ToString(x);
        }

        private void counttotroomswhereBookedadded()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT COUNT(*) OVER (PARTITION BY NowDate) FROM CustomerTB where NowDate = '" + DateTime.Parse(lblDate.Text) + "'", con);
            double p = Convert.ToDouble(cmd.ExecuteScalar());
            con.Close();
            lblSummeryTodayCustomers.Text = zero + Convert.ToString(p);
        }

        private void counttotroomswhereBookedaddedsUM()
        {
            string rupee = "Rs. ";
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT SUM(TotPrice) OVER (PARTITION BY NowDate) FROM CustomerTB where NowDate = '" + DateTime.Parse(lblDate.Text) + "'", con);
            double p = Convert.ToDouble(cmd.ExecuteScalar());
            con.Close();
            lblTodaytotSum.Text = rupee + Convert.ToString(p);
        }

        private void lastmonthsrecords()
        {
            //SqlConnection connn = new SqlConnection("Data Source=DESKTOP-6S94ROH;Initial Catalog=table1;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select YEAR(NowDate) AS Year, MONTH(NowDate) AS Month, SUM(TotalAmount) AS Calls from PaymentDetailsMTB group by YEAR(NowDate), MONTH(NowDate) order by YEAR(NowDate), MONTH(NowDate)", con);
            SqlDataAdapter dc = new SqlDataAdapter(cmd);
            DataTable du = new DataTable();
            dc.Fill(du);
            dataGridViewlastmontsrecords.DataSource = du;
            con.Close();
        }

        private void monrthlyprofitcount()
        {
            //string rupee = "Rs. ";
            //SqlConnection connn = new SqlConnection("Data Source=DESKTOP-6S94ROH;Initial Catalog=table1;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select TOP 1 sum(TotalAmount) from PaymentDetailsMTB group by month(NowDate) ORDER BY month(NowDate) DESC", con);
            double p = Convert.ToDouble(cmd.ExecuteScalar());
            con.Close();
            lblSummerymonthprofit.Text = Convert.ToString(p);
        }

        private void counttotofbookings()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select top 1 count(NIC) from CustomerMTB group by month(NowDate) ORDER BY month(NowDate) DESC ", con);
            double p = Convert.ToDouble(cmd.ExecuteScalar());
            con.Close();
            lblSummeryMonthlyBookings.Text = zero + Convert.ToString(p);
        }

        //Time Counter

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        //Dash Butons

        private void btnBooking_Click(object sender, EventArgs e)
        {
            BookingVisible();
            getitemsbydate();
            btnbookClickColor();
            btncustomerClickColor();
            btnroomsClickColor();
            btnHistoryClickColor();
            btnSummeryClickColor();
            btnSettingsClickColor();
            btnaboutClickColor();
            loadRoomNo();
            numberuse = 0;
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustomerVisible();
            getitemsbydate();
            btnbookClickColor();
            btncustomerClickColor();
            btnroomsClickColor();
            btnHistoryClickColor();
            btnSummeryClickColor();
            btnSettingsClickColor();
            btnaboutClickColor();
            loadRoomNo();
            numberuse = 0;
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            RoomsVisible();
            getitemsbydate();
            btnbookClickColor();
            btncustomerClickColor();
            btnroomsClickColor();
            btnHistoryClickColor();
            btnSummeryClickColor();
            btnSettingsClickColor();
            btnaboutClickColor();
            loadRoomNo();
            numberuse = 0;
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            HistoryVisible();
            getitemsbydate();
            btnbookClickColor();
            btncustomerClickColor();
            btnroomsClickColor();
            btnHistoryClickColor();
            btnSummeryClickColor();
            btnSettingsClickColor();
            btnaboutClickColor();
            loadRoomNo();
            numberuse = 0;
        }

        private void btnDashSummery_Click(object sender, EventArgs e)
        {
            summeryVisible();
            getitemsbydate();
            btnbookClickColor();
            btncustomerClickColor();
            btnroomsClickColor();
            btnHistoryClickColor();
            btnSummeryClickColor();
            btnSettingsClickColor();
            btnaboutClickColor();
            loadRoomNo();
            numberuse = 0;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsVisible();
            getitemsbydate();
            btnbookClickColor();
            btncustomerClickColor();
            btnroomsClickColor();
            btnHistoryClickColor();
            btnSummeryClickColor();
            btnSettingsClickColor();
            btnaboutClickColor();
            loadRoomNo();
            numberuse = 0;

            loadIdRoom();
            txtLoginUsername.Focus();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutVisible();
            getitemsbydate();
            hideing();
            btnbookClickColor();
            btncustomerClickColor();
            btnroomsClickColor();
            btnHistoryClickColor();
            btnSummeryClickColor();
            btnSettingsClickColor();
            btnaboutClickColor();
            loadRoomNo();
            numberuse = 0;
            btnContact.Visible = true;
            lblConditopnapp.Visible = true;
            pbiconbackwhite.Visible = true;
        }

        //Sign Out Button

        private void linkSignOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        //Dashboard Booking Designs


        int invoiceloadCounter = 0;

        private void grbBookingInvoicesclickcolor()
        {

            if (invoiceloadCounter == 0)
            {
                grbBookingInvoices.Visible = true;
                btnBookingNext.Enabled = false;
                btnBookingUpdate.Enabled = false;
                btnBookingClear.Enabled = false;
                btnBookingDelete.Enabled = false;
                lblBookingID.Visible = false;
                btnBookingPayInvoices.BackColor = Color.Goldenrod;
                btnBookingPayInvoices.ForeColor = Color.White;
                btnBookingPayInvoices.FlatAppearance.BorderSize = 0;
                invoiceloadCounter = 1;
            }
            else if(invoiceloadCounter == 1)
            {
                grbBookingInvoices.Visible = false;
                btnBookingNext.Enabled = true;
                btnBookingUpdate.Enabled = true;
                btnBookingClear.Enabled = true;
                btnBookingDelete.Enabled = true;
                lblBookingID.Visible = true;
                btnBookingPayInvoices.BackColor = Color.Gainsboro;
                btnBookingPayInvoices.ForeColor = Color.Black;
                btnBookingPayInvoices.FlatAppearance.BorderSize = 0;
                invoiceloadCounter = 0;
            }
        }

        private void invoicesview()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from PaymentDetailsTB", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtgirdViewBookingpayInvoices.DataSource = dt;
            con.Close();
        }

        private void btnBookingPayInvoices_Click(object sender, EventArgs e)
        {
            grbBookingInvoicesclickcolor();
            invoicesview();
        }


        //Login Designs Rooms Adding

        private void btnSettingsOption_Click(object sender, EventArgs e)
        {
            grbCompanyOption.Visible = false;
            grbRoomsOption.Visible = true;

            btnSettingsroomsClickColor();
            btnSettingsCompanyClickColor();
            viewOptionsinRoomSettings();
        }

        private void btnSettingsCompanySettings_Click(object sender, EventArgs e)
        {
            grbCompanyOption.Visible = true;
            grbRoomsOption.Visible = false;

            btnSettingsroomsClickColor();
            btnSettingsCompanyClickColor();
            hideOptionsinRoomSettings();
            uploadBtnVisible();
        }

        private void viewOptionsinRoomSettings()
        {
            lblRoomOptionTools.Visible = true;
            btnSettingsAdd.Visible = true;
            btnSettingsUpdate.Visible = true;
            btnSettingsDelete.Visible = true;
            btnSettingsClear.Visible = true;
        }

        private void btnSettingsCompanyClickColor()
        {
            if (grbCompanyOption.Visible == true)
            {
                btnSettingsCompanySettings.BackColor = Color.Goldenrod;
                btnSettingsCompanySettings.ForeColor = Color.White;
                btnSettingsCompanySettings.FlatAppearance.BorderSize = 0;
            }
            else if (grbCompanyOption.Visible == false)
            {
                btnSettingsCompanySettings.BackColor = Color.Gainsboro;
                btnSettingsCompanySettings.ForeColor = Color.Black;
                btnSettingsCompanySettings.FlatAppearance.BorderSize = 0;
            }
        }

        private void btnSettingsroomsClickColor()
        {
            if (grbRoomsOption.Visible == true)
            {
                btnSettingsOption.BackColor = Color.Goldenrod;
                btnSettingsOption.ForeColor = Color.White;
                btnSettingsOption.FlatAppearance.BorderSize = 0;
            }
            else if (grbRoomsOption.Visible == false)
            {
                btnSettingsOption.BackColor = Color.Gainsboro;
                btnSettingsOption.ForeColor = Color.Black;
                btnSettingsOption.FlatAppearance.BorderSize = 0;
            }
        }

        private void hideOptionsinRoomSettings()
        {
            lblRoomOptionTools.Visible = false;
            btnSettingsAdd.Visible = false;
            btnSettingsUpdate.Visible = false;
            btnSettingsDelete.Visible = false;
            btnSettingsClear.Visible = false;
        }



        //Rooms Add Login System

        private void txtLoginUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtLoginPassword.Text == "")
                {
                    txtLoginPassword.Focus();
                }
                else if (txtLoginPassword.Text != "" || txtLoginUsername.Text != "")
                {
                    try
                    {
                        if (txtLoginUsername.Text == "Admin")
                        {
                            int r = 1;
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("select CONVERT(varchar(4000),DECRYPTBYPASSPHRASE('8',Password)) from logInTB where ID = '" + r + "'", conn);
                            string password1 = Convert.ToString(cmd.ExecuteScalar());

                            SqlCommand cmd1 = new SqlCommand("select CONVERT(varchar(4000),DECRYPTBYPASSPHRASE('8',UserName)) from logInTB where ID = '" + r + "'", conn);
                            string UserName = Convert.ToString(cmd1.ExecuteScalar());
                            conn.Close();

                            if (password1 == txtLoginPassword.Text && UserName == txtLoginUsername.Text)
                            {
                                if (lblLoginchangeble.Text == "Log In")
                                {
                                    passwords();
                                    grbLogIn.Visible = false;
                                }
                                else if (lblLoginchangeble.Text == "Edit Info")
                                {
                                    companyEditInfo();
                                    grbLogIn.Visible = false;
                                }
                                else
                                {
                                    MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtLoginPassword.Clear();
                                    txtLoginUsername.Clear();

                                    txtLoginUsername.Focus();
                                }
                            }
                        }
                        else if (txtLoginUsername.Text == "User")
                        {
                            int y = 2;
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("select CONVERT(varchar(4000),DECRYPTBYPASSPHRASE('8',Password)) from logInTB where UserName = '" + y + "'", conn);
                            string password1 = Convert.ToString(cmd.ExecuteScalar());

                            SqlCommand cmd1 = new SqlCommand("select CONVERT(varchar(4000),DECRYPTBYPASSPHRASE('8',UserName)) from logInTB where ID = '" + y + "'", conn);
                            string UserName = Convert.ToString(cmd1.ExecuteScalar());
                            conn.Close();

                            if (password1 == txtLoginPassword.Text && UserName == txtLoginUsername.Text)
                            {
                                if (lblLoginchangeble.Text == "Log In")
                                {
                                    passwords();
                                    grbLogIn.Visible = false;
                                }
                                else if (lblLoginchangeble.Text == "Edit Info")
                                {
                                    companyEditInfo();
                                    grbLogIn.Visible = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtLoginPassword.Clear();
                                txtLoginUsername.Clear();

                                txtLoginUsername.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtLoginPassword.Clear();
                            txtLoginUsername.Clear();

                            txtLoginUsername.Focus();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error");
                    }
                    finally
                    {
                        UserpassClear();
                        con.Close();
                    }
                }
            }
        }

        private void txtLoginPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtLoginUsername.Text == "")
                {
                    txtLoginUsername.Focus();
                }
                else if (txtLoginPassword.Text != "" || txtLoginUsername.Text != "")
                {
                    try
                    {
                        if (txtLoginUsername.Text == "Admin")
                        {
                            int r = 1;
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("select CONVERT(varchar(4000),DECRYPTBYPASSPHRASE('8',Password)) from logInTB where ID = '" + r + "'", conn);
                            string password1 = Convert.ToString(cmd.ExecuteScalar());

                            SqlCommand cmd1 = new SqlCommand("select CONVERT(varchar(4000),DECRYPTBYPASSPHRASE('8',UserName)) from logInTB where ID = '" + r + "'", conn);
                            string UserName = Convert.ToString(cmd1.ExecuteScalar());
                            conn.Close();

                            if (password1 == txtLoginPassword.Text && UserName == txtLoginUsername.Text)
                            {
                                if (lblLoginchangeble.Text == "Log In")
                                {
                                    passwords();
                                    grbLogIn.Visible = false;
                                }
                                else if (lblLoginchangeble.Text == "Edit Info")
                                {
                                    companyEditInfo();
                                    grbLogIn.Visible = false;
                                }
                                else
                                {
                                    MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtLoginPassword.Clear();
                                    txtLoginUsername.Clear();

                                    txtLoginUsername.Focus();
                                }
                            }
                        }
                        else if (txtLoginUsername.Text == "User")
                        {
                            int y = 2;
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("select CONVERT(varchar(4000),DECRYPTBYPASSPHRASE('8',Password)) from logInTB where UserName = '" + y + "'", conn);
                            string password1 = Convert.ToString(cmd.ExecuteScalar());

                            SqlCommand cmd1 = new SqlCommand("select CONVERT(varchar(4000),DECRYPTBYPASSPHRASE('8',UserName)) from logInTB where ID = '" + y + "'", conn);
                            string UserName = Convert.ToString(cmd1.ExecuteScalar());
                            conn.Close();

                            if (password1 == txtLoginPassword.Text && UserName == txtLoginUsername.Text)
                            {
                                if (lblLoginchangeble.Text == "Log In")
                                {
                                    passwords();
                                    grbLogIn.Visible = false;
                                }
                                else if (lblLoginchangeble.Text == "Edit Info")
                                {
                                    companyEditInfo();
                                    grbLogIn.Visible = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtLoginPassword.Clear();
                                txtLoginUsername.Clear();

                                txtLoginUsername.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtLoginPassword.Clear();
                            txtLoginUsername.Clear();

                            txtLoginUsername.Focus();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error");
                    }
                    finally
                    {
                        UserpassClear();
                        con.Close();
                    }
                }
            }
        }

        private void UserpassClear()
        {
            txtLoginUsername.Clear();
            txtLoginPassword.Clear();
        }

        private void passwords()
        {/*
            grbLogIn.Visible = false;
            grbRoomsSettings.Visible = true;
            btnSettingsOption.BackColor = Color.Goldenrod;
            btnSettingsOption.ForeColor = Color.White;*/

            grbLogIn.Visible = false;
            grbRoomsSettings.Visible = true;
            grbCompanyOption.Visible = false;
            grbRoomsOption.Visible = true;
            btnSettingsOption.Enabled = true;
            btnSettingsAdd.Visible = true;
            btnSettingsUpdate.Visible = true;
            btnSettingsDelete.Visible = true;
            btnSettingsClear.Visible = true;
            lblRoomOptionTools.Visible = true;
            btnSettingsOption.BackColor = Color.Goldenrod;
            btnSettingsOption.ForeColor = Color.White;
            btnSettingsCompanySettings.BackColor = Color.Gainsboro;
            btnSettingsCompanySettings.ForeColor = Color.Black;
        }

        private void companyEditInfo()
        {
            grbLogIn.Visible = false;
            grbRoomsSettings.Visible = true;
            grbCompanyOption.Visible = true;
            grbRoomsOption.Visible = false;
            btnSettingsOption.Enabled = false;
            btnSettingsAdd.Visible = false;
            btnSettingsUpdate.Visible = false;
            btnSettingsDelete.Visible = false;
            btnSettingsClear.Visible = false;
            lblRoomOptionTools.Visible = false;
            btnSettingsOption.BackColor = Color.Gainsboro;
            btnSettingsOption.ForeColor = Color.Black;
            btnSettingsCompanySettings.BackColor = Color.Goldenrod;
            btnSettingsCompanySettings.ForeColor = Color.White;
        }

        private void btnLogInSecurity_Click(object sender, EventArgs e)
        {
            if (txtLoginUsername.Text == "")
            {
                txtLoginUsername.Focus();
            }
            else if (txtLoginPassword.Text != "" || txtLoginUsername.Text != "")
            {
                try
                {
                    if (txtLoginUsername.Text == "Admin")
                    {
                        int r = 1;
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("select CONVERT(varchar(4000),DECRYPTBYPASSPHRASE('8',Password)) from logInTB where ID = '" + r + "'", conn);
                        string password1 = Convert.ToString(cmd.ExecuteScalar());

                        SqlCommand cmd1 = new SqlCommand("select CONVERT(varchar(4000),DECRYPTBYPASSPHRASE('8',UserName)) from logInTB where ID = '" + r + "'", conn);
                        string UserName = Convert.ToString(cmd1.ExecuteScalar());
                        conn.Close();

                        if (password1 == txtLoginPassword.Text && UserName == txtLoginUsername.Text)
                        {
                            if (lblLoginchangeble.Text == "Log In")
                            {
                                passwords();
                                grbLogIn.Visible = false;
                            }
                            else if (lblLoginchangeble.Text == "Edit Info")
                            {
                                companyEditInfo();
                                grbLogIn.Visible = false;
                            }
                            else
                            {
                                MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtLoginPassword.Clear();
                                txtLoginUsername.Clear();

                                txtLoginUsername.Focus();
                            }
                        }
                    }
                    else if (txtLoginUsername.Text == "User")
                    {
                        int y = 2;
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("select CONVERT(varchar(4000),DECRYPTBYPASSPHRASE('8',Password)) from logInTB where UserName = '" + y + "'", conn);
                        string password1 = Convert.ToString(cmd.ExecuteScalar());

                        SqlCommand cmd1 = new SqlCommand("select CONVERT(varchar(4000),DECRYPTBYPASSPHRASE('8',UserName)) from logInTB where ID = '" + y + "'", conn);
                        string UserName = Convert.ToString(cmd1.ExecuteScalar());
                        conn.Close();

                        if (password1 == txtLoginPassword.Text && UserName == txtLoginUsername.Text)
                        {
                            if (lblLoginchangeble.Text == "Log In")
                            {
                                passwords();
                                grbLogIn.Visible = false;
                            }
                            else if (lblLoginchangeble.Text == "Edit Info")
                            {
                                companyEditInfo();
                                grbLogIn.Visible = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtLoginPassword.Clear();
                            txtLoginUsername.Clear();

                            txtLoginUsername.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtLoginPassword.Clear();
                        txtLoginUsername.Clear();

                        txtLoginUsername.Focus();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
                finally
                {
                    UserpassClear();
                    con.Close();
                }
            }
        }

        //Rooms Addin System

        private void loadRoomNo()
        {
            con.Open();
            //SqlCommand cmd = new SqlCommand("Select RoomNo from RoomsTB order by 1 asc", con);
            SqlCommand cmd = new SqlCommand("SELECT RoomNo FROM RoomsTB AS A WHERE NOT EXISTS(SELECT RoomNo FROM RoomsRTB AS B WHERE A.RoomNo = B.RoomNo) order by 1 asc", con);
            SqlDataAdapter da1 = new SqlDataAdapter();
            da1.SelectCommand = cmd;
            DataTable table1 = new DataTable();
            da1.Fill(table1);
            cmbCustomerRoNo.DataSource = table1;
            cmbCustomerRoNo.DisplayMember = "RoomNo";
            cmbCustomerRoNo.ValueMember = "RoomNo";
            con.Close();
        }

        public void emptyOption()
        {
            txtRoNo.Clear();
            txtRoName.Clear();
            cmbRoType.SelectedItem = null;
            txtRoPrice.Clear();
            lblRoNo.Text = "";
            lblRoType.Text = "";
            lblRoName.Text = "";
            lblRoPrice.Text = "";

            txtRoNo.Focus();
        }

        private void txtRoNo_TextChanged(object sender, EventArgs e)
        {
            if (txtRoNo.Text == "")
            {
                lblRoNo.Text = "";
                lblRoType.Text = "";
                lblRoName.Text = "";
                lblRoPrice.Text = "";
                return;
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from RoomsTB where RoomNo ='" + int.Parse(txtRoNo.Text) + "'", con);
                    SqlDataReader srd = cmd.ExecuteReader();
                    while (srd.Read())
                    {
                        lblRoNo.Text = srd.GetValue(1).ToString();
                        lblRoName.Text = srd.GetValue(2).ToString();
                        lblRoType.Text = srd.GetValue(3).ToString();
                        lblRoPrice.Text = srd.GetValue(4).ToString();
                        txtRoNo.Text = srd.GetValue(1).ToString();
                        txtRoName.Text = srd.GetValue(2).ToString();
                        cmbRoType.SelectedItem = srd.GetValue(3).ToString();
                        txtRoPrice.Text = srd.GetValue(4).ToString();

                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Don't enter 0 first!");
                    return;
                }
                finally
                {
                    
                    con.Close();
                }
            }
        }

        double cont = 0;

        string counter;

        private void loadIdRoom()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM RoomsTB WHERE ID = (SELECT MAX(ID) FROM RoomsTB) ", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            counter = cont + i.ToString();
        }


        private void btnSettingsAdd_Click(object sender, EventArgs e)
        {
            if (txtRoNo.Text == "" || txtRoName.Text == "" || cmbRoType.SelectedItem == null || txtRoPrice.Text == "")
            {
                MessageBox.Show("Please enter the Values!");
                return;
            }
            else
            {
                if (txtRoNo.Text == lblRoNo.Text)
                {
                    MessageBox.Show("Room is always added!");
                    return;
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into RoomsTB Values (@ID,@RoomNo,@RoomName,@RoomType,@RoomPrice)", con);
                    cmd.Parameters.AddWithValue("@ID", int.Parse(counter));
                    cmd.Parameters.AddWithValue("@RoomNo", int.Parse(txtRoNo.Text));
                    cmd.Parameters.AddWithValue("@RoomName", txtRoName.Text);
                    cmd.Parameters.AddWithValue("@RoomType", cmbRoType.SelectedItem);
                    cmd.Parameters.AddWithValue("@RoomPrice", float.Parse(txtRoPrice.Text));
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd3 = new SqlCommand("Select RoomsTB.RoomNo, RoomsTB.RoomName, RoomsTB.RoomType, RoomsTB.RoomPrice from RoomsTB order by 1 asc", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd3);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewRooms.DataSource = dt;

                    con.Close();
                    MessageBox.Show("Room Book is Sucessfull!", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Sucessfull!");
                    loadIdRoom();
                }

            }

            emptyOption();
        }

        private void btnSettingsUpdate_Click(object sender, EventArgs e)
        {
            if (txtRoNo.Text == "" || txtRoName.Text == "" || cmbRoType.SelectedItem == null || txtRoPrice.Text == "")
            {
                MessageBox.Show("Please enter the Values!");
                return;
            }
            else
            {
                if (txtRoNo.Text == lblRoNo.Text)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update RoomsTB set RoomName= @RoomName, RoomType= @RoomType, RoomPrice= @RoomPrice where RoomNo= @RoomNo", con);
                    cmd.Parameters.AddWithValue("@ID", int.Parse(counter));
                    cmd.Parameters.AddWithValue("@RoomNo", int.Parse(txtRoNo.Text));
                    cmd.Parameters.AddWithValue("@RoomName", txtRoName.Text);
                    cmd.Parameters.AddWithValue("@RoomType", cmbRoType.SelectedItem);
                    cmd.Parameters.AddWithValue("@RoomPrice", float.Parse(txtRoPrice.Text));
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd3 = new SqlCommand("Select RoomsTB.RoomNo, RoomsTB.RoomName, RoomsTB.RoomType, RoomsTB.RoomPrice from RoomsTB order by 1 asc", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd3);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewRooms.DataSource = dt;

                    con.Close();
                    MessageBox.Show("Room Update is Sucessfull!", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadIdRoom();
                }
                else
                {
                    MessageBox.Show("No Record to update!");
                    return;
                }

            }

            emptyOption();
        }

        private void btnSettingsDelete_Click(object sender, EventArgs e)
        {
            if (txtRoNo.Text != "" || txtRoName.Text != "" || cmbRoType.SelectedItem != null || txtRoPrice.Text != "")
            {
                MessageBox.Show("Apply RoomNo, No need other values!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (txtRoNo.Text == "")
                {
                    MessageBox.Show("Apply RoomNo!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete RoomsTB where RoomNo= @RoomNo", con);
                    cmd.Parameters.AddWithValue("@RoomNo", int.Parse(txtRoNo.Text));
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd3 = new SqlCommand("Select RoomsTB.RoomNo, RoomsTB.RoomName, RoomsTB.RoomType, RoomsTB.RoomPrice from RoomsTB order by 1 asc", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd3);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewRooms.DataSource = dt;

                    con.Close();
                    MessageBox.Show("Delete is Sucessfull!", "Succes Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    emptyOption();
                }
            }
            else if (txtRoNo.Text == "")
            {
                MessageBox.Show("Please Enter the RoomNo!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete RoomsTB where RoomNo= @RoomNo", con);
                cmd.Parameters.AddWithValue("@RoomNo", int.Parse(txtRoNo.Text));
                cmd.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand("Select RoomsTB.RoomNo, RoomsTB.RoomName, RoomsTB.RoomType, RoomsTB.RoomPrice from RoomsTB order by 1 asc", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd3);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewRooms.DataSource = dt;

                con.Close();
                MessageBox.Show("Delete is Sucessfull!", "Succes Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                emptyOption();
            }
        }

        private void btnSettingsClear_Click(object sender, EventArgs e)
        {
            emptyOption();
        }

        private void txtRoID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRoNo.Focus();
            }
        }

        private void txtRoNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRoName.Focus();
            }
        }

        private void txtRoName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRoPrice.Focus();
            }
        }

        private void txtRoPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtRoNo.Text == "" || txtRoName.Text == "" || cmbRoType.SelectedItem == null || txtRoPrice.Text == "")
                {
                    MessageBox.Show("Please enter the Values!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (txtRoNo.Text == lblRoNo.Text)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("update RoomsTB set RoomName= @RoomName, RoomType= @RoomType, RoomPrice= @RoomPrice where RoomNo= @RoomNo", con);
                        cmd.Parameters.AddWithValue("@ID", int.Parse(counter));
                        cmd.Parameters.AddWithValue("@RoomNo", int.Parse(txtRoNo.Text));
                        cmd.Parameters.AddWithValue("@RoomName", txtRoName.Text);
                        cmd.Parameters.AddWithValue("@RoomType", cmbRoType.SelectedItem);
                        cmd.Parameters.AddWithValue("@RoomPrice", float.Parse(txtRoPrice.Text));
                        cmd.ExecuteNonQuery();

                        SqlCommand cmd3 = new SqlCommand("Select RoomsTB.RoomNo, RoomsTB.RoomName, RoomsTB.RoomType, RoomsTB.RoomPrice from RoomsTB order by 1 asc", con);
                        SqlDataAdapter da = new SqlDataAdapter(cmd3);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridViewRooms.DataSource = dt;

                        con.Close();
                        MessageBox.Show("Update is Sucessfull!", "Succes Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadIdRoom();
                    }
                    else
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into RoomsTB Values (@ID,@RoomNo,@RoomName,@RoomType,@RoomPrice)", con);
                        cmd.Parameters.AddWithValue("@ID", int.Parse(counter));
                        cmd.Parameters.AddWithValue("@RoomNo", int.Parse(txtRoNo.Text));
                        cmd.Parameters.AddWithValue("@RoomName", txtRoName.Text);
                        cmd.Parameters.AddWithValue("@RoomType", cmbRoType.SelectedItem);
                        cmd.Parameters.AddWithValue("@RoomPrice", float.Parse(txtRoPrice.Text));
                        cmd.ExecuteNonQuery();

                        SqlCommand cmd3 = new SqlCommand("Select RoomsTB.RoomNo, RoomsTB.RoomName, RoomsTB.RoomType, RoomsTB.RoomPrice from RoomsTB order by 1 asc", con);
                        SqlDataAdapter da = new SqlDataAdapter(cmd3);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridViewRooms.DataSource = dt;

                        con.Close();
                        MessageBox.Show("Addding Room is Sucessfull!", "Succes Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadIdRoom();
                    }
                }

            }


        }

        //Company Values System

        string companyIDvalue = "1";

        string companyNowID;

        private void checkValueIDcompany()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from CompanyTB where ID ='" + companyIDvalue + "'", con);
            SqlDataReader srd = cmd.ExecuteReader();
            while (srd.Read())
            {
                companyNowID = srd.GetValue(0).ToString();

            }
            con.Close();
        }

        string yourinfoCName;
        string yourinfoCAdNo;
        string yourinfoCAd1;
        string yourinfoCAd2;
        string yourinfoCAdcity;
        string yourinfoCAdLandNo;
        string yourinfoCAdMobileNo;
        string yourinfoCAdEmail;
        string yourpassword;

        private void companyValuesShowAlways()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from CompanyTB where ID ='" + companyIDvalue + "'", con);
            SqlDataReader srd = cmd.ExecuteReader();
            while (srd.Read())
            {
                yourinfoCName = txtCompanySettingsName.Text = srd.GetValue(1).ToString();
                yourinfoCAdNo = txtCompanySettingsAdNo.Text = srd.GetValue(2).ToString();
                yourinfoCAd1 = txtCompanySettingsAd1.Text = srd.GetValue(3).ToString();
                yourinfoCAd2 = txtCompanySettingsAd2.Text = srd.GetValue(4).ToString();
                yourinfoCAdcity = txtCompanySettingsCity.Text = srd.GetValue(5).ToString();
                yourinfoCAdLandNo = txtCompanySettingsLandNo.Text = srd.GetValue(6).ToString();
                yourinfoCAdMobileNo = txtCompanySettingsWirelessNo.Text = srd.GetValue(7).ToString();
                yourinfoCAdEmail = txtCompanySettingsEmail.Text = srd.GetValue(8).ToString();
                yourpassword = txtEmailPasswordGenerated.Text = srd.GetValue(9).ToString();
            }
            con.Close();
        }

        private void Summeryourinfo()
        {
            lblDashSumerybackgroundui1Cname.Text = yourinfoCName;
            lblDashSumerybackgroundui1Caddress.Text = yourinfoCAdNo + "\n" + yourinfoCAd1 + ", " + yourinfoCAd2 + "\n" + yourinfoCAdcity;
            lblDashSumerybackgroundui1CMobileLandNO.Text = yourinfoCAdLandNo + " / " + yourinfoCAdMobileNo;
            lblDashSumerybackgroundui1Email.Text = yourinfoCAdEmail + "@gmail.com";
        }

        public void uploadBtnVisible()
        {
            if (companyNowID == null || companyNowID == "")
            {
                btnDashSettingCompanyUpload.Visible = true;
                btnDashSettingCompanySave.Visible = false;
            }
            else
            {
                btnDashSettingCompanyUpload.Visible = false;
                btnDashSettingCompanySave.Visible = true;
            }
        }

        private void btnDashSettingCompanyUpload_Click(object sender, EventArgs e)
        {
            if (txtCompanySettingsName.Text == "" || txtCompanySettingsAdNo.Text == "" || txtCompanySettingsAd1.Text == "" || txtCompanySettingsAd2.Text == "" || txtCompanySettingsCity.Text == "" || txtCompanySettingsLandNo.Text == "" || txtCompanySettingsWirelessNo.Text == "" || txtCompanySettingsEmail.Text == "" || txtEmailPasswordGenerated.Text == "")
            {
                MessageBox.Show("Please enter the value!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into CompanyTB Values (@ID,@CName,@CAddressNo,@CAddressLine1,@CAddressLine2,@CAddressCity,@ContactLandNo,@ContactMobileNo,@Email,@Password)", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(companyIDvalue));
                cmd.Parameters.AddWithValue("@CName", txtCompanySettingsName.Text);
                cmd.Parameters.AddWithValue("@CAddressNo", txtCompanySettingsAdNo.Text);
                cmd.Parameters.AddWithValue("@CAddressLine1", txtCompanySettingsAd1.Text);
                cmd.Parameters.AddWithValue("@CAddressLine2", txtCompanySettingsAd2.Text);
                cmd.Parameters.AddWithValue("@CAddressCity", txtCompanySettingsCity.Text);
                cmd.Parameters.AddWithValue("@ContactLandNo", int.Parse(txtCompanySettingsLandNo.Text));
                cmd.Parameters.AddWithValue("@ContactMobileNo", int.Parse(txtCompanySettingsWirelessNo.Text));
                cmd.Parameters.AddWithValue("@Email", txtCompanySettingsEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtEmailPasswordGenerated.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Company Details Adding Sucessfull!", "Succes Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnDashSettingCompanyUpload.Visible = false;
                btnDashSettingCompanySave.Visible = true;
            }
        }

        private void btnDashSettingCompanySave_Click(object sender, EventArgs e)
        {
            if (txtCompanySettingsName.Text == "" || txtCompanySettingsAdNo.Text == "" || txtCompanySettingsAd1.Text == "" || txtCompanySettingsAd2.Text == "" || txtCompanySettingsCity.Text == "" || txtCompanySettingsLandNo.Text == "" || txtCompanySettingsWirelessNo.Text == "" || txtCompanySettingsEmail.Text == "" || txtEmailPasswordGenerated.Text == "")
            {
                MessageBox.Show("Please enter the value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("update CompanyTB set CName= @CName, CAddressNo= @CAddressNo, CAddressLine1= @CAddressLine1, CAddressLine2= @CAddressLine2, CAddressCity= @CAddressCity, ContactLandNo= @ContactLandNo, ContactMobileNo= @ContactMobileNo , Email= @Email, Password= @Password where ID= @ID", con);
                cmd1.Parameters.AddWithValue("@ID", int.Parse(companyIDvalue));
                cmd1.Parameters.AddWithValue("@CName", txtCompanySettingsName.Text);
                cmd1.Parameters.AddWithValue("@CAddressNo", txtCompanySettingsAdNo.Text);
                cmd1.Parameters.AddWithValue("@CAddressLine1", txtCompanySettingsAd1.Text);
                cmd1.Parameters.AddWithValue("@CAddressLine2", txtCompanySettingsAd2.Text);
                cmd1.Parameters.AddWithValue("@CAddressCity", txtCompanySettingsCity.Text);
                cmd1.Parameters.AddWithValue("@ContactLandNo", int.Parse(txtCompanySettingsLandNo.Text));
                cmd1.Parameters.AddWithValue("@ContactMobileNo", int.Parse(txtCompanySettingsWirelessNo.Text));
                cmd1.Parameters.AddWithValue("@Email", txtCompanySettingsEmail.Text);
                cmd1.Parameters.AddWithValue("@Password", txtEmailPasswordGenerated.Text);
                cmd1.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Company Details Updating Sucessfull!", "Succes Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }


        //Customer Booking System

        double CIDcont = 0;

        string CIDcounter;

        private void loadCIdcounting()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM CustomerMTB WHERE ID = (SELECT MAX(ID) FROM CustomerMTB) ", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            CIDcounter = CIDcont + i.ToString();
            lblBookingID.Text = "# " + CIDcounter;
            lblIdRealcounter.Text = "# " + CIDcounter;
        }

        private void clearValuesofCdetails()
        {
            txtCustomerName.Clear();
            lblBookingRNo.Text = "";
            txtCustomerNIC.Clear();
            cmbCustomerGender.Text = "";
            dtCustomerBirthday.Text = "";
            txtCustomerAdNo.Clear();
            txtCustomerAddress1.Clear();
            txtCustomerAddress2.Clear();
            txtCustomerAdCity.Clear();
            txtCustomerMobileNo.Clear();
            txtCustomerAdEmail.Clear();
            dtCustomerCheckIn.Text = lblDate.Text;
            dtCustomerCheckOut.Text = lblDate.Text;
            lblBookingRName.Text = "";
            lblBookingRType.Text = "";
            lblBookingRPrice.Text = "";
        }

        string AlwaysBookRooms;

        string Idchecker;

        private void checkAlwaysAddRooms()
        {
            if(lblBookingRNo.Text == "")
            {
                return;
            }
            else
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select * from RoomsRTB where ID ='" + int.Parse(lblBookingRNo.Text) + "'", con);
                SqlDataReader srd1 = cmd1.ExecuteReader();
                while (srd1.Read())
                {
                    Idchecker = srd1.GetValue(0).ToString();
                    AlwaysBookRooms = srd1.GetValue(3).ToString();
                }
                con.Close();
            }
        }

        private void returnValue()
        {
            lblPDID.Text = txtCustomerID.Text;
            lblPDName.Text = txtCustomerName.Text;
            lblPDMobileNo.Text = txtCustomerMobileNo.Text;
            lblPDNIC.Text = txtCustomerNIC.Text;
            lblPDGender.Text = cmbCustomerGender.SelectedItem.ToString();
            lblPDBirthday.Text = dtCustomerBirthday.Value.ToLongDateString();
            lblPDANo.Text = txtCustomerAdNo.Text;
            lblPDALine1.Text = txtCustomerAddress1.Text;
            lblPDALine2.Text = txtCustomerAddress2.Text;
            lblPDACity.Text = txtCustomerAdCity.Text;
            lblPDAEmail.Text = txtCustomerAdEmail.Text;
            lblPDACheckInDate.Text = dtCustomerCheckIn.Value.ToString();
            lblPDACheckOutDate.Text = dtCustomerCheckOut.Value.ToString();
            lblPDARoomNo.Text = lblBookingRNo.Text;
            lblPDARoomPrice.Text = lblRoomPayPrice.Text;
        }

        public void getpaymentdetails()
        {
            con.Open();
            SqlCommand cmd2 = new SqlCommand("select * from PaymentDetailsTB where ID ='" + int.Parse(txtCustomerID.Text) + "'", con);
            SqlDataReader srd2 = cmd2.ExecuteReader();
            while (srd2.Read())
            {
                txtRoomPayDiscount.Text = srd2.GetValue(9).ToString();
                lblRoomPayTPrice.Text = srd2.GetValue(10).ToString();
                txtPayPayAmount.Text = srd2.GetValue(11).ToString();
                lblPayBalance.Text = srd2.GetValue(12).ToString();
            }
            con.Close();
        }




        private void btnBookingNext_Click(object sender, EventArgs e)
        {
            if (txtCustomerID.Text == "")
            {
                txtCustomerID.Text = CIDcounter;
            }

            if (txtCustomerName.Text == "" || cmbCustomerRoNo.SelectedItem == null || txtCustomerMobileNo.Text == "" || txtCustomerNIC.Text == "" || cmbCustomerGender.SelectedItem == null || txtCustomerAdNo.Text == "" || txtCustomerAddress1.Text == "" || txtCustomerAddress2.Text == "" || txtCustomerAdCity.Text == "" || txtCustomerAdEmail.Text == "")
            {
                MessageBox.Show("Please Enter The Values");
                grbDashPayment.Visible = false;
                grbDashBook.Visible = true;
                return;
            }
            else
            {

                lblPDBillNo.Text = lblIdRealcounter.Text;
                InvoiceBillID.Text = lblPDBillNo.Text;
                checkAlwaysAddRooms();
                //loadBIdcounting();

                int bookRoom = Convert.ToInt32(AlwaysBookRooms);
                int IdCheckerMaster = Convert.ToInt32(Idchecker);

                if (txtCustomerID.Text == "")
                {
                    return;
                }
                else
                {
                    int IdMaster = Convert.ToInt32(txtCustomerID.Text);
                    int CIDcount = Convert.ToInt32(CIDcounter);
                    if (IdCheckerMaster == IdMaster)
                    {
                        if (lblEmailErrorProvider.Visible == true)
                        {
                            MessageBox.Show("Please Check Import Details!");
                        }
                        else
                        {
                            if (txtCustomerNIC.Text.Length == 12)
                            {
                                grbDashPayment.Visible = true;
                                grbBookingPayInvoice1.Visible = false;
                                returnValue();
                                getpaymentdetails();
                            }
                            else if (txtCustomerNIC.Text.Length < 12)
                            {
                                string values = txtCustomerNIC.Text;
                                int result = 0;
                                if(int.TryParse(values, out result))
                                {
                                    txtCustomerNIC.Text = values + "v";
                                }
                                grbDashPayment.Visible = true;
                                grbBookingPayInvoice1.Visible = false;
                                returnValue();
                                getpaymentdetails();
                            }
                            else
                            {

                            }
                            
                        }
                    }
                    else
                    {
                        if (lblBookingRNo.Text == "")
                        {
                            return;
                        }
                        else
                        {
                            int selRoom = Convert.ToInt32(lblBookingRNo.Text);
                            if (bookRoom == selRoom)
                            {
                                MessageBox.Show("Always Booked Room!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (lblEmailErrorProvider.Visible == true || lblEmailErrorProvider.Text == "")
                                {
                                    MessageBox.Show("Please Check Import Details!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    if (txtCustomerNIC.Text.Length == 12)
                                    {
                                        grbDashPayment.Visible = true;
                                        grbBookingPayInvoice1.Visible = false;
                                        returnValue();
                                        getpaymentdetails();
                                    }
                                    else if (txtCustomerNIC.Text.Length < 12)
                                    {
                                        string values = txtCustomerNIC.Text;
                                        int result = 0;
                                        if (int.TryParse(values, out result))
                                        {
                                            txtCustomerNIC.Text = values + "v";
                                        }
                                        grbDashPayment.Visible = true;
                                        grbBookingPayInvoice1.Visible = false;
                                        returnValue();
                                        getpaymentdetails();
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                        }
                    }
                }
            }
            
        }



        private void btnRoomCheck_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from RoomsTB where RoomNo ='" + int.Parse(cmbCustomerRoNo.Text) + "'", con);
                SqlDataReader srd = cmd.ExecuteReader();
                while (srd.Read())
                {
                    lblBookingRNo.Text = srd.GetValue(1).ToString();
                    lblBookingRName.Text = srd.GetValue(2).ToString();
                    lblBookingRType.Text = srd.GetValue(3).ToString();
                    lblBookingRPrice.Text = srd.GetValue(4).ToString();
                }
            }
            catch(Exception)
            {
                return;
            }
            finally
            {
                con.Close();
            }
        }

        

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {
            
            if (txtCustomerID.Text == "")
            {
                loadCIdcounting();
                clearValuesofCdetails();
                return;
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from CustomerTB where ID ='" + int.Parse(txtCustomerID.Text) + "'", con);
                    SqlDataReader srd = cmd.ExecuteReader();
                    while (srd.Read())
                    {
                        lblIdRealcounter.Text = lblBookingID.Text = "# " + srd.GetValue(0).ToString();
                        txtCustomerName.Text = srd.GetValue(3).ToString();
                        lblBookingRNo.Text = srd.GetValue(4).ToString();
                        txtCustomerNIC.Text = srd.GetValue(5).ToString();
                        cmbCustomerGender.Text = srd.GetValue(6).ToString();
                        dtCustomerBirthday.Text = srd.GetValue(7).ToString();
                        txtCustomerAdNo.Text = srd.GetValue(8).ToString();
                        txtCustomerAddress1.Text = srd.GetValue(9).ToString();
                        txtCustomerAddress2.Text = srd.GetValue(10).ToString();
                        txtCustomerAdCity.Text = srd.GetValue(11).ToString();
                        txtCustomerMobileNo.Text = srd.GetValue(12).ToString();
                        txtCustomerAdEmail.Text = srd.GetValue(13).ToString();
                        dtCustomerCheckIn.Text = srd.GetValue(14).ToString();
                        dtCustomerCheckOut.Text = srd.GetValue(15).ToString();
                    }
                    con.Close();

                    if (lblBookingRNo.Text == "")
                    {
                        return;
                    }
                    else
                    {
                        try
                        {
                            con.Open();
                            SqlCommand cmd1 = new SqlCommand("select * from RoomsTB where ID ='" + int.Parse(lblBookingRNo.Text) + "'", con);
                            SqlDataReader srd1 = cmd1.ExecuteReader();
                            while (srd1.Read())
                            {
                                lblBookingRName.Text = srd1.GetValue(2).ToString();
                                lblBookingRType.Text = srd1.GetValue(3).ToString();
                                lblBookingRPrice.Text = srd1.GetValue(4).ToString();
                            }

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
        }

        private void txtCustomerAdEmail_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtCustomerAdEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtCustomerAdEmail.Text == "")
            {
                lblEmailErrorProvider.Visible = false;
            }
            else
            {
                lblEmailErrorProvider.Text = "* Please Enter Valid Email Address.";

                string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
                if (Regex.IsMatch(txtCustomerAdEmail.Text, pattern))
                {
                    lblEmailErrorProvider.Visible = false;
                }
                else
                {
                    lblEmailErrorProvider.Visible = true;
                }
            }
        }

        private void BookingDetailsUpdate()
        {
            if (txtCustomerID.Text == "" || txtCustomerName.Text == "" || cmbCustomerRoNo.SelectedItem == null || txtCustomerMobileNo.Text == "" || txtCustomerNIC.Text == "" || cmbCustomerGender.SelectedItem == null || txtCustomerAdNo.Text == "" || txtCustomerAddress1.Text == "" || txtCustomerAddress2.Text == "" || txtCustomerAdCity.Text == "" || txtCustomerAdEmail.Text == "")
            {
                MessageBox.Show("Please Enter The Values", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                grbDashPayment.Visible = false;
                grbDashBook.Visible = true;
                return;
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update CustomerTB set NowDate= @NowDate, NowTime= @NowTime, Name= @Name,RoomNo= @RoomNo, NIC= @NIC,Gender= @Gender,Birthday= @Birthday,AdNo= @AdNo,AdLine1= @AdLine1,AdLine2= @AdLine2,City= @City, MobileNo= @MobileNo, Email= @Email,CheckInDate= @CheckInDate,CheckOutDate= @CheckOutDate, TotPrice= @TotPrice where ID= @ID", con);
                    cmd.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                    cmd.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                    cmd.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                    cmd.Parameters.AddWithValue("@Name", txtCustomerName.Text);
                    cmd.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                    cmd.Parameters.AddWithValue("@NIC", txtCustomerNIC.Text);
                    cmd.Parameters.AddWithValue("@Gender", cmbCustomerGender.SelectedItem);
                    cmd.Parameters.AddWithValue("@Birthday", DateTime.Parse(dtCustomerBirthday.Value.ToString()));
                    cmd.Parameters.AddWithValue("@AdNo", txtCustomerAdNo.Text);
                    cmd.Parameters.AddWithValue("@AdLine1", txtCustomerAddress1.Text);
                    cmd.Parameters.AddWithValue("@AdLine2", txtCustomerAddress2.Text);
                    cmd.Parameters.AddWithValue("@City", txtCustomerAdCity.Text);
                    cmd.Parameters.AddWithValue("@MobileNo", int.Parse(txtCustomerMobileNo.Text));
                    cmd.Parameters.AddWithValue("@Email", txtCustomerAdEmail.Text);
                    cmd.Parameters.AddWithValue("@CheckInDate", DateTime.Parse(dtCustomerCheckIn.Value.ToString()));
                    cmd.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                    cmd.Parameters.AddWithValue("@TotPrice", float.Parse(lblPDATotPrice.Text));
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd1 = new SqlCommand("update CustomerMTB set NowDate= @NowDate, NowTime= @NowTime, Name= @Name,RoomNo= @RoomNo, NIC= @NIC,Gender= @Gender,Birthday= @Birthday,AdNo= @AdNo,AdLine1= @AdLine1,AdLine2= @AdLine2,City= @City, MobileNo= @MobileNo, Email= @Email,CheckInDate= @CheckInDate,CheckOutDate= @CheckOutDate, TotPrice= @TotPrice where ID= @ID", con);
                    cmd1.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                    cmd1.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                    cmd1.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                    cmd1.Parameters.AddWithValue("@Name", txtCustomerName.Text);
                    cmd1.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                    cmd1.Parameters.AddWithValue("@NIC", txtCustomerNIC.Text);
                    cmd1.Parameters.AddWithValue("@Gender", cmbCustomerGender.SelectedItem);
                    cmd1.Parameters.AddWithValue("@Birthday", DateTime.Parse(dtCustomerBirthday.Value.ToString()));
                    cmd1.Parameters.AddWithValue("@AdNo", txtCustomerAdNo.Text);
                    cmd1.Parameters.AddWithValue("@AdLine1", txtCustomerAddress1.Text);
                    cmd1.Parameters.AddWithValue("@AdLine2", txtCustomerAddress2.Text);
                    cmd1.Parameters.AddWithValue("@City", txtCustomerAdCity.Text);
                    cmd1.Parameters.AddWithValue("@MobileNo", int.Parse(txtCustomerMobileNo.Text));
                    cmd1.Parameters.AddWithValue("@Email", txtCustomerAdEmail.Text);
                    cmd1.Parameters.AddWithValue("@CheckInDate", DateTime.Parse(dtCustomerCheckIn.Value.ToString()));
                    cmd1.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                    cmd1.Parameters.AddWithValue("@TotPrice", float.Parse(lblPDATotPrice.Text));
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("update PaymentDetailsTB set NowDate= @NowDate, NowTime= @NowTime, RoomNo= @RoomNo, CustomerName= @CustomerName,  CustomerNIC= @CustomerNIC, CheckOutDate= @CheckOutDate, BillID= @BillID,Price= @Price,Discount= @Discount,TotalAmount= @TotalAmount,PayAmount= @PayAmount,Balance= @Balance  where ID= @ID", con);
                    cmd2.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                    cmd2.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                    cmd2.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                    cmd2.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                    cmd2.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cmd2.Parameters.AddWithValue("@CustomerNIC", txtCustomerNIC.Text);
                    cmd2.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                    if (BIDcounter == null)
                    {
                        BIDcounter = "1";
                        cmd2.Parameters.AddWithValue("@BillID", int.Parse(BIDcounter));
                    }
                    else
                    {
                        cmd2.Parameters.AddWithValue("@BillID", int.Parse(BIDcounter));
                    }
                    cmd2.Parameters.AddWithValue("@Price", float.Parse(lblPDARoomPrice.Text));
                    cmd2.Parameters.AddWithValue("@Discount", float.Parse(lblPDARoomDiscount.Text));
                    cmd2.Parameters.AddWithValue("@TotalAmount", float.Parse(lblPDATotPrice.Text));
                    cmd2.Parameters.AddWithValue("@PayAmount", float.Parse(txtPayPayAmount.Text));
                    cmd2.Parameters.AddWithValue("@Balance", float.Parse(lblPayBalance.Text));
                    cmd2.ExecuteNonQuery();

                    SqlCommand cmd3 = new SqlCommand("update PaymentDetailsMTB set NowDate= @NowDate, NowTime= @NowTime, RoomNo= @RoomNo, CustomerName= @CustomerName,  CustomerNIC= @CustomerNIC, CheckOutDate= @CheckOutDate, BillID= @BillID,Price= @Price,Discount= @Discount,TotalAmount= @TotalAmount,PayAmount= @PayAmount,Balance= @Balance  where ID= @ID", con);
                    cmd3.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                    cmd3.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                    cmd3.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                    cmd3.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                    cmd3.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cmd3.Parameters.AddWithValue("@CustomerNIC", txtCustomerNIC.Text);
                    cmd3.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                    if (BIDcounter == null)
                    {
                        BIDcounter = "1";
                        cmd3.Parameters.AddWithValue("@BillID", int.Parse(BIDcounter));
                    }
                    else
                    {
                        cmd3.Parameters.AddWithValue("@BillID", int.Parse(BIDcounter));
                    }
                    cmd3.Parameters.AddWithValue("@Price", float.Parse(lblPDARoomPrice.Text));
                    cmd3.Parameters.AddWithValue("@Discount", float.Parse(lblPDARoomDiscount.Text));
                    cmd3.Parameters.AddWithValue("@TotalAmount", float.Parse(lblPDATotPrice.Text));
                    cmd3.Parameters.AddWithValue("@PayAmount", float.Parse(txtPayPayAmount.Text));
                    cmd3.Parameters.AddWithValue("@Balance", float.Parse(lblPayBalance.Text));
                    cmd3.ExecuteNonQuery();

                    SqlCommand cmd4 = new SqlCommand("update RoomsRTB set NowDate= @NowDate, NowTime= @NowTime, RoomNo= @RoomNo, CustomerName= @CustomerName, CustomerNIC= @CustomerNIC, CheckOutDate= @CheckOutDate, RoomName= @RoomName, RoomType= @RoomType, RoomPrice= @RoomPrice where ID= @ID", con);
                    cmd4.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                    cmd4.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                    cmd4.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                    cmd4.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                    cmd4.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cmd4.Parameters.AddWithValue("@CustomerNIC", txtCustomerNIC.Text);
                    cmd4.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                    cmd4.Parameters.AddWithValue("@RoomName", lblBookingRName.Text);
                    cmd4.Parameters.AddWithValue("@RoomType", lblBookingRType.Text);
                    cmd4.Parameters.AddWithValue("@RoomPrice", float.Parse(lblBookingRPrice.Text));
                    cmd4.ExecuteNonQuery();

                    SqlCommand cmd5 = new SqlCommand("update RoomsMRTB set NowDate= @NowDate, NowTime= @NowTime, RoomNo= @RoomNo, CustomerName= @CustomerName, CustomerNIC= @CustomerNIC, CheckOutDate= @CheckOutDate, RoomName= @RoomName, RoomType= @RoomType, RoomPrice= @RoomPrice where ID= @ID", con);
                    cmd5.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                    cmd5.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                    cmd5.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                    cmd5.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                    cmd5.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cmd5.Parameters.AddWithValue("@CustomerNIC", txtCustomerNIC.Text);
                    cmd5.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                    cmd5.Parameters.AddWithValue("@RoomName", lblBookingRName.Text);
                    cmd5.Parameters.AddWithValue("@RoomType", lblBookingRType.Text);
                    cmd5.Parameters.AddWithValue("@RoomPrice", float.Parse(lblBookingRPrice.Text));
                    cmd5.ExecuteNonQuery();

                    

                    MessageBox.Show("Sucessfull Updated!", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    return;
                }
                finally
                {
                    con.Close();
                    loadRoomNo();
                    getitemsbydate();
                }
            }
        }

        private void btnBookingUpdate_Click(object sender, EventArgs e)
        {
            BookingDetailsUpdate();
        }

        private void btnBookingDelete_Click(object sender, EventArgs e)
        {
            if (txtCustomerID.Text == "" || lblBookingRNo.Text == "")
            {
                MessageBox.Show("Please Enter The Customer ID And RoomNumber", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("Delete CustomerTB where ID= @ID", con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("Delete RoomsRTB where RoomNo= @RoomNo", con);
                cmd1.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("Delete PaymentDetailsTB where ID= @ID", con);
                cmd2.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Delete is Sucessful!", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();

                clearall();

                con.Open();
                //SqlCommand cmd = new SqlCommand("Select RoomNo from RoomsTB order by 1 asc", con);
                SqlCommand cmd3 = new SqlCommand("SELECT RoomNo FROM RoomsTB AS A WHERE NOT EXISTS(SELECT RoomNo FROM RoomsRTB AS B WHERE A.RoomNo = B.RoomNo) order by 1 asc", con);
                SqlDataAdapter da1 = new SqlDataAdapter();
                da1.SelectCommand = cmd3;
                DataTable table1 = new DataTable();
                da1.Fill(table1);
                cmbCustomerRoNo.DataSource = table1;
                cmbCustomerRoNo.DisplayMember = "RoomNo";
                cmbCustomerRoNo.ValueMember = "RoomNo";
                con.Close();
            }
            
        }

        private void btnBookingClear_Click(object sender, EventArgs e)
        {
            clearall();
        }

        public void clearall()
        {
            txtCustomerID.Clear();
            txtCustomerName.Clear();
            cmbCustomerRoNo.SelectedItem = DateTime.Now.ToLongDateString();
            txtCustomerMobileNo.Clear();
            txtCustomerNIC.Clear();
            cmbCustomerGender.SelectedItem = "";
            txtCustomerAdNo.Clear();
            txtCustomerAddress1.Clear();
            txtCustomerAddress2.Clear();
            txtCustomerAdCity.Clear();
            txtCustomerAdEmail.Clear();
            dtCustomerCheckIn.Text = DateTime.Now.ToString();
            dtCustomerCheckOut.Text = DateTime.Now.ToString();
            txtRoomPayDiscount.Clear();
            txtPayPayAmount.Clear();
        }

        private void lblBookingRPrice_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void lblBookingRPrice_TextChanged_1(object sender, EventArgs e)
        {
            lblRoomPayPrice.Text = lblBookingRPrice.Text;
        }


        //Payment Section System

        double BIDcont = 0;

        string BIDcounter;

        private void loadBIdcounting()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM PaymentDetailsMTB WHERE ID = (SELECT MAX(ID) FROM PaymentDetailsMTB) ", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            BIDcounter = BIDcont + i.ToString();
            lblPDBillNo.Text = "# " + BIDcounter;
            InvoiceBillID.Text = lblPDBillNo.Text;
        }

        private void txtRoomPayDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtRoomPayDiscount.Text == "")
            {
                return;
            }
            else
            {
                double roomprice = Convert.ToDouble(lblRoomPayPrice.Text);
                double discount = Convert.ToDouble(txtRoomPayDiscount.Text);

                double totprice = roomprice - discount;
                lblRoomPayTPrice.Text = totprice.ToString();

                lblPDARoomDiscount.Text = txtRoomPayDiscount.Text;

                lblPDATotPrice.Text = lblRoomPayTPrice.Text;
            }
        }

        private void txtPayPayAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtPayPayAmount.Text == "")
            {
                return;
            }
            else
            {
                double totPrice = Convert.ToDouble(lblRoomPayTPrice.Text);
                double payAmount = Convert.ToDouble(txtPayPayAmount.Text);

                double res = payAmount - totPrice;
                lblPayBalance.Text = res.ToString();
            }
        }

        string CName;
        string CAddressNo;
        string CAddressLine1;
        string CAddressLine2;
        string CAddressCity;
        string ContactLandNo;
        string ContactMobileNo;
        string Email;

        private void btnBookingPaySubmit_Click(object sender, EventArgs e)
        {
            if (txtRoomPayDiscount.Text == "" || txtPayPayAmount.Text == "")
            {
                MessageBox.Show("Please Enter Discount And PayAmount! If you no enter the discount Please enter the value of '0'.");
            }
            else
            {
                grbBookingPayInvoice1.Visible = true;
                btnBookingPayClear.Enabled = false;
                btnBookingPaySubmit.Enabled = false;
                btnBookingUpdate.Enabled = false;
                lblPDBillNo.Text = counter;
                InvoicePrint.titancess.A.Text = counter;

                con.Open();
                SqlCommand cmd1 = new SqlCommand("select * from CompanyTB where ID = 1", con);
                SqlDataReader srd1 = cmd1.ExecuteReader();
                while (srd1.Read())
                {
                    InvoicePrint.titancess.C.Text = CName = srd1.GetValue(1).ToString();
                    CAddressNo = srd1.GetValue(2).ToString();
                    CAddressLine1 = srd1.GetValue(3).ToString();
                    CAddressLine2 = srd1.GetValue(4).ToString();
                    InvoicePrint.titancess.D.Text = CAddressCity = srd1.GetValue(5).ToString();
                    InvoicePrint.titancess.EG.Text =  ContactLandNo = srd1.GetValue(6).ToString();
                    ContactMobileNo = srd1.GetValue(7).ToString();
                    Email = srd1.GetValue(8).ToString();
                }

                con.Close();

                Invoicedatachanger();
            }
        }

        private void btnBookingPayClear_Click(object sender, EventArgs e)
        {
            txtRoomPayDiscount.Clear();
            txtPayPayAmount.Clear();
        }

        private void btnPayInvoiceCancel_Click(object sender, EventArgs e)
        {
            clearall();
            grbBookingPayInvoice1.Visible = false;
            grbDashPayment.Visible = false;
            btnBookingPaySubmit.Enabled = true;
            btnBookingUpdate.Enabled = true;
            btnBookingPayClear.Enabled = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (grbBookingPayInvoice1.Visible == true && grbPayPayDetails.Visible == true && grbPayPreviewDetails.Visible == true)
            {
                grbBookingPayInvoice1.Visible = false;
                btnBookingPayClear.Enabled = true;
                btnBookingPaySubmit.Enabled = true;
                btnBookingUpdate.Enabled = true;
                loadBIdcounting();
            }
            else if (grbPayPayDetails.Visible == true && grbPayPreviewDetails.Visible == true)
            {
                grbDashPayment.Visible = false;
                btnBookingPayClear.Enabled = true;
                btnBookingPaySubmit.Enabled = true;
                btnBookingUpdate.Enabled = true;
            }
        }

        private void Invoicedatachanger()
        {
            InvoiceCustomerName.Text = lblPDName.Text ;
            InvoiceCustomerANo.Text = lblPDANo.Text ;
            InvoiceCustomerAAd.Text = lblPDALine1.Text ;
            InvoiceCustomerAcity.Text = lblPDACity.Text;
            InvoiceCustomerNIC.Text = lblPDNIC.Text;
            InvoiceCustomerMobile.Text = lblPDMobileNo.Text;
            InvoicveCompanyAdNo.Text = CAddressNo;
            InvoicveCompanyAd.Text = CAddressLine1 + ", " + CAddressLine2;
            InvoicveCompanyAdCity.Text = CAddressCity;
            InvoicveCompanyName.Text = CName;
            InvoicveCompanyEmail.Text = Email;
            InvoicveCompanyNumber.Text = ContactLandNo + "/" + ContactMobileNo;
            InvoiceTotRoomPrice.Text = InvoicveTotPrice.Text = lblPDATotPrice.Text;
            InvoicveRoomNo.Text = "Room " + lblPDARoomNo.Text;
            InvoiceDates.Text = lblPDACheckInDate.Text + " " + " To " + " " + lblPDACheckOutDate.Text;
            InvoiceRoomType.Text = lblBookingRType.Text;
            InvoiceRoomPrice.Text = lblBookingRPrice.Text;
            InvoiceRoomDiscount.Text = lblPDARoomDiscount.Text;
            InvoiceDateofNow.Text = lblDate.Text;
            InvoiceCompanyName.Text = CName;
            
        }

        public void billprint()
        {
            InvoicePrint.titancess.B.Text = DateTime.Now.ToShortDateString();
            InvoicePrint.titancess.F.Text = lblPDATotPrice.Text;
            InvoicePrint.titancess.G.Text = lblPDACheckInDate.Text;
            InvoicePrint.titancess.H.Text = lblPDACheckOutDate.Text;
            InvoicePrint.titancess.I.Text = lblPDARoomDiscount.Text;
            int cc = Convert.ToInt32(lblPDATotPrice.Text);
            int cd = Convert.ToInt32(lblPDARoomDiscount.Text);
            int cr = cc - cd;
            InvoicePrint.titancess.K.Text = Convert.ToString(cr);
            InvoicePrint.titancess.L.Text = txtPayPayAmount.Text;
            int op = Convert.ToInt32(txtPayPayAmount.Text);
            int os = op - cr;
            InvoicePrint.titancess.M.Text = Convert.ToString(os);
        }

        private void pnlInvoice_Paint(object sender, PaintEventArgs e)
        {
            Graphics grp = this.pnlInvoice.CreateGraphics();
            Pen blackPen = new Pen(Color.Goldenrod, 1);

            PointF pnt1 = new PointF(545.0F, 170.0F);
            PointF pnt2 = new PointF(025.0F, 170.0F);
            e.Graphics.DrawLine(blackPen, pnt1, pnt2);
        }

        //Print Invoice

        private void btnPayInvoicePrint_Click(object sender, EventArgs e)
        {
            grbDashPayment.Enabled = false;
            billidnumberchecker();
            billprint();

            int billIDnum = Convert.ToInt32(BillIdnumber);

            if (txtCustomerID.Text == "")
            {
                return;
            }
            else
            {
                int CusBillChecker = Convert.ToInt32(txtCustomerID.Text);

                if (billIDnum == CusBillChecker)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update CustomerTB set NowDate= @NowDate, NowTime= @NowTime, Name= @Name,RoomNo= @RoomNo, NIC= @NIC,Gender= @Gender,Birthday= @Birthday,AdNo= @AdNo,AdLine1= @AdLine1,AdLine2= @AdLine2,City= @City, MobileNo= @MobileNo, Email= @Email,CheckInDate= @CheckInDate,CheckOutDate= @CheckOutDate, TotPrice= @TotPrice where ID= @ID", con);
                    cmd.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                    cmd.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                    cmd.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                    cmd.Parameters.AddWithValue("@Name", txtCustomerName.Text);
                    cmd.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                    cmd.Parameters.AddWithValue("@NIC", txtCustomerNIC.Text);
                    cmd.Parameters.AddWithValue("@Gender", cmbCustomerGender.SelectedItem);
                    cmd.Parameters.AddWithValue("@Birthday", DateTime.Parse(dtCustomerBirthday.Value.ToString()));
                    cmd.Parameters.AddWithValue("@AdNo", txtCustomerAdNo.Text);
                    cmd.Parameters.AddWithValue("@AdLine1", txtCustomerAddress1.Text);
                    cmd.Parameters.AddWithValue("@AdLine2", txtCustomerAddress2.Text);
                    cmd.Parameters.AddWithValue("@City", txtCustomerAdCity.Text);
                    cmd.Parameters.AddWithValue("@MobileNo", int.Parse(txtCustomerMobileNo.Text));
                    cmd.Parameters.AddWithValue("@Email", txtCustomerAdEmail.Text);
                    cmd.Parameters.AddWithValue("@CheckInDate", DateTime.Parse(dtCustomerCheckIn.Value.ToString()));
                    cmd.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                    cmd.Parameters.AddWithValue("@TotPrice", float.Parse(lblPDATotPrice.Text));
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("update CustomerMTB set NowDate= @NowDate, NowTime= @NowTime, Name= @Name,RoomNo= @RoomNo, NIC= @NIC,Gender= @Gender,Birthday= @Birthday,AdNo= @AdNo,AdLine1= @AdLine1,AdLine2= @AdLine2,City= @City, MobileNo= @MobileNo, Email= @Email,CheckInDate= @CheckInDate,CheckOutDate= @CheckOutDate, TotPrice= @TotPrice where ID= @ID", con);
                    cmd1.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                    cmd1.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                    cmd1.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                    cmd1.Parameters.AddWithValue("@Name", txtCustomerName.Text);
                    cmd1.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                    cmd1.Parameters.AddWithValue("@NIC", txtCustomerNIC.Text);
                    cmd1.Parameters.AddWithValue("@Gender", cmbCustomerGender.SelectedItem);
                    cmd1.Parameters.AddWithValue("@Birthday", DateTime.Parse(dtCustomerBirthday.Value.ToString()));
                    cmd1.Parameters.AddWithValue("@AdNo", txtCustomerAdNo.Text);
                    cmd1.Parameters.AddWithValue("@AdLine1", txtCustomerAddress1.Text);
                    cmd1.Parameters.AddWithValue("@AdLine2", txtCustomerAddress2.Text);
                    cmd1.Parameters.AddWithValue("@City", txtCustomerAdCity.Text);
                    cmd1.Parameters.AddWithValue("@MobileNo", int.Parse(txtCustomerMobileNo.Text));
                    cmd1.Parameters.AddWithValue("@Email", txtCustomerAdEmail.Text);
                    cmd1.Parameters.AddWithValue("@CheckInDate", DateTime.Parse(dtCustomerCheckIn.Value.ToString()));
                    cmd1.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                    cmd1.Parameters.AddWithValue("@TotPrice", float.Parse(lblPDATotPrice.Text));
                    cmd1.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("update PaymentDetailsTB set NowDate= @NowDate, NowTime= @NowTime, RoomNo= @RoomNo, CustomerName= @CustomerName,  CustomerNIC= @CustomerNIC, CheckOutDate= @CheckOutDate, BillID= @BillID,Price= @Price,Discount= @Discount,TotalAmount= @TotalAmount,PayAmount= @PayAmount,Balance= @Balance  where ID= @ID", con);
                    cmd2.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                    cmd2.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                    cmd2.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                    cmd2.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                    cmd2.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cmd2.Parameters.AddWithValue("@CustomerNIC", txtCustomerNIC.Text);
                    cmd2.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                    if (BIDcounter == null)
                    {
                        BIDcounter = "1";
                        cmd2.Parameters.AddWithValue("@BillID", int.Parse(BIDcounter));
                    }
                    else
                    {
                        cmd2.Parameters.AddWithValue("@BillID", int.Parse(BIDcounter));
                    }
                    cmd2.Parameters.AddWithValue("@Price", float.Parse(lblPDARoomPrice.Text));
                    cmd2.Parameters.AddWithValue("@Discount", float.Parse(lblPDARoomDiscount.Text));
                    cmd2.Parameters.AddWithValue("@TotalAmount", float.Parse(lblPDATotPrice.Text));
                    cmd2.Parameters.AddWithValue("@PayAmount", float.Parse(txtPayPayAmount.Text));
                    cmd2.Parameters.AddWithValue("@Balance", float.Parse(lblPayBalance.Text));
                    cmd2.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd3 = new SqlCommand("update PaymentDetailsMTB set NowDate= @NowDate, NowTime= @NowTime, RoomNo= @RoomNo, CustomerName= @CustomerName,  CustomerNIC= @CustomerNIC, CheckOutDate= @CheckOutDate, BillID= @BillID,Price= @Price,Discount= @Discount,TotalAmount= @TotalAmount,PayAmount= @PayAmount,Balance= @Balance  where ID= @ID", con);
                    cmd3.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                    cmd3.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                    cmd3.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                    cmd3.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                    cmd3.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cmd3.Parameters.AddWithValue("@CustomerNIC", txtCustomerNIC.Text);
                    cmd3.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                    if (BIDcounter == null)
                    {
                        BIDcounter = "1";
                        cmd3.Parameters.AddWithValue("@BillID", int.Parse(BIDcounter));
                    }
                    else
                    {
                        cmd3.Parameters.AddWithValue("@BillID", int.Parse(BIDcounter));
                    }
                    cmd3.Parameters.AddWithValue("@Price", float.Parse(lblPDARoomPrice.Text));
                    cmd3.Parameters.AddWithValue("@Discount", float.Parse(lblPDARoomDiscount.Text));
                    cmd3.Parameters.AddWithValue("@TotalAmount", float.Parse(lblPDATotPrice.Text));
                    cmd3.Parameters.AddWithValue("@PayAmount", float.Parse(txtPayPayAmount.Text));
                    cmd3.Parameters.AddWithValue("@Balance", float.Parse(lblPayBalance.Text));
                    cmd3.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd4 = new SqlCommand("update RoomsRTB set NowDate= @NowDate, NowTime= @NowTime, RoomNo= @RoomNo, CustomerName= @CustomerName, CustomerNIC= @CustomerNIC, CheckOutDate= @CheckOutDate, RoomName= @RoomName, RoomType= @RoomType, RoomPrice= @RoomPrice where ID= @ID", con);
                    cmd4.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                    cmd4.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                    cmd4.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                    cmd4.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                    cmd4.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cmd4.Parameters.AddWithValue("@CustomerNIC", txtCustomerNIC.Text);
                    cmd4.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                    cmd4.Parameters.AddWithValue("@RoomName", lblBookingRName.Text);
                    cmd4.Parameters.AddWithValue("@RoomType", lblBookingRType.Text);
                    cmd4.Parameters.AddWithValue("@RoomPrice", float.Parse(lblBookingRPrice.Text));
                    cmd4.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd5 = new SqlCommand("update RoomsMRTB set NowDate= @NowDate, NowTime= @NowTime, RoomNo= @RoomNo, CustomerName= @CustomerName, CustomerNIC= @CustomerNIC, CheckOutDate= @CheckOutDate, RoomName= @RoomName, RoomType= @RoomType, RoomPrice= @RoomPrice where ID= @ID", con);
                    cmd5.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                    cmd5.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                    cmd5.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                    cmd5.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                    cmd5.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cmd5.Parameters.AddWithValue("@CustomerNIC", txtCustomerNIC.Text);
                    cmd5.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                    cmd5.Parameters.AddWithValue("@RoomName", lblBookingRName.Text);
                    cmd5.Parameters.AddWithValue("@RoomType", lblBookingRType.Text);
                    cmd5.Parameters.AddWithValue("@RoomPrice", float.Parse(lblBookingRPrice.Text));
                    cmd5.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Sucessfull Updated!", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    loadRoomNo();
                    getitemsbydate();

                    invoicePrint1.Visible = true;
                }
                else
                {
                    /*int IdMaster = Convert.ToInt32(txtCustomerID.Text);
                    int CIDcount = Convert.ToInt32(CIDcounter);
                    if (IdMaster != CIDcount)
                    {
                        MessageBox.Show("Please Enter Top Of Id Number to Submit!");
                    }
                    else
                    {*/
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into CustomerTB values (@ID,@NowDate,@NowTime,@Name,@RoomNo,@NIC,@Gender,@Birthday,@AdNo,@AdLine1,@AdLine2,@City,@MobileNo,@Email,@CheckInDate,@CheckOutDate,@TotPrice)", con);
                    cmd.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                    cmd.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                    cmd.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                    cmd.Parameters.AddWithValue("@Name", txtCustomerName.Text);
                    cmd.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                    cmd.Parameters.AddWithValue("@NIC", txtCustomerNIC.Text);
                    cmd.Parameters.AddWithValue("@Gender", cmbCustomerGender.SelectedItem);
                    cmd.Parameters.AddWithValue("@Birthday", DateTime.Parse(dtCustomerBirthday.Value.ToString()));
                    cmd.Parameters.AddWithValue("@AdNo", txtCustomerAdNo.Text);
                    cmd.Parameters.AddWithValue("@AdLine1", txtCustomerAddress1.Text);
                    cmd.Parameters.AddWithValue("@AdLine2", txtCustomerAddress2.Text);
                    cmd.Parameters.AddWithValue("@City", txtCustomerAdCity.Text);
                    cmd.Parameters.AddWithValue("@MobileNo", int.Parse(txtCustomerMobileNo.Text));
                    cmd.Parameters.AddWithValue("@Email", txtCustomerAdEmail.Text);
                    cmd.Parameters.AddWithValue("@CheckInDate", DateTime.Parse(dtCustomerCheckIn.Value.ToString()));
                    cmd.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                    cmd.Parameters.AddWithValue("@TotPrice", float.Parse(lblPDATotPrice.Text));
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("insert into CustomerMTB values (@ID,@NowDate,@NowTime,@Name,@RoomNo,@NIC,@Gender,@Birthday,@AdNo,@AdLine1,@AdLine2,@City,@MobileNo,@Email,@CheckInDate,@CheckOutDate,@TotPrice)", con);
                    cmd1.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                    cmd1.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                    cmd1.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                    cmd1.Parameters.AddWithValue("@Name", txtCustomerName.Text);
                    cmd1.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                    cmd1.Parameters.AddWithValue("@NIC", txtCustomerNIC.Text);
                    cmd1.Parameters.AddWithValue("@Gender", cmbCustomerGender.SelectedItem);
                    cmd1.Parameters.AddWithValue("@Birthday", DateTime.Parse(dtCustomerBirthday.Value.ToString()));
                    cmd1.Parameters.AddWithValue("@AdNo", txtCustomerAdNo.Text);
                    cmd1.Parameters.AddWithValue("@AdLine1", txtCustomerAddress1.Text);
                    cmd1.Parameters.AddWithValue("@AdLine2", txtCustomerAddress2.Text);
                    cmd1.Parameters.AddWithValue("@City", txtCustomerAdCity.Text);
                    cmd1.Parameters.AddWithValue("@MobileNo", int.Parse(txtCustomerMobileNo.Text));
                    cmd1.Parameters.AddWithValue("@Email", txtCustomerAdEmail.Text);
                    cmd1.Parameters.AddWithValue("@CheckInDate", DateTime.Parse(dtCustomerCheckIn.Value.ToString()));
                    cmd1.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                    cmd1.Parameters.AddWithValue("@TotPrice", float.Parse(lblPDATotPrice.Text));
                    cmd1.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("insert into PaymentDetailsTB values (@ID,@NowDate,@NowTime,@RoomNo,@CustomerName,@CustomerNIC,@CheckOutDate,@BillID,@Price,@Discount,@TotalAmount,@PayAmount,@Balance)", con);
                    cmd2.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                    cmd2.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                    cmd2.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                    cmd2.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                    cmd2.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cmd2.Parameters.AddWithValue("@CustomerNIC", txtCustomerNIC.Text);
                    cmd2.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                    if (BIDcounter == null)
                    {
                        BIDcounter = "1";
                        cmd2.Parameters.AddWithValue("@BillID", int.Parse(BIDcounter));
                    }
                    else
                    {
                        cmd2.Parameters.AddWithValue("@BillID", int.Parse(BIDcounter));
                    }
                    cmd2.Parameters.AddWithValue("@Price", float.Parse(lblPDARoomPrice.Text));
                    cmd2.Parameters.AddWithValue("@Discount", float.Parse(lblPDARoomDiscount.Text));
                    cmd2.Parameters.AddWithValue("@TotalAmount", float.Parse(lblPDATotPrice.Text));
                    cmd2.Parameters.AddWithValue("@PayAmount", float.Parse(txtPayPayAmount.Text));
                    cmd2.Parameters.AddWithValue("@Balance", float.Parse(lblPayBalance.Text));
                    cmd2.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd3 = new SqlCommand("insert into PaymentDetailsMTB values (@ID,@NowDate,@NowTime,@RoomNo,@CustomerName,@CustomerNIC,@CheckOutDate,@BillID,@Price,@Discount,@TotalAmount,@PayAmount,@Balance)", con);
                    cmd3.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                    cmd3.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                    cmd3.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                    cmd3.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                    cmd3.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cmd3.Parameters.AddWithValue("@CustomerNIC", txtCustomerNIC.Text);
                    cmd3.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                    if (BIDcounter == null)
                    {
                        BIDcounter = "1";
                        cmd3.Parameters.AddWithValue("@BillID", int.Parse(BIDcounter));
                    }
                    else
                    {
                        cmd3.Parameters.AddWithValue("@BillID", int.Parse(BIDcounter));
                    }
                    cmd3.Parameters.AddWithValue("@Price", float.Parse(lblPDARoomPrice.Text));
                    cmd3.Parameters.AddWithValue("@Discount", float.Parse(lblPDARoomDiscount.Text));
                    cmd3.Parameters.AddWithValue("@TotalAmount", float.Parse(lblPDATotPrice.Text));
                    cmd3.Parameters.AddWithValue("@PayAmount", float.Parse(txtPayPayAmount.Text));
                    cmd3.Parameters.AddWithValue("@Balance", float.Parse(lblPayBalance.Text));
                    cmd3.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd4 = new SqlCommand("insert into RoomsRTB values (@ID,@NowDate,@NowTime,@RoomNo,@CustomerName,@CustomerNIC,@CheckOutDate,@RoomName,@RoomType,@RoomPrice)", con);
                    cmd4.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                    cmd4.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                    cmd4.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                    cmd4.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                    cmd4.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cmd4.Parameters.AddWithValue("@CustomerNIC", txtCustomerNIC.Text);
                    cmd4.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                    cmd4.Parameters.AddWithValue("@RoomName", lblBookingRName.Text);
                    cmd4.Parameters.AddWithValue("@RoomType", lblBookingRType.Text);
                    cmd4.Parameters.AddWithValue("@RoomPrice", float.Parse(lblBookingRPrice.Text));
                    cmd4.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd5 = new SqlCommand("insert into RoomsMRTB values (@ID,@NowDate,@NowTime,@RoomNo,@CustomerName,@CustomerNIC,@CheckOutDate,@RoomName,@RoomType,@RoomPrice)", con);
                    cmd5.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                    cmd5.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                    cmd5.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                    cmd5.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                    cmd5.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cmd5.Parameters.AddWithValue("@CustomerNIC", txtCustomerNIC.Text);
                    cmd5.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                    cmd5.Parameters.AddWithValue("@RoomName", lblBookingRName.Text);
                    cmd5.Parameters.AddWithValue("@RoomType", lblBookingRType.Text);
                    cmd5.Parameters.AddWithValue("@RoomPrice", float.Parse(lblBookingRPrice.Text));
                    cmd5.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Adding Sucessfull!", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    loadRoomNo();
                    getitemsbydate();

                    invoicePrint1.Visible = true;

                    //}

                }

            }

            
        }

        private void btnPayInvoicePrint_MouseHover(object sender, EventArgs e)
        {
        }

        private void printPnl(Panel pnl)
        {

        }

        //Update Or Add In Databace for Customer Vlaues

        string BillIdnumber;

        public void billidnumberchecker()
        {
            if (txtCustomerID.Text == "")
            {
                return;
            }
            else
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select * from PaymentDetailsTB where ID ='" + int.Parse(txtCustomerID.Text) + "' ", con);
                SqlDataReader srd1 = cmd1.ExecuteReader();
                while (srd1.Read())
                {
                    BillIdnumber = srd1.GetValue(0).ToString();
                }
                con.Close();
            }
        }

        private void btnPayInvoiceSubmit_Click(object sender, EventArgs e)
        {
            billidnumberchecker();

            int billIDnum = Convert.ToInt32(BillIdnumber);

            if (txtCustomerID.Text == "")
            {
                return;
            }
            else
            {
                int CusBillChecker = Convert.ToInt32(txtCustomerID.Text);

                if (billIDnum == CusBillChecker)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update CustomerTB set NowDate= @NowDate, NowTime= @NowTime, Name= @Name,RoomNo= @RoomNo, NIC= @NIC,Gender= @Gender,Birthday= @Birthday,AdNo= @AdNo,AdLine1= @AdLine1,AdLine2= @AdLine2,City= @City, MobileNo= @MobileNo, Email= @Email,CheckInDate= @CheckInDate,CheckOutDate= @CheckOutDate, TotPrice= @TotPrice where ID= @ID", con);
                    cmd.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                    cmd.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                    cmd.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                    cmd.Parameters.AddWithValue("@Name", txtCustomerName.Text);
                    cmd.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                    cmd.Parameters.AddWithValue("@NIC", txtCustomerNIC.Text);
                    cmd.Parameters.AddWithValue("@Gender", cmbCustomerGender.SelectedItem);
                    cmd.Parameters.AddWithValue("@Birthday", DateTime.Parse(dtCustomerBirthday.Value.ToString()));
                    cmd.Parameters.AddWithValue("@AdNo", txtCustomerAdNo.Text);
                    cmd.Parameters.AddWithValue("@AdLine1", txtCustomerAddress1.Text);
                    cmd.Parameters.AddWithValue("@AdLine2", txtCustomerAddress2.Text);
                    cmd.Parameters.AddWithValue("@City", txtCustomerAdCity.Text);
                    cmd.Parameters.AddWithValue("@MobileNo", int.Parse(txtCustomerMobileNo.Text));
                    cmd.Parameters.AddWithValue("@Email", txtCustomerAdEmail.Text);
                    cmd.Parameters.AddWithValue("@CheckInDate", DateTime.Parse(dtCustomerCheckIn.Value.ToString()));
                    cmd.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                    cmd.Parameters.AddWithValue("@TotPrice", float.Parse(lblPDATotPrice.Text));
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("update CustomerMTB set NowDate= @NowDate, NowTime= @NowTime, Name= @Name,RoomNo= @RoomNo, NIC= @NIC,Gender= @Gender,Birthday= @Birthday,AdNo= @AdNo,AdLine1= @AdLine1,AdLine2= @AdLine2,City= @City, MobileNo= @MobileNo, Email= @Email,CheckInDate= @CheckInDate,CheckOutDate= @CheckOutDate, TotPrice= @TotPrice where ID= @ID", con);
                    cmd1.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                    cmd1.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                    cmd1.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                    cmd1.Parameters.AddWithValue("@Name", txtCustomerName.Text);
                    cmd1.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                    cmd1.Parameters.AddWithValue("@NIC", txtCustomerNIC.Text);
                    cmd1.Parameters.AddWithValue("@Gender", cmbCustomerGender.SelectedItem);
                    cmd1.Parameters.AddWithValue("@Birthday", DateTime.Parse(dtCustomerBirthday.Value.ToString()));
                    cmd1.Parameters.AddWithValue("@AdNo", txtCustomerAdNo.Text);
                    cmd1.Parameters.AddWithValue("@AdLine1", txtCustomerAddress1.Text);
                    cmd1.Parameters.AddWithValue("@AdLine2", txtCustomerAddress2.Text);
                    cmd1.Parameters.AddWithValue("@City", txtCustomerAdCity.Text);
                    cmd1.Parameters.AddWithValue("@MobileNo", int.Parse(txtCustomerMobileNo.Text));
                    cmd1.Parameters.AddWithValue("@Email", txtCustomerAdEmail.Text);
                    cmd1.Parameters.AddWithValue("@CheckInDate", DateTime.Parse(dtCustomerCheckIn.Value.ToString()));
                    cmd1.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                    cmd1.Parameters.AddWithValue("@TotPrice", float.Parse(lblPDATotPrice.Text));
                    cmd1.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("update PaymentDetailsTB set NowDate= @NowDate, NowTime= @NowTime, RoomNo= @RoomNo, CustomerName= @CustomerName,  CustomerNIC= @CustomerNIC, CheckOutDate= @CheckOutDate, BillID= @BillID,Price= @Price,Discount= @Discount,TotalAmount= @TotalAmount,PayAmount= @PayAmount,Balance= @Balance  where ID= @ID", con);
                    cmd2.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                    cmd2.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                    cmd2.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                    cmd2.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                    cmd2.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cmd2.Parameters.AddWithValue("@CustomerNIC", txtCustomerNIC.Text);
                    cmd2.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                    if (BIDcounter == null)
                    {
                        BIDcounter = "1";
                        cmd2.Parameters.AddWithValue("@BillID", int.Parse(BIDcounter));
                    }
                    else
                    {
                        cmd2.Parameters.AddWithValue("@BillID", int.Parse(BIDcounter));
                    }
                    cmd2.Parameters.AddWithValue("@Price", float.Parse(lblPDARoomPrice.Text));
                    cmd2.Parameters.AddWithValue("@Discount", float.Parse(lblPDARoomDiscount.Text));
                    cmd2.Parameters.AddWithValue("@TotalAmount", float.Parse(lblPDATotPrice.Text));
                    cmd2.Parameters.AddWithValue("@PayAmount", float.Parse(txtPayPayAmount.Text));
                    cmd2.Parameters.AddWithValue("@Balance", float.Parse(lblPayBalance.Text));
                    cmd2.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd3 = new SqlCommand("update PaymentDetailsMTB set NowDate= @NowDate, NowTime= @NowTime, RoomNo= @RoomNo, CustomerName= @CustomerName,  CustomerNIC= @CustomerNIC, CheckOutDate= @CheckOutDate, BillID= @BillID,Price= @Price,Discount= @Discount,TotalAmount= @TotalAmount,PayAmount= @PayAmount,Balance= @Balance  where ID= @ID", con);
                    cmd3.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                    cmd3.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                    cmd3.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                    cmd3.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                    cmd3.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cmd3.Parameters.AddWithValue("@CustomerNIC", txtCustomerNIC.Text);
                    cmd3.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                    if (BIDcounter == null)
                    {
                        BIDcounter = "1";
                        cmd3.Parameters.AddWithValue("@BillID", int.Parse(BIDcounter));
                    }
                    else
                    {
                        cmd3.Parameters.AddWithValue("@BillID", int.Parse(BIDcounter));
                    }
                    cmd3.Parameters.AddWithValue("@Price", float.Parse(lblPDARoomPrice.Text));
                    cmd3.Parameters.AddWithValue("@Discount", float.Parse(lblPDARoomDiscount.Text));
                    cmd3.Parameters.AddWithValue("@TotalAmount", float.Parse(lblPDATotPrice.Text));
                    cmd3.Parameters.AddWithValue("@PayAmount", float.Parse(txtPayPayAmount.Text));
                    cmd3.Parameters.AddWithValue("@Balance", float.Parse(lblPayBalance.Text));
                    cmd3.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd4 = new SqlCommand("update RoomsRTB set NowDate= @NowDate, NowTime= @NowTime, RoomNo= @RoomNo, CustomerName= @CustomerName, CustomerNIC= @CustomerNIC, CheckOutDate= @CheckOutDate, RoomName= @RoomName, RoomType= @RoomType, RoomPrice= @RoomPrice where ID= @ID", con);
                    cmd4.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                    cmd4.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                    cmd4.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                    cmd4.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                    cmd4.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cmd4.Parameters.AddWithValue("@CustomerNIC", txtCustomerNIC.Text);
                    cmd4.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                    cmd4.Parameters.AddWithValue("@RoomName", lblBookingRName.Text);
                    cmd4.Parameters.AddWithValue("@RoomType", lblBookingRType.Text);
                    cmd4.Parameters.AddWithValue("@RoomPrice", float.Parse(lblBookingRPrice.Text));
                    cmd4.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    SqlCommand cmd5 = new SqlCommand("update RoomsMRTB set NowDate= @NowDate, NowTime= @NowTime, RoomNo= @RoomNo, CustomerName= @CustomerName, CustomerNIC= @CustomerNIC, CheckOutDate= @CheckOutDate, RoomName= @RoomName, RoomType= @RoomType, RoomPrice= @RoomPrice where ID= @ID", con);
                    cmd5.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                    cmd5.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                    cmd5.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                    cmd5.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                    cmd5.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cmd5.Parameters.AddWithValue("@CustomerNIC", txtCustomerNIC.Text);
                    cmd5.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                    cmd5.Parameters.AddWithValue("@RoomName", lblBookingRName.Text);
                    cmd5.Parameters.AddWithValue("@RoomType", lblBookingRType.Text);
                    cmd5.Parameters.AddWithValue("@RoomPrice", float.Parse(lblBookingRPrice.Text));
                    cmd5.ExecuteNonQuery();
                    con.Close();

                    loadRoomNo();
                    getitemsbydate();

                    MessageBox.Show("Sucessfull Updated!", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    clearall();
                    grbBookingPayInvoice1.Visible = false;
                    grbDashPayment.Visible = false;
                    btnBookingPaySubmit.Enabled = true;
                    btnBookingUpdate.Enabled = true;
                    btnBookingPayClear.Enabled = true;
                }
                else
                {
                    /*int IdMaster = Convert.ToInt32(txtCustomerID.Text);
                    int CIDcount = Convert.ToInt32(CIDcounter);
                    if (IdMaster != CIDcount)
                    {
                        MessageBox.Show("Please Enter Top Of Id Number to Submit!");
                    }
                    else
                    {*/
                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into CustomerTB values (@ID,@NowDate,@NowTime,@Name,@RoomNo,@NIC,@Gender,@Birthday,@AdNo,@AdLine1,@AdLine2,@City,@MobileNo,@Email,@CheckInDate,@CheckOutDate,@TotPrice)", con);
                        cmd.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                        cmd.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                        cmd.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                        cmd.Parameters.AddWithValue("@Name", txtCustomerName.Text);
                        cmd.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                        cmd.Parameters.AddWithValue("@NIC", txtCustomerNIC.Text);
                        cmd.Parameters.AddWithValue("@Gender", cmbCustomerGender.SelectedItem);
                        cmd.Parameters.AddWithValue("@Birthday", DateTime.Parse(dtCustomerBirthday.Value.ToString()));
                        cmd.Parameters.AddWithValue("@AdNo", txtCustomerAdNo.Text);
                        cmd.Parameters.AddWithValue("@AdLine1", txtCustomerAddress1.Text);
                        cmd.Parameters.AddWithValue("@AdLine2", txtCustomerAddress2.Text);
                        cmd.Parameters.AddWithValue("@City", txtCustomerAdCity.Text);
                        cmd.Parameters.AddWithValue("@MobileNo", int.Parse(txtCustomerMobileNo.Text));
                        cmd.Parameters.AddWithValue("@Email", txtCustomerAdEmail.Text);
                        cmd.Parameters.AddWithValue("@CheckInDate", DateTime.Parse(dtCustomerCheckIn.Value.ToString()));
                        cmd.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                        cmd.Parameters.AddWithValue("@TotPrice", float.Parse(lblPDATotPrice.Text));
                        cmd.ExecuteNonQuery();
                        con.Close();

                        con.Open();
                        SqlCommand cmd1 = new SqlCommand("insert into CustomerMTB values (@ID,@NowDate,@NowTime,@Name,@RoomNo,@NIC,@Gender,@Birthday,@AdNo,@AdLine1,@AdLine2,@City,@MobileNo,@Email,@CheckInDate,@CheckOutDate,@TotPrice)", con);
                        cmd1.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                        cmd1.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                        cmd1.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                        cmd1.Parameters.AddWithValue("@Name", txtCustomerName.Text);
                        cmd1.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                        cmd1.Parameters.AddWithValue("@NIC", txtCustomerNIC.Text);
                        cmd1.Parameters.AddWithValue("@Gender", cmbCustomerGender.SelectedItem);
                        cmd1.Parameters.AddWithValue("@Birthday", DateTime.Parse(dtCustomerBirthday.Value.ToString()));
                        cmd1.Parameters.AddWithValue("@AdNo", txtCustomerAdNo.Text);
                        cmd1.Parameters.AddWithValue("@AdLine1", txtCustomerAddress1.Text);
                        cmd1.Parameters.AddWithValue("@AdLine2", txtCustomerAddress2.Text);
                        cmd1.Parameters.AddWithValue("@City", txtCustomerAdCity.Text);
                        cmd1.Parameters.AddWithValue("@MobileNo", int.Parse(txtCustomerMobileNo.Text));
                        cmd1.Parameters.AddWithValue("@Email", txtCustomerAdEmail.Text);
                        cmd1.Parameters.AddWithValue("@CheckInDate", DateTime.Parse(dtCustomerCheckIn.Value.ToString()));
                        cmd1.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                        cmd1.Parameters.AddWithValue("@TotPrice", float.Parse(lblPDATotPrice.Text));
                        cmd1.ExecuteNonQuery();
                        con.Close();

                        con.Open();
                        SqlCommand cmd2 = new SqlCommand("insert into PaymentDetailsTB values (@ID,@NowDate,@NowTime,@RoomNo,@CustomerName,@CustomerNIC,@CheckOutDate,@BillID,@Price,@Discount,@TotalAmount,@PayAmount,@Balance)", con);
                        cmd2.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                        cmd2.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                        cmd2.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                        cmd2.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                        cmd2.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                        cmd2.Parameters.AddWithValue("@CustomerNIC", txtCustomerNIC.Text);
                        cmd2.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                        if (BIDcounter == null)
                        {
                            BIDcounter = "1";
                            cmd2.Parameters.AddWithValue("@BillID", int.Parse(BIDcounter));
                        }
                        else
                        {
                            cmd2.Parameters.AddWithValue("@BillID", int.Parse(BIDcounter));
                        }
                        cmd2.Parameters.AddWithValue("@Price", float.Parse(lblPDARoomPrice.Text));
                        cmd2.Parameters.AddWithValue("@Discount", float.Parse(lblPDARoomDiscount.Text));
                        cmd2.Parameters.AddWithValue("@TotalAmount", float.Parse(lblPDATotPrice.Text));
                        cmd2.Parameters.AddWithValue("@PayAmount", float.Parse(txtPayPayAmount.Text));
                        cmd2.Parameters.AddWithValue("@Balance", float.Parse(lblPayBalance.Text));
                        cmd2.ExecuteNonQuery();
                        con.Close();

                        con.Open();
                        SqlCommand cmd3 = new SqlCommand("insert into PaymentDetailsMTB values (@ID,@NowDate,@NowTime,@RoomNo,@CustomerName,@CustomerNIC,@CheckOutDate,@BillID,@Price,@Discount,@TotalAmount,@PayAmount,@Balance)", con);
                        cmd3.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                        cmd3.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                        cmd3.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                        cmd3.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                        cmd3.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                        cmd3.Parameters.AddWithValue("@CustomerNIC", txtCustomerNIC.Text);
                        cmd3.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                        if (BIDcounter == null)
                        {
                            BIDcounter = "1";
                            cmd3.Parameters.AddWithValue("@BillID", int.Parse(BIDcounter));
                        }
                        else
                        {
                            cmd3.Parameters.AddWithValue("@BillID", int.Parse(BIDcounter));
                        }
                        cmd3.Parameters.AddWithValue("@Price", float.Parse(lblPDARoomPrice.Text));
                        cmd3.Parameters.AddWithValue("@Discount", float.Parse(lblPDARoomDiscount.Text));
                        cmd3.Parameters.AddWithValue("@TotalAmount", float.Parse(lblPDATotPrice.Text));
                        cmd3.Parameters.AddWithValue("@PayAmount", float.Parse(txtPayPayAmount.Text));
                        cmd3.Parameters.AddWithValue("@Balance", float.Parse(lblPayBalance.Text));
                        cmd3.ExecuteNonQuery();
                        con.Close();

                        con.Open();
                        SqlCommand cmd4 = new SqlCommand("insert into RoomsRTB values (@ID,@NowDate,@NowTime,@RoomNo,@CustomerName,@CustomerNIC,@CheckOutDate,@RoomName,@RoomType,@RoomPrice)", con);
                        cmd4.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                        cmd4.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                        cmd4.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                        cmd4.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                        cmd4.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                        cmd4.Parameters.AddWithValue("@CustomerNIC", txtCustomerNIC.Text);
                        cmd4.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                        cmd4.Parameters.AddWithValue("@RoomName", lblBookingRName.Text);
                        cmd4.Parameters.AddWithValue("@RoomType", lblBookingRType.Text);
                        cmd4.Parameters.AddWithValue("@RoomPrice", float.Parse(lblBookingRPrice.Text));
                        cmd4.ExecuteNonQuery();
                        con.Close();

                        con.Open();
                        SqlCommand cmd5 = new SqlCommand("insert into RoomsMRTB values (@ID,@NowDate,@NowTime,@RoomNo,@CustomerName,@CustomerNIC,@CheckOutDate,@RoomName,@RoomType,@RoomPrice)", con);
                        cmd5.Parameters.AddWithValue("@ID", int.Parse(txtCustomerID.Text));
                        cmd5.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
                        cmd5.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
                        cmd5.Parameters.AddWithValue("@RoomNo", int.Parse(lblBookingRNo.Text));
                        cmd5.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                        cmd5.Parameters.AddWithValue("@CustomerNIC", txtCustomerNIC.Text);
                        cmd5.Parameters.AddWithValue("@CheckOutDate", DateTime.Parse(dtCustomerCheckOut.Value.ToString()));
                        cmd5.Parameters.AddWithValue("@RoomName", lblBookingRName.Text);
                        cmd5.Parameters.AddWithValue("@RoomType", lblBookingRType.Text);
                        cmd5.Parameters.AddWithValue("@RoomPrice", float.Parse(lblBookingRPrice.Text));
                        cmd5.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("Adding is Sucessfull!", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    loadRoomNo();
                    getitemsbydate();

                    clearall();

                        grbBookingPayInvoice1.Visible = false;
                        grbDashPayment.Visible = false;
                        btnBookingPaySubmit.Enabled = true;
                        btnBookingUpdate.Enabled = true;
                        btnBookingPayClear.Enabled = true;
                    
                    
                }

            }

            
        }

        private void linklblgobackCompanyInfoEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            grbDashReload.Visible = false;
            grbDashSummery.Visible = false;
            grbLogIn.Visible = true;
            lblLoginchangeble.Text = "Edit Info";
        }

        //Search values Customer

        private void searchCustomerNIC(string findValue1)
        {
            con.Open();
            string SearchQuarry = "select * from CustomerTB where CONCAT(NowDate,NIC,RoomNo,MobileNo,Email) LIKE '%" + findValue1 + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(SearchQuarry, con);
            DataTable ta = new DataTable();
            adapter.Fill(ta);
            dataGridViewCustomer.DataSource = ta;
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchCustomerDetailsbtID.Text == "")
            {
                CustomerGirdView();
                return;
            }
            else
            {
                searchCustomerNIC(txtSearchCustomerDetailsbtID.Text);
            }
        }

        //Search History Values
        private void SearchCustomerMTB(string findValue2)
        {
            string SearchQuarry = "select * from CustomerMTB where CONCAT(NowDate,RoomNo,Name,NIC,Email,CheckInDate,CheckOutDate) LIKE '%" + findValue2 + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(SearchQuarry, con);
            DataTable ta = new DataTable();
            adapter.Fill(ta);
            dataGridViewHistoryCustomer.DataSource = ta;
        }

        private void SearchRoomsMRTB(string findValue3)
        {
            string SearchQuarry = "select * from RoomsMRTB where CONCAT(NowDate,RoomNo,CustomerName,CustomerNIC) LIKE '%" + findValue3 + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(SearchQuarry, con);
            DataTable ta = new DataTable();
            adapter.Fill(ta);
            dataGridViewHistoryRoomsBooking.DataSource = ta;
        }

        private void SearchPaymentsDetailsMDB(string findValue4)
        {
            string SearchQuarry = "select * from PaymentDetailsMTB where CONCAT(NowDate,RoomNo,CustomerName,CustomerNIC,BillID) LIKE '%" + findValue4 + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(SearchQuarry, con);
            DataTable ta = new DataTable();
            adapter.Fill(ta);
            dataGridViewHistoryInvoices.DataSource = ta;
        }

        private void SearchHistoryDash_TextChanged(object sender, EventArgs e)
        {
            if (SearchHistoryDash.Text == "")
            {
                historygirdviews();
                return;
            }
            else
            {
                con.Open();
                SearchCustomerMTB(SearchHistoryDash.Text);
                SearchRoomsMRTB(SearchHistoryDash.Text);
                SearchPaymentsDetailsMDB(SearchHistoryDash.Text);
                con.Close();
            }
        }

        //Customer Booking Forcus List
        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCustomerName.Focus();
            }
        }

        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCustomerMobileNo.Focus();
            }
        }

        private void txtCustomerMobileNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCustomerNIC.Focus();
            }
        }

        private void txtCustomerNIC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtCustomerBirthday.Focus();
            }
        }

        private void dtCustomerBirthday_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCustomerAdNo.Focus();
            }
        }

        private void txtCustomerAdNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCustomerAddress1.Focus();
            }
        }

        private void txtCustomerAddress1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCustomerAddress2.Focus();
            }
        }

        private void txtCustomerAddress2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCustomerAdCity.Focus();
            }
        }

        private void dtCustomerCheckIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtCustomerCheckOut.Focus();
            }
        }

        private void dtCustomerCheckOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCustomerID.Text == "" || txtCustomerName.Text == "" || cmbCustomerRoNo.SelectedItem == null || txtCustomerMobileNo.Text == "" || txtCustomerNIC.Text == "" || cmbCustomerGender.SelectedItem == null || txtCustomerAdNo.Text == "" || txtCustomerAddress1.Text == "" || txtCustomerAddress2.Text == "" || txtCustomerAdCity.Text == "" || txtCustomerAdEmail.Text == "")
                {
                    MessageBox.Show("Please Enter The Values", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    grbDashPayment.Visible = false;
                    grbDashBook.Visible = true;
                    txtCustomerID.Focus();
                    return;
                }
                else
                {
                    checkAlwaysAddRooms();
                    //loadBIdcounting();

                    int bookRoom = Convert.ToInt32(AlwaysBookRooms);
                    int IdCheckerMaster = Convert.ToInt32(Idchecker);

                    if (txtCustomerID.Text == "")
                    {
                        return;
                    }
                    else
                    {
                        int IdMaster = Convert.ToInt32(txtCustomerID.Text);
                        int CIDcount = Convert.ToInt32(CIDcounter);
                        if (IdCheckerMaster == IdMaster)
                        {
                            if (lblEmailErrorProvider.Visible == true)
                            {
                                MessageBox.Show("Please Check Import Details!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                grbDashPayment.Visible = true;
                                grbBookingPayInvoice1.Visible = false;
                                returnValue();
                                getpaymentdetails();
                            }
                        }
                        else
                        {
                            if (lblBookingRNo.Text == "")
                            {
                                return;
                            }
                            else
                            {
                                int selRoom = Convert.ToInt32(lblBookingRNo.Text);
                                if (bookRoom == selRoom)
                                {
                                    MessageBox.Show("Always Booked Room!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    if (lblEmailErrorProvider.Visible == true || lblEmailErrorProvider.Text == "")
                                    {
                                        MessageBox.Show("Please Check Import Details!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        grbDashPayment.Visible = true;
                                        grbBookingPayInvoice1.Visible = false;
                                        returnValue();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void txtCustomerAdCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCustomerAdEmail.Focus();
            }
            
        }

        private void txtCustomerAdEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtCustomerCheckIn.Focus();
            }
        }

        private void txtRoomPayDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPayPayAmount.Focus();
            }
        }

        private void txtPayPayAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtRoomPayDiscount.Text == "" || txtPayPayAmount.Text == "")
                {
                    MessageBox.Show("Please Enter Discount And PayAmount! If you no enter the discount Please enter the value of '0'.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    grbBookingPayInvoice1.Visible = true;
                    btnBookingPayClear.Enabled = false;
                    btnBookingPaySubmit.Enabled = false;
                    btnBookingUpdate.Enabled = false;
                    lblPDBillNo.Text = counter;

                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("select * from CompanyTB where ID = 1", con);
                    SqlDataReader srd1 = cmd1.ExecuteReader();
                    while (srd1.Read())
                    {
                        CName = srd1.GetValue(1).ToString();
                        CAddressNo = srd1.GetValue(2).ToString();
                        CAddressLine1 = srd1.GetValue(3).ToString();
                        CAddressLine2 = srd1.GetValue(4).ToString();
                        CAddressCity = srd1.GetValue(5).ToString();
                        ContactLandNo = srd1.GetValue(6).ToString();
                        ContactMobileNo = srd1.GetValue(7).ToString();
                        Email = srd1.GetValue(8).ToString();
                    }

                    con.Close();

                    Invoicedatachanger();
                }
            }
        }

        //Lock inizialize Details

        private void txtCustomerID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCustomerMobileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtRoNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtRoPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void txtRoomPayDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void txtPayPayAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void txtCustomerNIC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            
            // same as testing for decimal above, we can check the text for digits
            /*if (char.IsDigit(e.KeyChar))
            {
                //Count the digits already in the text.  I'm using linq:
                if (txtCustomerNIC.Text.Count(Char.IsDigit) >= 14)
                {
                    e.Handled = true;
                }
                
            }*/
        }

        private void btnBackupsummery_Click(object sender, EventArgs e)
        {
            counttotroomswherenonBookedadded();
            counttotroomswhereBookedaddedsUM();
            lastmonthsrecords();
            counttotofbookings();
            monrthlyprofitcount();
            getMaxIDonbacup();
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into BackUpTB values (@ID,@NowDate,@NowTime,@DayBookings,@DayProfit,@MonthBookings,@MonthProfit)", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(BCid));
            cmd.Parameters.AddWithValue("@NowDate", DateTime.Parse(lblDate.Text));
            cmd.Parameters.AddWithValue("@NowTime", DateTime.Parse(lblTime.Text));
            cmd.Parameters.AddWithValue("@DayBookings", int.Parse(lblSummeryTodayCustomers.Text));
            cmd.Parameters.AddWithValue("@DayProfit", lblTodaytotSum.Text);
            cmd.Parameters.AddWithValue("@MonthBookings", int.Parse(lblSummeryMonthlyBookings.Text));
            cmd.Parameters.AddWithValue("@MonthProfit", lblSummerymonthprofit.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Backup Saved!");
            con.Close();
        }

        string BCid;
        string BccID;
        string Bcdate;
        string BcTime;
        string BcdayBookings;
        string Bcdayprofit;
        string Bcmonthlybookings;
        string Bcmonthlyprofit;

        private void addbackupdata()
        {

            if (txtsummeryIDenter.Text == "")
            {
                return;
            }
            else
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select * from BackUpTB where ID ='" + int.Parse(txtsummeryIDenter.Text) + "'", con);
                SqlDataReader srd1 = cmd1.ExecuteReader();
                while (srd1.Read())
                {
                    BccID = srd1.GetValue(0).ToString();
                    Bcdate = srd1.GetValue(1).ToString();
                    BcTime = srd1.GetValue(2).ToString();
                    BcdayBookings = srd1.GetValue(3).ToString();
                    Bcdayprofit = srd1.GetValue(4).ToString();
                    Bcmonthlybookings = srd1.GetValue(5).ToString();
                    Bcmonthlyprofit = srd1.GetValue(6).ToString();
                }
                con.Close();
            }
        }

        double appluzero = 0;

        public void getMaxIDonbacup()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BackUpTB WHERE ID = (SELECT MAX(ID) FROM BackUpTB) ", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            i++;
            BCid = appluzero + i.ToString();
        }

        public void assignValue()
        {
            ViewFutureDataOfAddingData.instanceses.dateID.Text = BccID;
            ViewFutureDataOfAddingData.instanceses.dateofview.Text = Bcdate;
            ViewFutureDataOfAddingData.instanceses.timeofview.Text = BcTime;
            ViewFutureDataOfAddingData.instanceses.dayofbookings.Text = BcdayBookings;
            ViewFutureDataOfAddingData.instanceses.dayofprofit.Text = Bcdayprofit;
            ViewFutureDataOfAddingData.instanceses.monthofbookings.Text = Bcmonthlybookings;
            ViewFutureDataOfAddingData.instanceses.monthofprofit.Text = Bcmonthlyprofit;
        } 

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            viewFutureDataOfAddingData1.Visible = false;
            btnBackupsummery.Visible = false;
            grbSummeryViewer.Visible = true;

            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from BackUpTB", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewSavingsummeryview.DataSource = dt;
            con.Close();
        }

        private void btnBackOfSummery_Click(object sender, EventArgs e)
        {
            viewFutureDataOfAddingData1.Visible = false;
            btnBackupsummery.Visible = true;
            grbSummeryViewer.Visible = false;

            txtsummeryIDenter.Clear();
        }

        private void btnViewofSummery_Click(object sender, EventArgs e)
        {
            addbackupdata();

            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from BackUpTB", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewSavingsummeryview.DataSource = dt;
            con.Close();

            if (txtsummeryIDenter.Text == "")
            {
                MessageBox.Show("Please Enter The ID!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                getMaxIDonbacup();
                addbackupdata();

                if (idsell == null)
                {
                    MessageBox.Show("No Recordes You Saved!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    assignValue();
                    viewFutureDataOfAddingData1.Visible = true;
                }
            }
        }

        private void lblDashBtns_Click(object sender, EventArgs e)
        {

        }

        string idsell;

        private void txtsummeryIDenter_TextChanged(object sender, EventArgs e)
        {
            if (txtsummeryIDenter.Text == "")
            {
                return;
            }
            else
            {
                con.Open();
                SqlCommand cmd1 = new SqlCommand("select * from BackUpTB where ID ='" + int.Parse(txtsummeryIDenter.Text) + "'", con);
                SqlDataReader srd1 = cmd1.ExecuteReader();
                while (srd1.Read())
                {
                    idsell = srd1.GetValue(0).ToString();
                }
                con.Close();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FutureCustomerNotes fcn = new FutureCustomerNotes();
            fcn.Show();
        }

        private void btnUse_Click(object sender, EventArgs e)
        {
            lblDashAboutUse1.Visible = true;
            lblDashAboutUse.Visible = true;
            lblHowtouse.Visible = true;
            pictureBContact.Visible = false;
            pictureBox2.Visible = false;
            label99.Visible = false;
            label101.Visible = false;
            lblConditopnapp.Visible = true;
            pbiconbackwhite.Visible = true;

            btnUse.BackColor = Color.Goldenrod;
            btnUse.ForeColor = Color.White;
            btnUse.FlatAppearance.BorderSize = 0;

            btnContact.BackColor = Color.Gainsboro;
            btnContact.ForeColor = Color.Black;
            btnContact.FlatAppearance.BorderSize = 0;

            hideing();

        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            lblDashAboutUse1.Visible = false;
            lblDashAboutUse.Visible = false;
            lblHowtouse.Visible = false;
            pictureBContact.Visible = true;
            pictureBox2.Visible = true;
            label99.Visible = true;
            label101.Visible = true;
            lblConditopnapp.Visible = false;
            pbiconbackwhite.Visible = false;

            btnUse.BackColor = Color.Gainsboro;
            btnUse.ForeColor = Color.Black;
            btnUse.FlatAppearance.BorderSize = 0;

            btnContact.BackColor = Color.Goldenrod;
            btnContact.ForeColor = Color.White;
            btnContact.FlatAppearance.BorderSize = 0;

            hideing1();
        }

        private void lblLinkAccountSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            accountSettings();
            addvaluesfromlogindata();
        }

        int numberuse = 0;

        private void accountSettings()
        {
            
            if (numberuse == 0)
            {
                grbAccountSettings.Visible = false;
                grbLoginAccountSettings.Visible = true;
                numberuse = 1;
            }
            else if(numberuse == 1)
            {
                grbAccountSettings.Visible = false;
                grbLoginAccountSettings.Visible = false;
                numberuse = 0;
            }
        }

        private void btnAccountSettingsSave_Click(object sender, EventArgs e)
        {
            if (IsValidPassword(txtPassword.Text))
            {
                string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
                if (Regex.IsMatch(txtEmailAddress.Text, pattern))
                {
                    int A = 1;
                    int B = 2;

                    if (lblAccountSettingsIdentity.Text == "Admin")
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("update loginTB set UserName= ENCRYPTBYPASSPHRASE('8','" + txtUserName.Text + "'), Password= ENCRYPTBYPASSPHRASE('8','" + txtPassword.Text + "'), Email= ENCRYPTBYPASSPHRASE('8','" + txtEmailAddress.Text + "') where ID = '" + A + "' ", conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Update Successfull!", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lblpasswordAccountSettings.ForeColor = Color.Black;
                        lblpasswordAccountSettings.Text = "Password";

                        lbltextChangedSettings.ForeColor = Color.DarkGreen;
                        lbltextChangedSettings.Text = "Account Details Update And Now You Can Enter Using This Values.";
                    }
                    else if (lblAccountSettingsIdentity.Text == "User")
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("update loginTB set UserName= ENCRYPTBYPASSPHRASE('8','" + txtUserName.Text + "'), Password= ENCRYPTBYPASSPHRASE('8','" + txtPassword.Text + "'), Email= ENCRYPTBYPASSPHRASE('8','" + txtEmailAddress.Text + "') where ID = '" + B + "' ", conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Update Successfull!", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lblpasswordAccountSettings.ForeColor = Color.Black;
                        lblpasswordAccountSettings.Text = "Password";

                        lbltextChangedSettings.ForeColor = Color.DarkGreen;
                        lbltextChangedSettings.Text = "Account Details Update And Now You Can Enter Using This Values.";
                    }
                }
                else
                {
                    MessageBox.Show("Your Email Is Not Valied!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Your Password Is Not Valied!", "Error Message",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int R = 0;

        private void btnUserChnage_Click(object sender, EventArgs e)
        {
            if (R == 0)
            {
                lblAccountSettingsIdentity.Text = "User";
                lblAccountSettingsIdentity.BackColor = Color.DarkGreen;
                btnUserChnage.Text = "Admin";
                lblpasswordAccountSettings.ForeColor = Color.Black;
                lblpasswordAccountSettings.Text = "Password";
                addvaluesfromlogindata();
                R = 1;
            }
            else if (R == 1)
            {
                lblAccountSettingsIdentity.Text = "Admin";
                lblAccountSettingsIdentity.BackColor = Color.Maroon;
                btnUserChnage.Text = "User";
                lblpasswordAccountSettings.ForeColor = Color.Black;
                lblpasswordAccountSettings.Text = "Password";
                addvaluesfromlogindata();
                R = 0;
            }
        }

        private void btnUserChnage_MouseEnter(object sender, EventArgs e)
        {
            if (R == 0)
            {
                btnUserChnage.BackColor = Color.DarkGreen;
                btnUserChnage.ForeColor = Color.White;
                btnUserChnage.FlatAppearance.BorderSize = 0;
            }
            else if (R == 1)
            {
                btnUserChnage.BackColor = Color.Maroon;
                btnUserChnage.ForeColor = Color.White;
                btnUserChnage.FlatAppearance.BorderSize = 0;
            }
        }

        private void btnUserChnage_MouseLeave(object sender, EventArgs e)
        {
            btnUserChnage.BackColor = Color.Gainsboro;
            btnUserChnage.ForeColor = Color.Black;
            btnUserChnage.FlatAppearance.BorderSize = 0;
        }

        private void addvaluesfromlogindata()
        {
            if (lblAccountSettingsIdentity.Text == "Admin")
            {
                int a = 1;
                conn.Open();

                SqlCommand cmd3 = new SqlCommand("select CONVERT(varchar(4000), DECRYPTBYPASSPHRASE('8',UserName))as RealEmail FROM loginTB where ID = '" + a + "'", conn);
                string res1 = Convert.ToString(cmd3.ExecuteScalar());
                txtUserName.Text = res1;

                SqlCommand cmd2 = new SqlCommand("select CONVERT(varchar(4000), DECRYPTBYPASSPHRASE('8',Password))as RealPASSWORD FROM loginTB where ID ='" + a + "'", conn);
                string res = Convert.ToString(cmd2.ExecuteScalar());
                txtPassword.Text = res;

                SqlCommand cmd = new SqlCommand("select CONVERT(varchar(4000), DECRYPTBYPASSPHRASE('8',Email))as RealEmail FROM loginTB where ID ='" + a + "'", conn);
                string res2 = Convert.ToString(cmd.ExecuteScalar());
                txtEmailAddress.Text = res2;


                conn.Close();
            }
            else if(lblAccountSettingsIdentity.Text == "User")
            {
                int b = 2;
                conn.Open();

                SqlCommand cmd3 = new SqlCommand("select CONVERT(varchar(4000), DECRYPTBYPASSPHRASE('8',UserName))as RealEmail FROM loginTB where ID = '" + b + "'", conn);
                string res1 = Convert.ToString(cmd3.ExecuteScalar());
                txtUserName.Text = res1;

                SqlCommand cmd2 = new SqlCommand("select CONVERT(varchar(4000), DECRYPTBYPASSPHRASE('8',Password))as RealPASSWORD FROM loginTB where ID ='" + b + "'", conn);
                string res = Convert.ToString(cmd2.ExecuteScalar());
                txtPassword.Text = res;

                SqlCommand cmd = new SqlCommand("select CONVERT(varchar(4000), DECRYPTBYPASSPHRASE('8',Email))as RealEmail FROM loginTB where ID ='" + b + "'", conn);
                string res2 = Convert.ToString(cmd.ExecuteScalar());
                txtEmailAddress.Text = res2;


                conn.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtEmailAddress_TextChanged(object sender, EventArgs e)
        {
            if (txtEmailAddress.Text == "")
            {
                lbltextChangedSettings.Text = "";
            }
            else
            {
                string textchanged = "Sorry Your Email Address Is Not Valied!";
                string textchanged1 = "Great! Valied Email Added!";

                string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
                if (Regex.IsMatch(txtEmailAddress.Text, pattern))
                {
                    lbltextChangedSettings.ForeColor = Color.DarkGreen;
                    lbltextChangedSettings.Text = textchanged1;
                }
                else
                {
                    lbltextChangedSettings.ForeColor = Color.Maroon;
                    lbltextChangedSettings.Text = textchanged;
                }
            }
        }

        private void btnAccountSettingsSave_MouseEnter(object sender, EventArgs e)
        {
            btnAccountSettingsSave.BackColor = Color.DarkGreen;
            btnAccountSettingsSave.ForeColor = Color.White;
            btnAccountSettingsSave.FlatAppearance.BorderSize = 0;
        }

        private void btnAccountSettingsSave_MouseLeave(object sender, EventArgs e)
        {
            btnAccountSettingsSave.BackColor = Color.Gainsboro;
            btnAccountSettingsSave.ForeColor = Color.Black;
            btnAccountSettingsSave.FlatAppearance.BorderSize = 0;
        }

        private void btnAccountSettingsEdit_MouseEnter(object sender, EventArgs e)
        {
            btnAccountSettingsEdit.BackColor = Color.Black;
            btnAccountSettingsEdit.ForeColor = Color.White;
            btnAccountSettingsEdit.FlatAppearance.BorderSize = 0;
        }

        private void btnAccountSettingsEdit_MouseLeave(object sender, EventArgs e)
        {
            btnAccountSettingsEdit.BackColor = Color.Gainsboro;
            btnAccountSettingsEdit.ForeColor = Color.Black;
            btnAccountSettingsEdit.FlatAppearance.BorderSize = 0;
        }

        private void btnAccountSettingsEdit_Click(object sender, EventArgs e)
        {
            grbAccountSettings.Visible = false;
            numberuse = 0;
        }

        private void btnLoginAccountsettings_Click(object sender, EventArgs e)
        {
            if (txtLoginuserNameAccountsettings.Text == "")
            {
                txtLoginuserNameAccountsettings.Focus();
            }
            if (txtLoginPasswordAccountsettings.Text == "")
            {
                txtLoginPasswordAccountsettings.Focus();
            }
            else if (txtLoginuserNameAccountsettings.Text != "" || txtLoginPasswordAccountsettings.Text != "")
            {

                try
                {
                    if (txtLoginuserNameAccountsettings.Text == "Admin")
                    {
                        int r = 1;
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("select CONVERT(varchar(4000),DECRYPTBYPASSPHRASE('8',Password)) from logInTB where ID = '" + r + "'", conn);
                        string password = Convert.ToString(cmd.ExecuteScalar());
                        conn.Close();

                        if (password == txtLoginPasswordAccountsettings.Text)
                        {
                            if (lblDashProfile.Text == "Admin")
                            {
                                if (txtLoginuserNameAccountsettings.Text == "Admin")
                                {
                                    grbLoginAccountSettings.Visible = false;
                                    grbAccountSettings.Visible = true;
                                }
                                else
                                {
                                    MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtLoginPasswordAccountsettings.Clear();
                                    txtLoginuserNameAccountsettings.Clear();

                                }
                            }
                            else if (lblDashProfile.Text == "User")
                            {
                                if (txtLoginuserNameAccountsettings.Text == "User")
                                {
                                    grbLoginAccountSettings.Visible = false;
                                    grbAccountSettings.Visible = true;
                                }
                                else
                                {
                                    MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtLoginPasswordAccountsettings.Clear();
                                    txtLoginuserNameAccountsettings.Clear();

                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtLoginPasswordAccountsettings.Clear();
                            txtLoginuserNameAccountsettings.Clear();
                        }
                    }
                    else if (txtLoginuserNameAccountsettings.Text == "User")
                    {
                        int y = 2;
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("select CONVERT(varchar(4000),DECRYPTBYPASSPHRASE('8',Password)) from logInTB where ID = '" + y + "'", conn);
                        string password = Convert.ToString(cmd.ExecuteScalar());
                        conn.Close();

                        if (password == txtLoginPasswordAccountsettings.Text)
                        {
                            if (lblDashProfile.Text == "Admin")
                            {
                                if (txtLoginuserNameAccountsettings.Text == "Admin")
                                {
                                    grbLoginAccountSettings.Visible = false;
                                    grbAccountSettings.Visible = true;
                                }
                                else
                                {
                                    MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtLoginPasswordAccountsettings.Clear();
                                    txtLoginuserNameAccountsettings.Clear();

                                }
                            }
                            else if (lblDashProfile.Text == "User")
                            {
                                if (txtLoginuserNameAccountsettings.Text == "User")
                                {
                                    grbLoginAccountSettings.Visible = false;
                                    grbAccountSettings.Visible = true;
                                }
                                else
                                {
                                    MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtLoginPasswordAccountsettings.Clear();
                                    txtLoginuserNameAccountsettings.Clear();

                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtLoginPasswordAccountsettings.Clear();
                            txtLoginuserNameAccountsettings.Clear();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Error");
                }
                finally
                {
                    txtLoginPasswordAccountsettings.Clear();
                    txtLoginuserNameAccountsettings.Clear();
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Please Enter Username and Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtLoginPasswordAccountsettings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtLoginuserNameAccountsettings.Text == "")
                {
                    txtLoginuserNameAccountsettings.Focus();
                }
                else if (txtLoginuserNameAccountsettings.Text != "" || txtLoginPasswordAccountsettings.Text != "")
                {
                    try
                    {
                        if (txtLoginuserNameAccountsettings.Text == "Admin")
                        {
                            int r = 1;
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("select CONVERT(varchar(4000),DECRYPTBYPASSPHRASE('8',Password)) from logInTB where ID = '" + r + "'", conn);
                            string password = Convert.ToString(cmd.ExecuteScalar());
                            conn.Close();

                            if (password == txtLoginPasswordAccountsettings.Text)
                            {
                                if (lblDashProfile.Text == "Admin")
                                {
                                    if (txtLoginuserNameAccountsettings.Text == "Admin")
                                    {
                                        grbLoginAccountSettings.Visible = false;
                                        grbAccountSettings.Visible = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtLoginPasswordAccountsettings.Clear();
                                        txtLoginuserNameAccountsettings.Clear();

                                    }
                                }
                                else if (lblDashProfile.Text == "User")
                                {
                                    if (txtLoginuserNameAccountsettings.Text == "User")
                                    {
                                        grbLoginAccountSettings.Visible = false;
                                        grbAccountSettings.Visible = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtLoginPasswordAccountsettings.Clear();
                                        txtLoginuserNameAccountsettings.Clear();

                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtLoginPasswordAccountsettings.Clear();
                                txtLoginuserNameAccountsettings.Clear();
                            }
                        }
                        else if (txtLoginuserNameAccountsettings.Text == "User")
                        {
                            int y = 2;
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("select CONVERT(varchar(4000),DECRYPTBYPASSPHRASE('8',Password)) from logInTB where ID = '" + y + "'", conn);
                            string password = Convert.ToString(cmd.ExecuteScalar());
                            conn.Close();

                            if (password == txtLoginPasswordAccountsettings.Text)
                            {
                                if (lblDashProfile.Text == "Admin")
                                {
                                    if (txtLoginuserNameAccountsettings.Text == "Admin")
                                    {
                                        grbLoginAccountSettings.Visible = false;
                                        grbAccountSettings.Visible = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtLoginPasswordAccountsettings.Clear();
                                        txtLoginuserNameAccountsettings.Clear();

                                    }
                                }
                                else if (lblDashProfile.Text == "User")
                                {
                                    if (txtLoginuserNameAccountsettings.Text == "User")
                                    {
                                        grbLoginAccountSettings.Visible = false;
                                        grbAccountSettings.Visible = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtLoginPasswordAccountsettings.Clear();
                                        txtLoginuserNameAccountsettings.Clear();

                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtLoginPasswordAccountsettings.Clear();
                                txtLoginuserNameAccountsettings.Clear();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error");
                    }
                    finally
                    {
                        txtLoginPasswordAccountsettings.Clear();
                        txtLoginuserNameAccountsettings.Clear();
                        con.Close();
                    }
                }
            }
        }

        private void txtLoginuserNameAccountsettings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtLoginPasswordAccountsettings.Text == "")
                {
                    txtLoginPasswordAccountsettings.Focus();
                }
                else if (txtLoginuserNameAccountsettings.Text != "" || txtLoginPasswordAccountsettings.Text != "")
                {
                    try
                    {
                        if (txtLoginuserNameAccountsettings.Text == "Admin")
                        {
                            int r = 1;
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("select CONVERT(varchar(4000),DECRYPTBYPASSPHRASE('8',Password)) from logInTB where ID = '" + r + "'", conn);
                            string password = Convert.ToString(cmd.ExecuteScalar());
                            conn.Close();

                            if (password == txtLoginPasswordAccountsettings.Text)
                            {
                                if (lblDashProfile.Text == "Admin")
                                {
                                    if (txtLoginuserNameAccountsettings.Text == "Admin")
                                    {
                                        grbLoginAccountSettings.Visible = false;
                                        grbAccountSettings.Visible = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtLoginPasswordAccountsettings.Clear();
                                        txtLoginuserNameAccountsettings.Clear();

                                    }
                                }
                                else if (lblDashProfile.Text == "User")
                                {
                                    if (txtLoginuserNameAccountsettings.Text == "User")
                                    {
                                        grbLoginAccountSettings.Visible = false;
                                        grbAccountSettings.Visible = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtLoginPasswordAccountsettings.Clear();
                                        txtLoginuserNameAccountsettings.Clear();

                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtLoginPasswordAccountsettings.Clear();
                                txtLoginuserNameAccountsettings.Clear();
                            }
                        }
                        else if (txtLoginuserNameAccountsettings.Text == "User")
                        {
                            int y = 2;
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("select CONVERT(varchar(4000),DECRYPTBYPASSPHRASE('8',Password)) from logInTB where ID = '" + y + "'", conn);
                            string password = Convert.ToString(cmd.ExecuteScalar());
                            conn.Close();

                            if (password == txtLoginPasswordAccountsettings.Text)
                            {
                                if (lblDashProfile.Text == "Admin")
                                {
                                    if (txtLoginuserNameAccountsettings.Text == "Admin")
                                    {
                                        grbLoginAccountSettings.Visible = false;
                                        grbAccountSettings.Visible = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtLoginPasswordAccountsettings.Clear();
                                        txtLoginuserNameAccountsettings.Clear();

                                    }
                                }
                                else if (lblDashProfile.Text == "User")
                                {
                                    if (txtLoginuserNameAccountsettings.Text == "User")
                                    {
                                        grbLoginAccountSettings.Visible = false;
                                        grbAccountSettings.Visible = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtLoginPasswordAccountsettings.Clear();
                                        txtLoginuserNameAccountsettings.Clear();

                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid Login details", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtLoginPasswordAccountsettings.Clear();
                                txtLoginuserNameAccountsettings.Clear();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error");
                    }
                    finally
                    {
                        txtLoginPasswordAccountsettings.Clear();
                        txtLoginuserNameAccountsettings.Clear();
                        con.Close();
                    }
                }
            }
        }

        private void btnLoginAccountsettings_MouseEnter(object sender, EventArgs e)
        {
            btnLoginAccountsettings.BackColor = Color.MidnightBlue;
            btnLoginAccountsettings.ForeColor = Color.White;
            btnLoginAccountsettings.FlatAppearance.BorderSize = 0;
        }

        private void btnLoginAccountsettings_MouseLeave(object sender, EventArgs e)
        {
            btnLoginAccountsettings.BackColor = Color.Gainsboro;
            btnLoginAccountsettings.ForeColor = Color.Black;
            btnLoginAccountsettings.FlatAppearance.BorderSize = 0;
        }

        private void chkEmailGenPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEmailGenPass.Checked)
            {
                txtEmailPasswordGenerated.UseSystemPasswordChar = false;
            }
            else
            {
                txtEmailPasswordGenerated.UseSystemPasswordChar = true;
            }
        }

        private void txtCompanySettingsEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtCompanySettingsEmail.Text == "")
            {
                txtCompanySettingsEmail.ForeColor = Color.DarkGray;
                txtCompanySettingsEmail.Text = "Please Dont enter Domain servise! ex. @gmail.com";
            }
            else
            {
                return;
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BookingVisible();
            btnbookClickColor();
            btncustomerClickColor();
            btnroomsClickColor();
            btnHistoryClickColor();
            btnSummeryClickColor();
            btnSettingsClickColor();
            btnaboutClickColor();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CustomerVisible();
            btnbookClickColor();
            btncustomerClickColor();
            btnroomsClickColor();
            btnHistoryClickColor();
            btnSummeryClickColor();
            btnSettingsClickColor();
            btnaboutClickColor();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RoomsVisible();
            btnbookClickColor();
            btncustomerClickColor();
            btnroomsClickColor();
            btnHistoryClickColor();
            btnSummeryClickColor();
            btnSettingsClickColor();
            btnaboutClickColor();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HistoryVisible();
            btnbookClickColor();
            btncustomerClickColor();
            btnroomsClickColor();
            btnHistoryClickColor();
            btnSummeryClickColor();
            btnSettingsClickColor();
            btnaboutClickColor();
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AboutVisible();
            hideing();
            btnbookClickColor();
            btncustomerClickColor();
            btnroomsClickColor();
            btnHistoryClickColor();
            btnSummeryClickColor();
            btnSettingsClickColor();
            btnaboutClickColor();
            btnContact.Visible = true;
            lblConditopnapp.Visible = true;
            pbiconbackwhite.Visible = true;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AboutVisible();
            hideing();
            btnbookClickColor();
            btncustomerClickColor();
            btnroomsClickColor();
            btnHistoryClickColor();
            btnSummeryClickColor();
            btnSettingsClickColor();
            btnaboutClickColor();
            btnContact.Visible = false;
            lblConditopnapp.Visible = true;
            pbiconbackwhite.Visible = true;
        }

        public static bool IsValidPassword(string plainText)
        {
            Regex regex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            Match match = regex.Match(plainText);
            return match.Success;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsValidPassword(txtPassword.Text))
            {
                lblpasswordAccountSettings.ForeColor = Color.DarkGreen;
                lblpasswordAccountSettings.Text = "Valied Password";
            }
            else
            {
                lblpasswordAccountSettings.ForeColor = Color.Red;
                lblpasswordAccountSettings.Text = "Not Valied Password";
            }
        }

        private void txtPassword_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Show("* Password of Length 8 \n * Requires at least 1 Unique Char. \n * Requires 1 Digit \n * Requires 1 Lower Case character \n * Requires 1 Upper Case character \n * Requires 1 Special Character", txtPassword);
        }

        private void txtDashBookingInvoicesDelete_TextChanged(object sender, EventArgs e)
        {
            if (txtDashBookingInvoicesDelete.Text == "")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from PaymentDetailsTB", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dtgirdViewBookingpayInvoices.DataSource = dt;
                con.Close();
            }
            else
            {
                try
                {
                    con.Open();
                    string SearchQuarry = "Select * from PaymentDetailsTB Where ID = '" + txtDashBookingInvoicesDelete.Text + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(SearchQuarry, con);
                    DataTable ta = new DataTable();
                    adapter.Fill(ta);
                    dtgirdViewBookingpayInvoices.DataSource = ta;
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
            
        }
    }
}
