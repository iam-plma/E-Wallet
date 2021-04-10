using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EWalletWPF.Navigation;
using Models.Categories;
using Prism.Commands;
using Services;

namespace EWalletWPF.Categories
{
    public class AddCategoryViewModel : INavigatable<CategoriesNavigatableTypes>, INotifyPropertyChanged
    {
        private NewCategory _newCategory;
        private Action _gotoMainCategories;
        public DelegateCommand BackCommand { get; }
        public DelegateCommand CreateCategoryCommand { get; }

        public AddCategoryViewModel(Action gotoMainCategories)
        {
            CreateCategoryCommand = new DelegateCommand(CreateCategory, IsCreateCategoryEnabled);
            _gotoMainCategories = gotoMainCategories;
        }
        public string Label
        {
            get
            {
                return _newCategory.Label;
            }
            set
            {
                if (_newCategory.Label != value)
                {
                    _newCategory.Label = value;
                    OnPropertyChanged();
                    CreateCategoryCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Description
        {
            get
            {
                return _newCategory.Description;
            }
            set
            {
                if (_newCategory.Description != value)
                {
                    _newCategory.Description = value;
                    OnPropertyChanged();
                    CreateCategoryCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public CategoriesNavigatableTypes Type
        {
            get
            {
                return CategoriesNavigatableTypes.AddCategory;
            }
        }
        private async void CreateCategory()
        {
            var categoryCreatingService = new CategoryCreatingService();
            try
            {
                await categoryCreatingService.CreateCategoryAsync(_newCategory);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Create Category failed: {ex.Message}");
                return;
            }

            MessageBox.Show($"Category successfully created");
            _gotoMainCategories.Invoke();
        }

        private bool IsCreateCategoryEnabled()
        {
            return !String.IsNullOrWhiteSpace(Label) && !String.IsNullOrWhiteSpace(Description);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void ClearSensitiveData()
        {
            _newCategory = new NewCategory();
        }

        public void UpdateView()
        {
            
        }
    }
}
