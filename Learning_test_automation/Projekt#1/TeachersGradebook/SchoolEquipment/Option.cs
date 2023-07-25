namespace SchoolEquipment
{
    public class Option
    {

        public string GetName()
        {
            string name;
            Console.Write("Please enter the name of the student: ");
            while (true)
            {
                name = Console.ReadLine();
                if (String.IsNullOrEmpty(name)) Console.Write("You didn't enter any value, try again: ");
                else break;
            }
            return name;
        }

        public string GetLastName()
        {
            string lastname;
            Console.Write("Please enter the lastname of the student: ");
            while (true)
            {
                lastname = Console.ReadLine();
                if (String.IsNullOrEmpty(lastname)) Console.Write("You didn't enter any value, try again: ");
                else break;
            }
            return lastname;
        }

        public int GetGrade(Verifier verifier)
        {
            Console.Write("Please enter the class your student is attending: ");
            return verifier.GetSchoolGradeNumber();
        }

        public int GetID(Verifier verifier)
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
