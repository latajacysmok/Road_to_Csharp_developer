namespace SchoolData
{
    public class Student
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int EducationYear { get; set; }
        public int Id { get; set; }

        public Student(int id, string name, string lastName, int educationYear)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            EducationYear = educationYear;
        }

        public override string ToString()
        {
            return $"{Name} {LastName}, ID number: {Id}";
        }
    }
}
