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
    public partial class bizkimiz : Form
    {
        public bizkimiz()
        {
            InitializeComponent();
        }

        private void bizkimiz_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;
            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;
            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;
            label5.Parent = pictureBox1;
            label5.BackColor = Color.Transparent;
            pictureBox2.Parent = pictureBox1;
            pictureBox2.BackColor = Color.Transparent;
            
            GeriBtn.Parent = pictureBox1;
            GeriBtn.BackColor = Color.Transparent;
        }

        private void GeriBtn_Click(object sender, EventArgs e)
        {
            Form1 dr = new Form1();
            dr.Show();
            this.Hide();
        }
    }
}
