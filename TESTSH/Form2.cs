using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TESTSH.Models.Objects;

namespace TESTSH
{
    public partial class Form2 : Form
    {
        private Сountry Country { get; set; } = null;
        public Form2(Сountry сountry)
        {
            InitializeComponent();
            Country = сountry;
            this.Text = "Отчет: " + Country.Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowCountries();
        }

        private void ShowCountries()
        {
            tableOperations.Rows.Clear();
            chartBalance.Series.Clear();

            var operation = Country.Operations.Where(x => x.Year == numberYears.Text.ToInt() && x.Month == numberMonth.Text.ToInt()).ToList();
            var balance = Country.HistoryBalance.Where(x => x.Year == numberYears.Text.ToInt() && x.Month == numberMonth.Text.ToInt()).ToList();
            this.balance.Text = balance.FirstOrDefault().Amount.ToString() + " Coins";
            Country.Operations.ForEach(x =>
            {
                if (x.Type == TypeOperation.Expenditure)
                {
                    tableOperations.Rows.Add(x.Id, x.Type.ToStr(), x.CountryTo.Name, x.Amount, x.DateCreate);
                }
                else
                {
                    tableOperations.Rows.Add(x.Id, x.Type.ToStr(), x.CountryFrom.Name, x.Amount, x.DateCreate);
                }
            });

            Series series = new Series();
            series.ChartType = SeriesChartType.FastLine;
            series.BorderWidth = 2;
            series.Color = Color.Red;
            series.ChartArea = "Balance";
            balance.ForEach(x =>
            {
                series.Points.AddXY(x.DateTime, x.Amount);
            });
            chartBalance.Series.Add(series);
        }
    }
}
