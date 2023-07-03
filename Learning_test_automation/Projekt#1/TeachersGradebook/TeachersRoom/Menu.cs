using SchoolData;
using SchoolActivity;
using SchoolPencilCase;

namespace Classroom
{
    public class Menu
    {
        Option option = new Option();
        Verifier verifier = new Verifier();       
        StudentSelector attendanceList = new StudentSelector();
        StudentRepository studentRepository = new StudentRepository();
        ClassRegister teachersDiary = new ClassRegister();
        StudentFile studentFile = new StudentFile();
        Time time = new Time();

        public void StartMenu()
        {        
            time.GetDate();
            
            GradeFile gradeFile = new GradeFile();

            studentFile.AddStudentParametersFromFileToList();
            gradeFile.AddGradeParametersFromFileToList();

            while (true)
            {
                PrintMenu();
                MenuOption menuOption = ChoiceOptionsFromMenu();
                RunOptionFromMenu(menuOption);
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine("\n\t***Menu***");
            Console.WriteLine("1 - Add a student.");
            Console.WriteLine("2 - Add a degree.");
            Console.WriteLine("3 - View ratings.");
            Console.WriteLine("4 - View the average grade in a given subject.");
            Console.WriteLine("5 - Finish the program.\n");
        }

        private void RunOptionFromMenu(MenuOption menuOption)
        {
            switch (menuOption)
                {
                    case MenuOption.AddStudent:
                        string name = option.GetName();
                        string lastName = option.GetLastName();
                        int educationYear = option.GetGrade(verifier);
                        int id = studentRepository.GetUniqueStudentId(verifier);
                        IStudent student = new Student(id, name, lastName, educationYear);
                        studentRepository.AddStudent(student, studentFile);
                        break;
                    case MenuOption.AddDegree:
                        student = attendanceList.SelectStudent(verifier, option);
                        if (student == null) break;
                        else teachersDiary.ChoiceOfSchoolSubject(student, verifier);
                        break;
                    case MenuOption.ViewRatings:
                        student = attendanceList.SelectStudent(verifier, option);
                        if (student == null) break;
                        else teachersDiary.ShowSchoolSubjects(student, verifier);
                        break;
                    case MenuOption.AverageOfGradesInGivenSubject:
                        bool avg = true;
                        student = attendanceList.SelectStudent(verifier, option);
                        if (student == null) break;
                        else teachersDiary.ShowSchoolSubjects(student, verifier, avg);
                        break;
                    case MenuOption.FinishProgram:
                        option.LeaveProgramme();
                        break;
                }
        }

        private MenuOption ChoiceOptionsFromMenu()
        {
            while (true)
            {
                switch (verifier.GetValidOptionNumber())
                {
                    case (int)MenuOption.AddStudent:
                        return MenuOption.AddStudent;
                    case (int)MenuOption.AddDegree:
                        return MenuOption.AddDegree;
                    case (int)MenuOption.ViewRatings:
                        return MenuOption.ViewRatings;
                    case (int)MenuOption.AverageOfGradesInGivenSubject:
                        return MenuOption.AverageOfGradesInGivenSubject;
                    case (int)MenuOption.FinishProgram:
                        return MenuOption.FinishProgram;
                    default:
                        Console.WriteLine("\nThe given number must equal 1, 2, 3, 4 or 5. Try again.");
                        break;
                }
            }
        }

    }
}
