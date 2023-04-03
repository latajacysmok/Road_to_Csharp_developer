namespace Decide
{
    public class Currency
    {
        public Names.CurrencyDefault Name { get; }
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

        public Currency(Names.CurrencyDefault name)//ct+ tab
        {
            Name         = name;
            BoughtCourse = GetBuyingCourse();
            SentCourse   = GetSellCourse();
        }

        public Currency(string name)//ct+ tab
        {
            UserNameCurrency       = name;
            this.UserValueCurrency = GetUserCourse(name);
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
                else Console.WriteLine($"This is not a number: {amount.ToString()}. Try again, please: ");
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

        private decimal GetBuyingCourse()
        {
            switch (Name)
            {
                case Names.CurrencyDefault.Dollar:
                    return 4.8765m;
                case Names.CurrencyDefault.Euro:
                    return 5.3722m;
                case Names.CurrencyDefault.Czech_crown:
                    return 0.2745m;
                default:
                    return 0;
            }
        }

        private decimal GetSellCourse()
        {
            switch (Name)
            {
                case Names.CurrencyDefault.Dollar:
                    return 4.3888m;
                case Names.CurrencyDefault.Euro:
                    return 4.8349m;
                case Names.CurrencyDefault.Czech_crown:
                    return 0.2470m;
                default:
                    return 0;
            }
        }

        private decimal GetUserCourse(string currencyUserName)
        {
            
            Console.Write($"Dear user, give me the exchange rate at which I should count the {currencyUserName}: ");
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out decimal exchangeRate)) return (Math.Round(exchangeRate, 4));
                else Console.WriteLine($"This is not a number: {exchangeRate}. Try again, please.");
            }
        }

    //prop + tab
}
}
