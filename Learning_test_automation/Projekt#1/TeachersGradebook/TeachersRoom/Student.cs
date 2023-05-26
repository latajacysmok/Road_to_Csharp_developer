namespace Infrastructure
{
    public class Student
    {
        Verifier verifier = new Verifier();

        private TeachersDiary teachersDiary;
        public string name;
        public string lastName;
        public int educationYear;

        private static int idCounter = 0;
        public int id;


        public TeachersDiary TeachersDiary
        {
            get { return teachersDiary; }
        }

        public Student()
        {
            idCounter++;
            id = idCounter;
            name = GetName();
            lastName = GetLastName();
            educationYear = GetGrade();

            teachersDiary = new TeachersDiary();
        }

        private static string GetName()
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

        private static string GetLastName()
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

        private int GetGrade()
        {
            Console.Write("Please enter the class your student is attending: ");
            return verifier.GetPositiveIntegerInput();
        }

        public override string ToString()
        {
            return $"{name} {lastName}, ID number: {id}";
        }
    }
}
