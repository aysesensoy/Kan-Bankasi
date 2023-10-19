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
    public partial class LaboratuvardaTestiGecenKanlar : Form
    {
        public LaboratuvardaTestiGecenKanlar()
        {
            InitializeComponent();
            Veriler();
        }


        SqlConnection baglanti = new SqlConnection(ConfigurationManager.AppSettings["Baglanti"]);

        private void Veriler()

        {
            baglanti.Open();

            string query = "select *from LaboratuvardaTestiGecenKanlarTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            LaboratuvarGecenDGV.DataSource = ds.Tables[0];
            LaboratuvarGecenDGV.Columns[6].Visible = false;
            LaboratuvarGecenDGV.Columns[8].Visible = false;

            baglanti.Close();
        }

        private void ara()

        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM LaboratuvardaTestiGecenKanlarTbl WHERE LDonorAdSoyad LIKE @search", baglanti);
            da.SelectCommand.Parameters.AddWithValue("@search", "%" + GecenAraTb.Text + "%");
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            LaboratuvarGecenDGV.DataSource = tablo;
            baglanti.Close();

        }

        int key = 0;
        private void LaboratuvarGecenDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            gecenacıklamaTb.Text = LaboratuvarGecenDGV.SelectedRows[0].Cells[7].Value.ToString();


            if (gecenacıklamaTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(LaboratuvarGecenDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void gecenacıklamaBtn_Click(object sender, EventArgs e)
        {
            string query1 = "update LaboratuvardaTestiGecenKanlarTbl set LAcıklama='" + gecenacıklamaTb.Text + "' where LNum=" + key + ";";

            baglanti.Open();
            gecenacıklamaTb.Text = "";
            SqlCommand komut1 = new SqlCommand(query1, baglanti);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            Veriler();
        }

        private void GecenAraBtn_Click(object sender, EventArgs e)
        {
            ara();
        }
        private void label10_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            imhaEdilenKanlarTbl log = new imhaEdilenKanlarTbl();
            log.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            LaboratuvardaTestEdilecekKanlar log = new LaboratuvardaTestEdilecekKanlar();
            log.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
           KanTransferi log = new KanTransferi();
            log.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            KanStogu log = new KanStogu();
            log.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            KanBagısı log = new KanBagısı();
            log.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HastaListesi log = new HastaListesi();
            log.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Hasta log = new Hasta();
            log.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DonorListesi log = new DonorListesi();
            log.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor log = new Donor();
            log.Show();
            this.Hide();
        }

        private void LaboratuvardaTestiGecenKanlar_Load(object sender, EventArgs e)
        {
            LaboratuvarGecenDGV.Columns[0].HeaderText = "ID";
            LaboratuvarGecenDGV.Columns[1].HeaderText = "Kan Grubu";
            LaboratuvarGecenDGV.Columns[2].HeaderText = "TC No";
            LaboratuvarGecenDGV.Columns[3].HeaderText = "Donor İsim,Soyisim";
            LaboratuvarGecenDGV.Columns[4].HeaderText = "Tarih";
            LaboratuvarGecenDGV.Columns[5].HeaderText = "Personel Ad,Soyad";
            LaboratuvarGecenDGV.Columns[6].HeaderText = "Açıklama";
            LaboratuvarGecenDGV.Columns[7].HeaderText = "Kanın Sağlık Değeri";
        }

       
    }
}
