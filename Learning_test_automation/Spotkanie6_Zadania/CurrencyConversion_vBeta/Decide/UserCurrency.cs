namespace CurrencySelection
{
    public class UserCurrency
    {
        public decimal BoughtCurrency { get; set; }
        public decimal SoldCurrency { get; set; }
        public decimal UserTransaction { get; set; }

        public string currencyName;     
        private decimal userValue;

        private CurrencyName userName = new CurrencyName();

        public UserCurrency(bool ifBuy)
        {
            currencyName = userName.UserEntersNameOfCurrency(ifBuy);
            if (ifBuy) BoughtCurrency = GetUserCourse(currencyName);
            else SoldCurrency = GetUserCourse(currencyName);

            UserTransaction = ifBuy ? BoughtCurrency : SoldCurrency;
        }

        public decimal CurrencyExchange
        {
            get { return userValue; }
            set { userValue = Math.Round(value * UserTransaction, 2); }
        }

        private decimal GetUserCourse(string currencyUserName)
        {

            Console.Write($"Dear user, give me the exchange rate at which I should count the {currencyUserName}: ");
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out decimal exchangeRate)) return (Math.Round(exchangeRate, 4));
                else Console.Write($"This is not a number: {exchangeRate}. Try again, please: ");
            }
        }
    }
}
