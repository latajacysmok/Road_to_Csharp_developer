namespace SchoolData
{
    public class Student : IStudent
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int EducationYear { get; set; }
        public int Id { get; set; }

        public DateTime CreationTime { get; set; }

        public Student(int id, string name, string lastName, int educationYear)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            EducationYear = educationYear;
            CreationTime = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Name: {Name}; Lastname: {LastName}; ID number: {Id}; Education year: {EducationYear};";
        }
    }
}
