using Shouldly;

namespace WalletLibrary.Tests.CurrencyTests
{
    [TestClass]
    public class ToStringTests
    {
        [TestMethod]
        public void ToString_ReturnsName_IsSucessful()
        {
            // Arrange
            var currency = new Currency("United States Dollar", "$", 2, "USD");

            // Act
            var result = currency.ToString();

            // Assert
            result.ShouldBe("United States Dollar (USD)");
        }
    }
}
