using SchoolData;
using SchoolEquipment;
using FileManager;

namespace SchoolActivity
{
    public class StudentRepository
    {
        public static List<IStudent> students = new List<IStudent>();

        public void AddStudent(IStudent student, StudentFile studentFile)
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

        public int GetUniqueStudentId(Verifier verifier)
        {
            var students = GetAllStudents();

            int id = 0;
            if (verifier.IsNullOrEmpty(students))
            {
                Console.WriteLine("\nYour list is empty, You add the first item to your list.");
                return 1;
            }
            else
            {
                foreach (Student student in students)
                {
                    if (student.Id > id) id = student.Id;
                }
                return id + 1;
            }
        }

        public List<IStudent> GetAllStudents()
        { 
            return students; 
        }
    }
}
