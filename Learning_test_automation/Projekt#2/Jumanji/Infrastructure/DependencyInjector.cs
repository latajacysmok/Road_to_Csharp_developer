using SimpleInjector;
using GameMechanism;
using GamesElement;

namespace Infrastructure
{
    public class DependencyInjector
    {
        public Container Container = new Container();

        public void DependencyInjectorCreator()
        {
            Container.Options.EnableAutoVerification = false;
            RegisterOrganism();
            RegisterVerifier();
        }

        private void RegisterOrganism()
        {
            Container.Register<IOrganism, Organism>();
        }

        private void RegisterVerifier()
        {
            Container.Register<IVerifier, Verifier>();
        }

        // Register conditionar użyć tutaj aby móc wykorzystać kontener w SpawnRepository, przykład w saint 65 linia w SAINT
        //Container.RegisterSingleton<IArgument, Argument>();
    }
}