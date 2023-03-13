using System;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            string napis = "napis";
            Console.Write("test "+ napis+"\n");

            Console.Write("Podaj jak masz na imie: ");
            string imie = Console.ReadLine();

            Console.WriteLine("Cześć "+ imie);

            Console.Write("Ile masz lat?: ");
            int wiek = int.Parse(Console.ReadLine());

            Console.WriteLine("ok czyli masz "+wiek+" lat");

            int ileDo100 = 100 - wiek;

            Console.WriteLine("czyli {1} do 100 pozostalo ci {0} lat", ileDo100, imie);

            Console.WriteLine("podaj jakąś liczbe z przecinkiem:");
            double liczba = double.Parse(Console.ReadLine());
            Console.WriteLine("podana liczba do kwadratu to:"+liczba*liczba);

            //This is a change for exercise with git(ad.6)
            //podaj pierwsza liczbe: 2
            //podaj drógą liczbe: 3

            //2 + 3 = 5
            //2 - 3 = -1
            //2 * 3 = 6
            //2 / 3 = ?? 0(int) lub 0,66666666(double)
            //2 s 3 = 2 (reszta z dzielenie % - modulo)


        }
    }
}
