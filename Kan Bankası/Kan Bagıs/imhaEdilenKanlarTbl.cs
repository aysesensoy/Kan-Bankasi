using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Kan_Bankası.Kan_Bagıs
{
    public partial class imhaEdilenKanlarTbl : Form
    {
        public imhaEdilenKanlarTbl()
        {
            InitializeComponent();
            Veriler();
        }
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.AppSettings["Baglanti"]);

        private void Veriler()

        {
            baglanti.Open();

            string query = "select *from İmhaEdilenKanlarTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            imhaDGV.DataSource = ds.Tables[0];
            imhaDGV.Columns[6].Visible = false;
            imhaDGV.Columns[8].Visible = false;

            baglanti.Close();
        }

        private void ara()

        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM İmhaEdilenKanlarTbl WHERE LDonorAdSoyad LIKE @search", baglanti);
            da.SelectCommand.Parameters.AddWithValue("@search", "%" + imhaAraTb.Text + "%");
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            imhaDGV.DataSource = tablo;
            baglanti.Close();

        }


        private void imhaAraBtn_Click(object sender, EventArgs e)
        {
            ara();
        }

        private void imhaacıklamaBtn_Click(object sender, EventArgs e)
        {
            string query1 = "update İmhaEdilenKanlarTbl set LAcıklama='" + imhacıklamaTb.Text + "' where LNum=" + key + ";";

            baglanti.Open();
            imhacıklamaTb.Text = "";
            SqlCommand komut1 = new SqlCommand(query1, baglanti);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            Veriler();
        }

        int key = 0;
        private void imhaDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            imhacıklamaTb.Text = imhaDGV.SelectedRows[0].Cells[7].Value.ToString();


            if (imhacıklamaTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(imhaDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor log = new Donor();
            log.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DonorListesi log = new DonorListesi();
            log.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Hasta log = new Hasta();
            log.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HastaListesi log = new HastaListesi();
            log.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            KanBagısı log = new KanBagısı();
            log.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            KanStogu log = new KanStogu();
            log.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            KanTransferi log = new KanTransferi();
            log.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            LaboratuvardaTestEdilecekKanlar log = new LaboratuvardaTestEdilecekKanlar();
            log.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            LaboratuvardaTestiGecenKanlar log = new LaboratuvardaTestiGecenKanlar();
            log.Show();
            this.Hide();
        }

        private void imhaEdilenKanlarTbl_Load(object sender, EventArgs e)
        {
            imhaDGV.Columns[0].HeaderText = "ID";
            imhaDGV.Columns[1].HeaderText = "Kan Grubu";
            imhaDGV.Columns[2].HeaderText = "TC No";
            imhaDGV.Columns[3].HeaderText = "Donorun Adı,Soyadı";
            imhaDGV.Columns[4].HeaderText = "Tarih";
            imhaDGV.Columns[5].HeaderText = "Personel Adı,Soyadı";
            imhaDGV.Columns[6].HeaderText = "Açıklama";
            imhaDGV.Columns[7].HeaderText = "Kan Sağlık Değeri";
           
        }
    }
}
