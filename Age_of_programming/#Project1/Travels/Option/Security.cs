using System;
using System.Diagnostics;

namespace Option
{
    public class Security
    {
        private static bool IfEmpty(string word)
        {
            return String.IsNullOrEmpty(word);
        }

        private static bool IfNumberFromSet(int number)
        {
            if (0 < number && number < 10) return true;
            else return false;
        }

        public static string GetName()
        {
            string word;
            while (true)
            {
                word = Console.ReadLine();
                if (IfEmpty(word)) Console.Write("Nie wprowadziłeś żadnej wartści, spróbuj ponownie: ");
                else break;
            }
            return word;
        }

        public static int GetNumber()
        {
            string caller = new StackTrace().GetFrame(1).GetMethod().Name;

            if (caller == "ClearPlace" || caller == "SelectPlace") Console.Write("Podaj numer miejsca: ");
            else if (caller == "DeletePerson" || caller == "SelectPerson") Console.Write("Podaj numer osoby: ");
            else Console.Write("\nWybierz proszę opcję która Cię interesuję: ");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    if(IfNumberFromSet(number)) return number;
                    else Console.Write($" Wybrałeś: {number}, nie jest to liczba z zakresu 1-9. Spróbuj ponownie: ");
                }
                else Console.Write("Nie wprowadziłeś cyfry: ");
            }
        }
        public static void LeaveProgramme()
        {
            Console.WriteLine($"\nRozumiem, w takim razie do zobaczenia(aby zamknąć aplikację kliknij dowolny klawisz).");
            Console.ReadKey();
            Environment.Exit(1);
        }
    }
}