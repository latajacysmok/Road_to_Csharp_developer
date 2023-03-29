using Decide;

namespace CurrencyConversion
{
    public class Cantor
    {
        private decimal exchangeRate;
        public CurrencyNames foreignCurrency;
        public string userCurrency;
        Option option = new Option();
        Transaction transaction = new Transaction();

        public void PurchaseCurrency()
        {
            Console.Write("Dear user, tell me what currency you want to buy: \n");
            Currency currency = new Currency(option.GetCurrencyName());
        }

        public void SellCurrency()
        {
            Console.Write("Dear user, tell me what currency you want to sell: \n");
            Currency currency = new Currency(option.GetCurrencyName());
        }

        public decimal CurrencyUser()
        {
            while (true)
            {
                Console.Write("Dear user, tell me what currency you want to sell: ");
                userCurrency = Console.ReadLine();
                if (!String.IsNullOrEmpty(userCurrency))
                {
                    decimal userCourse = UserCourse(userCurrency);
                    return userCourse;
                }
                else Console.WriteLine("Currency name is required, please try again.");
            }
        }

        public decimal UserCourse(string userCurrency)
        {
            Console.Write($"Dear user, give me the exchange rate at which I should count the {userCurrency}: ");
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out exchangeRate)) break;
                else Console.WriteLine($"This is not a number: {exchangeRate}. Try again, please.");
            }
            return (Math.Round(exchangeRate, 4));
        }
    }
}
