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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Kan_Bankası
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Login log=new Login();
            log.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AdminSifreTb.Text == "")
            {
                MessageBox.Show("Admin Şifreni Giriniz");
            }
            else if (AdminSifreTb.Text == "1594")
            {
                Kullanıcı cal = new Kullanıcı();
                cal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yanlış Şifre");
                AdminSifreTb.Text = "";
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
