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
using System;
using System.Net;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Interop;
using System.Windows.Input;

namespace Kan_Bankası
{
    public partial class Donor : Form
    {

        public Donor()
        {
            InitializeComponent();
            personel();
        }
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.AppSettings["Baglanti"]);


        private void personel()

        {
            baglanti.Open();
            SqlCommand doldur = new SqlCommand("select PerAdSoyad from PersonelTbl", baglanti);
            SqlDataReader dr = doldur.ExecuteReader();
            while (dr.Read())
            {
                DPersonelCb.Items.Add(dr[0]);
            }
            baglanti.Close();
        }


        private void Reset()
        {
            DTcNoTb.Text = "";
            DAdSoyadTb.Text = "";
            DYasTb.Text = "";
            DCinsCb.SelectedIndex = -1;
            DKiloTb.Text = "";
            DTelefonTb.Text = "";
            DAdresTb.Text = "";
            DKGrupCb.SelectedIndex = -1;
            DMailTb.Text = "";
            DBilgiTb.Text = "";
            DPersonelCb.SelectedIndex = -1;
        }




        private void button1_Click_1(object sender, EventArgs e)
        {

            MailMessage mesaj = new MailMessage();
            mesaj.From = new MailAddress("sagliktransfermerkezi@outlook.com");
            mesaj.To.Add(DMailTb.Text);
            mesaj.Subject = "Saglık Transfer Merkezi";
            mesaj.Body = "Teşekkürler";

            SmtpClient a = new SmtpClient();
            a.Credentials = new System.Net.NetworkCredential("sagliktransfermerkezi@outlook.com", "erp14!!!");
            a.Port = 587;
            a.Host = "smtp.office365.com";
            a.EnableSsl = true;
            object userState = mesaj;

            try
            {
                a.SendAsync(mesaj, (object)mesaj);
                MessageBox.Show("Mail Gönderilmiştir" + DMailTb.Text);
            }

            catch (SmtpException ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
            }



            if (DTcNoTb.Text == "" || DAdSoyadTb.Text == "" || DYasTb.Text == "" || DCinsCb.SelectedIndex == -1 || DTelefonTb.Text == "" || DKGrupCb.SelectedIndex == -1 || DAdresTb.Text == "" || DKiloTb.Text == "" || DPersonelCb.SelectedIndex == -1)

            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    string tarihSaat = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string query = "insert into DonorTbl values('" + DTcNoTb.Text + "','" + DAdSoyadTb.Text + "'," + DYasTb.Text + ",'" + DKiloTb.Text + "','" + DTelefonTb.Text + "','" + DCinsCb.SelectedItem.ToString() + "','" + DKGrupCb.SelectedItem.ToString() + "','" + DMailTb.Text + "','" + DAdresTb.Text + "','" + DBilgiTb.Text + "','" + DPersonelCb.SelectedItem.ToString() + "','" + false + "','" + tarihSaat + "')";



                    string query4 = "insert into DonoriletisimBilgileriTbl values('" + DAdSoyadTb.Text + "','" + DYasTb.Text + "','" + DTelefonTb.Text + "','" + DCinsCb.SelectedItem.ToString() + "','" + DKGrupCb.SelectedItem.ToString() + "','" + DMailTb.Text + "','" + DAdresTb.Text + "','" + false + "')";


                    //LKanID,LKGrup,LTcNo,LDonorAdSoyad,LTarih,LPersonelAdSoyad,LSonuc,LAcıklama,LSil

                    string query6 = "insert into LaboratuvardaTestEdilecekKanlarTbl values('" + DKGrupCb.SelectedItem.ToString() + "','" + DTcNoTb.Text + "','" + DAdSoyadTb.Text + "','" + tarihSaat + "','" + DPersonelCb.SelectedItem.ToString() + "','" + false + "','" + DBilgiTb.Text + "','" + false + "','" + null+ "')";

                    baglanti.Open();
                    Reset();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    SqlCommand liste4 = new SqlCommand(query4, baglanti);
                    SqlCommand liste6 = new SqlCommand(query6, baglanti);
                    komut.ExecuteNonQuery();
                    liste4.ExecuteNonQuery();
                    liste6.ExecuteNonQuery();

                    MessageBox.Show("Donor Başarıyla Kayı Edildi");
                    baglanti.Close();

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

        private void label4_Click(object sender, EventArgs e)
        {
            Hasta dr = new Hasta();
            dr.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HastaListesi dr = new HastaListesi();
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

        private void label7_Click(object sender, EventArgs e)
        {
            KanTransferi dr = new KanTransferi();
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

        private void label23_Click(object sender, EventArgs e)
        {
            LaboratuvardaTestiGecenKanlar log = new LaboratuvardaTestiGecenKanlar();
            log.Show();
            this.Hide();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            imhaEdilenKanlarTbl log = new imhaEdilenKanlarTbl();
            log.Show();
            this.Hide();
        }

     
    }
}
