namespace CurrencyConversion
{
    class Cantor
    {
        public decimal exchangeRate;
        public string foreignCurrency;
        AppOption appOption = new AppOption();
        public (string, decimal) PurchaseCurrency()
        {
            Console.Write("Dear user, tell me what currency you want to buy: \n");
            AvailableCurrencies();
            foreignCurrency = appOption.IsCurrency();
            switch (char.ToUpper(foreignCurrency[0]) + foreignCurrency.Substring(1))
            {
                case "Dollar":
                    exchangeRate = 4.8765m;
                    break;
                case "Euro":
                    exchangeRate = 5.3722m;
                    break;
                case "Czech crown":
                    exchangeRate = 0.2745m;
                    break;
            }
            return (foreignCurrency, exchangeRate);
        }

        public (string, decimal) SellCurrency()
        {
            Console.Write("Dear user, tell me what currency you want to sell: \n");
            AvailableCurrencies();
            foreignCurrency = appOption.IsCurrency();
            switch (char.ToUpper(foreignCurrency[0]) + foreignCurrency.Substring(1))
            {
                case "Dollar":
                    exchangeRate = 4.3888m;
                    break;
                case "Euro":
                    exchangeRate = 4.8349m;
                    break;
                case "Czech crown":
                    exchangeRate = 0.2470m;
                    break;
            }
            return (foreignCurrency, exchangeRate);
        }

        public (string, decimal) CurrencyAndUserCourse()
        {
            string userCurrency;
            while (true)
            {
                Console.Write("Dear user, tell me what currency you want to sell: ");
                userCurrency = Console.ReadLine();
                if (!String.IsNullOrEmpty(userCurrency)) break;
                else Console.WriteLine("Currency name is required, please try again.");
            }

            Console.Write($"Dear user, give me the exchange rate at which I should count the {userCurrency}: ");
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out exchangeRate)) break;
                else Console.WriteLine($"This is not a number: {exchangeRate.ToString()}. Try again, please.");
            }
            return (userCurrency, Math.Round(exchangeRate, 4));
        }

        public void AvailableCurrencies()
        {
            Console.WriteLine("- Dollar,");
            Console.WriteLine("- Euro,");
            Console.WriteLine("- Czech crown.");
        }
    }
}
