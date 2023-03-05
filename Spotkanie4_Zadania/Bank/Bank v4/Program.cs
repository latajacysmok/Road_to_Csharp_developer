using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Podaj ilość konta ktore posiadasz w naszym banku: ");
            int iloscKont = int.Parse(Console.ReadLine());
            int[] konto = new int[iloscKont];

            int wybor = 0;
            int nrKonta;
            int kwota;
            while (wybor != 4)
            {
                Console.WriteLine("MENU");
                Console.WriteLine("1 - wypisz konta");
                Console.WriteLine("2 - wplac pieniadze");
                Console.WriteLine("3 - wyplac pieniadze");
                Console.WriteLine("4 - wyjscie");
                wybor = int.Parse(Console.ReadLine());
                switch (wybor)
                {
                    case 1:
                        for (int i = 0; i < konto.Length; i++)
                        {
                            Console.WriteLine("konto{0}:{1} zł", i, konto[i]);
                        }
                        break;
                    case 2:
                        Console.Write("podaj nr konta:");
                        nrKonta = int.Parse(Console.ReadLine());
                        Console.Write("podaj kwote:");
                        kwota = int.Parse(Console.ReadLine());

                        konto[nrKonta] = konto[nrKonta] + kwota;

                        break;
                    case 3:

                        Console.Write("podaj nr konta:");
                        nrKonta = int.Parse(Console.ReadLine());
                        Console.Write("podaj kwote:");
                        kwota = int.Parse(Console.ReadLine());

                        if (konto[nrKonta] < kwota)
                        {
                            Console.WriteLine("Brak wystarczających środków na koncie, masz aktualnie {0} pln.", konto[nrKonta]);
                        }
                        else
                        {
                            konto[nrKonta] = konto[nrKonta] - kwota;
                        }

                        break;
                }
            }


        }
    }
}


