using Decide;
using System.Diagnostics;

namespace CurrencyConversion
{
    public class Transaction
    {
        Option option = new Option();
        private Currency _currency;

        public void Buying()
        {
            option.PrintAvailableBuyExchangeRates();
            if (OwnCurrency() == MakingDecision.No) BuyCurrency();
        }

        public void Selling()
        {
            option.PrintAvailableSellExchangeRates();
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

                string name = userName.UserEntersNameOfCurrency(ifBuy);
                _currency = new Currency(name);

                Console.Write($"I understand my dear user, you have chosen {_currency.UserNameCurrency}, and how many {_currency.UserNameCurrency} do you need: ");

                decimal amount = _currency.GetAmount();

                Console.WriteLine($"For {amount} {_currency.UserNameCurrency} you will get: {amount * _currency.UserValueCurrency} PLN.");

                return exchangeRate;
            }
            return exchangeRate;
        }

        private void SellCurrency()
        {        
            Console.Write("Dear user, tell me what currency you want to sell: \n");
            
            CurrencyDefault currencyDefault = option.GetCurrencyName();       
            string result = currencyDefault.ToString() == "Czech_crown" ? "Czech crown" : currencyDefault.ToString();

            Console.Write($"I understand my dear user, you have chosen {result}, and how many {result}s do you need sell: ");
            
            _currency = new Currency(currencyDefault);
            decimal amount = _currency.GetAmount();
            _currency.SentValue = amount;

            Console.WriteLine($"For {amount} {result} you will get: {_currency.SentValue} PLN.");
        }

        private void BuyCurrency()
        {         
            Console.Write("Dear user, tell me what currency you want to buy: \n");
            
            CurrencyDefault currencyDefault = option.GetCurrencyName();
            string result = currencyDefault.ToString() == "Czech_crown" ? "Czech crown" : currencyDefault.ToString();

            Console.Write($"I understand my dear user, you have chosen {result}, and how many {result}s do you need buy: ");

            Currency currency = new Currency(currencyDefault);
            decimal amount = currency.GetAmount();
            currency.BoughtValue = amount;
            decimal currencyAmount = currency.BoughtValue;

            Console.WriteLine($"For {amount} {result} you will pay: {currency.BoughtValue} PLN.");
        }
    }
}
