using SchoolData;
using SchoolPencilCase;

namespace SchoolActivity
{
    public class GradeRepository
    {
        public static List<IGrade> grades = new List<IGrade>();
        GradeFile gradeFile = new GradeFile();
        Verifier verifier = new Verifier();
        public void AddGrade(IGrade grade)
        {          
            grades.Add(grade);

            gradeFile.GradeFileCreate(grade.ToString());
        }

        private List<IGrade> GetAllGrades()
        {
            return grades;
        }

        public int GetUniqueGradeId()
        {
            List<IGrade> grades = GetAllGrades();
            int id = 0;

            if (verifier.IsNullOrEmpty(grades))
            {
                Console.WriteLine("\nYour list is empty, You add the first item to your list.");
                return 1;
            }
            else
            {
                foreach (Grade grade in grades)
                {
                    if (grade.Id > id) id = grade.Id;
                }
                return id + 1;
            }
        }

        public List<Grade> GetGradeStudentsSubject(int idSearchedStudent, SchoolSubjects schoolSubject)
        {
            List<Grade> studentGrades = new List<Grade>();
            foreach (Grade grade in grades)
            {
                if (grade.StudentID.Equals(idSearchedStudent) && grade.SchoolSubject == schoolSubject) studentGrades.Add(grade);
            }
            return studentGrades;
        }
    }
}
