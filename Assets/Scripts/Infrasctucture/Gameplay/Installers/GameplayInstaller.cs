using Assets.Scripts.Infrasctucture.Gameplay.Factories;
using Assets.Scripts.Infrasctucture.Gameplay.Providers;
using Assets.Scripts.Infrasctucture.Gameplay.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Container.Bind<IRoundObserver>().To<RoundObserver>().AsSingle();
            Container.Bind<ITankFactory>().To<TankFactory>().AsSingle();
            Container.Bind<ITanksProvider>().To<TanksProvider>().AsSingle();
            Container.Bind<ICameraControlProvider>().To<CameraControlProvider>().AsSingle();
            Container.Bind<ILevelSpawnPointsProvider>().To<LevelSpawnPointsProvider>().AsSingle();
            Container.Bind<ITanksGameObjectsRegistry>().To<TanksGameObjectsRegistry>().AsSingle();
            Container.Bind<IInputSourceServiceAssing>().To<InputSourceAssingService>().AsSingle();
            Container.Bind<IInputSourceFactory>().To<InputSourceFactory>().AsSingle();
        }
    }
}
