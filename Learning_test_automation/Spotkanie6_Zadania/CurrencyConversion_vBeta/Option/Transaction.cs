using CurrencySelection;
using System.Diagnostics;

namespace CurrencyConversion
{
    public class Transaction
    {
        Option option = new Option();
        CurrencyPresentation currencyPresentation = new CurrencyPresentation();
        Dollar dollar = new Dollar();
        Euro euro = new Euro();
        CzechCrown czechCrown = new CzechCrown();

        public void Buying()
        {
            currencyPresentation.PrintAvailableBuyExchangeRates();
            if (OwnCurrency() == MakingDecision.No) BuyCurrency();
        }

        public void Selling()
        {
            currencyPresentation.PrintAvailableSellExchangeRates();
            if (OwnCurrency() == MakingDecision.No) SellCurrency();
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
                userCurrency.UserTransaction = amount;

                Console.WriteLine($"For {amount} {userCurrency.currencyName} you will get: {userCurrency.BoughtValue} PLN.");

                return exchangeRate;
            }
            return exchangeRate;
        }

        private void SellCurrency()
        {        
            Console.Write("\nDear user, tell me what currency you want to sell: \n");
            
            CurrencyDefault currencyDefault = currencyPresentation.GetCurrencyName();
            string result = currencyDefault.ToString() == "Czech_crown" ? "Czech crown" : currencyDefault.ToString();

            Console.Write($"I understand my dear user, you have chosen {result}, and how many {result}s do you need sell: ");
            
            decimal amount = option.GetAmount();
            string currencySymbol = "None!";
            decimal sentValue = 0;

            if (currencyDefault == CurrencyDefault.Dollar)
            {
                dollar.SentValue = amount;
                sentValue = dollar.SentValue;
                currencySymbol = dollar.SymbolCurrency;
            }
            else if (currencyDefault == CurrencyDefault.Euro)
            {
                euro.SentValue = amount;
                sentValue = euro.SentValue;
                currencySymbol = euro.SymbolCurrency;
            }
            else if (currencyDefault == CurrencyDefault.Czech_crown)
            {
                czechCrown.SentValue = amount;
                sentValue = czechCrown.SentValue;
                currencySymbol = czechCrown.SymbolCurrency;
            }

            Console.WriteLine($"For {amount} {currencySymbol} ({result})  you will get: {sentValue} PLN.");
        }

        private void BuyCurrency()
        {         
            Console.Write("\nDear user, tell me what currency you want to buy: \n");
            
            CurrencyDefault currencyDefault = currencyPresentation.GetCurrencyName();
            string result = currencyDefault.ToString() == "Czech_crown" ? "Czech crown" : currencyDefault.ToString();

            Console.Write($"I understand my dear user, you have chosen {result}, and how many {result}s do you need buy: ");

            decimal amount = option.GetAmount();
            string currencySymbol = "None!";
            decimal boughtValue = 0;

            if (currencyDefault == CurrencyDefault.Dollar)
            {
                dollar.BoughtValue = amount;
                boughtValue = dollar.BoughtValue;
                currencySymbol = dollar.SymbolCurrency;
            }
            else if (currencyDefault == CurrencyDefault.Euro)
            {
                euro.BoughtValue = amount;
                boughtValue = euro.BoughtValue;
                currencySymbol = euro.SymbolCurrency;
            }
            else if (currencyDefault == CurrencyDefault.Czech_crown)
            {
                czechCrown.BoughtValue = amount;
                boughtValue = czechCrown.BoughtValue;
                currencySymbol = czechCrown.SymbolCurrency;
            }

            Console.WriteLine($"For {amount} {currencySymbol} ({result}) you will pay: {boughtValue} PLN.");
        }
    }
}
