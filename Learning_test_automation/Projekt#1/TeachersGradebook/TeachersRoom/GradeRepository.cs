using SchoolData;

namespace Infrastructure
{
    public class GradeRepository
    {
        public double value;
        public int studentID;
        public int id;
        public string schoolSubject;

        private List<Grade> grades = new List<Grade>();

        public void AddGrade(Grade grade)
        {
            grades.Add(grade);
        }

        public Grade GetGrade(int id)
        {
            foreach (Grade grade in grades)
            {
                if (grade.Id.Equals(id)) return grade;
            }
            throw new NullReferenceException("We do not have a grade with this id.");
        }

        public List<Grade> GetAllGrades()
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
            return $"{value} for ID number: {id}";
        }
    }
}
