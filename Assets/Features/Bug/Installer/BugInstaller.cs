using Bug.Application;
using Bug.Application.Factories;
using Bug.Application.UseCases;
using Bug.Domain;
using Bug.Infrastructure;
using Bug.Strategies;
using System.Collections.Generic;
using Zenject;

namespace Bug.Installers
{
    public class BugInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<IColonyService>().To<ColonyService>().AsSingle();
            Container.Bind<ISpawnBugUseCase>().To<SpawnBugUseCase>().AsSingle();
            Container.Bind<BugFactory>().AsSingle();

            BindStrategies();

            Container.Bind<BugFSMFactory>().AsSingle();
            Container.Bind<IBugAssembler>().To<BugAssembler>().AsSingle();
        }
        private void BindStrategies()
        {
            Container.Bind<Dictionary<BugType, IMovementStrategy>>()
                .FromMethod(_ => new Dictionary<BugType, IMovementStrategy>
                {
                    { BugType.Worker, new SeekFoodMovementStrategy() },
                    { BugType.Predator, new SeekEverythingMovementStrategy() }
                })
                .AsSingle();

            Container.Bind<Dictionary<BugType, IEatingStrategy>>()
                .FromMethod(_ => new Dictionary<BugType, IEatingStrategy>
                {
                    { BugType.Worker, new EatOnlyFoodStrategy() },
                    { BugType.Predator, new EatOnlyFoodStrategy() }
                })
                .AsSingle();

            Container.Bind<Dictionary<BugType, IReproductionStrategy>>()
                .FromMethod(_ => new Dictionary<BugType, IReproductionStrategy>
                {
                    { BugType.Worker, new WorkerReproductionStrategy() },
                    { BugType.Predator, new PredatorReproductionStrategy() }
                })
                .AsSingle();
        }
    }

}