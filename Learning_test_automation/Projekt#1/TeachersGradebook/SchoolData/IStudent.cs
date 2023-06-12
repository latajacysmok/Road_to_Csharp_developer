namespace SchoolData
{
    public interface IStudent
    {
        string Name { get; set; }
        string LastName { get; set; }
        int EducationYear { get; set; }
        int Id { get; set; }

        DateTime CreationTime { get; set; }
    }
}
