using CurrencySelection;
using System;

namespace CurrencyConversion
{
    public class CurrencyPresentation
    {
        Option option = new Option();
        Dollar dollar = new Dollar();
        Euro euro = new Euro();
        CzechCrown czechCrown = new CzechCrown();
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
            foreach (CurrencyDefault currency in Enum.GetValues(typeof(CurrencyDefault)))
            {
                if (currency == CurrencyDefault.Dollar) Console.WriteLine($"- {dollar.NameCurrency}: {dollar.BoughtCurrency} pln,");
                else if (currency == CurrencyDefault.Euro) Console.WriteLine($"- {euro.NameCurrency}: {euro.BoughtCurrency} pln,");
                else if (currency == CurrencyDefault.Czech_crown) Console.WriteLine($"- {czechCrown.NameCurrency}: {czechCrown.BoughtCurrency} pln.");
            }
            Console.WriteLine();
        }
        public void PrintAvailableSellExchangeRates()
        {
            Console.WriteLine("\nHere are the values of currencies that we have prepared for you: ");
            foreach (CurrencyDefault currency in Enum.GetValues(typeof(CurrencyDefault)))
            {
                if (currency == CurrencyDefault.Dollar) Console.WriteLine($"- {dollar.NameCurrency}: {dollar.SoldCurrency} pln,");
                else if (currency == CurrencyDefault.Euro) Console.WriteLine($"- {euro.NameCurrency}: {euro.SoldCurrency} pln,");
                else if (currency == CurrencyDefault.Czech_crown) Console.WriteLine($"- {czechCrown.NameCurrency}: {czechCrown.SoldCurrency} pln.");
            }
            Console.WriteLine();
        }
    }
}
