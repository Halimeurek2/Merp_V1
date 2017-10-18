using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace MERP_MUI
{
    public partial class FirmaRapor : MetroFramework.Forms.MetroForm
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        string komut;
        MySqlCommand myCommand;
        MySqlDataAdapter da;
        MySqlConnection myConnection;
        MySqlDataReader myReader;
        DataTable dt = new DataTable();

        int index = 0;

        public FirmaRapor()
        {
            InitializeComponent();
        }

        private void FirmaRapor_Load(object sender, EventArgs e)
        {
            server = "localhost";
            database = "uretimplanlama_2";
            uid = "root";
            password = "root";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            myConnection = new MySqlConnection(connectionString);
            myConnection.Open();

            komut = "SELECT fatura_firma,sum(fatura_euro) from db_faturalar where fatura_cinsi='Elektronik' and fatura_tipi='G' and fatura_proje_no='"+lbl_prjNo.Text+"' group by fatura_firma order by sum(fatura_euro) DESC";
            da = new MySqlDataAdapter(komut, connection);

            myCommand = new MySqlCommand(komut, myConnection);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                if(myReader.GetString(0)!="MASRAF")
                {
                    dgw_elektronik.Rows.Add();
                    dgw_elektronik.Rows[index].Cells[0].Value = myReader.GetString(0);
                    dgw_elektronik.Rows[index].Cells[2].Value = myReader.GetString(1);
                    index++;
                }
            }
            myReader.Close();

            index = 0;
            komut = "SELECT fatura_firma,sum(fatura_euro) from db_faturalar where fatura_cinsi='Mekanik' and fatura_tipi='G' and fatura_proje_no='" + lbl_prjNo.Text + "' group by fatura_firma order by sum(fatura_euro) DESC";
            da = new MySqlDataAdapter(komut, connection);

            myCommand = new MySqlCommand(komut, myConnection);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                if (myReader.GetString(0) != "MASRAF")
                {
                    dgw_mekanik.Rows.Add();
                    dgw_mekanik.Rows[index].Cells[0].Value = myReader.GetString(0);
                    dgw_mekanik.Rows[index].Cells[2].Value = myReader.GetString(1);
                    index++;
                }
            }
            myReader.Close();

            index = 0;
            komut = "SELECT fatura_firma,sum(fatura_euro) from db_faturalar where fatura_cinsi='Genel Giderler' and fatura_tipi='G' and fatura_proje_no='" + lbl_prjNo.Text + "' group by fatura_firma order by sum(fatura_euro) DESC";
            da = new MySqlDataAdapter(komut, connection);

            myCommand = new MySqlCommand(komut, myConnection);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                if (myReader.GetString(0) != "MASRAF")
                {
                    dgw_genel.Rows.Add();
                    dgw_genel.Rows[index].Cells[0].Value = myReader.GetString(0);
                    dgw_genel.Rows[index].Cells[2].Value = myReader.GetString(1);
                    index++;
                }
            }
            myReader.Close();

            SiparisToplam();
            OdenenFaturalar();
            Kalan();
        }
        public void SiparisToplam()
        {
            for(int i=0;i<dgw_genel.Rows.Count;i++)
            {
                try
                {
                    komut = "SELECT sum(siparis_euro) FROM db_siparis_emri where tedarikci='" + dgw_genel.Rows[i].Cells[0].Value + "';";
                    da = new MySqlDataAdapter(komut, connection);

                    myCommand = new MySqlCommand(komut, myConnection);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        dgw_genel.Rows[i].Cells[1].Value = string.Format(new CultureInfo("de-DE"), "{0:C2}", Convert.ToDecimal(myReader.GetString(0)));
                    }
                    myReader.Close();
                }
                catch
                {
                    dgw_genel.Rows[i].Cells[1].Value = 0;
                    myReader.Close();
                }
            }

            for (int i = 0; i < dgw_elektronik.Rows.Count; i++)
            {
                try
                {
                    komut = "SELECT sum(siparis_euro) FROM db_siparis_emri where tedarikci='" + dgw_elektronik.Rows[i].Cells[0].Value + "';";
                    da = new MySqlDataAdapter(komut, connection);

                    myCommand = new MySqlCommand(komut, myConnection);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        dgw_elektronik.Rows[i].Cells[1].Value = string.Format(new CultureInfo("de-DE"), "{0:C2}", Convert.ToDecimal(myReader.GetString(0)));
                    }
                    myReader.Close();
                }
                catch
                {
                    dgw_elektronik.Rows[i].Cells[1].Value = 0;
                    myReader.Close();
                }
            }

            for (int i = 0; i < dgw_mekanik.Rows.Count; i++)
            {
                try
                {
                    komut = "SELECT sum(siparis_euro) FROM db_siparis_emri where tedarikci='" + dgw_mekanik.Rows[i].Cells[0].Value + "';";
                    da = new MySqlDataAdapter(komut, connection);

                    myCommand = new MySqlCommand(komut, myConnection);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        dgw_mekanik.Rows[i].Cells[1].Value = string.Format(new CultureInfo("de-DE"), "{0:C2}", Convert.ToDecimal(myReader.GetString(0)));
                    }
                    myReader.Close();
                }
                catch
                {
                    dgw_mekanik.Rows[i].Cells[1].Value = 0;
                    myReader.Close();
                }
            }
        }

        public void OdenenFaturalar()
        {
            for (int i = 0; i < dgw_genel.Rows.Count; i++)
            {
                try
                {
                    komut = "SELECT sum(fatura_euro) from db_faturalar where fatura_cinsi='Genel Giderler' and fatura_proje_no='" + lbl_prjNo.Text + "' and fatura_firma='" + dgw_genel.Rows[i].Cells[0].Value + "' and fatura_durum='ODENDI' and fatura_tipi='G'";
                    da = new MySqlDataAdapter(komut, connection);

                    myCommand = new MySqlCommand(komut, myConnection);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        dgw_genel.Rows[i].Cells[3].Value = myReader.GetString(0);
                    }
                    myReader.Close();
                }
                catch
                {
                    dgw_genel.Rows[i].Cells[3].Value = 0;
                    myReader.Close();
                }
            }

            for (int i = 0; i < dgw_elektronik.Rows.Count; i++)
            {
                try
                {
                    komut = "SELECT sum(fatura_euro) from db_faturalar where fatura_cinsi='Elektronik' and fatura_proje_no='" + lbl_prjNo.Text + "' and fatura_firma='" + dgw_elektronik.Rows[i].Cells[0].Value + "' and fatura_durum='ODENDI' and fatura_tipi='G'";
                    da = new MySqlDataAdapter(komut, connection);

                    myCommand = new MySqlCommand(komut, myConnection);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        dgw_elektronik.Rows[i].Cells[3].Value = myReader.GetString(0);
                    }
                    myReader.Close();
                }
                catch
                {
                    dgw_elektronik.Rows[i].Cells[3].Value = 0;
                    myReader.Close();
                }
            }

            for (int i = 0; i < dgw_mekanik.Rows.Count; i++)
            {
                try
                {
                    komut = "SELECT sum(fatura_euro) from db_faturalar where fatura_cinsi='Mekanik' and fatura_proje_no='"+lbl_prjNo.Text+"' and fatura_firma='"+ dgw_mekanik.Rows[i].Cells[0].Value + "' and fatura_durum='ODENDI' and fatura_tipi='G'";
                    da = new MySqlDataAdapter(komut, connection);

                    myCommand = new MySqlCommand(komut, myConnection);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        dgw_mekanik.Rows[i].Cells[3].Value = myReader.GetString(0);
                    }
                    myReader.Close();
                }
                catch
                {
                    dgw_mekanik.Rows[i].Cells[3].Value = 0;
                    myReader.Close();
                }
            }
        }

        public void Kalan()
        {
            for (int k = 0; k < dgw_elektronik.Rows.Count; k++)
            {
                dgw_elektronik.Rows[k].Cells[4].Value = string.Format(new CultureInfo("de-DE"), "{0:C2}", (Convert.ToDecimal(dgw_elektronik.Rows[k].Cells[2].Value) - Convert.ToDecimal(dgw_elektronik.Rows[k].Cells[3].Value)));
                dgw_elektronik.Rows[k].Cells[2].Value = string.Format(new CultureInfo("de-DE"), "{0:C2}", Convert.ToDecimal(dgw_elektronik.Rows[k].Cells[2].Value));
                dgw_elektronik.Rows[k].Cells[3].Value = string.Format(new CultureInfo("de-DE"), "{0:C2}", Convert.ToDecimal(dgw_elektronik.Rows[k].Cells[3].Value));
            }
            for (int k = 0; k < dgw_mekanik.Rows.Count; k++)
            {
                dgw_mekanik.Rows[k].Cells[4].Value = string.Format(new CultureInfo("de-DE"), "{0:C2}", (Convert.ToDecimal(dgw_mekanik.Rows[k].Cells[2].Value) - Convert.ToDecimal(dgw_mekanik.Rows[k].Cells[3].Value)));
                dgw_mekanik.Rows[k].Cells[2].Value = string.Format(new CultureInfo("de-DE"), "{0:C2}", Convert.ToDecimal(dgw_mekanik.Rows[k].Cells[2].Value));
                dgw_mekanik.Rows[k].Cells[3].Value = string.Format(new CultureInfo("de-DE"), "{0:C2}", Convert.ToDecimal(dgw_mekanik.Rows[k].Cells[3].Value));
            }
            for (int k = 0; k < dgw_genel.Rows.Count; k++)
            {
                dgw_genel.Rows[k].Cells[4].Value = string.Format(new CultureInfo("de-DE"), "{0:C2}", (Convert.ToDecimal(dgw_genel.Rows[k].Cells[2].Value) - Convert.ToDecimal(dgw_genel.Rows[k].Cells[3].Value)));
                dgw_genel.Rows[k].Cells[2].Value = string.Format(new CultureInfo("de-DE"), "{0:C2}", Convert.ToDecimal(dgw_genel.Rows[k].Cells[2].Value));
                dgw_genel.Rows[k].Cells[3].Value = string.Format(new CultureInfo("de-DE"), "{0:C2}", Convert.ToDecimal(dgw_genel.Rows[k].Cells[3].Value));
            }
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
