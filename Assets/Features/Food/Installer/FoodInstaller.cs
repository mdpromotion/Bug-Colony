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
        }
    }
}