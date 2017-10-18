using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MERP_MUI
{
    public partial class FaturaDuzenle : MetroFramework.Forms.MetroForm
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        string connectionString;
        string komut;
        MySqlCommand myCommand;
        MySqlDataAdapter da;
        MySqlConnection myConnection;
        DataTable dt = new DataTable();
        DBConnect db;
        HelperFunctions hf;
        decimal fatura_euro;
        string tutar;


        DateTime baslangic;
        DateTime bitis;
        string vade;

        public FaturaDuzenle()
        {
            InitializeComponent();
            hf = new HelperFunctions();
        }

        private void FaturaDuzenle_Load(object sender, EventArgs e)
        {
            server = "localhost";
            database = "uretimplanlama_2";
            uid = "root";
            password = "root";
            //string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            myConnection = new MySqlConnection(connectionString);
            myConnection.Open();

            komut = "SELECT DISTINCT proje_no FROM db_projeler";
            da = new MySqlDataAdapter(komut, connection);
            myCommand = new MySqlCommand(komut, myConnection);
            MySqlDataReader myReader;
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                cmb_projeNo.Items.Add(myReader["proje_no"]);
            }
            myReader.Close();

            komut = "SELECT DISTINCT fatura_firma FROM db_faturalar";
            da = new MySqlDataAdapter(komut, connection);

            myCommand = new MySqlCommand(komut, myConnection);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                cmb_firma.Items.Add(myReader["fatura_firma"]);
            }
            myReader.Close();

            if(lbl_tip.Text=="K")
            {
                ck_kesilen.Checked = true;
            }
            else
            {
                ck_gelen.Checked = true;
            }
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ftr_dzn_Click(object sender, EventArgs e)
        {
            if (txt_ftr_tutar.Text.Contains('.') & txt_ftr_tutar.Text.Contains(','))
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
                tutar = hf.Comma2Dot(txt_ftr_tutar.Text);
                txt_avans.Text = hf.Comma2Dot(txt_avans.Text);

                DateTime dt = Convert.ToDateTime(txt_ftr_tarih.Text);

                string dateToday = dt.ToString("d");
                DayOfWeek day = Convert.ToDateTime(txt_ftr_tarih.Text).DayOfWeek;
                string dayToday = day.ToString();

                if ((day == DayOfWeek.Saturday) || (day == DayOfWeek.Sunday))
                {
                    MessageBoxx frmMessage = new MessageBoxx();
                    frmMessage.txtMessage.Text = "Lütfen hafta içi olacak bir tarih giriniz!";
                    frmMessage.Show();
                }
                else
                {
                    fatura_euro = Convert.ToDecimal(hf.EuroCalculation(txt_ftr_tarih.Text, txt_ftr_tutar.Text, cmb_birim.Text, Convert.ToString(fatura_euro)));

                    if (fatura_euro == Convert.ToDecimal(0000))
                    {
                        MessageBoxx frmMessage = new MessageBoxx();
                        frmMessage.txtMessage.Text = "Lütfen İnternete Bağlanınız";
                        frmMessage.Show();
                    }
                    else
                    {
                        vade = Convert.ToString(txt_ftr_vade.Text);
                        baslangic = Convert.ToDateTime(txt_ftr_tarih.Text);
                        bitis = baslangic.AddDays(int.Parse(vade));

                        if (cb_durum.Checked)
                        {
                            db = new DBConnect();
                            db.UpdateFaturalar(Convert.ToInt32(lbl_id.Text), Convert.ToString(txt_fatura_no.Text), Convert.ToString(cmb_projeNo.Text), Convert.ToString(cmb_firma.Text), Convert.ToInt32(txt_ftr_vade.Text), bitis, Convert.ToString(rcb_acıklama.Text), Convert.ToDateTime(txt_ftr_tarih.Text), ck_alarm.Checked, Convert.ToDecimal(txt_ftr_tutar.Text), Convert.ToString(cmb_birim.Text), Convert.ToInt32(txt_avans.Text), fatura_euro, Convert.ToString(lbl_tip.Text), Convert.ToString(cmb_ftr_tip.Text), Convert.ToString("ODENDI"));
                            this.Close();
                        }
                        else
                        {
                            db = new DBConnect();
                            db.UpdateFaturalar(Convert.ToInt32(lbl_id.Text), Convert.ToString(txt_fatura_no.Text), Convert.ToString(cmb_projeNo.Text), Convert.ToString(cmb_firma.Text), Convert.ToInt32(txt_ftr_vade.Text), bitis, Convert.ToString(rcb_acıklama.Text), Convert.ToDateTime(txt_ftr_tarih.Text), ck_alarm.Checked, Convert.ToDecimal(txt_ftr_tutar.Text), Convert.ToString(cmb_birim.Text), Convert.ToInt32(txt_avans.Text), fatura_euro, Convert.ToString(lbl_tip.Text), Convert.ToString(cmb_ftr_tip.Text), Convert.ToString("ODENMEDI"));
                            this.Close();
                        }
                    }
                }
            }
        }

        private void txt_ftr_vade_TextChanged(object sender, EventArgs e)
        {
            try
            {
                vade = Convert.ToString(txt_ftr_vade.Text);
                baslangic = Convert.ToDateTime(txt_ftr_tarih.Text);
                bitis = baslangic.AddDays(int.Parse(vade));
                date_alarm.Value = bitis;
            }
            catch
            {

            }
        }

        private void cmb_firma_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
