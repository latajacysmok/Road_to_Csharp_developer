using SchoolData;

namespace Infrastructure
{
    public class Menu
    {
        Option option = new Option();
        Verifier verifier = new Verifier();       
        AttendanceList attendanceList = new AttendanceList();
        StudentRepository studentRepository = new StudentRepository();
        TeachersSchoolSubjectDiary teachersDiary = new TeachersSchoolSubjectDiary();
        Time time = new Time();

        public void GetSelectionOfOptionsFromMenu()
        {        
            int choice;
            time.GetDate();

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
                        int id = option.GetUniqueStudentId();
                        Student student = new Student(id, name, lastName, educationYear);
                        studentRepository.AddStudent(student);
                        break;
                    case 2:
                        student = attendanceList.SelectStudent();
                        if (student == null) break;
                        else teachersDiary.ChoiceOfSchoolSubject(student);
                        break;
                    case 3:
                        student = attendanceList.SelectStudent();
                        if (student == null) break;
                        else teachersDiary.ShowSchoolSubjects(student);
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
