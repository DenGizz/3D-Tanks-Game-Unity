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


        public Tank CreateTank(Transform spawnPoint, Color color, int playerNumber)
        {
            GameObject tankInstance = _instantiator.InstantiatePrefab(_assetsProvider.GetTankPrefab());
            Tank tank = new Tank();
            tankInstance.transform.position = spawnPoint.position;
            tankInstance.transform.rotation = spawnPoint.rotation;
            tank.Setup(tankInstance, color, spawnPoint, playerNumber);
            return tank;
        }
    }
}
