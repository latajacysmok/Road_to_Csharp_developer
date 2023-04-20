using System.Xml.Linq;

namespace Decide
{
    public class Currency
    {
        public CurrencyDefault Name { get; }
        public decimal UserValueCurrency { get; }
        public string UserNameCurrency { get; }

        public decimal boughtValue;
        public decimal BoughtValue 
        {
            get { return boughtValue; }
            set { boughtValue = Math.Round(value * BoughtCourse, 2); }
        }

        private decimal sentValue;
        public decimal SentValue 
        {
            get {return sentValue; }
            set { sentValue = Math.Round(value * SentCourse, 2); }  
        }
        private decimal BoughtCourse { get; }
        private decimal SentCourse { get; }
        private string SymbolCurrency { get; }

        private Euro euro = new Euro();
        private Dollar dollar = new Dollar();
        private CzechCrown czechCrown = new CzechCrown();

        public Currency(CurrencyDefault name)//ct+ tab
        {
            Name         = name;
            BoughtCourse = GetBuyingCourse();
            SentCourse   = GetSellCourse();
            SymbolCurrency = GetSymbolCurrency(name);
        }

        public Currency(string name)
        {
            UserNameCurrency       = name;
            this.UserValueCurrency = GetUserCourse(name);
        }

        public Currency()
        {
            
        }

        public decimal GetAmount()
        {
            decimal amount;
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out amount))
                {
                    if (IfNumberIsPositive(amount)) break;
                    else continue;
                }
                else Console.Write($"This is not a number: {amount}. Try again, please: ");
            }
            return amount;
        }

        private bool IfNumberIsPositive(decimal number)
        {
            if (number > 0) return true;
            else
            {
                Console.Write("I can't convert negative value of money. Try again, please: ");
                return false;
            }
        }

        public decimal GetBuyingCourse()
        {

            switch (Name)
            {
                case CurrencyDefault.Dollar:
                    return dollar.buyCurrency();
                case CurrencyDefault.Euro:
                    return euro.buyCurrency();
                case CurrencyDefault.Czech_crown:
                    return czechCrown.buyCurrency();
                default:
                    return 0;
            }
        }    

        public decimal GetSellCourse()
        {
            switch (Name)
            {
                case CurrencyDefault.Dollar:
                    return dollar.sellCurrency();
                case CurrencyDefault.Euro:
                    return euro.sellCurrency();
                case CurrencyDefault.Czech_crown:
                    return czechCrown.sellCurrency();
                default:
                    return 0;
            }
        }

        public string GetSymbolCurrency(CurrencyDefault name)
        {
            switch (name)
            {
                case CurrencyDefault.Dollar:
                    return dollar.symbolCurrency();
                case CurrencyDefault.Euro:
                    return euro.symbolCurrency();
                case CurrencyDefault.Czech_crown:
                    return czechCrown.symbolCurrency();
                default:
                    throw new ArgumentException("Invalid currency value", nameof(Name));
            }
        }

        private decimal GetUserCourse(string currencyUserName)
        {
            
            Console.Write($"Dear user, give me the exchange rate at which I should count the {currencyUserName}: ");
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out decimal exchangeRate)) return (Math.Round(exchangeRate, 4));
                else Console.Write($"This is not a number: {exchangeRate}. Try again, please: ");
            }
        }
    //prop + tab
    }
}
