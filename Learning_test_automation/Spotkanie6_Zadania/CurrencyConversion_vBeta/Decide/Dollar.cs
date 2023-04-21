namespace CurrencySelection
{
    public class Dollar : Currency
    {
        public Dollar() : base(4.8765m, 4.3888m)
        {
            SymbolCurrency = "$";
            NameCurrency = "Dollar";
        }

        public string NameCurrency { get; private set; }
        public string SymbolCurrency { get; private set; }

    }
}
