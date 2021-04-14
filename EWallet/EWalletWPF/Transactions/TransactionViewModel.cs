using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Services;
using EWalletWPF.Navigation;
using Models.Wallets;
using Models.Transactions;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Mvvm;

namespace EWalletWPF.Transactions
{
    public class TransactionViewModel : BindableBase, INavigatable<TransactionsNavigatableTypes>, INotifyPropertyChanged
    {
        private TransactionDetailsViewModel _currentTransaction;
        private Wallet _wallet;
        private Action _gotoAddTransaction;
        private Action _gotoWallets;

        private TransactionService _service;
        public DelegateCommand AddTransactionCommand { get; }
        public DelegateCommand BackCommand { get; }
        public static ObservableCollection<TransactionDetailsViewModel> Transactions { get; set; }
        public TransactionViewModel(Action gotoAddTransaction, Action gotoWallets)
        {
            _gotoAddTransaction = gotoAddTransaction;
            AddTransactionCommand = new DelegateCommand(_gotoAddTransaction);
            _gotoWallets = gotoWallets;
            BackCommand = new DelegateCommand(_gotoWallets);

            _wallet = UserManager.CurrentWallet;
            _service = new TransactionService();
            Transactions = new ObservableCollection<TransactionDetailsViewModel>();
            foreach (var transaction in _service.GetWalletTransactions(_wallet))
            {
                Transactions.Add(new TransactionDetailsViewModel(transaction, _wallet));
            }
        } 
        public TransactionsNavigatableTypes Type
        {
            get
            {
                return TransactionsNavigatableTypes.MainTransaction;
            }
        }

        public TransactionDetailsViewModel CurrentTransaction { 
            get
            {
                return _currentTransaction;
            }
            set
            {
                _currentTransaction = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged1;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged1?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void ClearSensitiveData()
        {
            UpdateView();
        }

        public void UpdateView()
        {
            _wallet = UserManager.CurrentWallet;
            _currentTransaction = null;
            _service = new TransactionService();
            Transactions = new ObservableCollection<TransactionDetailsViewModel>();
            foreach (var transaction in _service.GetWalletTransactions(_wallet))
            {
                Transactions.Add(new TransactionDetailsViewModel(transaction, _wallet));
            }
        }
    }
}
