using SchoolData;

namespace Infrastructure
{
    public class TeachersSchoolSubjectDiary
    {
        SchoolGradebook schoolGradebook = new SchoolGradebook();
        SchoolSubjects schoolSubject = new SchoolSubjects();
        Verifier verifier = new Verifier();

        public int id;
        public SchoolSubjects subject;
        public double number;

        public void ShowSchoolSubjects(Student student)
        {
            ListAvailableSubjects();
            schoolSubject = GetSchoolSubject();
            schoolGradebook.ShowGrade(schoolSubject, student);
        }

        public SchoolSubjects GetSchoolSubject()
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

        public void ChoiceOfSchoolSubject(Student student)
        {
            ListAvailableSubjects();
            schoolSubject = GetSchoolSubject();

            switch (schoolSubject)
            {
                case SchoolSubjects.Mathematics:
                    schoolGradebook.AddGrade(student.Id, SchoolSubjects.Mathematics);
                    break;
                case SchoolSubjects.Physics:
                    schoolGradebook.AddGrade(student.Id, SchoolSubjects.Physics);
                    break;
                case SchoolSubjects.Religion:
                    schoolGradebook.AddGrade(student.Id, SchoolSubjects.Religion);
                    break;
                default:
                    Console.WriteLine("There is no such school subject in our timetable.");
                    break;
            }
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
