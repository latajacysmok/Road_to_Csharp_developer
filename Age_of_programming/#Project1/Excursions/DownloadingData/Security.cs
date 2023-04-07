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
    }
}
