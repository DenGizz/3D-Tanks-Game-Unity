using UnityEngine;

namespace Assets.Scripts.Resources
{
    [CreateAssetMenu(fileName = "UiResourcesBundle", menuName = "Resources/UiResourcesBundle")]
    public class UiResourceBundle : ScriptableObject
    {
        public GameObject MessagesUiPrefab => _messagesUiPrefab;

        [SerializeField] private GameObject _messagesUiPrefab;
    }
}
