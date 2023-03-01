using System;
using System.Linq.Expressions;

namespace CurrencyConversion
{
    class Program
    {
        static decimal amount;
        static decimal exchangeRate;
        static string foreignCurrency;

        static void Main(string[] args)
        {
            while (true)
            {
                BuyOrSell();
                WhatDoWeDoNext();
            }          
        }

        static void BuyOrSell()
        {
            decimal currencyValue;
            Console.Write("Dear user, tell me what you want? Buy?");
            int buy = DecideWhichOption();
            if (buy == 1)
            {              
                Console.Write("User, make a choice regarding the exchange rate now?: ");
                int exchangeRate = DecideWhichOption();
                if (exchangeRate == 1) currencyValue = Math.Round(CurrencyAndUserCourse(), 4);
                else if(exchangeRate == 2)
                {
                    Console.Write("User, do you want to assign it yourself?: ");
                    int assignItYourself = DecideWhichOption();
                    if (assignItYourself == 1) currencyValue = Math.Round(PurchaseCurrency(), 4);
                    else if(assignItYourself == 2)
                    {
                        Console.WriteLine("I understand that you are not yet decided what to do. We can try again.");
                        WhatDoWeDoNext();
                    }
                }

                Console.Write($"I understand my dear user, you have chosen {foreignCurrency}, and how many {foreignCurrency} do you need: ");
                DownloadAmount();
                Console.WriteLine($"{amount} {foreignCurrency} will cost you: {Math.Round(amount * currencyValue, 2)} PLN.");
            }
                      
            else if (buy == 2) 
            {
                Console.Write("Dear user, tell me what you want? Sell?");
                int sell = DecideWhichOption();
                if (sell == 1)
                {
                    Console.Write("User, do you want to assign it yourself?: ");
                    int ifTheyWantsAlone = DecideWhichOption();
                    if (ifTheyWantsAlone == 1) currencyValue = Math.Round(CurrencyAndUserCourse(), 4);
                    else if (ifTheyWantsAlone == 2)
                    {
                        Console.Write("User, make a choice regarding the exchange rate now?: ");
                        int exchangeRate = DecideWhichOption();
                        if (exchangeRate == 1) currencyValue = Math.Round(SellCurrency(), 4);
                        else if (exchangeRate == 2)
                        {
                            Console.WriteLine("I understand that you are not yet decided what to do. We can try again.");
                            WhatDoWeDoNext();
                        }
                    }

                    Console.Write($"I understand my dear user, you have chosen {foreignCurrency}, and how many {foreignCurrency} do you need sell: ");
                    DownloadAmount();
                    Console.WriteLine($"For {amount} {foreignCurrency} you will get: {Math.Round(amount * currencyValue, 2)} PLN.");
                }
                else if (sell == 2) 
                {
                    Console.WriteLine("I understand that you are not yet decided what to do. We can try again.");
                    WhatDoWeDoNext();
                }

            }
        }

        public static int DecideWhichOption()
        {
            while (true)
            {
                Console.WriteLine("If yes enter: '1'.");
                Console.WriteLine("If no enter: '2'.");
                int decision = ItNumber();
                if (decision == 1 || decision == 2) return decision;
                else Console.WriteLine($"Your number is: {decision}.\nThe given number must equal 1 if you want to continue or 2 if you want to end the program. Try again.");
            }
        }

        public static int ItNumber()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int number)) return number;
                else Console.Write($"{number.ToString()} is not a number, please try again: ");
            }
        }

        static decimal DownloadAmount()
        {
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out amount))
                {
                    if (amount > 0) break;
                    else Console.WriteLine("I can't convert negative value of money. Try again, please: ");
                } 
                else Console.WriteLine($"This is not a number: {amount.ToString()}. Try again, please: ");
            }
            return Math.Round(amount, 2);
        }

        static decimal PurchaseCurrency()
        {
            bool isItGoodCurrency = true;
            while (true)
            {
                Console.Write("Dear user, tell me what currency you want to buy: ");
                foreignCurrency = Console.ReadLine();
                switch (char.ToUpper(foreignCurrency[0]) + foreignCurrency.Substring(1))
                {
                    case "Dollar":
                        exchangeRate = 4.8765m;
                        break;
                    case "Euro":
                        exchangeRate = 5.3722m;
                        break;
                    case "Czech crown":
                        exchangeRate = 0.2745m;
                        break;
                    default:
                        Console.WriteLine($"No given {foreignCurrency} currency in our exchange office.");
                        isItGoodCurrency = false;
                        break;
                }
                if (isItGoodCurrency) break;
                else
                {
                    Console.WriteLine("Try again, you can choose from among: \n-Dollar,\n-Euro,\n-Czech crown.");
                    isItGoodCurrency = true;
                }
            }
            
            return exchangeRate;
        }

        static decimal SellCurrency()
        {
            bool isItGoodCurrency = true;
            while (true)
            {
                Console.Write("Dear user, tell me what currency you want to sell: ");
                foreignCurrency = Console.ReadLine();
                switch (char.ToUpper(foreignCurrency[0]) + foreignCurrency.Substring(1))
                {
                    case "Dollar":
                        exchangeRate = 4.3888m;
                        break;
                    case "Euro":
                        exchangeRate = 4.8349m;
                        break;
                    case "Czech crown":
                        exchangeRate = 0.2470m;
                        break;
                    default:
                        Console.WriteLine($"No given {foreignCurrency} currency in our exchange office.");
                        isItGoodCurrency = false;  
                        break;
                }
                if (isItGoodCurrency) break;
                else
                {
                    Console.WriteLine("Try again, you can choose from among: \n-Dollar,\n-Euro,\n-Czech crown.");
                    isItGoodCurrency = true;
                }
            }
            
            return exchangeRate;
        }

        static decimal CurrencyAndUserCourse()
        {
            Console.Write("Dear user, tell me what currency you want to sell: ");
            string userCurrency = Console.ReadLine();
            Console.Write($"Dear user, give me the exchange rate at which I should count the {userCurrency}: ");
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out exchangeRate)) break;
                else Console.WriteLine($"This is not a number: {exchangeRate.ToString()}. Try again, please.");
            }            
            return Math.Round(exchangeRate, 4);
        }

        public static void WhatDoWeDoNext()
        {
            Console.WriteLine("User, would you like to perform another operation?");
            int decision = DecideWhichOption();
            GoOutOrStay(decision);
        }

        public static void GoOutOrStay(int ifExit)
        {
            while (true)
            {
                if (ifExit == 1)
                {
                    Console.WriteLine($"So let's get started again dear user.");
                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write(".");
                        Thread.Sleep(1000);
                    }
                    Console.Clear();
                    break;
                }
                else if (ifExit == 2)
                {
                    Console.WriteLine($"See you soon dear user.");
                    Environment.Exit(1);
                }
            }
        }
    }
}