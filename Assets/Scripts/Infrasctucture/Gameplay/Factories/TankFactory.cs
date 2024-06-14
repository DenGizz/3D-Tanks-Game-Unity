using Assets.Scripts.Tank;
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


        public ITank CreateTank(Vector3 position, Quaternion rotation, Color color, int playerNumber)
        {
            GameObject tankInstance = _instantiator.InstantiatePrefab(_assetsProvider.GetTankPrefab());
            TankBehaviour tank = tankInstance.GetComponent<TankBehaviour>();
            tankInstance.transform.position = position;
            tankInstance.transform.rotation = rotation;
            tank.Setup( color, playerNumber);
            return tank;
        }
    }
}
