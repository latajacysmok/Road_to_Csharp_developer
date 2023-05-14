namespace Option
{
    public class Validation
    {
        public int ValidateOptionNumber()
        {
            Console.Write("Drogi użytkowniku podaj proszę opcję którą chcesz użyć: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    if (LimitingOptions(number)) return number;
                    else
                    {
                        Console.Write("Drogi użytkowniku, podaj swoją odpowiedź: ");
                        continue;
                    }
                }
                else if (String.IsNullOrEmpty(number.ToString())) Console.Write("Drogi użytkowniku musisz podać mi jakąś watrość: ");
                else Console.Write($"{number} to nie jest liczba, spróbuj proszę jeszcze raz: ");
            }
        }

        private bool LimitingOptions(int number)
        {
            while (true)
            {
                if (0 < number && number < 6) return true;
                else
                {
                    Console.WriteLine($"Twój wybór: {number} jest zły. Musi być równy: 1 - 5");
                    return false;
                }
            }
        }

        public int GetAmount()
        {
            int amount;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out amount))
                {
                    if (IfNumberIsPositive(amount)) break;
                    else continue;
                }
                else Console.Write($"To nie jest liczba: {amount}. Spróbuj ponownie proszę: ");
            }
            return amount;
        }

        private bool IfNumberIsPositive(int number)
        {
            if (number > 0) return true;
            else
            {
                Console.Write("Nie mogę przyjąć ujemnej liczby. Spróbuj ponownie proszę: ");
                return false;
            }
        } 

        public void LeaveProgramme()
        {
            Console.WriteLine($"\nRozumiem, do zobaczenia później.");
            Console.ReadKey();
            Environment.Exit(1);
        }
    }
}
