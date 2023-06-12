using SchoolData;
using System.IO;

namespace Infrastructure
{
    public class FileWizard
    {
        private string uniqName = string.Empty;
        private string createText = string.Empty;
        public void FileCreation(Student student)
        {
            StudentRepository studentRepository = new StudentRepository();
            uniqName = "Student"; //student.CreationTime.ToString("'Student_'HH'-'mm'-'ss'_'dd'-'MM'-'yyyy");
            createText = studentRepository.ToString();
            SaveDataToFile(uniqName, createText);
        }

        public void FileCreation(Grade grade)
        {
            GradeRepository gradeRepository = new GradeRepository();
            uniqName = "Grade"; //grade.CreationTime.ToString("'Grade_'HH'-'mm'-'ss'_'dd'-'MM'-'yyyy");
            createText = gradeRepository.ToString();
            SaveDataToFile(uniqName, createText);
        }
        private void SaveDataToFile(string uniqName, string createText)
        {
            string dir = @"C:\Users\lemk\Desktop\TeachersGradebook";
            FolderDirectoryCreation(dir);

            string fileName = $"{dir}\\{uniqName}.txt";
            ListFiles(fileName);
            
            using (FileStream fileStream = FileCreation(fileName))
            {
                if (!File.Exists(fileName))
                {
                    Console.WriteLine($"The file '{uniqName}' was not created.");
                }
                else
                {
                        using (StreamWriter sw = new StreamWriter(fileStream))
                    {
                        sw.Write(createText);
                    }
                }
            }

            ReadFile(fileName);
        }

        private void FolderDirectoryCreation(string dir)
        {
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        }

        private FileStream FileCreation(string fileName)
        {
            if (!Directory.Exists(fileName)) return File.Create(fileName);
            else return null;         
        }

        private void ReadFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    if (sr.Peek() >= 0)
                    {
                        int counter = 0;
                        string ln;

                        Console.WriteLine($"File content: ");

                        while ((ln = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(ln);
                            counter++;
                        }
                        sr.Close();
                        Console.WriteLine($"File has {counter} lines.");
                    }
                    else Console.WriteLine($"File {fileName} is EMPTY!");
                }
            }
            else Console.WriteLine($"File {fileName} NOT EXIST!");
            //ReadingStudentParameters(fileName);
        }

        private void ListFiles(string dir)
        {
            if (!Directory.Exists(dir)) Console.WriteLine("The folder is empty. Now the first file will be created.");
            else
            {
                string[] files = Directory.GetFiles(dir);

                Console.WriteLine($"List of files in the folder({dir}):");

                foreach (string file in files)
                {
                    Console.WriteLine($"- {file}");
                }
            }    
        }

        public void ReadingStudentParameters(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    if (sr.Peek() >= 0)
                    {
                        string fileContent = sr.ReadToEnd();

                        string[] fields = fileContent.Split(';');

                        string name = "";
                        string lastname = "";
                        string id = "";

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
                                id = field.Trim().Substring("ID number:".Length).Trim();
                            }
                        }

                        Console.WriteLine($"Name: {name}");
                        Console.WriteLine($"Lastname: {lastname}");
                        Console.WriteLine($"ID number: {id}");
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

        public void ReadingGradeParameters(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    if (sr.Peek() >= 0)
                    {
                        string fileContent = sr.ReadToEnd();

                        string[] fields = fileContent.Split(';');

                        string schoolSubject = "";
                        string gradeValue = "";
                        string studentId = "";

                        foreach (string field in fields)
                        {
                            if (field.Trim().StartsWith("School subject:"))
                            {
                                schoolSubject = field.Trim().Substring("School subject:".Length).Trim();
                            }

                            if (field.Trim().StartsWith("Grade value:"))
                            {
                                gradeValue = field.Trim().Substring("Lastname:".Length).Trim();
                            }

                            if (field.Trim().StartsWith("Student id number:"))
                            {
                                studentId = field.Trim().Substring("Student id number:".Length).Trim();
                            }
                        }

                        Console.WriteLine($"Name: {schoolSubject}");
                        Console.WriteLine($"Lastname: {gradeValue}");
                        Console.WriteLine($"ID number: {studentId}");
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
