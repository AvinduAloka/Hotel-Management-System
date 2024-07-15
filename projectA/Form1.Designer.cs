namespace projectA
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grbsignin = new System.Windows.Forms.GroupBox();
            this.chbSigninpass = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.txtLoginUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.pnlUserName = new System.Windows.Forms.Panel();
            this.pnlPassword = new System.Windows.Forms.Panel();
            this.lblMoveandDrag = new System.Windows.Forms.Label();
            this.btnLoginClose = new System.Windows.Forms.Button();
            this.grbforgotPass = new System.Windows.Forms.GroupBox();
            this.linkResend = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtverifyCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grbchangePass = new System.Windows.Forms.GroupBox();
            this.chbShowPassNewPass = new System.Windows.Forms.CheckBox();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.lblErrormessage = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtReNewPass = new System.Windows.Forms.TextBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnclear3 = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.timvcode = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grbsignin.SuspendLayout();
            this.grbforgotPass.SuspendLayout();
            this.grbchangePass.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbsignin
            // 
            this.grbsignin.Controls.Add(this.chbSigninpass);
            this.grbsignin.Controls.Add(this.linkLabel1);
            this.grbsignin.Controls.Add(this.label1);
            this.grbsignin.Controls.Add(this.label2);
            this.grbsignin.Controls.Add(this.txtLoginPassword);
            this.grbsignin.Controls.Add(this.txtLoginUserName);
            this.grbsignin.Controls.Add(this.label3);
            this.grbsignin.Controls.Add(this.label4);
            this.grbsignin.Controls.Add(this.btnClear);
            this.grbsignin.Controls.Add(this.btnSignIn);
            this.grbsignin.Controls.Add(this.pnlUserName);
            this.grbsignin.Controls.Add(this.pnlPassword);
            this.grbsignin.Location = new System.Drawing.Point(11, 39);
            this.grbsignin.Name = "grbsignin";
            this.grbsignin.Size = new System.Drawing.Size(255, 307);
            this.grbsignin.TabIndex = 14;
            this.grbsignin.TabStop = false;
            // 
            // chbSigninpass
            // 
            this.chbSigninpass.AutoSize = true;
            this.chbSigninpass.Location = new System.Drawing.Point(131, 217);
            this.chbSigninpass.Name = "chbSigninpass";
            this.chbSigninpass.Size = new System.Drawing.Size(102, 17);
            this.chbSigninpass.TabIndex = 15;
            this.chbSigninpass.Text = "Show Password";
            this.chbSigninpass.UseVisualStyleBackColor = true;
            this.chbSigninpass.CheckedChanged += new System.EventHandler(this.chbSigninpass_CheckedChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.RoyalBlue;
            this.linkLabel1.Location = new System.Drawing.Point(21, 217);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(86, 13);
            this.linkLabel1.TabIndex = 14;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Forgot Password";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(18, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "* Enter the Username and Password";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(13, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "SIGN IN";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.BackColor = System.Drawing.Color.White;
            this.txtLoginPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoginPassword.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginPassword.Location = new System.Drawing.Point(21, 149);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.Size = new System.Drawing.Size(212, 22);
            this.txtLoginPassword.TabIndex = 10;
            this.txtLoginPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLoginPassword_KeyDown);
            // 
            // txtLoginUserName
            // 
            this.txtLoginUserName.BackColor = System.Drawing.Color.White;
            this.txtLoginUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoginUserName.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginUserName.Location = new System.Drawing.Point(21, 85);
            this.txtLoginUserName.Name = "txtLoginUserName";
            this.txtLoginUserName.Size = new System.Drawing.Size(212, 22);
            this.txtLoginUserName.TabIndex = 9;
            this.txtLoginUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLoginUserName_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(18, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Password";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(19, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "UserName";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Gainsboro;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(133, 252);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 32);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.MouseEnter += new System.EventHandler(this.btnClear_MouseEnter);
            this.btnClear.MouseLeave += new System.EventHandler(this.btnClear_MouseLeave);
            // 
            // btnSignIn
            // 
            this.btnSignIn.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSignIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSignIn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSignIn.FlatAppearance.BorderSize = 0;
            this.btnSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignIn.ForeColor = System.Drawing.Color.White;
            this.btnSignIn.Location = new System.Drawing.Point(21, 252);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(100, 32);
            this.btnSignIn.TabIndex = 5;
            this.btnSignIn.Text = "Sign In";
            this.btnSignIn.UseVisualStyleBackColor = false;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            this.btnSignIn.MouseEnter += new System.EventHandler(this.btnSignIn_MouseEnter);
            this.btnSignIn.MouseLeave += new System.EventHandler(this.btnSignIn_MouseLeave);
            // 
            // pnlUserName
            // 
            this.pnlUserName.Location = new System.Drawing.Point(21, 105);
            this.pnlUserName.Name = "pnlUserName";
            this.pnlUserName.Size = new System.Drawing.Size(212, 10);
            this.pnlUserName.TabIndex = 12;
            this.pnlUserName.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlUserName_Paint);
            // 
            // pnlPassword
            // 
            this.pnlPassword.Location = new System.Drawing.Point(21, 170);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Size = new System.Drawing.Size(212, 10);
            this.pnlPassword.TabIndex = 11;
            this.pnlPassword.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPassword_Paint);
            // 
            // lblMoveandDrag
            // 
            this.lblMoveandDrag.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblMoveandDrag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblMoveandDrag.ForeColor = System.Drawing.Color.White;
            this.lblMoveandDrag.Location = new System.Drawing.Point(-1, 0);
            this.lblMoveandDrag.Name = "lblMoveandDrag";
            this.lblMoveandDrag.Padding = new System.Windows.Forms.Padding(10, 0, 0, 4);
            this.lblMoveandDrag.Size = new System.Drawing.Size(280, 32);
            this.lblMoveandDrag.TabIndex = 13;
            this.lblMoveandDrag.Text = "Hotel Reservation System";
            this.lblMoveandDrag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMoveandDrag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblMoveandDrag_MouseDown);
            this.lblMoveandDrag.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblMoveandDrag_MouseMove);
            // 
            // btnLoginClose
            // 
            this.btnLoginClose.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnLoginClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLoginClose.FlatAppearance.BorderSize = 0;
            this.btnLoginClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoginClose.ForeColor = System.Drawing.Color.DarkGray;
            this.btnLoginClose.Location = new System.Drawing.Point(243, 0);
            this.btnLoginClose.Name = "btnLoginClose";
            this.btnLoginClose.Size = new System.Drawing.Size(36, 32);
            this.btnLoginClose.TabIndex = 16;
            this.btnLoginClose.Text = "X";
            this.btnLoginClose.UseVisualStyleBackColor = false;
            this.btnLoginClose.Click += new System.EventHandler(this.btnLoginClose_Click);
            this.btnLoginClose.MouseEnter += new System.EventHandler(this.btnLoginClose_MouseEnter);
            this.btnLoginClose.MouseLeave += new System.EventHandler(this.btnLoginClose_MouseLeave);
            // 
            // grbforgotPass
            // 
            this.grbforgotPass.Controls.Add(this.linkResend);
            this.grbforgotPass.Controls.Add(this.linkLabel2);
            this.grbforgotPass.Controls.Add(this.label5);
            this.grbforgotPass.Controls.Add(this.label6);
            this.grbforgotPass.Controls.Add(this.txtverifyCode);
            this.grbforgotPass.Controls.Add(this.label8);
            this.grbforgotPass.Controls.Add(this.button1);
            this.grbforgotPass.Controls.Add(this.btnOk);
            this.grbforgotPass.Controls.Add(this.panel1);
            this.grbforgotPass.Location = new System.Drawing.Point(11, 39);
            this.grbforgotPass.Name = "grbforgotPass";
            this.grbforgotPass.Size = new System.Drawing.Size(255, 307);
            this.grbforgotPass.TabIndex = 15;
            this.grbforgotPass.TabStop = false;
            // 
            // linkResend
            // 
            this.linkResend.AutoSize = true;
            this.linkResend.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkResend.LinkColor = System.Drawing.Color.RoyalBlue;
            this.linkResend.Location = new System.Drawing.Point(21, 173);
            this.linkResend.Name = "linkResend";
            this.linkResend.Size = new System.Drawing.Size(97, 13);
            this.linkResend.TabIndex = 15;
            this.linkResend.TabStop = true;
            this.linkResend.Text = "Resend OTP Code";
            this.linkResend.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkResend_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel2.LinkColor = System.Drawing.Color.RoyalBlue;
            this.linkLabel2.Location = new System.Drawing.Point(21, 196);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(77, 13);
            this.linkLabel2.TabIndex = 14;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Back To Login";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(18, 134);
            this.label5.MaximumSize = new System.Drawing.Size(230, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(223, 26);
            this.label5.TabIndex = 13;
            this.label5.Text = "* We Are Send To Verification Code For Your Identity E-mail. So Please Check your" +
    " email!";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label6.Location = new System.Drawing.Point(13, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 26);
            this.label6.TabIndex = 8;
            this.label6.Text = "Forgot Password";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtverifyCode
            // 
            this.txtverifyCode.BackColor = System.Drawing.Color.White;
            this.txtverifyCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtverifyCode.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtverifyCode.Location = new System.Drawing.Point(21, 94);
            this.txtverifyCode.Name = "txtverifyCode";
            this.txtverifyCode.Size = new System.Drawing.Size(212, 22);
            this.txtverifyCode.TabIndex = 9;
            this.txtverifyCode.TextChanged += new System.EventHandler(this.txtverifyCode_TextChanged);
            this.txtverifyCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtverifyCode_KeyDown);
            this.txtverifyCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtverifyCode_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label8.Location = new System.Drawing.Point(19, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 19);
            this.label8.TabIndex = 7;
            this.label8.Text = "Verify Code";
            this.label8.UseCompatibleTextRendering = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(133, 252);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 32);
            this.button1.TabIndex = 6;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(21, 252);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 32);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            this.btnOk.MouseEnter += new System.EventHandler(this.btnOk_MouseEnter);
            this.btnOk.MouseLeave += new System.EventHandler(this.btnOk_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(21, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 10);
            this.panel1.TabIndex = 12;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // grbchangePass
            // 
            this.grbchangePass.Controls.Add(this.chbShowPassNewPass);
            this.grbchangePass.Controls.Add(this.linkLabel3);
            this.grbchangePass.Controls.Add(this.lblErrormessage);
            this.grbchangePass.Controls.Add(this.label10);
            this.grbchangePass.Controls.Add(this.txtReNewPass);
            this.grbchangePass.Controls.Add(this.txtNewPass);
            this.grbchangePass.Controls.Add(this.label11);
            this.grbchangePass.Controls.Add(this.label12);
            this.grbchangePass.Controls.Add(this.btnclear3);
            this.grbchangePass.Controls.Add(this.btnSubmit);
            this.grbchangePass.Controls.Add(this.panel3);
            this.grbchangePass.Controls.Add(this.panel4);
            this.grbchangePass.Location = new System.Drawing.Point(11, 39);
            this.grbchangePass.Name = "grbchangePass";
            this.grbchangePass.Size = new System.Drawing.Size(255, 307);
            this.grbchangePass.TabIndex = 16;
            this.grbchangePass.TabStop = false;
            // 
            // chbShowPassNewPass
            // 
            this.chbShowPassNewPass.AutoSize = true;
            this.chbShowPassNewPass.Location = new System.Drawing.Point(131, 217);
            this.chbShowPassNewPass.Name = "chbShowPassNewPass";
            this.chbShowPassNewPass.Size = new System.Drawing.Size(102, 17);
            this.chbShowPassNewPass.TabIndex = 15;
            this.chbShowPassNewPass.Text = "Show Password";
            this.chbShowPassNewPass.UseVisualStyleBackColor = true;
            this.chbShowPassNewPass.CheckedChanged += new System.EventHandler(this.chbShowPassNewPass_CheckedChanged);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel3.LinkColor = System.Drawing.Color.RoyalBlue;
            this.linkLabel3.Location = new System.Drawing.Point(21, 217);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(77, 13);
            this.linkLabel3.TabIndex = 14;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Back To Login";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // lblErrormessage
            // 
            this.lblErrormessage.AutoSize = true;
            this.lblErrormessage.ForeColor = System.Drawing.Color.DimGray;
            this.lblErrormessage.Location = new System.Drawing.Point(18, 192);
            this.lblErrormessage.Name = "lblErrormessage";
            this.lblErrormessage.Size = new System.Drawing.Size(178, 13);
            this.lblErrormessage.TabIndex = 13;
            this.lblErrormessage.Text = "* Enter the Username and Password";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label10.Location = new System.Drawing.Point(13, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(190, 26);
            this.label10.TabIndex = 8;
            this.label10.Text = "Change Password";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtReNewPass
            // 
            this.txtReNewPass.BackColor = System.Drawing.Color.White;
            this.txtReNewPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReNewPass.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReNewPass.Location = new System.Drawing.Point(21, 154);
            this.txtReNewPass.Name = "txtReNewPass";
            this.txtReNewPass.Size = new System.Drawing.Size(212, 22);
            this.txtReNewPass.TabIndex = 10;
            this.txtReNewPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReNewPass_KeyDown);
            this.txtReNewPass.MouseHover += new System.EventHandler(this.txtReNewPass_MouseEnter);
            // 
            // txtNewPass
            // 
            this.txtNewPass.BackColor = System.Drawing.Color.White;
            this.txtNewPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNewPass.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPass.Location = new System.Drawing.Point(21, 90);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(212, 22);
            this.txtNewPass.TabIndex = 9;
            this.txtNewPass.TextChanged += new System.EventHandler(this.txtNewPass_TextChanged);
            this.txtNewPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewPass_KeyDown);
            this.txtNewPass.MouseHover += new System.EventHandler(this.txtNewPass_MouseEnter);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label11.Location = new System.Drawing.Point(18, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 19);
            this.label11.TabIndex = 8;
            this.label11.Text = "Re-Enter Password";
            this.label11.UseCompatibleTextRendering = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label12.Location = new System.Drawing.Point(19, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(126, 19);
            this.label12.TabIndex = 7;
            this.label12.Text = "Enter New Passsword";
            this.label12.UseCompatibleTextRendering = true;
            // 
            // btnclear3
            // 
            this.btnclear3.BackColor = System.Drawing.Color.Gainsboro;
            this.btnclear3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnclear3.FlatAppearance.BorderSize = 0;
            this.btnclear3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclear3.ForeColor = System.Drawing.Color.Black;
            this.btnclear3.Location = new System.Drawing.Point(133, 252);
            this.btnclear3.Name = "btnclear3";
            this.btnclear3.Size = new System.Drawing.Size(100, 32);
            this.btnclear3.TabIndex = 6;
            this.btnclear3.Text = "Clear";
            this.btnclear3.UseVisualStyleBackColor = false;
            this.btnclear3.Click += new System.EventHandler(this.btnclear3_Click);
            this.btnclear3.MouseEnter += new System.EventHandler(this.btnclear3_MouseEnter);
            this.btnclear3.MouseLeave += new System.EventHandler(this.btnclear3_MouseLeave);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSubmit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(21, 252);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 32);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            this.btnSubmit.MouseEnter += new System.EventHandler(this.btnSubmit_MouseEnter);
            this.btnSubmit.MouseLeave += new System.EventHandler(this.btnSubmit_MouseLeave);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(21, 111);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(212, 10);
            this.panel3.TabIndex = 12;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(21, 175);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(212, 10);
            this.panel4.TabIndex = 11;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // timvcode
            // 
            this.timvcode.Tick += new System.EventHandler(this.timvcode_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(279, 363);
            this.Controls.Add(this.btnLoginClose);
            this.Controls.Add(this.lblMoveandDrag);
            this.Controls.Add(this.grbchangePass);
            this.Controls.Add(this.grbforgotPass);
            this.Controls.Add(this.grbsignin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grbsignin.ResumeLayout(false);
            this.grbsignin.PerformLayout();
            this.grbforgotPass.ResumeLayout(false);
            this.grbforgotPass.PerformLayout();
            this.grbchangePass.ResumeLayout(false);
            this.grbchangePass.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbsignin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLoginPassword;
        private System.Windows.Forms.TextBox txtLoginUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.Panel pnlUserName;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.Label lblMoveandDrag;
        private System.Windows.Forms.Button btnLoginClose;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grbforgotPass;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtverifyCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grbchangePass;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.Label lblErrormessage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtReNewPass;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnclear3;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Timer timvcode;
        private System.Windows.Forms.CheckBox chbShowPassNewPass;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chbSigninpass;
        private System.Windows.Forms.LinkLabel linkResend;
    }
}

