using Assets.Scripts.Infrasctucture.Gameplay.Factories;
using Assets.Scripts.Infrasctucture.Gameplay.Providers;
using Assets.Scripts.Infrasctucture.Gameplay.Services;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrasctucture
{
    [CreateAssetMenu(fileName = "GameplayInstaller", menuName = "Infrasctucture/Installers/GameplayInstaller")]
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Game.Game>().AsSingle();
            Container.Bind<IBattleProvider>().To<BattleProvider>().AsSingle();
            Container.Bind<ITankFactory>().To<TankFactory>().AsSingle();
            Container.Bind<ICameraControlProvider>().To<CameraControlProvider>().AsSingle();
            Container.Bind<ILevelSpawnPointsProvider>().To<LevelSpawnPointsProvider>().AsSingle();
            Container.Bind<ITanksGameObjectsRegistry>().To<TanksGameObjectsRegistry>().AsSingle();
            Container.Bind<IInputSourceServiceAssing>().To<InputSourceAssingService>().AsSingle();
            Container.Bind<IInputSourceFactory>().To<InputSourceFactory>().AsSingle();
        }
    }
}
