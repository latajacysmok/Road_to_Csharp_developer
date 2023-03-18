namespace String
{
    internal class Program
    {
        static public void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome my dear user to a program showing what can be done with a string in C#.");
                Console.WriteLine("-------------------------------------------------------------------------------");
                OptionSelector choiceOptions = new OptionSelector();
                choiceOptions.PerformedOption();
                OptionsProgram possibleOptionsForUser = new OptionsProgram();
                possibleOptionsForUser.MakingDecisionAboutNextStep();
            }
        }
    }
}
