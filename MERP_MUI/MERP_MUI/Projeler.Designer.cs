﻿namespace MERP_MUI
{
    partial class Projeler
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Projeler));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lbl_toplam = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.cmb_projeNo = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txt_prjAdi = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.dgw_prj_list = new MetroFramework.Controls.MetroGrid();
            this.btn_prj_sil = new MetroFramework.Controls.MetroButton();
            this.btn_prj_duzenle = new MetroFramework.Controls.MetroButton();
            this.pbClose = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_prj_list)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(20, 60);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_prj_sil);
            this.splitContainer1.Panel2.Controls.Add(this.btn_prj_duzenle);
            this.splitContainer1.Size = new System.Drawing.Size(857, 491);
            this.splitContainer1.SplitterDistance = 445;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgw_prj_list);
            this.splitContainer2.Size = new System.Drawing.Size(857, 445);
            this.splitContainer2.SplitterDistance = 75;
            this.splitContainer2.SplitterWidth = 20;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.lbl_toplam);
            this.splitContainer3.Panel1.Controls.Add(this.metroLabel4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(857, 75);
            this.splitContainer3.SplitterDistance = 285;
            this.splitContainer3.TabIndex = 0;
            // 
            // lbl_toplam
            // 
            this.lbl_toplam.AutoSize = true;
            this.lbl_toplam.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_toplam.Location = new System.Drawing.Point(19, 43);
            this.lbl_toplam.Name = "lbl_toplam";
            this.lbl_toplam.Size = new System.Drawing.Size(16, 19);
            this.lbl_toplam.Style = MetroFramework.MetroColorStyle.Red;
            this.lbl_toplam.TabIndex = 53;
            this.lbl_toplam.Text = "0";
            this.lbl_toplam.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.lbl_toplam.UseCustomBackColor = true;
            this.lbl_toplam.UseCustomForeColor = true;
            this.lbl_toplam.UseStyleColors = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.metroLabel4.Location = new System.Drawing.Point(0, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(86, 25);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel4.TabIndex = 52;
            this.metroLabel4.Text = "Toplam :";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel4.UseCustomBackColor = true;
            this.metroLabel4.UseCustomForeColor = true;
            this.metroLabel4.UseStyleColors = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.cmb_projeNo);
            this.splitContainer4.Panel1.Controls.Add(this.metroLabel1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.txt_prjAdi);
            this.splitContainer4.Panel2.Controls.Add(this.metroLabel2);
            this.splitContainer4.Size = new System.Drawing.Size(568, 75);
            this.splitContainer4.SplitterDistance = 282;
            this.splitContainer4.TabIndex = 0;
            // 
            // cmb_projeNo
            // 
            this.cmb_projeNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmb_projeNo.FormattingEnabled = true;
            this.cmb_projeNo.ItemHeight = 23;
            this.cmb_projeNo.Location = new System.Drawing.Point(86, 42);
            this.cmb_projeNo.Name = "cmb_projeNo";
            this.cmb_projeNo.Size = new System.Drawing.Size(156, 29);
            this.cmb_projeNo.Style = MetroFramework.MetroColorStyle.Red;
            this.cmb_projeNo.TabIndex = 47;
            this.cmb_projeNo.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cmb_projeNo.UseCustomBackColor = true;
            this.cmb_projeNo.UseCustomForeColor = true;
            this.cmb_projeNo.UseSelectable = true;
            this.cmb_projeNo.UseStyleColors = true;
            this.cmb_projeNo.SelectedIndexChanged += new System.EventHandler(this.cmb_projeNo_SelectedIndexChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.metroLabel1.Location = new System.Drawing.Point(0, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(69, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel1.TabIndex = 48;
            this.metroLabel1.Text = "Proje No :";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel1.UseCustomBackColor = true;
            this.metroLabel1.UseCustomForeColor = true;
            this.metroLabel1.UseStyleColors = true;
            // 
            // txt_prjAdi
            // 
            // 
            // 
            // 
            this.txt_prjAdi.CustomButton.Image = null;
            this.txt_prjAdi.CustomButton.Location = new System.Drawing.Point(134, 1);
            this.txt_prjAdi.CustomButton.Name = "";
            this.txt_prjAdi.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txt_prjAdi.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_prjAdi.CustomButton.TabIndex = 1;
            this.txt_prjAdi.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_prjAdi.CustomButton.UseSelectable = true;
            this.txt_prjAdi.CustomButton.Visible = false;
            this.txt_prjAdi.Lines = new string[0];
            this.txt_prjAdi.Location = new System.Drawing.Point(83, 43);
            this.txt_prjAdi.MaxLength = 32767;
            this.txt_prjAdi.Name = "txt_prjAdi";
            this.txt_prjAdi.PasswordChar = '\0';
            this.txt_prjAdi.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_prjAdi.SelectedText = "";
            this.txt_prjAdi.SelectionLength = 0;
            this.txt_prjAdi.SelectionStart = 0;
            this.txt_prjAdi.ShortcutsEnabled = true;
            this.txt_prjAdi.Size = new System.Drawing.Size(156, 23);
            this.txt_prjAdi.Style = MetroFramework.MetroColorStyle.Red;
            this.txt_prjAdi.TabIndex = 48;
            this.txt_prjAdi.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txt_prjAdi.UseCustomBackColor = true;
            this.txt_prjAdi.UseCustomForeColor = true;
            this.txt_prjAdi.UseSelectable = true;
            this.txt_prjAdi.UseStyleColors = true;
            this.txt_prjAdi.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_prjAdi.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txt_prjAdi.TextChanged += new System.EventHandler(this.txt_prjAdi_TextChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroLabel2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.metroLabel2.Location = new System.Drawing.Point(0, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(71, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel2.TabIndex = 49;
            this.metroLabel2.Text = "Proje Adı :";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel2.UseCustomBackColor = true;
            this.metroLabel2.UseCustomForeColor = true;
            this.metroLabel2.UseStyleColors = true;
            // 
            // dgw_prj_list
            // 
            this.dgw_prj_list.AllowUserToResizeRows = false;
            this.dgw_prj_list.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgw_prj_list.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgw_prj_list.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgw_prj_list.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgw_prj_list.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgw_prj_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgw_prj_list.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgw_prj_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgw_prj_list.EnableHeadersVisualStyles = false;
            this.dgw_prj_list.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgw_prj_list.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgw_prj_list.Location = new System.Drawing.Point(0, 0);
            this.dgw_prj_list.Name = "dgw_prj_list";
            this.dgw_prj_list.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgw_prj_list.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgw_prj_list.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgw_prj_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_prj_list.Size = new System.Drawing.Size(857, 350);
            this.dgw_prj_list.Style = MetroFramework.MetroColorStyle.Silver;
            this.dgw_prj_list.TabIndex = 1;
            this.dgw_prj_list.UseCustomBackColor = true;
            this.dgw_prj_list.UseCustomForeColor = true;
            this.dgw_prj_list.UseStyleColors = true;
            this.dgw_prj_list.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgw_prj_list_RowHeaderMouseClick);
            // 
            // btn_prj_sil
            // 
            this.btn_prj_sil.Highlight = true;
            this.btn_prj_sil.Location = new System.Drawing.Point(658, 2);
            this.btn_prj_sil.Name = "btn_prj_sil";
            this.btn_prj_sil.Size = new System.Drawing.Size(116, 37);
            this.btn_prj_sil.Style = MetroFramework.MetroColorStyle.Red;
            this.btn_prj_sil.TabIndex = 56;
            this.btn_prj_sil.Text = "SİL";
            this.btn_prj_sil.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_prj_sil.UseCustomBackColor = true;
            this.btn_prj_sil.UseCustomForeColor = true;
            this.btn_prj_sil.UseSelectable = true;
            this.btn_prj_sil.UseStyleColors = true;
            this.btn_prj_sil.Click += new System.EventHandler(this.btn_prj_sil_Click);
            // 
            // btn_prj_duzenle
            // 
            this.btn_prj_duzenle.Highlight = true;
            this.btn_prj_duzenle.Location = new System.Drawing.Point(536, 2);
            this.btn_prj_duzenle.Name = "btn_prj_duzenle";
            this.btn_prj_duzenle.Size = new System.Drawing.Size(116, 37);
            this.btn_prj_duzenle.Style = MetroFramework.MetroColorStyle.Red;
            this.btn_prj_duzenle.TabIndex = 55;
            this.btn_prj_duzenle.Text = "DÜZENLE";
            this.btn_prj_duzenle.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btn_prj_duzenle.UseCustomBackColor = true;
            this.btn_prj_duzenle.UseCustomForeColor = true;
            this.btn_prj_duzenle.UseSelectable = true;
            this.btn_prj_duzenle.UseStyleColors = true;
            this.btn_prj_duzenle.Click += new System.EventHandler(this.btn_prj_duzenle_Click);
            // 
            // pbClose
            // 
            this.pbClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbClose.BackColor = System.Drawing.Color.Transparent;
            this.pbClose.Image = global::MERP_MUI.Properties.Resources.appbar_arrow_left_dark;
            this.pbClose.Location = new System.Drawing.Point(831, 12);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(46, 42);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbClose.TabIndex = 26;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // Projeler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 571);
            this.ControlBox = false;
            this.Controls.Add(this.pbClose);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Projeler";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Projeler";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Projeler_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw_prj_list)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private MetroFramework.Controls.MetroButton btn_prj_sil;
        private MetroFramework.Controls.MetroButton btn_prj_duzenle;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private MetroFramework.Controls.MetroLabel lbl_toplam;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private MetroFramework.Controls.MetroComboBox cmb_projeNo;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txt_prjAdi;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroGrid dgw_prj_list;
    }
}