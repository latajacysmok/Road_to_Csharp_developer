using Decide;
using static Decide.Names;

namespace CurrencyConversion
{
    public class Option
    {
        public MakingDecision DecideWhichOption()
        {
            while (true)
            {
                Console.WriteLine("If 'Yes' enter: '1'.");
                Console.WriteLine("If 'No' enter: '2'.");
                int decision = ItNumber();
                if (decision == (int)MakingDecision.Yes) return MakingDecision.Yes;
                else if (decision == (int)MakingDecision.No) return MakingDecision.No;
                else Console.WriteLine($"Your number is: {decision}.\nThe given number must equal 1 if you want to continue or 2 if you want to end the program. Try again.");
            }
        }

        private int ItNumber()
        {
            Console.Write("Dear user, please give me your answer now: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    if (0 < number && number < 4 ) return number;
                    else Console.WriteLine($"{number} must be equal: 1, 2 or 3");
                }
                else if (String.IsNullOrEmpty(number.ToString())) Console.Write("Dear User you have to give me some value: ");
                else Console.Write($"{number} is not a number, please try again: ");
            }
        }

        public CurrencyDefault GetCurrencyName()
        {
            AvailableCurrencies();
            
            while (true)
            {
                if (Enum.TryParse(ItNumber().ToString(), out CurrencyDefault currency)) return currency;
                else Console.WriteLine("Try again, you can choose from among: \n-Dollar: 1,\n-Euro: 2,\n-Czech crown: 3.");
            }
        }

        public void AvailableCurrencies()
        {
            Console.WriteLine("- Dollar: 1,");
            Console.WriteLine("- Euro: 2,");
            Console.WriteLine("- Czech crown: 3.");
        }

        public void WhatDoWeDoNext()
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("\nUser, would you like to perform another operation?");
            MakingDecision decision = DecideWhichOption();
            if (decision == MakingDecision.Yes) StayOnProgram();
            else if (decision == MakingDecision.No) LeaveProgramme();
        }

        private void StayOnProgram()
        {
            Console.WriteLine("\nSo let's get started again dear user.");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.Clear();
        }

        private void LeaveProgramme()
        {
            Console.WriteLine($"\nI understand that, see you soon dear user.");
            Console.ReadKey();
            Environment.Exit(1);
        }
    }
}