using UnityEngine;

namespace Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "BattleRulesConfig", menuName = "Configs/BattleRulesConfig")]
    public class BattleRulesConfig : ScriptableObject
    {
        public int NumRoundsToWin => numRoundsToWin;
        public float StartDelay => _startDelay;
        public float EndDelay => _endDelay;

        [SerializeField] private int numRoundsToWin = 5;
        [SerializeField] private float _startDelay = 3f; 
        [SerializeField] private float _endDelay = 3f; 
    }
}
