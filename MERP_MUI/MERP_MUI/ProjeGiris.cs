using MySql.Data.MySqlClient;
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

        public string harcama_m_mlz;
        public string harcama_el_mlz;
        public string harcama_imalat;
        public string harcama_test;
        public string harcama_risk;
        public string odeme_avans;
        public string odeme_pdr;
        public string odeme_cdr;
        public string odeme_prototip;
        public string odeme_test;
        public string odeme_kabul;
        public string s6;

        public string flag;

        public DateTime dtp_avans;
        public DateTime dtp_test;
        public DateTime dtp_kabul;
        public DateTime dtp_pdr;
        public DateTime dtp_cdr;
        public DateTime dtp_prototip;
        public DateTime dtp_s6;

        DateTime baslangic;
        DateTime bitis;
        string vade;

        public ProjeGiris()
        {
            InitializeComponent();
            hf = new HelperFunctions();
        }

        private void ProjeGiris_Load(object sender, EventArgs e)
        {
            server = "localhost";
            database = "uretimplanlama_2";
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

                vade = Convert.ToString(txt_vade.Text);
                baslangic = Convert.ToDateTime(dtp_baslangıc.Text);
                bitis = baslangic.AddDays(int.Parse(vade));

                db = new DBConnect();

                db.InsertProjeGiris(Convert.ToString(txt_proje_no.Text), Convert.ToString(txt_proje_adı.Text), Convert.ToDecimal(txt_butce.Text), Convert.ToString(cmb_birim.Text), Convert.ToString(txt_musteri.Text), Convert.ToDateTime(dtp_baslangıc.Text), Convert.ToDateTime(bitis), Convert.ToInt32(txt_vade.Text), Convert.ToString(rcb_acıklama.Text), Convert.ToDecimal(harcama_m_mlz), Convert.ToDecimal(harcama_el_mlz), Convert.ToDecimal(harcama_imalat), Convert.ToDecimal(harcama_test), Convert.ToDecimal(harcama_risk), Convert.ToDecimal(lbl_harcamalar.Text), Convert.ToString(lbl_birim.Text), Convert.ToDecimal(odeme_avans), Convert.ToDateTime(dtp_avans), Convert.ToDecimal(odeme_pdr), Convert.ToDateTime(dtp_pdr), Convert.ToDecimal(odeme_cdr), Convert.ToDateTime(dtp_cdr), Convert.ToDecimal(odeme_prototip), Convert.ToDateTime(dtp_prototip), Convert.ToDecimal(odeme_test), Convert.ToDateTime(dtp_test), Convert.ToDecimal(odeme_kabul), Convert.ToDateTime(dtp_kabul), Convert.ToDecimal(s6), Convert.ToDateTime(dtp_s6), Convert.ToString(flag));
                this.Close();
            }
        }

        private void btn_harcamalar_Click(object sender, EventArgs e)
        {
            if (ck_prj.Checked)
            {
                flag = "P";
                HarcamaOngorusu f1 = new HarcamaOngorusu();
                f1.lbl_pdr.Text = "PDR";
                f1.lbl_cdr.Text = "CDR";
                f1.lbl_prototip.Text = "Prototip";
                f1.lbl_kabul.Text = "Kabul";
                f1.lbl_test.Text = "Test";
                f1.lbl_s6.Enabled = false;
                f1.txt_s6.Enabled = false;
                f1.dtp_s6.Enabled = false;
                f1.Show();
            }
            else
            {
                flag = "S";
                HarcamaOngorusu f1 = new HarcamaOngorusu();
                f1.lbl_pdr.Text = "S1";
                f1.lbl_cdr.Text = "S2";
                f1.lbl_prototip.Text = "S3";
                f1.lbl_kabul.Text = "S5";
                f1.lbl_test.Text = "S4";
                f1.lbl_s6.Enabled = true;
                f1.txt_s6.Enabled = true;
                f1.dtp_s6.Enabled = true;
                f1.Show();
            }
        }
    }
}
