using SchoolData;

namespace Infrastructure
{
    public class SchoolGradebook
    {
        Option option = new Option();
        GradeRepository gradeRepository = new GradeRepository();
        
        public void ShowGrade(SchoolSubjects schoolSubjects, IStudent student)
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

        public void AddGrade(int studentId, SchoolSubjects subject)
        {
            double[] ratings = { 1, 1.5D, 2, 2.5D, 3, 3.5D, 4, 4.5D, 5, 5.5D, 6 };
            

            PrintPossibleSchoolGrades(ratings);

            Console.Write("\nDear user, enter the rating you want to add: ");
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double number))
                {
                    if (ratings.Contains(number))
                    {
                        int gradeID = option.GetUniqueGradeId();
                        IGrade grade = new Grade(gradeID, studentId, subject, number);
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
        private void PrintSubjectGrades(List<Grade> grades)
        {
            int index = 0;
            int totalCount = grades.Count;

            if (totalCount == 0) Console.WriteLine("\nYour list is empty, You add the first item to your list.");
            else
            {
                foreach (Grade grade in grades)
                {
                    index++;

                    if (index == totalCount)
                    {
                        Console.WriteLine(grade.Value + " ;");
                    }
                    else
                    {
                        Console.Write(grade.Value + ", ");
                    }
                }
                Console.WriteLine("");
            }       
        }
    }
}
