using Kan_Bankası.Kan_Bagıs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kan_Bankası.OrganBagısAyse
{
    public partial class OrganSilinenHastalar : Form
    {
        public OrganSilinenHastalar()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Kullanıcı log = new Kullanıcı();
            log.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            PersonelEkle log = new PersonelEkle();
            log.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            OrganSilinenDonorler log = new OrganSilinenDonorler();
            log.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            OrganSilinenHastalar log = new OrganSilinenHastalar();
            log.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            OrganDonorİletisimBilgileriObs log = new OrganDonorİletisimBilgileriObs();
            log.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            OrganHastaİletişimBilgileriObs log = new OrganHastaİletişimBilgileriObs();
            log.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            KontrolPaneli log = new KontrolPaneli();
            log.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            OrganAnasayfaObs log = new OrganAnasayfaObs();
            log.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
