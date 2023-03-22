using Option;

namespace CurrencyConversion
{
    class Program
    {
        static public void Main(string[] args)
        {
            PossibleOperations option = new PossibleOperations();
            Transaction transaction = new Transaction();
            while (true)
            {
                transaction.BuyOrSell();
                option.WhatDoWeDoNext();
            }          
        }
    }
}