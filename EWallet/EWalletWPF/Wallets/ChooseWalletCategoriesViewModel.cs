using Models.Categories;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using Services;

namespace EWalletWPF.Wallets
{
    public class ChooseWalletCategoriesViewModel : BindableBase
    {
        private WalletAddViewModel _ownerViewModel;
        private Category _category;
        public DelegateCommand AddCategoryCommand { get; }

        public string Label
        {
            get
            {
                return _category.Label;
            }
            set
            {
                _category.Label = value;
                RaisePropertyChanged(nameof(CategoryDisplayName));
            }
        }

        public string Description
        {
            get
            {
                return _category.Description;
            }
            set
            {
                _category.Description = value;
                RaisePropertyChanged(nameof(CategoryDisplayName));
            }
        }

        public string CategoryDisplayName
        {
            get
            {
                return $"{_category.Label}";
            }
        }

        public ChooseWalletCategoriesViewModel(Category category, WalletAddViewModel ownerViewModel)
        {
            _ownerViewModel = ownerViewModel;
            _category = category;
            AddCategoryCommand = new DelegateCommand(new Action(AddCategory));
        }

        private void AddCategory()
        {
            _ownerViewModel.WalletCategories.Add(_category);
            WalletAddViewModel.Categories.Remove(this);
        }
    }
}
