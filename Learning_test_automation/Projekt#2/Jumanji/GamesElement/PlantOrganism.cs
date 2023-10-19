namespace GamesElement
{
    public abstract class PlantOrganism : Organism, IPlantOrganism
    {
        protected PlantType getPlantType;
        public PlantType GetPlantType { get { return getPlantType; } }

        public override string ToString()
        {
            return $"Id: {Id}, Type: {getPlantType}, Position: [{Position.X + 1},{Position.Y + 1}]";
        }
    }
}
