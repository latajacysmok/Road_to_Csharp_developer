using Newtonsoft.Json;
using TestObjects;

namespace SchoolActivity
{
    public class SerializeStudent
    {
        public void PrintOutPersonJson()
        {
            string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TeachersGradebook");

            Person person = new Person
            {
                Name = "Stefan",
                LastName = "Mocny",
                EducationYear = 2023,
                Id = 1
            };

            string json = JsonConvert.SerializeObject(person);

            string filePath = $"{dir}\\person.json";
            File.WriteAllText(filePath, json);

            Console.WriteLine("JSON data has been written to the file.");
        }       
    }
}
