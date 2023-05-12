using Data;
using Option;

namespace Performer
{
    public class Announcement
    {
        MainContractor appOption = new MainContractor();
        private BmiCalculator bmi;
        private string name;

        public Announcement()
        {
            appOption.ProgramWelcome();
            this.name = appOption.GetName();
            ValueStorage programData = new ValueStorage(this.name);
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