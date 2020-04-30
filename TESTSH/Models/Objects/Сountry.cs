using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTSH.Models.Objects
{
    public class Сountry
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; private set; }
        public List<Coin> Coins { get; private set; } = new List<Coin>();
        public List<Operation> Operations { get; private set; } = new List<Operation>();
        public DateTime DateCreate { get; private set; }

        public Сountry(int id,string name)
        {
            Number = id;
            Name = name;
            DateCreate = DateTime.Now;
        }

        public void GenCoins(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Coins.Add(new Coin("Coin:" + Name, 1));
            }
        }

        public void ReceiptCoins(int amount, string fromSymbol)
        {
            for (int i = 0; i < amount; i++)
            {
                Coins.Add(new Coin("Coin:" + Name, 1));
            }
        }
        public void ExpenditureCoins(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Coins.Remove(Coins.LastOrDefault());
            }
        }
        public List<Coin> MyBalance()
        {
            return Coins.Where(x => x.Symbol == "Coin:" + Name).ToList();
        }
        public void AddOperation(TypeOperation type, int amount, Сountry country)
        {
            if (amount > MyBalance().Count / 2 && amount > country.MyBalance().Count / 2)
            {
                return;
            }

            else
            {
                switch (type)
                {
                    case TypeOperation.Receipt:
                        ReceiptCoins(amount, "Coin:" + country.Name);
                        country.AddOperation(TypeOperation.Expenditure,amount, this);
                        Operations.Add(new Operation() { Amount = amount, Type = type, CountryFrom = country, DateCreate = DateTime.Now });
                        break;
                    case TypeOperation.Expenditure:
                        ExpenditureCoins(amount);
                        country.AddOperation(TypeOperation.Receipt,amount, this);
                        Operations.Add(new Operation() { Amount = amount, Type = type, CountryTo = country, DateCreate = DateTime.Now });
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
