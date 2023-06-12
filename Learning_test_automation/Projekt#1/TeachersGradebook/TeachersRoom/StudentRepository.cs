using SchoolData;

namespace Infrastructure
{
    public class StudentRepository
    {
        private static List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);

            FileWizard fileWizard = new FileWizard();
            fileWizard.FileCreation(student);
        }

        public Student GetStudent(int id)
        {
            foreach(Student student in students) 
            {
                if (student.Id.Equals(id)) return student;
            }
            throw new NullReferenceException("We do not have a student with this id.");
        }

        public List<Student> GetAllStudents()
        { 
            return students; 
        }

        public override string ToString()
        {
            return string.Join(", ", students.Select(student => $"Name: {student.Name}; Lastname: {student.LastName}; ID number: {student.Id}; \n"));
        }
    }
}
