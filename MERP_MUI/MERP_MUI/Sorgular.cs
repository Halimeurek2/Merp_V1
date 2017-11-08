using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MERP_MUI
{
    class Sorgular
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        string connectionString;
        DataTable dt = new DataTable();
        string komut;
        MySqlCommand myCommand;
        MySqlDataAdapter da;
        MySqlConnection myConnection;
        MySqlDataReader myReader;
        
        HelperFunctions hf = new HelperFunctions();
     


        public Sorgular()
        {
            Initialize();
        }
        public void Initialize()
        {
            server = "localhost";
            database = "merp_dbv1";
            uid = "root";
            password = "root";
            //string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            myConnection = new MySqlConnection(connectionString);
            myConnection.Open();

            //connection = new MySqlConnection("Database=merp_dbv1; Data Source = localhost; User ID = root; password='root';");
        }
        public decimal FaturaTutar(string proje_no, string fatura_tip, decimal tutar)
        {
            try
            {
                komut = "SELECT sum(fatura_euro) FROM db_faturalar WHERE fatura_proje_no ='" + proje_no + "' AND fatura_tipi='" + fatura_tip + "'";
                da = new MySqlDataAdapter(komut, connection);
                myCommand = new MySqlCommand(komut, myConnection);
                MySqlDataReader myReader;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    tutar = Convert.ToDecimal(myReader.GetString(0));
                }
                myReader.Close();
            }
            catch
            {
                tutar = 0;
                if (myReader != null)
                { myReader.Close(); }
            }
            return tutar;
        }
        public decimal FaturaTutar(string proje_no, string fatura_tip, string fatura_durum, decimal tutar)
        {
            try
            {
                komut = "SELECT sum(fatura_tutari) FROM db_faturalar WHERE fatura_durum='"+fatura_durum+"' AND fatura_proje_no ='" + proje_no + "' AND fatura_tipi='"+fatura_tip+"'";
                da = new MySqlDataAdapter(komut, connection);
                myCommand = new MySqlCommand(komut, myConnection);
                MySqlDataReader myReader;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    tutar = Convert.ToDecimal(myReader.GetString(0));
                }
                myReader.Close();
            }
            catch
            {
                tutar = 0;
                if (myReader != null)
                { myReader.Close(); }
            }
            return tutar;
        }

        public decimal FaturaAvans(string proje_no, string fatura_tip, string fatura_durum, decimal tutar)
        {
            try
            {
                komut = "SELECT sum(fatura_avans) FROM db_faturalar WHERE fatura_durum='" + fatura_durum + "' AND fatura_proje_no ='" + proje_no + "' AND fatura_tipi='" + fatura_tip + "'";
                da = new MySqlDataAdapter(komut, connection);
                myCommand = new MySqlCommand(komut, myConnection);
                MySqlDataReader myReader;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    tutar = Convert.ToDecimal(myReader.GetString(0));
                }
                myReader.Close();
            }
            catch
            {
                tutar = 0;
                if (myReader != null)
                { myReader.Close(); }
            }
            return tutar;
        }

        public decimal ToplamAvans(string proje_no, string fatura_tip, string fatura_durum, string fatura_no, decimal tutar)
        {
            try
            {
                komut = "SELECT sum(fatura_tutari) FROM db_faturalar WHERE fatura_durum='"+fatura_durum+"' AND fatura_proje_no ='" + proje_no + "' AND fatura_tipi='"+fatura_tip+ "' AND fatura_no='" + fatura_no + "'";
                da = new MySqlDataAdapter(komut, connection);
                myCommand = new MySqlCommand(komut, myConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    tutar = Convert.ToDecimal(myReader.GetString(0));
                }
                myReader.Close();
            }
            catch
            {
                tutar = 0;
                if (myReader != null)
                { myReader.Close(); }
            }
            return tutar;
        }
        public decimal SumFatura(string proje_no, string fatura_tip, string fatura_cinsi, decimal tutar)
        {
            try
            {
                komut = "select sum(fatura_euro) as EURO from db_faturalar where fatura_cinsi='"+fatura_cinsi+"' AND fatura_proje_no ='" + proje_no + "' AND fatura_tipi='"+fatura_tip+"'";
                da = new MySqlDataAdapter(komut, connection);

                myCommand = new MySqlCommand(komut, myConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    tutar = Convert.ToDecimal(myReader.GetString(0));
                }
                myReader.Close();
            }
            catch
            {
                tutar = 0;
                if (myReader != null)
                { myReader.Close(); }
            }
            return tutar;
        }

        public decimal HarcamaOngoruSum(string proje_no, string harcama_tipi1, string harcama_tipi2, decimal tutar)
        {
            try
            {
                tutar = 0;
                komut = "select harcama_tutar,harcama_birim,harcama_tarih from db_projeharcama where harcama_proje = (select proje_id from db_projeler where proje_no = '" + proje_no + "') and (harcama_tipi = '"+harcama_tipi1+"' or harcama_tipi = '"+harcama_tipi2+"')";
                da = new MySqlDataAdapter(komut, connection);

                myCommand = new MySqlCommand(komut, myConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    tutar = Convert.ToDecimal(hf.EuroCalculation(myReader.GetString(2), myReader.GetString(0), myReader.GetString(1), Convert.ToString(tutar))) + tutar;
                }
                myReader.Close();
            }
            catch
            {
                tutar = 0;
                if(myReader!=null)
                { myReader.Close(); }
            }
            return tutar;
        }
        public decimal HarcamaOngoruSum(string proje_no, string harcama_tipi1, string harcama_tipi2, string harcama_tipi3, decimal tutar)
        {
            try
            {
                tutar = 0;
                komut = "select harcama_tutar,harcama_birim,harcama_tarih from db_projeharcama where harcama_proje = (select proje_id from db_projeler where proje_no = '" + proje_no + "') and (harcama_tipi = '"+harcama_tipi1+"' or harcama_tipi = '"+harcama_tipi2+"' or harcama_tipi = '"+harcama_tipi3+"')";
                da = new MySqlDataAdapter(komut, connection);

                myCommand = new MySqlCommand(komut, myConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    tutar = Convert.ToDecimal(hf.EuroCalculation(myReader.GetString(2), myReader.GetString(0), myReader.GetString(1), Convert.ToString(tutar))) + tutar;
                }
                myReader.Close();
            }
            catch
            {
                tutar = 0;
                if (myReader != null)
                { myReader.Close(); }
            }
            return tutar;
        }
        public decimal HarcamaOngoruSum(string proje_no, string harcama_tipi1, string harcama_tipi2, string harcama_tipi3, string harcama_tipi4, decimal tutar)
        {
            try
            {
                tutar = 0;
                komut = "select harcama_tutar,harcama_birim,harcama_tarih from db_projeharcama where harcama_proje = (select proje_id from db_projeler where proje_no = '" + proje_no + "') and (harcama_tipi = '"+harcama_tipi1+"' or harcama_tipi = '"+harcama_tipi2+"' or harcama_tipi = '"+harcama_tipi3+"' or harcama_tipi = '"+harcama_tipi4+"')";
                da = new MySqlDataAdapter(komut, connection);

                myCommand = new MySqlCommand(komut, myConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    tutar = Convert.ToDecimal(hf.EuroCalculation(myReader.GetString(2), myReader.GetString(0), myReader.GetString(1), Convert.ToString(tutar))) + tutar;
                }
                myReader.Close();
            }
            catch
            {
                tutar = 0;
                if (myReader != null)
                { myReader.Close(); }
            }
            return tutar;
        }
        public decimal ProjeButce(string proje_no, decimal tutar)
        {
            try
            {
                komut = "SELECT proje_butce,proje_birim,proje_baslangic FROM db_projeler WHERE proje_no='" + proje_no + "'";
                da = new MySqlDataAdapter(komut, connection);
                myCommand = new MySqlCommand(komut, myConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    tutar = Convert.ToDecimal(hf.EuroCalculation(Convert.ToString(myReader.GetString(2)), Convert.ToString(myReader.GetString(0)), Convert.ToString(myReader.GetString(1)), Convert.ToString(tutar)));
                }
                myReader.Close();
            }
            catch
            {
                tutar = 0;
                if (myReader != null)
                { myReader.Close(); }
            }
            return tutar;
        }
        public decimal SiparisToplam(string proje_no, decimal tutar)
        {
            try
            {
                komut = "SELECT sum(siparis_euro) FROM db_siparis_emri WHERE proje_no ='" + proje_no + "'";
                da = new MySqlDataAdapter(komut, connection);
                myCommand = new MySqlCommand(komut, myConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    tutar = Convert.ToDecimal(myReader.GetString(0));
                }
                myReader.Close();
            }
            catch
            {
                tutar = 0;
                if (myReader != null)
                { myReader.Close(); }
            }
            return tutar;
        }
        public string ProjeButceConvert(string proje_no, string tutar)
        {
            string BIRIM;
            try
            {
                komut = "SELECT proje_butce,proje_birim FROM db_projeler WHERE proje_no='" + proje_no + "'";
                da = new MySqlDataAdapter(komut, connection);
                myCommand = new MySqlCommand(komut, myConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    tutar = myReader.GetString(0);
                    BIRIM = Convert.ToString(myReader.GetString(1));

                    if (BIRIM == "USD")
                    {
                        tutar = string.Format(new CultureInfo("en-SG"), "{0:C2}", Convert.ToDecimal(tutar));
                    }
                    else if (BIRIM == "EUR")
                    {
                        tutar = string.Format(new CultureInfo("de-DE"), "{0:C2}", Convert.ToDecimal(tutar));
                    }
                    else if (BIRIM == "TRY")
                    {
                        tutar = string.Format("{0:C2}", Convert.ToDecimal(tutar));
                    }
                    else if (BIRIM == "GBP")
                    {
                        tutar = string.Format(new CultureInfo("en-GB"), "{0:C2}", Convert.ToDecimal(tutar));
                    }
                    else
                    {
                        tutar = string.Format(new CultureInfo("en-CH"), "{0:C2}", Convert.ToDecimal(tutar));
                    }
                }

                myReader.Close();
            }
            catch
            {
                tutar = "0";
                if (myReader != null)
                { myReader.Close(); }
            }
            return tutar;
        }
        public void FaturaArray(string proje_no, string fatura_durum, string fatura_tipi)
        {
            ProjeyeGoreRapor frmProjeRapor = new ProjeyeGoreRapor();
            try
            {
                int index = 0;
                komut = "SELECT DATE_FORMAT(fatura_vade_tarih,'%m-%Y') AS Month, SUM(fatura_euro) FROM db_faturalar WHERE fatura_durum='"+fatura_durum+"' and fatura_tipi='"+fatura_tipi+"' and fatura_proje_no ='" + proje_no + "' GROUP BY DATE_FORMAT(fatura_vade_tarih, '%m-%Y')";
                da = new MySqlDataAdapter(komut, connection);
                myCommand = new MySqlCommand(komut, myConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    if (Convert.ToDateTime(myReader.GetString(0)).Year == DateTime.Now.Year)
                    {
                        frmProjeRapor.monthG[index] = Convert.ToDateTime(myReader.GetString(0));
                        frmProjeRapor.month_sumG[index] = (float)Convert.ToDouble(myReader.GetString(1));
                        index++;
                    }
                }
                myReader.Close();
            }
            catch
            {
                if (myReader != null)
                { myReader.Close(); }
            }
        }
    }
}
