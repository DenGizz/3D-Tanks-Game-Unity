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
            Container.Bind<IAssetsProvider>().To<AssetsProvider>().AsSingle();
            Container.Bind<ITankFactory>().To<TankFactory>().AsSingle();
            Container.Bind<ITanksProvider>().To<TanksProvider>().AsSingle();
        }
    }
}
