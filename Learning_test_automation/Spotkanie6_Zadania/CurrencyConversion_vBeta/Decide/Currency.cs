namespace CurrencySelection
{
    public class Currency//użyć "Czegoś" żeby nie tworzyć obiektu klasy Currency
    {
        public decimal BoughtCurrency { get; private set; }
        public decimal SoldCurrency { get; private set; }
        public decimal UserCurrency { get; private set; }

        private decimal boughtValue;
        private decimal sentValue;
        private decimal userValue;

        public Currency(decimal boughtCurrency, decimal soldCurrency)
        {
            BoughtCurrency = boughtCurrency;
            SoldCurrency = soldCurrency;
        }

        public Currency()
        {
            
        }

        public virtual decimal BoughtValue
        {
            get { return boughtValue; }
            set { boughtValue = Math.Round(value * BoughtCurrency, 2); }
        }

        public decimal SentValue
        {
            get { return sentValue; }
            set { sentValue = Math.Round(value * SoldCurrency, 2); }
        }
        
        public decimal UserTransaction
        {
            get { return userValue; }
            set { userValue = Math.Round(value * UserCurrency, 2); }
        }

        //w inny sposób umożliwić tworzenie obiektu czyli pomyśleć nad konstruktorem
        // mieć konkretny konstruktor który jest wywoływany tylko wtedy gdy użytkownik podaję kurs
        // żeby logika wyciągania wartości waluty była utworzona osobna klasa jak np. Euro
        //prop + tab
    }
}
