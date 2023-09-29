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

        public IStudent GetStudent(int id)
        {
            return students.FirstOrDefault(student => student.Id.Equals(id));
        }

        public int GetUniqueStudentId(Verifier verifier)
        {
            var students = GetAllStudents();

            if (verifier.IsNullOrEmpty(students))
            {
                Console.WriteLine("\nYour list is empty, You add the first item to your list.");
                return 1;
            }
            else
            {
                return students.Max(student => student.Id) + 1;
            }
        }

        public List<IStudent> GetAllStudents()
        { 
            return students; 
        }
    }
}
