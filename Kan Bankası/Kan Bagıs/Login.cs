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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(ConfigurationManager.AppSettings["Baglanti"]);
        private void label55_Click(object sender, EventArgs e)
        {
            AdminLogin adm = new AdminLogin();
            adm.Show();
            this.Hide();
        }

     


        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter sda=new SqlDataAdapter("Select count(*) from KullanıcıTbl where KulId='"+KullaniciTb.Text+"' and KulSif='"+SifreTb.Text+"'",baglanti);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Anasayfa ana = new Anasayfa();
                ana.Show();
                this.Hide();
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Yanlış Kullanıcı ya da Şifre");
            }
            baglanti.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
