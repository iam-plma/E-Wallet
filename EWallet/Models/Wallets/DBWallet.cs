using DataStorage;
using System;
using System.Collections.Generic;

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
        public List<Guid> CategoryGuids { get; set; }

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

            CategoryGuids = new List<Guid>();
        }

        public void AddCategory(Guid categoryGuid)
        {
            CategoryGuids.Add(categoryGuid);
        }
    }
}
