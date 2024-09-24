using Assets.Scripts.Infrasctucture.Core.Factories;
using Assets.Scripts.Infrasctucture.Core.Providers;
using Assets.Scripts.Infrasctucture.Core.Services;
using Assets.Scripts.Infrasctucture.Core.Services.CoroutineRunners;
using Assets.Scripts.Infrastructure.Core.Services;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrasctucture.Core.Installers
{
    [CreateAssetMenu(fileName = "CoreInstaller", menuName = "Installers/CoreInstaller")]
    public class CoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IStateFactory>().To<StateFactroy>().AsSingle();
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<IAssetsProvider>().To<AssetsProvider>().AsSingle();
            Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        }
    }
}
