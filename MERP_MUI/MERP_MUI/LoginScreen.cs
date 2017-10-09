using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

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

        DBConnect db;

        Boolean Connected;
        public int check;
        public int kullanici_id;
        public DateTime giris_tarihi;

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
            komut = "SELECT kullanicigirisi_id FROM db_kullanicilar where kullanici_adi='" + txtKullaniciAdi.Text + "';";
            da = new MySqlDataAdapter(komut, connection);
            myCommand = new MySqlCommand(komut, myConnection);
            MySqlDataReader myReader;
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                kullanici_id = Convert.ToInt16(myReader.GetString(0));
            }
            myReader.Close();

            if (txtKullaniciAdi.Text!="" && txtPassword.Text=="")
            {
                komut = "SELECT animsaCheck FROM db_kullanicigirisi where kullanici_id='" + kullanici_id + "';";
                da = new MySqlDataAdapter(komut, connection);
                myCommand = new MySqlCommand(komut, myConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    check = Convert.ToInt16(myReader.GetString(0));
                }
                myReader.Close();

                if(check==1)
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();

                    MainForm frmMain = new MainForm();
                    frmMain.kullanici_id = kullanici_id;
                    frmMain.animsaCheck = check;
                }
                else
                {
                    MessageBoxx frmMessage = new MessageBoxx();
                    frmMessage.txtMessage.Text = "Lütfen şifre ile giriş yapınız";
                    frmMessage.Show();
                }
            }
            else if(txtKullaniciAdi.Text == "")
            {
                MessageBoxx frmMessage = new MessageBoxx();
                frmMessage.txtMessage.Text = "Lütfen kullanıcı adını giriniz";
                frmMessage.Show();
            }

            if(txtKullaniciAdi.Text != "" && txtPassword.Text != "")
            {
                try
                {
                    komut = "SELECT * FROM db_kullanicilar where kullanici_adi='" + txtKullaniciAdi.Text + "' and password='" + txtPassword.Text + "';";
                    da = new MySqlDataAdapter(komut, connection);
                    myCommand = new MySqlCommand(komut, myConnection);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        Connected = true;
                    }

                    myReader.Close();

                    if (Connected == false)
                    {
                        MessageBoxx frmMessage = new MessageBoxx();
                        frmMessage.txtMessage.Text = "Kullanıcı Adı veya Şifre Hatalı";
                        frmMessage.Show();
                    }
                    else
                    {
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                }
                catch
                {

                }
            }


        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                komut = "SELECT kullanicigirisi_id FROM db_kullanicilar where kullanici_adi='" + txtKullaniciAdi.Text + "';";
                da = new MySqlDataAdapter(komut, connection);
                myCommand = new MySqlCommand(komut, myConnection);
                MySqlDataReader myReader;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    kullanici_id = Convert.ToInt16(myReader.GetString(0));
                }
                myReader.Close();

                if (txtKullaniciAdi.Text != "" && txtPassword.Text == "")
                {
                    komut = "SELECT animsaCheck FROM db_kullanicigirisi where kullanici_id='" + kullanici_id + "';";
                    da = new MySqlDataAdapter(komut, connection);
                    myCommand = new MySqlCommand(komut, myConnection);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        check = Convert.ToInt16(myReader.GetString(0));
                    }
                    myReader.Close();

                    if (check == 1)
                    {
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();

                        MainForm frmMain = new MainForm();
                        frmMain.kullanici_id = kullanici_id;
                        frmMain.animsaCheck = check;
                    }
                    else
                    {
                        MessageBoxx frmMessage = new MessageBoxx();
                        frmMessage.txtMessage.Text = "Lütfen şifre ile giriş yapınız";
                        frmMessage.Show();
                    }
                }
                else if (txtKullaniciAdi.Text == "")
                {
                    MessageBoxx frmMessage = new MessageBoxx();
                    frmMessage.txtMessage.Text = "Lütfen kullanıcı adını giriniz";
                    frmMessage.Show();
                }

                if (txtKullaniciAdi.Text != "" && txtPassword.Text != "")
                {
                    try
                    {
                        komut = "SELECT * FROM db_kullanicilar where kullanici_adi='" + txtKullaniciAdi.Text + "' and password='" + txtPassword.Text + "';";
                        da = new MySqlDataAdapter(komut, connection);
                        myCommand = new MySqlCommand(komut, myConnection);
                        myReader = myCommand.ExecuteReader();
                        while (myReader.Read())
                        {
                            Connected = true;
                        }

                        myReader.Close();

                        if (Connected == false)
                        {
                            MessageBoxx frmMessage = new MessageBoxx();
                            frmMessage.txtMessage.Text = "Kullanıcı Adı veya Şifre Hatalı";
                            frmMessage.Show();
                        }
                        else
                        {
                            DialogResult = System.Windows.Forms.DialogResult.OK;
                            this.Close();
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }
    }
}
