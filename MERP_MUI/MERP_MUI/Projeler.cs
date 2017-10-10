using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace MERP_MUI
{
    public partial class Projeler : MetroFramework.Forms.MetroForm
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

        string id;
        string proje_adi;
        string proje_no;
        string butce;
        string birim;
        string harcamalar;
        string harcama_birim;
        string musteri;
        string vade;
        string aciklama;
        DateTime baslangic;
        DateTime bitis;

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

        DataTable dt = new DataTable();

        public Projeler()
        {
            InitializeComponent();
            hf = new HelperFunctions();
        }

        private void Projeler_Load(object sender, EventArgs e)
        {
            server = "localhost";
            database = "uretimplanlama_2";
            uid = "root";
            password = "root";
            //string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            myConnection = new MySqlConnection(connectionString);
            myConnection.Open();

            komut = "SELECT proje_no as ProjeNo," +
                    "proje_ismi as Projeİsmi," +
                    "proje_butce as Bütçe," +
                    "proje_birim as Birim," +
                    "proje_musteri as Müşteri," +
                    "proje_baslangic as Başlangıç," +
                    "proje_bitis as Bitiş," +
                    "proje_vade as Vade," +
                    "proje_aciklama as Açıklama," +
                    "harcama_toplam as Harcama," +
                    "harcama_toplam_birim as HarcamaBirim," +
                    "prj_tip as Tip FROM db_projeler";
            myCommand = new MySqlCommand(komut, myConnection);
            da = new MySqlDataAdapter(myCommand);
            dt = new DataTable();
            da.Fill(dt);
            dgw_prj_list.DataSource = dt;
            dgw_prj_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgw_prj_list.AutoSizeColumnsMode =
                       DataGridViewAutoSizeColumnsMode.Fill;


            dgw_prj_list.Columns[2].DefaultCellStyle.Format = "N2";
            dgw_prj_list.Columns[9].DefaultCellStyle.Format = "N2";

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
                cmb_projeNo.Items.Add(myReader["proje_no"]);
            }

            myConnection.Close();

            SumDGW();
        }

        private void btn_prj_sil_Click(object sender, EventArgs e)
        {
            DialogResult sil = new DialogResult();
            sil = MessageBox.Show("Emin misiniz?", "FATURA SİLME", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (sil == DialogResult.Yes)
            {
                komut = "DELETE FROM db_projeler WHERE proje_id='" + id + "'";
                myCommand = new MySqlCommand(komut, myConnection);
                da = new MySqlDataAdapter(myCommand);
                dt = new DataTable();
                // myReader = myCommand.ExecuteReader();

                da.Fill(dt);

                dgw_prj_list.DataSource = dt;

                dgw_prj_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgw_prj_list.AutoSizeColumnsMode =
                           DataGridViewAutoSizeColumnsMode.Fill;


                komut = "SELECT proje_no,proje_ismi,proje_butce,proje_birim,proje_musteri,proje_baslangic,proje_bitis,proje_vade,proje_aciklama,harcama_toplam,harcama_toplam_birim,prj_tip FROM db_projeler";
                myCommand = new MySqlCommand(komut, myConnection);
                da = new MySqlDataAdapter(myCommand);
                dt = new DataTable();
                // myReader = myCommand.ExecuteReader();

                da.Fill(dt);

                dgw_prj_list.DataSource = dt;

                dgw_prj_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgw_prj_list.AutoSizeColumnsMode =
                           DataGridViewAutoSizeColumnsMode.Fill;

                myConnection.Close();
            }
            else
            {

            }

            SumDGW();
        }

        private void dgw_prj_list_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ProjeDuzenle obj = new ProjeDuzenle();
            proje_no = dgw_prj_list.Rows[e.RowIndex].Cells[0].Value.ToString();
            proje_adi = dgw_prj_list.Rows[e.RowIndex].Cells[1].Value.ToString();
            butce = dgw_prj_list.Rows[e.RowIndex].Cells[2].Value.ToString();
            birim = dgw_prj_list.Rows[e.RowIndex].Cells[3].Value.ToString();

            musteri = dgw_prj_list.Rows[e.RowIndex].Cells[4].Value.ToString();
            baslangic = Convert.ToDateTime(dgw_prj_list.Rows[e.RowIndex].Cells[5].Value.ToString());
            bitis = Convert.ToDateTime(dgw_prj_list.Rows[e.RowIndex].Cells[6].Value.ToString());
            vade = dgw_prj_list.Rows[e.RowIndex].Cells[7].Value.ToString();
            aciklama = dgw_prj_list.Rows[e.RowIndex].Cells[8].Value.ToString();
            harcamalar = dgw_prj_list.Rows[e.RowIndex].Cells[9].Value.ToString();
            harcama_birim = dgw_prj_list.Rows[e.RowIndex].Cells[10].Value.ToString();
            flag = dgw_prj_list.Rows[e.RowIndex].Cells[11].Value.ToString();

            myConnection.Close();
            myConnection.Open();
            komut = "SELECT * FROM db_projeler WHERE proje_no='" + proje_no + "' AND proje_ismi='" + proje_adi + "'";
            da = new MySqlDataAdapter(komut, connection);

            //  myConnection = new MySqlConnection(connectionString);
            myCommand = new MySqlCommand(komut, myConnection);
            //   myConnection.Open();
            MySqlDataReader myReader;
            myReader = myCommand.ExecuteReader();
            // Always call Read before accessing data.
            while (myReader.Read())
            {
                id = myReader.GetString(0);
                harcama_m_mlz = myReader.GetString(10);
                harcama_el_mlz = myReader.GetString(11);
                harcama_imalat = myReader.GetString(12);
                harcama_test = myReader.GetString(13);
                harcama_risk = myReader.GetString(14);
                odeme_avans = myReader.GetString(17);
                dtp_avans = Convert.ToDateTime(myReader.GetString(18));
                odeme_pdr = myReader.GetString(19);
                dtp_pdr = Convert.ToDateTime(myReader.GetString(20));
                odeme_cdr = myReader.GetString(21);
                dtp_cdr = Convert.ToDateTime(myReader.GetString(22));
                odeme_prototip = myReader.GetString(23);
                dtp_prototip = Convert.ToDateTime(myReader.GetString(24));
                odeme_test = myReader.GetString(25);
                dtp_test = Convert.ToDateTime(myReader.GetString(26));
                odeme_kabul = myReader.GetString(27);
                dtp_kabul = Convert.ToDateTime(myReader.GetString(28));
                s6 = myReader.GetString(29);
                dtp_s6 = Convert.ToDateTime(myReader.GetString(30));
            }
            myReader.Close();
        }

        private void txt_prjAdi_TextChanged(object sender, EventArgs e)
        {
            if (cmb_projeNo.Text == "")
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dgw_prj_list.DataSource;
                bs.Filter = dgw_prj_list.Columns[1].HeaderText.ToString() + " LIKE '%" + txt_prjAdi.Text + "%'";
                dgw_prj_list.DataSource = bs;

                dgw_prj_list.Refresh();
            }
            else
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dgw_prj_list.DataSource;
                bs.Filter = string.Format(dgw_prj_list.Columns[0].HeaderText.ToString() + " LIKE '%{0}%' AND " + dgw_prj_list.Columns[1].HeaderText.ToString() + " LIKE '%{1}%'",
                                                  cmb_projeNo.Text, txt_prjAdi.Text);
                dgw_prj_list.DataSource = bs;
            }

            SumDGW();
        }

        private void btn_prj_duzenle_Click(object sender, EventArgs e)
        {
            ProjeDuzenle obj = new ProjeDuzenle();
            obj.lbl_id.Text = id;
            obj.cmb_birim.Text = birim;
            obj.txt_butce.Text = butce;
            obj.txt_musteri.Text = musteri;
            obj.txt_proje_adı.Text = proje_adi;
            obj.txt_proje_no.Text = proje_no;
            obj.dtp_baslangıc.Value = baslangic;
            obj.dtp_bitis.Value = bitis;
            obj.txt_vade.Text = vade;
            obj.rcb_acıklama.Text = aciklama;
            obj.lbl_harcamalar.Text = harcamalar;
            obj.lbl_birim.Text = harcama_birim;
            if (flag == "S") { obj.ck_seri.Checked = true; }
            else { obj.ck_prj.Checked = true; }
            obj.Show();


            HarcamaOngorusu ho = new HarcamaOngorusu();

            if (flag == "S")
            {
                ho.lbl_pdr.Text = "S1";
                ho.lbl_cdr.Text = "S2";
                ho.lbl_prototip.Text = "S3";
                ho.lbl_kabul.Text = "S5";
                ho.lbl_test.Text = "S4";
                ho.lbl_s6.Enabled = true;
                ho.txt_s6.Enabled = true;
                ho.dtp_s6.Enabled = true;
            }
            else
            {
                ho.lbl_pdr.Text = "PDR";
                ho.lbl_cdr.Text = "CDR";
                ho.lbl_prototip.Text = "Prototip";
                ho.lbl_kabul.Text = "Kabul";
                ho.lbl_test.Text = "Test";
                ho.lbl_s6.Enabled = false;
                ho.txt_s6.Enabled = false;
                ho.dtp_s6.Enabled = false;
            }
            ho.txt_m_mlz.Text = harcama_m_mlz;
            ho.txt_el_mlz.Text = harcama_el_mlz;
            ho.txt_imalat.Text = harcama_imalat;
            ho.txt_test.Text = harcama_test;
            ho.txt_risk.Text = harcama_risk;
            ho.txt_avans.Text = odeme_avans;
            ho.txt_pdr.Text = odeme_pdr;
            ho.txt_cdr.Text = odeme_cdr;
            ho.txt_prototip.Text = odeme_prototip;
            ho.txt_o_test.Text = odeme_test;
            ho.txt_kabul.Text = odeme_kabul;
            ho.txt_s6.Text = s6;
            ho.dtp_avans.Value = dtp_avans;
            ho.dtp_pdr.Value = dtp_pdr;
            ho.dtp_cdr.Value = dtp_cdr;
            ho.dtp_prototip.Value = dtp_prototip;
            ho.dtp_test.Value = dtp_test;
            ho.dtp_kabul.Value = dtp_kabul;
            ho.dtp_s6.Value = dtp_s6;

            ho.Show();
        }

        public void SumDGW()
        {
            try
            {
                decimal a = 0;
                foreach (DataGridViewRow r in dgw_prj_list.Rows)
                {
                    {
                        a += Convert.ToDecimal(r.Cells[9].Value);
                    }
                    lbl_toplam.Text = Convert.ToString(a);
                    lbl_toplam.Text = string.Format(new CultureInfo("de-DE"), "{0:C2}", Convert.ToDecimal(lbl_toplam.Text));
                }
            }
            catch
            {

            }
        }

        private void cmb_projeNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_projeNo.Text == "Hepsi")
            {
                komut = "SELECT proje_no,proje_ismi,proje_butce,proje_birim,proje_musteri,proje_baslangic,proje_bitis,proje_vade,proje_aciklama,harcama_toplam,harcama_toplam_birim,prj_tip FROM db_projeler";
                myCommand = new MySqlCommand(komut, myConnection);
                da = new MySqlDataAdapter(myCommand);
                dt = new DataTable();
                // myReader = myCommand.ExecuteReader();

                da.Fill(dt);

                dgw_prj_list.DataSource = dt;

                dgw_prj_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgw_prj_list.AutoSizeColumnsMode =
                           DataGridViewAutoSizeColumnsMode.Fill;

                myConnection.Close();
            }
            else
            {
                if (txt_prjAdi.Text == "")
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dgw_prj_list.DataSource;
                    bs.Filter = dgw_prj_list.Columns[0].HeaderText.ToString() + " LIKE '%" + cmb_projeNo.Text + "%'";
                    dgw_prj_list.DataSource = bs;

                    dgw_prj_list.Refresh();
                }
                else
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dgw_prj_list.DataSource;
                    bs.Filter = string.Format(dgw_prj_list.Columns[0].HeaderText.ToString() + " LIKE '%{0}%' AND " + dgw_prj_list.Columns[1].HeaderText.ToString() + " LIKE '%{1}%'",
                                                      cmb_projeNo.Text, txt_prjAdi.Text);
                    dgw_prj_list.DataSource = bs;
                }
            }
            SumDGW();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmb_projeNo.Text = "";
            txt_prjAdi.Text = "";

            komut = "SELECT proje_no,proje_ismi,proje_butce,proje_birim,proje_musteri,proje_baslangic,proje_bitis,proje_vade,proje_aciklama,harcama_toplam,harcama_toplam_birim,prj_tip FROM db_projeler";
            myCommand = new MySqlCommand(komut, myConnection);
            da = new MySqlDataAdapter(myCommand);
            dt = new DataTable();
            // myReader = myCommand.ExecuteReader();

            da.Fill(dt);

            dgw_prj_list.DataSource = dt;

            dgw_prj_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgw_prj_list.AutoSizeColumnsMode =
                       DataGridViewAutoSizeColumnsMode.Fill;

            myConnection.Close();

            SumDGW();
        }
    }
}
