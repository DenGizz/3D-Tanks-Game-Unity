using Assets.Scripts.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Behaviours
{
    internal class ShootableComponentInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IShootable>().FromComponentInHierarchy().AsSingle();
        }
    }
}
