namespace GamesElement
{
    public abstract class AnimalOrganism : Organism
    {
        public abstract int Initiative { get; }
        
        protected AnimalType getAnimalType;
        public AnimalType GetAnimalType { get { return getAnimalType; } }
        public abstract void OrganismMovement();

        public override string ToString()
        {
            return $"Id: {Id}, Type: {getAnimalType}, Position: [{position[0] + 1},{position[1] + 1}]";
        }
    }
}
