namespace CurrencySelection
{
    public class UserCurrency : Currency
    {
        public decimal userCurrencyRate;
        public string currencyName;
        private decimal userValue;

        public override decimal BoughtValue
        {
            get { return userValue; }
            set { userValue = Math.Round(value * userCurrencyRate, 2); }
        }

        private CurrencyName userName = new CurrencyName();

        public UserCurrency(bool ifBuy)
        {
            currencyName = userName.UserEntersNameOfCurrency(ifBuy);
            userCurrencyRate = GetUserCourse(currencyName);
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
