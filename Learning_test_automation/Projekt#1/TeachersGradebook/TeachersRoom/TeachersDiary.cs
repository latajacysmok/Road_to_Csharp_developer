namespace Infrastructure
{
    public class TeachersDiary
    {
        public List<double> mathGrades = new List<double>();
        public List<double> physicsGrades = new List<double>();
        public List<double> religionGrades = new List<double>();

        public void AddGradeToSchoolSubjects(List<double> schoolSubjects)
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
                        schoolSubjects.Add(number);
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
