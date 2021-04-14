using EWalletWPF.Navigation;
using Models.Transactions;
using Models.Wallets;
using Prism.Commands;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EWalletWPF.Transactions
{
    public class TransactionAddViewModel : INavigatable<TransactionsNavigatableTypes>, INotifyPropertyChanged
    {
        private Wallet _wallet;
        private NewTransaction _newTransaction;
        private Action _gotoMainTransactions;
        public DelegateCommand BackCommand { get; }
        public DelegateCommand CreateTransactionCommand { get; }

        public TransactionsNavigatableTypes Type { get { return TransactionsNavigatableTypes.AddTransaction; } }

        public DateTime DateTime
        {
            get
            {
                return _newTransaction.DateTime;
            }
            set
            {
                if (_newTransaction.DateTime != value)
                {
                    _newTransaction.DateTime = value;
                    OnPropertyChanged();
                    CreateTransactionCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string Description
        {
            get
            {
                return _newTransaction.Description;
            }
            set
            {
                if(_newTransaction.Description != value)
                {
                    _newTransaction.Description = value;
                    OnPropertyChanged();
                    CreateTransactionCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public decimal Sum
        {
            get
            {
                return _newTransaction.Sum;
            }
            set
            {
                if(_newTransaction.Sum != value)
                {
                    _newTransaction.Sum = value;
                    OnPropertyChanged();
                    CreateTransactionCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public Currency Currency
        {
            get
            {
                return _newTransaction.Currency;
            }
            set
            {
                if(_newTransaction.Currency != value)
                {
                    _newTransaction.Currency = value;
                    OnPropertyChanged();
                    CreateTransactionCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public TransactionAddViewModel(Action gotoMaintransactions)
        {
            CreateTransactionCommand = new DelegateCommand(CreateTransaction, IsCreateTransactionEnabled);
            _gotoMainTransactions = gotoMaintransactions;
            BackCommand = new DelegateCommand(_gotoMainTransactions);

            _wallet = UserManager.CurrentWallet;
        }
        private async void CreateTransaction()
        {
            var transactionCreatingService = new TransactionCreatingService();
            try
            {
                await transactionCreatingService.CreateTransactionAsync(_newTransaction, _wallet);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Create Transaction failed: {ex.Message}");
                return;
            }

            MessageBox.Show($"Transaction successfully created");
            _gotoMainTransactions.Invoke();
        }

        private bool IsCreateTransactionEnabled()
        {
            return !String.IsNullOrWhiteSpace(Description) && DateTime <= DateTime.Today && Sum != 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void ClearSensitiveData()
        {
            _newTransaction = new NewTransaction();
        }

        public void UpdateView()
        {
            _wallet = UserManager.CurrentWallet;
        }
    }
}
