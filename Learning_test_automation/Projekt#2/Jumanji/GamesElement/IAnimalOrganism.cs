namespace GamesElement
{
    public interface IAnimalOrganism : IOrganism
    {
        public abstract int Initiative { get; }
        public AnimalType GetAnimalType { get; }
        public abstract void OrganismMovement();
    }
}
