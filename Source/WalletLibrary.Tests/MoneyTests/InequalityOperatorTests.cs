using Shouldly;

namespace WalletLibrary.Tests.MoneyTests
{
    [TestClass]
    public class InequalityOperatorTests
    {
        [TestMethod]
        public void InequalityOperator_SameValueButDifferentReference_ReturnsFalse()
        {
            var x = new Money("USD", 10);
            var y = new Money("USD", 10);

            bool result = x != y;

            result.ShouldBeFalse();
        }
    }
}
