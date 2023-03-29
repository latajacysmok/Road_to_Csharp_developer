using Decide;

namespace CurrencyConversion
{
    public class Transaction
    {
        Option option = new Option();
        Cantor cantor = new Cantor();
        private decimal amount;

        public void BuyOrSell()
        {
            Console.Write("Dear user, tell me what you want? Buy?\n");
            var buy = option.DecideWhichOption();
            if      (buy == Decide.MakingDecision.Yes) Buying();
            else if (buy == Decide.MakingDecision.No) Selling();
        }

        public void Buying()
        {
            if (OwnCurrency() == Decide.MakingDecision.No) BuyCurrency();
        }

        public void Selling()
        {
            Console.Write("Dear user, tell me what you want? Sell?\n");
            Decide.MakingDecision sell = option.DecideWhichOption();
            if (OwnCurrency() == Decide.MakingDecision.No) SellCurrency();
        }
        private Decide.MakingDecision OwnCurrency()
        {
            Console.Write("User, make your choice regarding the exchange rate now, do you want to set the currency value yourself?: \n");
            Decide.MakingDecision exchangeRate = option.DecideWhichOption();
            if (exchangeRate == Decide.MakingDecision.Yes)
            {
                var result = cantor.CurrencyUser();
                string currency = cantor.userCurrency;
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
            Currency result = cantor.SellCurrency;
            string currency = cantor.foreignCurrency.ToString() == "Czech_crown" ? "Czech crown" : cantor.foreignCurrency.ToString();
            decimal currencyValue = Math.Round(result, 4);

            Console.Write($"I understand my dear user, you have chosen {currency}, and how many {currency}s do you need sell: ");
            amount = option.DownloadAmount();
            Console.WriteLine($"For {amount} {currency} you will get: {Math.Round(amount * currencyValue, 2)} PLN.");
        }

        private void BuyCurrency()
        {
            //var result = cantor.PurchaseCurrency();

            string currency =  .ToString() == "Czech_crown" ? "Czech crown" : cantor.foreignCurrency.ToString();
            decimal currencyValue = Math.Round(result, 4);

            Console.Write($"I understand my dear user, you have chosen {currency}, and how many {currency}s do you need buy: ");
            amount = option.DownloadAmount();
            Console.WriteLine($"{amount} {currency}s will cost you: {Math.Round(amount * currencyValue, 2)} PLN.");
        }
    }
}
