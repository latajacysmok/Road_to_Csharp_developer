namespace CurrencySelection
{
    public class CzechCrown : Currency
    {
        public CzechCrown() : base(boughtCurrency: 0.2745m, soldCurrency: 0.2470m)
        {
            SymbolCurrency = "Kč";
            NameCurrency = "Czech crown";
        }

        public string NameCurrency { get; private set; }
        public string SymbolCurrency { get; private set; }
    }
}
