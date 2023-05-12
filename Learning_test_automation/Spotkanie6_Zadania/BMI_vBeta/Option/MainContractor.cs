namespace Option
{
    public class MainContractor
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
                Console.Write("Dear user, make a choice: ");
                double decisionToExitTheProgram = ItNumber();
                if (decisionToExitTheProgram == (int)MakingDecision.Yes)
                {
                    StayOnProgram();
                    break;
                }
                else if (decisionToExitTheProgram == (int)MakingDecision.No) LeaveProgramme();
                else Console.WriteLine($"Your number is: {decisionToExitTheProgram}.\nThe given number must equal 1 if you want to continue or 2 if you want to end the program. Try again.");
            }
        }

        public string GetName()
        {
            string name;

            while (true)
            {
                name = Console.ReadLine();
                if (!String.IsNullOrEmpty(name)) break;
                else Console.Write("Dear user, you have entered an empty value, please enter your name: ");
            }
            return name.Substring(0, 1).ToUpper() + name.Substring(1);
        }

        private void StayOnProgram()
        {
            Console.WriteLine($"So let's get started again dear user.");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.Clear();
        }

        private void LeaveProgramme()
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
