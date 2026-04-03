using Bug.Application;
using Bug.Application.Factories;
using Bug.Application.UseCases;
using Bug.Infrastructure;
using Zenject;

namespace Bug.Installers
{
    public class BugInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<IColonyService>().To<ColonyService>().AsSingle();
            Container.Bind<SpawnBugUseCase>().AsSingle();
            Container.Bind<BugFactory>().AsSingle();
            Container.Bind<BugFSMFactory>().AsSingle();
            Container.Bind<IBugAssembler>().To<BugAssembler>().AsSingle();
        }
    }
}