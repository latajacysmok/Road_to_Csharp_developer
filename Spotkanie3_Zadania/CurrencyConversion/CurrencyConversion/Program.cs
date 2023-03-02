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
            Console.Write("Dear user, tell me what you want? Buy?\n");
            int buy = DecideWhichOption();
            if (buy == 1) Buying();
            else if (buy == 2) Selling();
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

        static  (string, decimal) PurchaseCurrency()
        {
            bool isItGoodCurrency = true;
            while (true)
            {
                Console.Write("Dear user, tell me what currency you want to buy: \n");
                Console.WriteLine("- Dollar,");
                Console.WriteLine("- Euro,");
                Console.WriteLine("- Czech crown.");
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
            
            return (foreignCurrency, exchangeRate);
        }

        static (string, decimal) SellCurrency()
        {
            bool isItGoodCurrency = true;
            while (true)
            {
                Console.Write("Dear user, tell me what currency you want to sell: \n");
                Console.WriteLine("- Dollar,");
                Console.WriteLine("- Euro,");
                Console.WriteLine("- Czech crown.");
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
            
            return (foreignCurrency, exchangeRate);
        }

        static (string, decimal) CurrencyAndUserCourse()
        {
            string userCurrency;
            while (true)
            {
                Console.Write("Dear user, tell me what currency you want to sell: ");
                userCurrency = Console.ReadLine();
                if (userCurrency != null) break;
                else Console.WriteLine("Currency name is required, please try again.");
            }
            
            Console.Write($"Dear user, give me the exchange rate at which I should count the {userCurrency}: ");
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out exchangeRate)) break;
                else Console.WriteLine($"This is not a number: {exchangeRate.ToString()}. Try again, please.");
            }            
            return (userCurrency, Math.Round(exchangeRate, 4));
        }

        static void Buying()
        {
            Console.Write("User, make your choice regarding the exchange rate now, do you want to set the currency value yourself?: \n");
            int exchangeRate = DecideWhichOption();

            if (exchangeRate == 1)
            {
                var result = CurrencyAndUserCourse();
                string currency = result.Item1;
                decimal currencyValue = Math.Round(result.Item2, 4);
                
                Console.Write($"I understand my dear user, you have chosen {currency}, and how many {currency} do you need: ");
                amount = DownloadAmount();
                Console.WriteLine($"{amount} {currency}s will cost you: {Math.Round(amount * currencyValue, 2)} PLN.");
            }
                
            else if (exchangeRate == 2)
            {
                Console.Write("User, to sure do you want to use ready-made currencies?: \n");
                int assignItYourself = DecideWhichOption();

                if (assignItYourself == 1) 
                {
                    var result = PurchaseCurrency();
                    string currency = result.Item1;
                    decimal currencyValue = Math.Round(result.Item2, 4);
                    currencyValue = Math.Round(currencyValue, 4);
                    Console.Write($"I understand my dear user, you have chosen {currency}, and how many {currency}s do you need: ");
                    amount = DownloadAmount();
                    Console.WriteLine($"{amount} {currency}s will cost you: {Math.Round(amount * currencyValue, 2)} PLN.");
                }
                        
                else if (assignItYourself == 2)
                {
                    Console.WriteLine("I understand that you are not yet decided what to do. We can try again.");
                    WhatDoWeDoNext();
                }
            }
        }

        static void Selling()
        {
            Console.Write("Dear user, tell me what you want? Sell?\n");
            int sell = DecideWhichOption();

            if (sell == 1)
            {
                Console.Write("User, do you want to set the currency value yourself?: \n");
                int ifTheyWantsAlone = DecideWhichOption();

                if (ifTheyWantsAlone == 1)
                {
                    var result = CurrencyAndUserCourse();
                    string currency = result.Item1;
                    decimal currencyValue = result.Item2;
                    Console.Write($"I understand my dear user, you have chosen {currency}, and how many {currency}s do you need sell: ");
                    amount = DownloadAmount();
                    Console.WriteLine($"For {amount} {currency}s you will get: {Math.Round(amount * currencyValue, 2)} PLN.");
                }
                    
                else if (ifTheyWantsAlone == 2)
                {
                    Console.Write("User, to sure make a choice regarding the exchange rate now?: \n");
                    int exchangeRate = DecideWhichOption();
                    
                    if (exchangeRate == 1)
                    {
                        var result = SellCurrency();
                        string currency = result.Item1;
                        decimal currencyValue = result.Item2;
                        Console.Write($"I understand my dear user, you have chosen {currency}, and how many {currency}s do you need sell: ");
                        amount = DownloadAmount();
                        Console.WriteLine($"For {amount} {currency} you will get: {Math.Round(amount * currencyValue, 2)} PLN.");
                    }
                    else if (exchangeRate == 2)
                    {
                        Console.WriteLine("I understand that you are not yet decided what to do. We can try again.");
                        WhatDoWeDoNext();
                    }
                }            
            }
            else if (sell == 2)
            {
                Console.WriteLine("I understand that you are not yet decided what to do. We can try again.");
                WhatDoWeDoNext();
            }
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