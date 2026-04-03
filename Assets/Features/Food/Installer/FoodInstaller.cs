using Food.Infrastructure;
using Zenject;

namespace Food.Installers
{
    public class FoodInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<IFoodService>().To<FoodService>().AsSingle();
        }
    }
}