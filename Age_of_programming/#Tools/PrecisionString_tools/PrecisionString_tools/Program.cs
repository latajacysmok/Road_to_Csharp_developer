namespace PrecisionString_tools
{
    class Program
    {
        static public void Main(string[] args)
        {
            Data.ValueStorage takeDate = new Data.ValueStorage();
            Printer.Scribe printer = new Printer.Scribe();

            string varNameFromUser = takeDate.TakeName();
            string valueFromUser = takeDate.TakeString();
            Console.WriteLine("--------\n");
            printer.PrintDate(varNameFromUser, valueFromUser);
            Console.ReadKey();
        }
    }

}
