using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace MERP_MUI
{
    class DBConnect
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DBConnect()
        {
            Initialize();
        }
        public void Initialize()
        {
            server = "localhost";
            database = "merp_dbv1";
            uid = "root";
            password = "root";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        //  MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        //  MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void InsertFaturaGiris(string fatura_no,
                                      string proje_no,
                                      string firma,
                                      int vade,
                                      DateTime vade_tarih,
                                      string aciklama,
                                      DateTime tarih,
                                      Boolean check,
                                      Decimal tutar,
                                      string birim,
                                      int avans,
                                      decimal fatura_euro,
                                      decimal fatura_dolar,
                                      decimal fatura_tl,
                                      string tip,
                                      string cins,
                                      string durum,
                                      string siparisemri)
        {

            MySqlCommand cmd = new MySqlCommand("INSERT INTO db_faturalar (fatura_no," +
           "fatura_proje_no," +
           "fatura_firma," +
           "fatura_vade," +
           "fatura_vade_tarih," +
           "fatura_aciklama," +
           "fatura_tarih," +
           "fatura_check," +
           "fatura_tutari," +
           "fatura_birim," +
           "fatura_avans," +
           "fatura_euro,fatura_dolar,fatura_tl,fatura_tipi,fatura_cinsi,fatura_durum,fatura_siparisemri) VALUES (@fatura_no," +
           "@proje_no," +
           "@firma," +
           "@vade," +
           "@vade_tarih," +
           "@aciklama," +
           "@tarih," +
           "@check," +
           "@tutar," +
           "@birim," +
           "@avans," +
           "@fatura_euro,@fatura_dolar,@fatura_tl,@tip,@cins,@durum,@siparisemri)", connection);

            cmd.Parameters.AddWithValue("@fatura_no", fatura_no);
            cmd.Parameters.AddWithValue("@proje_no", proje_no);
            cmd.Parameters.AddWithValue("@firma", firma);
            cmd.Parameters.AddWithValue("@vade", vade);
            cmd.Parameters.AddWithValue("@vade_tarih", vade_tarih);
            cmd.Parameters.AddWithValue("@aciklama", aciklama);
            cmd.Parameters.AddWithValue("@tarih", tarih);
            cmd.Parameters.AddWithValue("@check", check);
            cmd.Parameters.AddWithValue("@tutar", tutar);
            cmd.Parameters.AddWithValue("@birim", birim);
            cmd.Parameters.AddWithValue("@avans", avans);
            cmd.Parameters.AddWithValue("@fatura_euro", fatura_euro);
            cmd.Parameters.AddWithValue("@fatura_dolar", fatura_dolar);
            cmd.Parameters.AddWithValue("@fatura_tl", fatura_tl);
            cmd.Parameters.AddWithValue("@tip", tip);
            cmd.Parameters.AddWithValue("@cins", cins);
            cmd.Parameters.AddWithValue("@durum", durum);
            cmd.Parameters.AddWithValue("@siparisemri", siparisemri);


            //open connection
            if (this.OpenConnection() == true)
            {

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public void InsertProjeGiris(string proje_no,
                                     string proje_ismi,
                                     Decimal butce,
                                     string birim,
                                     decimal proje_euro,
                                     decimal proje_dolar,
                                     decimal proje_tl,
                                     string musteri,
                                     DateTime baslangic,
                                     DateTime bitis,
                                     int vade,
                                     string aciklama,
                                     decimal harcama_toplam,
                                     string harcama_top_birim,
                                     string tip)
        {

            MySqlCommand cmd = new MySqlCommand("INSERT INTO db_projeler (proje_no," +
           "proje_ismi," +
           "proje_butce," +
           "proje_birim," +
           "proje_euro," +
           "proje_dolar," +
           "proje_tl," +
           "proje_musteri," +
           "proje_baslangic," +
           "proje_bitis," +
           "proje_vade," +
           "proje_aciklama," +
           "harcama_toplam," +
           "harcama_toplam_birim," +
           "proje_tipi) VALUES (@proje_no,@proje_ismi,@butce,@birim,@proje_euro,@proje_dolar,@proje_tl," +
           "@musteri,@baslangic,@bitis,@vade,@aciklama," +
           "@harcama_toplam,@harcama_top_birim,"+
           "@tip)", connection);

            cmd.Parameters.AddWithValue("@proje_no", proje_no);
            cmd.Parameters.AddWithValue("@proje_ismi", proje_ismi);
            cmd.Parameters.AddWithValue("@butce", butce);
            cmd.Parameters.AddWithValue("@birim", birim);
            cmd.Parameters.AddWithValue("@proje_euro", proje_euro);
            cmd.Parameters.AddWithValue("@proje_dolar", proje_dolar);
            cmd.Parameters.AddWithValue("@proje_tl", proje_tl);
            cmd.Parameters.AddWithValue("@musteri", musteri);
            cmd.Parameters.AddWithValue("@baslangic", baslangic);
            cmd.Parameters.AddWithValue("@bitis", bitis);
            cmd.Parameters.AddWithValue("@vade", vade);
            cmd.Parameters.AddWithValue("@aciklama", aciklama);
            cmd.Parameters.AddWithValue("@harcama_toplam", harcama_toplam);
            cmd.Parameters.AddWithValue("@harcama_top_birim", harcama_top_birim);
            cmd.Parameters.AddWithValue("@tip", tip);


            //open connection
            if (this.OpenConnection() == true)
            {

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public void InsertSE(string proje_no,
                             string satinalma_no,
                             string tedarikci,
                             string siparisi_olusturan,
                             DateTime siparis_tarihi,
                             int vade,
                             DateTime temin_tarihi,
                             decimal fiyat,
                             string birim,
                             decimal siparis_euro,
                             decimal siparis_dolar,
                             decimal siparis_tl,
                             string aciklama, string siparis_tipi)
        {

            MySqlCommand cmd = new MySqlCommand("INSERT INTO db_siparis_emri (proje_no," +
           "satinalma_no," +
           "tedarikci," +
           "siparisi_olusturan," +
           "siparis_tarihi," +
           "vade," +
           "temin_tarihi," +
           "fiyat," +
           "fiyat_birim," +
           "siparis_euro," +
           "siparis_dolar," +
           "siparis_tl," +
           "aciklama,siparis_tipi) VALUES (@proje_no," +
           "@satinalma_no," +
           "@tedarikci," +
           "@siparisi_olusturan," +
           "@siparis_tarihi," +
           "@vade," +
           "@temin_tarihi," +
           "@fiyat," +
           "@birim," +
           "@siparis_euro," +
           "@siparis_dolar," +
           "@siparis_tl," +
           "@aciklama,@siparis_tipi)", connection);


            cmd.Parameters.AddWithValue("@proje_no", proje_no);
            cmd.Parameters.AddWithValue("@satinalma_no", satinalma_no);
            cmd.Parameters.AddWithValue("@tedarikci", tedarikci);
            cmd.Parameters.AddWithValue("@siparisi_olusturan", siparisi_olusturan);
            cmd.Parameters.AddWithValue("@siparis_tarihi", siparis_tarihi);
            cmd.Parameters.AddWithValue("@vade", vade);
            cmd.Parameters.AddWithValue("@temin_tarihi", temin_tarihi);
            cmd.Parameters.AddWithValue("@fiyat", fiyat);
            cmd.Parameters.AddWithValue("@birim", birim);
            cmd.Parameters.AddWithValue("@siparis_euro", siparis_euro);
            cmd.Parameters.AddWithValue("@siparis_dolar", siparis_dolar);
            cmd.Parameters.AddWithValue("@siparis_tl", siparis_tl);
            cmd.Parameters.AddWithValue("@aciklama", aciklama);
            cmd.Parameters.AddWithValue("@siparis_tipi", siparis_tipi);


            //open connection
            if (this.OpenConnection() == true)
            {

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public void InsertAktiviteGiris(string proje_no,
                                        string oncelik,
                                        string statu,
                                        string aciklama,
                                        string rapor_edilecek,
                                        DateTime olusturulan_tarih,
                                        DateTime bitis_tarih)
        {

            MySqlCommand cmd = new MySqlCommand("INSERT INTO db_aktivite (akt_prj_no," +
           "akt_oncelik," +
           "akt_statu," +
           "akt_aciklama," +
           "akt_rapor_edilecek," +
           "akt_olusturulan_tarih," +
           "akt_bitis_tarih) VALUES (@proje_no," +
           "@oncelik," +
           "@statu," +
           "@aciklama," +
           "@rapor_edilecek," +
           "@olusturulan_tarih," +
           "@bitis_tarih)", connection);

            cmd.Parameters.AddWithValue("@proje_no", proje_no);
            cmd.Parameters.AddWithValue("@oncelik", oncelik);
            cmd.Parameters.AddWithValue("@statu", statu);
            cmd.Parameters.AddWithValue("@aciklama", aciklama);
            cmd.Parameters.AddWithValue("@rapor_edilecek", rapor_edilecek);
            cmd.Parameters.AddWithValue("@olusturulan_tarih", olusturulan_tarih);
            cmd.Parameters.AddWithValue("@bitis_tarih", bitis_tarih);


            //open connection
            if (this.OpenConnection() == true)
            {

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public void InsertHarcamalar(int proje_id,
                                string harcama_tipi,
                                decimal harcama_tutar,
                                string birim,
                                DateTime tarih)
        {

            MySqlCommand cmd = new MySqlCommand("INSERT INTO db_projeharcama (harcama_proje," +
           "harcama_tipi," +
           "harcama_tutar," +
           "harcama_birim," +
           "harcama_tarih) VALUES (@proje_id," +
           "@harcama_tipi," +
           "@harcama_tutar," +
           "@birim," +
           "@tarih)", connection);

            cmd.Parameters.AddWithValue("@proje_id", proje_id);
            cmd.Parameters.AddWithValue("@harcama_tipi", harcama_tipi);
            cmd.Parameters.AddWithValue("@harcama_tutar", harcama_tutar);
            cmd.Parameters.AddWithValue("@birim", birim);
            cmd.Parameters.AddWithValue("@tarih", tarih);


            //open connection
            if (this.OpenConnection() == true)
            {

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public void InsertOdemeler(int proje_id,
                              string ongoru_tipi,
                              decimal ongoru_tutar,
                              string birim,
                              DateTime tarih)
        {

            MySqlCommand cmd = new MySqlCommand("INSERT INTO db_projeongoru (ongoru_proje," +
           "ongoru_tipi," +
           "ongoru_tutar," +
           "ongoru_birim," +
           "ongoru_tarih) VALUES (@proje_id," +
           "@ongoru_tipi," +
           "@ongoru_tutar," +
           "@birim," +
           "@tarih)", connection);

            cmd.Parameters.AddWithValue("@proje_id", proje_id);
            cmd.Parameters.AddWithValue("@ongoru_tipi", ongoru_tipi);
            cmd.Parameters.AddWithValue("@ongoru_tutar", ongoru_tutar);
            cmd.Parameters.AddWithValue("@birim", birim);
            cmd.Parameters.AddWithValue("@tarih", tarih);


            //open connection
            if (this.OpenConnection() == true)
            {

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public void InsertKullaniciGiris(string kullaniciAdi,
                                         string password,
                                         string kullanici_mail,
                                         DateTime guvenlikCevap)
        {

            MySqlCommand cmd = new MySqlCommand("INSERT INTO db_kullanicilar (kullanici_adi," +
           "password," +
           "kullanici_mail," +
           "guvenlikcevap) VALUES (@kullaniciAdi," +
           "@password," +
           "@kullanici_mail," +
           "@guvenlikCevap)", connection);

            cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@kullanici_mail", kullanici_mail);
            cmd.Parameters.AddWithValue("@guvenlikCevap", guvenlikCevap);


            //open connection
            if (this.OpenConnection() == true)
            {

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public void InsertKullanicilar(int kullanici_id,
                                       DateTime giris_tarihi,
                                       DateTime cikis_tarihi,
                                       int animsaCheck)
        {

            MySqlCommand cmd = new MySqlCommand("INSERT INTO db_kullanicigirisi (kullanici_id," +
           "giris_tarihi," +
           "cikis_tarihi," +
           "animsaCheck) VALUES (@kullanici_id," +
           "@giris_tarihi," +
           "@cikis_tarihi," +
           "@animsaCheck)", connection);

            cmd.Parameters.AddWithValue("@kullanici_id", kullanici_id);
            cmd.Parameters.AddWithValue("@giris_tarihi", giris_tarihi);
            cmd.Parameters.AddWithValue("@cikis_tarihi", cikis_tarihi);
            cmd.Parameters.AddWithValue("@animsaCheck", animsaCheck);


            //open connection
            if (this.OpenConnection() == true)
            {

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public void UpdateAktivite(int id,
                                   string proje_no,
                                   string oncelik,
                                   string statu,
                                   string aciklama,
                                   string rapor_edilecek,
                                   DateTime olusturulan_tarih,
                                   DateTime bitis_tarih)
        {
            MySqlCommand cmd = new MySqlCommand("update db_aktivite set akt_prj_no=@proje_no," +
           "akt_oncelik=@oncelik," +
           "akt_statu=@statu," +
           "akt_aciklama=@aciklama," +
           "akt_rapor_edilecek=@rapor_edilecek," +
           "akt_olusturulan_tarih=@olusturulan_tarih," +
           "akt_bitis_tarih=@bitis_tarih where akt_id=@id", connection);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@proje_no", proje_no);
            cmd.Parameters.AddWithValue("@oncelik", oncelik);
            cmd.Parameters.AddWithValue("@statu", statu);
            cmd.Parameters.AddWithValue("@aciklama", aciklama);
            cmd.Parameters.AddWithValue("@rapor_edilecek", rapor_edilecek);
            cmd.Parameters.AddWithValue("@olusturulan_tarih", olusturulan_tarih);
            cmd.Parameters.AddWithValue("@bitis_tarih", bitis_tarih);


            if (this.OpenConnection() == true)
            {

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public void UpdateFaturalar(int id,
                                    string fatura_no,
                                    string proje_no,
                                    string firma,
                                    int vade,
                                    DateTime vade_tarih,
                                    string aciklama,
                                    DateTime tarih,
                                    Boolean check,
                                    Decimal tutar,
                                    string birim,
                                    int avans,
                                    decimal fatura_euro,
                                    decimal fatura_dolar,
                                    decimal fatura_tl,
                                    string tip,
                                    string cins,
                                    string durum, string fatura_siparisemri)
        {
            MySqlCommand cmd = new MySqlCommand("update db_faturalar set fatura_no=@fatura_no," +
           "fatura_proje_no=@proje_no," +
           "fatura_firma=@firma," +
           "fatura_vade=@vade," +
           "fatura_vade_tarih=@vade_tarih," +
           "fatura_aciklama=@aciklama," +
           "fatura_tarih=@tarih," +
           "fatura_check=@check," +
           "fatura_tutari=@tutar," +
           "fatura_birim=@birim," +
           "fatura_avans=@avans," +
           "fatura_euro=@fatura_euro," +
           "fatura_dolar=@fatura_dolar," +
           "fatura_tl=@fatura_tl," +
           "fatura_tipi=@tip," +
           "fatura_cinsi=@cins," +
           "fatura_durum=@durum, fatura_siparisemri=@fatura_siparisemri where fatura_id=@id", connection);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@fatura_no", fatura_no);
            cmd.Parameters.AddWithValue("@proje_no", proje_no);
            cmd.Parameters.AddWithValue("@firma", firma);
            cmd.Parameters.AddWithValue("@vade", vade);
            cmd.Parameters.AddWithValue("@vade_tarih", vade_tarih);
            cmd.Parameters.AddWithValue("@aciklama", aciklama);
            cmd.Parameters.AddWithValue("@tarih", tarih);
            cmd.Parameters.AddWithValue("@check", check);
            cmd.Parameters.AddWithValue("@tutar", tutar);
            cmd.Parameters.AddWithValue("@birim", birim);
            cmd.Parameters.AddWithValue("avans", avans);
            cmd.Parameters.AddWithValue("@fatura_euro", fatura_euro);
            cmd.Parameters.AddWithValue("@fatura_dolar", fatura_dolar);
            cmd.Parameters.AddWithValue("@fatura_tl", fatura_tl);
            cmd.Parameters.AddWithValue("@tip", tip);
            cmd.Parameters.AddWithValue("@cins", cins);
            cmd.Parameters.AddWithValue("@durum", durum);
            cmd.Parameters.AddWithValue("@fatura_siparisemri", fatura_siparisemri);


            if (this.OpenConnection() == true)
            {

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public void UpdateProjeler(int id,
                                    string proje_no,
                                    string proje_ismi,
                                    decimal butce,
                                    string birim,
                                    decimal proje_euro,
                                    decimal proje_dolar,
                                    decimal proje_tl,
                                    string musteri,
                                    DateTime baslangic,
                                    DateTime bitis,
                                    int vade,
                                    string aciklama,
                                    decimal harcama_toplam,
                                    string harcama_top_birim,
                                    string tip)
        {
            MySqlCommand cmd = new MySqlCommand("update db_projeler set proje_no=@proje_no," +
           "proje_ismi=@proje_ismi," +
           "proje_butce=@butce," +
           "proje_birim=@birim," +
           "proje_euro=@proje_euro," +
           "proje_dolar=@proje_dolar," +
           "proje_tl=@proje_tl," +
           "proje_musteri=@musteri," +
           "proje_baslangic=@baslangic," +
           "proje_bitis=@bitis," +
           "proje_vade=@vade," +
           "proje_aciklama=@aciklama," +
           "harcama_toplam=@harcama_toplam," +
           "harcama_toplam_birim=@harcama_top_birim," +
           "proje_tipi=@tip where proje_id=@id", connection);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@proje_no", proje_no);
            cmd.Parameters.AddWithValue("@proje_ismi", proje_ismi);
            cmd.Parameters.AddWithValue("@butce", butce);
            cmd.Parameters.AddWithValue("@birim", birim);
            cmd.Parameters.AddWithValue("@proje_euro", proje_euro);
            cmd.Parameters.AddWithValue("@proje_dolar", proje_dolar);
            cmd.Parameters.AddWithValue("@proje_tl", proje_tl);
            cmd.Parameters.AddWithValue("@musteri", musteri);
            cmd.Parameters.AddWithValue("@baslangic", baslangic);
            cmd.Parameters.AddWithValue("@bitis", bitis);
            cmd.Parameters.AddWithValue("@vade", vade);
            cmd.Parameters.AddWithValue("@aciklama", aciklama);
            cmd.Parameters.AddWithValue("@harcama_toplam", harcama_toplam);
            cmd.Parameters.AddWithValue("@harcama_top_birim", harcama_top_birim);
            cmd.Parameters.AddWithValue("@tip", tip);


            if (this.OpenConnection() == true)
            {

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        public void UpdateSE(int id,
                        string proje_no,
                        string satinalma_no,
                        string tedarikci,
                        string siparisi_olusturan,
                        DateTime siparis_tarihi,
                        int vade,
                        DateTime temin_tarihi,
                        decimal fiyat,
                        string birim,
                        decimal siparis_euro,
                        decimal siparis_dolar,
                        decimal siparis_tl,
                        string aciklama, string siparis_tipi)
        {

            MySqlCommand cmd = new MySqlCommand("update db_siparis_emri set proje_no=@proje_no," +
           "satinalma_no=@satinalma_no," +
           "tedarikci=@tedarikci," +
           "siparisi_olusturan=@siparisi_olusturan," +
           "siparis_tarihi=@siparis_tarihi," +
           "vade=@vade," +
           "temin_tarihi=@temin_tarihi," +
           "fiyat=@fiyat," +
           "fiyat_birim=@birim," +
           "siparis_euro=@siparis_euro," +
           "siparis_dolar=@siparis_dolar," +
           "siparis_tl=@siparis_tl," +
           "aciklama=@aciklama, siparis_tipi=@siparis_tipi where siparis_id=@id", connection);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@proje_no", proje_no);
            cmd.Parameters.AddWithValue("@satinalma_no", satinalma_no);
            cmd.Parameters.AddWithValue("@tedarikci", tedarikci);
            cmd.Parameters.AddWithValue("@siparisi_olusturan", siparisi_olusturan);
            cmd.Parameters.AddWithValue("@siparis_tarihi", siparis_tarihi);
            cmd.Parameters.AddWithValue("@vade", vade);
            cmd.Parameters.AddWithValue("@temin_tarihi", temin_tarihi);
            cmd.Parameters.AddWithValue("@fiyat", fiyat);
            cmd.Parameters.AddWithValue("@birim", birim);
            cmd.Parameters.AddWithValue("@siparis_euro", siparis_euro);
            cmd.Parameters.AddWithValue("@siparis_dolar", siparis_dolar);
            cmd.Parameters.AddWithValue("@siparis_tl", siparis_tl);
            cmd.Parameters.AddWithValue("@aciklama", aciklama);
            cmd.Parameters.AddWithValue("@siparis_tipi", siparis_tipi);



            //open connection
            if (this.OpenConnection() == true)
            {

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public void UpdateHarcamalar(int id, int proje_id,
                                     string harcama_tipi,
                                     decimal harcama_tutar,
                                     string birim,
                                     DateTime tarih)
        {

            MySqlCommand cmd = new MySqlCommand("update db_projeharcama set harcama_proje=@proje_id," +
           "harcama_tipi=@harcama_tipi," +
           "harcama_tutar=@harcama_tutar," +
           "harcama_birim=@birim," +
           "harcama_tarih=@tarih where harcama_id=@id", connection);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@proje_id", proje_id);
            cmd.Parameters.AddWithValue("@harcama_tipi", harcama_tipi);
            cmd.Parameters.AddWithValue("@harcama_tutar", harcama_tutar);
            cmd.Parameters.AddWithValue("@birim", birim);
            cmd.Parameters.AddWithValue("@tarih", tarih);


            //open connection
            if (this.OpenConnection() == true)
            {

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public void UpdateOdemeler(int id, int proje_id,
                             string ongoru_tipi,
                             decimal ongoru_tutar,
                             string birim,
                             DateTime tarih)
        {

            MySqlCommand cmd = new MySqlCommand("update db_projeongoru set ongoru_proje=@proje_id," +
           "ongoru_tipi=@ongoru_tipi," +
           "ongoru_tutar=@ongoru_tutar," +
           "ongoru_birim=@birim," +
           "ongoru_tarih=@tarih where ongoru_id=@id", connection);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@proje_id", proje_id);
            cmd.Parameters.AddWithValue("@ongoru_tipi", ongoru_tipi);
            cmd.Parameters.AddWithValue("@ongoru_tutar", ongoru_tutar);
            cmd.Parameters.AddWithValue("@birim", birim);
            cmd.Parameters.AddWithValue("@tarih", tarih);


            //open connection
            if (this.OpenConnection() == true)
            {

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
    }
}
