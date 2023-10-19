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

namespace Kan_Bankası
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
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

     

        private void label9_Click(object sender, EventArgs e)
        {
            Login log= new Login();
            log.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            KanTransferi log = new KanTransferi();
            log.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            LaboratuvardaTestEdilecekKanlar log = new LaboratuvardaTestEdilecekKanlar();
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
    }
}
