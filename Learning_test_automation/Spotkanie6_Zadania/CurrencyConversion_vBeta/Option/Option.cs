using Decide;
using System.Diagnostics;

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
                int decision = VerifyItsNumber();
                if (decision == (int)MakingDecision.Yes) return MakingDecision.Yes;
                else if (decision == (int)MakingDecision.No) return MakingDecision.No;
                else Console.WriteLine($"Your number is: {decision}.\nThe given number must equal 1 if you want to continue or 2 if you want to end the program. Try again.");
            }
        }

        private int VerifyItsNumber()
        {
            Console.Write("Dear user, please give me your answer now: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    string caller = new StackTrace().GetFrame(1).GetMethod().Name;
                    bool ifYesOrNo;
                    if (caller == "DecideWhichOption" || caller == "BuyOrSell") ifYesOrNo = true;
                    else ifYesOrNo = false;
                    return LimitingOptions(ifYesOrNo, number);             
                }
                else if (String.IsNullOrEmpty(number.ToString())) Console.Write("Dear User you have to give me some value: ");
                else Console.Write($"{number} is not a number, please try again: ");
            }
        }

        private int LimitingOptions(bool ifYesOrNo, int number)
        {
            while(true)
            {
                if (ifYesOrNo)
                {
                    if (0 < number && number < 3) return number;
                    else Console.WriteLine($"{number} must be equal: 1 or 2 ");
                }
                else
                {
                    if (0 < number && number < 4) return number;
                    else Console.WriteLine($"{number} must be equal: 1, 2 or 3");
                }
            }
        }

        public void BuyOrSell()
        {
            Console.Write("Dear user, tell me what you want?\n");
            Console.WriteLine("If 'Buy' currency, enter: '1'.");
            Console.WriteLine("If 'Sell' currency, enter: '2'.");
            int decision = VerifyItsNumber();
            Transaction transaction = new Transaction();

            if (decision == (int)BuyingAndSelling.Buy) transaction.Buying();
            else if (decision == (int)BuyingAndSelling.Sell) transaction.Selling();
            else Console.WriteLine($"Your number is: {decision}.\nThe given number must equal 1 if you want to continue or 2 if you want to end the program. Try again.");
        }

        public CurrencyDefault GetCurrencyName()
        {
            PrintAvailableCurrencies();
            
            while (true)
            {
                if (Enum.TryParse(VerifyItsNumber().ToString(), out CurrencyDefault currency)) return currency;
                else Console.WriteLine("Try again, you can choose from among: \n-Dollar: 1,\n-Euro: 2,\n-Czech crown: 3.");
            }
        }

        public void PrintAvailableCurrencies()
        {
            Console.WriteLine("- Dollar: 1,");
            Console.WriteLine("- Euro: 2,");
            Console.WriteLine("- Czech crown: 3.");
        }
        
        public void PrintAvailableBuyExchangeRates()
        {
            Console.WriteLine("\n- Dollar: 4.38 pln,");
            Console.WriteLine("- Euro: 4.83 pln,");
            Console.WriteLine("- Czech crown: 0.24 pln.\n");
        }
        public void PrintAvailableSellExchangeRates()
        {
            Console.WriteLine("\n- Dollar: 4.87 pln,");
            Console.WriteLine("- Euro: 5.37 pln,");
            Console.WriteLine("- Czech crown: 0.27 pln.\n");
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