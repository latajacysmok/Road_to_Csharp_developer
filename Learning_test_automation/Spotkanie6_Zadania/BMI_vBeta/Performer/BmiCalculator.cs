namespace Performer
{
    public class BmiCalculator
    {
        private double powerCalculation;
        private double PowerCalculation
        {
            get { return powerCalculation; }
            set { powerCalculation = Math.Pow(2.0, (double)value); }
        }

        private double bmiCalculation;
        public double BmiCalculation 
        {
            get { return bmiCalculation; }
            set { bmiCalculation = value / PowerCalculation; }
        }

        private double calculateHowMuchShouldBeGained;
        private double CalculateHowMuchShouldBeGained
        {
            get { return calculateHowMuchShouldBeGained; }
            set { calculateHowMuchShouldBeGained = (lowerLimitBmi - BmiCalculation) * PowerCalculation; }
        }

        private double calculateHowMuchShouldBeLost;
        private double CalculateHowMuchShouldBeLost
        {
            get { return calculateHowMuchShouldBeLost; }
            set { calculateHowMuchShouldBeLost = (BmiCalculation - upperLimitBmi) * PowerCalculation; }
        }

        public string AdjusterToRightWeight { get; }
        public string EstimateWeight { get; }

        private const double lowerLimitBmi = 18.5;
        private const double upperLimitBmi = 24.9;



        public BmiCalculator(double weight, double height)
        {
            PowerCalculation = height;
            BmiCalculation = weight;
            AdjusterToRightWeight = GetAdjusterToRightWeight(GetEstimateWeight(), height);
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

        private string GetAdjusterToRightWeight(string results, double height)
        {
            if (results == "underweight") results = ($"You need gain {Math.Round(CalculateHowMuchShouldBeGained, 2)} kg to be within the normal BMI.");
            else if (results == "overweight") results = ($"You need lose {Math.Round(CalculateHowMuchShouldBeLost, 2)} kg to be within the normal BMI.");
            return results;
        }
    }
}
