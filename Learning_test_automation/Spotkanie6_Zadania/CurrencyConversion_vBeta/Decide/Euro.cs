namespace CurrencySelection
{
    public class Euro : Currency
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

        public Euro()
        {
            BoughtCurrency = 5.3722m;
            SoldCurrency = 5.3722m;
            SymbolCurrency = "€";
            NameCurrency = "Euro";
            //zastanowić się co jeszcze mogłoby być w klasie bazowej a co konkretnie w pochodnej.
        }
}
}
