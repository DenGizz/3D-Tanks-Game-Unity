using System;
using Assets.Scripts.Configs;
using Assets.Scripts.Infrastructure.Gameplay.Configs;
using Assets.Scripts.Resources;
using UnityEngine;

namespace Assets.Scripts.Infrasctucture.Core.Providers
{
    public class AssetsProvider : IAssetsProvider
    {
        public BattleRulesConfig GetBattleSessionConfig()
        {
        
            return UnityEngine.Resources.Load<BattleRulesConfig>(ResourcePath.BattleRulesConfig) 
                ?? throw new Exception("BattleSessionConfig not found");
        }


        public GameObject GetShellExplosionPrefab()
        {
            return UnityEngine.Resources.Load<GameObject>(ResourcePath.ShellExplosionPrefab)
    ?? throw new Exception($"Tank explosion asset not found at {ResourcePath.ShellExplosionPrefab}");
        }

        public GameObject GetTankExplosionPrefab()
        {
            return UnityEngine.Resources.Load<GameObject>(ResourcePath.TankExplosionPrefab)
                ?? throw new Exception($"Tank explosion asset not found at {ResourcePath.TankExplosionPrefab}");
        }

        public LocalDeviceInputSchemesConfig GetLocalInputSchemesConfig()
        {
            return UnityEngine.Resources.Load<LocalDeviceInputSchemesConfig>(ResourcePath.LocalInputSchemesConfig)
                ?? throw new Exception($"LocalInputSchemesConfig asset not found at {ResourcePath.LocalInputSchemesConfig}");
        }


        public ScenesConfig GetScenesConfig()
        {
            return UnityEngine.Resources.Load<ScenesConfig>(ResourcePath.ScenesConfig)
               ?? throw new Exception($"ScenesConfig asset not found at {ResourcePath.ScenesConfig}");
        }

        public GameObject GetMessagesUiPrefab()
        {
            return GetOrLoadAndGetUiResourceBundle().MessagesUiPrefab;
        }

        public GameObject GetTankPrefab()
        {
            return GetOrLoadAndGetGameplayResourceBundle().TankPrefab;
        }

        public GameObject GetShellPrefab()
        {
            return GetOrLoadAndGetGameplayResourceBundle().ShellPrefab;
        }

        private GameplayResourceBundle GetOrLoadAndGetGameplayResourceBundle()
        {
            return UnityEngine.Resources.Load<GameplayResourceBundle>(ResourcePath.GameplayResourceBundle)
                ?? throw new Exception("GameplayResourceBundle not found");
        }

        private UiResourceBundle GetOrLoadAndGetUiResourceBundle()
        {
            return UnityEngine.Resources.Load<UiResourceBundle>(ResourcePath.UiResourceBundle) ?? throw new Exception("UiResourceBundle not found");
        }
    }
}
