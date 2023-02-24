using Shouldly;

namespace WalletLibrary.Tests.MoneyTests
{
    [TestClass]
    public class EqualsTests
    {
        [TestMethod]
        public void Equals_MatchingValues_ReturnsTrue()
        {
            //Arrange
            var money1 = new Money("USD", 10);
            var money2 = new Money("USD", 10);

            // Act
            var result = money1.Equals(money2);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void Equals_MismatchedAmount_ReturnsFalse()
        {
            //Arrange
            var money1 = new Money("USD", 10);
            var money2 = new Money("USD", 20);

            // Act
            var result = money1.Equals(money2);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void Equals_MismatchedCurrency_ReturnsFalse()
        {
            //Arrange
            var money1 = new Money("USD", 10);
            var money2 = new Money("EUR", 20);

            // Act
            var result = money1.Equals(money2);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void Equals_SameInstance_ReturnsTrue()
        {
            //Arrange
            var money1 = new Money("USD", 10);

            // Act
            var result = money1.Equals(money1);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void Equals_NullInstance_ReturnsFalse()
        {
            //Arrange
            var money1 = new Money("USD", 10);
            Money? money2 =  null;

            // Act
            var result = money1.Equals(money2);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void ObjectEquals_ObjectIsMoney_ReturnsTrue()
        {
            //Arrange
            object money1 = new Money("USD", 10);
            object money2 = new Money("USD", 10);

            // Act
            var result = money1.Equals(money2);

            // Assert
            result.ShouldBeTrue();
        }
    }
}
