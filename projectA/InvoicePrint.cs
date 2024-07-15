using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace projectA
{
    public partial class InvoicePrint : UserControl
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

        public static InvoicePrint titancess;
        public Label A;
        public Label B;
        public Label C;
        public Label D;
        public Label EG;
        public Label F;
        public Label G;
        public Label H;
        public Label I;
        public Label J;
        public Label K;
        public Label L;
        public Label M;


        public InvoicePrint()
        {
            InitializeComponent();
            titancess = this;
            A = lblID;
            B = lblIssueDate;
            C = lblCompanyName;
            D = lblCompanyAddress;
            EG = lblCompanyNumber;
            F = lblbillPrice;
            G = lblbillcheckin;
            H = lblbillCheckuout;
            I = lblbillDiscount;
            K = lblbillTotal;
            L = lblbillPayment;
            M = lblbillBalance;

            printDocument1.PrintPage += new PrintPageEventHandler(printdoc1_PrintPage);

            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 6, 6));

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

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics grp = this.panel1.CreateGraphics();
            Pen blackPen = new Pen(Color.Black, 1);

            PointF pnt1 = new PointF(576.0F, 006.0F);
            PointF pnt2 = new PointF(000.0F, 006.0F);
            e.Graphics.DrawLine(blackPen, pnt1, pnt2);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics grp = this.panel2.CreateGraphics();
            Pen blackPen = new Pen(Color.Black, 1);

            PointF pnt1 = new PointF(576.0F, 006.0F);
            PointF pnt2 = new PointF(000.0F, 006.0F);
            e.Graphics.DrawLine(blackPen, pnt1, pnt2);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Graphics grp = this.panel3.CreateGraphics();
            Pen blackPen = new Pen(Color.Black, 1);

            PointF pnt1 = new PointF(576.0F, 006.0F);
            PointF pnt2 = new PointF(000.0F, 006.0F);
            e.Graphics.DrawLine(blackPen, pnt1, pnt2);
        }

        private void InvoicePrint_Load(object sender, EventArgs e)
        {
            btnPrintBill.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnPrintBill.Width, btnPrintBill.Height, 2, 2));
            panel4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel4.Width, panel4.Height, 4, 4));
        }

        private void btnPrintBill_MouseEnter(object sender, EventArgs e)
        {
            btnPrintBill.BackColor = Color.Black;
            btnPrintBill.ForeColor = Color.White;
            btnPrintBill.FlatAppearance.BorderSize = 0;
        }

        private void btnPrintBill_MouseLeave(object sender, EventArgs e)
        {
            btnPrintBill.BackColor = Color.Gainsboro;
            btnPrintBill.ForeColor = Color.Black;
            btnPrintBill.FlatAppearance.BorderSize = 0;
        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            Print(this.panel4);
           
            View.instance.grb1.Visible = false;
            View.instance.grb2.Visible = false;
            View.instance.b1.Visible = true;
            View.instance.b2.Visible = true;
            View.instance.b3.Visible = true;
            View.instance.clearall();
            View.instance.grbDashPayment1.Enabled = true;
            this.Hide();
        }

        Bitmap MemoryImage;
        private PrintDocument printDocument1 = new PrintDocument();
        private PrintPreviewDialog previewdlg = new PrintPreviewDialog();

        public void GetPrintArea(Panel pnl)
        {
            MemoryImage = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(MemoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
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
            e.Graphics.DrawImage(MemoryImage, (pagearea.Width / 2) - (this.panel4.Width / 2), this.panel4.Location.Y);
        }

        public void Print(Panel pnl)
        {
            Panel pannel = pnl;
            GetPrintArea(pnl);
            previewdlg.Document = printDocument1;
            previewdlg.ShowDialog();
        }

    }
}
