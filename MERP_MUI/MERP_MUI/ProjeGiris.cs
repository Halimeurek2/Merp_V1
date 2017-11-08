﻿using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MERP_MUI
{
    public partial class ProjeGiris : MetroFramework.Forms.MetroForm
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        string connectionString;
        MySqlConnection myConnection;

        DataTable dt = new DataTable();
        DBConnect db;
        HelperFunctions hf;

        public int[,] HarcamaArray;
        string komut;
        MySqlCommand myCommand;
        MySqlDataAdapter da;

        public string flag;

        DateTime baslangic;
        DateTime bitis;
        string vade;

        decimal proje_euro;
        decimal proje_dolar;
        decimal proje_tl;

        HarcamaOngorusu f1 = new HarcamaOngorusu();

        public ProjeGiris()
        {
            InitializeComponent();
            hf = new HelperFunctions();
        }

        private void ProjeGiris_Load(object sender, EventArgs e)
        {
            server = "localhost";
            database = "merp_dbv1";
            uid = "root";
            password = "root";
            //string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            myConnection = new MySqlConnection(connectionString);
            myConnection.Open();

   
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_prjDZN_Click(object sender, EventArgs e)
        {
            if (txt_butce.Text.Contains('.') & txt_butce.Text.Contains(','))
            {
                DialogResult uyarı = new DialogResult();
                uyarı = MessageBox.Show("Aynı anda hem virgül hem nokta giremezsiniz!", "FATURA SİLME", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (uyarı == DialogResult.OK)
                {

                }
                else
                {

                }
            }
            else
            {
                txt_butce.Text = hf.Comma2Dot(txt_butce.Text);
                lbl_harcamalar.Text = hf.Comma2Dot(lbl_harcamalar.Text);

                proje_euro = Convert.ToDecimal(hf.EuroCalculation(Convert.ToString(dtp_baslangıc.Value), txt_butce.Text, cmb_birim.Text, Convert.ToString(proje_euro)));
                proje_dolar = Convert.ToDecimal(hf.DolarCalculation(Convert.ToString(dtp_baslangıc.Value), txt_butce.Text, cmb_birim.Text, Convert.ToString(proje_dolar)));
                proje_tl = Convert.ToDecimal(hf.TLCalculation(Convert.ToString(dtp_baslangıc.Value), txt_butce.Text, cmb_birim.Text, Convert.ToString(proje_tl)));

                vade = Convert.ToString(txt_vade.Text);
                baslangic = Convert.ToDateTime(dtp_baslangıc.Text);
                bitis = baslangic.AddDays(int.Parse(vade));

                db = new DBConnect();

                if(ck_prj.Checked)
                {
                    db.InsertProjeGiris(Convert.ToString(txt_proje_no.Text), Convert.ToString(txt_proje_adı.Text), Convert.ToDecimal(txt_butce.Text), Convert.ToString(cmb_birim.Text), proje_euro, proje_dolar, proje_tl, Convert.ToString(txt_musteri.Text), Convert.ToDateTime(dtp_baslangıc.Text), Convert.ToDateTime(bitis), Convert.ToInt32(txt_vade.Text), Convert.ToString(rcb_acıklama.Text), Convert.ToDecimal(f1.toplam), Convert.ToString("EURO"), Convert.ToString("P"));
                }
                if(ck_seri.Checked)
                {
                    db.InsertProjeGiris(Convert.ToString(txt_proje_no.Text), Convert.ToString(txt_proje_adı.Text), Convert.ToDecimal(txt_butce.Text), Convert.ToString(cmb_birim.Text), proje_euro, proje_dolar, proje_tl, Convert.ToString(txt_musteri.Text), Convert.ToDateTime(dtp_baslangıc.Text), Convert.ToDateTime(bitis), Convert.ToInt32(txt_vade.Text), Convert.ToString(rcb_acıklama.Text), Convert.ToDecimal(f1.toplam), Convert.ToString("EURO"), Convert.ToString("S"));
                }


                komut = "SELECT * FROM db_projeler WHERE proje_no ='" + txt_proje_no.Text + "'";
                da = new MySqlDataAdapter(komut, connection);

                myConnection = new MySqlConnection(connectionString);
                myCommand = new MySqlCommand(komut, myConnection);
                myConnection.Open();
                MySqlDataReader myReader;
                myReader = myCommand.ExecuteReader();

                // Always call Read before accessing data.

                while (myReader.Read())
                {
                    for (int i = 0; i < f1.dgw_harcama.Rows.Count - 1; i++)
                    {
                        db.InsertHarcamalar(myReader.GetInt32(0), Convert.ToString(f1.dgw_harcama.Rows[i].Cells[1].Value), Convert.ToDecimal(f1.dgw_harcama.Rows[i].Cells[2].Value), Convert.ToString(f1.dgw_harcama.Rows[i].Cells[3].Value), Convert.ToDateTime(f1.dgw_harcama.Rows[i].Cells[0].Value));
                    }
                    for (int i = 0; i < f1.dgw_odeme.Rows.Count - 1; i++)
                    {
                        db.InsertOdemeler(myReader.GetInt32(0), Convert.ToString(f1.dgw_odeme.Rows[i].Cells[1].Value), Convert.ToDecimal(f1.dgw_odeme.Rows[i].Cells[2].Value), Convert.ToString(f1.dgw_odeme.Rows[i].Cells[3].Value), Convert.ToDateTime(f1.dgw_odeme.Rows[i].Cells[0].Value));
                    }
                }

                this.Close();
                f1.Close();
            }
        }

        private void btn_harcamalar_Click(object sender, EventArgs e)
        {
            f1.Show();
        }
    }
}
