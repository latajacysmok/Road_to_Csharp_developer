namespace BMI
{
    class BmiCalculator
    {
        public double BmiCalculation(double weight, double height)
        {
            double bmi = weight / PowerCalculation(height);
            return bmi;
        }

        public double PowerCalculation(double height)
        {
            double pow = Math.Pow(2.0, (double)height);
            return pow;
        }

        public double CalculateHowMuchShouldBeGained(double bmi, double height)
        {
            double missingDiffToRightBmi = 18.5 - bmi;
            double result = missingDiffToRightBmi * PowerCalculation(height);
            return result;
        }

        public double CalculateHowMuchShouldBeLost(double bmi, double height)
        {
            double missingDiffToRightBmi = bmi - 24.9;
            double result = missingDiffToRightBmi * PowerCalculation(height);
            return result;
        }
    }
}
