namespace Infrastructure
{
    public class Verifier
    {
        public int GetValidOptionNumber()
        {
            Console.Write("Dear user, please specify the option you want to use: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    if (IsChoiceWithinRange(number)) return number;
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

        private bool IsChoiceWithinRange(int number)
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
        public int GetPositiveIntegerInput()
        {
            int amount;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out amount))
                {
                    if (IsNumberPositive(amount)) break;
                    else continue;
                }
                else Console.Write($"This is not a number: {amount}. Please try again: ");
            }
            return amount;
        }

        public int GetSchoolGradeNumber()
        {
            int amount;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out amount))
                {
                    if (0 < amount && amount < 9) break;
                    else if (0 > amount) Console.Write($"The given number({amount}) is too small. Please try again:");
                    else if( amount > 9) Console.Write($"The given number({amount}) is too large. Please try again:");
                }
                else Console.Write($"This is not a number: {amount}. Please try again: ");
            }
            return amount;
        }

        private bool IsNumberPositive(int number)
        {
            if (number > 0) return true;
            else
            {
                Console.Write("I can't accept a negative number. Please try again: ");
                return false;
            }
        }

        public bool IsNullOrEmpty<T>(List<T> inputList)
        {
            if (inputList?.Any() != true) return true;
            else return false;
        }
    }
}
