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
    public partial class iletisim : Form
    {
        public iletisim()
        {
            InitializeComponent();
        }

        private void iletisim_Load(object sender, EventArgs e)
        {
            webView1.Url = "https://www.google.com/maps/place/Bili%C5%9Fim+E%C4%9Fitim+Merkezi/@40.9890888,29.028605,17z/data=!4m6!3m5!1s0x14cab9641f756bfd:0x418dd51bda331fa5!8m2!3d40.9891334!4d29.0289269!16s%2Fg%2F11s8tjj5nx";
        }

        private void GeriBtn_Click(object sender, EventArgs e)
        {
            Form1 dr = new Form1();
            dr.Show();
            this.Hide();
        }
    }
}
