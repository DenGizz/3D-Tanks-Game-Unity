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
            return LoadAsset<BattleRulesConfig>(ResourcePath.BattleRulesConfig);
        }

        public GameObject GetShellExplosionPrefab()
        {
            return LoadAsset<GameObject>(ResourcePath.ShellExplosionPrefab);
        }

        public GameObject GetTankExplosionPrefab()
        {
            return LoadAsset<GameObject>(ResourcePath.TankExplosionPrefab);
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

        public LocalDeviceInputSchemesConfig GetLocalInputSchemesConfig()
        {
            return LoadAsset<LocalDeviceInputSchemesConfig>(ResourcePath.LocalInputSchemesConfig);
        }

        public ScenesConfig GetScenesConfig()
        {
            return LoadAsset<ScenesConfig>(ResourcePath.ScenesConfig);
        }

        private GameplayResourceBundle GetOrLoadAndGetGameplayResourceBundle()
        {
            return LoadAsset<GameplayResourceBundle>(ResourcePath.GameplayResourceBundle);
        }

        private UiResourceBundle GetOrLoadAndGetUiResourceBundle()
        {
            return UnityEngine.Resources.Load<UiResourceBundle>(ResourcePath.UiResourceBundle) 
                ?? throw new Exception("UiResourceBundle not found");
        }

        private TAsset LoadAsset<TAsset>(string path) where TAsset : UnityEngine.Object
        {
            return UnityEngine.Resources.Load<TAsset>(path)
                ?? throw new Exception($"Can`t load asset at {path}");
        }
    }
}
