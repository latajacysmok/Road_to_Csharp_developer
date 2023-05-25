namespace Infrastructure
{
    public class StudentList
    {
        public List<Student> studentsList = new List<Student>();
        public void AddingStudentToList(Student student)
        {
            studentsList.Add(student);
        }
    }
}
