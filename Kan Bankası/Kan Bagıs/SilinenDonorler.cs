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
    public partial class SilinenDonorler : Form
    {
        public SilinenDonorler()
        {
            InitializeComponent();
            uyeler();
        }


        SqlConnection baglanti = new SqlConnection(ConfigurationManager.AppSettings["Baglanti"]);

        private void uyeler()

        {
            baglanti.Open();
            string query = "select *from DonorTbl where DSil=1";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            silinendonorDGV.DataSource = ds.Tables[0];
            silinendonorDGV.Columns[12].Visible = false;
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

        private void label7_Click(object sender, EventArgs e)
        {
            SilinenHastalar HL = new SilinenHastalar();
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

        private void SilinenDonorler_Load(object sender, EventArgs e)
        {
            silinendonorDGV.Columns[0].HeaderText = "ID";
            silinendonorDGV.Columns[1].HeaderText = "TC";
            silinendonorDGV.Columns[2].HeaderText = "İsim,Soyisim";
            silinendonorDGV.Columns[3].HeaderText = "Yaş";
            silinendonorDGV.Columns[4].HeaderText = "Kilo";
            silinendonorDGV.Columns[5].HeaderText = "Telefon";
            silinendonorDGV.Columns[6].HeaderText = "Cinsiyet";
            silinendonorDGV.Columns[7].HeaderText = "Kan Grubu";
            silinendonorDGV.Columns[8].HeaderText = "E-Mail";
            silinendonorDGV.Columns[9].HeaderText = "Adres";
            silinendonorDGV.Columns[10].HeaderText = "Bilgi";
            silinendonorDGV.Columns[11].HeaderText = "Personel";
            silinendonorDGV.Columns[12].HeaderText = "Tarih";
        }
    }

}
