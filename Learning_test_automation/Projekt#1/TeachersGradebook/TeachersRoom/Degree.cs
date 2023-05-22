namespace TeachersRoom
{
    public class Degree
    {
        private double rating;
        public double LessImportantRating
        {
            get { return rating; }
            set { rating = value * 0.65D; }
        }
        public double MoreImportantRating
        {
            get { return rating; }
            set { rating = value * 1.2D; }
        }

        public double CalculationOfAverageGrade(List<float> studentGrades)
        {
            return Math.Round(studentGrades.Average(), 2);
        }

    }
}