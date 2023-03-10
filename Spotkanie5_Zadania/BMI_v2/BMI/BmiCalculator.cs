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
    }
}
