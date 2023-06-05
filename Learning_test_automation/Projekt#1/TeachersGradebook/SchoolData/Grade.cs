namespace SchoolData
{
    public class Grade
    {
        public double Value { get; set; }
        public int StudentID { get; set; }
        public SchoolSubjects SchoolSubject { get; set; }
        public int Id{ get; set; }
        public string GetCreationTime { get; set; }

        public Grade(int iD, int studentID, SchoolSubjects schoolSubject, double grade)
        {
            Id = iD;
            Value = grade;
            StudentID = studentID;
            SchoolSubject = schoolSubject;
            DateTime gradeCreationTime = DateTime.Now;
            GetCreationTime = gradeCreationTime.ToString("'Grade_'HH'-'mm'-'ss'_'dd'-'MM'-'yyyy");
        }

        public override string ToString()
        {
            return $"{SchoolSubject}: {Value}, Student id number: {StudentID}";
        }
    }
}
