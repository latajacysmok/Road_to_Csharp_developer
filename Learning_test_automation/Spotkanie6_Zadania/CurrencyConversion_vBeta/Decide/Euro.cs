namespace Decide
{
    public class Euro : Cash
    {
        public override decimal buyCurrency()
        {
            return 5.3722m;
        }

        public override decimal sellCurrency()
        {
            return 4.8349m;
        }
        
        public override string symbolCurrency()
        {
            return "€";
        }
    }
}
