using System;

namespace Konwersja
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("podaj liczbe:");
            int liczba = int.Parse(Console.ReadLine());

            Console.Write("podaj system:");
            int system = int.Parse(Console.ReadLine());

            if (system > 10)
            {
                Console.WriteLine("konwersja chwilowo nie wykonalna");
            }
            int cyfra;
            string wynik = "";
            while (liczba > 0)
            {
                cyfra = liczba % system;
                liczba = liczba / system;
                wynik = cyfra + wynik;
            }

            Console.WriteLine("liczba w systemie {0} to {1}",system, wynik);
            Console.ReadKey();

        }


        static string Convert(int liczba, int system)
        {
            if (system > 10)
            {
                Console.WriteLine("konwersja chwilowo nie wykonalna");
            }
            int cyfra;
            string wynik = "";
            while(liczba>0)
            {
                cyfra = liczba % system;
                liczba = liczba / system;
                wynik = cyfra + wynik;
            }
            return wynik;

            int wybor = 5;
            int x;
            while (wybor!=5)
            {
                Console.WriteLine("menu");
                wybor= int.Parse(Console.ReadLine());
            }

        }
    }
}
