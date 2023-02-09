using System;
using System.Drawing;

namespace Ćwiczenie_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cześć Użytkowniku jak masz na imie?");
            Console.WriteLine("");
            string imie = Console.ReadLine();
            Console.WriteLine("Cześć {0}, podaj mi proszę pierwszą liczbę do moich obliczeń", imie);
            int pierwsza_liczba = int.Parse(Console.ReadLine());
            Console.WriteLine("Dziękuję {0}, teraz podaj drugą", imie);
            int druga_liczba = int.Parse(Console.ReadLine());
            Console.Write("Dziękuję {0}, teraz podaj mi działanie jakie mam wykonać, z racji że jestem prostym kalkulatorem masz do wyboru: " +
                "+, -, *, /, %, potege, pierwiastek i wartosc bezwzgledna: ", imie);
            string znak = Console.ReadLine();

            Console.WriteLine("Oto moje skomplikowane obliczenia: ");
            Console.WriteLine();
            switch (znak)
            {
                case "+":
                    Console.WriteLine("{0} + {1} = {2}", pierwsza_liczba, druga_liczba, pierwsza_liczba + druga_liczba);
                    break;
                case "-":
                    Console.WriteLine("{0} - {1} = {2}", pierwsza_liczba, druga_liczba, pierwsza_liczba - druga_liczba);
                    break;
                case "*":
                    Console.WriteLine("{0} * {1} = {2}", pierwsza_liczba, druga_liczba, pierwsza_liczba * druga_liczba);
                    break;
                case "/":
                    Console.WriteLine("{0} / {1} = {2}", pierwsza_liczba, druga_liczba, pierwsza_liczba / druga_liczba);
                    break;
                case "%":
                    Console.WriteLine("{0} % {1} = {2}", pierwsza_liczba, druga_liczba, pierwsza_liczba % druga_liczba);
                    break;                  
                case "potege":
                    Console.WriteLine("{0}^{1} = {2}", pierwsza_liczba, druga_liczba, Math.Pow(pierwsza_liczba, druga_liczba));
                    break;
                case "pierwiastek":
                    Console.WriteLine("sqrt({0}) = {1}", pierwsza_liczba, Math.Sqrt(pierwsza_liczba));
                    Console.WriteLine("sqrt({0}) = {1}", druga_liczba, Math.Sqrt(druga_liczba));
                    break;
                case "wartosc bezwzgledna":
                    Console.WriteLine("|{0}| = {1}", pierwsza_liczba, Math.Abs(pierwsza_liczba));
                    Console.WriteLine("|{0}| = {1}", druga_liczba, Math.Abs(druga_liczba));
                    break;
                default:
                    Console.WriteLine("{0}... nie no coś namieszałeś", znak);
                    break;
            }
            
            Console.Beep(8000, 100);
            Console.ReadKey();
        }
    }
}
