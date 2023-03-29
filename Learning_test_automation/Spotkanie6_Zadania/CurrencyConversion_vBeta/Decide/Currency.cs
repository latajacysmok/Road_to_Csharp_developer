using System.Xml.Linq;

namespace Decide
{
    public class Currency
    {
        public CurrencyNames Name { get; }
        public decimal BoughtValue { get; }
        public decimal SentValue { get; }
        private decimal BoughtCourse { get; }
        private decimal SentCourse { get; }

        public Currency(CurrencyNames name)//ct+ tab
        {
            Name = name;
            BoughtCourse = GetBuyingCourse();
            SentCourse = GetSellCourse();
        }

        private decimal GetBuyingCourse()
        {
            switch (Name)
            {
                case CurrencyNames.Dollar:
                    return 4.8765m;
                case CurrencyNames.Euro:
                    return 5.3722m;
                case CurrencyNames.Czech_crown:
                    return 0.2745m;
                default:
                    return 0;
            }
        }

        private decimal GetSellCourse()
        {
            switch (Name)
            {
                case CurrencyNames.Dollar:
                    return 4.3888m;
                case CurrencyNames.Euro:
                    return 4.8349m;
                case CurrencyNames.Czech_crown:
                    return 0.2470m;
                default:
                    return 0;
            }
        }

        //prop + tab
        // przy Tworzeniu klasy wywołuje konstruktor z konkretnymi wartościami, utwórz obiekt żeby było
    }
}
