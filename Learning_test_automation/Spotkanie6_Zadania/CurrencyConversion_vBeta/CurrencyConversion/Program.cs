namespace CurrencyConversion
{
    class Program
    {
        static public void Main(string[] args)
        {
            Transaction transaction = new Transaction();
            Option.Option option = new Option.Option();
            while (true)
            {
                transaction.BuyOrSell();
                option.WhatDoWeDoNext();
            }          
        }
    }
}