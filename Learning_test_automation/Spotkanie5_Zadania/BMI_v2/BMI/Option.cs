﻿namespace BMI
{
    class Option
    {
        public void ProgramWelcome()
        {
            Console.WriteLine("Welcome to BMI Calculator");
            Console.WriteLine("We will now calculate your BMI");
            Console.WriteLine("-------------------------");
            Console.Write("Dear user, write me your name: ");
        }

        public void MakingDecisionAboutNextStep(string name)
        {
            while (true)
            {
                Console.WriteLine($"{name} do you want to continue: ");
                Console.WriteLine("If yes enter: '1'.");
                Console.WriteLine("If no enter: '2'.");
                double decisionToExitTheProgram = ItNumber();
                if (decisionToExitTheProgram == 1)
                {
                    StayOnProgram();
                    return;
                }
                else if (decisionToExitTheProgram == 2) LeaveProgramme();
                else Console.WriteLine($"{name} entered an invalid value, The given number must equal 1 if you want to continue and 2 if you want to end the program. Please try again.");
            }
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

        public double ItNumber()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double number)) return number;
                else Console.Write($"{number} is not a number, please try again: ");
            }
        }
    }
}
