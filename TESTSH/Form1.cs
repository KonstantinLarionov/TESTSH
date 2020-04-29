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
        #region Props
        private List<Сountry> Сountries { get; set; }
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region Core
        private void Switcher_Button(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "close":
                    Close();
                    break;
                case "create":
                    Сountries = new List<Сountry>();
                    for (int i = 0; i < countCountry.Text.ToInt(); i++)
                    {
                        Сountry country = new Сountry(i, "Cntry:" + i);
                        Сountries.Add(country);
                        tableCntry.Rows.Add(i, country.Name, 0, 0, country.DateCreate);
                    }
                    break;
                case "start":
                    Task mainLife = new Task(() =>
                    {
                        int countYear = 0;
                        do
                        {
                            countYear++;
                            Thread.Sleep(2000);
                            Сountries.ForEach(x => {
                                x.GenCoins(countCoin.Text.ToInt());
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
                                Thread.Sleep(timeDel.Text.ToInt());
                            }
                            
                        }
                        while (true);

                    });
                    mainLife.Start();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Helpers
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, Color.IndianRed, ButtonBorderStyle.Solid);
        }
        

        #endregion
    }
    public static class EXT
    {
        public static int ToInt(this string str)
        {
            try
            {
                int num = Convert.ToInt32(str);
                return num;
            }
            catch
            {
                return 0;
            }
        }
    }
}
