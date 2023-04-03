using Data;
using Option;

namespace BMI
{
    public class Announcement
    {
        private string name;
        private double weight;
        private double height;
        private BmiCalculator bmi;
        Performer appOption = new Performer();

        public Announcement()
        {
            ValueStorage programData = new ValueStorage();
            
            appOption.ProgramWelcome();
            this.name = Console.ReadLine();
            this.weight = programData.WeightChecker(name);
            this.height = programData.HeightChecker(name);
            this.bmi = new BmiCalculator(weight, height);
        }
        public void ApplicationRunner()
        {           
            while (true)
            {
                Console.WriteLine($"Dear {name}, Your BMI is {Math.Round(bmi.BmiCalculation, 2)}. You have {EstimateWeight()}.");
                AdjusterToRightWeight();
                appOption.MakingDecisionAboutNextStep(name);
            }
        }
        public string EstimateWeight()
        {
            switch (bmi.BmiCalculation)
            {
                case < 18.5:
                    return "underweight";
                case > 24.9:
                    return "overweight";
                default:
                    return "weight in standard";
            }
        }

        public void AdjusterToRightWeight()
        {
            string results = EstimateWeight();

            if (results == "underweight") Console.WriteLine($"You need gain {Math.Round(bmi.CalculateHowMuchShouldBeGained, 2)} kg to be within the normal BMI.");
            else if (results == "overweight") Console.WriteLine($"You need lose {Math.Round(bmi.CalculateHowMuchShouldBeLost, 2)} kg to be within the normal BMI.");
        }
    }
}
