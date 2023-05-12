namespace CurrencySelection
{
    public class Dollar : Currency
    {
        public Dollar() : base(boughtCurrency: 4.8765m, soldCurrency: 4.3888m, nameCurrency: CurrencyDefault.Dollar.GetDisplayName(), symbolCurrency: "$")//"Dollar"
        {
        }
    }
}
