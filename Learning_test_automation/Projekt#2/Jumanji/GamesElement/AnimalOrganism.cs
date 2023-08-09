namespace GamesElement
{
    public abstract class AnimalOrganism : Organism, IAnimalOrganism
    {
        public abstract int Initiative { get; }
        
        protected AnimalType getAnimalType;
        public AnimalType GetAnimalType { get { return getAnimalType; } }

        public abstract void OrganismMovement();

        public override string ToString()
        {
            return $"Id: {Id}, Type: {getAnimalType}, Position: [{Position.X + 1},{Position.Y + 1}]";
        }
    }
}
