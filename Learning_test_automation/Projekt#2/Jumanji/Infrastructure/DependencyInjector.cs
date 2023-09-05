using SimpleInjector;
using GameMechanism;
using GamesElement;
using Animal;
using GameBoard;
using SimpleInjector.Lifestyles;
using System.ComponentModel;

namespace Infrastructure
{
    public class DependencyInjector
    {
        public SimpleInjector.Container Container = new SimpleInjector.Container();

        public DependencyInjector()
        {
            Container.Options.EnableAutoVerification = false;
            RegisterOrganisms();    
            RegisterVerifier();           
            RegisterBoard();
            RegisterReproduction();         
            RegisterMove();
            RegisterCollision();
            RegisterMenu();
        }

        private void RegisterOrganisms()
        {
            Container.Collection.Register<IOrganism>(new[]
            {
                typeof(Sheep),
                typeof(Wolf),
                typeof(Fox)
                // Add more implementations here if needed
            });
        }

        private void RegisterVerifier()
        {
            Container.Register<IVerifier, Verifier>();
        }

        private void RegisterMenu()
        {
            Container.Register<IMenu>(() =>
            {
                var verifier = Container.GetInstance<IVerifier>();
                var move = Container.GetInstance<IMove>();
                return new Menu(verifier, move);
            });
        }
        
        private void RegisterBoard()
        {
            Container.Register<IBoard>(() => new Board(10, 10));
        }
        
        private void RegisterMove()
        {
            Container.Register<IMove>(() =>
            {
                var board = Container.GetInstance<IBoard>();
                var listOrganism = Container.GetInstance<List<IOrganism>>();
                var verifier = Container.GetInstance<IVerifier>();
                return new Move(board, listOrganism, verifier);
            }, Lifestyle.Transient);
        }

        private void RegisterCollision()
        {
            Container.Register<ICollision>(() =>
            {
                var board = Container.GetInstance<IBoard>();
                var move = Container.GetInstance<IMove>();
                return new Collision(move.Board, move);
            }, Lifestyle.Transient);
        }

        private void RegisterReproduction()
        {
            
        }
    }
}