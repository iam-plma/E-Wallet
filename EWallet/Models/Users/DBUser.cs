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
        public List<Guid> WalletsGuids { get; set; }

        public DBUser(string firstName, string lastName, string email, string login, string password)
        {
            Guid = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Login = login;
            Password = password;

            WalletsGuids = new List<Guid>();
            FileName = Login;
        }

        public void AddWallet(Guid walletGuid)
        {
            WalletsGuids.Add(walletGuid);
        }
        public void DeleteWallet(Guid walletGuid)
        {
            WalletsGuids.Remove(walletGuid);
        }

    }
}
