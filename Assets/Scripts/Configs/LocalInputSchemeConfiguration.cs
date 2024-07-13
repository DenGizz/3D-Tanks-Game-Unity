using System;
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
