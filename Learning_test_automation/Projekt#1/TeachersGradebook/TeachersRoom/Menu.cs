using SchoolData;
using System.Xml.Linq;

namespace Infrastructure
{
    public class Menu
    {
        Option option = new Option();// Ogarnąć sobie w jaki sposób połączyć oceny ze studentami i jakoś wyświetlać napisz metode do tego
        Verifier verifier = new Verifier();       
        AttendanceList attendanceList = new AttendanceList();
        StudentRepository studentRepository = new StudentRepository();
        TeachersSchoolSubjectDiary teachersDiary = new TeachersSchoolSubjectDiary();

        public void GetSelectionOfOptionsFromMenu()
        {        
            int choice;
            List<Student> studentsList = studentRepository.GetAllStudents();

            while (true)
            {
                PrintMenu();

                choice = verifier.GetValidOptionNumber();

                switch (choice)
                {
                    case 1:
                        string name = option.GetName();
                        string lastName = option.GetLastName();
                        int educationYear = option.GetGrade();
                        int id = option.GetUniqueStudentId(studentsList);
                        Student student = new Student(id, name, lastName, educationYear);
                        studentRepository.AddStudent(student);
                        break;
                    case 2:
                        teachersDiary.ChoiceOfSchoolSubject(attendanceList.SelectingStuden(studentsList));
                        break;
                    case 3:
                        teachersDiary.ShowSchoolSubjects(attendanceList.SelectingStuden(studentsList));
                        break; 
                    case 4:
                        option.LeaveProgramme();
                        break;                       
                }
            }
        }

        public void PrintMenu()
        {
            Console.WriteLine("\n\t***Menu***");
            Console.WriteLine("1 - Add a student");
            Console.WriteLine("2 - Add a degree");
            Console.WriteLine("3 - View ratings.");
            Console.WriteLine("4 - Finish the program\n");
        }

    }
}
