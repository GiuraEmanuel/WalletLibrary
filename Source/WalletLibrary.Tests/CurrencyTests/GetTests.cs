using Shouldly;
using System.Management;

namespace WalletLibrary.Tests.CurrencyTests
{
    [TestClass]
    public class GetTests
    {
        [TestMethod]
        public void Get_IsSucessful()
        {
            // Act
            var result = Currency.Get("USD");

            // Assert
            result.CurrencyCode.ShouldBe("USD");
            result.ToString().ShouldBe("United States Dollar (USD)");
        }

        [TestMethod]
        public void Get_CurrencyNotFound_ThrowsArgumentException()
        {
            Should.Throw<ArgumentException>(() => Currency.Get("XYZ")).Message.ShouldBe("Currency not supported.");
        }
    }
}
