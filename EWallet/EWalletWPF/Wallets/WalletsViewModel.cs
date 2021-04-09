﻿using EWalletWPF.Navigation;
using Services;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Prism.Commands;
using System;
using System.Runtime.CompilerServices;
using Prism.Mvvm;

namespace EWalletWPF.Wallets
{
    public class WalletsViewModel : BindableBase , INotifyPropertyChanged, INavigatable<WalletsNavigatableTypes>
    {
        private WalletService _service;
        private WalletDetailsViewModel _currentWallet;

        private Action _gotoAddWallet;
        public static ObservableCollection<WalletDetailsViewModel> Wallets { get; set; }
        
        public WalletDetailsViewModel CurrentWallet
        {
            get
            {
                return _currentWallet;
            }
            set
            {
                _currentWallet = value;
                RaisePropertyChanged();
            }
        }
        
        public WalletsViewModel(Action gotoAddWallet)
        {
            _service = new WalletService();
            Wallets = new ObservableCollection<WalletDetailsViewModel>();
            foreach (var wallet in _service.GetWallets())
            {
                Wallets.Add(new WalletDetailsViewModel(wallet));
            }
            _gotoAddWallet = new Action(gotoAddWallet);
            AddWalletCommand = new DelegateCommand(_gotoAddWallet);
            QuitCommand = new DelegateCommand(() => Environment.Exit(0));
        }

        
        public WalletsNavigatableTypes Type
        {
            get
            {
                return WalletsNavigatableTypes.MainWallet;
            }
        }

        public void ClearSensitiveData()
        {

        }

        public DelegateCommand AddWalletCommand { get; }
        public DelegateCommand QuitCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged1;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged1?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpdateView()
        {
            _service = new WalletService();
            Wallets = new ObservableCollection<WalletDetailsViewModel>();
            foreach (var wallet in _service.GetWallets())
            {
                Wallets.Add(new WalletDetailsViewModel(wallet));
            }
        }
    }
}