using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Xml;

namespace MERP_MUI
{
    class HelperFunctions
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        string connectionString;
        DataTable dt = new DataTable();
        string tarih2;

        public HelperFunctions()
        {
            Initialize();
        }
        public void Initialize()
        {
            server = "localhost";
            database = "uretimplanlama_2";
            uid = "root";
            password = "root";
            //string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }
        public string Comma2Dot(string text)
        {
            text = text.Replace(',', '.');
            return text;
        }
        public string EuroCalculation(string tarih, string tutar, string birim, string euro)
        {
            DateTime dt = Convert.ToDateTime(tarih);
            tarih = dt.ToString("dd/MM/yyyy");
            string[] tr = tarih.Split('-');
            tarih = Convert.ToString(tr[0] + tr[1] + tr[2]);
            tarih2 = Convert.ToString(tr[2] + tr[1]);
            string anyDays = "http://www.tcmb.gov.tr/kurlar/" + tarih2 + "/" + tarih + ".xml";

            try
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(anyDays);

                DateTime exchangeDate = Convert.ToDateTime(xmlDoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);

                string USD = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
                string EURO = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
                string POUND = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteBuying").InnerXml;
                string CHF = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='CHF']/BanknoteBuying").InnerXml;

                decimal EtU = Convert.ToDecimal(EURO) / Convert.ToDecimal(USD);
                decimal EtC = Convert.ToDecimal(EURO) / Convert.ToDecimal(CHF);
                decimal EtP = Convert.ToDecimal(EURO) / Convert.ToDecimal(POUND);


                if (birim == "USD")
                {
                    euro = Convert.ToString(Convert.ToDecimal(tutar) / EtU);
                }
                else if (birim == "CHF")
                {
                    euro = Convert.ToString(Convert.ToDecimal(tutar) / EtC);
                }
                else if (birim == "TRY")
                {
                    euro = Convert.ToString(Convert.ToDecimal(tutar) / Convert.ToDecimal(EURO));
                }
                else if (birim == "GBP")
                {
                    euro = Convert.ToString(Convert.ToDecimal(tutar) / EtP);
                }
                else if (birim == "EUR")
                {
                    euro = Convert.ToString(Convert.ToDecimal(tutar));
                }
                else
                {
                    euro = Convert.ToString((0000));
                }
                return euro;
            }
            catch
            {
                euro = Convert.ToString((0000));
                return euro;
            }
        }
        public string DecimalToCurrency(decimal deger1, string deger2)
        {
            deger2 = string.Format(new CultureInfo("de-DE"), "{0:C2}", deger1);
            return deger2;
        }

        public string EuroDonusum(string birim, string butce)
        {
            try
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(@"http://www.tcmb.gov.tr/kurlar/today.xml");

                DateTime exchangeDate = Convert.ToDateTime(xmlDoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);

                string USD = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
                string EURO = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
                string POUND = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteBuying").InnerXml;
                string CHF = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='CHF']/BanknoteBuying").InnerXml;

                decimal EtU = Convert.ToDecimal(EURO) / Convert.ToDecimal(USD);
                decimal EtC = Convert.ToDecimal(EURO) / Convert.ToDecimal(CHF);
                decimal EtP = Convert.ToDecimal(EURO) / Convert.ToDecimal(POUND);


                if (birim == "USD")
                {
                    butce = Convert.ToString(Convert.ToDecimal(butce) / EtU);
                }
                else if (birim == "CHF")
                {
                    butce = Convert.ToString(Convert.ToDecimal(butce) / EtC);
                }
                else if (birim == "TRY")
                {
                    butce = Convert.ToString(Convert.ToDecimal(butce) / Convert.ToDecimal(EURO));
                }
                else if (birim == "GBP")
                {
                    butce = Convert.ToString(Convert.ToDecimal(butce) / EtP);
                }
                else if (birim == "EUR")
                {
                    butce = Convert.ToString(Convert.ToDecimal(butce));
                }
                else
                {
                    butce = Convert.ToString((0000));
                }
                return butce;
            }
            catch
            {
                butce = Convert.ToString((0000));
                return butce;
            }
        }
    }
}
