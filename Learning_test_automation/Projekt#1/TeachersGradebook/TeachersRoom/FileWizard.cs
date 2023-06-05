using SchoolData;

namespace Infrastructure
{
    public class FileWizard
    {
        public void FileCreation(object obj)
        {
            StudentRepository studentRepository = new StudentRepository();
            GradeRepository gradeRepository = new GradeRepository();

            var dir = @"C:\Users\lemk\Desktop\TeachersGradebook";
            string uniqName = string.Empty;
            string createText = string.Empty;

            if (obj is Student)
            {
                Student student = (Student)obj;
                uniqName = student.GetCreationTime;
                createText = studentRepository.ToString();
            }
            else if (obj is Grade)
            {
                Grade grade = (Grade)obj;
                uniqName = grade.GetCreationTime;
                createText = grade.ToString();//gradeRepository czemu jak uzywam tego to createText = ""???
            }

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            string fileName = $"{dir}\\{uniqName}.txt";
            using (FileStream fileStream = File.Create(fileName))
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
        }
    }
}
