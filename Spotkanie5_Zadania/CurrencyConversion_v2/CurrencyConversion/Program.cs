namespace CurrencyConversion
{
    class Program
    {
        static public void Main(string[] args)
        {
            AppOption appOption = new AppOption();
            Transaction transaction = new Transaction();
            while (true)
            {
                transaction.BuyOrSell();
                appOption.WhatDoWeDoNext();
            }          
        }
    }
}