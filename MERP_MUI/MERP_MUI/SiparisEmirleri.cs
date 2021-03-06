﻿using MySql.Data.MySqlClient;
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
    public partial class SiparisEmirleri : MetroFramework.Forms.MetroForm
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

        string proje_no;
        string tedarikci;
        string satinalma_no;
        string olusturan;
        DateTime siparis_tarihi;
        string vade;
        DateTime temin_tarihi;
        string fiyat_birim;
        string aciklama;
        string fiyat;
        string siparis_tipi;

        string id;

        public SiparisEmirleri()
        {
            InitializeComponent();
        }

        private void SiparisEmirleri_Load(object sender, EventArgs e)
        {
            server = "localhost";
            database = "merp_dbv1";
            uid = "root";
            password = "root";
            //string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            myConnection = new MySqlConnection(connectionString);
            myConnection.Open();

            komut = "SELECT * FROM db_siparis_emri";
            myCommand = new MySqlCommand(komut, myConnection);
            da = new MySqlDataAdapter(myCommand);
            dt = new DataTable();
            // myReader = myCommand.ExecuteReader();

            da.Fill(dt);

            dgw_stf_list.DataSource = dt;

            dgw_stf_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgw_stf_list.AutoSizeColumnsMode =
                       DataGridViewAutoSizeColumnsMode.Fill;

            dgw_stf_list.Columns[8].DefaultCellStyle.Format = "N2";
            dgw_stf_list.Columns[10].DefaultCellStyle.Format = "N2";
            dgw_stf_list.Columns[11].DefaultCellStyle.Format = "N2";
            dgw_stf_list.Columns[12].DefaultCellStyle.Format = "N2";

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

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ftr_sil_Click(object sender, EventArgs e)
        {
            DialogResult sil = new DialogResult();
            sil = MessageBox.Show("Emin misiniz?", "FATURA SİLME", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (sil == DialogResult.Yes)
            {
                komut = "DELETE FROM db_siparis_emri WHERE siparis_id='" + id + "'";
                myCommand = new MySqlCommand(komut, myConnection);
                da = new MySqlDataAdapter(myCommand);
                dt = new DataTable();
                // myReader = myCommand.ExecuteReader();

                da.Fill(dt);

                dgw_stf_list.DataSource = dt;

                dgw_stf_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgw_stf_list.AutoSizeColumnsMode =
                           DataGridViewAutoSizeColumnsMode.Fill;


                komut = "SELECT * FROM db_siparis_emri";
                myCommand = new MySqlCommand(komut, myConnection);
                da = new MySqlDataAdapter(myCommand);
                dt = new DataTable();
                // myReader = myCommand.ExecuteReader();

                da.Fill(dt);

                dgw_stf_list.DataSource = dt;

                dgw_stf_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgw_stf_list.AutoSizeColumnsMode =
                           DataGridViewAutoSizeColumnsMode.Fill;

                myConnection.Close();
            }
            else
            {

            }

            SumDGW();
        }

        private void txt_satınalma_no_TextChanged(object sender, EventArgs e)
        {
            RefreshFilter();
            SumDGW();
        }

        private void dgw_stf_list_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                id = dgw_stf_list.Rows[e.RowIndex].Cells[0].Value.ToString();
                proje_no = dgw_stf_list.Rows[e.RowIndex].Cells[1].Value.ToString();
                satinalma_no = dgw_stf_list.Rows[e.RowIndex].Cells[2].Value.ToString();
                tedarikci = dgw_stf_list.Rows[e.RowIndex].Cells[3].Value.ToString();
                olusturan = dgw_stf_list.Rows[e.RowIndex].Cells[4].Value.ToString();
                siparis_tarihi = Convert.ToDateTime(dgw_stf_list.Rows[e.RowIndex].Cells[5].Value);
                vade = dgw_stf_list.Rows[e.RowIndex].Cells[6].Value.ToString();
                temin_tarihi = Convert.ToDateTime(dgw_stf_list.Rows[e.RowIndex].Cells[7].Value);
                fiyat = dgw_stf_list.Rows[e.RowIndex].Cells[8].Value.ToString();
                fiyat_birim = dgw_stf_list.Rows[e.RowIndex].Cells[9].Value.ToString();
                aciklama = dgw_stf_list.Rows[e.RowIndex].Cells[13].Value.ToString();
                siparis_tipi= dgw_stf_list.Rows[e.RowIndex].Cells[14].Value.ToString();
            }
            catch { }
        }

        private void btn_ftr_duzenle_Click(object sender, EventArgs e)
        {
            try
            {
                SiparisEmriDuzenle obj = new SiparisEmriDuzenle();
                obj.lbl_id.Text = id;
                obj.cmb_prjno.Text = proje_no;
                obj.txt_siparisNo.Text = satinalma_no;
                obj.cmb_tedarikci.Text = tedarikci;
                obj.txt_talepKisi.Text = olusturan;
                obj.date_teslim.Value = siparis_tarihi;
                obj.txt_vade.Text = vade;
                obj.date_temin.Value = temin_tarihi;
                obj.txt_mlz_brmFiyat.Text = fiyat;
                obj.cmb_paraBirimi.Text = fiyat_birim;
                obj.rcb_aciklama.Text = aciklama;
                if(siparis_tipi=="Gelen")
                {
                    obj.rb_gelen.Checked = true;
                }
                else if(siparis_tipi=="Verilen")
                {
                    obj.rb_verilen.Checked = true;
                }
                obj.Show();
            }
            catch { }
        }

        public void RefreshFilter()
        {
            komut = "SELECT * FROM db_siparis_emri where proje_no like '%" + cmb_projeNo.Text + "%' and satinalma_no like '%" + txt_satınalma_no.Text + "%' and tedarikci like '%" + txt_tedarikci.Text + "%'";
            myCommand = new MySqlCommand(komut, myConnection);
            da = new MySqlDataAdapter(myCommand);
            dt = new DataTable();
            // myReader = myCommand.ExecuteReader();

            da.Fill(dt);

            dgw_stf_list.DataSource = dt;

            dgw_stf_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgw_stf_list.AutoSizeColumnsMode =
                       DataGridViewAutoSizeColumnsMode.Fill;

            myConnection.Close();
        }

        private void cmb_projeNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_projeNo.Text == "Hepsi")
            {
                komut = "SELECT * FROM db_siparis_emri";
                myCommand = new MySqlCommand(komut, myConnection);
                da = new MySqlDataAdapter(myCommand);
                dt = new DataTable();
                // myReader = myCommand.ExecuteReader();

                da.Fill(dt);

                dgw_stf_list.DataSource = dt;

                dgw_stf_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgw_stf_list.AutoSizeColumnsMode =
                           DataGridViewAutoSizeColumnsMode.Fill;

                myConnection.Close();
            }
            else
            {
                RefreshFilter();
            }

            SumDGW();
        }

        private void txt_tedarikci_TextChanged(object sender, EventArgs e)
        {
            RefreshFilter();
            SumDGW();
        }

        public void SumDGW()
        {
            try
            {
                decimal a = 0;
                foreach (DataGridViewRow r in dgw_stf_list.Rows)
                {
                    {
                        a += Convert.ToDecimal(r.Cells[10].Value);
                    }
                    lbl_toplam.Text = Convert.ToString(a);
                    lbl_toplam.Text = string.Format(new CultureInfo("de-DE"), "{0:C2}", Convert.ToDecimal(a));
                }
            }
            catch
            {

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmb_projeNo.Text = "";
            txt_satınalma_no.Text = "";
            txt_tedarikci.Text = "";

            komut = "SELECT * FROM db_siparis_emri";
            myCommand = new MySqlCommand(komut, myConnection);
            da = new MySqlDataAdapter(myCommand);
            dt = new DataTable();
            // myReader = myCommand.ExecuteReader();

            da.Fill(dt);

            dgw_stf_list.DataSource = dt;

            dgw_stf_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgw_stf_list.AutoSizeColumnsMode =
                       DataGridViewAutoSizeColumnsMode.Fill;

            myConnection.Close();

            SumDGW();
        }

        private void pb_refresh_Click(object sender, EventArgs e)
        {
            cmb_projeNo.Text = "";
            txt_satınalma_no.Text = "";
            txt_tedarikci.Text = "";

            komut = "SELECT * FROM db_siparis_emri";
            myCommand = new MySqlCommand(komut, myConnection);
            da = new MySqlDataAdapter(myCommand);
            dt = new DataTable();
            // myReader = myCommand.ExecuteReader();

            da.Fill(dt);

            dgw_stf_list.DataSource = dt;

            dgw_stf_list.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgw_stf_list.AutoSizeColumnsMode =
                       DataGridViewAutoSizeColumnsMode.Fill;

            myConnection.Close();

            SumDGW();
        }

        private void dgw_stf_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = dgw_stf_list.Rows[e.RowIndex].Cells[0].Value.ToString();
                proje_no = dgw_stf_list.Rows[e.RowIndex].Cells[1].Value.ToString();
                satinalma_no = dgw_stf_list.Rows[e.RowIndex].Cells[2].Value.ToString();
                tedarikci = dgw_stf_list.Rows[e.RowIndex].Cells[3].Value.ToString();
                olusturan = dgw_stf_list.Rows[e.RowIndex].Cells[4].Value.ToString();
                siparis_tarihi = Convert.ToDateTime(dgw_stf_list.Rows[e.RowIndex].Cells[5].Value);
                vade = dgw_stf_list.Rows[e.RowIndex].Cells[6].Value.ToString();
                temin_tarihi = Convert.ToDateTime(dgw_stf_list.Rows[e.RowIndex].Cells[7].Value);
                fiyat = dgw_stf_list.Rows[e.RowIndex].Cells[8].Value.ToString();
                fiyat_birim = dgw_stf_list.Rows[e.RowIndex].Cells[9].Value.ToString();
                aciklama = dgw_stf_list.Rows[e.RowIndex].Cells[13].Value.ToString();
                siparis_tipi = dgw_stf_list.Rows[e.RowIndex].Cells[14].Value.ToString();
            }
            catch { }
        }
    }
}
