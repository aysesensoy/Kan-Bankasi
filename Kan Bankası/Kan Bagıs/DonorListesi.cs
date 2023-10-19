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
    public partial class DonorListesi : Form
    {
        public DonorListesi()
        {
            InitializeComponent();
            uyeler();
        }
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.AppSettings["Baglanti"]);
        private void uyeler()

        {
            baglanti.Open();
            string query = "select *from DonorTbl where DSil=0";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DonorDGV.DataSource = ds.Tables[0];
            DonorDGV.Columns[12].Visible = false;
            baglanti.Close();
        }


     



        int key = 0;
        private void DonorDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DTcNoTb.Text = DonorDGV.SelectedRows[0].Cells[1].Value.ToString();
            DAdSoyadTb.Text = DonorDGV.SelectedRows[0].Cells[2].Value.ToString();
            DYasTb.Text = DonorDGV.SelectedRows[0].Cells[3].Value.ToString();
            DKiloTb.Text = DonorDGV.SelectedRows[0].Cells[4].Value.ToString();
            DTelefonTb.Text = DonorDGV.SelectedRows[0].Cells[5].Value.ToString();
            DCinsCb.Text = DonorDGV.SelectedRows[0].Cells[6].Value.ToString();
            DKGrupCb.Text = DonorDGV.SelectedRows[0].Cells[7].Value.ToString();
            DMailTb.Text = DonorDGV.SelectedRows[0].Cells[8].Value.ToString();
            DAdresTb.Text = DonorDGV.SelectedRows[0].Cells[9].Value.ToString();
            DBilgiTb.Text = DonorDGV.SelectedRows[0].Cells[10].Value.ToString();
            DPersonelCb.Text = DonorDGV.SelectedRows[0].Cells[11].Value.ToString();



            if (DAdSoyadTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(DonorDGV.SelectedRows[0].Cells[0].Value.ToString());
            }


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
            key = 0;
        }

        private void DDuzenleBtn_Click(object sender, EventArgs e)
        {
            if (DTcNoTb.Text == "" || DAdSoyadTb.Text == "" || DYasTb.Text == "" || DCinsCb.SelectedIndex == -1 || DTelefonTb.Text == "" || DKGrupCb.SelectedIndex == -1 || DAdresTb.Text == "" || DMailTb.Text == "" || DKiloTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {

                string query1 = "update DonoriletisimBilgileriTbl set DAdsoyad='" + DAdSoyadTb.Text + "',DYas='" + DYasTb.Text + "',DTelefon='" + DTelefonTb.Text + "',DCinsiyet='" + DCinsCb.SelectedItem.ToString() + "',DKGrup='" + DKGrupCb.SelectedItem.ToString() + "',DMail='" + DMailTb.Text + "',DAdres='" + DAdresTb.Text + "'where DNum=" + key + ";";

                string query2 = "update DonorTbl set DTcNo='" + DTcNoTb.Text + "',DAdsoyad='" + DAdSoyadTb.Text +
                                     "',DYas=" + DYasTb.Text + ",DKilo=" + DKiloTb.Text + ",DTelefon='" + DTelefonTb.Text + "',DCinsiyet='" + DCinsCb.SelectedItem.ToString() + "',DKGrup='" + DKGrupCb.SelectedItem.ToString() + "',DMail='" + DMailTb.Text + "',DAdres='" + DAdresTb.Text + "',DBilgi='" + DBilgiTb.Text + "'where DNum=" + key + ";";

                string query3 = "update LaboratuvardaTestEdilecekKanlarTbl set LKGrup='" + DKGrupCb.SelectedItem.ToString() + "',LTcNo='" + DTcNoTb.Text + "',LDonorAdSoyad='" + DAdSoyadTb.Text + "',LAcıklama='" + DBilgiTb.Text + "'where LNum=" + key + ";";


                baglanti.Open();
                Reset();
                SqlCommand komut1 = new SqlCommand(query1, baglanti);
                SqlCommand komut2 = new SqlCommand(query2, baglanti);
                SqlCommand komut3 = new SqlCommand(query3, baglanti);
                komut1.ExecuteNonQuery();
                komut2.ExecuteNonQuery();
                komut3.ExecuteNonQuery();
               
                
                MessageBox.Show("Donor Başarıyla Güncellendi");
                baglanti.Close();
                uyeler();

            }

        }

        private void DSilBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Silinecek donoru Seçiniz");
            }
            else
            {
                try
                {
                    string query = "update DonorTbl set DSil= 1 where DNum=" + key + ";";
                    string query6 = "update DonoriletisimBilgileriTbl set DSil= 1 where DNum=" + key + ";";
                    string query7 = "update LaboratuvardaTestEdilecekKanlarTbl set LSil= 1 where LNum=" + key + ";";


                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    SqlCommand liste6 = new SqlCommand(query6, baglanti);
                    SqlCommand liste7 = new SqlCommand(query7, baglanti);
                    liste6.ExecuteNonQuery();
                    liste7.ExecuteNonQuery();
                    MessageBox.Show("Donor Başarıyla Silindi");
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

        private void DonorListesi_Load(object sender, EventArgs e)
        {
            DonorDGV.Columns[0].HeaderText = "ID";
            DonorDGV.Columns[1].HeaderText = "TC";
            DonorDGV.Columns[2].HeaderText = "İsim,Soyisim";
            DonorDGV.Columns[3].HeaderText = "Yaş";
            DonorDGV.Columns[4].HeaderText = "Kilo";
            DonorDGV.Columns[5].HeaderText = "Telefon Numarası";
            DonorDGV.Columns[6].HeaderText = "Cinsiyet";
            DonorDGV.Columns[7].HeaderText = "Kan Grubu";
            DonorDGV.Columns[8].HeaderText = "E-Mail";
            DonorDGV.Columns[9].HeaderText = "Adres";
            DonorDGV.Columns[10].HeaderText = "Bilgi";
            DonorDGV.Columns[11].HeaderText = "Personel";
            DonorDGV.Columns[12].HeaderText = "Verilen Tarih";
           
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
