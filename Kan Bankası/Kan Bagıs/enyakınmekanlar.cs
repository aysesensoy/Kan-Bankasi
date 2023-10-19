
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kan_Bankası.Kan_Bagıs
{
    public partial class enyakınmekanlar : Form
    {
        public enyakınmekanlar()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            webView1.Url = "https://www.google.com/maps/search/" + textBox1.Text;
        }

        private void GeriBtn_Click(object sender, EventArgs e)
        {
            Form1 dr = new Form1();
            dr.Show();
            this.Hide();
        }
    }
}
