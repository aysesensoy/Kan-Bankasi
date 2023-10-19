using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Kan_Bankası.Kan_Bagıs;

namespace Kan_Bankası
{
    public partial class HastaListesi : Form
    {
        public HastaListesi()
        {
            InitializeComponent();
            uyeler();
        }
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.AppSettings["Baglanti"]);

        private void uyeler()

        {
            baglanti.Open();
            string query = "select *from HastaTbl where HSil=0";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            HastaDGV.DataSource = ds.Tables[0];
            HastaDGV.Columns[11].Visible = false;
            baglanti.Close();
        }


        private void HastaListesi_Load(object sender, EventArgs e)
        {
            HastaDGV.Columns[0].HeaderText = "ID";
            HastaDGV.Columns[1].HeaderText = "TC";
            HastaDGV.Columns[2].HeaderText = "İsim,Soyisim";
            HastaDGV.Columns[3].HeaderText = "Yaş";
            HastaDGV.Columns[4].HeaderText = "Kilo";
            HastaDGV.Columns[5].HeaderText = "Telefon Numarası";
            HastaDGV.Columns[6].HeaderText = "Cinsiyet";
            HastaDGV.Columns[7].HeaderText = "Kan Grubu";
            HastaDGV.Columns[8].HeaderText = "E-Mail";
            HastaDGV.Columns[9].HeaderText = "Adres";
            HastaDGV.Columns[10].HeaderText = "Bilgi";
            HastaDGV.Columns[11].HeaderText = "Verilen Tarih";
        }


        int key = 0;

        private void HastaDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HTcNoTb.Text = HastaDGV.SelectedRows[0].Cells[1].Value.ToString();
            HAdSoyadTb.Text = HastaDGV.SelectedRows[0].Cells[2].Value.ToString();
            HYasTb.Text = HastaDGV.SelectedRows[0].Cells[3].Value.ToString();
            HKiloTb.Text = HastaDGV.SelectedRows[0].Cells[4].Value.ToString();
            HTelefonTb.Text = HastaDGV.SelectedRows[0].Cells[5].Value.ToString();
            HCinsCb.Text = HastaDGV.SelectedRows[0].Cells[6].Value.ToString();
            HKGrupCb.Text = HastaDGV.SelectedRows[0].Cells[7].Value.ToString();
            HMailTb.Text = HastaDGV.SelectedRows[0].Cells[8].Value.ToString();
            HAdresTb.Text = HastaDGV.SelectedRows[0].Cells[9].Value.ToString();
            HBilgiTb.Text = HastaDGV.SelectedRows[0].Cells[10].Value.ToString();


            if (HAdSoyadTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(HastaDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Reset()
        {
            HTcNoTb.Text = "";
            HAdSoyadTb.Text = "";
            HYasTb.Text = "";
            HCinsCb.SelectedIndex = -1;
            HKiloTb.Text = "";
            HTelefonTb.Text = "";
            HAdresTb.Text = "";
            HKGrupCb.SelectedIndex = -1;
            HMailTb.Text = "";
            HBilgiTb.Text = "";


            key = 0;
        }


        private void HDuzenleBtn_Click(object sender, EventArgs e)
        {
            if (HTcNoTb.Text == "" || HAdSoyadTb.Text == "" || HYasTb.Text == "" || HCinsCb.SelectedIndex == -1 || HTelefonTb.Text == "" || HKGrupCb.SelectedIndex == -1 || HAdresTb.Text == "" || HMailTb.Text == "" || HKiloTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    string query = "update HastaTbl set HTcNo='" + HTcNoTb.Text + "',HAdsoyad='" + HAdSoyadTb.Text +
                        "',HYas=" + HYasTb.Text + ",HKilo=" + HKiloTb.Text + ",HTelefon='" + HTelefonTb.Text + "',HCinsiyet='" + HCinsCb.SelectedItem.ToString() + "',HKGrup='" + HKGrupCb.SelectedItem.ToString() + "',HMail='" + HMailTb.Text + "',HAdres='" + HAdresTb.Text + "',HBilgi='" + HBilgiTb.Text + "'where HNum=" + key + ";";

                    // HNum,HAdsoyad,HYas,HTelefon,HCinsiyet,HKGrup,HMail,HAdres

                    string query7 = "update HastailetisimBilgileriTbl set HAdsoyad='" + HAdSoyadTb.Text + "',HYas='" + HYasTb.Text + "',HTelefon='" + HTelefonTb.Text + "',HCinsiyet='" + HCinsCb.SelectedItem.ToString() + "',HKGrup='" + HKGrupCb.SelectedItem.ToString() + "',HMail='" + HMailTb.Text + "',HAdres='" + HAdresTb.Text + "'where HNum=" + key + ";";



                    baglanti.Open();

                    SqlCommand komut = new SqlCommand(query, baglanti);
                    SqlCommand liste7 = new SqlCommand(query7, baglanti);
                    komut.ExecuteNonQuery();
                    liste7.ExecuteNonQuery();
                    MessageBox.Show("Hasta Başarıyla Güncellendi");
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

        private void HSilBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Silinecek hastayı Seçiniz");
            }
            else
            {
                try
                {
                    string query = "update HastaTbl set HSil= 1 where HNum=" + key + ";";
                    string query8 = "update HastailetisimBilgileriTbl set HSil= 1 where HNum=" + key + ";";

                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    SqlCommand liste8 = new SqlCommand(query8, baglanti);
                    komut.ExecuteNonQuery();
                    liste8.ExecuteNonQuery();

                    MessageBox.Show("Hasta Başarıyla Silindi");
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

        private void label2_Click(object sender, EventArgs e)
        {
            Donor dr = new Donor();
            dr.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DonorListesi dr = new DonorListesi();
            dr.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            KanBagısı dr = new KanBagısı();
            dr.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            KanStogu dr = new KanStogu();
            dr.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            KanTransferi dr = new KanTransferi();
            dr.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HastaListesi HL = new HastaListesi();
            HL.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Hasta ha = new Hasta();
            ha.Show();
            this.Hide();

        }

        private void label23_Click(object sender, EventArgs e)
        {
            LaboratuvardaTestEdilecekKanlar ha = new LaboratuvardaTestEdilecekKanlar();
            ha.Show();
            this.Hide();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            LaboratuvardaTestiGecenKanlar ha = new LaboratuvardaTestiGecenKanlar();
            ha.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            imhaEdilenKanlarTbl ha = new imhaEdilenKanlarTbl();
            ha.Show();
            this.Hide();

        }
    }
}

