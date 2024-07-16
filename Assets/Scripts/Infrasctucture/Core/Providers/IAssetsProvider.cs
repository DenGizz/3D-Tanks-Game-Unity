using Assets.Scripts.Configs;
using UnityEngine;

namespace Assets.Scripts.Infrasctucture.Core.Providers
{
    public interface IAssetsProvider
    {
        BattleRulesConfig GetBattleSessionConfig();
        GameObject GetMessagesUiPrefab();
        GameObject GetTankPrefab();
        GameObject GetTankExplosionPrefab();
        LocalInputSchemesConfig GetLocalInputSchemesConfig();
        GameObject GetShellPrefab();
    }
}
