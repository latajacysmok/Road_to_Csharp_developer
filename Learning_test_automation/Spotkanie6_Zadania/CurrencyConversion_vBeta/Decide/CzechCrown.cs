namespace Decide
{
    public class CzechCrown : Currency
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

        private decimal sentValue;
        public decimal SentValue
        {
            get { return sentValue; }
            set { sentValue = Math.Round(value * SoldCurrency, 2); }
        }

        public CzechCrown()
        {
            BoughtCurrency = 0.2745m;
            SoldCurrency = 0.2470m;
            SymbolCurrency = "Kč";
            NameCurrency = "Czech crown";
        }
    }
}
