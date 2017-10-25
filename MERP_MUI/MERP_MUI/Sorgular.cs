using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
            connection = new MySqlConnection(connectionString);
            connection.Open();

            //connection = new MySqlConnection("Database=merp_dbv1; Data Source = localhost; User ID = root; password='root';");
        }
        public decimal FaturaTutar(string proje_no, string proje_tip, decimal tutar)
        {
            komut = "SELECT sum(fatura_euro) FROM db_faturalar WHERE fatura_proje_no ='" + proje_no + "' AND fatura_tipi='" + proje_tip + "'";
            da = new MySqlDataAdapter(komut, connection);
            myCommand = new MySqlCommand(komut, myConnection);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                tutar = Convert.ToDecimal(myReader.GetString(0));
            }
            myReader.Close();
            return tutar;
        }
    }
}
