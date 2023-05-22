using SchoolData;

namespace TeachersRoom
{
    public class TeachersDiary
    {
        private int Id { get; set; }

        SubjectDegree subjectDegree = new SubjectDegree();

        public List<double> mathGrades = new List<double>();
        public List<double> physicsGrades = new List<double>();
        public List<double> religionGrades = new List<double>();

        public TeachersDiary(int id)
        {
            Id = id;
        }

        public void AddingGrades(List<double> schoolSubjects)
        {
            Console.WriteLine("\nList of school grades to choose from: ");
            foreach (double grade in subjectDegree.ratings)
            {
                Console.Write(grade + " ");
            }

            Console.Write("\nDear user, enter the rating you want to add: ");
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double number))
                {
                    if (subjectDegree.ratings.Contains(number))
                    {
                        schoolSubjects.Add(number);
                        break;
                    }
                    else Console.WriteLine("There is no such school grade.");
                }
                else Console.Write("You didn't provide a number.");
            }       
        }
    }
}
