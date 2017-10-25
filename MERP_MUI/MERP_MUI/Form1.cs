using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Drawing;
using System.Threading;

namespace MERP_MUI
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        private DataSet dsDovizKur;

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
        MySqlDataReader myReader;
        DataTable dt = new DataTable();

        int btn1_Flag = 0;
        int btn2_Flag = 0;
        int btn3_Flag = 0;

        public int fatura_id;
        int index = 0;

        public static float[] sumG = new float[2000];
        public static DateTime[] monthG = new DateTime[2000];

        public static float[] sumK = new float[2000];
        public static DateTime[] monthK = new DateTime[2000];

        public static float[] alOdemeler = new float[2000];
        public static DateTime[] monthAlOdemeler = new DateTime[2000];

        public static float[] yapOdemeler = new float[2000];
        public static DateTime[] monthYapOdemeler = new DateTime[2000];

        public static float[] odemeler = new float[7];
        public static DateTime[] monthOdemeler = new DateTime[7];

        public static float[] NewsumG = new float[12];
        public static float[] NewsumK = new float[12];
        public static float[] Newodemeler = new float[12];
        public static float[] NewAlOdemeler = new float[12];
        public static float[] NewYapOdemeler = new float[12];



        public int Connected;

        int elemanSayisiG = 0;
        int elemanSayisiK = 0;

        int elemanSayisiYap = 0;
        int elemanSayisiAl = 0;

        public int kullanici_id;
        public int animsaCheck;
        public static DateTime giris_tarihi;

        DateTime fatura_vade_tarih;
        public int flag = 0;
        int Mailfatura_id;
        string Mailfatura_no;
        int MailVade;
        string MailTip;
        string MailAciklama;
        int Excel_index = 2;
        Boolean PopupTrueG=false;
        Boolean PopupTrueK = false;

        string proje_butce;
        string harcama_toplam;
        string gelenFtr;
        string kesilenFtr;

        DBConnect db;
        SmtpClient sc;

        public MainForm()
        {
            InitializeComponent();
            var pos = this.PointToScreen(lbl_derece.Location);
            pos = pictureBox4.PointToClient(pos);
            lbl_derece.Parent = pictureBox4;
            lbl_derece.Location = pos;
            lbl_derece.BackColor = System.Drawing.Color.Transparent;
            lbl_durum.Parent = pictureBox4;
            lbl_yer.Parent = pictureBox4;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pb_loading.Location = new Point(this.Width / 2, this.Height / 2);
            pb_loading.Visible = true;
            Application.DoEvents();

            giris_tarihi = DateTime.Now;
            lbl_kullanici.Text = Properties.Settings.Default.UserName;

            server = "localhost";
            database = "merp_dbv1";
            uid = "root";
            password = "root";
            //string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            myConnection = new MySqlConnection(connectionString);
            myConnection.Open();

            try
            {
                dsDovizKur = new DataSet();
                dsDovizKur.ReadXml(@"http://www.tcmb.gov.tr/kurlar/today.xml");
                DataRow dr = dsDovizKur.Tables[1].Rows[0];
                lbl_usd.Text = dr[4].ToString().Replace('.', ',');
                dr = dsDovizKur.Tables[1].Rows[3];
                lbl_eur.Text = dr[4].ToString().Replace('.', ',');
                dr = dsDovizKur.Tables[1].Rows[4];
                lbl_gbp.Text = dr[4].ToString().Replace('.', ',');
            }
            catch
            {
                lbl_usd.Text = "Connection Fail!";
                lbl_eur.Text = "Connection Fail!";
                lbl_gbp.Text = "Connection Fail!";
            }

            komut = "SELECT * FROM db_aktivite WHERE akt_oncelik='" + Convert.ToString("COK ACİL") + "' AND akt_statu='" + Convert.ToString("AKTİF") + "'";
            myCommand = new MySqlCommand(komut, myConnection);
            da = new MySqlDataAdapter(myCommand);
            dt = new DataTable();
            // myReader = myCommand.ExecuteReader();

            da.Fill(dt);

            dg_cokacil.DataSource = dt;

            dg_cokacil.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dg_cokacil.AutoSizeColumnsMode =
                       DataGridViewAutoSizeColumnsMode.Fill;

            komut = "SELECT DISTINCT proje_no FROM db_projeler";
            da = new MySqlDataAdapter(komut, connection);
            myCommand = new MySqlCommand(komut, myConnection);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                cmb_proje.Items.Add(myReader["proje_no"]);
                cmb_Barprojeler.Items.Add(myReader["proje_no"]);
            }
            myReader.Close();
            myConnection.Close();

            cmb_yil.Text = "2017";
            cmb_proje.Text = "910.20";

            Mail();
            maliyet_hesapla();
            GetWeather("ISTANBUL");

            pb_loading.Visible = false;
        }

        public void Mail()
        {
            try
            {
                sc = new SmtpClient();
                sc.Port = 587;
                sc.Host = "smtp.gmail.com";
                sc.EnableSsl = true;
                sc.Credentials = new NetworkCredential("altinaymerp@gmail.com", "123456qweasd");

                Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

                if (xlApp == null)
                {
                    MessageBox.Show("Excel is not properly installed!!");
                    return;
                }

                if (File.Exists(Application.StartupPath + @"\" + "MERP" + ".xlsx"))
                {
                    File.Delete(Application.StartupPath + @"\" + "MERP" + ".xlsx");
                }

                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                xlWorkSheet.Cells[1, 1] = "ID";
                xlWorkSheet.Cells[1, 2] = "Fatura No";
                xlWorkSheet.Cells[1, 3] = "Fatura Vade Tarih";
                xlWorkSheet.Cells[1, 4] = "Vade";
                xlWorkSheet.Cells[1, 5] = "Fatura Tipi";
                xlWorkSheet.Cells[1, 6] = "Fatura Açıklama";

                xlWorkSheet.Columns[1].ColumnWidth = 20;
                xlWorkSheet.Columns[2].ColumnWidth = 20;
                xlWorkSheet.Columns[3].ColumnWidth = 20;
                xlWorkSheet.Columns[4].ColumnWidth = 20;
                xlWorkSheet.Columns[6].ColumnWidth = 100;

                komut = "SELECT fatura_id,fatura_no,fatura_vade_tarih,fatura_vade,fatura_tipi,fatura_aciklama  FROM db_faturalar WHERE fatura_tipi='K'";
                da = new MySqlDataAdapter(komut, connection);

                myConnection = new MySqlConnection(connectionString);
                myCommand = new MySqlCommand(komut, myConnection);
                myConnection.Open();
                MySqlDataReader myReader;
                myReader = myCommand.ExecuteReader();
                // Always call Read before accessing data.

                while (myReader.Read())
                {
                    fatura_vade_tarih = Convert.ToDateTime(myReader["fatura_vade_tarih"]);

                    if ((fatura_vade_tarih - DateTime.Now).TotalDays < 5 && (fatura_vade_tarih - DateTime.Now).TotalDays > 0)
                    {
                        Mailfatura_id = Convert.ToInt32(myReader["fatura_id"]);
                        Mailfatura_no = Convert.ToString(myReader["fatura_no"]);
                        MailVade = Convert.ToInt32(myReader["fatura_vade"]);
                        MailTip = Convert.ToString(myReader["fatura_tipi"]);
                        MailAciklama = Convert.ToString(myReader["fatura_aciklama"]);


                        xlWorkSheet.Cells[Excel_index, 1] = Mailfatura_id;
                        xlWorkSheet.Cells[Excel_index, 2] = Mailfatura_no;
                        xlWorkSheet.Cells[Excel_index, 3] = fatura_vade_tarih;
                        xlWorkSheet.Cells[Excel_index, 4] = MailVade;
                        xlWorkSheet.Cells[Excel_index, 5] = MailTip;
                        xlWorkSheet.Cells[Excel_index, 6] = MailAciklama;
                        Excel_index++;
                        PopupTrueK = true;
                    }
                }

                myReader.Close();

                NotificationWindow.PopupNotifier popup = new NotificationWindow.PopupNotifier();

                if (PopupTrueK==true)
                {
                    popup.Image = Properties.Resources.information_alert_attention_sign_help_48;
                    popup.TitleText = "Uyarı";
                    popup.ContentText = "Yaklaşan Vade Tarihi - KESİLEN FATURA -";
                    popup.popupIndex = 1;
                    popup.Popup();
                }


                komut = "SELECT fatura_id,fatura_no,fatura_vade_tarih,fatura_vade,fatura_tipi,fatura_aciklama  FROM db_faturalar WHERE fatura_tipi='G' and fatura_check='1'";
                da = new MySqlDataAdapter(komut, connection);

                myConnection = new MySqlConnection(connectionString);
                myCommand = new MySqlCommand(komut, myConnection);
                myConnection.Open();
                myReader = myCommand.ExecuteReader();
                // Always call Read before accessing data.

                while (myReader.Read())
                {
                    fatura_vade_tarih = Convert.ToDateTime(myReader["fatura_vade_tarih"]);

                    if ((fatura_vade_tarih - DateTime.Now).TotalDays < 5 && (fatura_vade_tarih - DateTime.Now).TotalDays > 0)
                    {
                        Mailfatura_id = Convert.ToInt32(myReader["fatura_id"]);
                        Mailfatura_no = Convert.ToString(myReader["fatura_no"]);
                        MailVade = Convert.ToInt32(myReader["fatura_vade"]);
                        MailTip = Convert.ToString(myReader["fatura_tipi"]);
                        MailAciklama = Convert.ToString(myReader["fatura_aciklama"]);


                        xlWorkSheet.Cells[Excel_index, 1] = Mailfatura_id;
                        xlWorkSheet.Cells[Excel_index, 2] = Mailfatura_no;
                        xlWorkSheet.Cells[Excel_index, 3] = fatura_vade_tarih;
                        xlWorkSheet.Cells[Excel_index, 4] = MailVade;
                        xlWorkSheet.Cells[Excel_index, 5] = MailTip;
                        xlWorkSheet.Cells[Excel_index, 6] = MailAciklama;
                        Excel_index++;
                        PopupTrueG = true;
                    }
                }

                myReader.Close();

                if(PopupTrueG==true)
                {
                    popup.Image = Properties.Resources.information_alert_attention_sign_help_48;
                    popup.TitleText = "Uyarı";
                    popup.ContentText = "Yaklaşan Vade Tarihi - GELEN FATURA -";
                    popup.popupIndex = 3;
                    //popup.popupIndex++;
                    popup.Popup();
                }


                xlWorkBook.SaveAs(Application.StartupPath + @"\" + "MERP", Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, false, misValue, Excel.XlSaveAsAccessMode.xlNoChange);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                //MessageBox.Show("Excel file created , you can find the file d:\\csharp-Excel.xls");


                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("altinaymerp@gmail.com", "ALTINAY UYARI SİSTEMİ");
                mail.To.Add("halime.urek@altinay.com");
                mail.Subject = "FATURA UYARISI";
                mail.IsBodyHtml = true;
                mail.Body = "Fatura vade tarihi 5 günden az olan faturalar ekteki excel dosyasındadır.";

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(Application.StartupPath + @"\" + "MERP" + ".xlsx");
                mail.Attachments.Add(attachment);
                //sc.Send(mail);

               
            }
            catch { }

            myConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (btn1_Flag == 0)
            {
                maliyet_hesapla();
                splitContainer12.Visible = false;
                pnlDGW.Dock = DockStyle.Fill;
                pnlDGW.Visible = true;

                btn1_Flag = 1;
            }
            else
            {
                pnlDGW.Visible = false;
                splitContainer12.Visible = true;
                btn1_Flag = 0;
            }

            if (pnlAcil.Visible == true)
            {
                pnlAcil.Visible = false;
                btn2_Flag = 0;
            }
            if (pnlFilter.Visible == true)
            {
                pnlFilter.Visible = false;
                btn3_Flag = 0;
            }
        }

        public void maliyet_hesapla()
        {
            myConnection.Open();

            int a = dg_maliyet.RowCount;

            komut = "select fatura_proje_no as PROJE_NO, sum(case when fatura_birim = 'TRY' then fatura_tutari else 0 end) as TRY, " +
                   "sum(case when fatura_birim = 'EUR' then fatura_tutari else 0 end) as EUR ," +
                   "sum(case when fatura_birim = 'USD' then fatura_tutari else 0 end) as USD , " +
                   "sum(case when fatura_birim = 'GBP' then fatura_tutari else 0 end) as GBP , " +
                   "sum(fatura_euro) as Toplam_Euro " +
                   "from db_faturalar where fatura_tipi = 'G' group by fatura_proje_no";

            myCommand = new MySqlCommand(komut, myConnection);
            da = new MySqlDataAdapter(myCommand);
            dt = new DataTable();
            da.Fill(dt);
            dg_maliyet.DataSource = dt;
            dg_maliyet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dg_maliyet.AutoSizeColumnsMode =
                       DataGridViewAutoSizeColumnsMode.Fill;

            dg_maliyet.Columns[1].DefaultCellStyle.Format = "c2";
            dg_maliyet.Columns[2].DefaultCellStyle.Format = "c2";
            dg_maliyet.Columns[2].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("de-DE");
            dg_maliyet.Columns[3].DefaultCellStyle.Format = "c2";
            dg_maliyet.Columns[3].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
            dg_maliyet.Columns[4].DefaultCellStyle.Format = "c2";
            dg_maliyet.Columns[4].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-GB");
            dg_maliyet.Columns[5].DefaultCellStyle.Format = "c2";
            dg_maliyet.Columns[5].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("de-DE");

            komut = "select fatura_proje_no as PROJE_NO, sum(case when fatura_birim = 'TRY' then fatura_tutari else 0 end) as TRY, " +
                  "sum(case when fatura_birim = 'EUR' then fatura_tutari else 0 end) as EUR ," +
                  "sum(case when fatura_birim = 'USD' then fatura_tutari else 0 end) as USD , " +
                  "sum(case when fatura_birim = 'GBP' then fatura_tutari else 0 end) as GBP , " +
                  "sum(fatura_euro) as Toplam_Euro " +
                  "from db_faturalar where fatura_tipi = 'K' group by fatura_proje_no";

            myCommand = new MySqlCommand(komut, myConnection);
            da = new MySqlDataAdapter(myCommand);
            dt = new DataTable();
            da.Fill(dt);
            dgw_faturalar.DataSource = dt;
            dgw_faturalar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgw_faturalar.AutoSizeColumnsMode =
                       DataGridViewAutoSizeColumnsMode.Fill;
            dgw_faturalar.Columns[1].DefaultCellStyle.Format = "c2";
            dgw_faturalar.Columns[2].DefaultCellStyle.Format = "c2";
            dgw_faturalar.Columns[2].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("de-DE");
            dgw_faturalar.Columns[3].DefaultCellStyle.Format = "c2";
            dgw_faturalar.Columns[3].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
            dgw_faturalar.Columns[4].DefaultCellStyle.Format = "c2";
            dgw_faturalar.Columns[4].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-GB");
            dgw_faturalar.Columns[5].DefaultCellStyle.Format = "c2";
            dgw_faturalar.Columns[5].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("de-DE");
            myConnection.Close();
        }

        public void ChartControl()
        {
            Array.Clear(monthG, 0, 2000);
            Array.Clear(sumG, 0, 2000);
            Array.Clear(monthK, 0, 2000);
            Array.Clear(sumK, 0, 2000);
            Array.Clear(odemeler, 0, 7);
            Array.Clear(monthOdemeler, 0, 7);
            Array.Clear(NewsumG, 0, 12);
            Array.Clear(NewsumK, 0, 12);
            Array.Clear(Newodemeler, 0, 12);

            Array.Clear(NewAlOdemeler, 0, 12);
            Array.Clear(NewYapOdemeler, 0, 12);
            Array.Clear(alOdemeler, 0, 2000);
            Array.Clear(yapOdemeler, 0, 2000);
            Array.Clear(monthAlOdemeler, 0, 2000);
            Array.Clear(monthYapOdemeler, 0, 2000);

            index = 0;
            elemanSayisiG = 0;
            elemanSayisiK = 0;
            elemanSayisiYap = 0;
            elemanSayisiAl = 0;

            myConnection.Open();
            try
            {
                komut = "SELECT fatura_tarih AS Month, fatura_euro AS EURO FROM db_faturalar WHERE fatura_tipi='G' and fatura_proje_no ='" + cmb_proje.Text + "'";
                da = new MySqlDataAdapter(komut, connection);
                myCommand = new MySqlCommand(komut, myConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    monthG[index] = Convert.ToDateTime(myReader.GetString(0));
                    sumG[index] = (float)Convert.ToDouble(myReader.GetString(1));
                    index++;
                    elemanSayisiG++;
                }
                myReader.Close();
            }
            catch
            {
                myReader.Close();
            }

            try
            {
                index = 0;
                komut = "SELECT fatura_tarih AS Month, fatura_euro AS EURO FROM db_faturalar WHERE fatura_tipi='K' and fatura_proje_no ='" + cmb_proje.Text + "'";
                da = new MySqlDataAdapter(komut, connection);
                myCommand = new MySqlCommand(komut, myConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    monthK[index] = Convert.ToDateTime(myReader.GetString(0));
                    sumK[index] = (float)Convert.ToDouble(myReader.GetString(1));
                    index++;
                    elemanSayisiK++;
                }
                myReader.Close();
            }
            catch
            {
                myReader.Close();
            }

            try
            {
                index = 0;
                komut = "SELECT fatura_tarih AS Month, fatura_euro AS EURO FROM db_faturalar WHERE fatura_tipi='G' and fatura_proje_no ='" + cmb_proje.Text + "' and fatura_durum='ODENMEDI'";
                da = new MySqlDataAdapter(komut, connection);
                myCommand = new MySqlCommand(komut, myConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    monthYapOdemeler[index] = Convert.ToDateTime(myReader.GetString(0));
                    yapOdemeler[index] = (float)Convert.ToDouble(myReader.GetString(1));
                    index++;
                    elemanSayisiYap++;
                }
                myReader.Close();
            }
            catch
            {
                myReader.Close();
            }

            try
            {
                index = 0;
                komut = "SELECT fatura_tarih AS Month, fatura_euro AS EURO FROM db_faturalar WHERE fatura_tipi='K' and fatura_proje_no ='" + cmb_proje.Text + "' and fatura_durum='ODENMEDI'";
                da = new MySqlDataAdapter(komut, connection);
                myCommand = new MySqlCommand(komut, myConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    monthAlOdemeler[index] = Convert.ToDateTime(myReader.GetString(0));
                    alOdemeler[index] = (float)Convert.ToDouble(myReader.GetString(1));
                    index++;
                    elemanSayisiAl++;
                }
                myReader.Close();
            }
            catch
            {
                myReader.Close();
            }

            try
            {
                komut = "SELECT * FROM db_projeler WHERE proje_no='" + cmb_proje.Text + "'";
                da = new MySqlDataAdapter(komut, connection);

                myCommand = new MySqlCommand(komut, myConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    odemeler[0] = (float)Convert.ToDouble(myReader.GetString(17));
                    monthOdemeler[0] = Convert.ToDateTime(myReader.GetString(18));
                    odemeler[1] = (float)Convert.ToDouble(myReader.GetString(19));
                    monthOdemeler[1] = Convert.ToDateTime(myReader.GetString(20));
                    odemeler[2] = (float)Convert.ToDouble(myReader.GetString(21));
                    monthOdemeler[2] = Convert.ToDateTime(myReader.GetString(22));
                    odemeler[3] = (float)Convert.ToDouble(myReader.GetString(23));
                    monthOdemeler[3] = Convert.ToDateTime(myReader.GetString(24));
                    odemeler[4] = (float)Convert.ToDouble(myReader.GetString(25));
                    monthOdemeler[4] = Convert.ToDateTime(myReader.GetString(26));
                    odemeler[5] = (float)Convert.ToDouble(myReader.GetString(27));
                    monthOdemeler[5] = Convert.ToDateTime(myReader.GetString(28));
                    odemeler[6] = (float)Convert.ToDouble(myReader.GetString(29));
                    monthOdemeler[6] = Convert.ToDateTime(myReader.GetString(30));
                }


                myReader.Close();

           /*
            * Bubble Sort
            */
                UInt32 row = 0, column = 0;
                DateTime tempDate = new DateTime();
                float tempBill = 0;
                for (row = 0; row < elemanSayisiG; row++)
                    for (column = 0; column < elemanSayisiG - 1; column++)
                    {
                        if (Int32.Parse(monthG[column].ToString("yyyyMMdd")) > Int32.Parse(monthG[column + 1].ToString("yyyyMMdd")))
                        {
                            tempDate = monthG[column];
                            tempBill = sumG[column];

                            monthG[column] = monthG[column + 1];
                            monthG[column + 1] = tempDate;

                            sumG[column] = sumG[column + 1];
                            sumG[column + 1] = tempBill;
                        }
                    }
                tempBill = 0;
                for (row = 0; row < elemanSayisiK; row++)
                    for (column = 0; column < elemanSayisiK - 1; column++)
                    {
                        if (Int32.Parse(monthK[column].ToString("yyyyMMdd")) > Int32.Parse(monthK[column + 1].ToString("yyyyMMdd")))
                        {
                            tempDate = monthK[column];
                            tempBill = sumK[column];

                            monthK[column] = monthK[column + 1];
                            monthK[column + 1] = tempDate;

                            sumK[column] = sumK[column + 1];
                            sumK[column + 1] = tempBill;
                        }
                    }



                 tempDate = new DateTime();
                 tempBill = 0;

                for (row = 0; row < odemeler.Length; row++)
                    for (column = 0; column < odemeler.Length - 1; column++)
                    {
                        if (Int32.Parse(monthOdemeler[column].ToString("yyyyMMdd")) > Int32.Parse(monthOdemeler[column + 1].ToString("yyyyMMdd")))
                        {
                            tempDate = monthOdemeler[column];
                            tempBill = odemeler[column];

                            monthOdemeler[column] = monthOdemeler[column + 1];
                            monthOdemeler[column + 1] = tempDate;

                            odemeler[column] = odemeler[column + 1];
                            odemeler[column + 1] = tempBill;
                        }
                    }
            }
            catch
            {
                myReader.Close();
            }

            Int32 month;
            for (month = 0; month < elemanSayisiG; month++)
            {
                if (Int32.Parse(monthG[month].ToString("yyyy")) == Int32.Parse(cmb_yil.Text))
                    NewsumG[Int32.Parse(monthG[month].ToString("MM")) - 1] += sumG[month];
            }

            for (month = 0; month < elemanSayisiK; month++)
            {
                if (Int32.Parse(monthK[month].ToString("yyyy")) == Convert.ToInt32(cmb_yil.Text))
                    NewsumK[Int32.Parse(monthK[month].ToString("MM")) - 1] += sumK[month];
            }

            for (month = 0; month < odemeler.Length; month++)
            {
                if (Int32.Parse(monthOdemeler[month].ToString("yyyy")) == Convert.ToInt32(cmb_yil.Text))
                    Newodemeler[Int32.Parse(monthOdemeler[month].ToString("MM")) - 1] += odemeler[month];
            }

            for (month = 0; month < elemanSayisiYap; month++)
            {
                if (Int32.Parse(monthYapOdemeler[month].ToString("yyyy")) == Convert.ToInt32(cmb_yil.Text))
                    NewYapOdemeler[Int32.Parse(monthYapOdemeler[month].ToString("MM")) - 1] += yapOdemeler[month];
            }

            for (month = 0; month < elemanSayisiAl; month++)
            {
                if (Int32.Parse(monthAlOdemeler[month].ToString("yyyy")) == Convert.ToInt32(cmb_yil.Text))
                    NewAlOdemeler[Int32.Parse(monthAlOdemeler[month].ToString("MM")) - 1] += alOdemeler[month];
            }

            myConnection.Close();

            chart1.Series["Gelen Faturalar"].Points.Clear();
            chart1.Series["Kesilen Faturalar"].Points.Clear();
            chart1.Series["Öngörülen Ödemeler"].Points.Clear();
            chart1.Series["Alınan Ödemeler"].Points.Clear();
            chart1.Series["Yapılan Ödemeler"].Points.Clear();



            for (int Month = 0; Month < 12 ; Month++)
            {
                if(NewsumG[Month] == 0)
                {
                    chart1.Series["Gelen Faturalar"].Points.AddXY(Convert.ToString((Month + 1) + ". ay"), NewsumG[Month]);
                }
                else
                {
                    chart1.Series["Gelen Faturalar"].Points.AddXY(Convert.ToString((Month + 1) + ". ay"), NewsumG[Month]);
                    chart1.Series["Gelen Faturalar"].Points[Month].Label = string.Format(new CultureInfo("de-DE"), "{0:C2}", Convert.ToDecimal(NewsumG[Month]));
                }

               
            }
            for (int Month = 0; Month < 12; Month++)
            {
                if(NewsumK[Month] == 0)
                {
                    chart1.Series["Kesilen Faturalar"].Points.AddXY(Convert.ToString((Month + 1) + ". ay"), NewsumK[Month]);
                }
                else
                {
                    chart1.Series["Kesilen Faturalar"].Points.AddXY(Convert.ToString((Month + 1) + ". ay"), NewsumK[Month]);
                    chart1.Series["Kesilen Faturalar"].Points[Month].Label = string.Format(new CultureInfo("de-DE"), "{0:C2}", Convert.ToDecimal(NewsumK[Month]));
                }

                
            }
            for (int Month = 0; Month < 12; Month++)
            {
                if(Newodemeler[Month] == 0)
                {
                    chart1.Series["Öngörülen Ödemeler"].Points.AddXY(Convert.ToString((Month + 1) + ". ay"), Newodemeler[Month]);
                }
                else
                {
                    chart1.Series["Öngörülen Ödemeler"].Points.AddXY(Convert.ToString((Month + 1) + ". ay"), Newodemeler[Month]);
                    chart1.Series["Öngörülen Ödemeler"].Points[Month].Label = string.Format(new CultureInfo("de-DE"), "{0:C2}", Convert.ToDecimal(Newodemeler[Month]));
                }

                
            }
            for (int Month = 0; Month < 12; Month++)
            {
                if (NewYapOdemeler[Month] == 0)
                {
                    chart1.Series["Yapılan Ödemeler"].Points.AddXY(Convert.ToString((Month + 1) + ". ay"), NewYapOdemeler[Month]);
                }
                else
                {
                    chart1.Series["Yapılan Ödemeler"].Points.AddXY(Convert.ToString((Month + 1) + ". ay"), NewYapOdemeler[Month]);
                    chart1.Series["Yapılan Ödemeler"].Points[Month].Label = string.Format(new CultureInfo("de-DE"), "{0:C2}", Convert.ToDecimal(NewYapOdemeler[Month]));
                }

                
            }
            for (int Month = 0; Month < 12; Month++)
            {
                if(NewAlOdemeler[Month] == 0)
                {
                    chart1.Series["Alınan Ödemeler"].Points.AddXY(Convert.ToString((Month + 1) + ". ay"), NewAlOdemeler[Month]);
                }
                else
                {
                    chart1.Series["Alınan Ödemeler"].Points.AddXY(Convert.ToString((Month + 1) + ". ay"), NewAlOdemeler[Month]);
                    chart1.Series["Alınan Ödemeler"].Points[Month].Label = string.Format(new CultureInfo("de-DE"), "{0:C2}", Convert.ToDecimal(NewAlOdemeler[Month]));
                }
            }
        }

        private void btnAktivite_Click(object sender, EventArgs e)
        {
            if(btn2_Flag==0)
            {
                splitContainer12.Visible = false;
                pnlAcil.Dock = DockStyle.Fill;
                pnlAcil.Visible = true;
                btn2_Flag = 1;
            }
            else
            {
                splitContainer12.Visible = true;
                pnlAcil.Visible = false;
                btn2_Flag = 0;
            }
            if (pnlDGW.Visible == true)
            {
                pnlDGW.Visible = false;
                btn1_Flag = 0;
            }
            if(pnlFilter.Visible==true)
            {
                pnlFilter.Visible = false;
                btn3_Flag = 0;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (btn3_Flag == 0)
            {
                splitContainer12.Visible = false;
                pnlFilter.Dock = DockStyle.Fill;
                pnlFilter.Visible = true;
                gb_filter.Visible = true;
                btn3_Flag = 1;
            }
            else
            {
                splitContainer12.Visible = true;
                pnlFilter.Visible = false;
                gb_filter.Visible = false;
                btn3_Flag = 0;
            }
            if (pnlAcil.Visible == true)
            {
                pnlAcil.Visible = false;
                btn2_Flag = 0;
            }
            if (pnlDGW.Visible == true)
            {
                pnlDGW.Visible = false;
                btn1_Flag = 0;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AktiviteGiris frmAktiviteGiris = new AktiviteGiris();
            frmAktiviteGiris.Show();
        }

        private void gELENFATURAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FaturaGiris frmFaturaGiris = new FaturaGiris();
            frmFaturaGiris.Show();
        }

        private void yENİPROJEGİRİŞİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjeGiris frmProjeGiris = new ProjeGiris();
            frmProjeGiris.Show();
        }

        private void acilNormalİşlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Acil_NormalIsler frmAcil_NormalIsler = new Acil_NormalIsler();
            frmAcil_NormalIsler.Show();
        }

        private void diğerİşlerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DigerIsler frmDigerIsler = new DigerIsler();
            frmDigerIsler.Show();
        }

        private void yENİSİPARİŞEMRİOLUŞTURToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SiparisEmriGiris frmSiparisEmriGiris = new SiparisEmriGiris();
            frmSiparisEmriGiris.Show();
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hakkinda frmHakkinda = new Hakkinda();
            frmHakkinda.Show();
        }

        private void dg_cokacil_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            AktiviteDuzenle ag = new AktiviteDuzenle();
            ag.Show();


            fatura_id = Convert.ToInt32(dg_cokacil.Rows[e.RowIndex].Cells[0].Value.ToString());
            AktiviteDuzenle f1 = (AktiviteDuzenle)Application.OpenForms["AktiviteDuzenle"];
            ComboBox no = (ComboBox)f1.Controls["cmb_prj_no"];
            ComboBox oncelik = (ComboBox)f1.Controls["cmb_oncelik"];
            ComboBox statu = (ComboBox)f1.Controls["cmb_statu"];
            RichTextBox acıklama = (RichTextBox)f1.Controls["rcb_acıklama"];
            ComboBox rapor = (ComboBox)f1.Controls["cmb_rapor_edilecek"];
            DateTimePicker olusturma = (DateTimePicker)f1.Controls["date_olusturma"];
            DateTimePicker bitis = (DateTimePicker)f1.Controls["date_bitis"];
            Label id = (Label)f1.Controls["lbl_id"];
            id.Text = dg_cokacil.Rows[e.RowIndex].Cells[0].Value.ToString();
            no.Text = dg_cokacil.Rows[e.RowIndex].Cells[1].Value.ToString();
            oncelik.Text = dg_cokacil.Rows[e.RowIndex].Cells[2].Value.ToString();
            statu.Text = dg_cokacil.Rows[e.RowIndex].Cells[3].Value.ToString();
            acıklama.Text = dg_cokacil.Rows[e.RowIndex].Cells[4].Value.ToString();
            rapor.Text = dg_cokacil.Rows[e.RowIndex].Cells[5].Value.ToString();
            olusturma.Text = dg_cokacil.Rows[e.RowIndex].Cells[6].Value.ToString();
            bitis.Text = dg_cokacil.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void cmb_proje_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChartControl();
        }

        private void pROJEYEGÖRERAPORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjeyeGoreRapor frmProjeyeGoreRapor = new ProjeyeGoreRapor();
            frmProjeyeGoreRapor.Show();
        }

        private void lİSTELEToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SiparisEmirleri frmSiparisEmirleri = new SiparisEmirleri();
            frmSiparisEmirleri.Show();
        }

        private void lİSTELEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Projeler frmProjeler = new Projeler();
            frmProjeler.Show();
        }

        private void cmb_yil_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChartControl();
        }

        private void lİSTELEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Faturalar frmFaturalar = new Faturalar();
            frmFaturalar.Show();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            myConnection.Open();
            komut = "SELECT kullanicigirisi_id FROM db_kullanicilar where kullanici_adi='" + lbl_kullanici.Text + "';";
            da = new MySqlDataAdapter(komut, connection);
            myCommand = new MySqlCommand(komut, myConnection);
            MySqlDataReader myReader;
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                kullanici_id = Convert.ToInt16(myReader.GetString(0));
            }
            myReader.Close();

            db = new DBConnect();
            db.InsertKullanicilar(kullanici_id, giris_tarihi, DateTime.Now, Properties.Settings.Default.Check);

            this.Close();
        }

        public void GetWeather(string sehir)
        {
            const string api = "bafa10c3a0987fafa61257b03821b835";
            string baglanti = "http://api.openweathermap.org/data/2.5/weather?q=Turkey," + sehir + "&mode=xml&units=metric&APPID=" + api;

            XDocument hava = XDocument.Load(baglanti);
            var sicaklik = hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            lbl_derece.Text = sicaklik.ToString()+ "°";

            var durum = hava.Descendants("clouds").ElementAt(0).Attribute("name").Value;
            lbl_durum.Text = durum.ToString();

            if(durum.Contains("clear sky") == true)
            {
                pictureBox4.Image = Properties.Resources.clear_sky;
            }
            else if(durum.Contains("few clouds") == true)
            {
                pictureBox4.Image = Properties.Resources.few_clouds;
            }
            else if(durum.Contains("broken clouds") == true || durum.Contains("scattered clouds") == true)
            {
                pictureBox4.Image = Properties.Resources.broken_clouds;
            }
            else if(durum.Contains("shower rain") == true || durum.Contains("rain") == true || durum.Contains("thunderstorm") == true)
            {
                pictureBox4.Image = Properties.Resources.rain;
            }
            else
            {
                pictureBox4.Image = Properties.Resources.snow;
            }


            //var yer = hava.Descendants("city").ElementAt(0).Attribute("name").Value;
            //lbl_yer.Text = yer.ToString();
            lbl_yer.Text = sehir;
        }

        private void cmb_sehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetWeather(cmb_sehir.Text);
        }

        private void cmb_Barprojeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            myConnection.Open();
            komut = "SELECT proje_baslangic,proje_bitis,proje_butce,harcama_toplam FROM db_projeler where proje_no='" + cmb_Barprojeler.Text + "'";
            da = new MySqlDataAdapter(komut, connection);
            myCommand = new MySqlCommand(komut, myConnection);
            MySqlDataReader myReader;
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                var start = Convert.ToDateTime(myReader.GetString(0));
                var end = Convert.ToDateTime(myReader.GetString(1));
                proje_butce = myReader.GetString(2);
                harcama_toplam = myReader.GetString(3);
                var total = (end - start).TotalSeconds;
                mpb_zaman.Value = Convert.ToInt32(Math.Truncate((DateTime.Now - start).TotalSeconds * 100 / total));
            }
            myReader.Close();

            komut = "SELECT sum(fatura_euro) FROM db_faturalar where fatura_tipi='G' and fatura_proje_no='"+cmb_Barprojeler.Text+"'";
            da = new MySqlDataAdapter(komut, connection);
            myCommand = new MySqlCommand(komut, myConnection);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                gelenFtr = myReader.GetString(0);
            }
            myReader.Close();

            komut = "SELECT sum(fatura_euro) FROM db_faturalar where fatura_tipi='K' and fatura_proje_no='" + cmb_Barprojeler.Text + "'";
            da = new MySqlDataAdapter(komut, connection);
            myCommand = new MySqlCommand(komut, myConnection);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                kesilenFtr = myReader.GetString(0);
            }
            myReader.Close();

           // MessageBox.Show(Convert.ToString(Convert.ToInt32(Convert.ToDouble(gelenFtr))));
            mpb_butce.Value = Convert.ToInt32(((100) * (Convert.ToInt32(gelenFtr)) / (Convert.ToInt32(harcama_toplam))));
            mpb_kesilenFtr.Value = Convert.ToInt32(((100 - 0) * (Convert.ToInt32(kesilenFtr) - 0) / (Convert.ToInt32(proje_butce) - 0)) + 0);
            myConnection.Close();
        }
    }
}
