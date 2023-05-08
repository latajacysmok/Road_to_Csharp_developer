﻿using CurrencySelection;
using System.Diagnostics;

namespace CurrencyConversion
{
    public class CurrencyPresentation
    {
        Option option = new Option();
        Currency dollar = new Dollar();
        Currency euro = new Euro();
        Currency czechCrown = new CzechCrown();
        List<Currency> currencies = new List<Currency>();
        //Transaction transaction = new Transaction(); //coś się tutaj kiełbasi, dlaczego :D

        private string name = "";// czy ja moge uniknąć takiego przypisywania?

        public CurrencyPresentation()
        {
            currencies.Add(dollar);
            currencies.Add(euro);
            currencies.Add(czechCrown);
        }

        public void BuyOrSell()
        {
            Console.Write("Dear user, tell me what you want?\n");
            Console.WriteLine("If 'Buy' currency, enter: '1'.");
            Console.WriteLine("If 'Sell' currency, enter: '2'.");
            Console.WriteLine("If you want to print sell and buy values for selected currencies, enter: '3'.");
            int decision = option.ValidateOptionNumber();
            Transaction transaction = new Transaction();

            switch (decision)
            {
                case (int)BuyingAndSelling.Buy:
                    transaction.Buying();
                    break;
                case (int)BuyingAndSelling.Sell:
                    transaction.Selling();
                    break;
                case (int)BuyingAndSelling.PrintSaleAndPurchaseValues:
                    transaction.PrintingSalesAndPurchaseValues();
                    break;
                default:
                    Console.WriteLine($"Your number is: {decision}.\nThe given number must equal 1 if you want to continue or 2 if you want to end the program. Try again.");
                    break;
            }
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

        public void PrintAvailableListExchangeRatesValue()
        {
            string caller = new StackTrace().GetFrame(1).GetMethod().Name;

            Console.WriteLine("\nHere are the values of currencies that we have prepared for you: ");

            foreach (var currency in currencies)
            {
                name = currency.NameCurrency.ToString();

                if (caller == "Buying") Console.WriteLine($"- {name}: {currency.BoughtCurrency} pln,");
                else Console.WriteLine($"- {name}: {currency.SoldCurrency} pln,");
            }

            Console.WriteLine();
        }

        public void PrintAvailableBuyAndSellExchangeRates()
        {
            Transaction transaction = new Transaction();

            Console.Write($"I understand my dear user, you have chosen to print the value of each available currency.\nEnter the value to be converted: ");

            decimal amount = option.GetAmount();

            List<CurrencyDefault> currenciesNames = new List<CurrencyDefault>();
            currenciesNames.Add(CurrencyDefault.Dollar);
            currenciesNames.Add(CurrencyDefault.Euro);
            currenciesNames.Add(CurrencyDefault.Czech_crown);

            transaction.PrintOutValueOfBuyingAndSellingCurrency(currenciesNames, amount);
        }
    }
}
