using CurrencySelection;

namespace CurrencyConversion
{
    public class CurrencyPresentation
    {
        Option option = new Option();
        Currency dollar = new Dollar();
        Currency euro = new Euro();
        Currency czechCrown = new CzechCrown();
        List<Currency> currencies = new List<Currency>();

        private string name;

        public void BuyOrSell()
        {
            Console.Write("Dear user, tell me what you want?\n");
            Console.WriteLine("If 'Buy' currency, enter: '1'.");
            Console.WriteLine("If 'Sell' currency, enter: '2'.");
            int decision = option.ValidateOptionNumber();
            Transaction transaction = new Transaction();

            if (decision == (int)BuyingAndSelling.Buy) transaction.Buying();
            else if (decision == (int)BuyingAndSelling.Sell) transaction.Selling();
            else Console.WriteLine($"Your number is: {decision}.\nThe given number must equal 1 if you want to continue or 2 if you want to end the program. Try again.");
        }

        public CurrencyDefault GetCurrencyName()
        {
            PrintAvailableCurrencies();

            while (true)
            {
                if (Enum.TryParse(option.ValidateOptionNumber().ToString(), out CurrencyDefault currency)) return currency;
                else Console.WriteLine("Try again, you can choose from among: \n-Dollar: 1,\n-Euro: 2,\n-Czech crown: 3.");
            }
        }

        private void PrintAvailableCurrencies()
        {
            Console.WriteLine("- Dollar: 1,");
            Console.WriteLine("- Euro: 2,");
            Console.WriteLine("- Czech crown: 3.\n");
        }

        public void PrintAvailableBuyExchangeRates()
        {
            Console.WriteLine("\nHere are the values of currencies that we have prepared for you: ");

            currencies.Add(dollar);
            currencies.Add(euro);
            currencies.Add(czechCrown);

            foreach (var currency in currencies)
            {
                name = currency.NameCurrency.ToString() == "Czech_crown" ? "Czech crown" : currency.NameCurrency.ToString();

                Console.WriteLine($"- {name}: {currency.BoughtCurrency} pln,");
            }

            Console.WriteLine();
        }
        public void PrintAvailableSellExchangeRates()
        {
            Console.WriteLine("\nHere are the values of currencies that we have prepared for you: ");

            currencies.Add(dollar);
            currencies.Add(euro);
            currencies.Add(czechCrown);

            foreach (var currency in currencies)
            {
                name = currency.NameCurrency.ToString() == "Czech_crown" ? "Czech crown" : currency.NameCurrency.ToString();

                Console.WriteLine($"- {name}: {currency.SoldCurrency} pln,");
            }

            Console.WriteLine();
        }
    }
}
