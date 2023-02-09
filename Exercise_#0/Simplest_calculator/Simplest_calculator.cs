using System;

namespace Ćwiczenie_1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("-------------------------------");
            //Console.WriteLine("Podaj A: ");
            //int A = int.Parse(Console.ReadLine());
            //Console.WriteLine("Podaj B: ");
            //int B = int.Parse(Console.ReadLine());
            /*Console.WriteLine("A:{0}, B:{1}", A, B);
            B = A;
            A = 7;
            B = B + 5;
            Console.WriteLine("A:{0}, B:{1}", A, B);
            Console.WriteLine("Ćwiczenie 1 - Prosty kalkulator");*/

            Console.WriteLine("Cześć Użytkowniku jak masz na imie?");
            Console.WriteLine("");
            string imie = Console.ReadLine(); //.ToUpper();
            Console.WriteLine("Cześć {0}, podaj mi proszę pierwszą liczbę do moich obliczeń", imie);
            int pierwsza_liczba = int.Parse(Console.ReadLine());
            Console.WriteLine("Dziękuję {0}, teraz podaj drugą", imie);
            int druga_liczba = int.Parse(Console.ReadLine());
            Console.WriteLine("Oto moje skomplikowane obliczenia: ");
            Console.WriteLine();
            Console.WriteLine("{0} + {1} = {2}", pierwsza_liczba, druga_liczba, pierwsza_liczba + druga_liczba);
            Console.WriteLine("{0} - {1} = {2}", pierwsza_liczba, druga_liczba, pierwsza_liczba - druga_liczba);
            Console.WriteLine("{0} * {1} = {2}", pierwsza_liczba, druga_liczba, pierwsza_liczba * druga_liczba);
            Console.WriteLine("{0} / {1} = {2}", pierwsza_liczba, druga_liczba, pierwsza_liczba / druga_liczba);
            Console.WriteLine("{0} % {1} = {2}", pierwsza_liczba, druga_liczba, pierwsza_liczba % druga_liczba);
            Console.WriteLine("{0}^{1} = {2}", pierwsza_liczba, druga_liczba, Math.Pow(pierwsza_liczba, druga_liczba));
            Console.WriteLine("sqrt({0}) = {1}", pierwsza_liczba, Math.Sqrt(pierwsza_liczba));
            Console.WriteLine("sqrt({0}) = {1}", druga_liczba, Math.Sqrt(druga_liczba));
            //const int niezmienna = 5;
            //niezmienna = 6;
            //Console.WriteLine(niezmienna);

            Console.Beep(8000, 100);
            Console.ReadKey();

        }
    }
}
