using Assets.Scripts.Configs;
using Assets.Scripts.Infrastructure.Gameplay.Configs;
using UnityEngine;

namespace Assets.Scripts.Infrasctucture.Core.Providers
{
    public interface IAssetsProvider
    {
        BattleRulesConfig GetBattleSessionConfig();
        GameObject GetMessagesUiPrefab();
        GameObject GetTankPrefab();
        GameObject GetTankExplosionPrefab();
        LocalDeviceInputSchemesConfig GetLocalInputSchemesConfig();
        GameObject GetShellPrefab();
        ScenesConfig GetScenesConfig();
        GameObject GetShellExplosionPrefab();
    }
}
