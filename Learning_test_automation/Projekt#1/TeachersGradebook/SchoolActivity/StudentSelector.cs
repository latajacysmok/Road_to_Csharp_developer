using SchoolData;
using SchoolEquipment;


namespace SchoolActivity
{
    public class StudentSelector
    {
        StudentRepository studentRepository = new StudentRepository();
        List<IStudent> students = StudentRepository.students;

        public IStudent SelectStudent(Verifier verifier, Option option)
        {         
            if (verifier.IsNullOrEmpty(students))
            {
                Console.WriteLine("Your list is empty, add an item to it before displaying the list.");
                return null;
            }
            else
            {
                return SelectStudentFromAvailableStudents(option, verifier);
            }           
        }

        private IStudent SelectStudentFromAvailableStudents(Option option, Verifier verifier)
        {
            GetListAvailableStudents();

            int id = option.GetID(verifier);
            return studentRepository.GetStudent(id);
        }

        private void GetListAvailableStudents()
        {
            Console.WriteLine("\nHere is a list of our students: ");

            Console.Write(string.Join("\n" ,students));

            Console.WriteLine("");
        }
    }
}
