using DataStorage;
using System;
using System.Collections.Generic;

namespace Models.Users
{
    public class DBUser : IStorable
    {
        public Guid Guid { get; }
        public string FileName { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Login { get; }
        public string Password { get; }
        public List<Guid> WalletGuids { get; set; }
        public List<Guid> CategoryGuids { get; set; }

        public DBUser(string firstName, string lastName, string email, string login, string password)
        {
            Guid = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Login = login;
            Password = password;

            WalletGuids = new List<Guid>();
            CategoryGuids = new List<Guid>();
            FileName = Login;
        }

        public void AddWallet(Guid walletGuid)
        {
            WalletGuids.Add(walletGuid);
        }
        public void DeleteWallet(Guid walletGuid)
        {
            WalletGuids.Remove(walletGuid);
        }
        public void AddCategory(Guid categoryGuid)
        {
            CategoryGuids.Add(categoryGuid);
        }
        public void DeleteCategory(Guid categoryGuid)
        {
            CategoryGuids.Remove(categoryGuid);
        }

    }
}
