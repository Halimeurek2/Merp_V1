using System;
using System.Windows.Forms;

namespace MERP_MUI
{
    public partial class HarcamaOngorusu : MetroFramework.Forms.MetroForm
    {
        HelperFunctions hf;
        int indexH = 0;
        int indexO = 0;
        public string toplam = "0";
        string toplam_euro;

        public int[,] HarcamaArray;

        public HarcamaOngorusu()
        {
            InitializeComponent();
            hf = new HelperFunctions();
        }

        private void HarcamaOngorusu_Load(object sender, EventArgs e)
        {

        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ekleH_Click(object sender, EventArgs e)
        {
            dgw_harcama.Rows.Add();//datagridviewe yeni satır ekler
            dgw_harcama.Rows[indexH].Cells[0].Value = date_tarihH.Text;
            dgw_harcama.Rows[indexH].Cells[1].Value = cmb_tipH.Text;
            dgw_harcama.Rows[indexH].Cells[2].Value = txt_tutarH.Text;
            dgw_harcama.Rows[indexH].Cells[3].Value = cmb_birimH.Text;
            indexH++;
        }

        private void btn_ekleO_Click(object sender, EventArgs e)
        {
            dgw_odeme.Rows.Add();//datagridviewe yeni satır ekler
            dgw_odeme.Rows[indexO].Cells[0].Value = date_tarihO.Text;
            dgw_odeme.Rows[indexO].Cells[1].Value = cmb_tipO.Text;
            dgw_odeme.Rows[indexO].Cells[2].Value = txt_tutarO.Text;
            dgw_odeme.Rows[indexO].Cells[3].Value = cmb_birimO.Text;
            indexO++;
        }

        private void dgw_harcama_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           // dgw_harcama.Rows.RemoveAt(this.dgw_harcama.SelectedRows[e.RowIndex].Index);
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgw_harcama.SelectedRows.Count > 0)
            {
                dgw_harcama.Rows.RemoveAt(this.dgw_harcama.SelectedRows[0].Index);
                indexH--;
            }
            if (this.dgw_odeme.SelectedRows.Count > 0)
            {
                dgw_odeme.Rows.RemoveAt(this.dgw_odeme.SelectedRows[0].Index);
                indexO--;
            }
        }

        private void btn_hesapla_Click(object sender, EventArgs e)
        {
            for (int i=0;i<dgw_harcama.Rows.Count-1;i++)
            {
                dgw_harcama.Rows[i].Cells[2].Value = hf.Comma2Dot(Convert.ToString(dgw_harcama.Rows[i].Cells[2].Value));
                toplam_euro = hf.EuroCalculation(Convert.ToString(dgw_harcama.Rows[i].Cells[0].Value), Convert.ToString(dgw_harcama.Rows[i].Cells[2].Value), Convert.ToString(dgw_harcama.Rows[i].Cells[3].Value), toplam_euro);
                toplam = Convert.ToString(Convert.ToDecimal(toplam_euro) + Convert.ToDecimal(toplam));
            }
        }
    }
}
