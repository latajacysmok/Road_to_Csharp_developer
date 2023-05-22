using SchoolData;

namespace TeachersRoom
{
    public class Menu
    {
        Option option = new Option();
        private List<StudentCreator> studentsList = new List<StudentCreator>();
        SchoolGradeWizard schoolGradeWizard = new SchoolGradeWizard();


        public void ListingPossibilities()
        {        
            int choice;
            
            while (true)
            {
                Console.WriteLine("\n\t***Menu***");
                Console.WriteLine("1 - Add a student");
                Console.WriteLine("2 - Add a degree");
                Console.WriteLine("3 - View ratings.");
                Console.WriteLine("4 - Finish the program\n");

                choice = option.ValidateOptionNumber();

                switch (choice)
                {
                    case 1:
                        StudentCreator studentCreator = new StudentCreator();
                        studentsList.Add(studentCreator);
                        break;
                    case 2:
                        schoolGradeWizard.AddGrade(studentsList);
                        break;
                    case 3:
                        schoolGradeWizard.ShowGrade(studentsList);
                        break; 
                    case 4:
                        option.LeaveProgramme();
                        break;                       
                }
            }
        }
    }
}
