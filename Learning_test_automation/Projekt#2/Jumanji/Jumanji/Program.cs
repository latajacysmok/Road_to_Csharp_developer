using GameBoard;
using GameMechanism;
using Infrastructure;

namespace Jumanji
{
    class Program
    {
        private static SimpleInjector.Container container;
        
        static public void Main(string[] args)
        {
            SimpleInjector.Container container = new DependencyInjector().Container;
            var verifier = container.GetInstance<IVerifier>();
            var move = container.GetInstance<IMove>();
            var collision = container.GetInstance<ICollision>();
            var menu = container.GetInstance<IMenu>();          
            menu.StartOfGame();
        }
    }
}
