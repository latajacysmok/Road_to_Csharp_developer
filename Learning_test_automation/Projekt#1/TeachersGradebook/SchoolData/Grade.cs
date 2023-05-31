namespace SchoolData
{
    public class Grade
    {
        public double Value { get; set; }
        public int StudentID { get; set; }
        public SchoolSubjects SchoolSubject { get; set; }
        public int Id{ get; set; }

        public Grade(int iD, int studentID, SchoolSubjects schoolSubject, double grade)
        {
            Id = iD;
            Value = grade;
            StudentID = studentID;
            SchoolSubject = schoolSubject;
        }

        public override string ToString()
        {
            return $"{SchoolSubject}: {Value}, Student id number: {StudentID}";
        }
    }
}
