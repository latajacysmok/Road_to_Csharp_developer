namespace CurrencySelection
{
    public class Euro : Currency
    {
        public Euro() : base( boughtCurrency: 5.3722m, soldCurrency: 5.1722m)
        {
            SymbolCurrency = "€";
            NameCurrency = "Euro";
        }

        public string NameCurrency { get; private set; }
        public string SymbolCurrency { get; private set; }
    }
}
