using Kan_Bankası.Kan_Bagıs;
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

namespace Kan_Bankası
{
    public partial class KanTransferi : Form
    {
        public KanTransferi()
        {
            InitializeComponent();
            fillHastaCb();
        }

        SqlConnection baglanti = new SqlConnection(ConfigurationManager.AppSettings["Baglanti"]);
        private void fillHastaCb()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select HNum from HastaTbl", baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("HNum", typeof(int));
            dt.Load(rdr);
            HastaIdCb.ValueMember = "HNum";
            HastaIdCb.DataSource = dt;
            baglanti.Close();
        }


        int stokk = 0;
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
                stokk = Convert.ToInt32(dr["KStok"].ToString());
            }
            baglanti.Close();
        }

        private void VeriAl()
        {
            baglanti.Open();
            string query = "select *from HastaTbl where HNum=" + HastaIdCb.SelectedValue.ToString() + "";
            SqlCommand komut = new SqlCommand(query, baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                HasAdTb.Text = dr["HAdSoyad"].ToString();
                KanGrupTb.Text = dr["HKGrup"].ToString();
            }
            baglanti.Close();
        }

        private void HastaIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            VeriAl();
            Stok(KanGrupTb.Text);
            if (stokk > 0)
            {
                TransferBtn.Visible = true;
                UygunLbl.Text = "Stok Uygun";
                UygunLbl.Visible = true;
            }
            else
            {
                TransferBtn.Visible = false;
                UygunLbl.Text = "Stok Uygun değil";
                UygunLbl.Visible = true;
            }
        }

      
        private void Reset()
        {
            HasAdTb.Text = "";
            KanGrupTb.Text = "";
            UygunLbl.Visible = false;
            TransferBtn.Visible = false;
        }

        private void kanGuncelle()
        {
            int yenistok = stokk - 1;
            try
            {
                string query = "update KanTbl set KStok=" + yenistok + " where KGrup='" + KanGrupTb.Text + "';";
                baglanti.Open();
                SqlCommand komut = new SqlCommand(query, baglanti);
                komut.ExecuteNonQuery();
                //MessageBox.Show("Hasta Başarıyla Güncellendi");
                baglanti.Close();
                
                

            }
            catch (Exception Ex)
            {

                MessageBox.Show("Ex.Message");
            }
        }

        private void TransferBtn_Click(object sender, EventArgs e)
        {

            if (HasAdTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    string query = "insert into TransferTbl values('" + HasAdTb.Text + "','" + KanGrupTb.Text + "')";
                    baglanti.Open();            
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Transfer Başarılı");
                    baglanti.Close();
                    Stok(KanGrupTb.Text);
                    kanGuncelle();
                    Reset();

                }
                catch (Exception Ex)
                {

                    MessageBox.Show("Ex.Message");
                }



            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            KanStogu ks = new KanStogu();
            ks.Show();
            this.Hide();

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

        private void label5_Click(object sender, EventArgs e)
        {
            HastaListesi dr = new HastaListesi();
            dr.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            KanBagısı dr = new KanBagısı();
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
            Login login = new Login();
            login.Show();
            this.Hide();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            Hasta ha = new Hasta();
            ha.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            LaboratuvardaTestEdilecekKanlar ha = new LaboratuvardaTestEdilecekKanlar();
            ha.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
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

        private void KanTransferi_Load(object sender, EventArgs e)
        {

        }
    }
}
