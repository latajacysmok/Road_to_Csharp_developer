using SchoolData;

namespace Infrastructure
{
    public class TeachersDiary
    {
        public List<Grades> mathGrades = new List<Grades>();
        public List<Grades> physicsGrades = new List<Grades>();
        public List<Grades> religionGrades = new List<Grades>();

        public void AddGradeToSchoolSubjects(List<Grades> schoolSubjects, int id)
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
                        Grades grades = new Grades(id, number, schoolSubjects);
                        schoolSubjects.Add(grades);
                        break;
                    }
                    else Console.WriteLine("There is no such school grade.");
                }
                else Console.Write("You didn't provide a number.");
            }       
        }

        public void PrintPossibleSchoolGrades(double[] ratings)
        {
            Console.WriteLine("\nList of school grades to choose from: ");
            foreach (double grade in ratings)
            {
                Console.Write(grade + " ");
            }
        }
    }
}
