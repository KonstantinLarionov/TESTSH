using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTSH.Models.Objects
{
    public enum TypeOperation
    {
        Receipt, Expenditure
    }
    public class Operation
    {
        public int Id { get; set; }
        public TypeOperation Type { get; set; }
        public int Amount { get; set; }
        public Сountry CountryFrom { get; set; }
        public Сountry CountryTo { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
