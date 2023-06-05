namespace SchoolData
{
    public class Student
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int EducationYear { get; set; }
        public int Id { get; set; }

        public string GetCreationTime { get; set; }

        public Student(int id, string name, string lastName, int educationYear)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            EducationYear = educationYear;
            //DateTime GetCreationTime = DateTime.Now;
            DateTime studentCreationTime = DateTime.Now;
            GetCreationTime = studentCreationTime.ToString("'Student_'HH'-'mm'-'ss'_'dd'-'MM'-'yyyy");
        }

        public override string ToString()
        {
            return $"{Name} {LastName}, ID number: {Id}";
        }
    }
}
