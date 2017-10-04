using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace MERP_MUI
{
    public partial class KullanıcıGirisi : MetroFramework.Forms.MetroForm
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

        public KullanıcıGirisi()
        {
            InitializeComponent();
        }

        private void KullanıcıGirisi_Load(object sender, EventArgs e)
        {
            server = "localhost";
            database = "uretimplanlama_2";
            uid = "root";
            password = "root";
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            myConnection = new MySqlConnection(connectionString);
            myConnection.Open();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text==txtPassword2.Text)
            {
                db = new DBConnect();
                db.InsertKullaniciGiris(Convert.ToString(txtKullanıcıAdı.Text), Convert.ToString(txtPassword.Text), Convert.ToString(txtMailAdress.Text), Convert.ToDateTime(dtpCevap.Value));
                this.Close();
            }
            else
            {
                MessageBoxx frmMessage = new MessageBoxx();
                frmMessage.txtMessage.Text = "Lütfen iki kutucuğa da aynı şifreyi giriniz";
                frmMessage.Show();
            }

        }
    }
}
