using EWalletWPF.Navigation;
using Models.Categories;
using Models.Wallets;
using Prism.Commands;
using Prism.Mvvm;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace EWalletWPF.Wallets
{
    public class WalletAddViewModel : BindableBase, INavigatable<WalletsNavigatableTypes>, INotifyPropertyChanged
    {
        public NewWallet _newWallet = new NewWallet();
        private Action _gotoWalletsMenu;
        private CategoryService _categoryService;
        private ChooseWalletCategoriesViewModel _currentCategory;
        public DelegateCommand BackCommand { get; }
        public DelegateCommand CreateWalletCommand { get; }
        public static ObservableCollection<ChooseWalletCategoriesViewModel> Categories { get; set; }

        public WalletAddViewModel(Action gotoWalletsMenu)
        {
            CreateWalletCommand = new DelegateCommand(CreateWallet, IsCreateWalletEnabled);
            _gotoWalletsMenu = gotoWalletsMenu;
            BackCommand = new DelegateCommand(_gotoWalletsMenu);

            _categoryService = new CategoryService();
            Categories = new ObservableCollection<ChooseWalletCategoriesViewModel>();
            foreach(var category in _categoryService.GetCategories())
            {
                Categories.Add(new ChooseWalletCategoriesViewModel(category, this));
            }

        }
        public WalletsNavigatableTypes Type
        {
            get
            {
                return WalletsNavigatableTypes.AddWallet;
            }
        }

        public string Label
        {
            get
            {
                return _newWallet.Label;
            }
            set
            {
                if (_newWallet.Label != value)
                {
                    _newWallet.Label = value;
                    OnPropertyChanged();
                    CreateWalletCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Description
        {
            get
            {
                return _newWallet.Description;
            }
            set
            {
                if (_newWallet.Description != value)
                {
                    _newWallet.Description = value;
                    OnPropertyChanged();
                    CreateWalletCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public decimal Balance
        {
            get
            {
                return _newWallet.Balance;
            }
            set
            {
                if (_newWallet.Balance != value)
                {
                    _newWallet.Balance = value;
                    OnPropertyChanged();
                    CreateWalletCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public Currency Currency
        {
            get
            {
                return _newWallet.Currency;
            }
            set
            {
                if (_newWallet.Currency != value)
                {
                    _newWallet.Currency = value;
                    OnPropertyChanged();
                    CreateWalletCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public ChooseWalletCategoriesViewModel CurrentCategory
        {
            get
            {
                return _currentCategory;
            }
            set
            {
                _currentCategory = value;
                OnPropertyChanged();
                RaisePropertyChanged();
            }

        }
        public List<Category> WalletCategories
        {
            get
            {
                if(_newWallet.Categories == null)
                {
                    _newWallet.Categories = new List<Category>();
                    return _newWallet.Categories;
                }
                else 
                    return _newWallet.Categories;
            }
        }
        private async void CreateWallet()
        {
            var walletCreatingService = new WalletCreatingService();
            try
            {
                await walletCreatingService.CreateWalletAsync(_newWallet);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Create Wallet failed: {ex.Message}");
                return;
            }

            MessageBox.Show($"Wallet successfully created");
            _gotoWalletsMenu.Invoke();
        }
        private bool IsCreateWalletEnabled()
        {
            return !String.IsNullOrWhiteSpace(Label) && !String.IsNullOrWhiteSpace(Description) 
                && (Currency == Currency.EUR || Currency == Currency.USD || Currency == Currency.UAH) && WalletCategories.Count != 0;
        }

        public event PropertyChangedEventHandler PropertyChanged1;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged1?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ClearSensitiveData()
        {
            _newWallet = new NewWallet();
        }

        public void UpdateView()
        {
            Categories = new ObservableCollection<ChooseWalletCategoriesViewModel>();
            foreach (var category in _categoryService.GetCategories())
            {
                Categories.Add(new ChooseWalletCategoriesViewModel(category, this));
            }
        }
    }
}
