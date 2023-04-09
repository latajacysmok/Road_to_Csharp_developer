namespace Option
{
    public class Security
    {
        private bool IfEmpty(string word)
        {
            return String.IsNullOrEmpty(word);
        }

        private bool IfNumberFromSet(int number)
        {
            if (0 < number && number < 10) return true;
            else return false;
        }

        public string GetName()
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

        public int GetNumber()
        {
            Console.Write("\nWybierz proszę opcję która Cię interesuję: ");
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
        public void LeaveProgramme()
        {
            Console.WriteLine($"\nRozumiem, w takim razie do zobaczenia(aby zamknąć aplikację kliknij dowolny klawisz).");
            Console.ReadKey();
            Environment.Exit(1);
        }
    }
}