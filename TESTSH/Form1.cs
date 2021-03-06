﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                case "create":
                    Сountries = new List<Сountry>();
                    for (int i = 0; i < countCountry.Text.ToInt(); i++)
                    {
                        Сountry country = new Сountry(i, "Cntry:" + i);
                        Сountries.Add(country);
                        tableCntry.Rows.Add(i, country.Name, 0, 0, country.DateCreate);
                    }
                    Update();
                    break;
                case "start":
                    ModelingLoop();
                    break;
                default:
                    break;
            }
        }
        private void Update()
        {
            Task task = new Task(()=> 
            {
                while (true)
                {
                    Thread.Sleep(100);
                    Сountries.ForEach(country =>
                    {
                        var cCoins = country.Coins.Where(x => x.Symbol == "Coin:" + country.Name).Count();
                        var ncCoins = country.Coins.Where(x => x.Symbol != "Coin:" + country.Name).Count();
                        tableCntry.Invoke((MethodInvoker)delegate
                        {
                            tableCntry.Rows[country.Number].Cells[2].Value = cCoins;
                            tableCntry.Rows[country.Number].Cells[3].Value = ncCoins;
                        });
                    });
                }
            });

            task.Start();

        }

        private void ModelingLoop()
        {
            Task mainLife = new Task(() =>
            {
                int countYear = 0;
                do
                {
                    countYear++;
                    Thread.Sleep(2000);
                    Сountries.ForEach(x =>
                    {
                        x.GenCoins(countCoin.Text.ToInt());
                        ShowCountries(x); //Можно засунуть в отдельный поток ненагружая операции, но и так много времени потратил
                    });
                    MessageBox.Show("Начало " + countYear + " года");
                    for (int i = 0; i < 12; i++)
                    {
                        #region TradingCountry
                        for (int j = 0; j < Сountries.Count; j++)
                        {
                            Сountries[j].WriteBalance(countYear, i);
                            //Сountries[j].Coins.OnChange += new EventHandler(Update);
                            for (int k = 1; k < 5; k++)//Можно сделать случайный выбор кто с кем торгует, но сделал просто с 4 ближайшими последующими
                            {
                                Operation operation = new Operation();
                                Random random = new Random();
                                TypeOperation type;
                                int amount = random.Next(1, (Сountries[j].MyBalance().Count) / 2);
                                bool statusOp = false;
                                if (random.Next(0, 2) == 0)
                                {
                                    type = TypeOperation.Receipt;
                                }
                                else
                                {
                                    type = TypeOperation.Expenditure;
                                }
                                try
                                {
                                    statusOp = Сountries[j].AddOperation(type, amount, Сountries[j + k], i, countYear);
                                }
                                catch
                                {
                                    statusOp = Сountries[j].AddOperation(type, amount, Сountries[1], i, countYear);
                                }

                                if (statusOp) // Запись баланса после каждой успешной сделки (для графика) можно отключить
                                {
                                    Сountries[j].WriteBalance(countYear, i);
                                }

                                if (succTrades.Checked)
                                {
                                    if (statusOp)
                                    {
                                        ShowOperation(countYear, i, j, k, type, amount); //Можно засунуть в отдельный поток ненагружая операции, но и так много времени потратил
                                    }
                                }
                                else
                                {
                                    ShowOperation(countYear, i, j, k, type, amount); //Можно засунуть в отдельный поток ненагружая операции, но и так много времени потратил
                                }

                                //if (TestOver())
                                //{
                                //    MessageBox.Show("Торги закончены.");
                                //    return;
                                //}
                                Thread.Sleep(timeoutOp.Text.ToInt());
                            }
                        }
                        #endregion

                        Thread.Sleep(timeDel.Text.ToInt());
                    }
                    MessageBox.Show("Год закончен. Страны выпускают по " + countCoin.Text + " монет каждая.");
                }
                while (!TestOver());
                MessageBox.Show("Торги закончены.");
            });
            mainLife.Start();
            
        }

      

        private bool TestOver()
        {

            foreach (var country in Сountries)
            {
                foreach (var countryInside in Сountries)
                {
                    if (!country.Coins.Any(coin => coin.Symbol == "Coin:" + countryInside.Name))
                    {
                        return false;
                    }
                }
            }
            return true;
            //bool result = true;
            //Сountries.ForEach(x=> {
            //    Сountries.ForEach(y => {
            //        if (!x.Coins.Any(coin => coin.Symbol == "Coin:" + y.Name))
            //        {
            //            result = false;
            //            return;
            //        }
            //    });
            //});
            //return result;
        }
        #endregion

        #region Helpers
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, Color.IndianRed, ButtonBorderStyle.Solid);
        }
        private void ShowOperation(int countYear, int j, int i, int k, TypeOperation type, int amount)
        {
            tableOperations.Invoke((MethodInvoker)delegate
            {
                tableOperations.Rows.Add(countYear, j, Сountries[i].Name, type.ToStr(), amount, Сountries[i + k].Name, DateTime.Now);
            });
        }

        private void ShowCountries(Сountry x)
        {
            tableCntry.Invoke((MethodInvoker)delegate
            {
                tableCntry.Rows[x.Number].Cells[2].Value = x.Coins.Count;
            });
        }
        private void Switcher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var country = Сountries.Where(x=>x.Name == tableCntry.Rows[e.RowIndex].Cells[1].Value.ToString()).FirstOrDefault(); //Можно взять как объект сразу с DGV
            Form2 report = new Form2(country);
            report.ShowDialog();
                
            
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
        public static string ToStr(this TypeOperation type)
        {
            switch (type)
            {
                case TypeOperation.Receipt:
                    return "Приход";
                case TypeOperation.Expenditure:
                    return "Расход";
                default:
                    return "";
            }
        }

    }
}
