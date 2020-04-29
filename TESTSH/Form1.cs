﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TESTSH.Models.Objects;

namespace TESTSH
{
    public partial class Form1 : Form
    {
        private List<Сountry> Сountries { get; set; }
        public Form1()
        {
            InitializeComponent();
            Сountries = new List<Сountry>();
            for (int i = 0; i < 100; i++)
            {
                Сountry country = new Сountry(i, "Cntry:" + i);
                Сountries.Add(country);
                tableCntry.Rows.Add(i, country.Name, 0, 0, country.DateCreate);
            }

            Task genCoins = new Task(()=> 
            {
                int countYear = 0;
                do
                {
                    countYear++;
                    Thread.Sleep(2000);
                    Сountries.ForEach(x=> { 
                        x.GenCoins(20);
                        tableCntry.Invoke((MethodInvoker)delegate {
                            tableCntry.Rows[x.Number].Cells[2].Value = x.Coins.Count;
                       });
                    });
                    MessageBox.Show("Начало " + countYear + " года");
                    Thread.Sleep(1200000); // 20 min equal 1 year
                }
                while (true);
               
            });
            genCoins.Start();
        }

        private void Switcher_Button(object sender, EventArgs e)
        {
        }
    }
}
