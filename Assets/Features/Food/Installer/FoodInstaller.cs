using Food.Infrastructure;
using Zenject;

namespace Food.Installers
{
    public class FoodInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<IFoodFactory>().To<FoodFactory>().AsSingle();
            Container.Bind<IFoodService>().To<FoodService>().AsSingle();
<<<<<<< Updated upstream
=======
<<<<<<< Updated upstream
            Container.Bind<ISpawnFoodUseCase>().To<SpawnFoodUseCase>().AsSingle();
=======
<<<<<<< Updated upstream
=======
            Container.Bind<ISpawnFoodUseCase>().To<SpawnFoodUseCase>().AsSingle();
            Container.BindInterfacesTo<FoodSpawnerController>().AsSingle().NonLazy();
>>>>>>> Stashed changes
>>>>>>> Stashed changes
>>>>>>> Stashed changes
        }
    }
}