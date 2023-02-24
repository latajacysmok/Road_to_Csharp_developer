﻿/*Zadanie 1 - Aplikacja konsolowa do przeliczania kursu walut z PLN na obcą walutę
Stwórz nową solucję oraz projekty, które uważasz, że będą potrzebne
Wymagania aplikacji: 
- aplikacja napisana czysto, z dobrymi praktykami nazewnictwa zmiennych i metod/funkcji, wydzielenie funkcji odpowiedzialnej za przeliczanie kwoty i inne dobre praktyki według uznania
- użytkownik podaje nazwę obcej waluty (do dwóch miejsc po przecinku)
- użytkownik podaje kurs waluty (do 4 miejsc po przecinku)
- użytkownik podaje kwotę, którą chce przeliczyć (do dwóch miejsc po przecinku)
- wartości są wyświetlone w konsoli (do dwóch miejsc po przecinku)*/

using System;
using System.Linq.Expressions;

namespace Cantor
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
                Console.WriteLine("User, would you like to perform another operation?[y/n]");
                if (Console.ReadLine().ToLower() == "y")
                {
                    Console.WriteLine("So let's get started.");
                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write(".");
                        Thread.Sleep(1000);
                    }
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Got it, see you soon.");
                    Console.ReadKey();
                    break;
                }
            }          
        }

        static void BuyOrSell()
        {
            Console.Write("Dear user, tell me what you want? Buy or sell foreign currency[b/s]: ");
            char buyOrSell = char.Parse(Console.ReadLine());
            if (buyOrSell == 'b')
            {
                Console.Write("User, make a choice regarding the exchange rate now, do you want to assign it yourself[y/n]?: ");
                string ifTheyWantsAlone = Console.ReadLine();
               
                if (ifTheyWantsAlone == "y") exchangeRate = Math.Round(UserCurrency(foreignCurrency), 4);
                else exchangeRate = Math.Round(PurchaseCurrency(), 4);

                Console.Write($"I understand my dear user, you have chosen {foreignCurrency}, and how many {foreignCurrency} do you need: ");
                DownloadAmount();
                Console.WriteLine($"{amount} {foreignCurrency} will cost you: {Math.Round(amount * exchangeRate, 2)} PLN.");
            }
            else
            {
                Console.Write("User, make a choice regarding the exchange rate now, do you want to assign it yourself[y/n]?: ");
                string ifTheyWantsAlone = Console.ReadLine();

                if (ifTheyWantsAlone == "y") exchangeRate = Math.Round(UserCurrency(foreignCurrency), 4);
                else exchangeRate = Math.Round(SellCurrency(), 4);

                Console.Write($"I understand my dear user, you have chosen {foreignCurrency}, and how many {foreignCurrency} do you need sell: ");
                DownloadAmount();
                Console.WriteLine($"For {amount} {foreignCurrency} you will get: {Math.Round(amount * exchangeRate, 2)} PLN.");
            }
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

        static decimal UserCurrency(string foreignCurrency)
        {
            Console.Write("Dear user, tell me what currency you want to sell: ");
            foreignCurrency = Console.ReadLine();
            Console.Write($"Dear user, give me the exchange rate at which I should count the {foreignCurrency}: ");
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out exchangeRate)) break;
                else Console.WriteLine($"This is not a number: {exchangeRate.ToString()}. Try again, please.");
            }            
            return Math.Round(exchangeRate, 4);
        }

        static decimal DownloadAmount()
        {
           
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out amount)) break;
                else Console.WriteLine($"This is not a number: {amount.ToString()}. Try again, please.");
            }
            return Math.Round(amount, 2);
        }
    }
}




