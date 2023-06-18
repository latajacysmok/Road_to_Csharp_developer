using SchoolData;

namespace Infrastructure
{
    public class Option
    {
        Verifier verifier = new Verifier();
        StudentRepository studentRepository = new StudentRepository();
        GradeRepository gradeRepository = new GradeRepository();

        public int GetUniqueStudentId()
        {
            var students = studentRepository.GetAllStudents();

            int id = 0;
            if (verifier.IsNullOrEmpty(students))
            {
                Console.WriteLine("\nYour list is empty, You add the first item to your list.");
                return 1;
            }
            else
            {
                foreach (Student student in students)
                {
                    if (student.Id > id) id = student.Id;
                }
                return id + 1;
            }
        }

        public int GetUniqueStudentId(int stutentId)
        {
            var students = studentRepository.GetAllStudents();

            //int id = 0;
            if (verifier.IsNullOrEmpty(students))
            {
                Console.WriteLine("\nYour list is empty, You add the first item to your list.");
                return stutentId;
            }
            else
            {
                foreach (Student student in students)
                {
                    if (student.Id == stutentId) stutentId = GetUniqueStudentId();
                }
                return stutentId;
            }
        }

        public int GetUniqueGradeId()
        {
            List<IGrade> grades = gradeRepository.GetAllGrades();
            int id = 0;

            if (verifier.IsNullOrEmpty(grades))
            {
                Console.WriteLine("\nYour list is empty, You add the first item to your list.");
                return 1;
            }
            else
            {
                foreach (Grade grade in grades)
                {
                    if (grade.Id > id) id = grade.Id;
                }
                return id + 1;
            }           
        }

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

        public int GetGrade()
        {
            Console.Write("Please enter the class your student is attending: ");
            return verifier.GetSchoolGradeNumber();
        }

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
