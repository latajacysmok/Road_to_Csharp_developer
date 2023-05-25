namespace SchoolData
{
    public class Grades
    {
        public double Grade { get; set; }
        public int ID { get; set; }
        public string SchoolSubject { get; set; }
        public Grades(int studentID, double grade, string schoolSubject)
        {
            Grade = grade;
            ID = studentID;
            SchoolSubject = schoolSubject;
        }
    }
}
