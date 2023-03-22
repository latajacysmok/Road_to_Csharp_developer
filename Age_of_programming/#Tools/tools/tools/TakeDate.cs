namespace Tools
{
    class TakeDate
    {
        public string TakeName()
        {
            Console.Write("Dear user, give me the name of the variable: ");
            return Console.ReadLine();
        }

        public int TakeNumber()
        {
            int number;
            while (true)
            {
                Console.Write("Now please give me a number my good friend: ");
                if (int.TryParse(Console.ReadLine(), out number)) break;
                else Console.WriteLine($"This is not a number. Try again, please.");
            }
            return number;
        }

        public void PrintDate(string name, int number)
        {
            Console.WriteLine($"Your variable {name} has the value: {number}");
        }
    }
}
