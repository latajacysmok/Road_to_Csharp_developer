using SchoolData;

namespace Infrastructure
{
    public class StudentFile
    {
        FileWizard fileWizard = new FileWizard();
        
        public void StudentFileCreation(string createText)
        {
            string uniqName = "Student";
            fileWizard.SaveDataToFile(uniqName, createText);
        }

        public void AddStudentParametersFromFileToList()
        {
            string fileName = @"C:\Users\lemk\Desktop\TeachersGradebook\Student.txt";

            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    if (sr.Peek() >= 0)
                    {
                        string fileContent = sr.ReadToEnd();

                        string[] allStudentsFromFile = fileContent.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                        string name          = default;
                        string lastname      = default;
                        int    id            = default;
                        int    educationYear = default;

                        foreach (var lineWithStudentDate in allStudentsFromFile)
                        {
                            string[] fields = lineWithStudentDate.Split(';');

                            foreach (string field in fields)
                            {
                                if (field.Trim().StartsWith("Name:"))
                                {
                                    name = field.Trim().Substring("Name:".Length).Trim();
                                }

                                if (field.Trim().StartsWith("Lastname:"))
                                {
                                    lastname = field.Trim().Substring("Lastname:".Length).Trim();
                                }

                                if (field.Trim().StartsWith("ID number:"))
                                {
                                    int.TryParse(field.Trim().Substring("ID number:".Length).Trim(), out id);
                                }

                                if (field.Trim().StartsWith("Education year:"))
                                {
                                    int.TryParse(field.Trim().Substring("Education year:".Length).Trim(), out educationYear);
                                }
                            }
                            IStudent student = new Student(id, name, lastname, educationYear);
                            StudentRepository.students.Add(student);
                        }

                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine($"File {fileName} is EMPTY!");
                    }

                    sr.Close();
                }
            }
            else
            {
                Console.WriteLine($"File {fileName} does NOT EXIST!");
            }
        }
    }
}
