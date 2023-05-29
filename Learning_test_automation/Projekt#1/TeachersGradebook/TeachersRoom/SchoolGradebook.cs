using SchoolData;

namespace Infrastructure
{
    public class SchoolGradebook
    {
        Option option = new Option();
        GradeRepository gradeRepository = new GradeRepository();
        
        public void ShowGrade(SchoolSubjects schoolSubjects, Student student)
        {
            switch (schoolSubjects)
            {
                case SchoolSubjects.Mathematics:
                    Console.WriteLine("\nMath grades are as follows:");
                    PrintSubjectGrades(gradeRepository.GetGradeStudentsSubject(student.Id, SchoolSubjects.Mathematics));
                    break;
                case SchoolSubjects.Physics:
                    Console.WriteLine("\nPhysics grades are as follows:");
                    PrintSubjectGrades(gradeRepository.GetGradeStudentsSubject(student.Id, SchoolSubjects.Physics));
                    break;
                case SchoolSubjects.Religion:
                    Console.WriteLine("\nReligious grades are as follows:");
                    PrintSubjectGrades(gradeRepository.GetGradeStudentsSubject(student.Id, SchoolSubjects.Religion));
                    break;
                default:
                    Console.WriteLine("There is no such school subject in our timetable.");
                    break;
            }
        }

        public void AddGradeToStudent(int id, SchoolSubjects subject)
        {
            double[] ratings = { 1, 1.5D, 2, 2.5D, 3, 3.5D, 4, 4.5D, 5, 5.5D, 6 };
            List<Grade> grades = gradeRepository.GetAllGrades();

            PrintPossibleSchoolGrades(ratings);

            Console.Write("\nDear user, enter the rating you want to add: ");
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double number))
                {
                    if (ratings.Contains(number))
                    {
                        int gradeID = option.GetUniqueGradeId(grades);
                        Grade grade = new Grade(gradeID, id, subject, number);
                        gradeRepository.AddGrade(grade);
                        break;
                    }
                    else Console.WriteLine("There is no such school grade.");
                }
                else Console.Write("You didn't provide a number.");
            }
        }

        private void PrintPossibleSchoolGrades(double[] ratings)
        {
            Console.WriteLine("\nList of school grades to choose from: ");
            foreach (double grade in ratings)
            {
                Console.Write(grade + " ");
            }
        }
        private void PrintSubjectGrades(List<Grade> subject)
        {
            int index = 0;
            int totalCount = subject.Count;

            foreach (Grade grades in subject)
            {
                index++;

                if (index == totalCount)
                {
                    Console.WriteLine(grades.Value + " ;");
                }
                else
                {
                    Console.Write(grades.Value + ", ");
                }
            }
            Console.WriteLine("");
        }
    }
}
