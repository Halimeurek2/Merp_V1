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
        int index = 0;
        string flag;
        public string[] harcama_id = new string[10];
        public string[] odeme_id = new string[10];
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

        DataTable dt = new DataTable();

        public Projeler()
        {
            InitializeComponent();
            hf = new HelperFunctions();
        }

        private void Projeler_Load(object sender, EventArgs e)
        {
            server = "localhost";
            database = "merp_dbv1";
            uid = "root";
            password = "root";
            //string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            myConnection = new MySqlConnection(connectionString);
            myConnection.Open();

            komut = "SELECT proje_id as ID, proje_no as ProjeNo," +
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
                    "proje_tipi as Tip FROM db_projeler";
            myCommand = new MySqlCommand(komut, myConnection);
            da = new MySqlDataAdapter(myCommand);
            dt = new DataTable();
            da.Fill(dt);
            dgw_prj_list.DataSource = dt;
            dgw_prj_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgw_prj_list.AutoSizeColumnsMode =
                       DataGridViewAutoSizeColumnsMode.Fill;


            dgw_prj_list.Columns[3].DefaultCellStyle.Format = "N2";
            dgw_prj_list.Columns[10].DefaultCellStyle.Format = "N2";

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


                komut = "SELECT proje_id,proje_no,proje_ismi,proje_butce,proje_birim,proje_musteri,proje_baslangic,proje_bitis,proje_vade,proje_aciklama,harcama_toplam,harcama_toplam_birim,proje_tipi FROM db_projeler";
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
            try
            {
                ProjeDuzenle obj = new ProjeDuzenle();
                id = dgw_prj_list.Rows[e.RowIndex].Cells[0].Value.ToString();
                proje_no = dgw_prj_list.Rows[e.RowIndex].Cells[1].Value.ToString();
                proje_adi = dgw_prj_list.Rows[e.RowIndex].Cells[2].Value.ToString();
                butce = dgw_prj_list.Rows[e.RowIndex].Cells[3].Value.ToString();
                birim = dgw_prj_list.Rows[e.RowIndex].Cells[4].Value.ToString();

                musteri = dgw_prj_list.Rows[e.RowIndex].Cells[5].Value.ToString();
                baslangic = Convert.ToDateTime(dgw_prj_list.Rows[e.RowIndex].Cells[6].Value.ToString());
                bitis = Convert.ToDateTime(dgw_prj_list.Rows[e.RowIndex].Cells[7].Value.ToString());
                vade = dgw_prj_list.Rows[e.RowIndex].Cells[8].Value.ToString();
                aciklama = dgw_prj_list.Rows[e.RowIndex].Cells[9].Value.ToString();
                harcamalar = dgw_prj_list.Rows[e.RowIndex].Cells[10].Value.ToString();
                harcama_birim = dgw_prj_list.Rows[e.RowIndex].Cells[11].Value.ToString();
                flag = dgw_prj_list.Rows[e.RowIndex].Cells[12].Value.ToString();

                myConnection.Close();
                myConnection.Open();
            }
            catch { }
        }

        private void txt_prjAdi_TextChanged(object sender, EventArgs e)
        {
            if (cmb_projeNo.Text == "")
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dgw_prj_list.DataSource;
                bs.Filter = dgw_prj_list.Columns[2].HeaderText.ToString() + " LIKE '%" + txt_prjAdi.Text + "%'";
                dgw_prj_list.DataSource = bs;

                dgw_prj_list.Refresh();
            }
            else
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dgw_prj_list.DataSource;
                bs.Filter = string.Format(dgw_prj_list.Columns[1].HeaderText.ToString() + " LIKE '%{0}%' AND " + dgw_prj_list.Columns[2].HeaderText.ToString() + " LIKE '%{1}%'",
                                                  cmb_projeNo.Text, txt_prjAdi.Text);
                dgw_prj_list.DataSource = bs;
            }

            SumDGW();
        }

        private void btn_prj_duzenle_Click(object sender, EventArgs e)
        {
            try
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

                komut = "SELECT * FROM db_projeharcama WHERE harcama_proje='" + id + "'";
                da = new MySqlDataAdapter(komut, connection);

                myCommand = new MySqlCommand(komut, myConnection);
                MySqlDataReader myReader;
                myReader = myCommand.ExecuteReader();
                
                while (myReader.Read())
                {
                    Array.Resize(ref harcama_id, index+1);
                    harcama_id[index] = myReader.GetString(0);
                    ho.dgw_harcama.Rows.Add();
                    ho.dgw_harcama.Rows[index].Cells[0].Value = Convert.ToDateTime(myReader.GetString(5));
                    ho.dgw_harcama.Rows[index].Cells[1].Value = myReader.GetString(2);
                    ho.dgw_harcama.Rows[index].Cells[2].Value = myReader.GetString(3);
                    ho.dgw_harcama.Rows[index].Cells[3].Value = myReader.GetString(4);
                    index++;
                }
                myReader.Close();

                index = 0;
                komut = "SELECT * FROM db_projeongoru WHERE ongoru_proje='" + id + "'";
                da = new MySqlDataAdapter(komut, connection);

                myCommand = new MySqlCommand(komut, myConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    Array.Resize(ref odeme_id, index + 1);
                    odeme_id[index] = myReader.GetString(0);
                    ho.dgw_odeme.Rows.Add();
                    ho.dgw_odeme.Rows[index].Cells[0].Value = Convert.ToDateTime(myReader.GetString(5));
                    ho.dgw_odeme.Rows[index].Cells[1].Value = myReader.GetString(2);
                    ho.dgw_odeme.Rows[index].Cells[2].Value = myReader.GetString(3);
                    ho.dgw_odeme.Rows[index].Cells[3].Value = myReader.GetString(4);
                    index++;
                }
                myReader.Close();

                ho.Show();
            }
            catch { }
        }

        public void SumDGW()
        {
            try
            {
                decimal a = 0;
                foreach (DataGridViewRow r in dgw_prj_list.Rows)
                {
                    {
                        a += Convert.ToDecimal(r.Cells[10].Value);
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
                komut = "SELECT proje_id as ID, proje_no as ProjeNo," +
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
                    "proje_tipi as Tip FROM db_projeler";
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
                    bs.Filter = dgw_prj_list.Columns[1].HeaderText.ToString() + " LIKE '%" + cmb_projeNo.Text + "%'";
                    dgw_prj_list.DataSource = bs;

                    dgw_prj_list.Refresh();
                }
                else
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dgw_prj_list.DataSource;
                    bs.Filter = string.Format(dgw_prj_list.Columns[1].HeaderText.ToString() + " LIKE '%{0}%' AND " + dgw_prj_list.Columns[2].HeaderText.ToString() + " LIKE '%{1}%'",
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

            komut = "SELECT proje_id as ID, proje_no as ProjeNo," +
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
                   "proje_tipi as Tip FROM db_projeler";
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

        private void dgw_prj_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ProjeDuzenle obj = new ProjeDuzenle();
                id = dgw_prj_list.Rows[e.RowIndex].Cells[0].Value.ToString();
                proje_no = dgw_prj_list.Rows[e.RowIndex].Cells[1].Value.ToString();
                proje_adi = dgw_prj_list.Rows[e.RowIndex].Cells[2].Value.ToString();
                butce = dgw_prj_list.Rows[e.RowIndex].Cells[3].Value.ToString();
                birim = dgw_prj_list.Rows[e.RowIndex].Cells[4].Value.ToString();

                musteri = dgw_prj_list.Rows[e.RowIndex].Cells[5].Value.ToString();
                baslangic = Convert.ToDateTime(dgw_prj_list.Rows[e.RowIndex].Cells[6].Value.ToString());
                bitis = Convert.ToDateTime(dgw_prj_list.Rows[e.RowIndex].Cells[7].Value.ToString());
                vade = dgw_prj_list.Rows[e.RowIndex].Cells[8].Value.ToString();
                aciklama = dgw_prj_list.Rows[e.RowIndex].Cells[9].Value.ToString();
                harcamalar = dgw_prj_list.Rows[e.RowIndex].Cells[10].Value.ToString();
                harcama_birim = dgw_prj_list.Rows[e.RowIndex].Cells[11].Value.ToString();
                flag = dgw_prj_list.Rows[e.RowIndex].Cells[12].Value.ToString();

                myConnection.Close();
                myConnection.Open();
            }
            catch { }
        }
    }
}
