namespace Tools
{
    class Program
    {
        static public void Main(string[] args)
        {
            TakeDate takeDate = new TakeDate();
            string varNameFromUser = takeDate.TakeName();
            int valueFromUser = takeDate.TakeNumber();
            Console.WriteLine("--------\n");
            takeDate.PrintDate(varNameFromUser, valueFromUser);
            Console.ReadKey();
        }
    }
}

