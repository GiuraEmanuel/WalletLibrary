namespace WalletLibrary
{
    public sealed class Money : IEquatable<Money>
    {
        public Currency Currency { get; }

        public decimal Amount { get; }

        public Money(string currencyCode, decimal amount)
        {
            Currency = Currency.Get(currencyCode);
            Amount = amount;
        }

        public Money(Currency currency, decimal amount)
        {
            ArgumentNullException.ThrowIfNull(currency);
            Currency = currency;
            Amount = amount;
        }

        public static bool operator ==(Money x, Money y)
        {
            ArgumentNullException.ThrowIfNull(x);
            ArgumentNullException.ThrowIfNull(y);

            return x.Equals(y);
        }

        public static bool operator !=(Money x, Money y) => !(x == y);

        public static Money operator +(Money x, Money y)
        {
            ArgumentNullException.ThrowIfNull(x);
            ArgumentNullException.ThrowIfNull(x);

            if (x.Currency != x.Currency)
            {
                throw new ArgumentException("Currencies don't match.");
            }

            return new Money(x.Currency, x.Amount + x.Amount);
        }

        public static Money operator -(Money x, Money y)
        {
            ArgumentNullException.ThrowIfNull(x);
            ArgumentNullException.ThrowIfNull(y);

            if (x.Currency != y.Currency)
            {
                throw new ArgumentException("Currencies don't match.");
            }

            return new Money(x.Currency, x.Amount - y.Amount);
        }

        public static Money operator -(Money value) 
        {
            ArgumentNullException.ThrowIfNull(value);

            return new Money(value.Currency, -value.Amount);
        } 

        public override string ToString()
        {
            if (Amount < 0)
            {
                return $"{Currency.CurrencyCode} -{Currency.Symbol}{(-Amount).ToString("N" + Currency.Decimals)}";
            }

            return $"{Currency.CurrencyCode} {Currency.Symbol}{Amount.ToString("N" + Currency.Decimals)}";
        }

        public bool Equals(Money? money)
        {
            if (money is null)
            {
                return false;
            }

            // checks if money and this point to the same address
            if (ReferenceEquals(this, money))
            {
                return true;
            }

            return Currency == money.Currency && Amount == money.Amount;
        }

        public override bool Equals(object? obj)
        {
            return obj is Money money && Equals(money);
        }

        public override int GetHashCode() => (Currency, Amount).GetHashCode();
    }
}
