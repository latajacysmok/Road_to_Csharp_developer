namespace BMI
{
    public class BmiCalculator
    {
        public double BmiCalculation { get; }
        private double CalculateHowMuchShouldBeGained { get; }
        private double CalculateHowMuchShouldBeLost { get; }
        public string AdjusterToRightWeight { get; }
        public string EstimateWeight { get; }

        private const double lowerLimitBmi = 18.5;
        private const double upperLimitBmi = 24.9;



        public BmiCalculator(double weight, double height)
        {
            BmiCalculation = GetBmiCalculation(weight, height);
            CalculateHowMuchShouldBeGained = GetCalculateHowMuchShouldBeGained(height);
            CalculateHowMuchShouldBeLost = GetCalculateHowMuchShouldBeLost(height);
            AdjusterToRightWeight = GetAdjusterToRightWeight(GetEstimateWeight());
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
            double missingDiffToRightBmi = lowerLimitBmi - BmiCalculation;
            return missingDiffToRightBmi * GetPowerCalculation(height);
        }

        private double GetCalculateHowMuchShouldBeLost(double height)
        {
            double missingDiffToRightBmi = BmiCalculation - upperLimitBmi;
            return missingDiffToRightBmi * GetPowerCalculation(height);
        }

        private string GetEstimateWeight()
        {
            switch (BmiCalculation)
            {
                case < lowerLimitBmi:
                    return "underweight";
                case > upperLimitBmi:
                    return "overweight";
                default:
                    return "weight in standard";
            }
        }

        private string GetAdjusterToRightWeight(string results)
        {
            if (results == "underweight") results = ($"You need gain {Math.Round(CalculateHowMuchShouldBeGained, 2)} kg to be within the normal BMI.");
            else if (results == "overweight") results = ($"You need lose {Math.Round(CalculateHowMuchShouldBeLost, 2)} kg to be within the normal BMI.");
            return results;
        }
    }
}
