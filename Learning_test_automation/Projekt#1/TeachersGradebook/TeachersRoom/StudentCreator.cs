using SchoolData;

namespace TeachersRoom
{
    public class StudentCreator
    {
        Option option = new Option();
        private string name;
        private string lastname;
        private int grade;
        Student student;

        private TeachersDiary teachersDiary;

        public TeachersDiary TeachersDiary
        {
            get { return teachersDiary; }
        }

        public StudentCreator()
        {
            name = GetName();
            lastname = GetLastName();
            grade = GetGrade();
            student = new Student(name, lastname, grade);
            teachersDiary = new TeachersDiary(student.id);
        }

        private string GetName()
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

        private string GetLastName()
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
            return option.ReadPositiveIntegerInput();
        }

        public override string ToString()
        {
            return $"{name} {lastname}, ID number: {student.id}";
        }
    }
}
