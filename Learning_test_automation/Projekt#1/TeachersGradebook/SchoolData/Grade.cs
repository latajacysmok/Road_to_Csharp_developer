namespace SchoolData
{
    public class Grade : IGrade
    {
        public double Value { get; set; }
        public int StudentID { get; set; }
        public SchoolSubjects SchoolSubject { get; set; }
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }

        public Grade(int iD, int studentID, SchoolSubjects schoolSubject, double grade)
        {
            Id = iD;
            Value = grade;
            StudentID = studentID;
            SchoolSubject = schoolSubject;
            CreationTime = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{SchoolSubject}: {Value}, ID number: {Id}, Student id number: {StudentID}";
        }
    }
}
