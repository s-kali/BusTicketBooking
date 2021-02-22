
namespace Booking_Database
{
    partial class signup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(signup));
            this.txtUserSign = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtPassSign = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.btnSignup = new System.Windows.Forms.Button();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.bunifuThinButton21 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUserSign
            // 
            this.txtUserSign.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserSign.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtUserSign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUserSign.HintForeColor = System.Drawing.Color.Empty;
            this.txtUserSign.HintText = "";
            this.txtUserSign.isPassword = false;
            this.txtUserSign.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtUserSign.LineIdleColor = System.Drawing.Color.Gray;
            this.txtUserSign.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtUserSign.LineThickness = 3;
            this.txtUserSign.Location = new System.Drawing.Point(195, 186);
            this.txtUserSign.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserSign.Name = "txtUserSign";
            this.txtUserSign.Size = new System.Drawing.Size(370, 44);
            this.txtUserSign.TabIndex = 0;
            this.txtUserSign.Text = "Username";
            this.txtUserSign.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUserSign.Enter += new System.EventHandler(this.txtUserSignEnter);
            this.txtUserSign.Leave += new System.EventHandler(this.txtUserSignLeave);
            // 
            // txtPassSign
            // 
            this.txtPassSign.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassSign.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtPassSign.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPassSign.HintForeColor = System.Drawing.Color.Empty;
            this.txtPassSign.HintText = "";
            this.txtPassSign.isPassword = false;
            this.txtPassSign.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtPassSign.LineIdleColor = System.Drawing.Color.Gray;
            this.txtPassSign.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtPassSign.LineThickness = 3;
            this.txtPassSign.Location = new System.Drawing.Point(195, 253);
            this.txtPassSign.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassSign.Name = "txtPassSign";
            this.txtPassSign.Size = new System.Drawing.Size(370, 44);
            this.txtPassSign.TabIndex = 1;
            this.txtPassSign.Text = "Password";
            this.txtPassSign.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPassSign.Enter += new System.EventHandler(this.txtPassSignEnter);
            this.txtPassSign.Leave += new System.EventHandler(this.txtPassSignLeave);
            // 
            // btnSignup
            // 
            this.btnSignup.BackColor = System.Drawing.Color.Transparent;
            this.btnSignup.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSignup.Location = new System.Drawing.Point(319, 345);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(123, 48);
            this.btnSignup.TabIndex = 2;
            this.btnSignup.Text = "Sign Up";
            this.btnSignup.UseVisualStyleBackColor = false;
            this.btnSignup.Click += new System.EventHandler(this.btnSignup_Click);
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(299, 45);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(167, 42);
            this.bunifuCustomLabel1.TabIndex = 3;
            this.bunifuCustomLabel1.Text = "SIGN UP";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.bunifuThinButton21);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 142);
            this.panel1.TabIndex = 4;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Booking_Database.Properties.Resources.x1;
            this.pictureBox3.Location = new System.Drawing.Point(735, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(37, 41);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // bunifuThinButton21
            // 
            this.bunifuThinButton21.ActiveBorderThickness = 1;
            this.bunifuThinButton21.ActiveCornerRadius = 20;
            this.bunifuThinButton21.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton21.ActiveForecolor = System.Drawing.Color.Silver;
            this.bunifuThinButton21.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton21.BackColor = System.Drawing.Color.MidnightBlue;
            this.bunifuThinButton21.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton21.BackgroundImage")));
            this.bunifuThinButton21.ButtonText = "BACK";
            this.bunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton21.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bunifuThinButton21.ForeColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton21.IdleBorderThickness = 1;
            this.bunifuThinButton21.IdleCornerRadius = 20;
            this.bunifuThinButton21.IdleFillColor = System.Drawing.Color.Silver;
            this.bunifuThinButton21.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton21.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton21.Location = new System.Drawing.Point(13, 9);
            this.bunifuThinButton21.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bunifuThinButton21.Name = "bunifuThinButton21";
            this.bunifuThinButton21.Size = new System.Drawing.Size(55, 40);
            this.bunifuThinButton21.TabIndex = 7;
            this.bunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton21.Click += new System.EventHandler(this.bunifuThinButton21_Click);
            // 
            // signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.btnSignup);
            this.Controls.Add(this.txtPassSign);
            this.Controls.Add(this.txtUserSign);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "signup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "signup";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuMaterialTextbox txtUserSign;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtPassSign;
        private System.Windows.Forms.Button btnSignup;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton21;
    }
}