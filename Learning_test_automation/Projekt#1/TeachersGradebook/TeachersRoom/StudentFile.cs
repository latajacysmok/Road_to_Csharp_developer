using SchoolData;

namespace Infrastructure
{
    public class StudentFile
    {
        FileWizard fileWizard = new FileWizard();

        private string name;
        private string lastname;
        private int id;
        private int educationYear;

        public void StudentFileCreation(string createText)
        {
            string uniqName = "Student";
            fileWizard.SaveDataToFile(uniqName, createText);
        }

        public void AddStudentParametersFromFileToList()
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TeachersGradebook", "Student.txt");

            if (File.Exists(fileName))
            {
                using (StreamReader streamReader = new StreamReader(fileName))
                {
                    if (streamReader.Peek() >= 0)
                    {
                        string fileContent = streamReader.ReadToEnd();

                        string[] allStudentsFromFile = fileContent.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                        ExtractingStudentInformationFromFile(allStudentsFromFile);

                        streamReader.Close();
                    }
                    else
                    {
                        Console.WriteLine($"File {fileName} is EMPTY!");
                    }

                    streamReader.Close();
                }
            }
            else
            {
                Console.WriteLine($"File {fileName} does NOT EXIST!");
            }
        }

        private void ExtractingStudentInformationFromFile(string[] allStudentsFromFile)
        {
            foreach (var lineWithStudentDate in allStudentsFromFile)
            {
                string[] fields = lineWithStudentDate.Split(';');

                foreach (string field in fields)
                {
                    StudentData(field);
                }
                IStudent student = new Student(id, name, lastname, educationYear);
                StudentRepository.students.Add(student);
            }
        }

        private void StudentData(string field)
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
    }
}
