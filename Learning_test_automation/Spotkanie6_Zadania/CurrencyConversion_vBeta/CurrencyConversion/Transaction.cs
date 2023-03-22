using Option;
using Decide;

namespace CurrencyConversion
{
    class Transaction
    {
        PossibleOperations option = new PossibleOperations();
        Cantor cantor = new Cantor();
        public decimal amount;

        public void BuyOrSell()
        {
            Console.Write("Dear user, tell me what you want? Buy?\n");
            int buy = option.DecideWhichOption();
            if (buy == (int)Choice.Yes) Buying();
            else if (buy == (int)Choice.No) Selling();
        }

        public void Buying()
        {
            if (OwnCurrency() == (int)Choice.No) BuyCurrency();
        }

        public void Selling()
        {
            Console.Write("Dear user, tell me what you want? Sell?\n");
            int sell = option.DecideWhichOption();
            if (OwnCurrency() == (int)Choice.No) SellCurrency();
        }
        private int OwnCurrency()
        {
            Console.Write("User, make your choice regarding the exchange rate now, do you want to set the currency value yourself?: \n");
            int exchangeRate = option.DecideWhichOption();
            if (exchangeRate == (int)Choice.Yes)
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
            var result = cantor.SellCurrency();
            string currency = cantor.foreignCurrency;
            decimal currencyValue = Math.Round(result, 4);
            Console.Write($"I understand my dear user, you have chosen {currency}, and how many {currency}s do you need sell: ");
            amount = option.DownloadAmount();
            Console.WriteLine($"For {amount} {currency} you will get: {Math.Round(amount * currencyValue, 2)} PLN.");
        }

        private void BuyCurrency()
        {
            var result = cantor.PurchaseCurrency();
            string currency = cantor.foreignCurrency;
            decimal currencyValue = Math.Round(result, 4);
            currencyValue = Math.Round(currencyValue, 4);
            Console.Write($"I understand my dear user, you have chosen {currency}, and how many {currency}s do you need buy: ");
            amount = option.DownloadAmount();
            Console.WriteLine($"{amount} {currency}s will cost you: {Math.Round(amount * currencyValue, 2)} PLN.");
        }
    }
}
