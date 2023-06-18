using SchoolData;

namespace Infrastructure
{
    public class FileWizard
    {    

        public void SaveDataToFile(string uniqName, string createText)
        {
            string dir = @"C:\Users\lemk\Desktop\TeachersGradebook";
            FolderDirectoryCreation(dir);

            string fileName = $"{dir}\\{uniqName}.txt";
            ListFiles(dir);
            
            using (FileStream fileStream = FileCreation(fileName))
            {
                if (!File.Exists(fileName))
                {
                    Console.WriteLine($"The file '{uniqName}' was not created.");
                }
                else
                {
                    fileStream.Seek(0, SeekOrigin.End);
                    using (StreamWriter sw = new StreamWriter(fileStream))
                    {
                        sw.WriteLine(createText);
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
            if (!File.Exists(fileName))
            {
                return File.Create(fileName);
            }

            return File.OpenWrite(fileName);
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
        }

        private void ListFiles(string dir)
        {
            string[] files = Directory.GetFiles(dir);
            if (files.Length == 0) Console.WriteLine("The folder is empty. Now the first file will be created.");
            else
            {
                Console.WriteLine($"List of files in the folder({dir}):");

                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file);
                    string fileExtension = Path.GetExtension(file);

                    Console.WriteLine($"- {fileNameWithoutExtension}{fileExtension}\n");
                }
            }    
        }
    }
}
