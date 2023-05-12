namespace CurrencySelection
{
    public static class CurrencyDefaultExtensions
    {
        public static string GetDisplayName(this CurrencyDefault currency)
        {
            switch (currency)
            {
                case CurrencyDefault.Dollar:
                    return "Dollar";
                case CurrencyDefault.Euro:
                    return "Euro";
                case CurrencyDefault.Czech_crown:
                    return "Czech crown";
                default:
                    throw new ArgumentException("Invalid currency.");
            }
        }
    }
}
