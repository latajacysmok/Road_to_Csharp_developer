namespace CurrencySelection
{
    public abstract class Currency
    {
        public decimal BoughtCurrency { get; set; }
        public decimal SoldCurrency { get; set; }
        public string NameCurrency { get; set; }
        public string SymbolCurrency { get; set; }

        private decimal boughtValue;
        private decimal sentValue;

        public Currency(decimal boughtCurrency, decimal soldCurrency, string nameCurrency, string symbolCurrency)//CurrencyDefault
        {
            BoughtCurrency = boughtCurrency;
            SoldCurrency = soldCurrency;
            NameCurrency = nameCurrency;
            SymbolCurrency = symbolCurrency;
        }

        public decimal BoughtValue
        {
            get { return boughtValue; }
            set { boughtValue = Math.Round(value * BoughtCurrency, 2); }
        }

        public decimal SentValue
        {
            get { return sentValue; }
            set { sentValue = Math.Round(value * SoldCurrency, 2); }
        }

        /*public string NameCurrency(CurrencyDefault name)
        {
            return name.ToString();
        }*/
        //w inny sposób umożliwić tworzenie obiektu czyli pomyśleć nad konstruktorem
        // mieć konkretny konstruktor który jest wywoływany tylko wtedy gdy użytkownik podaję kurs
        //prop + tab
    }
}
