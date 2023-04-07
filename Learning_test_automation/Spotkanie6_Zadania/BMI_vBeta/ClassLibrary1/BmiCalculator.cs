namespace BMI
{
    public class BmiCalculator
    {
        public double BmiCalculation { get; }
        public double CalculateHowMuchShouldBeGained { get; }
        public double CalculateHowMuchShouldBeLost { get; }
        public string AdjusterToRightWeight { get; }
        public string EstimateWeight { get; }


        public BmiCalculator(double weight, double height)
        {
            BmiCalculation = GetBmiCalculation(weight, height);
            CalculateHowMuchShouldBeGained = GetCalculateHowMuchShouldBeGained(height);
            CalculateHowMuchShouldBeLost = GetCalculateHowMuchShouldBeLost(height);
            EstimateWeight = GetEstimateWeight();
            AdjusterToRightWeight = GetAdjusterToRightWeight(EstimateWeight);      
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

        private string GetEstimateWeight()
        {
            switch (BmiCalculation)
            {
                case < 18.5:
                    return "underweight";
                case > 24.9:
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