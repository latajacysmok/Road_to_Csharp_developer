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
            SimpleInjector.Container container = new DependencyInjector().Container;// utworzyć interface dla verifare, move i narazie tyle i zastąpić tam gdzie jest new kontenerem//dodać kontener  w Proram i tam dodać referencje do DI, 
            var verifier = container.GetInstance<IVerifier>;
            Menu menu = new Menu(verifier);
            menu.StartOfGame();
        }
    }
}
