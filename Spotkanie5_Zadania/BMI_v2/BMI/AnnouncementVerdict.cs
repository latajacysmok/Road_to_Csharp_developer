namespace BMI
{
    class AnnouncementVerdict
    {
        BmiCalculator bmiCalculator = new BmiCalculator();
        public void ApplicationRunner()
        {
            ProgramData programData = new ProgramData();
            AppOption appOption = new AppOption();
            appOption.ProgramWelcome();
            string name = Console.ReadLine();
            while (true)
            {
                double weight = programData.WeightChecker(name);
                double height = programData.HeightChecker(name);
                double bmi = bmiCalculator.BmiCalculation(weight, height);

                Console.WriteLine($"Dear {name}, Your BMI is {Math.Round(bmi, 2)}. You have {EstimateWeight(bmi)}.");
                WhatNeedToBeOk(bmi, height);
                appOption.ChoiceOptions(name);
            }
        }
        public string EstimateWeight(double bmi)
        {
            switch (bmi)
            {
                case < 18.5:
                    return "underweight";
                case > 24.9:
                    return "overweight";
                default:
                    return "weight in standard";
            }
        }

        public void WhatNeedToBeOk(double bmi, double height)
        {
            string results = EstimateWeight(bmi);

            if (results == "underweight") Console.WriteLine($"You need gain {Math.Round(bmiCalculator.CalculateHowMuchShouldBeGained(bmi, height), 2)} kg to be within the normal BMI.");
            else if (results == "overweight") Console.WriteLine($"You need lose {Math.Round(bmiCalculator.CalculateHowMuchShouldBeLost(bmi, height), 2)} kg to be within the normal BMI.");
        }
    }
}
