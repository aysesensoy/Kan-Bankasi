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
    public partial class saglık : Form
    {
        public saglık()
        {
            InitializeComponent();
        }


        #region Bel Çevresi Risk Saptama Hesaplama Butonu

        private void BelCevresiRiskSaptamaBTN_Click_1(object sender, EventArgs e)
        {

            BelcevresiRiskLbl.Visible = true;
            BelCevresiDetayTxt.Visible = true;

            int belcevresi;
            belcevresi = Convert.ToInt32(BelcevresiTxt.Text);
            //if (comboBox1.SelectedItem == null || BelcevresiTxt.Text=="")     //2 seçecekten biri boşsa messageboxtaki uyarıyı versin
            //{
            //    MessageBox.Show("Lütfen Bilgileri Doldurunuz");
            //}
            if (comboBox1.SelectedItem == "Erkek")
            {
                if (belcevresi < 0)
                {
                    MessageBox.Show("Lütfen doğru rakam giriniz. Bel çevresi 0 dan düşük olamaz");
                }
                else if (belcevresi > 0 && belcevresi <= 94)
                {
                    BelcevresiRiskLbl.Text = "Normal";
                    BelCevresiDetayTxt.Text = "Erkeklerin bel çevresinin 94cm'den küçük olması normaldir.Yeterli ve dengeli beslenerek, düzenli aktivite yaparak formunuzu korumaya özen gösterin.";
                }
                else if (belcevresi > 94 && belcevresi <= 102)
                {
                    BelcevresiRiskLbl.Text = "Artmış Risk";
                    BelCevresiDetayTxt.Text = "Erkeklerin bel çevresinin 94cm'den büyük olması risklidir. Yeterli ve dengeli beslenerek, düzenli fiziksel aktivite yaparak boyunuza uygun ağırlığa ulaşmaya özen gösterin.";
                }
                else
                {


                    BelcevresiRiskLbl.Text = "Yüksek Risk";
                    BelCevresiDetayTxt.Text = "Erkeklerin bel çevresinin 102cm'den büyük olması şişmanlığın göstergesidir. Bu sağlığınız için risklidir. Lütfen bir sağlık kuruluşuna başvurunuz.";
                }

            }
            if (comboBox1.SelectedItem == "Kadın")
            {
                if (belcevresi < 0)
                {
                    MessageBox.Show("Lütfen doğru rakam giriniz. Bel çevresi 0 dan düşük olamaz");
                }
                else if (belcevresi > 0 && belcevresi <= 80)
                {
                    BelcevresiRiskLbl.Text = "Normal";
                    BelCevresiDetayTxt.Text = "Kadınların bel çevresinin 80cm'den küçük olması normaldir.Yeterli ve dengeli beslenerek, düzenli aktivite yaparak formunuzu korumaya özen gösterin.";
                }
                else if (belcevresi > 80 && belcevresi <= 88)
                {
                    BelcevresiRiskLbl.Text = "Artmış Risk";
                    BelCevresiDetayTxt.Text = "Kadınların bel çevresinin 80cm'den büyük olması risklidir. Yeterli ve dengeli beslenerek, düzenli fiziksel aktivite yaparak boyunuza uygun ağırlığa ulaşmaya özen gösterin.";
                }
                else
                {
                    BelcevresiRiskLbl.Text = "Yüksek Risk";
                    BelCevresiDetayTxt.Text = "Kadınların bel çevresinin 88cm'den büyük olması şişmanlığın göstergesidir. Bu sağlığınız için risklidir. Lütfen bir sağlık kuruluşuna başvurunuz.";
                }
            }
        }


        #endregion

        #region Beden Kütle İndeksi Hesaplama Butonu



        private void BEDENKütleHesaplaBtn_Click_1(object sender, EventArgs e)
        {
            label18.Visible = true;
            textBox5.Visible = true;

            double kütleindeksikütle, kütleindeksiboy, sonuc;
            kütleindeksikütle = Convert.ToDouble(textBox3.Text);
            kütleindeksiboy = Convert.ToDouble(textBox4.Text);
            kütleindeksiboy = kütleindeksiboy / 100;
            sonuc = kütleindeksikütle / (kütleindeksiboy * kütleindeksiboy);
            sonuc = Math.Round(sonuc, 1);

            if (sonuc <= 18.5)
            {
                label18.Text = sonuc + " Zayıf";
                textBox5.Text = "Boyunuza göre uygun ağırlıkta olmadığınızı, zayıf olduğunuzu gösterir. Zayıflık, bazı hastalıklar için risk oluşturan ve istenmeyen bir durumdur. " +
                    "Boyunuza uygun ağırlığa erişmeniz için yeterli ve dengeli beslenmeli, beslenme alışkanlıklarınızı geliştirmeye özen göstermelisiniz.";
            }
            else if (sonuc > 18.5 && sonuc <= 25)
            {
                label18.Text = sonuc + " Normal";
                textBox5.Text = "Boyunuza göre uygun ağırlıkta olduğunuzu gösterir. Yeterli ve dengeli beslenerek ve düzenli fiziksel " +
                    "aktivite yaparak bu ağırlığınızı korumaya özen gösteriniz.";
            }
            else if (sonuc > 25 && sonuc <= 30)
            {
                label18.Text = sonuc + " Şişman (Obez) - I. Sınıf";
                textBox5.Text = "Boyunuza göre vücut ağırlığınızın fazla olduğunu bir başka deyişle şişman olduğunuzun bir göstergesidir. Şişmanlık, " +
                    "kalp-damar hastalıkları, diyabet, hipertansiyon v.b. kronik hastalıklar için risk faktörüdür. Bir sağlık kuruluşuna başvurarak hekim / " +
                    "diyetisyen kontrolünde zayıflayarak normal ağırlığa inmeniz sağlığınız açısından çok önemlidir. Lütfen, sağlık kuruluşuna başvurunuz.";
            }
            else if (sonuc > 30 && sonuc <= 35)
            {
                label18.Text = sonuc + " Şişman (Obez) - II. Sınıf";
                textBox5.Text = "Boyunuza göre vücut ağırlığınızın fazla olduğunu bir başka deyişle şişman olduğunuzun bir göstergesidir. Şişmanlık, " +
                    "kalp-damar hastalıkları, diyabet, hipertansiyon v.b. kronik hastalıklar için risk faktörüdür. Bir sağlık kuruluşuna başvurarak hekim / " +
                    "diyetisyen kontrolünde zayıflayarak normal ağırlığa inmeniz sağlığınız açısından çok önemlidir. Lütfen, sağlık kuruluşuna başvurunuz.";
            }
            else
            {
                label18.Text = sonuc + " Şişman (Obez) - III. Sınıf";
                textBox5.Text = "Boyunuza göre vücut ağırlığınızın fazla olduğunu bir başka deyişle şişman olduğunuzun bir göstergesidir. Şişmanlık, " +
                    "kalp-damar hastalıkları, diyabet, hipertansiyon v.b. kronik hastalıklar için risk faktörüdür. Bir sağlık kuruluşuna başvurarak hekim / " +
                    "diyetisyen kontrolünde zayıflayarak normal ağırlığa inmeniz sağlığınız açısından çok önemlidir. Lütfen, sağlık kuruluşuna başvurunuz.";
            }
        }



        #endregion

        #region Aktiviteye Göre Harcanan Enerji Hesaplama Butonu



        private void AktiviteyeGöreEnerjiBtn_Click_1(object sender, EventArgs e)
        {

            label7.Visible = true;
            label8.Visible = true;


            double aktivitekilo, aktivitedakika, enerji;
            aktivitekilo = Convert.ToDouble(textBox1.Text);
            aktivitedakika = Convert.ToDouble(textBox2.Text);

            if (aktivitetürüCB.SelectedItem == "     Ayakta durmak")
            {
                enerji = 2 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Uyumak")
            {
                enerji = 0.95 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Yazı yazmak (elle)")
            {
                enerji = 1.4 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Yazı yazmak (bilgisayarda)")
            {
                enerji = 1.1 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Telefonda konuşmak")
            {
                enerji = 1.3 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Televizyon izlemek")
            {
                enerji = 1.3 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Araba kullanmak")
            {
                enerji = 1.8 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Araba tamir etmek")
            {
                enerji = 3.3 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Bahçe işleri")
            {
                enerji = 4 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Ağaç dikmek")
            {
                enerji = 4.5 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Marangoz işleri (hafif)")
            {
                enerji = 3 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Alışveriş yapmak")
            {
                enerji = 2.5 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Merdiven inip-çıkmak")
            {
                enerji = 6 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Yemek pişirmek")
            {
                enerji = 3.3 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Yemek yemek")
            {
                enerji = 1.8 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Badana yapmak")
            {
                enerji = 5 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Temizlik yapmak")
            {
                enerji = 4 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }

            else if (aktivitetürüCB.SelectedItem == "     Yer silmek (elle, diz üstünde)")
            {
                enerji = 4 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Cam silmek")
            {
                enerji = 4 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Çamaşır yıkamak (makine ile) ve asmak")
            {
                enerji = 4.4 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Yatak toplamak")
            {
                enerji = 3 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Ev içinde mobilya taşımak")
            {
                enerji = 9 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }

            else if (aktivitetürüCB.SelectedItem == "     Ütü yapmak")
            {
                enerji = 3 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }

            else if (aktivitetürüCB.SelectedItem == "     Örgü örmek")
            {
                enerji = 2.5 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Balık tutmak")
            {
                enerji = 3.5 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Dans etmek")
            {
                enerji = 6 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Yürüyüş (yavaş)")
            {
                enerji = 4.5 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Yürüyüş (hızlı)")
            {
                enerji = 6 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Doğa yürüyüşü")
            {
                enerji = 8 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Tepe tırmanışı")
            {
                enerji = 10 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Koşu")
            {
                enerji = 15 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Basketbol")
            {
                enerji = 7.5 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Futbol")
            {
                enerji = 8.5 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Hentbol")
            {
                enerji = 8 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Voleybol")
            {
                enerji = 4 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Paten kaymak")
            {
                enerji = 6 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Kayak")
            {
                enerji = 5 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Kaykay")
            {
                enerji = 4.7 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Yüzme")
            {
                enerji = 9.8 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Masa tenisi")
            {
                enerji = 6 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Tenis")
            {
                enerji = 7 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Bisiklet sürme")
            {
                enerji = 8 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Güreş")
            {
                enerji = 15 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Davul")
            {
                enerji = 3.8 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Piyano")
            {
                enerji = 2.3 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }
            else if (aktivitetürüCB.SelectedItem == "     Gitar")
            {
                enerji = 2 * 3.5 * aktivitekilo / 200 * aktivitedakika;
                label7.Text = "Bu Sürede " + enerji + " Kal Enerji Harcanmıştır.";
            }


        }


        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 dr = new Form1();
            dr.Show();
            this.Hide();
        }

        

        
    }
}
