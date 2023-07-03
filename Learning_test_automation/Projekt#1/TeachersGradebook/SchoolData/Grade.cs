namespace SchoolData
{
    public class Grade : IGrade
    {
        public double Value { get; set; }
        public int StudentID { get; set; }
        public SchoolSubjects SchoolSubject { get; set; }
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public KnowledgeTestType GradeType { get; set; }

        public Grade(int iD, int studentID, SchoolSubjects schoolSubject, double grade, KnowledgeTestType gradeType)
        {
            Id = iD;
            Value = grade;
            StudentID = studentID;
            SchoolSubject = schoolSubject;
            CreationTime = DateTime.Now;
            GradeType = gradeType;
    }

        public override string ToString()
        {
            return $"School subject: {SchoolSubject}, Grade value: {Value}, The given grade is from: {GradeType}, ID number: {Id}, Student id number: {StudentID}";
        }
    }
}
