using SchoolData;

namespace Infrastructure
{
    public class StudentRepository
    {
        public static List<IStudent> students = new List<IStudent>();
        StudentFile studentFile = new StudentFile();

        public void AddStudent(IStudent student)
        {      
            students.Add(student);

            studentFile.StudentFileCreation(student.ToString());
        }

        public Student GetStudent(int id)
        {
            foreach(Student student in students) 
            {
                if (student.Id.Equals(id)) return student;
            }
            throw new NullReferenceException("We do not have a student with this id.");
        }

        public List<IStudent> GetAllStudents()
        { 
            return students; 
        }

        public override string ToString()
        {
            return string.Join("", students.Select(student => $"Name: {student.Name}; Lastname: {student.LastName}; ID number: {student.Id}; Education year: {student.EducationYear}"));
        }
    }
}
