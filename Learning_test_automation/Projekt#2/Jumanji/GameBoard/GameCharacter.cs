using GamesElement;
using Plant;

namespace GameBoard
{
    public class GameCharacter
    {
        Grass grass = new Grass();
        Dandelion dandelion = new Dandelion();
        SpawnRepository spawnRepository;
        public GameCharacter(int high, int width)
        {
            //spawnRepository = new SpawnRepository(high, width);
        }   
    }
}
