using Kan_Bankası.OrganBagısAyse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kan_Bankası.Kan_Bagıs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void label6_Click(object sender, EventArgs e)
        {
            Anasayfa log = new Anasayfa();
            log.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            saglık dr = new saglık();
            dr.Show();
            this.Hide();
        }

        private void EnYakınHastaneBtn_Click(object sender, EventArgs e)
        {
            enyakınmekanlar dr = new enyakınmekanlar();
            dr.Show();
            this.Hide();
        }

        private void EnYakınEczaneBtn_Click(object sender, EventArgs e)
        {
            enyakınmekanlar dr = new enyakınmekanlar();
            dr.Show();
            this.Hide();
        }

        private void EnYakınKanMerkeziBtn_Click(object sender, EventArgs e)
        {
            enyakınmekanlar dr = new enyakınmekanlar();
            dr.Show();
            this.Hide();
        }

        private void EnYakınOrganBağısMerkeziBtn_Click(object sender, EventArgs e)
        {
            enyakınmekanlar dr = new enyakınmekanlar();
            dr.Show();
            this.Hide();
        }

        private void BizKimizBtn_Click(object sender, EventArgs e)
        {
            bizkimiz kt = new bizkimiz();
            kt.Show();
            this.Hide();
        }

        private void İletişimBtn_Click(object sender, EventArgs e)
        {
            iletisim kt = new iletisim();
            kt.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            OrganAnasayfaObs log = new OrganAnasayfaObs();
            log.Show();
            this.Hide();
        }

    }
}
