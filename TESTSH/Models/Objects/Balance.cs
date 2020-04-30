using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTSH.Models.Objects
{
    public class Balance
    {
        public int Id { get; private set; }
        public int Amount { get; private set; }
        public int Month { get; private set; }
        public int Year { get; private set; }
        public DateTime DateTime { get; set; }

        public Balance(int year, int month, int amount)
        {
            Year = year; Month = month; Amount = amount; DateTime = DateTime.Now;
        }


    }
}
