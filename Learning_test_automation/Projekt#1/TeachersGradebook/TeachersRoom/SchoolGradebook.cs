using SchoolData;

namespace Infrastructure
{
    public class SchoolGradebook
    {
        public void ShowGrade(SchoolSubjects schoolSubjects, Student student)
        {
            switch (schoolSubjects)
            {
                case SchoolSubjects.Mathematics:
                    Console.WriteLine("\nMath grades are as follows:");
                    PrintSubjectGrades(student.TeachersDiary.mathGrades);
                    break;
                case SchoolSubjects.Physics:
                    Console.WriteLine("\nPhysics grades are as follows:");
                    PrintSubjectGrades(student.TeachersDiary.physicsGrades);
                    break;
                case SchoolSubjects.Religion:
                    Console.WriteLine("\nReligious grades are as follows:");
                    PrintSubjectGrades(student.TeachersDiary.religionGrades);
                    break;
                default:
                    Console.WriteLine("There is no such school subject in our timetable.");
                    break;
            }
        }

        private void PrintSubjectGrades(List<Grades> subject)
        {
            int index = 0;
            int totalCount = subject.Count;

            foreach (Grades grades in subject)
            {
                index++;

                if (index == totalCount)
                {
                    Console.WriteLine(grades.Grade + " ;");
                }
                else
                {
                    Console.Write(grades.Grade + ", ");
                }
            }
            Console.WriteLine("");
        }

        public void ListAvailableStudents(List<Student> studentsList)
        {
            Console.WriteLine("\nHere is a list of our students: ");

            foreach (Student student in studentsList)
            {
                Console.WriteLine(student.ToString());
            }
            Console.WriteLine("");
        }

        public void ListAvailableSubjects()
        {
            Console.WriteLine("\nHere is a list of our subjects: ");

            string[] subjectNames = Enum.GetNames(typeof(SchoolSubjects));

            int count = 1;
            foreach (string subjectName in subjectNames)
            {
                Console.WriteLine(count + " - " + subjectName);
                count++;
            }
            Console.WriteLine("");
        }
    }
}
