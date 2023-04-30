using CurrencyConversion;
using System.Text;

namespace Interface
{
    class Program
    {
        static public void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Transaction transaction = new Transaction();
            Option option = new Option();
            CurrencyPresentation currencyPresentation = new CurrencyPresentation();
            while (true)
            {
                currencyPresentation.BuyOrSell();
                option.WhatDoWeDoNext();
            }          
        }
    }
}