using System;
using Xunit;
using Models.Wallets;

namespace EWalletTests
{
    public class WalletTest
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var wallet = new Wallet()
            {
                Label = "UselessWallet",
                Description = "UselessTestWallet",
                Balance = 123,
                Currency = Currency.UAH,
            };

            var expected = "UselessWallet";

            //Act
            var actual = wallet.Label;

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
