using Bug.Installers;
using Food.Installers;
using Zenject;

namespace Core.Installers
{
    public class GameMonoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Install<FoodInstaller>();
            Container.Install<BugInstaller>();
            Container.Install<GameInstaller>();
        }
    }
}