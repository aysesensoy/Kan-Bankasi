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

namespace Kan_Bankası.Kan_Bagıs
{
    public partial class KanBagısı : Form
    {
        public KanBagısı()
        {
            InitializeComponent();
            uyeler();
            KanStok();
        }
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.AppSettings["Baglanti"]);

        private void uyeler()

        {
            baglanti.Open();
            string query = "select *from DonorTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            KBagısıDGV.DataSource = ds.Tables[0];
            KBagısıDGV.Columns[12].Visible = false;
            KBagısıDGV.Columns[4].Visible = false;
            KBagısıDGV.Columns[5].Visible = false;
            KBagısıDGV.Columns[6].Visible = false;
            KBagısıDGV.Columns[8].Visible = false;
            KBagısıDGV.Columns[9].Visible = false;
            KBagısıDGV.Columns[1].Visible = false;
            KBagısıDGV.Columns[3].Visible = false;

            baglanti.Close();
        }


        private void KanStok()

        {
            baglanti.Open();
            string query = "select *from KanTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            KStoguDGV.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        int eskistok;
        private void Stok(string Kgrup)
        {
            baglanti.Open();
            string query = "select *from KanTbl where KGrup='" + Kgrup + "'";
            SqlCommand komut = new SqlCommand(query, baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                eskistok = Convert.ToInt32(dr["KStok"].ToString());
            }
            baglanti.Close();
        }

        private void KBagısıDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DAdSoyadTb.Text = KBagısıDGV.SelectedRows[0].Cells[2].Value.ToString();
            DKGrubuTb.Text = KBagısıDGV.SelectedRows[0].Cells[7].Value.ToString();
            Stok(DKGrubuTb.Text);
        }
        private void Reset()
        {
            DAdSoyadTb.Text = "";
            DKGrubuTb.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DAdSoyadTb.Text == "")
            {
                MessageBox.Show("Bir Donor Seçiniz");
            }
            else
            {
                try
                {
                    int stok = eskistok+1;
                    string query = "update KanTbl set KStok='" + stok + "' where KGrup='" + DKGrubuTb.Text + "';";
                    baglanti.Open();

                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Bağış Başarılı");
                    baglanti.Close();
                    Reset();
                    KanStok();

                }
                catch (Exception Ex)
                {

                    MessageBox.Show("Ex.Message");
                }
            }
        }

        private void KStoguDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void label12_Click(object sender, EventArgs e)
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

        private void label16_Click(object sender, EventArgs e)
        {
            LaboratuvardaTestiGecenKanlar log = new LaboratuvardaTestiGecenKanlar();
            log.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            imhaEdilenKanlarTbl log = new imhaEdilenKanlarTbl();
            log.Show();
            this.Hide();
        }

        private void KanBagısı_Load(object sender, EventArgs e)
        {
            KStoguDGV.Columns[0].HeaderText = "Kan Grubu";
            KStoguDGV.Columns[1].HeaderText = "Stok Adeti";

            KBagısıDGV.Columns[0].HeaderText = "ID";
            KBagısıDGV.Columns[1].HeaderText = "İsim,Soyisim";
            KBagısıDGV.Columns[2].HeaderText = "İsim,Soyisim";
            KBagısıDGV.Columns[3].HeaderText = "Bilgi";
            KBagısıDGV.Columns[4].HeaderText = "Personel";
            KBagısıDGV.Columns[5].HeaderText = "Tarih";
        }
    }
}
