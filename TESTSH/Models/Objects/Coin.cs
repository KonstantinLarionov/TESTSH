using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTSH.Models.Objects
{
    public class Coin
    {
        public int Id { get; set; }
        public int Par { get; private set; }
        public string Symbol { get; private set; }
        public DateTime DateCreate { get; private set; }

        public Coin(string symbol, int par)
        {
            Symbol = symbol;
            Par = par;
            DateCreate = DateTime.Now;
        }
    }
}
