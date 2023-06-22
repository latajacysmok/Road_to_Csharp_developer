using SchoolData;

namespace Infrastructure
{
    public class GradeRepository
    {
        public static List<IGrade> grades = new List<IGrade>();
        GradeFile gradeFile = new GradeFile();

        public void AddGrade(IGrade grade)
        {
            grades.Add(grade);

            gradeFile.GradeFileCreate(grade.ToString());
        }

        public Grade GetGrade(int id)
        {
            foreach (Grade grade in grades)
            {
                if (grade.Id.Equals(id)) return grade;
            }
            throw new NullReferenceException("We do not have a grade with this id.");
        }

        public List<IGrade> GetAllGrades()
        {
            return grades;
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

        public override string ToString()
        {
            return string.Join("", grades.Select(grade => $"School subject: {grade.SchoolSubject}; Grade value: {grade.Value}; Student id number: {grade.StudentID};"));
        }
    }
}
