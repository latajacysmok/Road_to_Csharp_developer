namespace PrecisionString_tools
{
    class Date
    {
        public string TakeName()
        {
            Console.Write("Dear user, give me the name of the variable: ");
            return Console.ReadLine();
        }

        private string TakeWord(int minStringLen, int maxStringLen)
        {
            Console.Write("Finally, give me the word you want: ");
            string wordFromUser = Console.ReadLine();
            while (true)
            {
                if (minStringLen <= wordFromUser.Length && wordFromUser.Length <= maxStringLen) return wordFromUser;
                else
                {
                    Console.Write($"My good friend, your word lenght have now {wordFromUser.Length}, but should be between {minStringLen} and {maxStringLen}.\n\n Enter the word again: ");
                    wordFromUser = Console.ReadLine();
                }
            }
        }

        public string TakeString()
        {
            int minStringLen = TakeMinimumStringLength();
            int maxStringLen = TakeMaximumStringLength(minStringLen);
         
            return TakeWord(minStringLen, maxStringLen);
        }

        private int TakeMinimumStringLength()
        {
            while (true)
            {
                Console.Write("Now please give me a minimum string length my good friend: ");
                if (int.TryParse(Console.ReadLine(), out int minStringLen)) return minStringLen;
                else Console.WriteLine($"This is not a number: {minStringLen.ToString()}. Try again, please.");
            }
        }

        private int TakeMaximumStringLength(int minStringLen)
        {
            while (true)
            {
                Console.Write("Please give me a maximum string length my good friend: ");
                if (int.TryParse(Console.ReadLine(), out int maxStringLen))
                {
                    if (maxStringLen < minStringLen) Console.WriteLine($"Your number is less than the minimum, try to enter something greater than {minStringLen}!!!");
                    else return maxStringLen;
                }
                else Console.WriteLine($"This is not a number: {maxStringLen.ToString()}. Try again, please.");
            }
        }
    }
}
