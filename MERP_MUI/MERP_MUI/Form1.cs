using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public static float[] odemeler = new float[7];
        public static DateTime[] monthOdemeler = new DateTime[7];

        public static float[] NewsumG = new float[12];
        public static float[] NewsumK = new float[12];
        public static float[] Newodemeler = new float[12];

        public int Connected;

        int elemanSayisiG = 0;
        int elemanSayisiK = 0;

        public int kullanici_id;
        public int animsaCheck;
        public static DateTime giris_tarihi;

        DBConnect db;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            giris_tarihi = DateTime.Now;
            lbl_kullanici.Text = Properties.Settings.Default.UserName;

            server = "localhost";
            database = "uretimplanlama_2";
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
            MySqlDataReader myReader;
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                cmb_proje.Items.Add(myReader["proje_no"]);
            }
            myReader.Close();
            myConnection.Close();

            cmb_yil.Text = "2017";

            maliyet_hesapla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (btn1_Flag == 0)
            {
                maliyet_hesapla();
                pnlDGW.Dock = DockStyle.Fill;
                pnlDGW.Visible = true;

                btn1_Flag = 1;
            }
            else
            {
                pnlDGW.Visible = false;
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

            index = 0;
            elemanSayisiG = 0;
            elemanSayisiK = 0;

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

            myConnection.Close();

            chart1.Series["Gelen Faturalar"].Points.Clear();
            chart1.Series["Kesilen Faturalar"].Points.Clear();
            chart1.Series["Öngörülen Ödemeler"].Points.Clear();

         

            for (int Month = 0; Month < 12 ; Month++)
            {
                chart1.Series["Gelen Faturalar"].Points.AddXY(Convert.ToString((Month + 1) + ". ay"), NewsumG[Month]);
                chart1.Series["Gelen Faturalar"].Points[Month].Label = string.Format(new CultureInfo("de-DE"), "{0:C2}", Convert.ToDecimal(NewsumG[Month]));
            }
            for (int Month = 0; Month < 12; Month++)
            {
                chart1.Series["Kesilen Faturalar"].Points.AddXY(Convert.ToString((Month + 1) + ". ay"), NewsumK[Month]);
                chart1.Series["Kesilen Faturalar"].Points[Month].Label = string.Format(new CultureInfo("de-DE"), "{0:C2}", Convert.ToDecimal(NewsumK[Month]));
            }
            for (int Month = 0; Month < 12; Month++)
            {
                chart1.Series["Öngörülen Ödemeler"].Points.AddXY(Convert.ToString((Month + 1) + ". ay"), Newodemeler[Month]);
                chart1.Series["Öngörülen Ödemeler"].Points[Month].Label = string.Format(new CultureInfo("de-DE"), "{0:C2}", Convert.ToDecimal(Newodemeler[Month]));
            }

        }

        private void btnAktivite_Click(object sender, EventArgs e)
        {
            if(btn2_Flag==0)
            {
                pnlAcil.Dock = DockStyle.Fill;
                pnlAcil.Visible = true;
                btn2_Flag = 1;
            }
            else
            {
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
            //if(btn3_Flag==0)
            //{
            //    pnlFilter.Left = this.Location.X;
            //    pnlFilter.Top = pnlFilter.Height * 3;
            //    pnlFilter.Visible = true;
            //    btn3_Flag = 1;
            //}
            //else
            //{
            //    pnlFilter.Visible = false;
            //    btn3_Flag = 0;
            //}
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
    }
}
