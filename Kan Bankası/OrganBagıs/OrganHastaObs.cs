using Kan_Bankası.OrganBagıs;
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
    public partial class OrganHastaObs : Form
    {
        public OrganHastaObs()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            OrganDonorObs dr = new OrganDonorObs();
            dr.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            OrganDonorListesiObs dr = new OrganDonorListesiObs();
            dr.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            OrganHastaObs dr = new OrganHastaObs();
            dr.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            OrganHastaListesi dr = new OrganHastaListesi();
            dr.Show();
            this.Hide();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            OrganBagıs dr = new OrganBagıs();
            dr.Show();
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            OrganStok dr = new OrganStok();
            dr.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            OrganTransfer dr = new OrganTransfer();
            dr.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            OrganLaboratuvaraGidecekOrganlar dr = new OrganLaboratuvaraGidecekOrganlar();
            dr.Show();
            this.Hide();
        }

        private void label23_Click(object sender, EventArgs e)
        {
            OrganTestiGeçenOrganlar dr = new OrganTestiGeçenOrganlar();
            dr.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            OrganİmhaOrgan dr = new OrganİmhaOrgan();
            dr.Show();
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
