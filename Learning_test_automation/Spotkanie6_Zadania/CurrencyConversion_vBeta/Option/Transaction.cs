using Decide;

namespace CurrencyConversion
{
    public class Transaction // może tutaj tylko wypiywać a w Currency wyliczać, Cantor przyjmuje wartośći
    {
        Option option = new Option();
        Cantor currencyExchange = new Cantor();

        public void BuyOrSell()
        {
            Console.Write("Dear user, tell me what you want? Buy?\n");
            var buy = option.DecideWhichOption();
            if      (buy == MakingDecision.Yes) Buying();
            else if (buy == MakingDecision.No) Selling();
        }

        public void Buying()
        {
            if (OwnCurrency() == MakingDecision.No) BuyCurrency();
        }

        public void Selling()
        {
            Console.Write("Dear user, tell me what you want? Sell?\n");
            MakingDecision sell = option.DecideWhichOption();
            if (OwnCurrency() == MakingDecision.No) SellCurrency();
        }
        private MakingDecision OwnCurrency()
        {
            Console.Write("User, make your choice regarding the exchange rate now, do you want to set the currency value yourself?: \n");
            MakingDecision exchangeRate = option.DecideWhichOption();
            if (exchangeRate == MakingDecision.Yes)
            {
                Currency currency = currencyExchange.GetCurrencyUserName();
                Console.Write($"I understand my dear user, you have chosen {currency.UserNameCurrency}, and how many {currency.UserNameCurrency} do you need: ");

                decimal amount = currencyExchange.GetOnlyAmount();

                Console.WriteLine($"For {amount} {currency.UserNameCurrency} you will get: {amount * currency.UserValueCurrency} PLN.");

                return exchangeRate;
            }
            return exchangeRate;
        }

        private void SellCurrency()
        {
            Console.Write("Dear user, tell me what currency you want to sell: \n");
            Names.CurrencyDefault currency = currencyExchange.GetCurrency();
            
            string result = currency.ToString() == "Czech_crown" ? "Czech crown" : currency.ToString();

            Console.Write($"I understand my dear user, you have chosen {result}, and how many {result}s do you need sell: ");
            
            decimal amount = currencyExchange.GetOnlyAmount();
            decimal currencyAmount = currencyExchange.GetCurrencySellAmount(amount);

            Console.WriteLine($"For {amount} {result} you will get: {currencyAmount} PLN.");
        }

        private void BuyCurrency()
        {
            Console.Write("Dear user, tell me what currency you want to buy: \n");
            Names.CurrencyDefault currency = currencyExchange.GetCurrency();

            string result = currency.ToString() == "Czech_crown" ? "Czech crown" : currency.ToString();

            Console.Write($"I understand my dear user, you have chosen {result}, and how many {result}s do you need buy: ");

            decimal amount = currencyExchange.GetOnlyAmount();
            decimal currencyAmount = currencyExchange.GetCurrencyBuyAmount(amount);

            Console.WriteLine($"For {amount} {result} you will pay: {currencyAmount} PLN.");
        }
    }
}
