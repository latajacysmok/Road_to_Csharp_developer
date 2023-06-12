using SchoolData;

namespace Infrastructure
{
    public class GradeRepository
    {
        private static List<Grade> grades = new List<Grade>();

        public void AddGrade(Grade grade)
        {
            grades.Add(grade);

            FileWizard fileWizard = new FileWizard();
            fileWizard.FileCreation(grade);
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
            return string.Join(", ", grades.Select(grade => $"School subject: {grade.SchoolSubject}; Grade value: {grade.Value}; Student id number: {grade.StudentID};\n"));
        }
    }
}
