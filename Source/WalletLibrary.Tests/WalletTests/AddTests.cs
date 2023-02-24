using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace WalletLibrary.Tests.WalletTests
{
    [TestClass]
    public class AddTests
    {
        [TestMethod]
        public void AddMoney_IsSuccessful()
        {
            // Arrange
            var money = new Money("USD", 10);
            var wallet = new Wallet();

            // Act
            wallet.Add(money);

            // Assert
            wallet["USD"].ShouldBe(money);

            // Act
            wallet.Add(money);

            // Assert
            wallet["USD"].ShouldBe(money + money);
            wallet.ToString().ShouldBe("USD $20.00");
        }

        [TestMethod]
        public void AddMoney_MultipleCurrencies_IsSuccessful()
        {
            // Arrange
            var usdMoney = new Money("USD", 10);
            var eurMoney = new Money("EUR", 10);
            var wallet = new Wallet();

            // Act
            wallet.Add(usdMoney);
            wallet.Add(usdMoney);
            wallet.Add(eurMoney);
            wallet.Add(eurMoney);

            // Assert
            wallet["USD"].ShouldBe(usdMoney + usdMoney);
            wallet["EUR"].ShouldBe(eurMoney + eurMoney);
            wallet.ToString().ShouldBe("USD $20.00, EUR €20.00");
        }

        [TestMethod]
        public void Add_IsSuccessful()
        {
            // Arrange
            var wallet = new Wallet();

            // Act
            wallet.Add("USD", 10);

            // Assert
            wallet["USD"].Amount.ShouldBe(10);
            wallet.ToString().ShouldBe("USD $10.00");
        }
    }
}
