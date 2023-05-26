using SchoolData;

namespace Infrastructure
{
    public class SchoolGradeWizard
    {
        Option option = new Option();
        Verifier verifier = new Verifier();
        SchoolGradebook schoolGradebook = new SchoolGradebook();

        public void AddGrade(List<Student> studentsList)
        {
            schoolGradebook.ListAvailableStudents(studentsList);
            int id = option.GetID();

            schoolGradebook.ListAvailableSubjects();

            AddGrade(id, studentsList, GetSchoolSubjects());
        }

        private void AddGrade(int id, List<Student> studentsList, SchoolSubjects schoolSubjects)
        {
            Student student = studentsList[id - 1];

            switch (schoolSubjects)
            {
                case SchoolSubjects.Mathematics:
                    student.TeachersDiary.AddGradeToSchoolSubjects(student.TeachersDiary.mathGrades, student.id); 
                    break;
                case SchoolSubjects.Physics:
                    student.TeachersDiary.AddGradeToSchoolSubjects(student.TeachersDiary.physicsGrades, student.id);
                    break;
                case SchoolSubjects.Religion:
                    student.TeachersDiary.AddGradeToSchoolSubjects(student.TeachersDiary.religionGrades, student.id);
                    break;
                default:
                    Console.WriteLine("There is no such school subject in our timetable.");
                    break;
            }
        }

        public void ShowGrade(List<Student> studentsList)
        {
            SchoolSubjects schoolSubjects = new SchoolSubjects();
            schoolGradebook.ListAvailableStudents(studentsList);
            int id = option.GetID();

            Student student = studentsList[id - 1];

            schoolGradebook.ListAvailableSubjects();
            schoolSubjects = GetSchoolSubjects();
            schoolGradebook.ShowGrade(schoolSubjects, student);
        }

        public SchoolSubjects GetSchoolSubjects()
        {
            while (true)
            {
                switch (verifier.GetValidOptionNumber())
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
    }
}
