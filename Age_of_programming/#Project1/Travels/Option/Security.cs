namespace Option
{
    public class Security
    {
        private bool IfEmpty(string word)
        {
            return String.IsNullOrEmpty(word);
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
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int number)) return number;
                else Console.Write("Nie wprowadziłeś liczby: ");
            }
        }
    }
}