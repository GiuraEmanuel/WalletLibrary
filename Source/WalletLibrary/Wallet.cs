namespace WalletLibrary
{
    public class Wallet
    {
        private readonly List<Money> _values = new();

        public Money this[string currencyCode] => this[Currency.Get(currencyCode)];

        public Money this[Currency currency]
        {
            get
            {
                var index = _values.FindIndex(m => m.Currency == currency);

                if (index < 0)
                {
                    return new Money(currency, 0);
                }

                return _values[index];
            }
        }

        public void Add(Money money)
        {
            ArgumentNullException.ThrowIfNull(money);

            var index = _values.FindIndex(m => m.Currency == money.Currency);

            if (index >= 0)
            {
                _values[index] += money;
            }
            else
            {
                _values.Add(money);
            }
        }

        public void Add(string currencyCode, decimal amount) => Add(new Money(currencyCode, amount));

        public void Subtract(string currencyCode, decimal amount)
        {
            Add(currencyCode, -amount);
        }

        public void Subtract(Money money)
        {
            ArgumentNullException.ThrowIfNull(money);
            Add(-money);
        }

        public override string ToString()
        {
            return string.Join(", ", _values);
        }
    }
}
