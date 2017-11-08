using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MERP_MUI
{
    public partial class SiparisEmriDuzenle : MetroFramework.Forms.MetroForm
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
        
        string siparis_euro;
        string siparis_dolar;
        string siparis_tl;

        public SiparisEmriDuzenle()
        {
            InitializeComponent();
            hf = new HelperFunctions();
        }

        private void SiparisEmriDuzenle_Load(object sender, EventArgs e)
        {
            server = "localhost";
            database = "merp_dbv1";
            uid = "root";
            password = "root";
            //string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            myConnection = new MySqlConnection(connectionString);
            myConnection.Open();


            komut = "SELECT DISTINCT proje_no FROM db_projeler";
            da = new MySqlDataAdapter(komut, connection);

            //  myConnection = new MySqlConnection(connectionString);
            myCommand = new MySqlCommand(komut, myConnection);
            //   myConnection.Open();
            MySqlDataReader myReader;
            myReader = myCommand.ExecuteReader();
            // Always call Read before accessing data.
            while (myReader.Read())
            {
                cmb_prjno.Items.Add(myReader["proje_no"]);
            }
            myReader.Close();

            komut = "SELECT DISTINCT tedarikci FROM db_siparis_emri";
            da = new MySqlDataAdapter(komut, connection);

            myCommand = new MySqlCommand(komut, myConnection);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                cmb_tedarikci.Items.Add(myReader["tedarikci"]);
            }
            myReader.Close();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_duzenle_Click(object sender, EventArgs e)
        {
            if (txt_mlz_brmFiyat.Text.Contains('.') & txt_mlz_brmFiyat.Text.Contains(','))
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
                txt_mlz_brmFiyat.Text = hf.Comma2Dot(txt_mlz_brmFiyat.Text);

                DateTime dt = Convert.ToDateTime(date_teslim.Text);

                string dateToday = dt.ToString("d");
                DayOfWeek day = Convert.ToDateTime(date_teslim.Text).DayOfWeek;


                if ((day == DayOfWeek.Saturday) || (day == DayOfWeek.Sunday))
                {
                    MessageBox.Show("Lütfen hafta içi olacak bir tarih giriniz! ");
                }
                else
                {
                    siparis_euro = hf.EuroCalculation(date_teslim.Text, txt_mlz_brmFiyat.Text, cmb_paraBirimi.Text, siparis_euro);
                    siparis_dolar = hf.DolarCalculation(date_teslim.Text, txt_mlz_brmFiyat.Text, cmb_paraBirimi.Text, siparis_dolar);
                    siparis_tl = hf.TLCalculation(date_teslim.Text, txt_mlz_brmFiyat.Text, cmb_paraBirimi.Text, siparis_tl);

                    db = new DBConnect();
                    if(rb_gelen.Checked)
                    {
                        db.UpdateSE(Convert.ToInt32(lbl_id.Text), Convert.ToString(cmb_prjno.Text), Convert.ToString(txt_siparisNo.Text), Convert.ToString(cmb_tedarikci.Text), Convert.ToString(txt_talepKisi.Text), Convert.ToDateTime(date_teslim.Text), Convert.ToInt32(txt_vade.Text), Convert.ToDateTime(date_temin.Text), Convert.ToDecimal(txt_mlz_brmFiyat.Text), Convert.ToString(cmb_paraBirimi.Text), Convert.ToDecimal(siparis_euro), Convert.ToDecimal(siparis_dolar), Convert.ToDecimal(siparis_tl), Convert.ToString(rcb_aciklama.Text), Convert.ToString("Gelen"));
                    }
                    if(rb_verilen.Checked)
                    {
                        db.UpdateSE(Convert.ToInt32(lbl_id.Text), Convert.ToString(cmb_prjno.Text), Convert.ToString(txt_siparisNo.Text), Convert.ToString(cmb_tedarikci.Text), Convert.ToString(txt_talepKisi.Text), Convert.ToDateTime(date_teslim.Text), Convert.ToInt32(txt_vade.Text), Convert.ToDateTime(date_temin.Text), Convert.ToDecimal(txt_mlz_brmFiyat.Text), Convert.ToString(cmb_paraBirimi.Text), Convert.ToDecimal(siparis_euro), Convert.ToDecimal(siparis_dolar), Convert.ToDecimal(siparis_tl), Convert.ToString(rcb_aciklama.Text), Convert.ToString("Verilen"));
                    }
                   
                    this.Close();
                }
            }
        }
    }
}
