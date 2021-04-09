using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Entities
{
    public enum Currency
    {
        USD,
        EUR,
        UAH
    }

    public class Wallet : EntityBase
    {
        private User _owner;
        private List<User> _sharedWith;

        private string _label;
        private decimal _balance;
        private string _description;
        private Currency _currency;

        private List<Category> _categories;
        private List<Transaction> _transactions;

        public List<User> Owners { get => _sharedWith; set => _sharedWith = value; }
        public string Label { get => _label; set => _label = value; }
        public decimal Balance { get => _balance; set => _balance = value; }
        public string Description { get => _description; set => _description = value; }
        public Currency Currency { get => _currency; set => _currency = value; }
        public User Owner { get => _owner; set => _owner = value; }

        public Wallet()
        {
            _sharedWith = new List<User>();
            _categories = new List<Category>();
            _transactions = new List<Transaction>();
        }

        public Wallet(User owner, string label, decimal startBalance, string description, Currency currency)
        {
            _sharedWith = new List<User>();
            _sharedWith.Add(owner);

            Owner = owner;
            _label = label;
            _balance = startBalance;
            _description = description;
            _currency = currency;
        }

        public override bool Validate()
        {
            bool result = true;

            if (string.IsNullOrWhiteSpace(Label))
                result = false;
            if (Owners.Count == 0)
                result = false;
            foreach(User user in Owners)
            {
                if (!user.IsValid)
                    result = false;
            }

            return result;
        }

        public void ShareWith(User owner)
        {
            if(!_sharedWith.Contains(owner))
                _sharedWith.Add(owner);
        }

        public void AddCategory(Category newCategory)
        {
            if (!_categories.Contains(newCategory))
                _categories.Add(newCategory);
        }

        public void AddTransaction(Transaction newTransaction)
        {
            if (!_transactions.Contains(newTransaction) && _categories.Contains(newTransaction.Category) 
                && newTransaction.Currency == _currency)
            {
                _transactions.Add(newTransaction);
                _balance += newTransaction.Sum;
            }
        }

        public void DeleteTransaction(Transaction transaction)
        {
            if (_transactions.Contains(transaction))
            {
                _balance += transaction.Sum;
                _transactions.Remove(transaction);
            }
        }

        public Transaction EditTransaction(Transaction transaction)
        {
            if (_transactions.Contains(transaction))
            {
                int pos = _transactions.IndexOf(transaction);
                return _transactions[pos];
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public List<Transaction> ShowTransactions()
        {
            return GetTransactions(0, 10);
        }

        public List<Transaction> ShowTransactions(uint from, uint to)
        {
            return GetTransactions(from, to);
        }

        private List<Transaction> GetTransactions(uint from, uint to)
        {
            List<Transaction> resultList = new List<Transaction>();

            List<Transaction> reversedTransactions = _transactions;
            reversedTransactions.Reverse();

            if(from > reversedTransactions.Count)
                return resultList;

            if (to > reversedTransactions.Count)
                to = (uint)reversedTransactions.Count;
            
            for (int i = (int)from; i < to; i++)
            {
                resultList.Add(reversedTransactions[i]);     
            }

            return resultList;
        }

        public decimal GetMonthExpenses()
        {
            return GetMonthStats(false);
        }

        public decimal GetMonthIncomes()
        {
            return GetMonthStats(true);
        }

        private decimal GetMonthStats(bool incomes)
        {
            decimal result = 0;
            DateTime currentDate = DateTime.Today;

            foreach (Transaction transaction in _transactions)
                if (transaction.Date.Month == currentDate.Month)
                {
                    if (incomes)
                    {
                        if (transaction.Sum > 0)
                            result += transaction.Sum;
                    }
                    else
                    {
                        if (transaction.Sum < 0)
                        {
                            var temp = transaction.Sum;
                            temp *= -1;
                            result += temp;
                        }
                    }
                }


            return result;
        }
    } 
}
