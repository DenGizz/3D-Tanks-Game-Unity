using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "LocalInputSchemesConfig", menuName = "Configs/Input/LocalInputSchemesConfig")]
    public class LocalInputSchemesConfig : ScriptableObject
    {
        public IEnumerable<LocalInputSchemeConfiguration> LocalInputConfigurations => _localInputConfigurations;

        [SerializeField] private List<LocalInputSchemeConfiguration> _localInputConfigurations;
    }
}