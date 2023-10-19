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
    public partial class Hastane : Form
    {
        public Hastane()
        {
            InitializeComponent();
            uyeler();
        }
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.AppSettings["Baglanti"]);
        private void uyeler()
        {
            baglanti.Open();
            string query = "select *from HastaneTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            HastaneDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void Reset()
        {
            HastaneAdTb.Text = "";
            HastaneAdres.Text = "";
            HastaneTelefnTb.Text = "";
            HastaneMail.Text = "";
            HastaneAcıklama.Text = "";
            key = 0;

        }



        private void HastaneKydtBtn_Click(object sender, EventArgs e)
        {
            if (HastaneAdTb.Text == "" || HastaneAdres.Text == "" || HastaneTelefnTb.Text == "" || HastaneMail.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    string query = "insert into HastaneTbl values('" + HastaneAdTb.Text + "','" + HastaneAdres.Text + "','" + HastaneTelefnTb.Text + "','" + HastaneMail.Text + "','" + HastaneAcıklama.Text + "')";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Hastane Başarıyla Kaydedildi");
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

        private void HastaneDznBtn_Click(object sender, EventArgs e)
        {
            if (HastaneAdTb.Text == "" || HastaneAdres.Text == "" || HastaneTelefnTb.Text == "" || HastaneMail.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    string query = "update HastaneTbl set HastaneAdı='" + HastaneAdTb.Text + "',HastaneAdres='" + HastaneAdres.Text + "',HastaneTelefon='" + HastaneTelefnTb.Text + "',HastaneMail='" + HastaneMail.Text + "',Acıklama='" + HastaneAcıklama.Text + "' where HastaneID=" + key + ";";
                    baglanti.Open();

                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Hastane Başarıyla Güncellendi");
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
        private void HastaneDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HastaneAdTb.Text = HastaneDGV.SelectedRows[0].Cells[1].Value.ToString();
            HastaneAdres.Text = HastaneDGV.SelectedRows[0].Cells[2].Value.ToString();
            HastaneTelefnTb.Text = HastaneDGV.SelectedRows[0].Cells[3].Value.ToString();
            HastaneMail.Text = HastaneDGV.SelectedRows[0].Cells[4].Value.ToString();
            HastaneAcıklama.Text = HastaneDGV.SelectedRows[0].Cells[5].Value.ToString();

            if (HastaneAdTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(HastaneDGV.SelectedRows[0].Cells[0].Value.ToString());
            }


        }

        private void HastaneSilBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Silinecek Hastaneyi Seçiniz");
            }
            else
            {
                try
                {
                    string query = "delete from HastaneTbl where HastaneID=" + key + ";";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Hastane Başarıyla Silindi");
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

        private void label9_Click(object sender, EventArgs e)
        {
           Login kul = new Login();
            kul.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Anasayfa kul = new Anasayfa();
            kul.Show();
            this.Hide();

        }

        private void label8_Click(object sender, EventArgs e)
        {
            KontrolPaneli kul = new KontrolPaneli();
            kul.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            ikram kul = new ikram();
            kul.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            HastailetisimBilgileri kul = new HastailetisimBilgileri();
            kul.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            DonoriletisimBilgileri kul = new DonoriletisimBilgileri();
            kul.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            SilinenHastalar kul = new SilinenHastalar();
            kul.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            SilinenDonorler kul = new SilinenDonorler();
            kul.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            PersonelEkle kul = new PersonelEkle();
            kul.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Kullanıcı kul = new Kullanıcı();
            kul.Show();
            this.Hide();
        }

        private void Hastane_Load(object sender, EventArgs e)
        {
            HastaneDGV.Columns[0].HeaderText = "ID";
            HastaneDGV.Columns[1].HeaderText = "Hastane Adı";
            HastaneDGV.Columns[2].HeaderText = "Adres";
            HastaneDGV.Columns[3].HeaderText = "Telefon";
            HastaneDGV.Columns[4].HeaderText = "E-Mail";
            HastaneDGV.Columns[5].HeaderText = "Açıklama";
        }
    }
}




