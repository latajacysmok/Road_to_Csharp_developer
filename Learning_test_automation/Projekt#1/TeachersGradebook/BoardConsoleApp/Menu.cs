using SchoolData;
using SchoolActivity;
using SchoolEquipment;
using FileManager;
using TestObjects;

namespace BoardConsoleApp
{
    public class Menu
    {
        Option option = new Option();
        Verifier verifier = new Verifier();
        Time time = new Time();
        MenuRepository menuRepository = new MenuRepository();

        public void StartMenu()
        {
            time.GetDate();      

            while (true)
            {
                // Do zabawy serializacją
                SerializeStudent serializeStudent = new SerializeStudent();
                serializeStudent.PrintOutPersonJson();

                DeserializeStudent deserializeStudent = new DeserializeStudent();
                Person deserializedPerson = deserializeStudent.DeserializePersonFromJson();

                if (deserializedPerson != null)
                {
                    Console.WriteLine("Deserialized Person:");
                    Console.WriteLine($"Name: {deserializedPerson.Name}");
                    Console.WriteLine($"Last Name: {deserializedPerson.LastName}");
                    Console.WriteLine($"Education Year: {deserializedPerson.EducationYear}");
                    Console.WriteLine($"Id: {deserializedPerson.Id}");
                }

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
                    menuRepository.AddStudentInMenu(option, verifier);
                    break;
                case MenuOption.AddDegree:
                    menuRepository.AddDegreeInMenu(option, verifier);
                    break;
                case MenuOption.ViewRatings:
                    menuRepository.ViewRatingsInMenu(option, verifier);
                    break;
                case MenuOption.AverageOfGradesInGivenSubject:
                    menuRepository.AverageOfGradesInGivenSubjectInMenu(option, verifier);
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
