﻿using System;
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
    public partial class Gecis : Form
    {
        public Gecis()
        {
            InitializeComponent();
        }
        int startpos = 0;
        private void Gecis_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            startpos += 5;
            GecisProgressBar.Value = startpos;
            if (GecisProgressBar.Value==100) 
            {
                GecisProgressBar.Value = 0;
                timer1.Stop();

                Login log = new Login();
                log.Show();
                this.Hide();


            }
        }
    }
}
