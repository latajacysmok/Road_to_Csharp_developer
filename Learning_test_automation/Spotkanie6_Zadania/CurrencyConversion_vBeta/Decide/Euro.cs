namespace CurrencySelection
{
    public class Euro : Currency
    {
        public Euro() : base(5.3722m, 5.3722m)
        {
            SymbolCurrency = "€";
            NameCurrency = "Euro";
        }

        public string NameCurrency { get; private set; }
        public string SymbolCurrency { get; private set; }
    }
}
