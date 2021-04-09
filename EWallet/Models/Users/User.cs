using Models.Wallets;
using System;
using System.Collections.Generic;

namespace Models.Users
{
    public class User
    {
        private string _firstName;
        private string _lastName;
        public List<Wallet> _wallets { get; }
        public User(Guid guid, string firstName, string lastName, string email, string login)
        {
            Guid = guid;
            //FirstName = firstName;
            //LastName = lastName;
            _firstName = firstName;
            _lastName = lastName;
            Email = email;
            Login = login;
        }

        public Guid Guid { get; }
       // public string FirstName { get; }
        //public string LastName { get; }
        public string Email { get; }
        public string Login { get; }
        public string FullName
        {
            get
            {
                string result = _firstName;
                if (!string.IsNullOrWhiteSpace(_lastName))
                {
                    if (!string.IsNullOrWhiteSpace(_firstName))
                    {
                        result += " ";
                    }
                    result += _lastName;
                }
                return result;
            }
        }
    }
}
