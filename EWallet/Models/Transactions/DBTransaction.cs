using DataStorage;
using Models.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Transactions
{
    public class DBTransaction : IStorable
    {
        public Guid Guid { get; }
        public string FileName { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Sum { get; set; }
        public string Description { get; set; }
        public Currency Currency { get; set; }
        public DBTransaction(DateTime dateTime, string description, decimal sum, Currency currency, string fileName = "")
        {
            Guid = Guid.NewGuid();
            DateTime = dateTime;
            Sum = sum;
            Description = description;
            Currency = currency;

            if (String.IsNullOrEmpty(fileName))
                FileName = Guid.ToString("N");
            else
                FileName = fileName;
        }
    }
}
