using DataStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Wallets
{
    public class DBWallet : IStorable
    {
        public Guid Guid { get; }
        public string FileName { get; set; }
        public string Label { get; }
        public string Description { get; }
        public decimal Balance { get; }
        public Currency Currency { get; }

        public DBWallet(string label, string description, decimal balance, Currency currency, string fileName = "")
        {
            Guid = Guid.NewGuid();
            Label = label;
            Description = description;
            Balance = balance;
            Currency = currency;

            if (String.IsNullOrEmpty(fileName))
                FileName = Guid.ToString("N");
            else
                FileName = fileName;
        }

    }
}
