using SchoolData;
using SchoolEquipment;
using FileManager;

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
                id = grades.Max(grade => grade.Id);
                return id + 1;
            }
        }

        public List<IGrade> GetStudentGradesBySchoolSubject(int idSearchedStudent, SchoolSubjects schoolSubject)
        {
            return grades.Where(grade => grade.StudentID.Equals(idSearchedStudent) && grade.SchoolSubject == schoolSubject).ToList();
        }
    }
}
