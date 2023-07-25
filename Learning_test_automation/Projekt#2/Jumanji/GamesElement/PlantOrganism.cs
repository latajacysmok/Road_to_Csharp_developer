namespace GamesElement
{
    public abstract class PlantOrganism : Organism
    {
        protected PlantType getPlantType;
        public PlantType GetPlantType { get { return getPlantType; } }

        public override string ToString()
        {
            return $"Id: {Id}, Type: {getPlantType}, Position: [{position[0] + 1},{position[1] + 1}]";
        }
    }
}
