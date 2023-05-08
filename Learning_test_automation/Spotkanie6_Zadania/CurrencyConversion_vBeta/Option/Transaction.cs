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

        private decimal amount;

        public Transaction()
        {
            currencies.Add(dollar);
            currencies.Add(euro);
            currencies.Add(czechCrown);
        }

        public void Buying()
        {
            currencyPresentation.PrintAvailableListExchangeRatesValue();
            if (OwnCurrency() == MakingDecision.No) Purchase();
        }

        public void Selling()
        {
            currencyPresentation.PrintAvailableListExchangeRatesValue();
            if (OwnCurrency() == MakingDecision.No) Sale();
        }

        public void PrintingSalesAndPurchaseValues()
        {
            currencyPresentation.PrintAvailableBuyAndSellExchangeRates();
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

                amount = option.GetAmount();
                userCurrency.CurrencyExchange = amount;

                Console.WriteLine($"For {amount} {userCurrency.currencyName} you will get: {userCurrency.CurrencyExchange} PLN.");
                            
                return exchangeRate;
            }
            return exchangeRate;
        }   

        private void Purchase()
        {
            Console.Write($"\nDear user, tell me what currency you want to buy: \n");

            CurrencyDefault currencyDefault = currencyPresentation.GetCurrencyName();

            string result = currencyDefault.GetDisplayName();
            Currency selectedCurrency = currencies.First(c => c.NameCurrency == currencyDefault.GetDisplayName());

            Console.Write($"I understand my dear user, you have chosen {result}, and how many {result}s do you need buy: ");

            decimal amount = option.GetAmount();
            ValueOfPurchase(currencyDefault, amount);

            Console.WriteLine($"For {amount} {selectedCurrency.SymbolCurrency} ({result})  you will pay: {selectedCurrency.BoughtValue} PLN.");
        }

    private void Sale()
        {
            Console.Write($"\nDear user, tell me what currency you want to sell: \n");

            CurrencyDefault currencyDefault = currencyPresentation.GetCurrencyName();
            string result = currencyDefault.GetDisplayName();
            Currency selectedCurrency = currencies.First(c => c.NameCurrency == currencyDefault.GetDisplayName());

            Console.Write($"I understand my dear user, you have chosen {result}, and how many {result}s do you need sell: ");

            amount = option.GetAmount();
            ValueOfSales(currencyDefault, amount);

            Console.WriteLine($"For {amount} {selectedCurrency.SymbolCurrency} ({result})  you will get: {selectedCurrency.SentValue} PLN.");
        }

        private void ValueOfPurchase(CurrencyDefault currencyDefault, decimal amount)
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
        }
        
        private void ValueOfSales(CurrencyDefault currencyDefault, decimal amount)
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
        }

        public void PrintOutValueOfBuyingAndSellingCurrency(List<CurrencyDefault> currenciesNames, decimal amount)
        {           
            for (int i = 0; i < currencies.Count; i++)
            {
                ValueOfPurchase(currenciesNames[i], amount);
                Console.WriteLine($"For {amount} {currencies[i].SymbolCurrency} ({currencies[i].NameCurrency})  you will pay: {currencies[i].BoughtValue} PLN.");
                

                ValueOfSales(currenciesNames[i], amount);
                Console.WriteLine($"For {amount} {currencies[i].SymbolCurrency} ({currencies[i].NameCurrency})  you will get: {currencies[i].SentValue} PLN.");

                Console.WriteLine("*****************************************");
                Console.WriteLine();
            }
        }
    }
}
