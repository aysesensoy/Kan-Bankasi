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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Kan_Bankası.Kan_Bagıs
{
    public partial class HastailetisimBilgileri : Form
    {

        public HastailetisimBilgileri()
        {
            InitializeComponent();
            
            Veriler();
        }
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.AppSettings["Baglanti"]);


       

        private void Veriler()

        {
            baglanti.Open();

            string query = "select *from HastailetisimBilgileriTbl where HSil=0";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            HastailetisimDGV.DataSource = ds.Tables[0];
            HastailetisimDGV.Columns[8].Visible = false;


            baglanti.Close();
        }

        private void ara()

        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM HastailetisimBilgileriTbl WHERE HAdsoyad LIKE @search", baglanti);
            da.SelectCommand.Parameters.AddWithValue("@search", "%" + HastaAraTb.Text + "%");
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            HastailetisimDGV.DataSource = tablo;
            baglanti.Close();

        }




        private void HastailetisimDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Kullanıcı kul = new Kullanıcı();
            kul.Show();
            this.Hide();
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

        private void label13_Click(object sender, EventArgs e)
        {
            DonoriletisimBilgileri kul = new DonoriletisimBilgileri();
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

        private void HastaAraBtn_Click(object sender, EventArgs e)
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

        private void HastailetisimBilgileri_Load(object sender, EventArgs e)
        {
            HastailetisimDGV.Columns[0].HeaderText = "ID";
            HastailetisimDGV.Columns[1].HeaderText = "İsim,Soyisim";
            HastailetisimDGV.Columns[2].HeaderText = "Yaş";
            HastailetisimDGV.Columns[3].HeaderText = "Telefon";
            HastailetisimDGV.Columns[4].HeaderText = "Cinsiyet";
            HastailetisimDGV.Columns[5].HeaderText = "Kan Grubu";
            HastailetisimDGV.Columns[6].HeaderText = "Mail";
            HastailetisimDGV.Columns[7].HeaderText = "Adres";
        }
    }
}
