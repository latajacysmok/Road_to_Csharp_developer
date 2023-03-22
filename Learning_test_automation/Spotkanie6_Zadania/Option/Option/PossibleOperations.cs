using Decide;

namespace Option
{
    public class PossibleOperations
    {

        public int DecideWhichOption()
        {
            while (true)
            {
                Console.WriteLine("If 'Yes' enter: '1'.");
                Console.WriteLine("If 'No' enter: '2'.");
                int decision = ItNumber();
                if (decision == (int)Choice.Yes || decision == (int)Choice.No) return decision;
                else Console.WriteLine($"Your number is: {decision}.\nThe given number must equal 1 if you want to continue or 2 if you want to end the program. Try again.");
            }
        }

        private int ItNumber()
        {
            Console.Write("Dear user, please give me your answer now: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int number)) return number;
                else Console.Write($"{number} is not a number, please try again: ");
            }
        }

        public string IsCurrency()
        {
            AvailableCurrencies();
            while (true)
            {               
                string[] currency = { "Dollar", "Euro", "Czech_crown" };
                var foreignCurrency = ItNumber();
                Currency intAsEnum = (Currency)foreignCurrency;

                if (currency.Contains(intAsEnum.ToString())) return intAsEnum.ToString();
                else Console.WriteLine("Try again, you can choose from among: \n-Dollar: 1,\n-Euro: 2,\n-Czech crown: 3.");
            }
        }

        private int DecideWhichCurrency()
        {
            while (true)
            {
                Console.WriteLine("If 'Yes' enter: '1'.");
                Console.WriteLine("If 'No' enter: '2'.");
                int decision = ItNumber();
                if (decision == (int)Choice.Yes || decision == (int)Choice.No) return decision;
                else Console.WriteLine($"Your number is: {decision}.\nThe given number must equal 1 if you want to continue or 2 if you want to end the program. Try again.");
            }
        }

        public void AvailableCurrencies()
        {
            Console.WriteLine("- Dollar: 1,");
            Console.WriteLine("- Euro: 2,");
            Console.WriteLine("- Czech crown: 3.");
        }

        public decimal DownloadAmount()
        {
            decimal amount;
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out amount))
                {
                    if (amount > 0) break;
                    else Console.WriteLine("I can't convert negative value of money. Try again, please: ");
                }
                else Console.WriteLine($"This is not a number: {amount.ToString()}. Try again, please: ");
            }
            return Math.Round(amount, 2);
        }

        public void WhatDoWeDoNext()
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("\nUser, would you like to perform another operation?");
            int decision = DecideWhichOption();
            if (decision == (int)Choice.Yes) StayOnProgram();
            else if (decision == (int)Choice.No) LeaveProgramme();
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

        public void NoDecisionYet()
        {
            Console.WriteLine("I understand that you are not yet decided what to do. We can try again.");
            WhatDoWeDoNext();
        }
    }
}