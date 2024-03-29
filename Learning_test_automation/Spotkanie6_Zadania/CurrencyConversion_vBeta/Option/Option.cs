﻿using CurrencySelection;
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
                int decision = ValidateOptionNumber();
                if (decision == (int)MakingDecision.Yes) return MakingDecision.Yes;
                else if (decision == (int)MakingDecision.No) return MakingDecision.No;
                else Console.WriteLine($"Your number is: {decision}.\nThe given number must equal 1 if you want to continue or 2 if you want to end the program. Try again.");
            }
        }

        public int ValidateOptionNumber()
        {
            Console.Write("Dear user, please give me your answer now: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    string caller = new StackTrace().GetFrame(1).GetMethod().Name;
                    bool ifTwoChoiceOption;
                    if (caller == "DecideWhichOption") ifTwoChoiceOption = true;
                    else ifTwoChoiceOption = false;
                    if (LimitingOptions(ifTwoChoiceOption, number)) return number;
                    else
                    {
                        Console.Write("Dear user, please give me your answer now: ");
                        continue;
                    }
                }
                else if (String.IsNullOrEmpty(number.ToString())) Console.Write("Dear User you have to give me some value: ");
                else Console.Write($"{number} is not a number, please try again: ");
            }
        }

        private bool LimitingOptions(bool ifYesOrNo, int number)
        {
            while (true)
            {
                if (ifYesOrNo)
                {
                    if (0 < number && number < 3) return true;
                    else
                    {
                        Console.WriteLine($"Your choice: {number} is wrong. Must be equal: 1 or 2");
                        return false;
                    }
                }
                else
                {
                    if (0 < number && number < 4) return true;
                    else
                    {
                        Console.WriteLine($"Your choice: {number} is wrong. Must be equal: 1, 2 or 3");
                        return false;
                    }
                }
            }
        }

        public decimal GetAmount()
        {
            decimal amount;
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out amount))
                {
                    if (IfNumberIsPositive(amount)) break;
                    else continue;
                }
                else Console.Write($"This is not a number: {amount}. Try again, please: ");
            }
            return amount;
        }

        private bool IfNumberIsPositive(decimal number)
        {
            if (number > 0) return true;
            else
            {
                Console.Write("I can't convert negative value of money. Try again, please: ");
                return false;
            }
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