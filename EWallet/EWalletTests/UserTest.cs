using Models.Users;
using System;
using Xunit;

namespace EWalletTests
{
    public class UserTest
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var user = new User(Guid.NewGuid(), "Ivan", "Pohodichev", "IvanPohodichev@gmail.com", "IPohodichev");

            var expected = "Ivan Pohodichev";

            //Act
            var actual = user.FullName;

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
