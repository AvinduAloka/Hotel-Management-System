namespace projectA
{
    partial class PreLoadedWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreLoadedWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.lblChangeLaableText = new System.Windows.Forms.Label();
            this.lblProjesCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblChangebletext = new System.Windows.Forms.Label();
            this.closeButton1 = new projectA.CloseButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(-1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(558, 32);
            this.label1.TabIndex = 0;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(346, 359);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.progressBar1.Location = new System.Drawing.Point(315, 299);
            this.progressBar1.MarqueeAnimationSpeed = 50;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(181, 2);
            this.progressBar1.Step = 4;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(320, 95);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(181, 73);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(14, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hotel Management System";
            this.label2.UseCompatibleTextRendering = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(318, 228);
            this.label3.MaximumSize = new System.Drawing.Size(190, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 52);
            this.label3.TabIndex = 6;
            this.label3.Text = "Room management crucial for hotel operations, ensuring appropriate pricing, provi" +
    "sions, and services to retain customers.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblChangeLaableText
            // 
            this.lblChangeLaableText.BackColor = System.Drawing.Color.Transparent;
            this.lblChangeLaableText.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblChangeLaableText.Location = new System.Drawing.Point(300, 182);
            this.lblChangeLaableText.Name = "lblChangeLaableText";
            this.lblChangeLaableText.Size = new System.Drawing.Size(213, 35);
            this.lblChangeLaableText.TabIndex = 7;
            this.lblChangeLaableText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProjesCount
            // 
            this.lblProjesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblProjesCount.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblProjesCount.Location = new System.Drawing.Point(481, 357);
            this.lblProjesCount.Name = "lblProjesCount";
            this.lblProjesCount.Size = new System.Drawing.Size(53, 23);
            this.lblProjesCount.TabIndex = 8;
            this.lblProjesCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(360, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 22);
            this.label4.TabIndex = 9;
            this.label4.Text = "Welcome!";
            // 
            // lblChangebletext
            // 
            this.lblChangebletext.ForeColor = System.Drawing.Color.DimGray;
            this.lblChangebletext.Location = new System.Drawing.Point(312, 304);
            this.lblChangebletext.Name = "lblChangebletext";
            this.lblChangebletext.Size = new System.Drawing.Size(186, 14);
            this.lblChangebletext.TabIndex = 10;
            this.lblChangebletext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // closeButton1
            // 
            this.closeButton1.BackColor = System.Drawing.Color.White;
            this.closeButton1.Location = new System.Drawing.Point(510, 12);
            this.closeButton1.Name = "closeButton1";
            this.closeButton1.Size = new System.Drawing.Size(32, 32);
            this.closeButton1.TabIndex = 1;
            // 
            // PreLoadedWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(555, 398);
            this.Controls.Add(this.lblChangebletext);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblProjesCount);
            this.Controls.Add(this.lblChangeLaableText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.closeButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PreLoadedWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PreLoadedWindow";
            this.Load += new System.EventHandler(this.PreLoadedWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CloseButton closeButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblChangeLaableText;
        private System.Windows.Forms.Label lblProjesCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblChangebletext;
    }
}