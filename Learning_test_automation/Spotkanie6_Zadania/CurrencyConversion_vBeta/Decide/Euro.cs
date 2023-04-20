namespace Decide
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

        public Euro()//czy ja muszę dawać argument w konstruktorze z wszystkimi mozliwościami dla CurrencyDefault 
        {
            BoughtCurrency = 5.3722m;
            SoldCurrency = 5.3722m;
            SymbolCurrency = "€";
            NameCurrency = "Euro";

            //przypisywanie propertkom wartości, czyli temu wyżej przypisać tutaj wartości a nie tam na górze.
            //usunięcie metod switch w Currency(3 są).
            //zastanowić się co jeszcze mogłoby być w klasie bazowej a co konkretnie w pochodnej.
            // powtórz powyższe dla pozostałych walut.
        }
}
}
