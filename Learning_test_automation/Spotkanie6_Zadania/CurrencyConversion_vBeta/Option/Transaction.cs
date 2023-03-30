using Decide;

namespace CurrencyConversion
{
    public class Transaction // może tutaj tylko wypiywać a w Currency wyliczać, Cantor przyjmuje wartośći
    {
        Option option = new Option();
        Cantor currencyExchange = new Cantor();
        private decimal amount;      

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
                var result = currencyExchange.CurrencyUser();
                string currency = currencyExchange.userCurrency;
                decimal currencyValue = Math.Round(result, 4);

                Console.Write($"I understand my dear user, you have chosen {currency}, and how many {currency} do you need: ");
                amount = option.DownloadAmount();
                Console.WriteLine($"{amount} {currency}s will cost you: {Math.Round(amount * currencyValue, 2)} PLN.");
                return exchangeRate;
            }
            return exchangeRate;
        }

        private void SellCurrency()
        {
            Console.Write("Dear user, tell me what currency you want to sell: \n");
            CurrencyNames currency = currencyExchange.GetCurrency();// tu uzyc obiekt, ktory utworzyles
            //Currency.BoughtCourse value = currencyExchange.GetCurrency();

            string result = currency.ToString() == "Czech_crown" ? "Czech crown" : currencyExchange.foreignCurrency.ToString();
            //decimal currencyValue = Math.Round(result.BoughtValue, 4);

            Console.Write($"I understand my dear user, you have chosen {result}, and how many {result}s do you need sell: ");
            amount = option.DownloadAmount();
            //Console.WriteLine($"For {amount} {result} you will get: {Math.Round(amount * currencyValue, 2)} PLN.");
        }

        private void BuyCurrency()
        {
            Console.Write("Dear user, tell me what currency you want to buy: \n");
            CurrencyNames currency = currencyExchange.GetCurrency();

            string result = currency.ToString() == "Czech_crown" ? "Czech crown" : currencyExchange.foreignCurrency.ToString();

            Console.Write($"I understand my dear user, you have chosen {result}, and how many {result}s do you need buy: ");
            amount = option.DownloadAmount();
            decimal currencyAmount = currencyExchange.GetCurrencyBuyAmount(amount);
            Console.WriteLine($"{amount} {result}s will cost you: {currencyAmount} PLN.");
        }
    }
}
