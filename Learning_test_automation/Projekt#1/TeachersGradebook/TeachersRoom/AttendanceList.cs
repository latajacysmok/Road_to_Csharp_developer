using SchoolData;

namespace Infrastructure
{
    public class AttendanceList
    {
        Option option = new Option();
        Verifier verifier = new Verifier();
        StudentRepository studentRepository = new StudentRepository();

        public Student SelectStudent()
        {
            List<IStudent> students = studentRepository.GetAllStudents();
            if (verifier.IsNullOrEmpty(students))
            {
                Console.WriteLine("Your list is empty, add an item to it before displaying the list.");
                return null;
            }
            else
            {
                ListAvailableStudents();

                int id = option.GetID();
                return studentRepository.GetStudent(id);
            }           
        }

        private void ListAvailableStudents()
        {
            List<IStudent> students = studentRepository.GetAllStudents();
            Console.WriteLine("\nHere is a list of our students: ");

            foreach (IStudent student in students)
            {
                Console.WriteLine(student.ToString());
            }
            Console.WriteLine("");
        }
    }
}
