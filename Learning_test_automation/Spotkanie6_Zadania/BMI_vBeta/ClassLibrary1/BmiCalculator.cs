namespace BMI
{
    public class BmiCalculator
    {
        public double BmiCalculation { get; }
        public double CalculateHowMuchShouldBeGained { get; }
        public double CalculateHowMuchShouldBeLost { get; }

        public BmiCalculator(double weight, double height)
        {
            BmiCalculation = GetBmiCalculation(weight, height);
            CalculateHowMuchShouldBeGained = GetCalculateHowMuchShouldBeGained(height);
            CalculateHowMuchShouldBeLost = GetCalculateHowMuchShouldBeLost(height);
        }

        private double GetBmiCalculation(double weight, double height)
        {
            return weight / GetPowerCalculation(height);
        }

        private double GetPowerCalculation(double height)
        {
            return Math.Pow(2.0, (double)height);
        }

        private double GetCalculateHowMuchShouldBeGained(double height)
        {
            double missingDiffToRightBmi = 18.5 - BmiCalculation;
            double result = missingDiffToRightBmi * GetPowerCalculation(height);
            return result;
        }

        private double GetCalculateHowMuchShouldBeLost(double height)
        {
            double missingDiffToRightBmi = BmiCalculation - 24.9;
            double result = missingDiffToRightBmi * GetPowerCalculation(height);
            return result;
        }
    }
}