﻿namespace Tools
{
    class Program
    {
        static public void Main(string[] args)
        {
            Date takeDate = new Date();
            string varNameFromUser = takeDate.TakeName();
            int valueFromUser = takeDate.TakeNumber();
            Console.WriteLine("--------\n");
            takeDate.PrintDate(varNameFromUser, valueFromUser);
            Console.ReadKey();
        }
    }
}

