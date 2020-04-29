using System;
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

            Task mainLife = new Task(()=> 
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
                    for (int i = 0; i < 12; i++)
                    {
                        #region TradingCountry
                        for (int j = 0; j < Сountries.Count; j++)
                        {   
                            for (int k = 1; k < 5; k++)//Можно сделать случайный выбор кто с кем торгует
                            {

                            }
                        }
                        #endregion
                        Thread.Sleep(60000);
                    }
                    Thread.Sleep(1200000); // 20 min equal 1 year
                }
                while (true);
               
            });
            mainLife.Start();
        }

        private void Switcher_Button(object sender, EventArgs e)
        {
        }
    }
}
