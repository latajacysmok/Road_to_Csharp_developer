namespace Tools
{
    class Program
    {
        static void Main(string[] args)
        {
            string varNameFromUser = TakeName();
            int valueFromUser = TakeNumber();
            Console.WriteLine("--------\n");
            PrintDate(varNameFromUser, valueFromUser);
            Console.ReadKey();
        }

        static string TakeName()
        {
            Console.Write("Dear user, give me the name of the variable: ");
            return Console.ReadLine();
        }

        static int TakeNumber()
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

        static void PrintDate(string name, int number)
        {
            Console.WriteLine($"Your variable {name} has the value: {number}");
        }
    }

}

