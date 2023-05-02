using CurrencySelection;
using System.Diagnostics;

namespace CurrencyConversion
{
    public class Transaction
    {
        Option option = new Option();
        CurrencyPresentation currencyPresentation = new CurrencyPresentation();
        Currency dollar = new Dollar();
        Currency euro = new Euro();
        Currency czechCrown = new CzechCrown();
        List<Currency> currencies = new List<Currency>();

        public void Buying()
        {
            currencyPresentation.PrintAvailableBuyExchangeRates();
            if (OwnCurrency() == MakingDecision.No) BuyOrSellCurrency();
        }

        public void Selling()
        {
            currencyPresentation.PrintAvailableSellExchangeRates();
            if (OwnCurrency() == MakingDecision.No) BuyOrSellCurrency();
        }
        private MakingDecision OwnCurrency()
        {
            CurrencyName userName = new CurrencyName();

            Console.Write("User, make your choice regarding the exchange rate now, do you want to set the currency value yourself?: \n");
            MakingDecision exchangeRate = option.DecideWhichOption();
            if (exchangeRate == MakingDecision.Yes)
            {
                string caller = new StackTrace().GetFrame(1).GetMethod().Name;
                bool ifBuy;
                if (caller == "Buying") ifBuy = true;
                else ifBuy = false;

                UserCurrency userCurrency = new UserCurrency(ifBuy);

                Console.Write($"I understand my dear user, you have chosen {userCurrency.currencyName}, and how many {userCurrency.currencyName} do you need: ");

                decimal amount = option.GetAmount();
                userCurrency.CurrencyExchange = amount;

                Console.WriteLine($"For {amount} {userCurrency.currencyName} you will get: {userCurrency.CurrencyExchange} PLN.");
                            
                return exchangeRate;
            }
            return exchangeRate;
        }

        private void BuyOrSellCurrency()
        {
            string caller = new StackTrace().GetFrame(1).GetMethod().Name;
            bool ifBuy;
            string transaction;
            if (caller == "Buying")
            {
                ifBuy = true;
                transaction = "buy";
            }
            else
            {
                ifBuy = false;
                transaction = "sell";
            }

            Console.Write($"\nDear user, tell me what currency you want to {transaction}: \n");

            CurrencyDefault currencyDefault = currencyPresentation.GetCurrencyName();
            string result = currencyDefault.ToString() == "Czech_crown" ? "Czech crown" : currencyDefault.ToString();

            Console.Write($"I understand my dear user, you have chosen {result}, and how many {result}s do you need {transaction}: ");

            decimal amount = option.GetAmount();

            currencies.Add(dollar);
            currencies.Add(euro);
            currencies.Add(czechCrown);

            Currency selectedCurrency = currencies.FirstOrDefault(c => c.NameCurrency == currencyDefault.ToString());

            if (ifBuy) Purchase(currencyDefault, amount, selectedCurrency, result);
            else Sale(currencyDefault, amount, selectedCurrency, result);
        }

        private void Purchase(CurrencyDefault currencyDefault, decimal amount, Currency selectedCurrency, string result)
        {

            switch (currencyDefault)
            {
                case CurrencyDefault.Dollar:
                    dollar.BoughtValue = amount;
                    break;
                case CurrencyDefault.Euro:
                    euro.BoughtValue = amount;
                    break;
                case CurrencyDefault.Czech_crown:
                    czechCrown.BoughtValue = amount;
                    break;
                default:
                    Console.WriteLine("Error, something went wrong!!!");
                    break;
            }

            Console.WriteLine($"For {amount} {selectedCurrency.SymbolCurrency} ({result})  you will pay: {selectedCurrency.BoughtValue} PLN.");
        }

        private void Sale(CurrencyDefault currencyDefault, decimal amount, Currency selectedCurrency, string result)
        {
            switch (currencyDefault)
            {
                case CurrencyDefault.Dollar:
                    dollar.SentValue = amount;
                    break;
                case CurrencyDefault.Euro:
                    euro.SentValue = amount;
                    break;
                case CurrencyDefault.Czech_crown:
                    czechCrown.SentValue = amount;
                    break;
                default:
                    Console.WriteLine("Error, something went wrong!!!");
                    break;
            }

            Console.WriteLine($"For {amount} {selectedCurrency.SymbolCurrency} ({result})  you will get: {selectedCurrency.SentValue} PLN.");
        }
    }
}
