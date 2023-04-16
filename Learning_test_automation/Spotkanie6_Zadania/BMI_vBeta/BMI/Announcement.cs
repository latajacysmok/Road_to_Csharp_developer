using Data;
using Option;

namespace BMI
{
    public class Announcement
    {
        Performer appOption = new Performer();
        private BmiCalculator bmi;
        private string name;

        public Announcement()
        {
            appOption.ProgramWelcome();
            ValueStorage programData = new ValueStorage();
            this.name = programData.Name;
            this.bmi = new BmiCalculator(programData.Weight, programData.Height);
        }
        public void ApplicationRunner()
        {
            while (true)
            {
                Console.WriteLine($"Dear {name}, Your BMI is {Math.Round(bmi.BmiCalculation, 2)}. You have {bmi.EstimateWeight}.");
                Console.WriteLine(bmi.AdjusterToRightWeight);
                appOption.MakingDecisionAboutNextStep(name);
                break;
            }
        }
    }
}
