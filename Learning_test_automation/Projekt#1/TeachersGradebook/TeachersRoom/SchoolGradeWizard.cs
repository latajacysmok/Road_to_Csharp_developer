using SchoolData;

namespace TeachersRoom
{
    public class SchoolGradeWizard
    {
        Option option = new Option();

        public void AddGrade(List<StudentCreator> studentsList)
        {
            ListAvailableStudents(studentsList);
            int id = GetID();

            ListAvailableSubjects();

            AddGrade(id, studentsList, GetSchoolSubjects());
        }

        private void AddGrade(int id, List<StudentCreator> studentsList, SchoolSubjects schoolSubjects)
        {
            StudentCreator student = studentsList[id - 1];
            switch (schoolSubjects)
            {
                case SchoolSubjects.Mathematics:
                    student.TeachersDiary.AddGradeToSchoolSubjects(student.TeachersDiary.mathGrades); ;
                    break;
                case SchoolSubjects.Physics:
                    student.TeachersDiary.AddGradeToSchoolSubjects(student.TeachersDiary.physicsGrades); ;
                    break;
                case SchoolSubjects.Religion:
                    student.TeachersDiary.AddGradeToSchoolSubjects(student.TeachersDiary.religionGrades); ;
                    break;
                default:
                    Console.WriteLine("There is no such school subject in our timetable.");
                    break;
            }
        }

        public void ShowGrade(List<StudentCreator> studentsList)
        {
            SchoolSubjects schoolSubjects = new SchoolSubjects();
            ListAvailableStudents(studentsList);
            int id = GetID();
            StudentCreator student = studentsList[id - 1];

            ListAvailableSubjects();
            schoolSubjects = GetSchoolSubjects();
            ShowGrade(id, schoolSubjects, student);
        }

        private void ShowGrade(int id, SchoolSubjects schoolSubjects, StudentCreator student)
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

        private void PrintSubjectGrades(List<double> subject)
        {
            int index = 0;
            int totalCount = subject.Count;

            foreach (double grades in subject)
            {
                index++;

                if (index == totalCount)
                {
                    Console.WriteLine(grades + " ;");
                }
                else
                {
                    Console.Write(grades + ", ");
                }
            }
            Console.WriteLine("");
        }

        private int GetID()
        {
            Console.Write("Enter the ID of the student you are interested in: ");
            return option.ReadPositiveIntegerInput();
        }

        private SchoolSubjects GetSchoolSubjects()
        {
            while (true)
            {
                switch (option.ValidateOptionNumber())
                {
                    case (int)SchoolSubjects.Mathematics:
                        return SchoolSubjects.Mathematics;
                    case (int)SchoolSubjects.Physics:
                        return SchoolSubjects.Physics;
                    case (int)SchoolSubjects.Religion:
                        return SchoolSubjects.Religion;
                    default:
                        Console.WriteLine("\nThe given number must equal 1, 2 or 3. Try again.");
                        break;
                }
            }
        }

        private void ListAvailableStudents(List<StudentCreator> studentsList)
        {
            Console.WriteLine("\nHere is a list of our students: ");

            foreach (StudentCreator student in studentsList)
            {
                Console.WriteLine(student.ToString());
            }
            Console.WriteLine("");
        }

        private void ListAvailableSubjects()
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
