using SchoolActivity;
using SchoolData;
using SchoolEquipment;
using TestObjects;

namespace BoardConsoleApp
{
    public class MenuRepository
    {
        StudentSelector studentSelector = new StudentSelector();
        GradeSheetPrinter teachersDiary = new GradeSheetPrinter();
        StudentRepository studentRepository = new StudentRepository();
        StudentFile studentFile = new StudentFile();
        IStudent student;

        public MenuRepository()
        {
            GradeFile gradeFile = new GradeFile();
            
            studentFile.AddStudentParametersFromFileToList();
            gradeFile.AddGradeParametersFromFileToList();

        }
        public void AddStudentInMenu(Option option, Verifier verifier)
        {
            string name = option.GetName();
            string lastName = option.GetLastName();
            int educationYear = option.GetGrade(verifier);
            int id = studentRepository.GetUniqueStudentId(verifier);
            IStudent student = new Student(id, name, lastName, educationYear);
            studentRepository.AddStudent(student, studentFile);
        }
        public void AddDegreeInMenu(Option option, Verifier verifier)
        {
            student = studentSelector.SelectStudent(verifier, option);
            if (student is null){ Console.WriteLine("You currently don't have any students, so you can't add a grade."); }
            else { teachersDiary.ChoiceOfSchoolSubject(student, verifier); }         
        }
        public void ViewRatingsInMenu(Option option, Verifier verifier)
        {
            student = studentSelector.SelectStudent(verifier, option);
            if (student is null) { Console.WriteLine("You currently don't have any students, so you can't add a grade."); }
            else { teachersDiary.ShowSchoolSubjects(student, verifier); }       
        }
        public void AverageOfGradesInGivenSubjectInMenu(Option option, Verifier verifier)
        {
            bool avg = true;
            student = studentSelector.SelectStudent(verifier, option);          
            if (student is null) { Console.WriteLine("You currently don't have any students, so you can't add a grade."); }
            else { teachersDiary.ShowSchoolSubjects(student, verifier, avg); }
        }
        
        public void SerializeDeserializeStudentInMenu()
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
        }    
    }
}
