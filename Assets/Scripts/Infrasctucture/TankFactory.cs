using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrasctucture
{
    public class TankFactory : ITankFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetsProvider _assetsProvider;

        public TankFactory(IInstantiator instantiator, IAssetsProvider assetsProvider)
        {
            _instantiator = instantiator;
            _assetsProvider = assetsProvider;
        }

        public Tank CreateTank()
        {
            GameObject tankInstance = _instantiator.InstantiatePrefab(_assetsProvider.GetTankPrefab());
            Tank tank = tankInstance.GetComponent<Tank>();
            tank.GameObjectInstance = tankInstance;
            return tank;
        }
    }
}
