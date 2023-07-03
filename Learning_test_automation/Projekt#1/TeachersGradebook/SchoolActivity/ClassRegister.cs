using SchoolData;
using SchoolPencilCase;

namespace SchoolActivity
{
    public class ClassRegister
    {
        SchoolGradebook schoolGradebook = new SchoolGradebook();
        SchoolSubjects schoolSubject = new SchoolSubjects();

        public int id;
        public SchoolSubjects subject;
        public double number;

        public void ShowSchoolSubjects(IStudent student, Verifier verifier)
        {
            GetListAvailableSubjects();
            schoolSubject = GetSchoolSubject(verifier);
            schoolGradebook.ShowGrade(schoolSubject, student);
        }
        public void ShowSchoolSubjects(IStudent student, Verifier verifier, bool avg)
        {
            GetListAvailableSubjects();
            schoolSubject = GetSchoolSubject(verifier);
            schoolGradebook.ShowAverageGrade(schoolSubject, student);
        }

        private SchoolSubjects GetSchoolSubject(Verifier verifier)
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

        public void ChoiceOfSchoolSubject(IStudent student, Verifier verifier)
        {
            GetListAvailableSubjects();
            schoolSubject = GetSchoolSubject(verifier);

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

        public void GetListAvailableSubjects()
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
