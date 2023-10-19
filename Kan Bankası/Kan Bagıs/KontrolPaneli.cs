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
    public partial class KontrolPaneli : Form
    {
        public KontrolPaneli()
        {
            InitializeComponent();
            VeriCek();
        }
        SqlConnection baglanti = new SqlConnection(ConfigurationManager.AppSettings["Baglanti"]);
        private void VeriCek()
        {
            baglanti.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*)  from DonorTbl", baglanti);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DonorLbl.Text = dt.Rows[0][0].ToString();
              
            SqlDataAdapter sda1 = new SqlDataAdapter("select count(*)  from TransferTbl", baglanti);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            TransferLbl.Text = dt1.Rows[0][0].ToString();

            SqlDataAdapter sda2 = new SqlDataAdapter("select count(*)  from KullanıcıTbl", baglanti);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            KullaniciLbl.Text = dt2.Rows[0][0].ToString();

            SqlDataAdapter sda12 = new SqlDataAdapter("select count(*)  from PersonelTbl", baglanti);
            DataTable dt12 = new DataTable();
            sda12.Fill(dt12);
            PersonelLbl.Text = dt12.Rows[0][0].ToString();

            SqlDataAdapter sda3 = new SqlDataAdapter("select sum(KStok)  from KanTbl", baglanti);
            DataTable dt3= new DataTable();
            sda3.Fill(dt3);
            int Kstok = Convert.ToInt32(dt3.Rows[0][0].ToString());

            SqlDataAdapter sda4 = new SqlDataAdapter("select KStok  from KanTbl where KGrup='"+"0+"+"'", baglanti);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            OplusLbl.Text = dt4.Rows[0][0].ToString();
            double OplusPercentage = (Convert.ToDouble(dt4.Rows[0][0].ToString())/Kstok*100);
            OplusBar.Value = Convert.ToInt32(OplusPercentage);

            SqlDataAdapter sda5 = new SqlDataAdapter("select KStok  from KanTbl where KGrup='" + "AB+" + "'", baglanti);
            DataTable dt5 = new DataTable();
            sda5.Fill(dt5);
            ABplusLbl.Text = dt5.Rows[0][0].ToString();
            double ABplusPercentage = (Convert.ToDouble(dt5.Rows[0][0].ToString()) / Kstok * 100);
            ABplusBar.Value = Convert.ToInt32(ABplusPercentage);

            SqlDataAdapter sda6 = new SqlDataAdapter("select KStok  from KanTbl where KGrup='" + "0-" + "'", baglanti);
            DataTable dt6 = new DataTable();
            sda6.Fill(dt6);
            OnegativeLbl.Text = dt6.Rows[0][0].ToString();
            double OminutesPercentage = (Convert.ToDouble(dt6.Rows[0][0].ToString()) / Kstok * 100);
            OminBar.Value = Convert.ToInt32(OminutesPercentage);

            SqlDataAdapter sda7 = new SqlDataAdapter("select KStok  from KanTbl where KGrup='" + "AB-" + "'", baglanti);
            DataTable dt7 = new DataTable();
            sda7.Fill(dt7);
            ABnegativeLbl.Text = dt7.Rows[0][0].ToString();
            double ABminutesPercentage = (Convert.ToDouble(dt7.Rows[0][0].ToString()) / Kstok * 100);
            ABminBar.Value = Convert.ToInt32(ABminutesPercentage);

            SqlDataAdapter sda8 = new SqlDataAdapter("select KStok  from KanTbl where KGrup='" + "A+" + "'", baglanti);
            DataTable dt8 = new DataTable();
            sda8.Fill(dt8);
            AplusLbl.Text = dt8.Rows[0][0].ToString();
            double AplusPercentage = (Convert.ToDouble(dt8.Rows[0][0].ToString()) / Kstok * 100);
            AplusBar.Value = Convert.ToInt32(AplusPercentage);

            SqlDataAdapter sda9 = new SqlDataAdapter("select KStok  from KanTbl where KGrup='" + "B+" + "'", baglanti);
            DataTable dt9 = new DataTable();
            sda9.Fill(dt9);
            BplusLbl.Text = dt9.Rows[0][0].ToString();
            double BplusPercentage = (Convert.ToDouble(dt9.Rows[0][0].ToString()) / Kstok * 100);
            BplusBar.Value = Convert.ToInt32(BplusPercentage);

            SqlDataAdapter sda10 = new SqlDataAdapter("select KStok  from KanTbl where KGrup='" + "A-" + "'", baglanti);
            DataTable dt10 = new DataTable();
            sda10.Fill(dt10);
            AnegativeLbl.Text = dt10.Rows[0][0].ToString();
            double AminutesPercentage = (Convert.ToDouble(dt10.Rows[0][0].ToString()) / Kstok * 100);
            AminBar.Value = Convert.ToInt32(AminutesPercentage);

            SqlDataAdapter sda11 = new SqlDataAdapter("select KStok  from KanTbl where KGrup='" + "B-" + "'", baglanti);
            DataTable dt11 = new DataTable();
            sda11.Fill(dt11);
            BnegativeLbl.Text = dt11.Rows[0][0].ToString();
            double BminutesPercentage = (Convert.ToDouble(dt11.Rows[0][0].ToString()) / Kstok * 100);
            BminBar.Value = Convert.ToInt32(BminutesPercentage);


            baglanti.Close();
            TotalLbl.Text = ""+Kstok;
        }

        private void KontrolPaneli_Load(object sender, EventArgs e)
        {

        }

       

        private void label9_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Kullanıcı kul = new Kullanıcı();
            kul.Show();
            this.Hide();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            PersonelEkle kul = new PersonelEkle();
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

        private void label12_Click(object sender, EventArgs e)
        {
            DonoriletisimBilgileri kul = new DonoriletisimBilgileri();
            kul.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            HastailetisimBilgileri kul = new HastailetisimBilgileri();
            kul.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            ikram kul = new ikram();
            kul.Show();
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Hastane kul = new Hastane();
            kul.Show();
            this.Hide();
        }

       
    }
}
