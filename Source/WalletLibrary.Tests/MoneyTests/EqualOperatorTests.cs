using Shouldly;

namespace WalletLibrary.Tests.MoneyTests
{
    [TestClass]
    public class EqualOperatorTests
    {
        [TestMethod]
        public void EqualOperator_NonNullValues_ReturnsTrue()
        {
            // Arrange
            var money1 = new Money("USD", 10);
            var money2 = new Money("USD", 10);

            // Act
            var result = money1 == money2;

            // Assert
            result.ShouldBeTrue();
        }

        public void EqualsOperator_OneValueIsNull_ReturnsFalse()
        {
            Money value = new Money("USD", 10);
            Money nullValue = null;

            (value == nullValue).ShouldBeFalse();
            (nullValue == value).ShouldBeFalse();
        }
    }
}
