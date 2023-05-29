using SchoolData;

namespace CurrencySelection
{
    public static class SchoolSubjectsExtensions
    {
        public static string GetDisplayName(this SchoolSubjects currency)
        {
            switch (currency)
            {
                case SchoolSubjects.Mathematics:
                    return "Mathematics";
                case SchoolSubjects.Physics:
                    return "Physics";
                case SchoolSubjects.Religion:
                    return "Religion";
                default:
                    throw new ArgumentException("Invalid currency.");
            }
        }
    }
}
