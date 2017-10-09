using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MERP_MUI
{
    public partial class Faturalar : MetroFramework.Forms.MetroForm
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

        string id;
        string firma;
        string proje_no;
        string fatura_no;
        string birim;
        string tutar;
        int check;
        string avans;
        string vade;
        DateTime vade_tarih;
        string fatura_tarih;
        string acıklama;
        string tip;
        string cins;
        string durum;

        DataTable datatable = new DataTable();

        public Faturalar()
        {
            InitializeComponent();
        }

        private void Faturalar_Load(object sender, EventArgs e)
        {
            server = "localhost";
            database = "uretimplanlama_2";
            uid = "root";
            password = "root";
            //string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            myConnection = new MySqlConnection(connectionString);
            myConnection.Open();


            komut = "SELECT * FROM db_faturalar";
            myCommand = new MySqlCommand(komut, myConnection);
            da = new MySqlDataAdapter(myCommand);
            dt = new DataTable();
            // myReader = myCommand.ExecuteReader();

            da.Fill(dt);
            dgw_ftr_list.DataSource = dt;

            dgw_ftr_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgw_ftr_list.AutoSizeColumnsMode =
                       DataGridViewAutoSizeColumnsMode.Fill;

            dgw_ftr_list.Columns[12].DefaultCellStyle.Format = "N2";
            dgw_ftr_list.Columns[9].DefaultCellStyle.Format = "N2";

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
            myConnection.Close();

            SumDGW();
        }

        private void btn_ftr_duzenle_Click(object sender, EventArgs e)
        {
            FaturaDuzenle obj = new FaturaDuzenle();
            obj.lbl_id.Text = id;
            obj.txt_fatura_no.Text = fatura_no;
            obj.cmb_projeNo.Text = proje_no;
            obj.cmb_firma.Text = firma;
            obj.txt_ftr_vade.Text = vade;
            obj.rcb_acıklama.Text = acıklama;
            obj.date_alarm.Value = vade_tarih;
            obj.txt_ftr_tarih.Text = fatura_tarih;
            obj.ck_alarm.Checked = Convert.ToBoolean(check);
            obj.txt_ftr_tutar.Text = tutar;
            obj.cmb_birim.Text = birim;
            obj.txt_avans.Text = avans;
            obj.lbl_tip.Text = tip;
            obj.cmb_ftr_tip.Text = cins;
            if (durum == "ÖDENDİ")
            {
                obj.cb_durum.Checked = true;
            }
            else
            {
                obj.cb_durum.Checked = false;
            }
            obj.Show();
        }

        private void btn_ftr_sil_Click(object sender, EventArgs e)
        {
            DialogResult sil = new DialogResult();
            sil = MessageBox.Show("Emin misiniz?", "FATURA SİLME", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (sil == DialogResult.Yes)
            {
                komut = "DELETE FROM db_faturalar WHERE fatura_id='" + id + "'";
                myCommand = new MySqlCommand(komut, myConnection);
                da = new MySqlDataAdapter(myCommand);
                dt = new DataTable();
                // myReader = myCommand.ExecuteReader();

                da.Fill(dt);

                dgw_ftr_list.DataSource = dt;

                dgw_ftr_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgw_ftr_list.AutoSizeColumnsMode =
                           DataGridViewAutoSizeColumnsMode.Fill;


                komut = "SELECT * FROM db_faturalar";
                myCommand = new MySqlCommand(komut, myConnection);
                da = new MySqlDataAdapter(myCommand);
                dt = new DataTable();
                // myReader = myCommand.ExecuteReader();

                da.Fill(dt);

                dgw_ftr_list.DataSource = dt;

                dgw_ftr_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgw_ftr_list.AutoSizeColumnsMode =
                           DataGridViewAutoSizeColumnsMode.Fill;

                myConnection.Close();
            }
            else
            {

            }

            SumDGW();
        }

        private void dgw_ftr_list_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FaturaDuzenle obj = new FaturaDuzenle();

            id = dgw_ftr_list.Rows[e.RowIndex].Cells[0].Value.ToString();
            fatura_no = dgw_ftr_list.Rows[e.RowIndex].Cells[1].Value.ToString();
            proje_no = dgw_ftr_list.Rows[e.RowIndex].Cells[2].Value.ToString();
            firma = dgw_ftr_list.Rows[e.RowIndex].Cells[3].Value.ToString();
            vade = dgw_ftr_list.Rows[e.RowIndex].Cells[4].Value.ToString();
            acıklama = dgw_ftr_list.Rows[e.RowIndex].Cells[6].Value.ToString();
            vade_tarih = Convert.ToDateTime(dgw_ftr_list.Rows[e.RowIndex].Cells[5].Value.ToString());
            fatura_tarih = dgw_ftr_list.Rows[e.RowIndex].Cells[7].Value.ToString();
            check = Convert.ToInt32(dgw_ftr_list.Rows[e.RowIndex].Cells[8].Value);
            tutar = dgw_ftr_list.Rows[e.RowIndex].Cells[9].Value.ToString();
            birim = dgw_ftr_list.Rows[e.RowIndex].Cells[10].Value.ToString();
            avans = dgw_ftr_list.Rows[e.RowIndex].Cells[11].Value.ToString();
            tip = dgw_ftr_list.Rows[e.RowIndex].Cells[13].Value.ToString();
            cins = dgw_ftr_list.Rows[e.RowIndex].Cells[14].Value.ToString();
            durum = dgw_ftr_list.Rows[e.RowIndex].Cells[15].Value.ToString();
        }

        private void txt_ftr_no_TextChanged(object sender, EventArgs e)
        {
            Refresh();
            SumDGW();
        }

        private void txt_tip_TextChanged(object sender, EventArgs e)
        {
            Refresh();
            SumDGW();
        }

        public void Refresh()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dgw_ftr_list.DataSource;

            bs.Filter = string.Format(dgw_ftr_list.Columns[1].HeaderText.ToString() + " LIKE '%{0}%' AND " + dgw_ftr_list.Columns[3].HeaderText.ToString() + " LIKE '%{1}%' AND " +
                                      dgw_ftr_list.Columns[13].HeaderText.ToString() + " LIKE '%{2}%' AND " + dgw_ftr_list.Columns[2].HeaderText.ToString() + " LIKE '%{3}%'",
                                                  txt_ftr_no.Text, cmb_firma.Text, txt_tip.Text, cmb_projeNo.Text);
            dgw_ftr_list.DataSource = bs;
            dgw_ftr_list.Refresh();
        }

        public void SumDGW()
        {
            try
            {
                decimal a = 0;
                foreach (DataGridViewRow r in dgw_ftr_list.Rows)
                {
                    {
                        a += Convert.ToDecimal(r.Cells[12].Value);
                    }
                    label1.Text = Convert.ToString(a);
                    label1.Text = string.Format(new CultureInfo("de-DE"), "{0:C2}", Convert.ToDecimal(label1.Text));
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
                komut = "SELECT * FROM db_faturalar";
                myCommand = new MySqlCommand(komut, myConnection);
                da = new MySqlDataAdapter(myCommand);
                dt = new DataTable();
                // myReader = myCommand.ExecuteReader();

                da.Fill(dt);

                dgw_ftr_list.DataSource = dt;

                dgw_ftr_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgw_ftr_list.AutoSizeColumnsMode =
                           DataGridViewAutoSizeColumnsMode.Fill;

                myConnection.Close();

                cmb_firma.Text = "";
                txt_ftr_no.Text = "";
                txt_tip.Text = "";
            }
            else
            {
                Refresh();
            }

            SumDGW();
        }

        private void cmb_firma_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refresh();
            SumDGW();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmb_firma.Text = "";
            cmb_projeNo.Text = "";
            txt_ftr_no.Text = "";
            txt_tip.Text = "";
        }
    }
}
