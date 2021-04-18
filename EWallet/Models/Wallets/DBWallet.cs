using DataStorage;
using System;
using System.Collections.Generic;
using Models.Transactions;

namespace Models.Wallets
{
    public class DBWallet : IStorable
    {
        public Guid Guid { get; }
        public string FileName { get; set; }
        public string Label { get; }
        public string Description { get; }
        public decimal Balance { get; set; }
        public Currency Currency { get; }
        public List<Guid> CategoryGuids { get; set; }
        public List<Guid> TransactionGuids { get; set; }

        public DBWallet(string label, string description, decimal balance, Currency currency,
             string fileName = "")
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

            //if (catGuids != null)
            //    CategoryGuids = catGuids;
            //else
                CategoryGuids = new List<Guid>();

            //if (transGuids != null)
            //    TransactionGuids = transGuids;
            //else
                TransactionGuids = new List<Guid>();
        }

        public void AddCategory(Guid categoryGuid)
        {
            CategoryGuids.Add(categoryGuid);
        }
        public void AddTransaction(Guid transactionGuid)
        {
            TransactionGuids.Add(transactionGuid);
        }
        public void DeleteTransaction(Guid transactionGuid)
        {
            TransactionGuids.Remove(transactionGuid);
        }
        public void AddTransaction(DBTransaction newTransaction)
        {
            TransactionGuids.Add(newTransaction.Guid);
            UpdateBalance(newTransaction.Sum, newTransaction.Currency);
        }
        public void DeleteTransaction(DBTransaction transactionToDelete)
        {
            TransactionGuids.Remove(Guid.Parse(transactionToDelete.FileName));
            UpdateBalance(-transactionToDelete.Sum, transactionToDelete.Currency);
        }
        public void UpdateBalance(decimal sum, Currency currency)
        {
            if(currency == Currency)
            {
                Balance += sum;
                return;
            }
            if(currency == Currency.UAH)
            {
                if(Currency == Currency.EUR)
                {
                    decimal convertedSum = sum / (decimal)33.45;
                    Balance += convertedSum;
                }
                else if(Currency == Currency.USD)
                {
                    decimal convertedSum = sum / 28;
                    Balance += convertedSum;
                }
                return;
            }
            if (currency == Currency.EUR)
            {
                if (Currency == Currency.UAH)
                {
                    decimal convertedSum = sum * (decimal)33.45;
                    Balance += convertedSum;
                }
                else if (Currency == Currency.USD)
                {
                    decimal convertedSum = sum * (decimal)1.2;
                    Balance += convertedSum;
                }
                return;
            }
            if (currency == Currency.USD)
            {
                if (Currency == Currency.UAH)
                {
                    decimal convertedSum = sum * 28;
                    Balance += convertedSum;
                }
                else if (Currency == Currency.EUR)
                {
                    decimal convertedSum = sum / (decimal)1.2;
                    Balance += convertedSum;
                }
                return;
            }

        }
        
        public void ChangeTransactionCurrency(decimal sum, Currency oldCurrency, Currency newCurrency)
        {
            UpdateBalance(-sum, oldCurrency);
            UpdateBalance(sum, newCurrency);
        }
    }
}
