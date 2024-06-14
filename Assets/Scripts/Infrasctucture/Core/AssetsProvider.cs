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
        private UiResourceBundle _uiResourceBundle;
        private BattleSessionConfig _battleSessionConfig;

        public BattleSessionConfig GetBattleSessionConfig()
        {
            if (_battleSessionConfig == null)
                _battleSessionConfig = UnityEngine.Resources.Load<BattleSessionConfig>(ResourcePath.BattleSessionConfig);
        
            return _battleSessionConfig ?? throw new Exception("BattleSessionConfig not found");
        }

        public GameObject GetMessagesUiPrefab()
        {
            return GetOrLoadAndGetUiResourceBundle().MessagesUiPrefab;
        }

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

        private UiResourceBundle GetOrLoadAndGetUiResourceBundle()
        {
            if (_uiResourceBundle == null)
                _uiResourceBundle = UnityEngine.Resources.Load<UiResourceBundle>(ResourcePath.UiResourceBundle);

            return _uiResourceBundle ?? throw new Exception("UiResourceBundle not found");
        }
    }
}
