using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Models.Users;
using DataStorage;

namespace Services
{
    public class AuthenticationService
    {

        private FileDataStorage<DBUser> _storage = new FileDataStorage<DBUser>();

        public async Task<User> AuthenticateAsync(AuthenticationUser authUser)
        {
            if (String.IsNullOrWhiteSpace(authUser.Login) || String.IsNullOrWhiteSpace(authUser.Password))
                throw new ArgumentException("Login or Password is Empty");
            var users = await _storage.GetAllAsync();
            var dbUser = users.FirstOrDefault(user => user.Login == authUser.Login && user.Password == authUser.Password);
            if (dbUser == null)
                throw new Exception("Wrong Login or Password");
            return new User(dbUser.Guid, dbUser.FirstName, dbUser.LastName, dbUser.Email, dbUser.Login);
        }

        public async Task<bool> RegisterUserAsync(RegistrationUser regUser)
        {
            var users = await _storage.GetAllAsync();
            var dbUser = users.FirstOrDefault(user => user.Login == regUser.Login);
            if (dbUser != null)
                throw new Exception("User already exists");

            if (String.IsNullOrWhiteSpace(regUser.Login) || String.IsNullOrWhiteSpace(regUser.Password) || String.IsNullOrWhiteSpace(regUser.LastName))
                throw new ArgumentException("Login, Password or Last Name is Empty");

            dbUser = new DBUser(regUser.FirstName, regUser.LastName, regUser.Login + "@gmail.com",
                regUser.Login, regUser.Password);
            await _storage.AddOrUpdateAsync(dbUser);
            return true;
        }

    }
}
