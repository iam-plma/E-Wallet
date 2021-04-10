using Models.Categories;
using Prism.Commands;
using Prism.Mvvm;
using Services;
using System;

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
            DeleteCategoryCommand = new DelegateCommand(new Action(DeleteWallet));
        }

        private async void DeleteWallet()
        {
            var creatingService = new CategoryCreatingService();
            await creatingService.DeleteCategoryAsync(_category);
            CategoriesViewModel.Categories.Remove(this);
        }
        private async void UpdateCategory()
        {
            var creatingService = new CategoryCreatingService();
            await creatingService.UpdateCategoryAsync(_category);
        }
    }
}
