using SchoolData;

namespace Infrastructure
{
    public class GradeFile
    {
        FileWizard fileWizard = new FileWizard();

        public void GradeFileCreation(string createText)
        {
            string uniqName = "Grade";
            fileWizard.SaveDataToFile(uniqName, createText);
        }

        public void AddGradeParametersFromFileToList()
        {
            string fileName = @"C:\Users\lemk\Desktop\TeachersGradebook\Grade.txt";

            if (File.Exists(fileName))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    if (sr.Peek() >= 0)
                    {
                        string fileContent = sr.ReadToEnd();

                        string[] grades = fileContent.Split('\n');

                        SchoolSubjects schoolSubject = default;
                        double gradeValue    = default;
                        int studentId     = default;
                        int gradeID = default;

                        foreach (var lineWithGradeDate in grades)
                        {
                            string[] fields = lineWithGradeDate.Split(';');

                            foreach (string field in fields)
                            {
                                if (field.Trim().StartsWith("School subject:"))
                                {
                                    SchoolSubjects.TryParse(field.Trim().Substring("School subject:".Length).Trim(), out schoolSubject);
                                }

                                if (field.Trim().StartsWith("Grade value:"))
                                {
                                    double.TryParse(field.Trim().Substring("Grade value:".Length).Trim(), out gradeValue);
                                }

                                if (field.Trim().StartsWith("ID number:"))
                                {
                                    int.TryParse(field.Trim().Substring("ID number:".Length).Trim(), out gradeID);
                                }

                                if (field.Trim().StartsWith("Student id number:"))
                                {
                                    int.TryParse(field.Trim().Substring("Student id number".Length).Trim(), out studentId);
                                }
                            }
                            IGrade grade = new Grade(gradeID, studentId, schoolSubject, gradeValue);
                            GradeRepository.grades.Add(grade);
                        }
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
