using SchoolData;

namespace Infrastructure
{
    public class StudentSelector
    {
        Option option = new Option();
        Verifier verifier = new Verifier();
        StudentRepository studentRepository = new StudentRepository();
        List<IStudent> students = StudentRepository.students;

        public IStudent SelectStudent()
        {         
            if (verifier.IsNullOrEmpty(students))
            {
                Console.WriteLine("Your list is empty, add an item to it before displaying the list.");
                return null;
            }
            else
            {
                return SelectStudentFromAvailableStudents();
            }           
        }

        private IStudent SelectStudentFromAvailableStudents()
        {
            ListAvailableStudents();

            int id = option.GetID();
            return studentRepository.GetStudent(id);
        }

        private void ListAvailableStudents()
        {
            Console.WriteLine("\nHere is a list of our students: ");

            foreach (IStudent student in students)
            {
                Console.WriteLine(student.ToString());
            }
            Console.WriteLine("");
        }
    }
}
