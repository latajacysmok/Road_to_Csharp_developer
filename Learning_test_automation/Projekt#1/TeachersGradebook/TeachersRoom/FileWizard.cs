using SchoolData;

namespace Infrastructure
{
    public class FileWizard
    {    

        public void SaveDataToFile(string uniqueName, string createText)
        {
            //string dir = @"C:\Users\lemk\Desktop\TeachersGradebook";
            string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TeachersGradebook");

            DirectoryCreation(dir);

            string fileName = $"{dir}\\{uniqueName}.txt";
            ListFiles(dir);
            
            using (FileStream fileStream = FileCreation(fileName))
            {
                if (!File.Exists(fileName))
                {
                    Console.WriteLine($"The file '{uniqueName}' was not created.");
                }
                else
                {
                    fileStream.Seek(0, SeekOrigin.End);
                    using (StreamWriter informationForOneObjectToWrite = new StreamWriter(fileStream))
                    {
                        informationForOneObjectToWrite.WriteLine(createText);
                    }
                }
            }

            ReadFile(fileName);
        }

        private void DirectoryCreation(string dir)
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
                using (StreamReader fileContent = new StreamReader(fileName))
                {
                    if (fileContent.Peek() >= 0)
                    {
                        int counter = 0;
                        string collectionOfInformationAboutSingleObject;

                        Console.WriteLine($"File content: ");

                        while ((collectionOfInformationAboutSingleObject = fileContent.ReadLine()) != null)
                        {
                            Console.WriteLine(collectionOfInformationAboutSingleObject);
                            counter++;
                        }
                        fileContent.Close();
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
