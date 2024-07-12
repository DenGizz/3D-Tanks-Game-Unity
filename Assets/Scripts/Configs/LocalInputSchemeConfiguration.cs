using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Configs
{
    [Serializable]
    public class LocalInputSchemeConfiguration
    {
        public string MoveAxisName => _verticalAxisName;
        public string TurnAxisName => _horizontalAxisName;
        public string FireButtonName => _fireButtonName;

        [SerializeField] private string _verticalAxisName;
        [SerializeField] private string _horizontalAxisName;
        [SerializeField] private string _fireButtonName;
    }
}
