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
using Kan_Bankası.Kan_Bagıs;
using System.Configuration;

namespace Kan_Bankası
{
    public partial class Hasta : Form
    {
        public Hasta()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.AppSettings["Baglanti"]);
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (HTcNoTb.Text == "" || HAdSoyadTb.Text == "" || HYasTb.Text == "" || HCinsCb.SelectedIndex == -1 || HTelefonTb.Text == "" || HKGrupCb.SelectedIndex == -1 || HAdresTb.Text == "" || HKiloTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    string tarihSaat = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string query = "insert into HastaTbl values('" + HTcNoTb.Text + "','" + HAdSoyadTb.Text + "'," + HYasTb.Text + ",'" + HKiloTb.Text + "','" + HTelefonTb.Text + "','" + HCinsCb.SelectedItem.ToString() + "','" + HKGrupCb.SelectedItem.ToString() + "','" + HMailTb.Text + "','" + HAdresTb.Text + "','" + HBilgiTb.Text + "','" + false + "','" + tarihSaat + "')";

                    string query2 = "insert into HastailetisimBilgileriTbl values('" + HAdSoyadTb.Text + "','" + HYasTb.Text + "','" + HTelefonTb.Text + "','" + HCinsCb.SelectedItem.ToString() + "','" + HKGrupCb.SelectedItem.ToString() + "','" + HMailTb.Text + "','" + HAdresTb.Text + "','" + false + "')";



                    baglanti.Open();
                    Reset();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    SqlCommand liste2 = new SqlCommand(query2, baglanti);
                    komut.ExecuteNonQuery();
                    liste2.ExecuteNonQuery();
                    MessageBox.Show("Hasta Başarıyla Kayıt Edildi");
                    baglanti.Close();

                }

                catch (Exception Ex)
                {

                    MessageBox.Show("Ex.Message");
                }


               // HNum,HAdsoyad,HYas,HTelefon,HCinsiyet,HKGrup,HMail,HAdres


            }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            HastaListesi HL = new HastaListesi();
            HL.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            KanTransferi kt = new KanTransferi();
            kt.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor dr = new Donor();
            dr.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Hasta dr = new Hasta();
            dr.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DonorListesi dr = new DonorListesi();
            dr.Show();
            this.Hide();

        }

        private void label20_Click(object sender, EventArgs e)
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



        private void label9_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            LaboratuvardaTestEdilecekKanlar log = new LaboratuvardaTestEdilecekKanlar();
            log.Show();
            this.Hide();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            LaboratuvardaTestiGecenKanlar log = new LaboratuvardaTestiGecenKanlar();
            log.Show();
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            imhaEdilenKanlarTbl log = new imhaEdilenKanlarTbl();
            log.Show();
            this.Hide();
        }

       
    }

}
