using UnityEngine;

namespace Assets.Scripts.Infrastructure.Gameplay.Configs
{
    [CreateAssetMenu(fileName = "ScenesConfig", menuName = "Configs/ScenesConfig")]
    public class ScenesConfig : ScriptableObject
    {
        public string BattleFieldSceneName => _battleFieldSceneName;

        [SerializeField] private string _battleFieldSceneName;
    }
}