namespace BMI
{
    class Program
        {
            static public void Main(string[] args)
            {
                AnnouncementVerdict announcementVerdict = new AnnouncementVerdict();
                Console.WriteLine("Welcome to BMI Calculator");
                Console.WriteLine("We will now calculate your BMI");
                Console.WriteLine("-------------------------");
                Console.Write("Dear user, write me your name: ");
                announcementVerdict.ApplicationRunner();
            }
        }
}
   