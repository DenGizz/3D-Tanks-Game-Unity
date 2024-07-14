using Assets.Scripts.Behaviours.TankBehaviours;
using Assets.Scripts.Domain;
using Assets.Scripts.Infrasctucture.Core;
using Assets.Scripts.Infrasctucture.Gameplay.Providers;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrasctucture.Gameplay.Factories
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


        public ITank CreateTank(Vector3 position, Quaternion rotation)
        {
            GameObject tankInstance = _instantiator.InstantiatePrefab(_assetsProvider.GetTankPrefab());
            TankBehaviour tank = tankInstance.GetComponent<TankBehaviour>();
            tank.Position = position;
            tank.Rotation = rotation;

            _gameObjectsRegistry.RegisterGameObject(tank, tankInstance);
            return tank;
        }
    }
}
