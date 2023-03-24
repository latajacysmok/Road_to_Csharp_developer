using CurrencyConversion;

namespace Interface
{
    class Program
    {
        static public void Main(string[] args)
        {
            Transaction transaction = new Transaction();
            Option option = new Option();
            while (true)
            {
                transaction.BuyOrSell();
                option.WhatDoWeDoNext();
            }          
        }
    }
}