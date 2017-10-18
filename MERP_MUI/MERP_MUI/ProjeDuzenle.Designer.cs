namespace MERP_MUI
{
    partial class ProjeDuzenle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjeDuzenle));
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.btn_prjDZN = new MetroFramework.Controls.MetroButton();
            this.btn_harcamalar = new MetroFramework.Controls.MetroButton();
            this.rcb_acıklama = new System.Windows.Forms.RichTextBox();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.ck_prj = new MetroFramework.Controls.MetroCheckBox();
            this.lbl_birim = new MetroFramework.Controls.MetroLabel();
            this.lbl_harcamalar = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.dtp_bitis = new MetroFramework.Controls.MetroDateTime();
            this.dtp_baslangıc = new MetroFramework.Controls.MetroDateTime();
            this.txt_vade = new MetroFramework.Controls.MetroTextBox();
            this.txt_musteri = new MetroFramework.Controls.MetroTextBox();
            this.txt_butce = new MetroFramework.Controls.MetroTextBox();
            this.txt_proje_adı = new MetroFramework.Controls.MetroTextBox();
            this.ck_seri = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txt_proje_no = new MetroFramework.Controls.MetroTextBox();
            this.cmb_birim = new MetroFramework.Controls.MetroComboBox();
            this.lbl_id = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.SuspendLayout();
            // 
            // pbClose
            // 
            this.pbClose.BackColor = System.Drawing.Color.Transparent;
            this.pbClose.Image = global::MERP_MUI.Properties.Resources.appbar_arrow_left_dark;
            this.pbClose.Location = new System.Drawing.Point(598, 25);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(46, 42);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbClose.TabIndex = 88;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // btn_prjDZN
            // 
            this.btn_prjDZN.Highlight = true;
            this.btn_prjDZN.Location = new System.Drawing.Point(528, 431);
            this.btn_prjDZN.Name = "btn_prjDZN";
            this.btn_prjDZN.Size = new System.Drawing.Size(116, 60);
            this.btn_prjDZN.Style = MetroFramework.MetroColorStyle.Red;
            this.btn_prjDZN.TabIndex = 87;
            this.btn_prjDZN.Text = "DÜZENLE";
            this.btn_prjDZN.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_prjDZN.UseCustomBackColor = true;
            this.btn_prjDZN.UseCustomForeColor = true;
            this.btn_prjDZN.UseSelectable = true;
            this.btn_prjDZN.UseStyleColors = true;
            this.btn_prjDZN.Click += new System.EventHandler(this.btn_prjDZN_Click);
            // 
            // btn_harcamalar
            // 
            this.btn_harcamalar.Highlight = true;
            this.btn_harcamalar.Location = new System.Drawing.Point(502, 90);
            this.btn_harcamalar.Name = "btn_harcamalar";
            this.btn_harcamalar.Size = new System.Drawing.Size(142, 36);
            this.btn_harcamalar.Style = MetroFramework.MetroColorStyle.Red;
            this.btn_harcamalar.TabIndex = 86;
            this.btn_harcamalar.Text = "Harcamalar ve Ödemeler";
            this.btn_harcamalar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_harcamalar.UseCustomBackColor = true;
            this.btn_harcamalar.UseCustomForeColor = true;
            this.btn_harcamalar.UseSelectable = true;
            this.btn_harcamalar.UseStyleColors = true;
            this.btn_harcamalar.Click += new System.EventHandler(this.btn_harcamalar_Click);
            // 
            // rcb_acıklama
            // 
            this.rcb_acıklama.Location = new System.Drawing.Point(128, 404);
            this.rcb_acıklama.Name = "rcb_acıklama";
            this.rcb_acıklama.Size = new System.Drawing.Size(377, 87);
            this.rcb_acıklama.TabIndex = 73;
            this.rcb_acıklama.Text = "";
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.metroLabel11.Location = new System.Drawing.Point(26, 404);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(69, 19);
            this.metroLabel11.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel11.TabIndex = 85;
            this.metroLabel11.Text = "Açıklama :";
            this.metroLabel11.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel11.UseCustomBackColor = true;
            this.metroLabel11.UseCustomForeColor = true;
            this.metroLabel11.UseStyleColors = true;
            // 
            // ck_prj
            // 
            this.ck_prj.AutoSize = true;
            this.ck_prj.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ck_prj.Location = new System.Drawing.Point(140, 100);
            this.ck_prj.Name = "ck_prj";
            this.ck_prj.Size = new System.Drawing.Size(50, 15);
            this.ck_prj.Style = MetroFramework.MetroColorStyle.Red;
            this.ck_prj.TabIndex = 84;
            this.ck_prj.Text = "Proje";
            this.ck_prj.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ck_prj.UseCustomBackColor = true;
            this.ck_prj.UseCustomForeColor = true;
            this.ck_prj.UseSelectable = true;
            this.ck_prj.UseStyleColors = true;
            // 
            // lbl_birim
            // 
            this.lbl_birim.AutoSize = true;
            this.lbl_birim.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_birim.Location = new System.Drawing.Point(421, 96);
            this.lbl_birim.Name = "lbl_birim";
            this.lbl_birim.Size = new System.Drawing.Size(40, 19);
            this.lbl_birim.Style = MetroFramework.MetroColorStyle.Red;
            this.lbl_birim.TabIndex = 83;
            this.lbl_birim.Text = "Birim";
            this.lbl_birim.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.lbl_birim.UseCustomBackColor = true;
            this.lbl_birim.UseCustomForeColor = true;
            this.lbl_birim.UseStyleColors = true;
            // 
            // lbl_harcamalar
            // 
            this.lbl_harcamalar.AutoSize = true;
            this.lbl_harcamalar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_harcamalar.Location = new System.Drawing.Point(333, 96);
            this.lbl_harcamalar.Name = "lbl_harcamalar";
            this.lbl_harcamalar.Size = new System.Drawing.Size(87, 19);
            this.lbl_harcamalar.Style = MetroFramework.MetroColorStyle.Red;
            this.lbl_harcamalar.TabIndex = 82;
            this.lbl_harcamalar.Text = "Harcamalar -";
            this.lbl_harcamalar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.lbl_harcamalar.UseCustomBackColor = true;
            this.lbl_harcamalar.UseCustomForeColor = true;
            this.lbl_harcamalar.UseStyleColors = true;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.metroLabel8.Location = new System.Drawing.Point(329, 329);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(110, 19);
            this.metroLabel8.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel8.TabIndex = 81;
            this.metroLabel8.Text = "Proje Bitiş Tarihi :";
            this.metroLabel8.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel8.UseCustomBackColor = true;
            this.metroLabel8.UseCustomForeColor = true;
            this.metroLabel8.UseStyleColors = true;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.metroLabel7.Location = new System.Drawing.Point(302, 182);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(141, 19);
            this.metroLabel7.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel7.TabIndex = 80;
            this.metroLabel7.Text = "Proje Başlangıç Tarihi :";
            this.metroLabel7.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel7.UseCustomBackColor = true;
            this.metroLabel7.UseCustomForeColor = true;
            this.metroLabel7.UseStyleColors = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.metroLabel6.Location = new System.Drawing.Point(381, 259);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(46, 19);
            this.metroLabel6.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel6.TabIndex = 79;
            this.metroLabel6.Text = "Vade :";
            this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel6.UseCustomBackColor = true;
            this.metroLabel6.UseCustomForeColor = true;
            this.metroLabel6.UseStyleColors = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.metroLabel5.Location = new System.Drawing.Point(26, 353);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(59, 19);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel5.TabIndex = 78;
            this.metroLabel5.Text = "Müşteri :";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel5.UseCustomBackColor = true;
            this.metroLabel5.UseCustomForeColor = true;
            this.metroLabel5.UseStyleColors = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.metroLabel4.Location = new System.Drawing.Point(26, 300);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(47, 19);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel4.TabIndex = 77;
            this.metroLabel4.Text = "Birim :";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel4.UseCustomBackColor = true;
            this.metroLabel4.UseCustomForeColor = true;
            this.metroLabel4.UseStyleColors = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.metroLabel3.Location = new System.Drawing.Point(26, 253);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(91, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel3.TabIndex = 76;
            this.metroLabel3.Text = "Proje Bütçesi :";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel3.UseCustomBackColor = true;
            this.metroLabel3.UseCustomForeColor = true;
            this.metroLabel3.UseStyleColors = true;
            // 
            // dtp_bitis
            // 
            this.dtp_bitis.Location = new System.Drawing.Point(456, 323);
            this.dtp_bitis.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtp_bitis.Name = "dtp_bitis";
            this.dtp_bitis.Size = new System.Drawing.Size(200, 29);
            this.dtp_bitis.TabIndex = 75;
            // 
            // dtp_baslangıc
            // 
            this.dtp_baslangıc.Location = new System.Drawing.Point(456, 178);
            this.dtp_baslangıc.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtp_baslangıc.Name = "dtp_baslangıc";
            this.dtp_baslangıc.Size = new System.Drawing.Size(200, 29);
            this.dtp_baslangıc.TabIndex = 74;
            // 
            // txt_vade
            // 
            // 
            // 
            // 
            this.txt_vade.CustomButton.Image = null;
            this.txt_vade.CustomButton.Location = new System.Drawing.Point(134, 1);
            this.txt_vade.CustomButton.Name = "";
            this.txt_vade.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_vade.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_vade.CustomButton.TabIndex = 1;
            this.txt_vade.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_vade.CustomButton.UseSelectable = true;
            this.txt_vade.CustomButton.Visible = false;
            this.txt_vade.Lines = new string[0];
            this.txt_vade.Location = new System.Drawing.Point(462, 255);
            this.txt_vade.MaxLength = 32767;
            this.txt_vade.Name = "txt_vade";
            this.txt_vade.PasswordChar = '\0';
            this.txt_vade.PromptText = "Gün olarak giriniz";
            this.txt_vade.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_vade.SelectedText = "";
            this.txt_vade.SelectionLength = 0;
            this.txt_vade.SelectionStart = 0;
            this.txt_vade.ShortcutsEnabled = true;
            this.txt_vade.Size = new System.Drawing.Size(156, 23);
            this.txt_vade.Style = MetroFramework.MetroColorStyle.Red;
            this.txt_vade.TabIndex = 72;
            this.txt_vade.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txt_vade.UseCustomBackColor = true;
            this.txt_vade.UseCustomForeColor = true;
            this.txt_vade.UseSelectable = true;
            this.txt_vade.UseStyleColors = true;
            this.txt_vade.WaterMark = "Gün olarak giriniz";
            this.txt_vade.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_vade.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txt_musteri
            // 
            // 
            // 
            // 
            this.txt_musteri.CustomButton.Image = null;
            this.txt_musteri.CustomButton.Location = new System.Drawing.Point(134, 1);
            this.txt_musteri.CustomButton.Name = "";
            this.txt_musteri.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_musteri.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_musteri.CustomButton.TabIndex = 1;
            this.txt_musteri.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_musteri.CustomButton.UseSelectable = true;
            this.txt_musteri.CustomButton.Visible = false;
            this.txt_musteri.Lines = new string[0];
            this.txt_musteri.Location = new System.Drawing.Point(128, 353);
            this.txt_musteri.MaxLength = 32767;
            this.txt_musteri.Name = "txt_musteri";
            this.txt_musteri.PasswordChar = '\0';
            this.txt_musteri.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_musteri.SelectedText = "";
            this.txt_musteri.SelectionLength = 0;
            this.txt_musteri.SelectionStart = 0;
            this.txt_musteri.ShortcutsEnabled = true;
            this.txt_musteri.Size = new System.Drawing.Size(156, 23);
            this.txt_musteri.Style = MetroFramework.MetroColorStyle.Red;
            this.txt_musteri.TabIndex = 71;
            this.txt_musteri.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txt_musteri.UseCustomBackColor = true;
            this.txt_musteri.UseCustomForeColor = true;
            this.txt_musteri.UseSelectable = true;
            this.txt_musteri.UseStyleColors = true;
            this.txt_musteri.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_musteri.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txt_butce
            // 
            // 
            // 
            // 
            this.txt_butce.CustomButton.Image = null;
            this.txt_butce.CustomButton.Location = new System.Drawing.Point(134, 1);
            this.txt_butce.CustomButton.Name = "";
            this.txt_butce.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_butce.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_butce.CustomButton.TabIndex = 1;
            this.txt_butce.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_butce.CustomButton.UseSelectable = true;
            this.txt_butce.CustomButton.Visible = false;
            this.txt_butce.Lines = new string[0];
            this.txt_butce.Location = new System.Drawing.Point(128, 255);
            this.txt_butce.MaxLength = 32767;
            this.txt_butce.Name = "txt_butce";
            this.txt_butce.PasswordChar = '\0';
            this.txt_butce.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_butce.SelectedText = "";
            this.txt_butce.SelectionLength = 0;
            this.txt_butce.SelectionStart = 0;
            this.txt_butce.ShortcutsEnabled = true;
            this.txt_butce.Size = new System.Drawing.Size(156, 23);
            this.txt_butce.Style = MetroFramework.MetroColorStyle.Red;
            this.txt_butce.TabIndex = 68;
            this.txt_butce.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txt_butce.UseCustomBackColor = true;
            this.txt_butce.UseCustomForeColor = true;
            this.txt_butce.UseSelectable = true;
            this.txt_butce.UseStyleColors = true;
            this.txt_butce.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_butce.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txt_proje_adı
            // 
            // 
            // 
            // 
            this.txt_proje_adı.CustomButton.Image = null;
            this.txt_proje_adı.CustomButton.Location = new System.Drawing.Point(134, 1);
            this.txt_proje_adı.CustomButton.Name = "";
            this.txt_proje_adı.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_proje_adı.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_proje_adı.CustomButton.TabIndex = 1;
            this.txt_proje_adı.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_proje_adı.CustomButton.UseSelectable = true;
            this.txt_proje_adı.CustomButton.Visible = false;
            this.txt_proje_adı.Lines = new string[0];
            this.txt_proje_adı.Location = new System.Drawing.Point(128, 201);
            this.txt_proje_adı.MaxLength = 32767;
            this.txt_proje_adı.Name = "txt_proje_adı";
            this.txt_proje_adı.PasswordChar = '\0';
            this.txt_proje_adı.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_proje_adı.SelectedText = "";
            this.txt_proje_adı.SelectionLength = 0;
            this.txt_proje_adı.SelectionStart = 0;
            this.txt_proje_adı.ShortcutsEnabled = true;
            this.txt_proje_adı.Size = new System.Drawing.Size(156, 23);
            this.txt_proje_adı.Style = MetroFramework.MetroColorStyle.Red;
            this.txt_proje_adı.TabIndex = 66;
            this.txt_proje_adı.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txt_proje_adı.UseCustomBackColor = true;
            this.txt_proje_adı.UseCustomForeColor = true;
            this.txt_proje_adı.UseSelectable = true;
            this.txt_proje_adı.UseStyleColors = true;
            this.txt_proje_adı.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_proje_adı.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ck_seri
            // 
            this.ck_seri.AutoSize = true;
            this.ck_seri.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ck_seri.Location = new System.Drawing.Point(26, 100);
            this.ck_seri.Name = "ck_seri";
            this.ck_seri.Size = new System.Drawing.Size(81, 15);
            this.ck_seri.Style = MetroFramework.MetroColorStyle.Red;
            this.ck_seri.TabIndex = 70;
            this.ck_seri.Text = "Seri Üretim";
            this.ck_seri.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ck_seri.UseCustomBackColor = true;
            this.ck_seri.UseCustomForeColor = true;
            this.ck_seri.UseSelectable = true;
            this.ck_seri.UseStyleColors = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.metroLabel2.Location = new System.Drawing.Point(26, 199);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(71, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel2.TabIndex = 67;
            this.metroLabel2.Text = "Proje Adı :";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel2.UseCustomBackColor = true;
            this.metroLabel2.UseCustomForeColor = true;
            this.metroLabel2.UseStyleColors = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.metroLabel1.Location = new System.Drawing.Point(26, 149);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(69, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel1.TabIndex = 65;
            this.metroLabel1.Text = "Proje No :";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel1.UseCustomBackColor = true;
            this.metroLabel1.UseCustomForeColor = true;
            this.metroLabel1.UseStyleColors = true;
            // 
            // txt_proje_no
            // 
            // 
            // 
            // 
            this.txt_proje_no.CustomButton.Image = null;
            this.txt_proje_no.CustomButton.Location = new System.Drawing.Point(134, 1);
            this.txt_proje_no.CustomButton.Name = "";
            this.txt_proje_no.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_proje_no.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_proje_no.CustomButton.TabIndex = 1;
            this.txt_proje_no.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_proje_no.CustomButton.UseSelectable = true;
            this.txt_proje_no.CustomButton.Visible = false;
            this.txt_proje_no.Lines = new string[0];
            this.txt_proje_no.Location = new System.Drawing.Point(128, 150);
            this.txt_proje_no.MaxLength = 32767;
            this.txt_proje_no.Name = "txt_proje_no";
            this.txt_proje_no.PasswordChar = '\0';
            this.txt_proje_no.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_proje_no.SelectedText = "";
            this.txt_proje_no.SelectionLength = 0;
            this.txt_proje_no.SelectionStart = 0;
            this.txt_proje_no.ShortcutsEnabled = true;
            this.txt_proje_no.Size = new System.Drawing.Size(156, 23);
            this.txt_proje_no.Style = MetroFramework.MetroColorStyle.Red;
            this.txt_proje_no.TabIndex = 64;
            this.txt_proje_no.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txt_proje_no.UseCustomBackColor = true;
            this.txt_proje_no.UseCustomForeColor = true;
            this.txt_proje_no.UseSelectable = true;
            this.txt_proje_no.UseStyleColors = true;
            this.txt_proje_no.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_proje_no.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // cmb_birim
            // 
            this.cmb_birim.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmb_birim.FormattingEnabled = true;
            this.cmb_birim.ItemHeight = 23;
            this.cmb_birim.Items.AddRange(new object[] {
            "USD",
            "EUR",
            "TRY",
            "CHF",
            "GBP"});
            this.cmb_birim.Location = new System.Drawing.Point(128, 299);
            this.cmb_birim.Name = "cmb_birim";
            this.cmb_birim.Size = new System.Drawing.Size(156, 29);
            this.cmb_birim.Style = MetroFramework.MetroColorStyle.Red;
            this.cmb_birim.TabIndex = 69;
            this.cmb_birim.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cmb_birim.UseCustomBackColor = true;
            this.cmb_birim.UseCustomForeColor = true;
            this.cmb_birim.UseSelectable = true;
            this.cmb_birim.UseStyleColors = true;
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_id.Location = new System.Drawing.Point(623, 69);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(21, 19);
            this.lbl_id.Style = MetroFramework.MetroColorStyle.Red;
            this.lbl_id.TabIndex = 124;
            this.lbl_id.Text = "ID";
            this.lbl_id.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.lbl_id.UseCustomBackColor = true;
            this.lbl_id.UseCustomForeColor = true;
            this.lbl_id.UseStyleColors = true;
            this.lbl_id.Visible = false;
            // 
            // ProjeDuzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 517);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_id);
            this.Controls.Add(this.pbClose);
            this.Controls.Add(this.btn_prjDZN);
            this.Controls.Add(this.btn_harcamalar);
            this.Controls.Add(this.rcb_acıklama);
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.ck_prj);
            this.Controls.Add(this.lbl_birim);
            this.Controls.Add(this.lbl_harcamalar);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.dtp_bitis);
            this.Controls.Add(this.dtp_baslangıc);
            this.Controls.Add(this.txt_vade);
            this.Controls.Add(this.txt_musteri);
            this.Controls.Add(this.txt_butce);
            this.Controls.Add(this.txt_proje_adı);
            this.Controls.Add(this.ck_seri);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txt_proje_no);
            this.Controls.Add(this.cmb_birim);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjeDuzenle";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Proje Düzenle";
            this.Load += new System.EventHandler(this.ProjeDuzenle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbClose;
        public MetroFramework.Controls.MetroButton btn_prjDZN;
        public MetroFramework.Controls.MetroButton btn_harcamalar;
        public System.Windows.Forms.RichTextBox rcb_acıklama;
        public MetroFramework.Controls.MetroLabel metroLabel11;
        public MetroFramework.Controls.MetroCheckBox ck_prj;
        public MetroFramework.Controls.MetroLabel lbl_birim;
        public MetroFramework.Controls.MetroLabel lbl_harcamalar;
        public MetroFramework.Controls.MetroLabel metroLabel8;
        public MetroFramework.Controls.MetroLabel metroLabel7;
        public MetroFramework.Controls.MetroLabel metroLabel6;
        public MetroFramework.Controls.MetroLabel metroLabel5;
        public MetroFramework.Controls.MetroLabel metroLabel4;
        public MetroFramework.Controls.MetroLabel metroLabel3;
        public MetroFramework.Controls.MetroDateTime dtp_bitis;
        public MetroFramework.Controls.MetroDateTime dtp_baslangıc;
        public MetroFramework.Controls.MetroTextBox txt_vade;
        public MetroFramework.Controls.MetroTextBox txt_musteri;
        public MetroFramework.Controls.MetroTextBox txt_butce;
        public MetroFramework.Controls.MetroTextBox txt_proje_adı;
        public MetroFramework.Controls.MetroCheckBox ck_seri;
        public MetroFramework.Controls.MetroLabel metroLabel2;
        public MetroFramework.Controls.MetroLabel metroLabel1;
        public MetroFramework.Controls.MetroTextBox txt_proje_no;
        public MetroFramework.Controls.MetroComboBox cmb_birim;
        public MetroFramework.Controls.MetroLabel lbl_id;
    }
}