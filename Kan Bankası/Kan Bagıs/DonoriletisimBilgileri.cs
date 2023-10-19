using Kan_Bankası.Kan_Bagıs;
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

namespace Kan_Bankası
{
    public partial class DonoriletisimBilgileri : Form
    {
        public DonoriletisimBilgileri()
        {
            InitializeComponent();
            Veriler();
        }
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.AppSettings["Baglanti"]);


        private void Veriler()

        {
            baglanti.Open();

            string query = "select *from DonoriletisimBilgileriTbl  where DSil=0";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DonoriletisimDGV.DataSource = ds.Tables[0];
            DonoriletisimDGV.Columns[8].Visible = false;


            baglanti.Close();
        }


        private void ara()

        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DonoriletisimBilgileriTbl WHERE DAdsoyad LIKE @search", baglanti);
            da.SelectCommand.Parameters.AddWithValue("@search", "%" + DonorAraTb.Text + "%");
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            DonoriletisimDGV.DataSource = tablo;
            baglanti.Close();

        }




        private void label4_Click(object sender, EventArgs e)
        {
            PersonelEkle kul = new PersonelEkle();
            kul.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            SilinenDonorler kul = new SilinenDonorler();
            kul.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            SilinenHastalar kul = new SilinenHastalar();
            kul.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            HastailetisimBilgileri kul = new HastailetisimBilgileri();
            kul.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            KontrolPaneli kul = new KontrolPaneli();
            kul.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Anasayfa kul = new Anasayfa();
            kul.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login kul = new Login();
            kul.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Kullanıcı kul = new Kullanıcı();
            kul.Show();
            this.Hide();
        }

        private void DonorAraBtn_Click(object sender, EventArgs e)
        {
            ara();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            ikram kul = new ikram();
            kul.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Hastane kul = new Hastane();
            kul.Show();
            this.Hide();
        }

        private void DonoriletisimBilgileri_Load(object sender, EventArgs e)
        {
            DonoriletisimDGV.Columns[0].HeaderText = "ID";
            DonoriletisimDGV.Columns[1].HeaderText = "İsim,Soyisim";
            DonoriletisimDGV.Columns[2].HeaderText = "Yaş";
            DonoriletisimDGV.Columns[3].HeaderText = "Telefon";
            DonoriletisimDGV.Columns[4].HeaderText = "Cinsiyet";
            DonoriletisimDGV.Columns[5].HeaderText = "Kan Grubu";
            DonoriletisimDGV.Columns[6].HeaderText = "Mail";
            DonoriletisimDGV.Columns[7].HeaderText = "Adres";
        }

        
    }
}
