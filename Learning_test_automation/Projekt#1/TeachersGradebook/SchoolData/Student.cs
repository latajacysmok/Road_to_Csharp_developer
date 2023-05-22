namespace SchoolData
{
    public class Student
    {
        private string Name { get; set; }
        private string LastName { get; set; }
        private int Grade { get; set; }

        private static int idCounter = 0;
        public int id;

        public Student(string name, string lastName, int grade)
        {
            idCounter++;
            id = idCounter;
            Name = name;
            LastName = lastName;
            Grade = grade;
        }
    }
}