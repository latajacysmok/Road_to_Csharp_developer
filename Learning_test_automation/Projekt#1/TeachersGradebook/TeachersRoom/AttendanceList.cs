namespace Infrastructure
{
    public class AttendanceList
    {
        Option option = new Option();
        Verifier verifier = new Verifier();
        StudentRepository studentRepository = new StudentRepository();

        public Student SelectingStuden(List<Student> studentsList)
        {
            if(verifier.IsNullOrEmpty(studentsList))
            {
                Console.WriteLine("Your list is empty, add an item to it before displaying the list.");
                return null;
            }
            else
            {
                ListAvailableStudents(studentsList);

                int id = option.GetID();
                return studentRepository.GetStudent(id);
            }           
        }

        private void ListAvailableStudents(List<Student> studentsList)
        {
            Console.WriteLine("\nHere is a list of our students: ");

            foreach (Student student in studentsList)
            {
                Console.WriteLine(student.ToString());
            }
            Console.WriteLine("");
        }
    }
}
