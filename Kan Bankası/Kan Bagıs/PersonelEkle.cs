using System;
using System.Collections;
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
    public partial class PersonelEkle : Form
    {
        public PersonelEkle()
        {
            InitializeComponent();
            uyeler();
        }
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.AppSettings["Baglanti"]);

        private void uyeler()

        {
            baglanti.Open();
            string query = "select *from PersonelTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PersonelDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void Reset()
        {
            PAdSoyadTb.Text = "";
            PBransTb.Text = "";
            PTelefonTb.Text = "";
            key = 0;
        }


        private void PKaydetBtn_Click(object sender, EventArgs e)
        {
            if (PAdSoyadTb.Text == "" || PBransTb.Text == "" || PTelefonTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    string query = "insert into PersonelTbl values('" + PAdSoyadTb.Text + "','" + PBransTb.Text + "','" + PTelefonTb.Text + "')";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Personel Başarıyla Kaydedildi");
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


        private void PDuzebleBtn_Click(object sender, EventArgs e)
        {
            if (PAdSoyadTb.Text == "" || PBransTb.Text == "" || PTelefonTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    string query = "update PersonelTbl set PerAdSoyad='" + PAdSoyadTb.Text + "',PerBrans='" + PBransTb.Text + "', PerTelefon='" + PTelefonTb.Text + "' where PerNum=" + key + ";";
                    baglanti.Open();

                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Personel Başarıyla Güncellendi");
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


        private void PSilBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Silinecek Personeli Seçiniz");
            }
            else
            {
                try
                {
                    string query = "delete from PersonelTbl where PerNum=" + key + ";";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Personel Başarıyla Silindi");
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
        private void PersonelDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            PAdSoyadTb.Text = PersonelDGV.SelectedRows[0].Cells[1].Value.ToString();
            PBransTb.Text  = PersonelDGV.SelectedRows[0].Cells[2].Value.ToString();
            PTelefonTb.Text = PersonelDGV.SelectedRows[0].Cells[3].Value.ToString();




            if (PAdSoyadTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PersonelDGV.SelectedRows[0].Cells[0].Value.ToString());
            }



        }

        private void label2_Click(object sender, EventArgs e)
        {
            Kullanıcı HL = new Kullanıcı();
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

        private void PersonelEkle_Load(object sender, EventArgs e)
        {
            PersonelDGV.Columns[0].HeaderText = "ID";
            PersonelDGV.Columns[1].HeaderText = "İsim,Soyisim";
            PersonelDGV.Columns[2].HeaderText = "Branş";
            PersonelDGV.Columns[3].HeaderText = "Telefon Numarası";
        }
    }
}
