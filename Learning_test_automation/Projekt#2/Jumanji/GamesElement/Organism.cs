namespace GamesElement
{
    public abstract class Organism
    {
        protected int strength;
        public  int Strength 
        { 
            get { return strength; }
            set { strength = value; }
        }

        protected string id;
        public  string Id 
        {
            get { return id; } 
            set { id = value; }
        }

        protected int[] position;

        public int[] Position
        {
            get { return position; }
            set { position = value; }
        }

        public abstract void OrganismAction();
        public abstract void OrganismCollision();
        public int[] GetPosition()
        {
            return position;
        }
        public void SetPosition(int x, int y)
        {
            int[] newPosition = new int[] { x, y };
            Position = newPosition;
        }
    }
}
