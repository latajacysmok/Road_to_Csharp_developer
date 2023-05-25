namespace Infrastructure
{
    public class Option
    {
        Verifier verifier = new Verifier();

        public int GetID()
        {
            Console.Write("Enter the ID of the student you are interested in: ");
            return verifier.GetPositiveIntegerInput();
        }
        public void LeaveProgramme()
        {
            Console.WriteLine($"\nDear user I understand, see you later.");
            Console.ReadKey();
            Environment.Exit(1);
        }
    }
}
