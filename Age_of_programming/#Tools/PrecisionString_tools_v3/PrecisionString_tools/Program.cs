using System;

namespace Precision_tools
{
    class Program
    {
        static void Main(string[] args)
        {
            string varNameFromUser = TakeName();
            string valueFromUser = TakeString();
            Console.WriteLine("--------\n");
            PrintDate(varNameFromUser, valueFromUser);
            Console.ReadKey();
        }
        
        static string TakeName()
        {
            Console.Write("Dear user, give me the name of the variable: ");
            return Console.ReadLine();
        }

        static string TakeString()
        {
            int minStringLen;
            int maxStringLen;

            while (true)
            {
                Console.Write("Now please give me a minimum string length my good friend: ");
                if (int.TryParse(Console.ReadLine(), out minStringLen)) break;
                else Console.WriteLine($"This is not a number: {minStringLen.ToString()}. Try again, please.");
            }
            while (true)
            {
                Console.Write("Please give me a maximum string length my good friend: ");
                if (int.TryParse(Console.ReadLine(), out maxStringLen))
                {
                    if (maxStringLen < minStringLen)
                    {
                        Console.WriteLine($"Your number is less than the minimum, try to enter something greater than {minStringLen}!!!");
                        continue;
                    }
                    break;
                }                  
                else Console.WriteLine($"This is not a number: {maxStringLen.ToString()}. Try again, please.");
            }
            Console.WriteLine("Finally, give me the word you want: ");
            string wordFromUser = Console.ReadLine();
            while (true)
            {                
                if (minStringLen <= wordFromUser.Length && wordFromUser.Length <= maxStringLen) break;
                else
                {
                    Console.Write($"My good friend, your word lenght have now {wordFromUser.Length}, but should be between {minStringLen} and {maxStringLen}.\n\n Enter the word again: ");
                    wordFromUser = Console.ReadLine();
                }
            }
            return wordFromUser;
        }

        static void PrintDate(string varNameFromUser, string valueFromUser)
        {
            Console.WriteLine($"Your variable {varNameFromUser} has the value: {valueFromUser}");
        }
    }

}
