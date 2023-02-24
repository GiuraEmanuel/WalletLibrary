namespace WalletLibrary
{
    public class Currency
    {
        private readonly static List<Currency> _currencies = new List<Currency>() {
                            new Currency("United States Dollar", "$", 2, "USD"),
                            new Currency("Euro", "€", 2, "EUR"),
                            new Currency("Libyan Dinar", "LD", 3, "LYD")};

        public string Name { get; }

        public string Symbol { get; }

        public int Decimals { get; }

        public string CurrencyCode { get; }

        public Currency(string name, string symbol, int decimals, string currencyCode)
        {
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            ArgumentException.ThrowIfNullOrEmpty(symbol, nameof(symbol));
            ArgumentException.ThrowIfNullOrEmpty(currencyCode, nameof(currencyCode));

            if (decimals > 10 || decimals < 0)
            {
                throw new ArgumentException("Invalid number of decimals.", nameof(decimals));
            }

            Name = name;
            Symbol = symbol;
            CurrencyCode = currencyCode;
            Decimals = decimals;
        }

        public static Currency Get(string currencyCode)
        {
            ArgumentException.ThrowIfNullOrEmpty(currencyCode);

            for (int i = 0; i < _currencies.Count; i++)
            {
                var currency = _currencies[i];
                if (currencyCode.Equals(currency.CurrencyCode))
                {
                    return currency;
                }
            }

            throw new ArgumentException("Currency not supported.");
        }

        public override string ToString()
        {
            return $"{Name} ({CurrencyCode})";
        }
    }
}
