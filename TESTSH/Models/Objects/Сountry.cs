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
        public List<Balance> HistoryBalance { get; set; } = new List<Balance>();
        public List<Operation> Operations { get; private set; } = new List<Operation>();
        public DateTime DateCreate { get; private set; }
        public int CanSpend { get; set; }

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
            CanSpend = Coins.Count / 2;
        }

        public void ReceiptCoins(int amount, string fromSymbol)
        {
            for (int i = 0; i < amount; i++)
            {
                Coins.Add(new Coin(fromSymbol, 1));
            }
        }
        public void ExpenditureCoins(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Coins.Remove(Coins.LastOrDefault());
            }
            CanSpend -= amount;
        }
        public List<Coin> MyBalance()
        {
            return Coins.Where(x => x.Symbol == "Coin:" + Name).ToList();
        }

        public void WriteBalance(int year, int month)
        {
            HistoryBalance.Add(new Balance(year, month, Coins.Count));
        }

        public bool AddOperation(TypeOperation type, int amount, Сountry country, int month, int years)
        {
            if (amount < CanSpend && amount < country.CanSpend)// Проверка на половину депо
            {
                Random rnd = new Random();
                int id = rnd.Next(0, 10000000);
                if (!this.Operations.Any(x => x.Id == id))
                {
                    switch (type)
                    {
                        case TypeOperation.Receipt:
                            ReceiptCoins(amount, "Coin:" + country.Name);
                            country.ExpenditureCoins(amount);

                            SaveData(type, amount, country, id, month, years);
                            SaveData(type, amount, this, id, month, years);
                            break;
                        case TypeOperation.Expenditure:
                            ExpenditureCoins(amount);
                            country.ReceiptCoins(amount, "Coin:" + country.Name);

                            SaveData(type, amount, country, id, month, years);
                            SaveData(type, amount, this, id, month, years);
                            break;
                        default:
                            break;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            ///При таком подходе будет переполнение ( Хотел сделать красиво через рекурсию :C )
            //if (!this.Operations.Any(x=>x.Id == id))
            //{
            //    switch (type)
            //    {
            //        case TypeOperation.Receipt:
            //            ReceiptCoins(amount, "Coin:" + country.Name);
            //            country.AddOperation(TypeOperation.Expenditure, amount, this);
            //            SaveData(type, amount, country, id);
            //            break;
            //        case TypeOperation.Expenditure:
            //            ExpenditureCoins(amount);
            //            country.AddOperation(TypeOperation.Receipt, amount, this);
            //            SaveData(type, amount, country, id);
            //            break;
            //        default:
            //            break;
            //    }
            //}

        }

        private void SaveData(TypeOperation type, int amount, Сountry country, int id, int month, int years)
        {
            if (type == TypeOperation.Expenditure)
            {
                Operations.Add(new Operation() { Id = id, Amount = amount, Type = type, CountryTo = country, DateCreate = DateTime.Now, Month = month, Year = years });
            }
            else
            {
                Operations.Add(new Operation() { Id = id, Amount = amount, Type = type, CountryFrom = country, DateCreate = DateTime.Now, Month = month, Year = years });
            }
        }
    }
}
