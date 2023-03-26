namespace Tools
{
    class Program
    {
        static public void Main(string[] args)
        {
            Data.ValueStorage takeData = new Data.ValueStorage();
            string varNameFromUser = takeData.TakeName();
            int valueFromUser = takeData.TakeNumber();
            Console.WriteLine("--------\n");
            takeData.PrintDate(varNameFromUser, valueFromUser);
            Console.ReadKey();
        }
    }
}

