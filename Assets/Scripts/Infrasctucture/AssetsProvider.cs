using Assets.Scripts.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrasctucture
{
    public class AssetsProvider : IAssetsProvider
    {
        private  GameplayResourceBundle _gameplayResourceBundle;

        public GameObject GetTankPrefab()
        {
            return GetOrLoadAndGetGameplayResourceBundle().TankPrefab;
        }

        private GameplayResourceBundle GetOrLoadAndGetGameplayResourceBundle()
        {
            if (_gameplayResourceBundle == null)
                _gameplayResourceBundle = UnityEngine.Resources.Load<GameplayResourceBundle>(ResourcePath.GameplayResourceBundle);

            return _gameplayResourceBundle ?? throw new Exception("GameplayResourceBundle not found");
        }
    }
}
