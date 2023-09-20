using Newtonsoft.Json;
using TestObjects;

namespace SchoolActivity
{
    public class DeserializeStudent
    {
        public Person DeserializePersonFromJson()
        {
            string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TeachersGradebook");
            string filePath = $"{dir}\\person.json";

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                Person person = JsonConvert.DeserializeObject<Person>(json);
                return person;
            }
            else
            {
                Console.WriteLine("The JSON file does not exist.");
                return null;
            }
        }
    }
}
