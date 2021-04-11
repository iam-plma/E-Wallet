using DataStorage;
using Models.Categories;
using Models.Users;
using Models.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryCreatingService
    {
        private FileDataStorage<DBWallet> _walletStorage = new FileDataStorage<DBWallet>();
        private FileDataStorage<DBUser> _userStorage = new FileDataStorage<DBUser>();
        private FileDataStorage<DBCategory> _categoryStorage = new FileDataStorage<DBCategory>();

        public async Task<bool> CreateCategoryAsync(NewCategory newCategory)
        {
            if (String.IsNullOrWhiteSpace(newCategory.Label))
                throw new ArgumentException("Label is Empty");

            var dbCategory = new DBCategory(newCategory.Label, newCategory.Description);

            var users = await _userStorage.GetAllAsync();
            var dbUser = users.FirstOrDefault(user => user.Login == UserManager.Login);
            dbUser.AddCategory(dbCategory.Guid);

            await _categoryStorage.AddOrUpdateAsync(dbCategory);
            await _userStorage.AddOrUpdateAsync(dbUser);

            return true;
        }

        public async Task<bool> UpdateCategoryAsync(Category categoryToEdit)
        {
            if (String.IsNullOrWhiteSpace(categoryToEdit.Label))
                throw new ArgumentException("Label is Empty");

            var categories = await _categoryStorage.GetAllAsync();
            var newDBCategory = new DBCategory(categoryToEdit.Label, categoryToEdit.Description, categoryToEdit.FileName);

            await _categoryStorage.AddOrUpdateAsync(newDBCategory);

            return true;
        }

        public async Task<bool> DeleteCategoryAsync(Category categoryToDelete)
        {
            if (String.IsNullOrWhiteSpace(categoryToDelete.Label))
                throw new ArgumentException("Label is Empty");

            var categories = await _categoryStorage.GetAllAsync();
            var dbCategory = categories.FirstOrDefault(category => category.FileName == categoryToDelete.FileName);

            var users = await _userStorage.GetAllAsync();
            var dbUser = users.FirstOrDefault(user => user.Login == UserManager.Login);
            dbUser.DeleteCategory(Guid.Parse(dbCategory.FileName));

            if (dbCategory != null)
                _categoryStorage.DeleteAsync(dbCategory.FileName);

            await _userStorage.AddOrUpdateAsync(dbUser);
            return true;
        }

        public async Task<bool> AddCategoryToWalletAsync(Category categoryToAdd, Wallet _wallet)
        {
            if (String.IsNullOrEmpty(categoryToAdd.Label))
                throw new ArgumentException("Category Label is Empty");

            var categories = await _categoryStorage.GetAllAsync();
            var dbCategory = categories.FirstOrDefault(category => category.FileName == categoryToAdd.FileName);

            var wallets = await _walletStorage.GetAllAsync();
            var dbWallet = wallets.FirstOrDefault(wallet => wallet.FileName == _wallet.FileName);
            dbWallet.AddCategory(Guid.Parse(dbCategory.FileName));

            await _walletStorage.AddOrUpdateAsync(dbWallet);
            return true;
        }
    }
}
