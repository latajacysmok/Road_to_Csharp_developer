namespace SchoolData
{
    public class Grades
    {
        public double Grade { get; set; }
        public int ID { get; set; }
        public List<Grades> SchoolSubject { get; set; }
        public Grades(int studentID, double grade, List<Grades> schoolSubject)
        {
            Grade = grade;
            ID = studentID;
            SchoolSubject = schoolSubject;
        }
    }
}
