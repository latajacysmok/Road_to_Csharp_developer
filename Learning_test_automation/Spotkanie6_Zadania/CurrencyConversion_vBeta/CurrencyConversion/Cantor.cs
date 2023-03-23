namespace CurrencyConversion
{
    class Cantor
    {
        private decimal exchangeRate;
        public string foreignCurrency;
        public string userCurrency;
        Option.Option option = new Option.Option();

        public decimal PurchaseCurrency()
        {
            Console.Write("Dear user, tell me what currency you want to buy: \n");
            foreignCurrency = option.IsCurrency();
            switch (foreignCurrency)
            {
                case "Dollar":
                    return 4.8765m;
                case "Euro":
                    return 5.3722m;
                case "Czech crown":
                    return 0.2745m;
                default:
                    return 0;
            }
        }

        public decimal SellCurrency()
        {
            Console.Write("Dear user, tell me what currency you want to sell: \n");
            foreignCurrency = option.IsCurrency();
            switch (foreignCurrency)
            {
                case "Dollar":
                    return 4.3888m;
                case "Euro":
                    return 4.8349m;
                case "Czech crown":
                    return 0.2470m;
                default:
                    return 0;
            }
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
