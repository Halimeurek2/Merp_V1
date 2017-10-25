using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace MERP_MUI
{
    public partial class AktiviteDuzenle : MetroFramework.Forms.MetroForm
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
        DBConnect db;

        public AktiviteDuzenle()
        {
            InitializeComponent();
        }

        private void AktiviteDuzenle_Load(object sender, EventArgs e)
        {
            server = "localhost";
            database = "merp_dbv1";
            uid = "root";
            password = "root";
            //string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            myConnection = new MySqlConnection(connectionString);
            myConnection.Open();

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
                cmb_prj_no.Items.Add(myReader["proje_no"]);
            }
            myReader.Close();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_duzenle_Click(object sender, EventArgs e)
        {
            db = new DBConnect();
            db.UpdateAktivite(Convert.ToInt32(lbl_id.Text), Convert.ToString(cmb_prj_no.Text), Convert.ToString(cmb_oncelik.Text), Convert.ToString(cmb_statu.Text), Convert.ToString(rcb_acıklama.Text), Convert.ToString(cmb_rapor_edilecek.Text), Convert.ToDateTime(date_olusturma.Text), Convert.ToDateTime(date_bitis.Text));

            this.Close();
        }
    }
}
