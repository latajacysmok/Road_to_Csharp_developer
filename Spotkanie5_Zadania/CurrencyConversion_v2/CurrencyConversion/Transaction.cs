namespace CurrencyConversion
{
    class Transaction
    {
        Option appOption = new Option();
        Cantor cantor = new Cantor();
        public decimal amount;
        public void BuyOrSell()
        {
            Console.Write("Dear user, tell me what you want? Buy?\n");
            int buy = appOption.DecideWhichOption();
            if (buy == 1) Buying();
            else if (buy == 2) Selling();
        }

        public void Buying()
        {           
            if (OwnCurrency() == 2)
            {
                Console.Write("User, to sure do you want to use ready-made currencies?: \n");
                int assignItYourself = appOption.DecideWhichOption();

                if (assignItYourself == 1)
                {
                    var result = cantor.PurchaseCurrency();
                    string currency = cantor.foreignCurrency;
                    decimal currencyValue = Math.Round(result, 4);
                    currencyValue = Math.Round(currencyValue, 4);
                    Console.Write($"I understand my dear user, you have chosen {currency}, and how many {currency}s do you need buy: ");
                    amount = appOption.DownloadAmount();
                    Console.WriteLine($"{amount} {currency}s will cost you: {Math.Round(amount * currencyValue, 2)} PLN.");
                }
                else if (assignItYourself == 2) appOption.NoDecisionYet();
            }
        }

        public void Selling()
        {
            Console.Write("Dear user, tell me what you want? Sell?\n");
            int sell = appOption.DecideWhichOption();

            if (OwnCurrency() == 2)
            {
            Console.Write("User, to sure make a choice regarding the exchange rate now?: \n");
            int exchangeRate = appOption.DecideWhichOption();

            if (exchangeRate == 1)
            {
                var result = cantor.SellCurrency();
                string currency = cantor.foreignCurrency;
                decimal currencyValue = Math.Round(result, 4);
                Console.Write($"I understand my dear user, you have chosen {currency}, and how many {currency}s do you need sell: ");
                        amount = appOption.DownloadAmount();
                        Console.WriteLine($"For {amount} {currency} you will get: {Math.Round(amount * currencyValue, 2)} PLN.");
            }
            else if (exchangeRate == 2) appOption.NoDecisionYet();
            }
        }
        public int OwnCurrency()
        {
            Console.Write("User, make your choice regarding the exchange rate now, do you want to set the currency value yourself?: \n");
            int exchangeRate = appOption.DecideWhichOption();
            if (exchangeRate == 1)
            {
                var result = cantor.CurrencyUser();
                string currency = cantor.userCurrency;
                decimal currencyValue = Math.Round(result, 4);

                Console.Write($"I understand my dear user, you have chosen {currency}, and how many {currency} do you need: ");
                amount = appOption.DownloadAmount();
                Console.WriteLine($"{amount} {currency}s will cost you: {Math.Round(amount * currencyValue, 2)} PLN.");
                return exchangeRate;
            }
            return exchangeRate;
        }
    }
}
