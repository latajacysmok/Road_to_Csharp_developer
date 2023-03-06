using Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word
{
    internal class Program
    {
        static public void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome my dear user to a program showing what can be done with a string in C#.");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("\nFirst select the operation you want to perform on the string:");
                ChoiceOptions choiceOptions = new ChoiceOptions();
                choiceOptions.SelectOption();
                OptionsProgram possibleOptionsForUser = new OptionsProgram();
                possibleOptionsForUser.MakingDecisionYesorNo();
            }
        }
    }
}
