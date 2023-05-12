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
        private bool ifBuy;

        public Transaction()
        {
            currencies.Add(dollar);
            currencies.Add(euro);
            currencies.Add(czechCrown);
        }

        public void Buy()
        {
            if (OwnCurrency(CurrencyTrading.Buy) == MakingDecision.No) PurchaseValueSetting();
        }

        public void Sell()
        {
            if (OwnCurrency(CurrencyTrading.Sell) == MakingDecision.No) SalesValueSetting();
        }

        private MakingDecision OwnCurrency(CurrencyTrading choice)
        {
            CurrencyName userName = new CurrencyName();

            Console.Write("User, make your choice regarding the exchange rate now, do you want to set the currency value yourself?: \n");
            MakingDecision exchangeRate = option.DecideWhichOption();
            if (exchangeRate == MakingDecision.Yes)
            {
                if (choice == CurrencyTrading.Buy) ifBuy = true;
                else if (choice == CurrencyTrading.Buy) ifBuy = false;

                UserCurrency userCurrency = new UserCurrency(ifBuy);

                Console.Write($"I understand my dear user, you have chosen {userCurrency.currencyName}, and how many {userCurrency.currencyName} do you need: ");

                amount = option.GetAmount();
                userCurrency.CurrencyExchange = option.GetAmount();

                Console.WriteLine($"For {amount} {userCurrency.currencyName} you will get: {userCurrency.CurrencyExchange} PLN.");
                            
                return exchangeRate;
            }
            return exchangeRate;
        }   

        private void PurchaseValueSetting()
        {
            Console.Write($"\nDear user, tell me what currency you want to buy: \n");

            CurrencyDefault currencyDefault = currencyPresentation.GetCurrencyName();

            string result = currencyDefault.GetDisplayName();
            Currency selectedCurrency = currencies.First(c => c.NameCurrency == result);

            Console.Write($"I understand my dear user, you have chosen {result}, and how many {result}s do you need buy: ");

            decimal amount = option.GetAmount();
            ValueOfPurchase(currencyDefault, amount);

            Console.WriteLine($"For {amount} {selectedCurrency.SymbolCurrency} ({result})  you will pay: {selectedCurrency.BoughtValue} PLN.");
        }

    private void SalesValueSetting()
        {
            Console.Write($"\nDear user, tell me what currency you want to sell: \n");

            CurrencyDefault currencyDefault = currencyPresentation.GetCurrencyName();
            string result = currencyDefault.GetDisplayName();
            Currency selectedCurrency = currencies.First(c => c.NameCurrency == result);

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
