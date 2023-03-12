namespace BMI
{
    class AnnouncementVerdict
    {
        public void ApplicationRunner()
        {
            ProgramData programData = new ProgramData();
            BmiCalculator bmiCalculator = new BmiCalculator();
            AppOption appOption = new AppOption();
            appOption.ProgramWelcome();
            string name = Console.ReadLine();
            while (true)
            {
                double weight = programData.WeightChecker(name);
                double height = programData.HeightChecker(name);
                double bmi = bmiCalculator.BmiCalculation(weight, height);

                Console.WriteLine($"Dear {name}, Your BMI is {Math.Round(bmi, 2)}. You have {EstimateWeight(bmi)}.");
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
    }
}
