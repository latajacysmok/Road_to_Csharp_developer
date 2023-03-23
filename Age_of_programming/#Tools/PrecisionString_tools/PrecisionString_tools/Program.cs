namespace PrecisionString_tools
{
    class Program
    {
        static public void Main(string[] args)
        {
            Data.Data takeDate = new Data.Data();
            Printer.Printer printer = new Printer.Printer();

            string varNameFromUser = takeDate.TakeName();
            string valueFromUser = takeDate.TakeString();
            Console.WriteLine("--------\n");
            printer.PrintDate(varNameFromUser, valueFromUser);
            Console.ReadKey();
        }
    }

}
