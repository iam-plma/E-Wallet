using DataStorage;
using Models.Categories;
using Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService
    {
        private FileDataStorage<DBCategory> _categoryStorage = new FileDataStorage<DBCategory>();
        private FileDataStorage<DBUser> _userStorage = new FileDataStorage<DBUser>();
        public CategoryService()
        {
        }

        public List<Category> GetCategories()
        {
            Task<List<Category>> task = Task.Run<List<Category>>(async () => await GetCurrentUserCategoriesAsync());
            return task.Result;
        }

        public async Task<List<Category>> GetCurrentUserCategoriesAsync()
        {
            var users = await _userStorage.GetAllAsync();
            var dbUser = users.FirstOrDefault(user => user.Login == UserManager.Login);

            List<string> categoriesFileNames = new List<string>();
            foreach (Guid guid in dbUser.CategoryGuids)
                categoriesFileNames.Add(guid.ToString("N"));

            if (categoriesFileNames.Count == 0)
                return new List<Category>();

            List<Category> categoriesResult = new List<Category>();
            var categories = await _categoryStorage.GetAllAsync();

            foreach (string fileName in categoriesFileNames)
            {
                DBCategory tempWallet = categories.FirstOrDefault(category => category.FileName == fileName);
                Category category = new Category()
                {
                    Label = tempWallet.Label,
                    Description = tempWallet.Description,
                    FileName = tempWallet.FileName
                };
                categoriesResult.Add(category);
            }

            return categoriesResult;
        }
    }
}
