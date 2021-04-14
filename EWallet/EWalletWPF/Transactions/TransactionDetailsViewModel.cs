using Models.Transactions;
using Models.Wallets;
using Prism.Commands;
using Prism.Mvvm;
using Services;
using System;

namespace EWalletWPF.Transactions
{
    public class TransactionDetailsViewModel : BindableBase
    {
        private Wallet _wallet;
        private Transaction _transaction;
        public DelegateCommand DeleteTransactionCommand { get; }

        public DateTime DateTime
        {
            get
            {
                return _transaction.DateTime;
            }
            set
            {
                _transaction.DateTime = value;
                UpdateTransactions(0, Currency);
                RaisePropertyChanged(nameof(DisplayName));
            }
        }
        public string Description
        {
            get
            {
                return _transaction.Description;
            }
            set
            {
                _transaction.Description = value;
                UpdateTransactions(0, Currency);

            }
        }
        public Currency Currency
        {
            get
            {
                return _transaction.Currency;
            }
            set
            {
                Currency tempCurrency = _transaction.Currency;
                _transaction.Currency = value;
                UpdateTransactions(0, tempCurrency);
            }
        }
        public decimal Sum
        {
            get
            {
                return _transaction.Sum;
            }
            set
            {
                decimal tempSum = _transaction.Sum;
                _transaction.Sum = value;
                decimal difference = _transaction.Sum - tempSum;
                UpdateTransactions(difference, Currency);
            }
        }
        public string DisplayName
        {
            get
            {
                return $"{_transaction.DateTime}";
            }
        }
        public TransactionDetailsViewModel(Transaction transaction, Wallet wallet)
        {
            _wallet = wallet;
            _transaction = transaction;
            DeleteTransactionCommand = new DelegateCommand(new Action(DeleteTransaction));
        }
        private async void DeleteTransaction()
        {
            var creatingService = new TransactionCreatingService();
            await creatingService.DeleteTransactionAsync(_transaction, _wallet);
            TransactionViewModel.Transactions.Remove(this);
        }

        private async void UpdateTransactions(decimal difference, Currency oldCurrency)
        {
            var creatingService = new TransactionCreatingService();
            await creatingService.UpdateTransactionAsync(_transaction, _wallet, difference, oldCurrency);

        }

    }
}
