using SchoolData;

namespace Infrastructure
{
    public class GradeFile
    {
        FileWizard fileWizard = new FileWizard();

        private SchoolSubjects schoolSubject;
        private double gradeValue;
        private int studentId;
        private int gradeID;

        public void GradeFileCreate(string createText)
        {
            string uniqName = "Grade";
            fileWizard.SaveDataToFile(uniqName, createText);
        }

        public void AddGradeParametersFromFileToList()
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TeachersGradebook", "Grade.txt");

            if (File.Exists(fileName))
            {
                using (StreamReader streamReader = new StreamReader(fileName))
                {
                    if (streamReader.Peek() >= 0)
                    {
                        string fileContent = streamReader.ReadToEnd();

                        string[] grades = fileContent.Split('\n');

                        ExtractingGradeInformationFromFile(grades);
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

        private void ExtractingGradeInformationFromFile(string[] grades)
        {
            foreach (var lineWithGradeDate in grades)
            {
                string[] fields = lineWithGradeDate.Split(';');

                foreach (string field in fields)
                {
                    GradeData(field);
                }
                IGrade grade = new Grade(gradeID, studentId, schoolSubject, gradeValue);
                GradeRepository.grades.Add(grade);
            }
        }

        private void GradeData(string field)
        {
            const string searchedPhraseSchoolSubject = "School subject:";
            const string searchedPhrasegradeValue = "Grade value:";
            const string searchedPhraseIdNumber = "ID number:";
            const string searchedPhraseStudentIdNumber = "Student id number:";


            if (field.Trim().StartsWith(searchedPhraseSchoolSubject))
            {
                Enum.TryParse(field.Trim().Substring(searchedPhraseSchoolSubject.Length).Trim(), out schoolSubject);
            }

            if (field.Trim().StartsWith(searchedPhrasegradeValue))
            {
                double.TryParse(field.Trim().Substring(searchedPhrasegradeValue.Length).Trim(), out gradeValue);
            }

            if (field.Trim().StartsWith(searchedPhraseIdNumber))
            {
                int.TryParse(field.Trim().Substring(searchedPhraseIdNumber.Length).Trim(), out gradeID);
            }

            if (field.Trim().StartsWith(searchedPhraseStudentIdNumber))
            {
                int.TryParse(field.Trim().Substring(searchedPhraseStudentIdNumber.Length).Trim(), out studentId);
            }
        }
    }
}
