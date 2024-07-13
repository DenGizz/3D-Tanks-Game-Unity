using Assets.Scripts.Configs;
using UnityEngine;

namespace Assets.Scripts.Infrasctucture.Core
{
    public interface IAssetsProvider
    {
        BattleRulesConfig GetBattleSessionConfig();
        GameObject GetMessagesUiPrefab();
        GameObject GetTankPrefab();
        GameObject GetTankExplosionPrefab();
        LocalInputSchemesConfig GetLocalInputSchemesConfig();
    }
}
