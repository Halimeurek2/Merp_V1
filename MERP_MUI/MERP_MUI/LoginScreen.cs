using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace MERP_MUI
{
    public partial class LoginScreen : MetroFramework.Forms.MetroForm
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

        public int Connected;

        public LoginScreen()
        {
            InitializeComponent();
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {
            server = "localhost";
            database = "uretimplanlama_2";
            uid = "root";
            password = "root";
            //string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            myConnection = new MySqlConnection(connectionString);
            myConnection.Open();
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            KullanıcıGirisi frmGiris = new KullanıcıGirisi();
            frmGiris.Show();
        }

        private void pbLogin_Click(object sender, EventArgs e)
        {
            try
            {
                komut = "SELECT * FROM db_kullanıcılar where kullanici_adi='" + txtKullanıcıAdı.Text + "' and password='" + txtPassword.Text + "';";
                da = new MySqlDataAdapter(komut, connection);
                myCommand = new MySqlCommand(komut, myConnection);
                MySqlDataReader myReader;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    
                }

                //MainForm frmMain = new MainForm();
                //frmMain.Connected = 1;
                //frmMain.Show();
               

                myReader.Close();
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch {  }
        }
    }
}
