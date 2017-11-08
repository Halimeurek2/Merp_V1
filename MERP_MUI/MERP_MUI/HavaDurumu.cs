using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MERP_MUI
{
    public partial class HavaDurumu : Form
    {
        public HavaDurumu()
        {
            InitializeComponent();
            //this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(0, 0);
        }

        private Graphics graphics = null;
        private Bitmap bitmap = null;
        private byte opacity = 0xff;
        private Color colorize = Color.White;
        private string locationCode = "wc:TUXX0014"; // Istanbul
        private string degreeType = "C";
        private string culture = "tr-TR"; //de-DE // en-US
        private string dataFormat =
            "http://weather.service.msn.com/data.aspx?" +
            "src=vista" +
            "&wealocations={0}" +
            "&weadegreetype={1}" +
            "&culture={2}";
        private int refreshInterval = 1000 * 60 * 5; // 5 dakika
        private bool hibernate = false;


        private void LoadSettings()
        {
            //int left = Properties.Settings.Default.Left;
            //if (left == 0xffff) left = (SystemInformation.WorkingArea.Width - this.Width) / 2;
            //int top = Properties.Settings.Default.Top;
            //if (top == 0xffff) top = (SystemInformation.WorkingArea.Height - this.Height) / 2;
            //this.Left = left;
            //this.Top = top;
            //locationCode = Properties.Settings.Default.LocationCode;
            //colorize = Properties.Settings.Default.Colorize;
        }

        private void HavaDurumu_Load(object sender, EventArgs e)
        {
            /* Uygulamadan cikildiginda ayarlarin kaydedilmesi icin gerekli */
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

            /* Saydamlik icin formun Opacity ozelligini kullanin */
            opacity = Convert.ToByte(this.Opacity * 0xff);

            long style = CreateParams.ExStyle;

            // Bu fromun window styles ozelliginden WS_EX_LAYERED bitini varsa kaldir
            if ((style & Win32.WS_EX_LAYERED) != 0)
            {
                style &= ~Win32.WS_EX_LAYERED;
                Win32.SetWindowLong(this.Handle, Win32.GWL_EXSTYLE, (IntPtr)style);
            }

            // Simdi WS_EX_LAYERED bitini set et
            style |= Win32.WS_EX_LAYERED;
            Win32.SetWindowLong(this.Handle, Win32.GWL_EXSTYLE, (IntPtr)style);

            /* Form boyutlarinda bir Bitmap olustur */
            bitmap = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppArgb);

            /* Bitmap ile baglantili ana Graphics nesnesi */
            graphics = Graphics.FromImage(bitmap);

            /* Yumusak metin etkisi. Eger AntiAliasGridFit yaparsaniz keskin bir metin elde edersiniz. */
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            /* Resimleri olceklendirilmesi en iyi kalitede olsun. Dikkat islemci tuketimi artar. */
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            /* Baslangic ayarlarini yukle */
            LoadSettings();

            /* Yukleme zamanlayicisini etkinlestir */
            loaderTimer.Enabled = true;
        }
        private void OnApplicationExit(object sender, EventArgs e)
        {
            try
            {
                this.SaveSettings();
            }
            catch { }
        }
        private void SaveSettings()
        {
            //Properties.Settings.Default.Left = this.Left;
            //Properties.Settings.Default.Top = this.Top;
            //Properties.Settings.Default.LocationCode = locationCode;
            //Properties.Settings.Default.Colorize = colorize;
            //Properties.Settings.Default.Save();
        }

        private void HavaDurumu_Activated(object sender, EventArgs e)
        {
            //closeBox.Visible = true;
            RepaintLayeredForm();
            UpdateLayeredForm();
        }

        private void HavaDurumu_Deactivate(object sender, EventArgs e)
        {
            RepaintLayeredForm();
            UpdateLayeredForm();
        }

        private void HavaDurumu_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Win32.ReleaseCapture();
                Win32.SendMessage(this.Handle, Win32.WM_SYSCOMMAND, Win32.SC_DRAGMOVE, 0x0);
            }
        }

        private void loaderTimer_Tick(object sender, EventArgs e)
        {
            loaderTimer.Enabled = false;
            BeginLoader();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            refreshTimer.Enabled = false;
            GetWeatherData();
            RepaintLayeredForm();
            UpdateLayeredForm();
            refreshTimer.Enabled = true;
        }
        private void BeginLoader()
        {
            refreshTimer.Interval = refreshInterval;
            refreshTimer.Enabled = true;
            GetWeatherData();
            RepaintLayeredForm();
            UpdateLayeredForm();
        }
        private void GetWeatherData()
        {

            locationLabel.Text = Properties.Resources.Connecting;

            RepaintLayeredForm();
            UpdateLayeredForm();

            string requestURL = String.Format(dataFormat, locationCode, degreeType, culture);

            WebClient webclient = new WebClient();
            webclient.Encoding = Encoding.UTF8;
            webclient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(OnDownloadStringCompleted);
            webclient.DownloadStringAsync(new Uri(requestURL));

        }
        private void DisplayError()
        {
            locationLabel.Text = Properties.Resources.ErrorMessage;
            RepaintLayeredForm();
            UpdateLayeredForm();
        }
        private void OnDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {

            if (e.Error != null)
            {
                DisplayError();
                return;
            }

            string strData = e.Result;
            if (strData == "")
            {
                DisplayError();
                return;
            }

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(strData);
            //doc.Save("data.xml");

            XmlNode node = doc.SelectSingleNode("/weatherdata/weather/@errormessage");
            if (node != null)
            {
                DisplayError();
                return;
            }

            node = doc.SelectSingleNode("/weatherdata/weather/current/@skycode");
            string textValue = node.Value;
            textValue = "Light" + textValue;
            skyBigPicture.Image = Properties.Resources.ResourceManager.GetObject(textValue) as Bitmap;

            node = doc.SelectSingleNode("/weatherdata/weather/@weatherlocationname");
            textValue = node.Value;
            int pos = textValue.IndexOf(',');
            if (pos > 0) textValue = textValue.Substring(0, pos);
            locationLabel.Text = textValue;

            node = doc.SelectSingleNode("/weatherdata/weather/current/@temperature");
            textValue = node.Value;
            tempLabel.Text = textValue + '\u00b0';

            node = doc.SelectSingleNode("/weatherdata/weather/current/@skytext");
            textValue = node.Value;
            skyTextLabel.Text = textValue;

            node = doc.SelectSingleNode("/weatherdata/weather/current/@feelslike");
            feelslikeLabel.Text = String.Format(Properties.Resources.FeelsLike, node.Value + '\u00b0');

            node = doc.SelectSingleNode("/weatherdata/weather/current/@date");
            textValue = node.Value;

            node = doc.SelectSingleNode("/weatherdata/weather/current/@observationtime");
            textValue = textValue + " " + node.Value;

            timeLabel.Text = textValue;

            XmlNodeList list = doc.SelectNodes("/weatherdata/weather/forecast");
            if (list.Count > 0)
            {

                XmlElement element;

                element = list.Item(1) as XmlElement;
                daylabel1.Text = element.GetAttribute("day");
                skytextLabel1.Text = element.GetAttribute("skytextday");
                textValue = element.GetAttribute("skycodeday");
                textValue = "Light" + textValue;
                skySmallPicture1.Image = Properties.Resources.ResourceManager.GetObject(textValue) as Bitmap;
                templabel1.Text = element.GetAttribute("high") + '\u00b0' + "/ " + element.GetAttribute("low") + '\u00b0';

                element = list.Item(2) as XmlElement;
                daylabel2.Text = element.GetAttribute("day");
                skytextLabel2.Text = element.GetAttribute("skytextday");
                textValue = element.GetAttribute("skycodeday");
                textValue = "Light" + textValue;
                skySmallPicture2.Image = Properties.Resources.ResourceManager.GetObject(textValue) as Bitmap;
                templabel2.Text = element.GetAttribute("high") + '\u00b0' + "/ " + element.GetAttribute("low") + '\u00b0';

                element = list.Item(3) as XmlElement;
                daylabel3.Text = element.GetAttribute("day");
                skytextLabel3.Text = element.GetAttribute("skytextday");
                textValue = element.GetAttribute("skycodeday");
                textValue = "Light" + textValue;
                skySmallPicture3.Image = Properties.Resources.ResourceManager.GetObject(textValue) as Bitmap;
                templabel3.Text = element.GetAttribute("high") + '\u00b0' + "/ " + element.GetAttribute("low") + '\u00b0';

            }

            RepaintLayeredForm();
            UpdateLayeredForm();
        }
        private void UpdateLayeredForm()
        {
            /* Desktop ile uyumlu bir DC olustur. */
            IntPtr SrcDC = Win32.CreateCompatibleDC(IntPtr.Zero);

            /* Olusturdugumuz DC ile uyumlu yeni bir DC daha olusturmaliyiz. Kopyalama icin. */
            IntPtr DestDC = Win32.CreateCompatibleDC(SrcDC);

            /* Cizim yaptigimiz resmin Windows tarafidan anlasilan HBITMAP turunden degiskene ata.
               Bu kisim onemli. Cizim yaptigimiz resmi gercek dunyaya getiriyoruz.
               BitmapHandle degiskeni artik Windows tarafindan kullanilanilabilir duruma geldi. */
            IntPtr BitmapHandle = bitmap.GetHbitmap(Color.FromArgb(0));

            /* SrcDC de bitmap secilmeli */
            IntPtr PrevBitmap = Win32.SelectObject(DestDC, BitmapHandle);

            /* Boyutlar ve konum */
            Win32.Size Size = new Win32.Size()
            {
                X = Width,
                Y = Height
            };

            Win32.Point S = new Win32.Point()
            {
                X = 0,
                Y = 0
            };

            Win32.Point P = new Win32.Point()
            {
                X = Left,
                Y = Top
            };

            Win32.BlendFunction BlendFunc = new Win32.BlendFunction()
            {
                BlendOp = Win32.AC_SRC_OVER,
                BlendFlags = 0x00, /* Sifir olmali */
                AlphaFormat = Win32.AC_SRC_ALPHA,
                SourceConstantAlpha = opacity /* Ana formun donukluk degeri. 0 = tam saydam, 255 = tam donuk. */
            };

            /* Microsoft'un sihirli fonksiyonu! Oylesine onemli ki, aslinda butun kiyamet burada kopuyor.
              Detayli aciklamayi MSDN' den mutlaka okuyunuz. http://msdn.microsoft.com/en-us/library/ms633556(VS.85).aspx */
            Win32.UpdateLayeredWindow(this.Handle, SrcDC, ref P, ref Size, DestDC,
                ref S, 0, ref BlendFunc, Win32.ULW_ALPHA);

            /* SrcDC yi eski haline getir. */
            Win32.SelectObject(SrcDC, PrevBitmap);

            /* ve Bitmap'i yok et. Yoksa hafiza sizmasi olur. */
            Win32.DeleteObject(BitmapHandle);

            /* DC leri yok et. */
            Win32.DeleteDC(DestDC);
            Win32.DeleteDC(SrcDC);

        }
        private void RepaintLayeredForm()
        {

            /* Herseyi sil */
            graphics.Clear(Color.FromArgb(0));

            /* Dikkat form uzerindeki bilesenler tersten siralanir */
            for (int index = this.Controls.Count - 1; index >= 0; index--)
            {

                Control control = this.Controls[index];

                /* Bilesen gorunmezse cizim yapma */
                if (!control.Visible) continue;

                if (control is PictureBox)
                {
                    /* Bilesen PictureBox turundense Image ozelligini ciz  */
                    PictureBox picture = control as PictureBox;
                    /* Renklendirme isleminde closeBox haric tutulacak */
                    if (picture.Name == "closeBox")
                    {
                        /* Sadece closeBox dugmesini normal ciz */
                        graphics.DrawImage(picture.Image, picture.Bounds);
                    }
                    else
                    {
                        /* Diger pictureBox nesnelerini renklendirilmis olarak ciz */
                        this.DrawColorizedPicture(picture, colorize);
                    }
                }
                else if (control is Label)
                {
                    /* Bilesen Label turundense durum biraz karisik. Normalde DrawToBitmap fonksiyonu
                     * transparent cizim yapmaz. Biz zeminin cizilmesini istemiyoruz. Orjinalden biraz
                     * farkli bir cizim yapiyoruz.
                     */
                    Label label = control as Label;
                    this.DrawTransparentLabel(label);
                }
                else
                {
                    /* Diger turdense varsayilan cizim */
                    control.DrawToBitmap(bitmap, control.Bounds);
                }
            }

        }
        private void DrawTransparentLabel(Label label)
        {

            using (Brush foreBrush = new SolidBrush(label.ForeColor))
            using (StringFormat format = new StringFormat())
            {

                switch (label.TextAlign)
                {
                    case ContentAlignment.TopLeft:
                        format.Alignment = StringAlignment.Near;
                        format.LineAlignment = StringAlignment.Near;
                        break;
                    case ContentAlignment.TopRight:
                        format.Alignment = StringAlignment.Far;
                        format.LineAlignment = StringAlignment.Near;
                        break;
                    case ContentAlignment.TopCenter:
                        format.Alignment = StringAlignment.Center;
                        format.LineAlignment = StringAlignment.Near;
                        break;

                    case ContentAlignment.MiddleLeft:
                        format.Alignment = StringAlignment.Near;
                        format.LineAlignment = StringAlignment.Center;
                        break;
                    case ContentAlignment.MiddleRight:
                        format.Alignment = StringAlignment.Far;
                        format.LineAlignment = StringAlignment.Center;
                        break;
                    case ContentAlignment.MiddleCenter:
                        format.Alignment = StringAlignment.Center;
                        format.LineAlignment = StringAlignment.Center;
                        break;

                    case ContentAlignment.BottomLeft:
                        format.Alignment = StringAlignment.Near;
                        format.LineAlignment = StringAlignment.Far;
                        break;
                    case ContentAlignment.BottomRight:
                        format.Alignment = StringAlignment.Far;
                        format.LineAlignment = StringAlignment.Far;
                        break;
                    case ContentAlignment.BottomCenter:
                        format.Alignment = StringAlignment.Center;
                        format.LineAlignment = StringAlignment.Far;
                        break;

                }
                /* Tek satira cizim yapmak icin ayarla */
                format.FormatFlags = StringFormatFlags.NoWrap;
                /* Satira sigmazsa ... karakterlerini goruntule */
                format.Trimming = StringTrimming.EllipsisCharacter;
                Rectangle rect = label.Bounds;
                /* Koordinatlari 1 piksel saga ve asagiya kaydir */
                rect.Offset(1, 1);
                /* Siyah golge etkisi vermek icin cizim */
                graphics.DrawString(label.Text, label.Font, Brushes.Black, rect, format);
                /* Normal cizim */
                graphics.DrawString(label.Text, label.Font, foreBrush, label.Bounds, format);

            }

        }
        private void DrawColorizedPicture(PictureBox picture, Color color)
        {
            ColorMatrix matrix = new ColorMatrix(new float[][]
            {
                new float[]{ 1f, 0f, 0f, 0f, 0f },
                new float[]{ 0f, 1f, 0f, 0f, 0f },
                new float[]{ 0f, 0f, 1f, 0f, 0f },
                new float[]{ 0f, 0f, 0f, 1f, 0f },
                new float[]{ 0f, 0f, 0f, 0f, 1f }
            });
            matrix.Matrix00 = (float)color.R / (float)255;
            matrix.Matrix11 = (float)color.G / (float)255;
            matrix.Matrix22 = (float)color.B / (float)255;
            using (ImageAttributes attr = new ImageAttributes())
            {
                attr.SetColorMatrix(matrix);
                graphics.DrawImage(picture.Image, picture.Bounds, 0f, 0f, picture.Image.Width, picture.Image.Height, GraphicsUnit.Pixel, attr);
            }
        }
    }
}
