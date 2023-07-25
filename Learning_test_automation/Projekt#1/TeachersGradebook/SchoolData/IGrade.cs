    namespace SchoolData
{
    public interface IGrade
    {
        double Value { get; set; }
        int StudentID { get; set; }
        SchoolSubjects SchoolSubject { get; set; }
        int Id { get; set; }
        DateTime CreationTime { get; set; }
        GradeType GradeType { get; set; }
    }
}
