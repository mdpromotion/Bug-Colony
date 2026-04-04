using Core.Tick;
using Shared.Provider;
using Shared.Services;
using UnityEngine;
using Zenject;

namespace Core.Installers
{
    public class GameInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<ILogger>().FromInstance(Debug.unityLogger).AsSingle();
            Container.Bind<IRandomProvider>().To<RandomProvider>().AsSingle();
            Container.Bind<IGameObjectService>().To<GameObjectService>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesTo<TickManager>().AsSingle().NonLazy();
        }
    }
}