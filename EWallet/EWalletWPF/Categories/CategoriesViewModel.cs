using Prism.Commands;
using System;
using EWalletWPF.Navigation;
using Prism.Mvvm;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Services;

namespace EWalletWPF.Categories
{
    public class CategoriesViewModel : BindableBase, INavigatable<CategoriesNavigatableTypes>, INotifyPropertyChanged
    {
        private CategoryDetailsViewModel _currentCategory;
        private Action _gotoAddCategory;
        private Action _gotoWallets;
        private CategoryService _service;
        public static ObservableCollection<CategoryDetailsViewModel> Categories { get; set; }

        public DelegateCommand AddCategoryCommand { get; }
        public DelegateCommand BackCommand { get; }

        public CategoriesViewModel(Action gotoAddCategory, Action gotoWallets)
        {
            _gotoAddCategory = gotoAddCategory;
            AddCategoryCommand = new DelegateCommand(_gotoAddCategory);
            _gotoWallets = gotoWallets;
            BackCommand = new DelegateCommand(_gotoWallets);
            _service = new CategoryService();
            Categories = new ObservableCollection<CategoryDetailsViewModel>();
            foreach (var category in _service.GetCategories())
            {
                Categories.Add(new CategoryDetailsViewModel(category));
            }
        }
        public CategoryDetailsViewModel CurrentCategory
        {
            get
            {
                return _currentCategory;
            }
            set
            {
                _currentCategory = value;
                RaisePropertyChanged();
            }
        }
        public CategoriesNavigatableTypes Type
        {
            get
            {
                return CategoriesNavigatableTypes.MainCategory;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged1;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged1?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void ClearSensitiveData()
        {
            
        }

        public void UpdateView()
        {
            _service = new CategoryService();
            Categories = new ObservableCollection<CategoryDetailsViewModel>();
            foreach (var category in _service.GetCategories())
            {
                Categories.Add(new CategoryDetailsViewModel(category));
            }
        }
    }
}
