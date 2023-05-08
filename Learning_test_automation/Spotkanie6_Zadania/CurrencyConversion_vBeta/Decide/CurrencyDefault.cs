namespace CurrencySelection
{
    public enum CurrencyDefault
    {
        Dollar = 1,
        Euro = 2,
        Czech_crown = 3
    }

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

