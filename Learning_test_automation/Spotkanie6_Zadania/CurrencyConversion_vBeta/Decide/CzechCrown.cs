namespace CurrencySelection
{
    public class CzechCrown : Currency
    {
        public CzechCrown() : base(boughtCurrency: 0.2745m, soldCurrency: 0.2470m, nameCurrency: CurrencyDefault.Czech_crown.GetDisplayName(), symbolCurrency: "Kč")//"Czech crown"
        {
        }
    }
}
