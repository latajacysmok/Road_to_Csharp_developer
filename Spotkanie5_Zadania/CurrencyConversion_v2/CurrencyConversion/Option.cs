namespace CurrencyConversion
{
    class Option
    {
        public int DecideWhichOption()
        {
            while (true)
            {
                Console.WriteLine("If 'Yes' enter: '1'.");
                Console.WriteLine("If 'No' enter: '2'.");
                int decision = ItNumber();
                if (decision == 1 || decision == 2) return decision;
                else Console.WriteLine($"Your number is: {decision}.\nThe given number must equal 1 if you want to continue or 2 if you want to end the program. Try again.");
            }
        }

        public int ItNumber()
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
            while(true)
            {
                string foreignCurrency = Console.ReadLine();
                string[] currency = { "Dollar", "Euro", "Czech crown" };
                if (!String.IsNullOrEmpty(foreignCurrency))
                {
                    if (currency.Contains(char.ToUpper(foreignCurrency[0]) + foreignCurrency.Substring(1))) return foreignCurrency;
                    else Console.WriteLine("Try again, you can choose from among: \n-Dollar,\n-Euro,\n-Czech crown.");
                }
                else Console.WriteLine("You didn't enter anything value, try again please.");
            }            
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
            if (decision == 1) StayOnProgram();
            else if (decision == 2) LeaveProgramme();
        }

        public void StayOnProgram()
        {
            Console.WriteLine($"So let's get started again dear user.");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.Clear();
        }

        public void LeaveProgramme()
        {
            Console.WriteLine($"See you soon dear user.");
            Environment.Exit(1);
        }

        public void NoDecisionYet()
        {
            Console.WriteLine("I understand that you are not yet decided what to do. We can try again.");
            WhatDoWeDoNext();
        }
    }
}
