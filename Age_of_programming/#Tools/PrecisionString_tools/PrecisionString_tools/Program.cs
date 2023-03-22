namespace PrecisionString_tools
{
    class Program
    {
        static public void Main(string[] args)
        {
            Date takeDate = new Date();
            Printer printer = new Printer();

            string varNameFromUser = takeDate.TakeName();
            string valueFromUser = takeDate.TakeString();
            Console.WriteLine("--------\n");
            printer.PrintDate(varNameFromUser, valueFromUser);
            Console.ReadKey();
        }
    }

}
