namespace Decide
{
    public class CzechCrown : Cash
    {
        public override decimal buyCurrency()
        {
            return 0.2745m;
        }

        public override decimal sellCurrency()
        {
            return 0.2470m;
        }

        public override string symbolCurrency()
        {
            return "\u004B\u010D"; 
        }
    }
}
