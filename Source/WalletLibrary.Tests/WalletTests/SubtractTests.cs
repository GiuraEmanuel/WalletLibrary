using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace WalletLibrary.Tests.WalletTests
{
    [TestClass]
    public class SubtractTests
    {
        [TestMethod]
        public void Subtract_IsSuccessful()
        {
            // Arrange
            var wallet = new Wallet();

            // Act
            wallet.Add("USD", 10);
            wallet.Subtract("USD", 10);

            // Assert
            wallet["USD"].Amount.ShouldBe(0);
            wallet.ToString().ShouldBe("USD $0.00");
        }

        [TestMethod]
        public void Subtract_CurrencyIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var wallet = new Wallet();

            // Assert
            Should.Throw<ArgumentNullException>(() => wallet.Subtract(null, 10));
        }

        public void SubtractMoney_IsSuccessful()
        {
            // Arrange
            var wallet = new Wallet();
            var money = new Money("USD", 10);
            // Act
            wallet.Add(money);
            wallet.Subtract(money);

            // Assert
            wallet["USD"].Amount.ShouldBe(0);
            wallet.ToString().ShouldBe("USD $0.00");
        }

        [TestMethod]
        public void SubtractMoney_MoneyIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var wallet = new Wallet();
            Money money = null;

            // Assert
            Should.Throw<ArgumentNullException>(() => wallet.Subtract(money));
        }
    }
}
