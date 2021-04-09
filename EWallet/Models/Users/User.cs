using Models.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Users
{
    public class User
    {
        public List<Wallet> _wallets { get; }
        public User(Guid guid, string firstName, string lastName, string email, string login)
        {
            Guid = guid;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Login = login;
        }

        public Guid Guid { get; }
        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public string Login { get; }
    }
}
