using SchoolData;

namespace Infrastructure
{
    public class Menu
    {
        Option option = new Option();
        Verifier verifier = new Verifier();        
        SchoolGradeWizard schoolGradeWizard = new SchoolGradeWizard();
        StudentList listOperation = new StudentList();


        public void GetSelectionOfOptionsFromMenu()
        {        
            int choice;
            
            while (true)
            {
                PrintMenu();

                choice = verifier.GetValidOptionNumber();

                switch (choice)
                {
                    case 1:
                        Student student = new Student();
                        listOperation.AddingStudentToList(student);
                        break;
                    case 2:
                        schoolGradeWizard.AddGrade(listOperation.studentsList);
                        break;
                    case 3:
                        schoolGradeWizard.ShowGrade(listOperation.studentsList);
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
