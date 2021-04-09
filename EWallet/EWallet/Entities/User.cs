using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Entities
{
    public class User : EntityBase
    {
        private string _firstName;
        private string _lastName;
        private string _email;

        private List<Category> _categories;
        private List<Wallet> _wallets;
        private List<Wallet> _sharedWallets;

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public string FullName
        {
            get
            {
                string result = LastName;
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    if (!string.IsNullOrWhiteSpace(LastName))
                    {
                        result += " ";
                    }
                    result += FirstName;
                }
                return result;
            }
        }
        public List<Wallet> Wallets
        {
            get
            {
                return _wallets;
            }
        }
        public List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }
        public List<Wallet> SharedWallets { get => _sharedWallets;  }

        public User()
        {
            _categories = new List<Category>();
            _wallets = new List<Wallet>();
            _sharedWallets = new List<Wallet>();
        }
        public User(string firstName, string lastName, string email)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;

            _categories = new List<Category>();
            _wallets = new List<Wallet>();
            _sharedWallets = new List<Wallet>();
        }
        public override bool Validate()
        {
            bool result = true;

            if (string.IsNullOrWhiteSpace(LastName))
                result = false;
            if (string.IsNullOrWhiteSpace(Email))
                result = false;

            return result;
        }
        public void AddWallet(Wallet wallet)
        {
            if (!_wallets.Contains(wallet))
                _wallets.Add(wallet);
        }
        public void AddSharedWallet(Wallet wallet)
        {
            if (!_sharedWallets.Contains(wallet))
                _sharedWallets.Add(wallet);
        }
        public void ShareWallet(Wallet wallet, User user)
        {
            if (_wallets.Contains(wallet) && user != this)
            {
                if(this == wallet.Owner)
                {
                    wallet.ShareWith(user);
                    user.AddSharedWallet(wallet);
                }
            }
        }
        public void AddCategory(Category category)
        {
            if (!_categories.Contains(category))
                _categories.Add(category);
        }
        public void AddCategoryToWallet(Category category, Wallet wallet)
        {
            if (_wallets.Contains(wallet))
            {
                _wallets[_wallets.IndexOf(wallet)].AddCategory(category);
            }
        }
        public void AddTransactionToWallet(Transaction transaction, Wallet wallet)
        {
            if (_wallets.Contains(wallet))
            {
                _wallets[_wallets.IndexOf(wallet)].AddTransaction(transaction);
            }
            if (_sharedWallets.Contains(wallet))
            {
                _sharedWallets[_sharedWallets.IndexOf(wallet)].AddTransaction(transaction);
            }
        }
        public void EditWalletTransaction(Transaction transaction, Wallet wallet)
        {
            if (_wallets.Contains(wallet))
            {
                _wallets[_wallets.IndexOf(wallet)].EditTransaction(transaction);
            }
        }
        public void DeleteWalletTransaction(Transaction transaction, Wallet wallet)
        {
            if (_wallets.Contains(wallet))
            {
                _wallets[_wallets.IndexOf(wallet)].DeleteTransaction(transaction);
            }
        }
        public override string ToString()
        {
            return FullName;
        }
        static void Main() { }
    }
}
