using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word
{
    internal class OptionProgram
    {
        class OptionsProgram
        {
            private int decisionToExitTheProgram;

            public OptionsProgram(int number)
            {
                decisionToExitTheProgram = number;
            }
            public void MakingDecisionYesorNo()
            {
                while (true)
                {
                    Console.WriteLine($"Dear user do you want to continue: ");
                    Console.WriteLine("If 'Yes' enter: '1'.");
                    Console.WriteLine("If 'No' enter: '2'.");
                    //int decisionToExitTheProgram = 
                    if (decisionToExitTheProgram == 1)
                    {
                        StayOnProgram();
                        break;
                    }
                    else if (decisionToExitTheProgram == 2)
                    {
                        LeaveTheProgramme();
                    }
                    else Console.WriteLine("You entered an invalid value, The given number must equal 1 if you want to continue and 2 if you want to end the program. Please try again.");

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

            public void LeaveTheProgramme()
            {
                Console.WriteLine($"See you soon dear user.");
                Environment.Exit(1);
            }
        }
    }
}
