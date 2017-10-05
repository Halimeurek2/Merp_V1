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
            database = "uretimplanlama_2";
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
                                      string tip,
                                      string cins,
                                      string durum)
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
           "fatura_euro,fatura_tipi,fatura_cinsi,fatura_durum) VALUES (@fatura_no," +
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
           "@fatura_euro,@tip,@cins,@durum)", connection);

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
            cmd.Parameters.AddWithValue("@tip", tip);
            cmd.Parameters.AddWithValue("@cins", cins);
            cmd.Parameters.AddWithValue("@durum", durum);


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
                                     string musteri,
                                     DateTime baslangic,
                                     DateTime bitis,
                                     int vade,
                                     string aciklama,
                                     decimal harcama_m_mlz,
                                     decimal harcama_el_mlz,
                                     decimal harcama_imalat,
                                     decimal harcama_test,
                                     decimal harcama_risk,
                                     decimal harcama_toplam,
                                     string harcama_top_birim,
                                     decimal odeme_avans,
                                     DateTime date_avans,
                                     decimal odeme_pdr,
                                     DateTime date_pdr,
                                     decimal odeme_cdr,
                                     DateTime date_cdr,
                                     decimal odeme_prototip,
                                     DateTime date_prototip,
                                     decimal odeme_test,
                                     DateTime date_test,
                                     decimal odeme_kabul,
                                     DateTime date_kabul,
                                     decimal odeme_s6,
                                     DateTime date_s6,
                                     string tip)
        {

            MySqlCommand cmd = new MySqlCommand("INSERT INTO db_projeler (proje_no," +
           "proje_ismi," +
           "proje_butce," +
           "proje_birim," +
           "proje_musteri," +
           "proje_baslangic," +
           "proje_bitis," +
           "proje_vade," +
           "proje_aciklama," +
           "harcama_m_mlz," +
           "harcama_el_mlz," +
           "harcama_imalat," +
           "harcama_test," +
           "harcama_risk," +
           "harcama_toplam," +
           "harcama_toplam_birim," +
           "odeme_avans," +
           "date_avans," +
           "odeme_pdr," +
           "date_pdr," +
           "odeme_cdr," +
           "date_cdr," +
           "odeme_prototip," +
           "date_prototip," +
           "odeme_test," +
           "date_test," +
           "odeme_kabul," +
           "date_kabul," +
           "odeme_s6," +
           "date_s6," +
           "prj_tip) VALUES (@proje_no,@proje_ismi,@butce,@birim," +
           "@musteri,@baslangic,@bitis,@vade,@aciklama,@harcama_m_mlz," +
           "@harcama_el_mlz,@harcama_imalat,@harcama_test,@harcama_risk," +
           "@harcama_toplam,@harcama_top_birim,@odeme_avans,@date_avans," +
           "@odeme_pdr,@date_pdr,@odeme_cdr,@date_cdr,@odeme_prototip," +
           "@date_prototip,@odeme_test,@date_test,@odeme_kabul,@date_kabul,@odeme_s6,@date_s6,@tip)", connection);

            cmd.Parameters.AddWithValue("@proje_no", proje_no);
            cmd.Parameters.AddWithValue("@proje_ismi", proje_ismi);
            cmd.Parameters.AddWithValue("@butce", butce);
            cmd.Parameters.AddWithValue("@birim", birim);
            cmd.Parameters.AddWithValue("@musteri", musteri);
            cmd.Parameters.AddWithValue("@baslangic", baslangic);
            cmd.Parameters.AddWithValue("@bitis", bitis);
            cmd.Parameters.AddWithValue("@vade", vade);
            cmd.Parameters.AddWithValue("@aciklama", aciklama);
            cmd.Parameters.AddWithValue("@harcama_m_mlz", harcama_m_mlz);
            cmd.Parameters.AddWithValue("@harcama_el_mlz", harcama_el_mlz);
            cmd.Parameters.AddWithValue("@harcama_imalat", harcama_imalat);
            cmd.Parameters.AddWithValue("@harcama_test", harcama_test);
            cmd.Parameters.AddWithValue("@harcama_risk", harcama_risk);
            cmd.Parameters.AddWithValue("@harcama_toplam", harcama_toplam);
            cmd.Parameters.AddWithValue("@harcama_top_birim", harcama_top_birim);
            cmd.Parameters.AddWithValue("@odeme_avans", odeme_avans);
            cmd.Parameters.AddWithValue("@date_avans", date_avans);
            cmd.Parameters.AddWithValue("@odeme_pdr", odeme_pdr);
            cmd.Parameters.AddWithValue("@date_pdr", date_pdr);
            cmd.Parameters.AddWithValue("@odeme_cdr", odeme_cdr);
            cmd.Parameters.AddWithValue("@date_cdr", date_cdr);
            cmd.Parameters.AddWithValue("@odeme_prototip", odeme_prototip);
            cmd.Parameters.AddWithValue("@date_prototip", date_prototip);
            cmd.Parameters.AddWithValue("@odeme_test", odeme_test);
            cmd.Parameters.AddWithValue("@date_test", date_test);
            cmd.Parameters.AddWithValue("@odeme_kabul", odeme_kabul);
            cmd.Parameters.AddWithValue("@date_kabul", date_kabul);
            cmd.Parameters.AddWithValue("@odeme_s6", odeme_s6);
            cmd.Parameters.AddWithValue("@date_s6", date_s6);
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
                             string aciklama)
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
           "aciklama) VALUES (@proje_no," +
           "@satinalma_no," +
           "@tedarikci," +
           "@siparisi_olusturan," +
           "@siparis_tarihi," +
           "@vade," +
           "@temin_tarihi," +
           "@fiyat," +
           "@birim," +
           "@siparis_euro," +
           "@aciklama)", connection);


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
            cmd.Parameters.AddWithValue("@aciklama", aciklama);



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
                                    string tip,
                                    string cins,
                                    string durum)
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
           "fatura_tipi=@tip," +
           "fatura_cinsi=@cins," +
           "fatura_durum=@durum where fatura_id=@id", connection);

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
            cmd.Parameters.AddWithValue("@tip", tip);
            cmd.Parameters.AddWithValue("@cins", cins);
            cmd.Parameters.AddWithValue("@durum", durum);


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
                                   string musteri,
                                   DateTime baslangic,
                                   DateTime bitis,
                                   int vade,
                                   string aciklama,
                                   decimal harcama_m_mlz,
                                   decimal harcama_el_mlz,
                                   decimal harcama_imalat,
                                   decimal harcama_test,
                                   decimal harcama_risk,
                                   decimal harcama_toplam,
                                   string harcama_top_birim,
                                   decimal odeme_avans,
                                   DateTime date_avans,
                                   decimal odeme_pdr,
                                   DateTime date_pdr,
                                   decimal odeme_cdr,
                                   DateTime date_cdr,
                                   decimal odeme_prototip,
                                   DateTime date_prototip,
                                   decimal odeme_test,
                                   DateTime date_test,
                                   decimal odeme_kabul,
                                   DateTime date_kabul,
                                   decimal odeme_s6,
                                   DateTime date_s6,
                                   string tip)
        {
            MySqlCommand cmd = new MySqlCommand("update db_projeler set proje_no=@proje_no," +
           "proje_ismi=@proje_ismi," +
           "proje_butce=@butce," +
           "proje_birim=@birim," +
           "proje_musteri=@musteri," +
           "proje_baslangic=@baslangic," +
           "proje_bitis=@bitis," +
           "proje_vade=@vade," +
           "proje_aciklama=@aciklama," +
           "harcama_m_mlz=@harcama_m_mlz," +
           "harcama_el_mlz=@harcama_el_mlz," +
           "harcama_imalat=@harcama_imalat," +
           "harcama_test=@harcama_test," +
           "harcama_risk=@harcama_risk," +
           "harcama_toplam=@harcama_toplam," +
           "harcama_toplam_birim=@harcama_top_birim," +
           "odeme_avans=@odeme_avans," +
           "date_avans=@date_avans," +
           "odeme_pdr=@odeme_pdr," +
           "date_pdr=@date_pdr," +
           "odeme_cdr=@odeme_cdr," +
           "date_cdr=@date_cdr," +
           "odeme_prototip=@odeme_prototip," +
           "date_prototip=@date_prototip," +
           "odeme_test=@odeme_test," +
           "date_test=@date_test," +
           "odeme_kabul=@odeme_kabul," +
           "date_kabul=@date_kabul," +
           "odeme_s6=@odeme_s6," +
           "date_s6=@date_s6," +
           "prj_tip=@tip where proje_id=@id", connection);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@proje_no", proje_no);
            cmd.Parameters.AddWithValue("@proje_ismi", proje_ismi);
            cmd.Parameters.AddWithValue("@butce", butce);
            cmd.Parameters.AddWithValue("@birim", birim);
            cmd.Parameters.AddWithValue("@musteri", musteri);
            cmd.Parameters.AddWithValue("@baslangic", baslangic);
            cmd.Parameters.AddWithValue("@bitis", bitis);
            cmd.Parameters.AddWithValue("@vade", vade);
            cmd.Parameters.AddWithValue("@aciklama", aciklama);
            cmd.Parameters.AddWithValue("@harcama_m_mlz", harcama_m_mlz);
            cmd.Parameters.AddWithValue("@harcama_el_mlz", harcama_el_mlz);
            cmd.Parameters.AddWithValue("@harcama_imalat", harcama_imalat);
            cmd.Parameters.AddWithValue("@harcama_test", harcama_test);
            cmd.Parameters.AddWithValue("@harcama_risk", harcama_risk);
            cmd.Parameters.AddWithValue("@harcama_toplam", harcama_toplam);
            cmd.Parameters.AddWithValue("@harcama_top_birim", harcama_top_birim);
            cmd.Parameters.AddWithValue("@odeme_avans", odeme_avans);
            cmd.Parameters.AddWithValue("@date_avans", date_avans);
            cmd.Parameters.AddWithValue("@odeme_pdr", odeme_pdr);
            cmd.Parameters.AddWithValue("@date_pdr", date_pdr);
            cmd.Parameters.AddWithValue("@odeme_cdr", odeme_cdr);
            cmd.Parameters.AddWithValue("@date_cdr", date_cdr);
            cmd.Parameters.AddWithValue("@odeme_prototip", odeme_prototip);
            cmd.Parameters.AddWithValue("@date_prototip", date_prototip);
            cmd.Parameters.AddWithValue("@odeme_test", odeme_test);
            cmd.Parameters.AddWithValue("@date_test", date_test);
            cmd.Parameters.AddWithValue("@odeme_kabul", odeme_kabul);
            cmd.Parameters.AddWithValue("@date_kabul", date_kabul);
            cmd.Parameters.AddWithValue("@odeme_s6", odeme_s6);
            cmd.Parameters.AddWithValue("@date_s6", date_s6);
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
                             string aciklama)
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
           "aciklama=@aciklama where siparis_id=@id", connection);

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
            cmd.Parameters.AddWithValue("@aciklama", aciklama);



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
