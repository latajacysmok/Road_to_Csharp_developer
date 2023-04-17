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
            while (true)
            {
                option.BuyOrSell();
                option.WhatDoWeDoNext();
            }          
        }
    }
}