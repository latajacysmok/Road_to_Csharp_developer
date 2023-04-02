using Decide;

namespace CurrencyConversion
{
    public class Cantor
    {
        Option option = new Option();
        Names name = new Names();
        private Currency currency;

        public Names.CurrencyDefault GetCurrency()
        {
            this.currency = new Currency(option.GetCurrencyName());
            return currency.Name;
        }

        public decimal GetCurrencySellAmount(decimal amount)
        {
            currency.SentValue = amount;
            return currency.SentValue;
        }
        
        public decimal GetOnlyAmount()
        {
            decimal amount = currency.GetAmount();
            return amount;
        }

        public decimal GetCurrencyBuyAmount(decimal amount)
        {           
            currency.BoughtValue = amount;
            return currency.BoughtValue;
        }

        public Currency GetCurrencyUserName()
        {
            this.currency = new Currency(name.CurrencyUser());
            return currency;
        }

    }
}
