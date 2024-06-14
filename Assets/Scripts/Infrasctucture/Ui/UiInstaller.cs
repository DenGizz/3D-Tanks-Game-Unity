using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrasctucture
{
    [CreateAssetMenu(fileName = "UiInstaller", menuName = "Infrasctucture/Installers/UiInstaller")]
    public class UiInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IUiFactory>().To<UiFactory>().AsSingle();
        }
    }
}
