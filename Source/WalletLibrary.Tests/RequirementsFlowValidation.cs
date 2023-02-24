using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace WalletLibrary.Tests
{
    [TestClass]
    public class RequirementsFlowValidation
    {
        [TestMethod]
        public void RequirementsFlowValidationTest_IsSuccessful()
        {
            // Arrange
            Currency usd = Currency.Get("USD");
            var usdMoney = new Money("USD", 10);
            var usdMoney1 = new Money(usd, 10);
            Wallet wallet = new Wallet();

            // Act
            wallet.Add(new Money("USD", 10));
            wallet.Add("USD", 5);
            wallet.Subtract("EUR", 50);

            // Assert
            usd.ToString().ShouldBe("United States Dollar (USD)");
            usdMoney.ToString().ShouldBe("USD $10.00");
            usdMoney.Currency.ToString().ShouldBe("United States Dollar (USD)");
            usdMoney.Amount.ToString().ShouldBe("10");
            wallet.ToString().ShouldBe("USD $15.00, EUR -€50.00");
            (wallet["USD"] + new Money("USD", 5)).ToString().ShouldBe("USD $20.00");
            Should.Throw<ArgumentException>(() => usdMoney + new Money("EUR", 10));
        }
    }
}
