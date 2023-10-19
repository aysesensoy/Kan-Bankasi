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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kan_Bankası.Kan_Bagıs
{
    public partial class LaboratuvardaTestEdilecekKanlar : Form
    {
        public LaboratuvardaTestEdilecekKanlar()
        {
            InitializeComponent();
            uyeler();
        }
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.AppSettings["Baglanti"]);

        private void uyeler()
        {
            baglanti.Open();
            string query = "select *from LaboratuvardaTestEdilecekKanlarTbl where LSil=0";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            LaboratuvarGidenDGV.DataSource = ds.Tables[0];
            LaboratuvarGidenDGV.Columns[8].Visible = false;
            LaboratuvarGidenDGV.Columns[6].Visible = false;
            baglanti.Close();
        }
        private void ara()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM LaboratuvardaTestEdilecekKanlarTbl WHERE LDonorAdSoyad LIKE @search", baglanti);
            da.SelectCommand.Parameters.AddWithValue("@search", "%" + LabaGidenAraTb.Text + "%");
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            LaboratuvarGidenDGV.DataSource = tablo;
            baglanti.Close();
        }
        private void yenile()
        {
            baglanti.Open();
            string query = "select *from LaboratuvardaTestEdilecekKanlarTbl where LSil=0";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            LaboratuvarGidenDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void LabaGidnAraBtn_Click(object sender, EventArgs e)
        {
            ara();
        }

        private void Reset()
        {
            labacıklamaTb.Text = "";
            key = 0;
        }



        int key = 0;
        private void LaboratuvarGidenDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            labacıklamaTb.Text = LaboratuvarGidenDGV.SelectedRows[0].Cells[7].Value.ToString();
           

            if (labacıklamaTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(LaboratuvarGidenDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string query1 = "update LaboratuvardaTestEdilecekKanlarTbl set LAcıklama='" + labacıklamaTb.Text + "' where LNum=" + key + ";";

            baglanti.Open();
            Reset();
            SqlCommand komut1 = new SqlCommand(query1, baglanti);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            yenile();

        }

        private void TestBtn_Click(object sender, EventArgs e)
        {
           
                Random rnd = new Random();
                int sayi = rnd.Next(0, 100);

                string querytest = "update LaboratuvardaTestEdilecekKanlarTbl set LKanSaglıkDegeri='" + sayi + "' where LNum=" + key + ";";

                baglanti.Open();
                SqlCommand komuttest = new SqlCommand(querytest, baglanti);
                komuttest.ExecuteNonQuery();
                baglanti.Close();
                

               
                 //int sonucu = Convert.ToInt32(sonucTb.Text);
            if (sayi < 40)
            {

                DataGridViewSelectedRowCollection selectedRows = LaboratuvarGidenDGV.SelectedRows;
                foreach (DataGridViewRow row in selectedRows)
                {
                    // Seçili satırdaki verileri al
                    string kangrup = row.Cells["LKGrup"].Value.ToString();
                    string tc = row.Cells["LTcNo"].Value.ToString();
                    string ad = row.Cells["LDonorAdSoyad"].Value.ToString();
                    string zamn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string personel = row.Cells["LPersonelAdSoyad"].Value.ToString();
                    bool lsonuc = Convert.ToBoolean(row.Cells["LSonuc"].Value);
                    string acıklama = row.Cells["LAcıklama"].Value.ToString();
                    bool lsil = Convert.ToBoolean(row.Cells["LSil"].Value);
                    int deger = Convert.ToInt32(sayi);

                    // SQL Server veritabanına ekle
                    string query = "INSERT INTO İmhaEdilenKanlarTbl (LKGrup, LTcNo, LDonorAdSoyad,LTarih,LPersonelAdSoyad,LSonuc,LAcıklama,LSil,LKanSaglıkDegeri) VALUES (@LKGrup, @LTcNo, @LDonorAdSoyad,@LTarih,@LPersonelAdSoyad,@LSonuc,@LAcıklama,@LSil,@LKanSaglıkDegeri)";

                    baglanti.Open();
                    using (SqlCommand command = new SqlCommand(query, baglanti))

                    {
                        command.Parameters.AddWithValue("@LKGrup", kangrup);
                        command.Parameters.AddWithValue("@LTcNo", tc);
                        command.Parameters.AddWithValue("@LDonorAdSoyad", ad);
                        command.Parameters.AddWithValue("@LTarih", zamn);
                        command.Parameters.AddWithValue("@LPersonelAdSoyad", personel);
                        command.Parameters.AddWithValue("@LSonuc", lsonuc);
                        command.Parameters.AddWithValue("@LAcıklama", acıklama);
                        command.Parameters.AddWithValue("@LSil", lsil);
                        command.Parameters.AddWithValue("@LKanSaglıkDegeri", deger);


                        command.ExecuteNonQuery();
                        baglanti.Close();

                    }
                }


            }
            else
            {
                DataGridViewSelectedRowCollection selectedRows = LaboratuvarGidenDGV.SelectedRows;
                foreach (DataGridViewRow row in selectedRows)
                {
                    // Seçili satırdaki verileri al
                    string kangrup = row.Cells["LKGrup"].Value.ToString();
                    string tc = row.Cells["LTcNo"].Value.ToString();
                    string ad = row.Cells["LDonorAdSoyad"].Value.ToString();
                    string zamn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string personel = row.Cells["LPersonelAdSoyad"].Value.ToString();
                    bool lsonuc = Convert.ToBoolean(row.Cells["LSonuc"].Value);
                    string acıklama = row.Cells["LAcıklama"].Value.ToString();
                    bool lsil = Convert.ToBoolean(row.Cells["LSil"].Value);
                    int deger = Convert.ToInt32(sayi);

                    // SQL Server veritabanına ekle
                    string query = "INSERT INTO LaboratuvardaTestiGecenKanlarTbl (LKGrup, LTcNo, LDonorAdSoyad,LTarih,LPersonelAdSoyad,LSonuc,LAcıklama,LSil,LKanSaglıkDegeri) VALUES (@LKGrup, @LTcNo, @LDonorAdSoyad,@LTarih,@LPersonelAdSoyad,@LSonuc,@LAcıklama,@LSil,@LKanSaglıkDegeri)";

                    baglanti.Open();
                    using (SqlCommand command = new SqlCommand(query, baglanti))

                    {
                        command.Parameters.AddWithValue("@LKGrup", kangrup);
                        command.Parameters.AddWithValue("@LTcNo", tc);
                        command.Parameters.AddWithValue("@LDonorAdSoyad", ad);
                        command.Parameters.AddWithValue("@LTarih", zamn);
                        command.Parameters.AddWithValue("@LPersonelAdSoyad", personel);
                        command.Parameters.AddWithValue("@LSonuc", lsonuc);
                        command.Parameters.AddWithValue("@LAcıklama", acıklama);
                        command.Parameters.AddWithValue("@LSil", lsil);
                        command.Parameters.AddWithValue("@LKanSaglıkDegeri", deger);


                        command.ExecuteNonQuery();
                        baglanti.Close();

                    }
                }


            }

            yenile();

        }

        


        private void label10_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DonorListesi log = new DonorListesi();
            log.Show();
            this.Hide();
        }
        private void label7_Click(object sender, EventArgs e)
        {
            KanTransferi log = new KanTransferi();
            log.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            KanStogu log = new KanStogu();
            log.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            KanBagısı log = new KanBagısı();
            log.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HastaListesi log = new HastaListesi();
            log.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Hasta log = new Hasta();
            log.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor log = new Donor();
            log.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            LaboratuvardaTestiGecenKanlar log = new LaboratuvardaTestiGecenKanlar();
            log.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            imhaEdilenKanlarTbl log = new imhaEdilenKanlarTbl();
            log.Show();
            this.Hide();
        }

        private void LaboratuvardaTestEdilecekKanlar_Load(object sender, EventArgs e)
        {
            LaboratuvarGidenDGV.Columns[0].HeaderText = "ID";
            LaboratuvarGidenDGV.Columns[1].HeaderText = "Kan Grubu";
            LaboratuvarGidenDGV.Columns[2].HeaderText = "TC No";
            LaboratuvarGidenDGV.Columns[3].HeaderText = "Donor İsim,Soyisim";
            LaboratuvarGidenDGV.Columns[4].HeaderText = "Tarih";
            LaboratuvarGidenDGV.Columns[5].HeaderText = "Personel Ad,Soyad";
            LaboratuvarGidenDGV.Columns[6].HeaderText = "Açıklama";
            LaboratuvarGidenDGV.Columns[7].HeaderText = "Kanın Sağlık Değeri";
        }
    }
    }

