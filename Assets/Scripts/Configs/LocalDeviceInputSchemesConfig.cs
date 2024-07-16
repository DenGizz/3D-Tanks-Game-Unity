using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "LocalDeviceInputSchemesConfig", menuName = "Configs/Input/LocalDeviceInputSchemesConfig")]
    public class LocalDeviceInputSchemesConfig : ScriptableObject
    {
        public IEnumerable<LocalDeviceInputSchemeConfig> LocalDeviceInputConfigurations => _localInputConfigurations;

        [SerializeField] private List<LocalDeviceInputSchemeConfig> _localInputConfigurations;
    }
}