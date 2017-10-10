namespace MERP_MUI
{
    partial class LoginScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginScreen));
            this.lblLogin = new MetroFramework.Controls.MetroLink();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cb_animsa = new MetroFramework.Controls.MetroCheckBox();
            this.lblgetPassword = new MetroFramework.Controls.MetroLink();
            this.pbLogin = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            this.txtKullaniciAdi = new MetroFramework.Controls.MetroTextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLogin
            // 
            this.lblLogin.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblLogin.Location = new System.Drawing.Point(170, 17);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(56, 23);
            this.lblLogin.Style = MetroFramework.MetroColorStyle.Silver;
            this.lblLogin.TabIndex = 8;
            this.lblLogin.Text = "Sign in";
            this.lblLogin.UseCustomBackColor = true;
            this.lblLogin.UseCustomForeColor = true;
            this.lblLogin.UseSelectable = true;
            this.lblLogin.UseStyleColors = true;
            this.lblLogin.Click += new System.EventHandler(this.lblLogin_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.cb_animsa);
            this.panel2.Controls.Add(this.lblgetPassword);
            this.panel2.Controls.Add(this.pbLogin);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.txtPassword);
            this.panel2.Controls.Add(this.txtKullaniciAdi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(20, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(209, 275);
            this.panel2.TabIndex = 7;
            // 
            // cb_animsa
            // 
            this.cb_animsa.AutoSize = true;
            this.cb_animsa.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cb_animsa.Location = new System.Drawing.Point(21, 206);
            this.cb_animsa.Name = "cb_animsa";
            this.cb_animsa.Size = new System.Drawing.Size(63, 15);
            this.cb_animsa.Style = MetroFramework.MetroColorStyle.Orange;
            this.cb_animsa.TabIndex = 28;
            this.cb_animsa.Text = "Anımsa";
            this.cb_animsa.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cb_animsa.UseCustomBackColor = true;
            this.cb_animsa.UseCustomForeColor = true;
            this.cb_animsa.UseSelectable = true;
            this.cb_animsa.UseStyleColors = true;
            this.cb_animsa.CheckedChanged += new System.EventHandler(this.cb_animsa_CheckedChanged);
            // 
            // lblgetPassword
            // 
            this.lblgetPassword.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblgetPassword.Location = new System.Drawing.Point(21, 249);
            this.lblgetPassword.Name = "lblgetPassword";
            this.lblgetPassword.Size = new System.Drawing.Size(143, 23);
            this.lblgetPassword.Style = MetroFramework.MetroColorStyle.Silver;
            this.lblgetPassword.TabIndex = 5;
            this.lblgetPassword.Text = "Forgot your password ?";
            this.lblgetPassword.UseCustomBackColor = true;
            this.lblgetPassword.UseCustomForeColor = true;
            this.lblgetPassword.UseSelectable = true;
            this.lblgetPassword.UseStyleColors = true;
            this.lblgetPassword.Click += new System.EventHandler(this.lblgetPassword_Click);
            // 
            // pbLogin
            // 
            this.pbLogin.Image = global::MERP_MUI.Properties.Resources.Picture1_colorchange;
            this.pbLogin.Location = new System.Drawing.Point(147, 206);
            this.pbLogin.Name = "pbLogin";
            this.pbLogin.Size = new System.Drawing.Size(37, 40);
            this.pbLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogin.TabIndex = 4;
            this.pbLogin.TabStop = false;
            this.pbLogin.Click += new System.EventHandler(this.pbLogin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MERP_MUI.Properties.Resources.Picture2;
            this.pictureBox1.Location = new System.Drawing.Point(25, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // txtPassword
            // 
            // 
            // 
            // 
            this.txtPassword.CustomButton.Image = null;
            this.txtPassword.CustomButton.Location = new System.Drawing.Point(141, 1);
            this.txtPassword.CustomButton.Name = "";
            this.txtPassword.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPassword.CustomButton.TabIndex = 1;
            this.txtPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPassword.CustomButton.UseSelectable = true;
            this.txtPassword.CustomButton.Visible = false;
            this.txtPassword.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtPassword.Lines = new string[0];
            this.txtPassword.Location = new System.Drawing.Point(21, 177);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PromptText = "Şifre";
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(163, 23);
            this.txtPassword.Style = MetroFramework.MetroColorStyle.Red;
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtPassword.UseCustomBackColor = true;
            this.txtPassword.UseCustomForeColor = true;
            this.txtPassword.UseSelectable = true;
            this.txtPassword.UseStyleColors = true;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.WaterMark = "Şifre";
            this.txtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // txtKullaniciAdi
            // 
            // 
            // 
            // 
            this.txtKullaniciAdi.CustomButton.Image = null;
            this.txtKullaniciAdi.CustomButton.Location = new System.Drawing.Point(141, 1);
            this.txtKullaniciAdi.CustomButton.Name = "";
            this.txtKullaniciAdi.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtKullaniciAdi.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtKullaniciAdi.CustomButton.TabIndex = 1;
            this.txtKullaniciAdi.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtKullaniciAdi.CustomButton.UseSelectable = true;
            this.txtKullaniciAdi.CustomButton.Visible = false;
            this.txtKullaniciAdi.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtKullaniciAdi.Icon = ((System.Drawing.Image)(resources.GetObject("txtKullaniciAdi.Icon")));
            this.txtKullaniciAdi.Lines = new string[0];
            this.txtKullaniciAdi.Location = new System.Drawing.Point(21, 137);
            this.txtKullaniciAdi.MaxLength = 32767;
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.PasswordChar = '\0';
            this.txtKullaniciAdi.PromptText = "Kullanıcı Adı";
            this.txtKullaniciAdi.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtKullaniciAdi.SelectedText = "";
            this.txtKullaniciAdi.SelectionLength = 0;
            this.txtKullaniciAdi.SelectionStart = 0;
            this.txtKullaniciAdi.ShortcutsEnabled = true;
            this.txtKullaniciAdi.Size = new System.Drawing.Size(163, 23);
            this.txtKullaniciAdi.Style = MetroFramework.MetroColorStyle.Red;
            this.txtKullaniciAdi.TabIndex = 0;
            this.txtKullaniciAdi.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtKullaniciAdi.UseCustomBackColor = true;
            this.txtKullaniciAdi.UseCustomForeColor = true;
            this.txtKullaniciAdi.UseSelectable = true;
            this.txtKullaniciAdi.UseStyleColors = true;
            this.txtKullaniciAdi.WaterMark = "Kullanıcı Adı";
            this.txtKullaniciAdi.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtKullaniciAdi.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtKullaniciAdi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 355);
            this.ControlBox = false;
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginScreen";
            this.Opacity = 0.7D;
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.LoginScreen_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLink lblLogin;
        private System.Windows.Forms.Panel panel2;
        private MetroFramework.Controls.MetroLink lblgetPassword;
        private System.Windows.Forms.PictureBox pbLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTextBox txtPassword;
        private MetroFramework.Controls.MetroTextBox txtKullaniciAdi;
        private MetroFramework.Controls.MetroCheckBox cb_animsa;
    }
}