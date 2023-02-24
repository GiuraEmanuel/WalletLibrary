using Shouldly;

namespace WalletLibrary.Tests.MoneyTests
{
    [TestClass]
    public class PlusOperatorTests
    {
        [TestMethod]
        public void PlusOperator_SameCurrency_IsSuccessful()
        {
            // Arrange

            var money1 = new Money("USD", 10);
            var money2 = new Money("USD", 5);

            // Act
            var result = money1 + money2;

            // Assert
            result.Amount.ShouldBe(15);
            result.Currency.CurrencyCode.ShouldBe("USD");
        }

        [TestMethod]
        public void PlusOperator_MismatchedCurrency_ThrowsArgumentException()
        {
            // Arrange

            var money1 = new Money("USD", 10);
            var money2 = new Money("EUR", 5);

            // Assert
            Should.Throw<ArgumentException>(() => money1 + money2).Message.ShouldBe("Currencies don't match.");
        }
    }
}
