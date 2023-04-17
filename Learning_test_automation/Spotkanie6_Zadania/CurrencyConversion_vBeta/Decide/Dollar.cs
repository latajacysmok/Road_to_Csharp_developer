namespace Decide
{
    public class Dollar : Cash
    {
        public override decimal buyCurrency()
        {
            return 4.8765m;
        }

        public override decimal sellCurrency()
        {
            return 4.3888m;
        }

        public override string symbolCurrency()
        {
            return "$";
        }
    }
}
