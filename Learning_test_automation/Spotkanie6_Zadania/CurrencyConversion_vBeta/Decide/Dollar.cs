namespace CurrencySelection
{
    public class Dollar : Currency
    {
        public decimal BoughtCurrency;
        public decimal SoldCurrency;
        public string NameCurrency;
        public string SymbolCurrency;
        public decimal boughtValue;
        public decimal BoughtValue
        {
            get { return boughtValue; }
            set { boughtValue = Math.Round(value * BoughtCurrency, 2); }
        }

        public decimal sentValue;
        public decimal SentValue
        {
            get { return sentValue; }
            set { sentValue = Math.Round(value * SoldCurrency, 2); }
        }

        public Dollar()
        {
            BoughtCurrency = 4.8765m;
            SoldCurrency = 4.3888m;
            SymbolCurrency = "$";
            NameCurrency = "Dolar";
        }
    }
}
