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
    public partial class Kullanıcı : Form
    {
        public Kullanıcı()
        {
            InitializeComponent();
            uyeler();
        }
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.AppSettings["Baglanti"]);



        private void uyeler()

        {
            baglanti.Open();
            string query = "select *from KullanıcıTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            KullanıcıDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void Reset()
        {
            KulAdSoyadTb.Text = "";
            KulAdTb.Text = "";
            KulSıfreTb.Text = "";
            key = 0;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (KulAdTb.Text == "" || KulSıfreTb.Text == "" || KulAdSoyadTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    string query = "insert into KullanıcıTbl values('" +KulAdSoyadTb.Text+ "','" + KulAdTb.Text + "','" + KulSıfreTb.Text +  "')";
                    baglanti.Open();  
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı Başarıyla Kaydedildi");
                    baglanti.Close();
                    Reset();
                    uyeler();

                }
                catch (Exception Ex)
                {

                    MessageBox.Show("Ex.Message");
                }

            }

        }
        int key = 0;
        private void CalisanDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            KulAdSoyadTb.Text = KullanıcıDGV.SelectedRows[0].Cells[1].Value.ToString();
            KulAdTb.Text = KullanıcıDGV.SelectedRows[0].Cells[2].Value.ToString();
            KulSıfreTb.Text = KullanıcıDGV.SelectedRows[0].Cells[3].Value.ToString();
            



            if (KulAdTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(KullanıcıDGV.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Silinecek Kullanıcıyı Seçiniz");
            }
            else
            {
                try
                {
                    string query = "delete from KullanıcıTbl where KulNum=" + key + ";";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı Başarıyla Silindi");
                    baglanti.Close();
                    Reset();
                    uyeler();

                }
                catch (Exception Ex)
                {

                    MessageBox.Show("Ex.Message");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (KulAdTb.Text=="" || KulSıfreTb.Text=="" || KulAdSoyadTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    string query = "update KullanıcıTbl set KulAdSoyad='" + KulAdSoyadTb.Text + "',KulId='" + KulAdTb.Text + "', KulSif='" + KulSıfreTb.Text +  "' where KulNum=" + key + ";";
                    baglanti.Open();

                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı Başarıyla Güncellendi");
                    baglanti.Close();
                    Reset();
                    uyeler();

                }
                catch (Exception Ex)
                {

                    MessageBox.Show("Ex.Message");
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            PersonelEkle per = new PersonelEkle();
            per.Show();
            this.Hide();

        }


        private void label9_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            KontrolPaneli kul = new KontrolPaneli();
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

        private void label5_Click(object sender, EventArgs e)
        {
            Anasayfa HL = new Anasayfa();
            HL.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            DonoriletisimBilgileri kul = new DonoriletisimBilgileri();
            kul.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            HastailetisimBilgileri kul = new HastailetisimBilgileri();
            kul.Show();
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

        private void Kullanıcı_Load(object sender, EventArgs e)
        {
            KullanıcıDGV.Columns[0].HeaderText = "ID";
            KullanıcıDGV.Columns[1].HeaderText = "Adı, Soyadı";
            KullanıcıDGV.Columns[2].HeaderText = "Kullanıcı Adı";
            KullanıcıDGV.Columns[3].HeaderText = "Kullanıcı Şifresi";
        }
    }
    

}
