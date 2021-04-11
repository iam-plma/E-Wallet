using Models.Categories;
using Models.Wallets;
using Prism.Commands;
using Prism.Mvvm;
using Services;
using System;
using System.Windows;

namespace EWalletWPF.Categories
{
    public class CategoryDetailsViewModel : BindableBase
    {
        private Category _category;
        public DelegateCommand DeleteCategoryCommand { get; }

        public string Label
        {
            get
            {
                return _category.Label;
            }
            set
            {
                _category.Label = value;
                UpdateCategory();
                RaisePropertyChanged(nameof(DisplayName));
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
                UpdateCategory();
            }
        }
        public string DisplayName
        {
            get
            {
                return $"{_category.Label}";
            }
        }
        public CategoryDetailsViewModel(Category category)
        {
            _category = category;
            DeleteCategoryCommand = new DelegateCommand(new Action(DeleteCategory));
        }

        private async void DeleteCategory()
        {
            bool belongs = false;
            var creatingService = new CategoryCreatingService();

            var walletService = new WalletService();
            var wallets = walletService.GetWallets();

            var categoryService = new CategoryService();
            foreach(Wallet wallet in wallets)
            {
                var catigories = categoryService.GetCurrentWalletCategories(wallet);
                foreach(Category category in catigories)
                {
                    if(category.FileName == _category.FileName)
                    {
                        MessageBox.Show($"You can`t delete category that belongs to any wallet. Delete wallet first!");
                        belongs = true;
                        break;
                    }
                }
                if (belongs)
                    break;
            }

            if (!belongs)
            {
                await creatingService.DeleteCategoryAsync(_category);
                CategoriesViewModel.Categories.Remove(this);
            }
            
        }
        private async void UpdateCategory()
        {
            var creatingService = new CategoryCreatingService();
            await creatingService.UpdateCategoryAsync(_category);
        }
    }
}
