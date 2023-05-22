namespace TeachersRoom
{
    public class Option
    {
        public int ValidateOptionNumber()
        {
            Console.Write("Dear user, please specify the option you want to use: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    if (LimitingOptions(number)) return number;
                    else
                    {
                        Console.Write("Dear user, please provide your answer: ");
                        continue;
                    }
                }
                else if (String.IsNullOrEmpty(number.ToString())) Console.Write("Dear user, you need to give me some value: ");
                else Console.Write($"{number} this is not a number, please try again: ");
            }
        }

        private bool LimitingOptions(int number)
        {
            while (true)
            {
                if (0 < number && number < 5) return true;
                else
                {
                    Console.WriteLine($"Your choice: {number} is incorrect. It has to be equal: 1 - 4");
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
                else Console.Write($"This is not a number: {amount}. Please try again: ");
            }
            return amount;
        }

        private bool IfNumberIsPositive(int number)
        {
            if (number > 0) return true;
            else
            {
                Console.Write("I can't accept a negative number. Please try again: ");
                return false;
            }
        }
        public void LeaveProgramme()
        {
            Console.WriteLine($"\nDear user I understand, see you later.");
            Console.ReadKey();
            Environment.Exit(1);
        }
    }
}
