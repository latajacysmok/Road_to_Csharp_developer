using SchoolData;
using SchoolEquipment;

namespace SchoolActivity
{
    public class SchoolGradebook
    {
        GradeRepository gradeRepository = new GradeRepository();
        Verifier verifier = new Verifier();
        Degree degree = new Degree();
        public void ShowAllGrades(SchoolSubjects schoolSubjects, IStudent student)
        {
            switch (schoolSubjects)
            {
                case SchoolSubjects.Mathematics:
                    if (gradeRepository.GetStudentGradesBySchoolSubject(student.Id, SchoolSubjects.Mathematics).Count == 0) { Console.WriteLine("This student has no grades. You need to add a some grades to it first."); }
                    else
                    {
                        Console.WriteLine("\nMath grades are as follows:");
                        PrintSubjectGrades(gradeRepository.GetStudentGradesBySchoolSubject(student.Id, SchoolSubjects.Mathematics));
                    }
                    
                    break;
                case SchoolSubjects.Physics:
                    if (gradeRepository.GetStudentGradesBySchoolSubject(student.Id, SchoolSubjects.Physics).Count == 0) { Console.WriteLine("This student has no grades. You need to add a some grades to it first."); }
                    else
                    {
                        Console.WriteLine("\nPhysics grades are as follows:");
                        PrintSubjectGrades(gradeRepository.GetStudentGradesBySchoolSubject(student.Id, SchoolSubjects.Physics));
                    }
                    
                    break;
                case SchoolSubjects.Religion:
                    if (gradeRepository.GetStudentGradesBySchoolSubject(student.Id, SchoolSubjects.Religion).Count == 0) { Console.WriteLine("This student has no grades. You need to add a some grades to it first."); }
                    else
                    {
                        Console.WriteLine("\nReligious grades are as follows:");
                        PrintSubjectGrades(gradeRepository.GetStudentGradesBySchoolSubject(student.Id, SchoolSubjects.Religion));
                    }
                    
                    break;
                default:
                    Console.WriteLine("There is no such school subject in our timetable.");
                    break;
            }
        }
        
        public void ShowGradesAverage(SchoolSubjects schoolSubjects, IStudent student)
        {
            switch (schoolSubjects)
            {
                case SchoolSubjects.Mathematics:
                    if (gradeRepository.GetStudentGradesBySchoolSubject(student.Id, SchoolSubjects.Mathematics).Count == 0) { Console.WriteLine("The grade point average is 0 because the student does not yet have grades in the subject."); } 
                    else 
                    {
                        Console.WriteLine("\nThe average math grade is:");
                        PrintSubjectAverage(gradeRepository.GetStudentGradesBySchoolSubject(student.Id, SchoolSubjects.Mathematics)); 
                    }
                   
                    break;
                case SchoolSubjects.Physics:
                    if (gradeRepository.GetStudentGradesBySchoolSubject(student.Id, SchoolSubjects.Physics).Count == 0) { Console.WriteLine("The grade point average is 0 because the student does not yet have grades in the subject."); }
                    else
                    {
                        Console.WriteLine("\nThe average physics grade is:");
                        PrintSubjectAverage(gradeRepository.GetStudentGradesBySchoolSubject(student.Id, SchoolSubjects.Physics));
                    }
                    
                    break;
                case SchoolSubjects.Religion:
                    if (gradeRepository.GetStudentGradesBySchoolSubject(student.Id, SchoolSubjects.Religion).Count == 0) { Console.WriteLine("The grade point average is 0 because the student does not yet have grades in the subject."); }
                    else
                    {
                        Console.WriteLine("\nThe average religious grade is:");
                        PrintSubjectAverage(gradeRepository.GetStudentGradesBySchoolSubject(student.Id, SchoolSubjects.Religion));
                    }
                        
                    break;
                default:
                    Console.WriteLine("There is no such school subject in our timetable.");
                    break;
            }
        }

        public void AddGrade(int studentId, SchoolSubjects subject)
        {
            double[] ratings = { 1, 1.5D, 2, 2.5D, 3, 3.5D, 4, 4.5D, 5, 5.5D, 6 };

            GradeType testType = ChooseTestType();

            PrintPossibleSchoolGrades(ratings);

            Console.Write("\nDear user, enter the rating you want to add: ");
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double number))
                {
                    if (ratings.Contains(number))
                    {
                        int gradeID = gradeRepository.GetUniqueGradeId();
                        IGrade grade = new Grade(gradeID, studentId, subject, number, testType);
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
        
        private void PrintSubjectAverage(List<Grade> grades)
        {
            int index = 0;
            int totalCount = grades.Count;
            List<double> gradeAVG = new List<double>();

            if (totalCount == 0) Console.WriteLine("\nYour list is empty, You add the first item to your list.");
            else
            {
                foreach (Grade grade in grades)
                {
                    gradeAVG.Add(grade.Value);
                }
                Console.WriteLine(degree.CalculationOfAverageDegree(gradeAVG));
                Console.WriteLine("");
            }       
        }

        private void GradeTypePrintout()
        {
            Console.WriteLine("\nWhat type of grade will be given: ");
            Console.WriteLine("1 - Test.");
            Console.WriteLine("2 - Homework.");
            Console.WriteLine("3 - Quiz.");
        }
        public GradeType ChooseTestType()
        {
            GradeTypePrintout();

            while (true)
            {
                switch (verifier.GetValidOptionNumber())
                {
                    case (int)GradeType.Test:
                        return GradeType.Test;
                    case (int)GradeType.Homework:
                        return GradeType.Homework;
                    case (int)GradeType.Quiz:
                        return GradeType.Quiz;
                    default:
                        Console.WriteLine("\nThe given number must equal 1, 2 or 3. Try again.");
                        break;
                }
            }
        }
    }
}
