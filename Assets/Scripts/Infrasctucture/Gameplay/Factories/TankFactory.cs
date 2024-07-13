using Assets.Scripts.Infrasctucture.Gameplay.Providers;
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
        private readonly ITanksGameObjectsRegistry _gameObjectsRegistry;

        public TankFactory(IInstantiator instantiator, IAssetsProvider assetsProvider, ITanksGameObjectsRegistry gameObjectsRegistry)
        {
            _instantiator = instantiator;
            _assetsProvider = assetsProvider;
            _gameObjectsRegistry = gameObjectsRegistry; 
        }


        public ITank CreateTank(Vector3 position, Quaternion rotation,string name, Color color)
        {
            GameObject tankInstance = _instantiator.InstantiatePrefab(_assetsProvider.GetTankPrefab());
            TankBehaviour tank = tankInstance.GetComponent<TankBehaviour>();
            tankInstance.transform.position = position;
            tankInstance.transform.rotation = rotation;
            tank.Setup(name, color);

            _gameObjectsRegistry.RegisterGameObject(tank, tankInstance);
            return tank;
        }
    }
}
