using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Kan_Bankası.Kan_Bagıs
{
    public partial class ikram : Form
    {
        public ikram()
        {
            InitializeComponent();
            durum();
        }


        SqlConnection baglanti = new SqlConnection(ConfigurationManager.AppSettings["Baglanti"]);


        private void ekle()

        {
            
            string query6 = "update İkramDurumuTbl set İkramKekStok='" + textBox1.Text + "',İkramMeyvesuyuStok='" + textBox2.Text + "' ;";

            baglanti.Open();
            SqlCommand liste6 = new SqlCommand(query6, baglanti);
            liste6.ExecuteNonQuery();
            baglanti.Close();

        }

        private void durum()

        {
        
            label7.Text = " ";
            label8.Text = " ";
            SqlCommand komut = new SqlCommand("select *from İkramDurumuTbl",baglanti);
            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
            label7.Text = dr.GetValue(0).ToString();
            label8.Text = dr.GetValue(1).ToString();

            }

            baglanti.Close();

        }


        private void MeyveSuyuBtn_Click(object sender, EventArgs e)
        {
            ekle();
            MessageBox.Show("Eklendi");
            textBox1.Text = "";
            textBox2.Text = "";
            durum();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kullanıcı HL = new Kullanıcı();
            HL.Show();
            this.Hide();
        }
    }

}
