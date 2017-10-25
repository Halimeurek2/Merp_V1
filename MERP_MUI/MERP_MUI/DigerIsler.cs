using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace MERP_MUI
{
    public partial class DigerIsler : MetroFramework.Forms.MetroForm
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
        public int akt_id;

        public DigerIsler()
        {
            InitializeComponent();
        }

        private void DigerIsler_Load(object sender, EventArgs e)
        {
            server = "localhost";
            database = "merp_dbv1";
            uid = "root";
            password = "root";
            //string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            myConnection = new MySqlConnection(connectionString);
            myConnection.Open();

            komut = "SELECT * FROM db_aktivite WHERE akt_statu='" + Convert.ToString("AKTİF") + "'";
            myCommand = new MySqlCommand(komut, myConnection);
            da = new MySqlDataAdapter(myCommand);
            dt = new DataTable();
            // myReader = myCommand.ExecuteReader();

            da.Fill(dt);

            dg_aktif.DataSource = dt;

            dg_aktif.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dg_aktif.AutoSizeColumnsMode =
                       DataGridViewAutoSizeColumnsMode.Fill;

            komut = "SELECT * FROM db_aktivite WHERE akt_statu='" + Convert.ToString("PASİF") + "'";
            myCommand = new MySqlCommand(komut, myConnection);
            da = new MySqlDataAdapter(myCommand);
            dt = new DataTable();
            // myReader = myCommand.ExecuteReader();

            da.Fill(dt);

            dg_pasif.DataSource = dt;

            dg_pasif.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dg_pasif.AutoSizeColumnsMode =
                       DataGridViewAutoSizeColumnsMode.Fill;


            komut = "SELECT * FROM db_aktivite WHERE akt_statu='" + Convert.ToString("BEKLEMEDE") + "'";
            myCommand = new MySqlCommand(komut, myConnection);
            da = new MySqlDataAdapter(myCommand);
            dt = new DataTable();
            // myReader = myCommand.ExecuteReader();

            da.Fill(dt);

            dg_bekleme.DataSource = dt;

            dg_bekleme.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dg_bekleme.AutoSizeColumnsMode =
                       DataGridViewAutoSizeColumnsMode.Fill;

            komut = "SELECT * FROM db_aktivite WHERE akt_statu='" + Convert.ToString("BİTTİ") + "'";
            myCommand = new MySqlCommand(komut, myConnection);
            da = new MySqlDataAdapter(myCommand);
            dt = new DataTable();
            // myReader = myCommand.ExecuteReader();

            da.Fill(dt);

            dg_biten.DataSource = dt;

            dg_biten.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dg_biten.AutoSizeColumnsMode =
                       DataGridViewAutoSizeColumnsMode.Fill;

            myConnection.Close();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dg_pasif_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                AktiviteDuzenle ag = new AktiviteDuzenle();
                ag.Show();

                akt_id = Convert.ToInt32(dg_pasif.Rows[e.RowIndex].Cells[0].Value.ToString());
                AktiviteDuzenle f1 = (AktiviteDuzenle)Application.OpenForms["AktiviteDuzenle"];
                ComboBox no = (ComboBox)f1.Controls["cmb_prj_no"];
                ComboBox oncelik = (ComboBox)f1.Controls["cmb_oncelik"];
                ComboBox statu = (ComboBox)f1.Controls["cmb_statu"];
                RichTextBox acıklama = (RichTextBox)f1.Controls["rcb_acıklama"];
                ComboBox rapor = (ComboBox)f1.Controls["cmb_rapor_edilecek"];
                DateTimePicker olusturma = (DateTimePicker)f1.Controls["date_olusturma"];
                DateTimePicker bitis = (DateTimePicker)f1.Controls["date_bitis"];
                Label id = (Label)f1.Controls["lbl_id"];
                id.Text = dg_pasif.Rows[e.RowIndex].Cells[0].Value.ToString();
                no.Text = dg_pasif.Rows[e.RowIndex].Cells[1].Value.ToString();
                oncelik.Text = dg_pasif.Rows[e.RowIndex].Cells[2].Value.ToString();
                statu.Text = dg_pasif.Rows[e.RowIndex].Cells[3].Value.ToString();
                acıklama.Text = dg_pasif.Rows[e.RowIndex].Cells[4].Value.ToString();
                rapor.Text = dg_pasif.Rows[e.RowIndex].Cells[5].Value.ToString();
                olusturma.Text = dg_pasif.Rows[e.RowIndex].Cells[6].Value.ToString();
                bitis.Text = dg_pasif.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            catch { }
        }

        private void dg_bekleme_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                AktiviteDuzenle ag = new AktiviteDuzenle();
                ag.Show();

                akt_id = Convert.ToInt32(dg_bekleme.Rows[e.RowIndex].Cells[0].Value.ToString());
                AktiviteDuzenle f1 = (AktiviteDuzenle)Application.OpenForms["AktiviteDuzenle"];
                ComboBox no = (ComboBox)f1.Controls["cmb_prj_no"];
                ComboBox oncelik = (ComboBox)f1.Controls["cmb_oncelik"];
                ComboBox statu = (ComboBox)f1.Controls["cmb_statu"];
                RichTextBox acıklama = (RichTextBox)f1.Controls["rcb_acıklama"];
                ComboBox rapor = (ComboBox)f1.Controls["cmb_rapor_edilecek"];
                DateTimePicker olusturma = (DateTimePicker)f1.Controls["date_olusturma"];
                DateTimePicker bitis = (DateTimePicker)f1.Controls["date_bitis"];
                Label id = (Label)f1.Controls["lbl_id"];
                id.Text = dg_bekleme.Rows[e.RowIndex].Cells[0].Value.ToString();
                no.Text = dg_bekleme.Rows[e.RowIndex].Cells[1].Value.ToString();
                oncelik.Text = dg_bekleme.Rows[e.RowIndex].Cells[2].Value.ToString();
                statu.Text = dg_bekleme.Rows[e.RowIndex].Cells[3].Value.ToString();
                acıklama.Text = dg_bekleme.Rows[e.RowIndex].Cells[4].Value.ToString();
                rapor.Text = dg_bekleme.Rows[e.RowIndex].Cells[5].Value.ToString();
                olusturma.Text = dg_bekleme.Rows[e.RowIndex].Cells[6].Value.ToString();
                bitis.Text = dg_bekleme.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            catch { }
        }

        private void btn_prj_sil_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow a in dg_aktif.Rows)
            {
                if (a.Selected == true)
                {
                    DialogResult sil = new DialogResult();
                    sil = MessageBox.Show("Emin misiniz?", "FATURA SİLME", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (sil == DialogResult.Yes)
                    {
                        komut = "DELETE FROM db_aktivite WHERE akt_id='" + akt_id + "'";
                        myCommand = new MySqlCommand(komut, myConnection);
                        da = new MySqlDataAdapter(myCommand);
                        dt = new DataTable();
                        // myReader = myCommand.ExecuteReader();

                        da.Fill(dt);

                        dg_aktif.DataSource = dt;

                        dg_aktif.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        dg_aktif.AutoSizeColumnsMode =
                                   DataGridViewAutoSizeColumnsMode.Fill;

                        komut = "SELECT * FROM db_aktivite WHERE akt_statu='" + Convert.ToString("AKTİF") + "'";
                        myCommand = new MySqlCommand(komut, myConnection);
                        da = new MySqlDataAdapter(myCommand);
                        dt = new DataTable();
                        // myReader = myCommand.ExecuteReader();

                        da.Fill(dt);

                        dg_aktif.DataSource = dt;

                        dg_aktif.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        dg_aktif.AutoSizeColumnsMode =
                                   DataGridViewAutoSizeColumnsMode.Fill;

                        myConnection.Close();
                    }
                }

            }

            foreach (DataGridViewRow p in dg_pasif.Rows)
            {
                if (p.Selected == true)
                {
                    DialogResult sil = new DialogResult();
                    sil = MessageBox.Show("Emin misiniz?", "FATURA SİLME", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (sil == DialogResult.Yes)
                    {
                        komut = "DELETE FROM db_aktivite WHERE akt_id='" + akt_id + "'";
                        myCommand = new MySqlCommand(komut, myConnection);
                        da = new MySqlDataAdapter(myCommand);
                        dt = new DataTable();
                        // myReader = myCommand.ExecuteReader();

                        da.Fill(dt);

                        dg_pasif.DataSource = dt;

                        dg_pasif.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        dg_pasif.AutoSizeColumnsMode =
                                   DataGridViewAutoSizeColumnsMode.Fill;

                        komut = "SELECT * FROM db_aktivite WHERE akt_statu='" + Convert.ToString("PASİF") + "'";
                        myCommand = new MySqlCommand(komut, myConnection);
                        da = new MySqlDataAdapter(myCommand);
                        dt = new DataTable();
                        // myReader = myCommand.ExecuteReader();

                        da.Fill(dt);

                        dg_pasif.DataSource = dt;

                        dg_pasif.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        dg_pasif.AutoSizeColumnsMode =
                                   DataGridViewAutoSizeColumnsMode.Fill;

                        myConnection.Close();
                    }
                }

            }
            foreach (DataGridViewRow b in dg_bekleme.Rows)
            {
                if (b.Selected == true)
                {
                    DialogResult sil = new DialogResult();
                    sil = MessageBox.Show("Emin misiniz?", "FATURA SİLME", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (sil == DialogResult.Yes)
                    {
                        komut = "DELETE FROM db_aktivite WHERE akt_id='" + akt_id + "'";
                        myCommand = new MySqlCommand(komut, myConnection);
                        da = new MySqlDataAdapter(myCommand);
                        dt = new DataTable();
                        // myReader = myCommand.ExecuteReader();

                        da.Fill(dt);

                        dg_bekleme.DataSource = dt;

                        dg_bekleme.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        dg_bekleme.AutoSizeColumnsMode =
                                   DataGridViewAutoSizeColumnsMode.Fill;

                        komut = "SELECT * FROM db_aktivite WHERE akt_statu='" + Convert.ToString("BEKLEMEDE") + "'";
                        myCommand = new MySqlCommand(komut, myConnection);
                        da = new MySqlDataAdapter(myCommand);
                        dt = new DataTable();
                        // myReader = myCommand.ExecuteReader();

                        da.Fill(dt);

                        dg_bekleme.DataSource = dt;

                        dg_bekleme.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        dg_bekleme.AutoSizeColumnsMode =
                                   DataGridViewAutoSizeColumnsMode.Fill;

                        myConnection.Close();
                    }
                }
            }

            foreach (DataGridViewRow btn in dg_biten.Rows)
            {
                if (btn.Selected == true)
                {
                    DialogResult sil = new DialogResult();
                    sil = MessageBox.Show("Emin misiniz?", "FATURA SİLME", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (sil == DialogResult.Yes)
                    {
                        komut = "DELETE FROM db_aktivite WHERE akt_id='" + akt_id + "'";
                        myCommand = new MySqlCommand(komut, myConnection);
                        da = new MySqlDataAdapter(myCommand);
                        dt = new DataTable();
                        // myReader = myCommand.ExecuteReader();

                        da.Fill(dt);

                        dg_biten.DataSource = dt;

                        dg_biten.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        dg_biten.AutoSizeColumnsMode =
                                   DataGridViewAutoSizeColumnsMode.Fill;

                        komut = "SELECT * FROM db_aktivite WHERE akt_statu='" + Convert.ToString("BİTTİ") + "'";
                        myCommand = new MySqlCommand(komut, myConnection);
                        da = new MySqlDataAdapter(myCommand);
                        dt = new DataTable();
                        // myReader = myCommand.ExecuteReader();

                        da.Fill(dt);

                        dg_biten.DataSource = dt;

                        dg_biten.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        dg_biten.AutoSizeColumnsMode =
                                   DataGridViewAutoSizeColumnsMode.Fill;

                        myConnection.Close();
                    }
                }

            }
        }

        private void dg_aktif_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                AktiviteDuzenle ag = new AktiviteDuzenle();
                ag.Show();

                akt_id = Convert.ToInt32(dg_aktif.Rows[e.RowIndex].Cells[0].Value.ToString());
                AktiviteDuzenle f1 = (AktiviteDuzenle)Application.OpenForms["AktiviteDuzenle"];
                ComboBox no = (ComboBox)f1.Controls["cmb_prj_no"];
                ComboBox oncelik = (ComboBox)f1.Controls["cmb_oncelik"];
                ComboBox statu = (ComboBox)f1.Controls["cmb_statu"];
                RichTextBox acıklama = (RichTextBox)f1.Controls["rcb_acıklama"];
                ComboBox rapor = (ComboBox)f1.Controls["cmb_rapor_edilecek"];
                DateTimePicker olusturma = (DateTimePicker)f1.Controls["date_olusturma"];
                DateTimePicker bitis = (DateTimePicker)f1.Controls["date_bitis"];
                Label id = (Label)f1.Controls["lbl_id"];
                id.Text = dg_aktif.Rows[e.RowIndex].Cells[0].Value.ToString();
                no.Text = dg_aktif.Rows[e.RowIndex].Cells[1].Value.ToString();
                oncelik.Text = dg_aktif.Rows[e.RowIndex].Cells[2].Value.ToString();
                statu.Text = dg_aktif.Rows[e.RowIndex].Cells[3].Value.ToString();
                acıklama.Text = dg_aktif.Rows[e.RowIndex].Cells[4].Value.ToString();
                rapor.Text = dg_aktif.Rows[e.RowIndex].Cells[5].Value.ToString();
                olusturma.Text = dg_aktif.Rows[e.RowIndex].Cells[6].Value.ToString();
                bitis.Text = dg_aktif.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            catch { }
        }

        private void dg_biten_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                AktiviteDuzenle ag = new AktiviteDuzenle();
                ag.Show();

                akt_id = Convert.ToInt32(dg_biten.Rows[e.RowIndex].Cells[0].Value.ToString());
                AktiviteDuzenle f1 = (AktiviteDuzenle)Application.OpenForms["AktiviteDuzenle"];
                ComboBox no = (ComboBox)f1.Controls["cmb_prj_no"];
                ComboBox oncelik = (ComboBox)f1.Controls["cmb_oncelik"];
                ComboBox statu = (ComboBox)f1.Controls["cmb_statu"];
                RichTextBox acıklama = (RichTextBox)f1.Controls["rcb_acıklama"];
                ComboBox rapor = (ComboBox)f1.Controls["cmb_rapor_edilecek"];
                DateTimePicker olusturma = (DateTimePicker)f1.Controls["date_olusturma"];
                DateTimePicker bitis = (DateTimePicker)f1.Controls["date_bitis"];
                Label id = (Label)f1.Controls["lbl_id"];
                id.Text = dg_biten.Rows[e.RowIndex].Cells[0].Value.ToString();
                no.Text = dg_biten.Rows[e.RowIndex].Cells[1].Value.ToString();
                oncelik.Text = dg_biten.Rows[e.RowIndex].Cells[2].Value.ToString();
                statu.Text = dg_biten.Rows[e.RowIndex].Cells[3].Value.ToString();
                acıklama.Text = dg_biten.Rows[e.RowIndex].Cells[4].Value.ToString();
                rapor.Text = dg_biten.Rows[e.RowIndex].Cells[5].Value.ToString();
                olusturma.Text = dg_biten.Rows[e.RowIndex].Cells[6].Value.ToString();
                bitis.Text = dg_biten.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            catch { }
        }

        private void dg_aktif_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                AktiviteDuzenle ag = new AktiviteDuzenle();
                ag.Show();

                akt_id = Convert.ToInt32(dg_aktif.Rows[e.RowIndex].Cells[0].Value.ToString());
                AktiviteDuzenle f1 = (AktiviteDuzenle)Application.OpenForms["AktiviteDuzenle"];
                ComboBox no = (ComboBox)f1.Controls["cmb_prj_no"];
                ComboBox oncelik = (ComboBox)f1.Controls["cmb_oncelik"];
                ComboBox statu = (ComboBox)f1.Controls["cmb_statu"];
                RichTextBox acıklama = (RichTextBox)f1.Controls["rcb_acıklama"];
                ComboBox rapor = (ComboBox)f1.Controls["cmb_rapor_edilecek"];
                DateTimePicker olusturma = (DateTimePicker)f1.Controls["date_olusturma"];
                DateTimePicker bitis = (DateTimePicker)f1.Controls["date_bitis"];
                Label id = (Label)f1.Controls["lbl_id"];
                id.Text = dg_aktif.Rows[e.RowIndex].Cells[0].Value.ToString();
                no.Text = dg_aktif.Rows[e.RowIndex].Cells[1].Value.ToString();
                oncelik.Text = dg_aktif.Rows[e.RowIndex].Cells[2].Value.ToString();
                statu.Text = dg_aktif.Rows[e.RowIndex].Cells[3].Value.ToString();
                acıklama.Text = dg_aktif.Rows[e.RowIndex].Cells[4].Value.ToString();
                rapor.Text = dg_aktif.Rows[e.RowIndex].Cells[5].Value.ToString();
                olusturma.Text = dg_aktif.Rows[e.RowIndex].Cells[6].Value.ToString();
                bitis.Text = dg_aktif.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            catch { }
        }

        private void dg_pasif_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                AktiviteDuzenle ag = new AktiviteDuzenle();
                ag.Show();

                akt_id = Convert.ToInt32(dg_pasif.Rows[e.RowIndex].Cells[0].Value.ToString());
                AktiviteDuzenle f1 = (AktiviteDuzenle)Application.OpenForms["AktiviteDuzenle"];
                ComboBox no = (ComboBox)f1.Controls["cmb_prj_no"];
                ComboBox oncelik = (ComboBox)f1.Controls["cmb_oncelik"];
                ComboBox statu = (ComboBox)f1.Controls["cmb_statu"];
                RichTextBox acıklama = (RichTextBox)f1.Controls["rcb_acıklama"];
                ComboBox rapor = (ComboBox)f1.Controls["cmb_rapor_edilecek"];
                DateTimePicker olusturma = (DateTimePicker)f1.Controls["date_olusturma"];
                DateTimePicker bitis = (DateTimePicker)f1.Controls["date_bitis"];
                Label id = (Label)f1.Controls["lbl_id"];
                id.Text = dg_pasif.Rows[e.RowIndex].Cells[0].Value.ToString();
                no.Text = dg_pasif.Rows[e.RowIndex].Cells[1].Value.ToString();
                oncelik.Text = dg_pasif.Rows[e.RowIndex].Cells[2].Value.ToString();
                statu.Text = dg_pasif.Rows[e.RowIndex].Cells[3].Value.ToString();
                acıklama.Text = dg_pasif.Rows[e.RowIndex].Cells[4].Value.ToString();
                rapor.Text = dg_pasif.Rows[e.RowIndex].Cells[5].Value.ToString();
                olusturma.Text = dg_pasif.Rows[e.RowIndex].Cells[6].Value.ToString();
                bitis.Text = dg_pasif.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            catch { }
        }

        private void dg_bekleme_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                AktiviteDuzenle ag = new AktiviteDuzenle();
                ag.Show();

                akt_id = Convert.ToInt32(dg_bekleme.Rows[e.RowIndex].Cells[0].Value.ToString());
                AktiviteDuzenle f1 = (AktiviteDuzenle)Application.OpenForms["AktiviteDuzenle"];
                ComboBox no = (ComboBox)f1.Controls["cmb_prj_no"];
                ComboBox oncelik = (ComboBox)f1.Controls["cmb_oncelik"];
                ComboBox statu = (ComboBox)f1.Controls["cmb_statu"];
                RichTextBox acıklama = (RichTextBox)f1.Controls["rcb_acıklama"];
                ComboBox rapor = (ComboBox)f1.Controls["cmb_rapor_edilecek"];
                DateTimePicker olusturma = (DateTimePicker)f1.Controls["date_olusturma"];
                DateTimePicker bitis = (DateTimePicker)f1.Controls["date_bitis"];
                Label id = (Label)f1.Controls["lbl_id"];
                id.Text = dg_bekleme.Rows[e.RowIndex].Cells[0].Value.ToString();
                no.Text = dg_bekleme.Rows[e.RowIndex].Cells[1].Value.ToString();
                oncelik.Text = dg_bekleme.Rows[e.RowIndex].Cells[2].Value.ToString();
                statu.Text = dg_bekleme.Rows[e.RowIndex].Cells[3].Value.ToString();
                acıklama.Text = dg_bekleme.Rows[e.RowIndex].Cells[4].Value.ToString();
                rapor.Text = dg_bekleme.Rows[e.RowIndex].Cells[5].Value.ToString();
                olusturma.Text = dg_bekleme.Rows[e.RowIndex].Cells[6].Value.ToString();
                bitis.Text = dg_bekleme.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            catch { }
        }

        private void dg_biten_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                AktiviteDuzenle ag = new AktiviteDuzenle();
                ag.Show();

                akt_id = Convert.ToInt32(dg_biten.Rows[e.RowIndex].Cells[0].Value.ToString());
                AktiviteDuzenle f1 = (AktiviteDuzenle)Application.OpenForms["AktiviteDuzenle"];
                ComboBox no = (ComboBox)f1.Controls["cmb_prj_no"];
                ComboBox oncelik = (ComboBox)f1.Controls["cmb_oncelik"];
                ComboBox statu = (ComboBox)f1.Controls["cmb_statu"];
                RichTextBox acıklama = (RichTextBox)f1.Controls["rcb_acıklama"];
                ComboBox rapor = (ComboBox)f1.Controls["cmb_rapor_edilecek"];
                DateTimePicker olusturma = (DateTimePicker)f1.Controls["date_olusturma"];
                DateTimePicker bitis = (DateTimePicker)f1.Controls["date_bitis"];
                Label id = (Label)f1.Controls["lbl_id"];
                id.Text = dg_biten.Rows[e.RowIndex].Cells[0].Value.ToString();
                no.Text = dg_biten.Rows[e.RowIndex].Cells[1].Value.ToString();
                oncelik.Text = dg_biten.Rows[e.RowIndex].Cells[2].Value.ToString();
                statu.Text = dg_biten.Rows[e.RowIndex].Cells[3].Value.ToString();
                acıklama.Text = dg_biten.Rows[e.RowIndex].Cells[4].Value.ToString();
                rapor.Text = dg_biten.Rows[e.RowIndex].Cells[5].Value.ToString();
                olusturma.Text = dg_biten.Rows[e.RowIndex].Cells[6].Value.ToString();
                bitis.Text = dg_biten.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            catch { }
        }
    }
}
