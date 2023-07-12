using SchoolData;

namespace SchoolActivity
{
    public class Degree
    {
        private double rating;
        public double HomeworkDegreeRating
        {
            get { return rating; }
            set { rating = value * 0.65D; }
        }
        public double TestDegreeRating
        {
            get { return rating; }
            set { rating = value * 1.2D; }
        }

        public double CalculationOfAverageDegree(List<double> studentGrades)
        {
            return Math.Round(studentGrades.Average(), 2);
        }
    }
}