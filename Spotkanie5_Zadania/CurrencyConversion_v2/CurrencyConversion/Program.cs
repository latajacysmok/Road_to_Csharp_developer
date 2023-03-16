namespace CurrencyConversion
{
    class Program
    {
        static public void Main(string[] args)
        {
            Option appOption = new Option();
            Transaction transaction = new Transaction();
            while (true)
            {
                transaction.BuyOrSell();
                appOption.WhatDoWeDoNext();
            }          
        }
    }
}