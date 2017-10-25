using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MERP_MUI
{
    public partial class ProjeDuzenle : MetroFramework.Forms.MetroForm
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        string connectionString;
        MySqlConnection myConnection;

        string komut;
        MySqlCommand myCommand;
        MySqlDataAdapter da;

        DataTable dt = new DataTable();
        DBConnect db;
        HelperFunctions hf;

        public string flag;
        string vade;
        DateTime baslangic;
        DateTime bitis;

        public ProjeDuzenle()
        {
            InitializeComponent();
            hf = new HelperFunctions();
        }

        private void ProjeDuzenle_Load(object sender, EventArgs e)
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


                vade = Convert.ToString(txt_vade.Text);
                baslangic = Convert.ToDateTime(dtp_baslangıc.Text);
                bitis = baslangic.AddDays(int.Parse(vade));

                if(ck_prj.Checked)
                {
                    db = new DBConnect();
                    db.UpdateProjeler(Convert.ToInt32(lbl_id.Text), Convert.ToString(txt_proje_no.Text), Convert.ToString(txt_proje_adı.Text), Convert.ToDecimal(txt_butce.Text), Convert.ToString(cmb_birim.Text), Convert.ToString(txt_musteri.Text), Convert.ToDateTime(dtp_baslangıc.Text), Convert.ToDateTime(bitis), Convert.ToInt32(txt_vade.Text), Convert.ToString(rcb_acıklama.Text), Convert.ToDecimal(lbl_harcamalar.Text), Convert.ToString(lbl_birim.Text), Convert.ToString("P"));
                }
                if(ck_seri.Checked)
                {
                    db = new DBConnect();
                    db.UpdateProjeler(Convert.ToInt32(lbl_id.Text), Convert.ToString(txt_proje_no.Text), Convert.ToString(txt_proje_adı.Text), Convert.ToDecimal(txt_butce.Text), Convert.ToString(cmb_birim.Text), Convert.ToString(txt_musteri.Text), Convert.ToDateTime(dtp_baslangıc.Text), Convert.ToDateTime(bitis), Convert.ToInt32(txt_vade.Text), Convert.ToString(rcb_acıklama.Text), Convert.ToDecimal(lbl_harcamalar.Text), Convert.ToString(lbl_birim.Text), Convert.ToString("S"));
                }
                HarcamaOngorusu ho = (HarcamaOngorusu)Application.OpenForms["HarcamaOngorusu"];
                Projeler prjlr = (Projeler)Application.OpenForms["Projeler"];

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
                    for (int i = 0; i < ho.dgw_harcama.Rows.Count - 1; i++)
                    {
                        db.UpdateHarcamalar(Convert.ToInt16(prjlr.harcama_id[i]) ,myReader.GetInt32(0), Convert.ToString(ho.dgw_harcama.Rows[i].Cells[1].Value), Convert.ToDecimal(ho.dgw_harcama.Rows[i].Cells[2].Value), Convert.ToString(ho.dgw_harcama.Rows[i].Cells[3].Value), Convert.ToDateTime(ho.dgw_harcama.Rows[i].Cells[0].Value));
                    }
                    for (int i = 0; i < ho.dgw_odeme.Rows.Count - 1; i++)
                    {
                        db.UpdateOdemeler(Convert.ToInt16(prjlr.odeme_id[i]), myReader.GetInt32(0), Convert.ToString(ho.dgw_odeme.Rows[i].Cells[1].Value), Convert.ToDecimal(ho.dgw_odeme.Rows[i].Cells[2].Value), Convert.ToString(ho.dgw_odeme.Rows[i].Cells[3].Value), Convert.ToDateTime(ho.dgw_odeme.Rows[i].Cells[0].Value));
                    }
                }
                myReader.Close();
                myConnection.Close();
                this.Close();
                ho.Close();
            }
        }

        private void btn_harcamalar_Click(object sender, EventArgs e)
        {
           
        }
    }
}
