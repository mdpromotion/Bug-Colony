using Bug.Application;
using Bug.Application.Factories;
using Bug.Application.UseCases;
using Bug.Domain;
using Bug.Infrastructure;
using Bug.Presentation;
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
            Container.Bind<IBugObjectFactory>().To<BugObjectFactory>().AsSingle();
            Container.Bind<IBugEventBus>().To<BugEventBus>().AsSingle();
            Container.BindInterfacesTo<BugEventHandler>().AsSingle().NonLazy();
            Container.BindInterfacesTo<ColonyController>().AsSingle().NonLazy();

            BindStrategies();

            Container.Bind<BugFSMFactory>().AsSingle();
            Container.Bind<IBugAssembler>().To<BugAssembler>().AsSingle();
            Container.BindInterfacesTo<BugAIController>().AsSingle().NonLazy();

            InstallPresentation();
        }

        private void InstallPresentation()
        {
            Container.BindInterfacesTo<Presenter>().AsSingle();
            Container.Bind<IView>().To<View>().FromComponentInHierarchy().AsSingle();
            Container.Bind<BugsData>().AsSingle();
        }

        private void BindStrategies()
        {
            Container.Bind<SeekFoodMovementStrategy>().AsTransient();
            Container.Bind<SeekEverythingMovementStrategy>().AsTransient();

            Container.Bind<EatOnlyFoodStrategy>().AsTransient();
            Container.Bind<EatEverythingStrategy>().AsTransient();

            Container.Bind<WorkerReproductionStrategy>().AsTransient();
            Container.Bind<PredatorReproductionStrategy>().AsTransient();

            BindMovementStrategies();
            BindEatingStrategies();
            BindReproductionStrategies();
        }


        private void BindMovementStrategies()
        {
            Container.Bind<Dictionary<BugType, IMovementStrategy>>()
                .FromMethod(ctx => new Dictionary<BugType, IMovementStrategy>
                {
            { BugType.Worker, ctx.Container.Instantiate<SeekFoodMovementStrategy>() },
            { BugType.Predator, ctx.Container.Instantiate<SeekEverythingMovementStrategy>() }
                })
                .AsSingle();
        }

        private void BindEatingStrategies()
        {
            Container.Bind<Dictionary<BugType, IEatingStrategy>>()
                .FromMethod(ctx => new Dictionary<BugType, IEatingStrategy>
                {
            { BugType.Worker, ctx.Container.Instantiate<EatOnlyFoodStrategy>() },
            { BugType.Predator, ctx.Container.Instantiate<EatEverythingStrategy>() }
                })
                .AsSingle();
        }

        private void BindReproductionStrategies()
        {
            Container.Bind<Dictionary<BugType, IReproductionStrategy>>()
                .FromMethod(ctx => new Dictionary<BugType, IReproductionStrategy>
                {
            { BugType.Worker, ctx.Container.Instantiate<WorkerReproductionStrategy>() },
            { BugType.Predator, ctx.Container.Instantiate<PredatorReproductionStrategy>() }
                })
                .AsSingle();
        }
    }

}