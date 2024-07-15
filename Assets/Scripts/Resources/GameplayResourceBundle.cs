using UnityEngine;

namespace Assets.Scripts.Resources
{
    [CreateAssetMenu(fileName = "GameplayResourceBundle", menuName = "Resources/GameplayResourceBundle")]
    public class GameplayResourceBundle : ScriptableObject
    {
        public GameObject TankPrefab => _tankPrefab;
        public GameObject ShellPrefab => _shellPrefab;

        [SerializeField] private GameObject _tankPrefab;
        [SerializeField] private GameObject _shellPrefab;
    }
}
