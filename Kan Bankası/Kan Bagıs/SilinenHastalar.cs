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

namespace Kan_Bankası.Kan_Bagıs
{
    public partial class SilinenHastalar : Form
    {
        public SilinenHastalar()
        {
            InitializeComponent();
            uyeler();
        }

        SqlConnection baglanti = new SqlConnection(ConfigurationManager.AppSettings["Baglanti"]);

        private void uyeler()

        {
            baglanti.Open();
            string query = "select *from HastaTbl where HSil=1";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            silinenhastalarDGV.DataSource = ds.Tables[0];
            silinenhastalarDGV.Columns[11].Visible = false;
            baglanti.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Kullanıcı HL = new Kullanıcı();
            HL.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            PersonelEkle HL = new PersonelEkle();
            HL.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            SilinenDonorler HL = new SilinenDonorler();
            HL.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            DonoriletisimBilgileri HL = new DonoriletisimBilgileri();
            HL.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            HastailetisimBilgileri HL = new HastailetisimBilgileri();
            HL.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            KontrolPaneli HL = new KontrolPaneli();
            HL.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Anasayfa HL = new Anasayfa();
            HL.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login HL = new Login();
            HL.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ikram HL = new ikram();
            HL.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Hastane kul = new Hastane();
            kul.Show();
            this.Hide();
        }

        private void SilinenHastalar_Load(object sender, EventArgs e)
        {
            silinenhastalarDGV.Columns[0].HeaderText = "ID";
            silinenhastalarDGV.Columns[1].HeaderText = "TC";
            silinenhastalarDGV.Columns[2].HeaderText = "İsim,Soyisim";
            silinenhastalarDGV.Columns[3].HeaderText = "Yaş";
            silinenhastalarDGV.Columns[4].HeaderText = "Kilo";
            silinenhastalarDGV.Columns[5].HeaderText = "Telefon";
            silinenhastalarDGV.Columns[6].HeaderText = "Cinsiyet";
            silinenhastalarDGV.Columns[7].HeaderText = "Kan Grubu";
            silinenhastalarDGV.Columns[8].HeaderText = "E-Mail";
            silinenhastalarDGV.Columns[9].HeaderText = "Adres";
            silinenhastalarDGV.Columns[10].HeaderText = "Bilgi";
            silinenhastalarDGV.Columns[11].HeaderText = "Personel";
            silinenhastalarDGV.Columns[12].HeaderText = "Tarih";
        }
    }
}
