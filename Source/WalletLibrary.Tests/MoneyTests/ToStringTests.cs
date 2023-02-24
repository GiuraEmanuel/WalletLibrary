using Shouldly;

namespace WalletLibrary.Tests.MoneyTests
{
    [TestClass]
    public class ToStringTests
    {
        [TestMethod]
        public void ToString_IsSuccessful()
        {
            // Arrange
            var money = new Money("USD", 10);

            // Act
            var result = money.ToString();

            // Assert
            result.ShouldBe("USD $10.00");
        }
    }
}
