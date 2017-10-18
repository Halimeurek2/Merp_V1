namespace MERP_MUI
{
    partial class AktiviteDuzenle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AktiviteDuzenle));
            this.btn_duzenle = new MetroFramework.Controls.MetroButton();
            this.rcb_acıklama = new System.Windows.Forms.RichTextBox();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.date_bitis = new MetroFramework.Controls.MetroDateTime();
            this.date_olusturma = new MetroFramework.Controls.MetroDateTime();
            this.cmb_rapor_edilecek = new MetroFramework.Controls.MetroComboBox();
            this.cmb_statu = new MetroFramework.Controls.MetroComboBox();
            this.cmb_oncelik = new MetroFramework.Controls.MetroComboBox();
            this.cmb_prj_no = new MetroFramework.Controls.MetroComboBox();
            this.lbl_id = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_duzenle
            // 
            this.btn_duzenle.Highlight = true;
            this.btn_duzenle.Location = new System.Drawing.Point(252, 492);
            this.btn_duzenle.Name = "btn_duzenle";
            this.btn_duzenle.Size = new System.Drawing.Size(120, 42);
            this.btn_duzenle.Style = MetroFramework.MetroColorStyle.Red;
            this.btn_duzenle.TabIndex = 110;
            this.btn_duzenle.Text = "Düzenle";
            this.btn_duzenle.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_duzenle.UseCustomBackColor = true;
            this.btn_duzenle.UseCustomForeColor = true;
            this.btn_duzenle.UseSelectable = true;
            this.btn_duzenle.UseStyleColors = true;
            this.btn_duzenle.Click += new System.EventHandler(this.btn_duzenle_Click);
            // 
            // rcb_acıklama
            // 
            this.rcb_acıklama.Location = new System.Drawing.Point(104, 395);
            this.rcb_acıklama.Name = "rcb_acıklama";
            this.rcb_acıklama.Size = new System.Drawing.Size(268, 87);
            this.rcb_acıklama.TabIndex = 99;
            this.rcb_acıklama.Text = "";
            // 
            // pbClose
            // 
            this.pbClose.BackColor = System.Drawing.Color.Transparent;
            this.pbClose.Image = global::MERP_MUI.Properties.Resources.appbar_arrow_left_dark;
            this.pbClose.Location = new System.Drawing.Point(326, 25);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(46, 42);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbClose.TabIndex = 109;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.metroLabel2.Location = new System.Drawing.Point(29, 388);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(69, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel2.TabIndex = 108;
            this.metroLabel2.Text = "Açıklama :";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel2.UseCustomBackColor = true;
            this.metroLabel2.UseCustomForeColor = true;
            this.metroLabel2.UseStyleColors = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.metroLabel1.Location = new System.Drawing.Point(29, 342);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(72, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel1.TabIndex = 107;
            this.metroLabel1.Text = "Bitiş Tarih :";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel1.UseCustomBackColor = true;
            this.metroLabel1.UseCustomForeColor = true;
            this.metroLabel1.UseStyleColors = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.metroLabel6.Location = new System.Drawing.Point(29, 248);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(103, 19);
            this.metroLabel6.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel6.TabIndex = 106;
            this.metroLabel6.Text = "Rapor Edilecek :";
            this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel6.UseCustomBackColor = true;
            this.metroLabel6.UseCustomForeColor = true;
            this.metroLabel6.UseStyleColors = true;
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.metroLabel11.Location = new System.Drawing.Point(29, 198);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(45, 19);
            this.metroLabel11.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel11.TabIndex = 105;
            this.metroLabel11.Text = "Statu :";
            this.metroLabel11.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel11.UseCustomBackColor = true;
            this.metroLabel11.UseCustomForeColor = true;
            this.metroLabel11.UseStyleColors = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.metroLabel5.Location = new System.Drawing.Point(29, 151);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(59, 19);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel5.TabIndex = 104;
            this.metroLabel5.Text = "Öncelik :";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel5.UseCustomBackColor = true;
            this.metroLabel5.UseCustomForeColor = true;
            this.metroLabel5.UseStyleColors = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.metroLabel4.Location = new System.Drawing.Point(29, 297);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(115, 19);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel4.TabIndex = 103;
            this.metroLabel4.Text = "Oluşturulan Tarih :";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel4.UseCustomBackColor = true;
            this.metroLabel4.UseCustomForeColor = true;
            this.metroLabel4.UseStyleColors = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.metroLabel3.Location = new System.Drawing.Point(29, 104);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(69, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel3.TabIndex = 102;
            this.metroLabel3.Text = "Proje No :";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel3.UseCustomBackColor = true;
            this.metroLabel3.UseCustomForeColor = true;
            this.metroLabel3.UseStyleColors = true;
            // 
            // date_bitis
            // 
            this.date_bitis.Location = new System.Drawing.Point(155, 339);
            this.date_bitis.MinimumSize = new System.Drawing.Size(0, 29);
            this.date_bitis.Name = "date_bitis";
            this.date_bitis.Size = new System.Drawing.Size(200, 29);
            this.date_bitis.TabIndex = 101;
            // 
            // date_olusturma
            // 
            this.date_olusturma.Location = new System.Drawing.Point(155, 292);
            this.date_olusturma.MinimumSize = new System.Drawing.Size(0, 29);
            this.date_olusturma.Name = "date_olusturma";
            this.date_olusturma.Size = new System.Drawing.Size(200, 29);
            this.date_olusturma.TabIndex = 100;
            // 
            // cmb_rapor_edilecek
            // 
            this.cmb_rapor_edilecek.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmb_rapor_edilecek.FormattingEnabled = true;
            this.cmb_rapor_edilecek.ItemHeight = 23;
            this.cmb_rapor_edilecek.Items.AddRange(new object[] {
            "M. Emin İLKMEN",
            "Z. Burak MERCAN",
            "Kemal BERKKAN",
            "Murat KOÇ",
            "MÜŞTERİ"});
            this.cmb_rapor_edilecek.Location = new System.Drawing.Point(179, 245);
            this.cmb_rapor_edilecek.Name = "cmb_rapor_edilecek";
            this.cmb_rapor_edilecek.Size = new System.Drawing.Size(156, 29);
            this.cmb_rapor_edilecek.Style = MetroFramework.MetroColorStyle.Red;
            this.cmb_rapor_edilecek.TabIndex = 98;
            this.cmb_rapor_edilecek.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cmb_rapor_edilecek.UseCustomBackColor = true;
            this.cmb_rapor_edilecek.UseCustomForeColor = true;
            this.cmb_rapor_edilecek.UseSelectable = true;
            this.cmb_rapor_edilecek.UseStyleColors = true;
            // 
            // cmb_statu
            // 
            this.cmb_statu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmb_statu.FormattingEnabled = true;
            this.cmb_statu.ItemHeight = 23;
            this.cmb_statu.Items.AddRange(new object[] {
            "AKTİF",
            "PASİF",
            "BİTTİ",
            "BEKLEMEDE"});
            this.cmb_statu.Location = new System.Drawing.Point(179, 198);
            this.cmb_statu.Name = "cmb_statu";
            this.cmb_statu.Size = new System.Drawing.Size(156, 29);
            this.cmb_statu.Style = MetroFramework.MetroColorStyle.Red;
            this.cmb_statu.TabIndex = 97;
            this.cmb_statu.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cmb_statu.UseCustomBackColor = true;
            this.cmb_statu.UseCustomForeColor = true;
            this.cmb_statu.UseSelectable = true;
            this.cmb_statu.UseStyleColors = true;
            // 
            // cmb_oncelik
            // 
            this.cmb_oncelik.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmb_oncelik.FormattingEnabled = true;
            this.cmb_oncelik.ItemHeight = 23;
            this.cmb_oncelik.Items.AddRange(new object[] {
            "ÇOK ACİL",
            "ACİL",
            "NORMAL",
            "BİR ARA YAPARSIN"});
            this.cmb_oncelik.Location = new System.Drawing.Point(179, 151);
            this.cmb_oncelik.Name = "cmb_oncelik";
            this.cmb_oncelik.Size = new System.Drawing.Size(156, 29);
            this.cmb_oncelik.Style = MetroFramework.MetroColorStyle.Red;
            this.cmb_oncelik.TabIndex = 96;
            this.cmb_oncelik.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cmb_oncelik.UseCustomBackColor = true;
            this.cmb_oncelik.UseCustomForeColor = true;
            this.cmb_oncelik.UseSelectable = true;
            this.cmb_oncelik.UseStyleColors = true;
            // 
            // cmb_prj_no
            // 
            this.cmb_prj_no.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmb_prj_no.FormattingEnabled = true;
            this.cmb_prj_no.ItemHeight = 23;
            this.cmb_prj_no.Location = new System.Drawing.Point(179, 104);
            this.cmb_prj_no.Name = "cmb_prj_no";
            this.cmb_prj_no.Size = new System.Drawing.Size(156, 29);
            this.cmb_prj_no.Style = MetroFramework.MetroColorStyle.Red;
            this.cmb_prj_no.TabIndex = 95;
            this.cmb_prj_no.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cmb_prj_no.UseCustomBackColor = true;
            this.cmb_prj_no.UseCustomForeColor = true;
            this.cmb_prj_no.UseSelectable = true;
            this.cmb_prj_no.UseStyleColors = true;
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_id.Location = new System.Drawing.Point(351, 70);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(21, 19);
            this.lbl_id.Style = MetroFramework.MetroColorStyle.Red;
            this.lbl_id.TabIndex = 125;
            this.lbl_id.Text = "ID";
            this.lbl_id.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.lbl_id.UseCustomBackColor = true;
            this.lbl_id.UseCustomForeColor = true;
            this.lbl_id.UseStyleColors = true;
            this.lbl_id.Visible = false;
            // 
            // AktiviteDuzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 546);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_id);
            this.Controls.Add(this.btn_duzenle);
            this.Controls.Add(this.rcb_acıklama);
            this.Controls.Add(this.pbClose);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.date_bitis);
            this.Controls.Add(this.date_olusturma);
            this.Controls.Add(this.cmb_rapor_edilecek);
            this.Controls.Add(this.cmb_statu);
            this.Controls.Add(this.cmb_oncelik);
            this.Controls.Add(this.cmb_prj_no);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AktiviteDuzenle";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Aktivite Düzenle";
            this.Load += new System.EventHandler(this.AktiviteDuzenle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btn_duzenle;
        private System.Windows.Forms.PictureBox pbClose;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        public System.Windows.Forms.RichTextBox rcb_acıklama;
        public MetroFramework.Controls.MetroDateTime date_bitis;
        public MetroFramework.Controls.MetroDateTime date_olusturma;
        public MetroFramework.Controls.MetroComboBox cmb_rapor_edilecek;
        public MetroFramework.Controls.MetroComboBox cmb_statu;
        public MetroFramework.Controls.MetroComboBox cmb_oncelik;
        public MetroFramework.Controls.MetroComboBox cmb_prj_no;
        public MetroFramework.Controls.MetroLabel lbl_id;
    }
}